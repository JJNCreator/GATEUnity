using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public Transform[] waypoints;
    public bool isPatrolling;
    public LayerMask damageLayerMask;
    public Animator animator;
    private NavMeshAgent _navMeshAgent;
    private int destinationPoint = 0;
    private float cooldownTimer = 0f;
    private float attackFrequency = 5f;

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        isPatrolling = true;
        cooldownTimer = attackFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        AIBehaviour();

        if(cooldownTimer >= 0f)
        {
            cooldownTimer -= 1f * Time.deltaTime;
        }
        if (cooldownTimer <= 0f)
        {
            DamagePlayer();

        }
    }

    private void AIBehaviour()
    {
        if(isPatrolling)
        {
            if(!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.5f)
            {
                GoToNextPoint();
            }
        }
        else
        {
            _navMeshAgent.SetDestination(GameManager.Instance.player.transform.position);
        }
        animator.SetFloat("Forward", Mathf.Clamp01(_navMeshAgent.velocity.magnitude));
    }

    private void GoToNextPoint()
    {
        if (waypoints.Length == 0)
            return;

        _navMeshAgent.destination = waypoints[destinationPoint].position;

        destinationPoint = (destinationPoint + 1) % waypoints.Length;
    }
    private void DamagePlayer()
    {
        var ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        var raycastHitInfo = new RaycastHit();
        var raycast = Physics.Raycast(ray, out raycastHitInfo, 5f, damageLayerMask);
        if (raycast)
        {
            animator.SetTrigger(string.Format("Attack{0}", Random.Range(0, 2) == 0 ? "Right" : "Left"));
            raycastHitInfo.collider.GetComponent<Health>().AdjustCurrentHealth(-5);
            cooldownTimer = attackFrequency;
        }
        Debug.DrawRay(transform.position, ray.direction);
    }
}
