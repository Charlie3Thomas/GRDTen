using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryDataLoader : MonoBehaviour
{
    [SerializeField] private GameObject crop_data_container;
    [SerializeField] private GameObject calendar;

    public string c_name;
    public string c_code;

    public long GetCropDataInTime(string _crop, int _year)
    {
        Debug.Log(c_name + 
            " produced " + 
            crop_data_container.GetComponent<CropDataContainer>().
                GetDataForCountry(_crop, c_name, _year) +
            " tonnes of " +
            _crop +
            " in the year " +
            _year);

        return crop_data_container.GetComponent<CropDataContainer>().
                GetDataForCountry(_crop, c_name, _year);
    }


    private void Start()
    {
        try { crop_data_container = GameObject.FindGameObjectWithTag("CropData"); }
        catch { Debug.Log("CountryDataLoader: No GameObject with Tag \"CropData\""); }
        try { calendar = GameObject.FindGameObjectWithTag("Calendar"); }
        catch { Debug.Log("CountryDataLoader: No GameObject with Tag \"Calendar\""); }
    }

}
