using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageAttatcher : MonoBehaviour
{
    [SerializeField] Rigidbody2D packageRigidBody;
    [SerializeField] SpringJoint2D springJoint2D;
    
    public bool isAtatched
    {
        get { return (springJoint2D != null && springJoint2D.connectedBody != null);}
    } 


    private void Start()
    {
        if(packageRigidBody == null)
            packageRigidBody = GetComponent<Rigidbody2D>();
        
        // registra os eventos de morte do drone
    }

    private void OnDestroy()
    {
        // remove eventos
    }


    public bool Attach(Rigidbody2D rbToAttatch)
    {
        if (springJoint2D.connectedBody == null)
        {
            Debug.Log("Attatched!!");
            springJoint2D.connectedBody = rbToAttatch;
            return true;
        }
        return false;
    }

}
