using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistributeTemperature : MonoBehaviour
{
    private float rn;
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        rn = Random.Range(-5f, 28f);

        if (GetComponent<Renderer>() == null)
            return;

        mat = this.gameObject.GetComponent<Renderer>().material;
        mat.SetFloat("_Temperature", rn);
        Destroy(this);
    }
}
