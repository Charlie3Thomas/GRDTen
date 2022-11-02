using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsBody : MonoBehaviour
{
    private bool inOrbit = false;
    private GameObject earth;
    private MeshCollider orbit1;

    void Start()
    {
        earth = GameObject.FindGameObjectWithTag("Earth");
        orbit1 = GameObject.FindGameObjectWithTag("Orbit1").GetComponent<MeshCollider>();
        gameObject.layer = LayerMask.NameToLayer("Non-Orbital");
    }

    // Update is called once per frame
    void Update()
    {
        if (inOrbit)
            return;

        if(Vector3.Distance(transform.position, earth.transform.position) > (orbit1.bounds.extents.x / (orbit1.transform.localScale.x / 2)))
        {
            gameObject.layer = LayerMask.NameToLayer("Orbital");
                inOrbit = true;
        }
    }
}
