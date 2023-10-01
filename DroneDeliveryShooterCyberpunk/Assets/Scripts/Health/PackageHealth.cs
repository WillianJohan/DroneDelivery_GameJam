using System;
using Unity.VisualScripting;
using UnityEngine;

public class PackageHealth : MonoBehaviour, IDamageable
{
    [SerializeField] uint maxLife = 3;
    [SerializeField] int currentHealth = 3;

    
    [SerializeField] Sprite[] packageHealthStages = new Sprite[3];
    [SerializeField] SpriteRenderer graphic;

    public event Action<int> OnDamage;
    public event Action OnDestroy;

    void Start()
    {
        currentHealth = (int)maxLife;
        setGraphic();
    }

    public void DealDamage(uint damageAmount)
    {
        Debug.Log("Package HIT! " + damageAmount);
        currentHealth -= (int)damageAmount;
        HandleOnDamage((int)damageAmount);
        if (currentHealth <= 0)
            HandleOnDie();
    }

    void setGraphic()
    {
        if (graphic == null) return;
        graphic.sprite = packageHealthStages[Mathf.Clamp(currentHealth, 0, 2)];
    }

    protected virtual void HandleOnDamage(int value)
    {
        setGraphic();
        OnDamage?.Invoke(value);
    }

    protected virtual void HandleOnDie()
    {
        OnDestroy?.Invoke();
        Destroy(gameObject, 0.2f);
    }

}
