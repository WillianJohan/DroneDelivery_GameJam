using System;
using UnityEngine;

public class PackageHealth : MonoBehaviour, IDamageable
{
    [SerializeField] uint maxLife = 3;
    [SerializeField] int currentHealth = 3;

    public event Action<int> OnDamage;
    public event Action OnDestroy;

    void Start()
    {
        currentHealth = (int)maxLife;
    }

    public void DealDamage(uint damageAmount)
    {
        currentHealth -= (int)damageAmount;
        HandleOnDamage((int)damageAmount);
        if (currentHealth <= 0)
            HandleOnDie();
    }

    protected virtual void HandleOnDamage(int value) => OnDamage?.Invoke(value);
    protected virtual void HandleOnDie()
    {
        OnDestroy?.Invoke();
        Destroy(gameObject, 0.2f);
    }

}
