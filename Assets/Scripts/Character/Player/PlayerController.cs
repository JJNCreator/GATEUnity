using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public Transform playerCamera;
    public float turnSmoothTime = 0.1f;
    public LayerMask damageLayerMask;
    public Animator animator;
    public bool isAttacking;

    private float turnSmoothVelocity;
    private Rigidbody _rb;
    private bool _characterOnGround = true;
    private Vector2 _currentInputVector;
    private Vector2 _smoothInputVelocity;
    private float _smoothInputSpeed = 0.2f;
    private float cooldownTimer = 0f;
    private float attackFrequency = 2.5f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        cooldownTimer = attackFrequency;
    }

    private void Update()
    {
        if (cooldownTimer >= 0f)
        {
            cooldownTimer -= 1f * Time.deltaTime;
        }
        DamageCharacter();
    }

    private void FixedUpdate()
    {
        _rb.AddForce(Vector3.down * 100f);

        _currentInputVector = Vector2.SmoothDamp(_currentInputVector, UserInput.Instance.MoveInput, 
            ref _smoothInputVelocity, _smoothInputSpeed);
        var direction = new Vector3(_currentInputVector.x, 0f, _currentInputVector.y);

        if (direction.magnitude >= 0.1f)
        {
            var targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            var moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward * moveSpeed;

            _rb.velocity = new Vector3(moveDirection.x, _rb.velocity.y, moveDirection.z) * direction.magnitude;
            animator.SetFloat("Forward", Mathf.Clamp01(direction.z));
        }
        if (UserInput.Instance.JumpPressed && _characterOnGround)
        {
            _rb.AddForce(new Vector3(0f, 5f, 0f) * jumpHeight, ForceMode.Impulse);
            animator.SetBool("Jump", true);
            _characterOnGround = false;
        }
    }

    public void DamageCharacter()
    {
        var ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        var raycastHitInfo = new RaycastHit();
        var raycast = Physics.Raycast(ray, out raycastHitInfo, 5f, damageLayerMask);
        if(UserInput.Instance.AttackPressed)
        {
            animator.SetTrigger(string.Format("Attack{0}", Random.Range(0, 2) == 0 ? "Right" : "Left"));

            if (!isAttacking)
            {
                if (raycast)
                {
                    isAttacking = true;
                    Invoke("ResetAttack", 2f);
                }
            }
        }
        Debug.DrawRay(transform.position, ray.direction);
    }

    private void ResetAttack()
    {
        isAttacking = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _characterOnGround = true;
        animator.SetBool("Jump", false);
    }
}
