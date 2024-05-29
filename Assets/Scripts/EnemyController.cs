using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public Transform[] waypoints;
    public bool isPatrolling;
    private NavMeshAgent _navMeshAgent;
    private int destinationPoint = 0;

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        isPatrolling = true;
    }

    // Update is called once per frame
    void Update()
    {
        AIBehaviour();
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
            //TODO: Change to GameManager.Instance.GetPlayer
            _navMeshAgent.SetDestination(target.position);
        }
    }

    private void GoToNextPoint()
    {
        if (waypoints.Length == 0)
            return;

        _navMeshAgent.destination = waypoints[destinationPoint].position;

        destinationPoint = (destinationPoint + 1) % waypoints.Length;
    }
}
