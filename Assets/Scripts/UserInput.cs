using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static UserInput Instance;

    public Vector2 MoveInput { get; private set; }
    public bool JumpPressed { get; private set; }
    public bool PausedPressed { get; private set; }
    public Vector2 LookInput { get; private set; }
    public bool AttackPressed { get; private set; }

    private PlayerInput _playerInput;

    private InputAction _moveAction;
    private InputAction _jumpAction;
    private InputAction _pauseAction;
    private InputAction _lookAction;
    private InputAction _attackAction;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        _playerInput = GetComponent<PlayerInput>();
        SetupInputActions();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInputs();
    }
    private void SetupInputActions()
    {
        _moveAction = _playerInput.actions.FindAction("Movement");
        _pauseAction = _playerInput.actions.FindAction("Pause");
        _jumpAction = _playerInput.actions.FindAction("Jumping");
        _lookAction = _playerInput.actions.FindAction("Look");
        _attackAction = _playerInput.actions.FindAction("Attack");
    }
    private void UpdateInputs()
    {
        MoveInput = _moveAction.ReadValue<Vector2>();
        JumpPressed = _jumpAction.WasPressedThisFrame();
        PausedPressed = _pauseAction.WasPressedThisFrame();
        LookInput = _lookAction.ReadValue<Vector2>();
        AttackPressed = _attackAction.WasPressedThisFrame();
    }
}
