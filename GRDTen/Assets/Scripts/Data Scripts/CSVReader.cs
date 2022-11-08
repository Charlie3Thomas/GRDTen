using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml.Serialization;
using Unity.VisualScripting;
using static CSVReader;

public class CSVReader : MonoBehaviour
{
    [SerializeField] private TextAsset text_asset_data;
    [SerializeField] private bool text_asset_is_temp_data = false;
    [SerializeField] private CropList crop_list = new CropList();
    [SerializeField] private TemperatureList temp_list = new TemperatureList();

    [System.Serializable]
    public class TemperatureData
    {
        public string td_entity;
        public string td_year;
        public string td_median;
        public string td_upper;
        public string td_lower;
    }

    [System.Serializable]
    public class TemperatureList
    {
        public TemperatureData[] temps;
    }

    [System.Serializable]
    public class CropData
    {
        public string cd_entity;
        //public string cd_code;
        public string cd_year;
        public string cd_tonnes;
    }

    [System.Serializable]
    public class CropList
    {
        public CropData[] crops;
    }

    private void ReadCSVTemp(TextAsset _txt_asset)
    {
        string[] data = _txt_asset.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        int table_size = data.Length / 6;
        temp_list.temps = new TemperatureData[table_size];

        for (int i = 0; i < table_size; i++)
        {
            temp_list.temps[i] = new TemperatureData();
            temp_list.temps[i].td_entity = data[(6 * i)];
            temp_list.temps[i].td_year = data[(6 * i) + 2];
            temp_list.temps[i].td_median = data[(6 * i) + 3];
            temp_list.temps[i].td_upper = data[(6 * i) + 4];
            temp_list.temps[i].td_lower = data[(6 * i) + 5];
        }

    }
    
    private void ReadCSVCrop(TextAsset _txt_asset)
    {
        string[] data = _txt_asset.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        int table_size = data.Length / 4;
        crop_list.crops = new CropData[table_size];

        for (int i = 0; i < table_size; i++)
        {
            crop_list.crops[i] = new CropData();
            crop_list.crops[i].cd_entity = data[(4 * i)];
            //crop_list.crop[i].cd_code = data[(4 * i) + 1];
            crop_list.crops[i].cd_year = data[(4 * i) + 2];
            crop_list.crops[i].cd_tonnes = data[(4 * i) + 3];
        }
    }

    private void Start()
    {
        if (text_asset_is_temp_data) // is temp data
        {
            ReadCSVTemp(text_asset_data);
        }
        else // is crop data
        {
            ReadCSVCrop(text_asset_data);
        }
    }
}
