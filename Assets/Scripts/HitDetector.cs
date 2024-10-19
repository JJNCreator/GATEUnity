using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    public bool isPlayer = true;
   
    private void OnTriggerEnter(Collider other)
    {
        if (isPlayer)
        {
            if (other.CompareTag("Enemy"))
            {
                if (GameManager.Instance.player.isAttacking)
                {
                    other.GetComponent<Health>().AdjustCurrentHealth(-10);
                }
            }
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Health>().AdjustCurrentHealth(-10);
            }
        }
    }
}