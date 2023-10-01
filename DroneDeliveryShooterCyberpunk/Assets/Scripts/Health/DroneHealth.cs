using System;
using UnityEngine;

public class DroneHealth : MonoBehaviour, IDamageable
{
    public event Action<int> OnDamage;
    [SerializeField] AudioSource droneAudioHitSource;

    public virtual void DealDamage(uint damageAmount)
    {
        Debug.Log("Drone HIT! " + damageAmount);
        HandleOnDamage((int)damageAmount);
    }

    protected virtual void HandleOnDamage(int value)
    {
        if(droneAudioHitSource != null)
            droneAudioHitSource.Play();

        OnDamage?.Invoke(value);
    }
}
