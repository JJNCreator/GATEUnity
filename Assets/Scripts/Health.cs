using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 100;
    public Slider healthBarSlider;
    public Gradient healthBarGradient;
    public bool followPlayerCamera = true;
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
    public void AdjustCurrentHealth(int amount)
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
    }
    private void CheckHealthBarGradient()
    {
        healthBarSlider.fillRect.GetComponent<Image>().color = healthBarGradient.Evaluate(((float)currentHealth / (float)maxHealth));
    }
    public void RegenerateHealth()
    {
        AdjustCurrentHealth(+1);
    }
    private void OnDeath(bool isPlayer)
    {
        if(isPlayer)
        {
            GameManager.Instance.SpawnPlayerRagdoll();
            GameManager.Instance.playerCamera.GetComponent<PlayerCamera>().mouseSensitivityX = 0f;
            GameManager.Instance.playerCamera.GetComponent<PlayerCamera>().mouseSensitivityY = 0f;
            GameUIManager.Instance.ToggleCursor(true);
            GameUIManager.Instance.ToggleGameOverPanel();
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
