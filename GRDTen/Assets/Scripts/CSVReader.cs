using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml.Serialization;

public class CSVReader : MonoBehaviour
{
    public TextAsset text_asset_data;

    //[System.Serializable]
    //public class TemperatureData
    //{
    //    public string td_entity;
    //    public int td_year;
    //    public int td_median;
    //    public int td_upper;
    //    public int td_lower;
    //}

    [System.Serializable]
    public class CropData
    {
        public string cd_entity;
        public string cd_code;
        public string cd_year;
        public string cd_tonnes;
    }

    [System.Serializable]
    public class CropList
    {
        public CropData[] crop;
    }

    //public TemperatureData temp_data = new TemperatureData();
    public CropList crop_list = new CropList();

    private void ReadCSV(TextAsset _txt_asset)
    {
        string[] data = _txt_asset.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        int table_size = data.Length / 4;
        crop_list.crop = new CropData[table_size];

        for (int i = 0; i < table_size; i++)
        {
            crop_list.crop[i] = new CropData();
            crop_list.crop[i].cd_entity = data[(4 * i)];
            crop_list.crop[i].cd_code = data[(4 * i) + 1];
            crop_list.crop[i].cd_year = data[(4 * i) + 2];
            crop_list.crop[i].cd_tonnes = data[(4 * i) + 3];
        }
    }

    private void Start()
    {
        ReadCSV(text_asset_data);
    }

}
