using DG.Tweening;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Direction
{
    Left, Right, Up, Down,None,
}
public enum Lane
{
    Left, Mid, Right
}
public class PlayerMovement : NetworkBehaviour
{
 
    [Header("Rigi")]
    [SerializeField] private Rigidbody rb;

    [Header("Input Action")]
    [SerializeField] private InputAction inputMove;
    [SerializeField] private InputAction inputDuck;
    [SerializeField] private InputAction inputJump;

    [Header("Move")]
    public float speed = 5f;
    [SerializeField] private Lane lanePlayer = Lane.Mid;
    private float distanceMoveX = 1.25f;

    private Vector3 targetPos;
    private Vector2 targetCurrent;
    private Direction targetDir = Direction.None;

    private bool IsProcessing;
    private bool _isJump = false;
    private bool _isGround = true;

    public bool IsJump
    {
        get { return _isJump; }
        set { _isJump = value; }
    }
    public bool IsGround
    {
        get { return _isGround; }
        set { _isGround = value; }
    }

    private void Awake()
    {
        IsProcessing = false;
        _isGround = true;

        //input System
        inputMove = PlayerController.Instance.InputActions.FindAction("Move");
        inputJump = PlayerController.Instance.InputActions.FindAction("Jump");
        inputDuck = PlayerController.Instance.InputActions.FindAction("Sprint");
    }

    void Update()
    {
        MovePlayer();
        /*if (IsOwner)
        {
            MovePlayer();
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 10);
        }*/
    }

    public void MovePlayer()
    {
        if (!InGameManager.Instance.IsStartRun) return; 
        if(InGameManager.Instance.IsEndGame) return;

        //pc
        InputMovePCMouse();
        InputMovePCKeyBoard();
        //mobile
        InputMoveMobile();

        MovePlayerByLane();

        SendPositionServerRpc(transform.position);
    }
    public void InputMoveMobile()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == UnityEngine.TouchPhase.Began)
            {
                targetCurrent = touch.position;
            }
            else if(touch.phase == UnityEngine.TouchPhase.Moved)
            {
                ProcessingPositionInput(touch.position);
            }
            else if(touch.phase == UnityEngine.TouchPhase.Ended)
            {
                IsProcessing = false;
            }
        }
    }
    public void InputMovePCMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetCurrent = Input.mousePosition;
        }
        if(Input.GetMouseButton(0))
        {
            ProcessingPositionInput(Input.mousePosition);
        }
        if(Input.GetMouseButtonUp(0))
        {
            IsProcessing = false;
        }
    }
    public void InputMovePCKeyBoard()
    {
        if (IsProcessing) return;

        Vector2 vc = inputMove.ReadValue<Vector2>();

        if(vc.x > 0)
        {
            targetDir = Direction.Right;
            IsProcessing = true;
        }
        if(vc.x < 0)
        {
            targetDir = Direction.Left;
            IsProcessing = true;
        }

        if(inputJump.WasPressedThisFrame())
        {
            targetDir = Direction.Up;
            IsProcessing = true;
        }

        if(inputDuck.WasPressedThisFrame())
        {
            targetDir = Direction.Down;
            IsProcessing = true;
        }
        //
        if (IsProcessing)
        { 
            ProcessingMove(targetDir);
            DOVirtual.DelayedCall(0.5f,()=>IsProcessing = false);
        }
    }

    public void ProcessingPositionInput(Vector2 pos)
    {
        if (IsProcessing) return;

        Vector2 dir = pos - targetCurrent;

        float distance = Vector2.Distance(targetCurrent, pos);

        if (distance < 20f) return;

        dir = dir.normalized;
        IsProcessing = true;

        if (Mathf.Abs(dir.y) > Mathf.Abs(dir.x))
        {
            if (dir.y > 0)
                targetDir = Direction.Up;
            else
                targetDir = Direction.Down;
        }
        else
        {
            if (dir.x > 0)
                targetDir = Direction.Right;
            else
                targetDir = Direction.Left;
        }
        Debug.Log(targetDir);
        ProcessingMove(targetDir);
    }
    public void ProcessingMove(Direction dir)
    {
        switch(dir)
        {
            case Direction.Right:
                MoveLR(Direction.Right);
                break;
            case Direction.Left:
                MoveLR(Direction.Left);
                break;
            case Direction.Up:
                MoveUpAndDown(1);
                break;
            case Direction.Down:
                MoveUpAndDown(-1);
                break;
            case Direction.None:
                break;
        }
    }
    public void MoveLR(Direction dir)
    {
        MoveLeftAndRight(dir);
    }
    public void MoveLeftAndRight(Direction dir)
    {
        if (dir == Direction.Left)
        {
            if(lanePlayer == Lane.Left)
            {
                return;
            }
            else if(lanePlayer == Lane.Mid)
            {
                lanePlayer = Lane.Left;
                PlayerController.Instance.PlayerAnim.PlayLeft();
            }
            else if(lanePlayer == Lane.Right)
            {
                lanePlayer = Lane.Mid;
                PlayerController.Instance.PlayerAnim.PlayLeft();
            }
        }
        else if(dir == Direction.Right)
        {
            if(lanePlayer == Lane.Right)
            {
                return;
            }
            else if(lanePlayer == Lane.Mid)
            {
                lanePlayer = Lane.Right;
                PlayerController.Instance.PlayerAnim.PlayRight();
            }
            else if(lanePlayer == Lane.Left)
            {
                lanePlayer = Lane.Mid;
                PlayerController.Instance.PlayerAnim.PlayRight();
            }
        }

        ObserverManager<ActionCamera>.PostEven(ActionCamera.LeftRight, dir);
    }
    public void MoveUpAndDown(int dir)
    {
        if(dir == 1)
        {
            if (!_isGround) return;
            _isGround = false;
            _isJump = true;

            //StartAnimation
            PlayerController.Instance.PlayerAnim.PlayJump();

            rb.AddForce(Vector3.up * 20f, ForceMode.Impulse);
        }
        else
        {
            if(IsJump)
            {
                Vector3 pos = transform.position;
                pos.y  = 0f;

                //StartAnimation
                PlayerController.Instance.PlayerAnim.EndJump();

                transform.DOMove(pos, 0.2f).OnComplete(() =>
                {

                });
            }
            else
            {
                PlayerController.Instance.PlayerAnim.PlayDuck();
            }
        }
    }

    public void MovePlayerByLane()
    {
        float targetX = 0f;

        switch (lanePlayer)
        {
            case Lane.Left:
                targetX = -distanceMoveX;
                break;
            case Lane.Mid:
                targetX = 0f;
                break;
            case Lane.Right:
                targetX = distanceMoveX;
                break;
        }

        Vector3 pos = transform.position;

        pos.x = Mathf.MoveTowards(pos.x, targetX, speed * Time.deltaTime);

        transform.position = pos;

    }
    
    //Server
    [ServerRpc]
    void SendPositionServerRpc(Vector3 pos)
    {
        UpdatePositionClientRpc(pos);
    }

    [ClientRpc]
    void UpdatePositionClientRpc(Vector3 pos)
    {
        if (IsOwner) return;
        targetPos = pos;
    }
}