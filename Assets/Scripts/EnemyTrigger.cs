using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public EnemyController associatedEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            associatedEnemy = other.GetComponent<EnemyController>();
        }
        if(other.CompareTag("Player"))
        {
            associatedEnemy.isPatrolling = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            associatedEnemy.isPatrolling = true;
        }
    }
}
