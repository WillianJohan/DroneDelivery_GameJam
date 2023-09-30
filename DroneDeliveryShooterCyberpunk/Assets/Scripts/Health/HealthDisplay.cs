using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealthDisplay : MonoBehaviour
{
    enum HealthVisibility { Always, OnDamage }

    [SerializeField] HealthVisibility visibility = HealthVisibility.Always;
    [SerializeField] Health health = null;
    
    [Header("HealthDisplay Components")]
    [SerializeField] Transform HealthBarParent;
    [SerializeField] Image healthBar;
    [SerializeField] Image healthBarLerpFill;
    [SerializeField] float fillSpeed = 10.0f;

    private void Start()
    {
        health.OnHealthUpdated += HandleHealthUpdated;
        ConfigHealthBarVisibility();
    }
    private void OnDestroy()
    {
        health.OnHealthUpdated -= HandleHealthUpdated;
        health.OnHealthUpdated -= UpdateHealthBarVisibility;
    }

    private void LateUpdate()
    {
        healthBarLerpFill.fillAmount = 
            Mathf.Lerp(
                healthBarLerpFill.fillAmount, 
                healthBar.fillAmount, 
                fillSpeed * Time.deltaTime
                );
    }

    protected virtual void HandleHealthUpdated(int currentHealth, int maxHealth)
    { 
        healthBar.fillAmount = (float) currentHealth / maxHealth;
    }

    #region HealthBar Visibility

    void ConfigHealthBarVisibility()
    {
        switch (visibility)
        {
            case HealthVisibility.Always:
                ActiveHealthBar();
                break;
            case HealthVisibility.OnDamage:
                HealthBarParent.gameObject.SetActive(false);
                health.OnHealthUpdated += UpdateHealthBarVisibility;
                break;
        }
    }
    
    void UpdateHealthBarVisibility(int currentHealth, int maxHealth)
    {
        bool healthBarActiveStatus = healthBar.gameObject.active;
        if (currentHealth == maxHealth && healthBarActiveStatus)
            DisableHealthBar();
        else if (currentHealth < maxHealth && !healthBarActiveStatus)
            ActiveHealthBar();
    }

    void ActiveHealthBar() => HealthBarParent.gameObject.SetActive(true);
    void DisableHealthBar() => HealthBarParent.gameObject.SetActive(false);

    #endregion
}
