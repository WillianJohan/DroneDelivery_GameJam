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
    List<PackageAttatcher> connectedPackage = new List<PackageAttatcher>();

    void Start()
    {
        if (!RigidBodyToAttach)
        {
            TryGetComponent<Rigidbody2D>(out RigidBodyToAttach);
        }

        if (!isPlayerHook && myAttatcher == null)
        {
            TryGetComponent<PackageAttatcher>(out myAttatcher);
        }
    }

    private void Update()
    {
        //if (!isPlayerHook) return;
        if(Input.GetKeyUp(KeyCode.Space) && connectedPackage != null) {
            disconnectPackage();
        }
    }

    void disconnectPackage()
    {
        for(int i = 0; i < connectedPackage.Count; i++)
            connectedPackage[i].Disconnect();
        connectedPackage.Clear();
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

}
