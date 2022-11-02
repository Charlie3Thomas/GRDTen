using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPhysicsLauncher : MonoBehaviour
{
    [SerializeField] private PhysicsLauncher pl;

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.CompareTag("Model"))
            Instantiate(pl.transform.gameObject, other.contacts[0].point, Quaternion.FromToRotation(transform.up, other.contacts[0].normal));

        Destroy(gameObject);
    }
}
