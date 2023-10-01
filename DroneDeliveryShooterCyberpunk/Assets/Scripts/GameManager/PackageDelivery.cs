using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageDelivery : MonoBehaviour
{

    public event Action OnPackageDelivered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent<PackageAttatcher>(out PackageAttatcher attatcher);
        if(attatcher != null)
        {
            OnPackageDelivered?.Invoke();
            attatcher.PackageRigidBody.gameObject.SetActive(false);
        }
    }


}
