using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CountryMatchUp : MonoBehaviour
{
    [SerializeField] private GameObject globe;
    [SerializeField] private GameObject data;

    private Transform[] globe_country_models;
    private CountryDataLoader[] data_country_prefabs;

    private void Start()
    {
        globe_country_models = globe.GetComponentsInChildren<Transform>();
        data_country_prefabs = data.GetComponentsInChildren<CountryDataLoader>();
        for (int i = 0; i < globe_country_models.Length; i++) // Loop through all Globe children
        {
            if(globe_country_models[i].name.Length == 3) // Only perform checks on Globe children with 3 letter names (iso3)
            {
                //Debug.Log(globe_country_models[i].name);
                for (int j = 0; j < data_country_prefabs.Length; j++) // For every country data object
                {
                    //Debug.Log(data_country_prefabs[j].c_code);

                    if (globe_country_models[i].name == data_country_prefabs[j].c_code)
                    {
                        //Debug.Log("Match");
                        data_country_prefabs[j].transform.parent = globe_country_models[i].transform;
                    }
                }
            }
        }
    }
}
