using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageAttatcher : MonoBehaviour
{
    [SerializeField] Rigidbody2D packageRigidBody;
    [SerializeField] SpringJoint2D springJoint2D;
    
    public bool IsAtatched
    {
        get { return (springJoint2D != null && springJoint2D.connectedBody != null);}
    } 


    private void Start()
    {
        if (packageRigidBody == null)
            packageRigidBody = GetComponent<Rigidbody2D>();

        //springJoint2D.connectedAnchor = transform.position;
        //springJoint2D.distance = transform.position.y + 1;
        //springJoint2D.autoConfigureDistance = false;
    }

    private void Update()
    {
        //if (!IsAtatched)
        //{
        //    springJoint2D.connectedAnchor = transform.position;
        //    springJoint2D.distance = transform.position.y + 1;
        //}
    }

    public bool Connect(Rigidbody2D rbToAttatch)
    {
        if (springJoint2D.connectedBody == null)
        {
            Debug.Log("Connected!!");
            springJoint2D.connectedBody = rbToAttatch;
            //springJoint2D.autoConfigureDistance = true;
            return true;
        }
        return false;
    }

    public bool Disconnect()
    {
        springJoint2D.connectedBody = null;
        //springJoint2D.distance = transform.position.y + 1;
        //springJoint2D.autoConfigureDistance = false;
        Debug.Log("Desconected!!");
        return true;
    }

}
