using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAudio : MonoBehaviour
{
    public AudioClip[] deathSounds;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        var selectedDeathSound = deathSounds[Random.Range(0, deathSounds.Length)];
        _audioSource.clip = selectedDeathSound;
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
