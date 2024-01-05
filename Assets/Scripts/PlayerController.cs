using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Transform camera;
    public float turnSmoothTime = 0.1f;
    public InputActions inputActions;

    private float turnSmoothVelocity;
    private Rigidbody _rb;
    private float _horizontalInput;
    private float _verticalInput;
    private Vector2 _movementVector;

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
        inputActions.Player.CameraRotateX.performed += OnCameraRotateX;
        inputActions.Player.CameraRotateY.performed += OnCameraRotateY;
    }

    private void FixedUpdate()
    {
        _rb.AddForce(Vector3.down * 100f);

        var direction = new Vector3(_horizontalInput, 0f, _verticalInput).normalized;

        if (direction.magnitude >= 0.1f)
        {
            var targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            var moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward * moveSpeed;

            _rb.velocity = new Vector3(moveDirection.x, _rb.velocity.y, moveDirection.z);
        }
    }
    #region Input
    public void OnMovement(CallbackContext ctx)
    {
        _movementVector = ctx.ReadValue<Vector2>();

        _horizontalInput = _movementVector.x;
        _verticalInput = _movementVector.y;
    }
    public void OnCameraRotateX(CallbackContext ctx)
    {
        var getX = ctx.ReadValue<float>();
        GameManager.Instance.playerCamera.GetComponent<PlayerCamera>().inputX = getX;
    }
    public void OnCameraRotateY(CallbackContext ctx)
    {
        var getY = ctx.ReadValue<float>();
        GameManager.Instance.playerCamera.GetComponent<PlayerCamera>().inputY = getY;
    }
    #endregion
}
