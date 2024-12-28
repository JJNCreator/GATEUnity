using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private Collider _enteredCollider;
    [SerializeField]private bool _isApplyingDamage = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_isApplyingDamage)
        {
            if(_enteredCollider != null)
            {
                _enteredCollider.GetComponent<Health>().AdjustCurrentHealth(-1);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            _enteredCollider = other;
            _isApplyingDamage = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            _isApplyingDamage = false;
            _enteredCollider = null;
        }
    }
}
