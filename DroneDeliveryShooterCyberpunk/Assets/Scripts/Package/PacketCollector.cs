using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PacketCollector : MonoBehaviour
{
    [SerializeField] bool isPlayerHook = false;
    public Rigidbody2D RigidBodyToAttach;
    
    [SerializeField] PackageAttatcher myAttatcher;

    // public PackageAttatcher AllCollected;

    void Start()
    {
        if (!RigidBodyToAttach)
        {
            TryGetComponent<Rigidbody2D>(out RigidBodyToAttach);
        }
    }

    private void Update()
    {
        // if(Input.GetKeyUp(KeyCode.Space) && isPlayerHook) {
        //     PackageAttatcher pk = AllCollected.Last();
        //     pk.
        // }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TryGetComponent<PackageAttatcher>(out PackageAttatcher otherAttatcher);
        if (otherAttatcher != null)
        {
            if (!isPlayerHook)
            {
                if (!myAttatcher.IsAtatched)
                    return;
            }
            
            bool isCollected = otherAttatcher.Attach(RigidBodyToAttach);
            // if (isCollected) AllCollected.Add(attatcher);
        }
    }

}
