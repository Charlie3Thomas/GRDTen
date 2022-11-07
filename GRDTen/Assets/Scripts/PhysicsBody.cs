using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsBody : MonoBehaviour
{
    [SerializeField] private GameObject theSuck;
    private Rigidbody rb;
    private bool inOrbit = false;
    private bool getSucked = false;
    private GameObject earth;
    private MeshCollider orbit1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        earth = GameObject.FindGameObjectWithTag("Earth");
        orbit1 = GameObject.FindGameObjectWithTag("Orbit1").GetComponent<MeshCollider>();
        theSuck = GameObject.FindGameObjectWithTag("MotherShip");
        gameObject.layer = LayerMask.NameToLayer("Non-Orbital");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent != null)
        {
            if (Input.GetKeyDown(KeyCode.R) || transform.parent.childCount >= 2500)
            {
                transform.parent = null;
                gameObject.layer = LayerMask.NameToLayer("Collecting");
                getSucked = true;
            }
        }

        if (inOrbit)
            return;

        if(Vector3.Distance(transform.position, earth.transform.position) > 
            (orbit1.bounds.extents.x / (orbit1.transform.localScale.x / 2))
            && gameObject.layer != LayerMask.NameToLayer("Collecting"))
        {
            gameObject.layer = LayerMask.NameToLayer("Orbital");
            inOrbit = true;
        }
    }

    void FixedUpdate()
    {
        if (!getSucked)
            return;

        getSucked = false;

        if (theSuck != null && rb != null)
        {
            rb.velocity = Vector3.zero;
            Vector3 toTheSuck = (theSuck.transform.position - gameObject.transform.position).normalized;
            rb.AddForce(toTheSuck * 4000, ForceMode.Force);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("MotherShip"))
            Destroy(gameObject);
    }
}
