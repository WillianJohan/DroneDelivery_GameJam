using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PacketCollector : MonoBehaviour
{
    [Header("Package Collector Info")]
    [SerializeField] bool isPlayerHook = false;
    public Rigidbody2D RigidBodyToAttach;
    List<PackageAttatcher> connectedPackage = new List<PackageAttatcher>();

    [Header("Package Info")]
    [SerializeField] PackageAttatcher myAttatcher;
    [SerializeField] PackageHealth myPackageHealth;

    void Start()
    {
        if (!RigidBodyToAttach)
            TryGetComponent<Rigidbody2D>(out RigidBodyToAttach);

        if (!isPlayerHook && myAttatcher == null)
            TryGetComponent<PackageAttatcher>(out myAttatcher);

        if (!isPlayerHook)
        {
            if(myPackageHealth == null) TryGetComponent<PackageHealth>(out myPackageHealth);
            myPackageHealth.OnDestroy += handlePackageDestroyed;
        }
    }

    private void OnDestroy()
    {
        if (myPackageHealth != null)
            myPackageHealth.OnDestroy -= handlePackageDestroyed;
    }

    private void Update()
    {
        //if (!isPlayerHook) return;
        if(Input.GetKeyUp(KeyCode.Space) && connectedPackage != null) {
            disconnectPackages();
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TryGetComponent<PackageAttatcher>(out PackageAttatcher otherAttatcher);
        if (otherAttatcher != null)
        {
            if (!isPlayerHook)
            {
                if (!myAttatcher.IsAtatched)
                    return;
            }
            
            bool isCollected = otherAttatcher.Connect(RigidBodyToAttach);
            if (isCollected) connectedPackage.Add(otherAttatcher);
        }
    }

    void handlePackageDestroyed()
    {
        disconnectPackages();
    }

    void disconnectPackages()
    {
        for (int i = 0; i < connectedPackage.Count; i++)
            connectedPackage[i]?.Disconnect();
        connectedPackage.Clear();
    }

}
