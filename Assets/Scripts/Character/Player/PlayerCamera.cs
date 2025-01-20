using UnityEngine;
using UnityEngine.Rendering;

public class PlayerCamera : MonoBehaviour
{
    public Transform target;
    public float inputX;
    public float inputY;
    public float mouseSensitivityX = 3f;
    public float mouseSensitivityY = 3f;
    public float distanceFromTarget = 3f;
    public bool xInverted;
    public bool yInverted;
    [SerializeField] private Volume _motionBlurVolume;

    private float rotationY;
    private float rotationX;
    private Vector3 CurrentRotation;
    private Vector3 SmoothVelocity;
    private float SmoothTime = 0.2f;
    private Transform _transformCache;

    private void OnEnable()
    {
        EventDelegates.onGamePaused += OnPausedGame;
        EventDelegates.onGameOver += FreezeMovement;
    }
    private void OnDisable()
    {
        EventDelegates.onGamePaused -= OnPausedGame;
        EventDelegates.onGameOver -= FreezeMovement;
    }

    private void Awake()
    {
        _transformCache = transform;
    }
    private void Start()
    {
        SetSettings();
    }
    private void LateUpdate()
    {
        float mouseX = UserInput.Instance.LookInput.x * mouseSensitivityX * ((!xInverted) ? -1f : 1f);
        float mouseY = UserInput.Instance.LookInput.y * mouseSensitivityY * ((!yInverted) ? -1f : 1f);
        rotationY += mouseX;
        rotationX += mouseY;
        rotationX = Mathf.Clamp(rotationX, -40f, 40f);
        var nextRotation = new Vector2(rotationX, rotationY);
        CurrentRotation = Vector3.SmoothDamp(CurrentRotation, nextRotation, ref SmoothVelocity, SmoothTime);
        _transformCache.eulerAngles = CurrentRotation;
        if (target != null)
        {
            _transformCache.position = target.position - _transformCache.forward * distanceFromTarget;
        }
    }
    private void OnPausedGame(bool b)
    {
        if (b == false)
        {
            SetSettings();
        }
    }
    private void SetSettings()
    {
        mouseSensitivityX = GameSettings.XSensitivity;
        mouseSensitivityY = GameSettings.YSensitivity;
        xInverted = GameSettings.XInverted;
        yInverted = GameSettings.YInverted;
        _motionBlurVolume.weight = (GameSettings.MotionBlur) ? 1f : 0f;
    }
    private void FreezeMovement()
    {
        mouseSensitivityX = 0f;
        mouseSensitivityY = 0f;
    }
}
