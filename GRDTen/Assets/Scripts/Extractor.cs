using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extractor : MonoBehaviour
{
    public static Extractor instance { get; private set; }

    [SerializeField] private PhysicsLauncher pl;
    private float d_timer = 0.0f;

    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    private void Update()
    {
        d_timer += Time.deltaTime;

        if (d_timer >= 10.0f)
            Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.CompareTag("Model"))
        {
            if(other.transform.GetComponent<CountryProperties>().GetHighlighed())
                Instantiate(pl.transform.gameObject, other.contacts[0].point, Quaternion.FromToRotation(transform.up, other.contacts[0].normal));
        }

        Destroy(gameObject);
    }
}
