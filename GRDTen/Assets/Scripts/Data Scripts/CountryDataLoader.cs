using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CountryDataLoader : MonoBehaviour
{
    [SerializeField] private GameObject crop_data_container;
    [SerializeField] private GameObject calendar;
    [SerializeField] private TextMeshProUGUI yield_ui;

    public string c_name;
    public string c_code;

    public long GetCropDataInTime(string _crop, int _year)
    {
        Debug.Log(c_name +
            " produced " + crop_data_container.GetComponent<CropDataContainer>().
                                               GetDataForCountry(_crop, c_name, _year) +
            " tonnes of " + _crop +
            " in the year " + _year);

        long crop_yield = crop_data_container.GetComponent<CropDataContainer>().
                GetDataForCountry(_crop, c_name, _year);

        if (crop_yield == -99) // if there is no data show zero
        {
            CountryYieldHolder._INSTANCE.selected_country_yield = 0; 
            return crop_yield;
        }            

        // Show crop yield to the screen
        try { CountryYieldHolder._INSTANCE.selected_country_yield = crop_yield; }
        catch { Debug.Log("Computer says no!"); }

        return crop_yield;
    }


    private void Start()
    {
        try { crop_data_container = GameObject.FindGameObjectWithTag("CropData"); }
        catch { Debug.Log("CountryDataLoader: No GameObject with Tag \"CropData\""); }
        try { calendar = GameObject.FindGameObjectWithTag("Calendar"); }
        catch { Debug.Log("CountryDataLoader: No GameObject with Tag \"Calendar\""); }
        //try { yield_ui = gameobject.findgameobjectwithtag("yield").getcomponent<textmeshprougui>(); }
        //catch { debug.log("computer says no!"); }
    }

}
