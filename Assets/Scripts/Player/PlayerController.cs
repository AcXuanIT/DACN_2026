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


    [Header("Input System")]
    [SerializeField] private InputActionAsset inputActions;

    public InputActionAsset InputActions => inputActions;
    public PlayerAnimation PlayerAnim => _playerAnimation;
    public PlayerCollider PlayerCol => _playerCollider;
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Pattern"))
        {
            Debug.Log("Trigger Ground");
            _playerMovement.IsGround = true;
            _playerMovement.IsJump = false;
            _playerAnimation.StartRunTrigger();
        }
    }
}
