using System;
using UnityEngine;

public class DroneHealth : MonoBehaviour, IDamageable
{
    public event Action<int> OnDamage;

    public virtual void DealDamage(uint damageAmount)
    {
        Debug.Log("Drone HIT! " + damageAmount);
        HandleOnDamage((int)damageAmount);
    }

    protected virtual void HandleOnDamage(int value) => OnDamage?.Invoke(value);
}
