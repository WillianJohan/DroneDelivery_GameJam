using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class OnHitDamage : MonoBehaviour
{

    public uint damage;
    public float impactForce = 10.0f;

    //void performDamage()
    //{
    //
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        TryGetComponent<Rigidbody2D>(out Rigidbody2D otherRigidbody);
        if (otherRigidbody != null)
        {
            Vector3 direction = transform.position.DirectionTo(other.transform.position);
            otherRigidbody.velocity = Vector3.zero;
            otherRigidbody.AddForce(direction * impactForce, ForceMode2D.Impulse);
        }
        
        TryGetComponent<IDamageable>(out IDamageable damageble);
        if (damageble != null) damageble.DealDamage(damage);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 direction = transform.position.DirectionTo(other.transform.position);
        other.rigidbody.velocity = Vector3.zero;
        other.rigidbody.AddForce(direction * impactForce, ForceMode2D.Impulse);

        TryGetComponent<IDamageable>(out IDamageable damageble);
        if(damageble != null) damageble.DealDamage(damage);
    }
}
