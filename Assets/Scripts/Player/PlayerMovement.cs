using DG.Tweening;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Direction
{
    Left, Right, Up, Down,None,
}
public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private Rigidbody rb;

    [Header("Input Action")]
    [SerializeField] private InputAction inputMove;
    [SerializeField] private InputAction inputDuck;
    [SerializeField] private InputAction inputJump;

    public float speed = 5f;
    private Vector3 targetPos;
    private float distanceMoveX = 1.25f;

    private Vector2 targetCurrent;
    private Direction targetDir = Direction.None;

    private bool IsProcessing;
    private bool IsMove;
    private bool _isJump = false;
    private bool _isGround = true;

    private int indexPlayer = 0;

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
        IsMove = false;

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
        //pc
        InputMovePCMouse();
        InputMovePCKeyBoard();
        //mobile
        InputMoveMobile();

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
            DOVirtual.DelayedCall(0.2f,()=>IsProcessing = false);
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
                MoveLeftAndRight(1);
                break;
            case Direction.Left:
                MoveLeftAndRight(-1);
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
    public void MoveLeftAndRight(int dir)
    {
        if (IsMove) return;
        if (dir == -1 && indexPlayer == -1) return;
        if (dir == 1 && indexPlayer == 1) return;

        Vector3 movePos = transform.position;
        indexPlayer += dir;
        movePos.x += dir * 1.25f;


        //start animation
        if(IsJump)
        {
            PlayerController.Instance.PlayerAnim.StartJumpLeftRight(dir);
        } else
            PlayerController.Instance.PlayerAnim.StartLeftRight(dir);


        transform.DOMove(movePos, 0.25f).OnComplete(() =>
        {
            Vector3 pos = transform.position;
            if (indexPlayer == 1) pos.x = 1.25f;
            else if (indexPlayer == 0) pos.x = 0f;
            else if (indexPlayer == -1) pos.x = -1.25f;
            transform.position = pos;
            IsMove = false;
        });
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
            PlayerController.Instance.PlayerAnim.StartJump();

            rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
        }
        else
        {
            if(IsJump)
            {
                Vector3 pos = transform.position;
                pos.y  = 0f;

                //StartAnimation
                PlayerController.Instance.PlayerAnim.StartDown();

                transform.DOMove(pos, 0.5f).OnComplete(() =>
                {

                });
            }
            else
            {
                PlayerController.Instance.PlayerAnim.StartDuck();
            }
        }
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