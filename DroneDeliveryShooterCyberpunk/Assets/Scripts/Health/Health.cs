using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable, ICurable
{
    [SerializeField, Min(1)] int maxHealth = 100;
    public int MaxHealth { get => maxHealth; }
    public int CurrentHealth { get; private set; }
    
    public event Action<int, int> OnHealthUpdated;
    public event Action<int> OnDamage;
    public event Action<int> OnHeal;
    public event Action OnDie;

    void Start() => CurrentHealth = MaxHealth;

    public virtual void DealDamage(uint damageAmount)
    {
        //Calculate the life
        CurrentHealth = CurrentHealth - (int)damageAmount;
        
        //Trigger the events
        HandleHealthUpdated();
        HandleOnDamage((int)damageAmount);
        if(CurrentHealth <= 0)
            HandleOnDie();
    }

    public virtual void Heal(uint cureAmount)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + (int)cureAmount, 0, maxHealth);
        HandleHealthUpdated();
        HandleOnHeal((int)cureAmount);
    }


    protected virtual void HandleHealthUpdated()        => OnHealthUpdated?.Invoke(CurrentHealth, maxHealth);
    protected virtual void HandleOnHeal(int value)      => OnHeal?.Invoke(value);
    protected virtual void HandleOnDamage(int value)    => OnDamage?.Invoke(value);
    protected virtual void HandleOnDie()                => OnDie?.Invoke();
}
