using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public EnemyController associatedEnemy;

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
