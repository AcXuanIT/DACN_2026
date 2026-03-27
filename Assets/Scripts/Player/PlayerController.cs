using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Function Player")]
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerAnimation _playerAnimation;


    [Header("Input System")]
    [SerializeField] private InputActionAsset inputActions;


    public InputActionAsset InputActions => inputActions;

    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
}
