using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountryProperties : MonoBehaviour
{
    [SerializeField] private GameObject outlines;
    [SerializeField] private TempData td;
    private Material outlineMat;
    [SerializeField] private bool inMenu;
    private bool isHighlighed;
    private Material mat;
    private float rn;
    private bool harvested = false;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Renderer>() == null)
            return;

        mat = this.gameObject.GetComponent<Renderer>().material;
        outlineMat = outlines.transform.GetChild(transform.GetSiblingIndex()).GetComponent<Renderer>().material;

        if(inMenu)
        {
            rn = Random.Range(-6.84f, 4.66f);
            mat.SetFloat("_Temperature", rn);
        }
    }

    void Update()
    {
        if (outlines == null)
            return;

        isHighlighed = ((outlineMat.GetInt("_isHighlighted")) == 1) ? true : false;
    }

    private void FixedUpdate()
    {
        if (inMenu)
            return;

        mat.SetFloat("_Temperature", GetTemp());
    }

    public bool GetHighlighed()
    {
        return isHighlighed;
    }

    public Material GetOutlineMat()
    {
        return outlineMat;
    }

    public float GetTemp()
    {
        if (transform.childCount > 0)
        {
            float temp = td.GetDataForCountry(transform.GetChild(0).name, Calendar.instance.year);
            return temp;
        }
        else
        {
            return -99f;
        }
    }

    public void SetHarvest(bool isHarvested)
    {
        harvested = isHarvested;
    }

    public bool GetHarvest()
    {
        return harvested;
    }
}
