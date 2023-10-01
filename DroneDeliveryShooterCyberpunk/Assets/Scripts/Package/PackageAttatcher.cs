using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageAttatcher : MonoBehaviour
{

    bool isAtatched = false;
    public Package package = null;
    

    private void Start()
    {
        // registra os eventos
    }

    private void OnDestroy()
    {
        // remove eventos
    }

    void OnAttach() { }
    void OnDesattach() { }

    public void Attach(Rigidbody packageCollectorRB)
    {
        
    }

}
