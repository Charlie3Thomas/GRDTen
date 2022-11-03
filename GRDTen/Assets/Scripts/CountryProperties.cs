using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryProperties : MonoBehaviour
{
    [SerializeField] private GameObject outlines;
    private Material outlineMat;
    private bool isHighlighed;
    private float rn;
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        rn = Random.Range(-6.84f, 4.66f);

        if (GetComponent<Renderer>() == null)
            return;

        mat = this.gameObject.GetComponent<Renderer>().material;
        outlineMat = outlines.transform.GetChild(transform.GetSiblingIndex()).GetComponent<Renderer>().material;
        mat.SetFloat("_Temperature", rn);
    }

    void Update()
    {
        if (outlines == null)
            return;

        isHighlighed = ((outlineMat.GetInt("_isHighlighted")) == 1) ? true : false;
    }

    public bool GetHighlighed()
    {
        return isHighlighed;
    }

    public Material GetOutlineMat()
    {
        return outlineMat;
    }
}
