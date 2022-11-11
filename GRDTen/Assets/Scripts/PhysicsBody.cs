using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsBody : MonoBehaviour
{
    [SerializeField] private GameObject theSuck;
    private GameObject collectableManager;
    private Rigidbody rb;
    private bool inOrbit = false;
    private bool getSucked = false;
    private float rn = 0.5f;
    private GameObject earth;
    private MeshCollider orbit1;
    private MeshCollider orbit3;
    private MeshCollider orbit5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        earth = GameObject.FindGameObjectWithTag("Earth");
        orbit1 = GameObject.FindGameObjectWithTag("Orbit1").GetComponent<MeshCollider>();
        orbit3 = GameObject.FindGameObjectWithTag("Orbit3").GetComponent<MeshCollider>();
        orbit5 = GameObject.FindGameObjectWithTag("Orbit5").GetComponent<MeshCollider>();
        theSuck = GameObject.FindGameObjectWithTag("MotherShip");
        collectableManager = GameObject.FindGameObjectWithTag("CollectableManager");
        gameObject.layer = LayerMask.NameToLayer("Non-Orbital");
        AudioManager.Instance.PlayOneShotWithParameters("Pop", transform);
        rn = Random.Range(0.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent != null)
        {
            if (Input.GetKeyDown(KeyCode.R) || transform.parent.childCount >= 1800)
            {
                transform.parent = collectableManager.transform;
                gameObject.layer = LayerMask.NameToLayer("Collecting");
                getSucked = true;
            }
        }

        if (inOrbit)
            return;

        Orbiting();
    }

    void FixedUpdate()
    {
        if (!getSucked)
            return;

        StartCoroutine(Sucking());
    }

    void Orbiting()
    {
        if (transform.localScale.x == 1)
        {
            if (Vector3.Distance(transform.position, earth.transform.position) >
            (orbit1.bounds.extents.x / (orbit1.transform.localScale.x / 2))
            && gameObject.layer != LayerMask.NameToLayer("Collecting"))
            {
                gameObject.layer = LayerMask.NameToLayer("Orbital1");
                inOrbit = true;
            }
        }
        if (transform.localScale.x == 2)
        {
            if (Vector3.Distance(transform.position, earth.transform.position) >
            (orbit3.bounds.extents.x / (orbit3.transform.localScale.x / 2))
            && gameObject.layer != LayerMask.NameToLayer("Collecting"))
            {
                gameObject.layer = LayerMask.NameToLayer("Orbital2");
                inOrbit = true;
            }
        }
        if (transform.localScale.x == 3)
        {
            if (Vector3.Distance(transform.position, earth.transform.position) >
            (orbit5.bounds.extents.x / (orbit5.transform.localScale.x / 2))
            && gameObject.layer != LayerMask.NameToLayer("Collecting"))
            {
                gameObject.layer = LayerMask.NameToLayer("Orbital3");
                inOrbit = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("MotherShip"))
        {
            AudioManager.Instance.PlayOneShotWithParameters("Slurp", transform);
            Destroy(gameObject);
        }
    }

    IEnumerator Sucking()
    {
        yield return new WaitForSeconds(rn);

        getSucked = false;

        if (theSuck != null && rb != null)
        {
            rb.velocity = Vector3.zero;
            Vector3 toTheSuck = (theSuck.transform.position - gameObject.transform.position).normalized;
            rb.AddForce(toTheSuck * 4000, ForceMode.Force);
        }

        yield return null;
    }
}
