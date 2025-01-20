using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 100;
    public Slider healthBarSlider;
    public Gradient healthBarGradient;
    public bool followPlayerCamera = true;
    public AudioClip[] gruntSounds;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        CheckHealthBarGradient();
        InvokeRepeating("RegenerateHealth", 1f, 1f);
    }

    private void Update()
    {
        if(followPlayerCamera)
        {
            var mainCamera = Camera.main.transform;
            healthBarSlider.transform.rotation = Quaternion.LookRotation(
                healthBarSlider.transform.position - mainCamera.transform.position);
        }
    }
    public void AdjustCurrentHealth(int amount, bool didDamage = true)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth < 0)
        {
            currentHealth = 0;
            OnDeath(gameObject.tag == "Player");
        }
        if(healthBarSlider != null)
        {
            healthBarSlider.value = ((float)currentHealth / (float)maxHealth);
            CheckHealthBarGradient();
        }
        if(didDamage)
        {
            PlayGruntSound();
        }
    }
    private void PlayGruntSound()
    {
        var selectedGruntSound = gruntSounds[Random.Range(0, gruntSounds.Length)];
        _audioSource.clip = selectedGruntSound;
        _audioSource.Play();
    }
    private void CheckHealthBarGradient()
    {
        healthBarSlider.fillRect.GetComponent<Image>().color = healthBarGradient.Evaluate((float)currentHealth / (float)maxHealth);
    }
    public void RegenerateHealth()
    {
        AdjustCurrentHealth(+1, didDamage: false);
    }
    private void OnDeath(bool isPlayer)
    {
        if(isPlayer)
        {
            EventDelegates.ExecuteGameOverEvent();
            Destroy(GameManager.Instance.player.gameObject);
        }
        else
        {
            GetComponent<TaskHolder>().CurrentTaskProgress = 100;
            GameManager.Instance.SpawnEnemyRagdoll(transform, 4000).Forget();
            Destroy(gameObject);
        }
    }
}
