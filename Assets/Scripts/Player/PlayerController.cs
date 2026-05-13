using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum StatePlayer
{
    Idle, Build, Run,
}
public class PlayerController : Singleton<PlayerController>
{
    [Header("Function Player")]
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private PlayerCollider _playerCollider;
    [SerializeField] private PlayerCollision _playerCollision;

    [Header("Input System")]
    [SerializeField] private InputActionAsset inputActions;

    public PlayerMovement PlayerMovement => _playerMovement;
    public InputActionAsset InputActions => inputActions;
    public PlayerAnimation PlayerAnim => _playerAnimation;
    public PlayerCollider PlayerCol => _playerCollider;

    public PlayerCollision PlayerCollision => _playerCollision;

    public bool IsHit { get; set; }
    private void Awake()
    {
        IsHit = false;
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            Debug.Log("Trigger Ground");
            if(_playerMovement.IsJump)
            {
                _playerAnimation.PlayRunAfterJump();
            }
            _playerMovement.IsGround = true;
            _playerMovement.IsJump = false;

        }

        if (collision.transform.CompareTag("Player"))
        {
            return;
        }
        if(collision.transform.CompareTag("Pattern"))
            _playerCollision.OnPlayerColliderHit(collision.collider);
    }
}
