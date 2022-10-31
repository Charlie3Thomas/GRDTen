using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GenerateCountryPrefabs : MonoBehaviour
{
    [SerializeField] private TextAsset txt_input;
    [SerializeField] private string[] data;
    [SerializeField] private CountryList country_list = new CountryList();

    [System.Serializable]
    private class Country
    {
        public string c_code;
        public string c_name;
    }

    [System.Serializable]
    private class CountryList
    {
        public Country[] country;
    }

    private void ReadCountries()
    {
        data = txt_input.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        //Debug.Log(data.Length);
        int num_countries = data.Length / 2;
        country_list.country = new Country[num_countries];

        for (int i = 0; i < num_countries; i++)
        {
            country_list.country[i] = new Country();
            country_list.country[i].c_code = data[(2 * i)];
            country_list.country[i].c_name = data[(2 * i) + 1];
        }
    }

    public void SaveCountry()
    {



        //string local_path = "Assets/Prefabs/Countries/" + CountryDataLoader.c_name + ".prefab"; // define asset path        
        //local_path = AssetDatabase.GenerateUniqueAssetPath(local_path); // ensure unique file name
        //PrefabUtility.SaveAsPrefabAssetAndConnect(CountryDataLoader, local_path, InteractionMode.UserAction); // create prefab

    }

    private void Start()
    {
        ReadCountries();
    }
}
