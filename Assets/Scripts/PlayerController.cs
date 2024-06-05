using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public Transform playerCamera;
    public float turnSmoothTime = 0.1f;
    public InputActions inputActions;

    private float turnSmoothVelocity;
    private Rigidbody _rb;
    private float _horizontalInput;
    private float _verticalInput;
    private bool _jumpPressed = false;
    private Vector2 _movementVector;
    private bool _characterOnGround = true;
    private Vector2 _currentInputVector;
    private Vector2 _smoothInputVelocity;
    private float _smoothInputSpeed = 0.2f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        inputActions = new InputActions();
        inputActions.Enable();

        inputActions.Player.Movement.performed += OnMovement;
        inputActions.Player.Look.performed += OnLook;
        inputActions.Player.Pause.performed += OnPaused;
        inputActions.Player.Jumping.performed += OnJump;
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void FixedUpdate()
    {
        _rb.AddForce(Vector3.down * 100f);

        _currentInputVector = Vector2.SmoothDamp(_currentInputVector, _movementVector, 
            ref _smoothInputVelocity, _smoothInputSpeed);
        var direction = new Vector3(_currentInputVector.x, 0f, _currentInputVector.y);

        if (direction.magnitude >= 0.01f)
        {
            var targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            var moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            _rb.velocity = new Vector3(moveDirection.x, _rb.velocity.y, moveDirection.z) * direction.magnitude * moveSpeed;
        }
        if(_jumpPressed && _characterOnGround)
        {
            _rb.AddForce(new Vector3(0f, 5f, 0f) * jumpHeight, ForceMode.Impulse);
            _characterOnGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        _characterOnGround = true;
    }
    #region Input
    public void OnMovement(CallbackContext ctx)
    {
        _horizontalInput = ctx.ReadValue<Vector2>().x;
        _verticalInput = ctx.ReadValue<Vector2>().y;

        _movementVector = new Vector2(_horizontalInput, _verticalInput);
    }
    public void OnLook(CallbackContext ctx)
    {
        var vector = ctx.ReadValue<Vector2>();
        GameManager.Instance.playerCamera.GetComponent<PlayerCamera>().inputX = vector.x;
        GameManager.Instance.playerCamera.GetComponent<PlayerCamera>().inputY = vector.y;

    }
    public void OnJump(CallbackContext ctx)
    {
        _jumpPressed = ctx.ReadValueAsButton();
    }
    public void OnPaused(CallbackContext ctx)
    {
        PauseMenuManager.Instance.Paused = ctx.ReadValueAsButton();
    }
    #endregion
}
