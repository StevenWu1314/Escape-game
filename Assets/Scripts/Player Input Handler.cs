using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerControls;
    [SerializeField] private string actionMapName = "Player";
    [SerializeField] private string move = "movement";
    private InputAction moveAction;
    public Vector2 MoveInput {get; private set;}
    public static PlayerInputHandler Instance { get; private set; }
    private void Awake() 
    {
    if (Instance = null) 
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    else 
    {
        Destroy(gameObject);
    }
    moveAction = playerControls.FindActionMap(actionMapName).FindAction(move);
    RegisterInputActions();

    }

    private void RegisterInputActions()
    {
        moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        moveAction.performed += context => MoveInput = Vector2.zero;
    }

    private void OnEnable() {
        moveAction.Enable();
    }
    private void OnDisable() {
        moveAction.Disable();
    }

}
