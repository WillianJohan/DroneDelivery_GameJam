using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PackageHealth))]
public class PackageHitDetector : MonoBehaviour
{

    [SerializeField] float collisionForceForLowDamage= 4.0f;
    [SerializeField] float collisionForceForMediumDamage = 8.0f;
    [SerializeField] float collisionForceForHighDamage = 10.0f;
    
    PackageHealth packageHealth;
    
    private void Start()
    {
        packageHealth = GetComponent<PackageHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude >= collisionForceForHighDamage) packageHealth.DealDamage(3);
        else if (collision.relativeVelocity.magnitude >= collisionForceForMediumDamage) packageHealth.DealDamage(2);
        else if (collision.relativeVelocity.magnitude >= collisionForceForLowDamage) packageHealth.DealDamage(1);
    }

}
