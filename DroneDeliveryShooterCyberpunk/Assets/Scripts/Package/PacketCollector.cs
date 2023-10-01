using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacketCollector : MonoBehaviour
{
    public Rigidbody2D RigidBodyToAttach;

    void Start()
    {
        if (!RigidBodyToAttach)
        {
            TryGetComponent<Rigidbody2D>(out RigidBodyToAttach);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        // detecta se o colider representa um pacote
        Debug.Log(collision.gameObject.name);



    }

}
