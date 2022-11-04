using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;

public class GenerateCountryPrefabs : MonoBehaviour
{
    [SerializeField] private TextAsset txt_input;
    [SerializeField] private string[] data;
    [SerializeField] private CountryList country_list = new CountryList();
    private int num_countries;

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
        data = txt_input.text.Split(new string[] { ",", "\r\n" }, StringSplitOptions.None);
        //Debug.Log(data.Length);
        num_countries = data.Length / 2;
        country_list.country = new Country[num_countries];

        for (int i = 0; i < num_countries; i++)
        {
            country_list.country[i] = new Country();
            country_list.country[i].c_code = data[(2 * i)];
            country_list.country[i].c_name = data[(2 * i) + 1];
        }
    }

    public void CreatePrefabCountry()
    {
        GameObject prefab_ref
            = (GameObject)AssetDatabase.LoadMainAssetAtPath("Assets/Prefabs/Countries/Source/Country.prefab");

        for (int i = 0; i < num_countries; i++)
        {
            string local_path = "Assets/Prefabs/Countries/" + country_list.country[i].c_name + ".prefab";
            local_path = AssetDatabase.GenerateUniqueAssetPath(local_path);
            GameObject instance_root = (GameObject)PrefabUtility.InstantiatePrefab(prefab_ref);
            // Debug.Log("Country name: " + country_list.country[i].c_name + " Country code: " + country_list.country[i].c_code);
            instance_root.GetComponent<CountryDataLoader>().c_name = country_list.country[i].c_name;
            instance_root.GetComponent<CountryDataLoader>().c_code = country_list.country[i].c_code;
            GameObject pVariant = PrefabUtility.SaveAsPrefabAsset(instance_root, local_path);
            GameObject.DestroyImmediate(instance_root);
        }
    }

    private void Start()
    {
        ReadCountries();
        CreatePrefabCountry();
    }
}
