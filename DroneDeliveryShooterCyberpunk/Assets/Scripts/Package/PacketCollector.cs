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
            RigidBodyToAttach = GetComponent<Rigidbody2D>();
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

}
