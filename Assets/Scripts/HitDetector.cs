using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    public bool isPlayer = true;
    public AudioClip[] punchSounds;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

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
                PlayPunchSound();
            }
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Health>().AdjustCurrentHealth(-10);
                PlayPunchSound();
            }
        }
    }
    private void PlayPunchSound()
    {
        var selectedPunchSound = punchSounds[Random.Range(0, punchSounds.Length)];
        _audioSource.clip = selectedPunchSound;
        _audioSource.Play();
    }
}