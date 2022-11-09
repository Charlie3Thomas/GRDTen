using Palmmedia.ReportGenerator.Core.Parser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TMPro;
using UnityEditor;
using UnityEngine;


public class CropDataContainer : MonoBehaviour
{
    [SerializeField] private TextAsset[] crop_data_sets;

    private Dictionary<string, TextAsset> cds_dictionary = new Dictionary<string, TextAsset>();

    private Dictionary<string,
            Dictionary<string,
            Dictionary<int, long>>> crops;

    private void PopulateCDSDictionary()
    {
        cds_dictionary.Add("apple", crop_data_sets[0]);
        cds_dictionary.Add("avocado", crop_data_sets[1]);
        cds_dictionary.Add("banana", crop_data_sets[2]);
        cds_dictionary.Add("barley", crop_data_sets[3]);
        cds_dictionary.Add("bean", crop_data_sets[4]);
        cds_dictionary.Add("cashew", crop_data_sets[5]);
        cds_dictionary.Add("cassava", crop_data_sets[6]);
        cds_dictionary.Add("cereal", crop_data_sets[7]);
        cds_dictionary.Add("cocoa bean", crop_data_sets[8]);
        cds_dictionary.Add("coffee bean", crop_data_sets[9]);
        cds_dictionary.Add("grapes", crop_data_sets[10]);
        cds_dictionary.Add("maize", crop_data_sets[11]);
        cds_dictionary.Add("orange", crop_data_sets[12]);
        cds_dictionary.Add("palm oil", crop_data_sets[13]);
        cds_dictionary.Add("pea", crop_data_sets[14]);
        cds_dictionary.Add("potato", crop_data_sets[15]);
        cds_dictionary.Add("rapeseed", crop_data_sets[16]);
        cds_dictionary.Add("rice", crop_data_sets[17]);
        cds_dictionary.Add("rye", crop_data_sets[18]);
        cds_dictionary.Add("seasame", crop_data_sets[19]);
        cds_dictionary.Add("soybean", crop_data_sets[20]);
        cds_dictionary.Add("sugar beet", crop_data_sets[21]);
        cds_dictionary.Add("sugar cane", crop_data_sets[22]);
        cds_dictionary.Add("sunflower seed", crop_data_sets[23]);
        cds_dictionary.Add("sweet potato", crop_data_sets[24]);
        cds_dictionary.Add("tea", crop_data_sets[25]);
        cds_dictionary.Add("tobacco", crop_data_sets[26]);
        cds_dictionary.Add("tomato", crop_data_sets[27]);
        cds_dictionary.Add("wheat", crop_data_sets[28]);
        cds_dictionary.Add("yams", crop_data_sets[29]);
    }

    private void PopulateCropDataContainer()
    {
        crops.Add("apple",          new Dictionary<string, Dictionary<int, long>>());
        crops.Add("avocado",        new Dictionary<string, Dictionary<int, long>>());
        crops.Add("banana",         new Dictionary<string, Dictionary<int, long>>());
        crops.Add("barley",         new Dictionary<string, Dictionary<int, long>>());
        crops.Add("bean",           new Dictionary<string, Dictionary<int, long>>());
        crops.Add("cashew",         new Dictionary<string, Dictionary<int, long>>());
        crops.Add("cassava",        new Dictionary<string, Dictionary<int, long>>());
        crops.Add("cereal",         new Dictionary<string, Dictionary<int, long>>());
        crops.Add("cocoa bean",     new Dictionary<string, Dictionary<int, long>>());
        crops.Add("coffee bean",    new Dictionary<string, Dictionary<int, long>>());
        crops.Add("grapes",         new Dictionary<string, Dictionary<int, long>>());
        crops.Add("maize",          new Dictionary<string, Dictionary<int, long>>());
        crops.Add("orange",         new Dictionary<string, Dictionary<int, long>>());
        crops.Add("palm oil",       new Dictionary<string, Dictionary<int, long>>());
        crops.Add("pea",            new Dictionary<string, Dictionary<int, long>>());
        crops.Add("potato",         new Dictionary<string, Dictionary<int, long>>());
        crops.Add("rapeseed",       new Dictionary<string, Dictionary<int, long>>());
        crops.Add("rice",           new Dictionary<string, Dictionary<int, long>>());
        crops.Add("rye",            new Dictionary<string, Dictionary<int, long>>());
        crops.Add("seasame",        new Dictionary<string, Dictionary<int, long>>());
        crops.Add("soybean",        new Dictionary<string, Dictionary<int, long>>());
        crops.Add("sugar beet",     new Dictionary<string, Dictionary<int, long>>());
        crops.Add("sugar cane",     new Dictionary<string, Dictionary<int, long>>());
        crops.Add("sunflower seed", new Dictionary<string, Dictionary<int, long>>());
        crops.Add("sweet potato",   new Dictionary<string, Dictionary<int, long>>());
        crops.Add("tea",            new Dictionary<string, Dictionary<int, long>>());
        crops.Add("tobacco",        new Dictionary<string, Dictionary<int, long>>());
        crops.Add("tomato",         new Dictionary<string, Dictionary<int, long>>());
        crops.Add("wheat",          new Dictionary<string, Dictionary<int, long>>());
        crops.Add("yams",           new Dictionary<string, Dictionary<int, long>>());
        

    }
    private void ReadCSVCrop(string _key)
    {

        string[] data = cds_dictionary[_key].text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        int table_size = data.Length / 4;
        //Debug.Log(_key + ": " + table_size);

        for (int i = 1; i < table_size - 1; i++)
        {
            string cd_name = data[(4 * i)];
            //Debug.Log(data[(4 * i) + 2]);
            //Debug.Log("              " + _key + cd_name + " " + i);
            int cd_year = Int32.Parse(data[(4 * i) + 2]);
            long cd_tonnes = Int64.Parse(data[(4 * i) + 3]);

            if (!crops[_key].ContainsKey(cd_name))
            {
                crops[_key][cd_name] = new Dictionary<int, long>();
            }

            crops[_key][cd_name][cd_year] = cd_tonnes;
        }
    }

    private void OnEnable()
    {
        //Debug.Log("            Starting CropDataContainer");
        crops = new Dictionary<string,
                    Dictionary<string,
                    Dictionary<int, long>>>();


        PopulateCDSDictionary();
        PopulateCropDataContainer();

        foreach(var key in crops.Keys)
        {
            ReadCSVCrop(key);
        }

        //GetDataForCountry("apple", "Afghanistan", 2000);
    }

    public long GetDataForCountry(string _crop, string _coutnry_name, int _production_year)
    {
        try { return crops[_crop][_coutnry_name][_production_year]; }
        catch { Debug.LogWarning(_coutnry_name + " has no " + _crop + " in the year " + _production_year); return -99; }
        //Debug.Log(data);
    }

    //private void Start()
    //{
        
    //    //GetHighestProductionFor();
    //}

    //public void GetHighestProductionFor(string _crop, string _coutnry_name, int _production_year)
    //{
    //    long higest_prod_value = 0;

    //    Debug.Log(crops[_crop][_coutnry_name][_production_year]);
    //}
}
