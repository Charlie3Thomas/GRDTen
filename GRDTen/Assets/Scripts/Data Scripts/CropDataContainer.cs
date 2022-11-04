using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class CropDataContainer : MonoBehaviour
{
    [SerializeField] private CropList country_data = new CropList();
    [SerializeField] private TextAsset[] crop_data_sets; 
    private SortedDictionary<string, CropList> crop_data_container = 
        new SortedDictionary<string, CropList>(); // Really don't reccomend serializing this

    #region Crop Data Containers
    // Also thoroughly advise against serializing these:
        private CropList apple = new CropList();
        private CropList avocado = new CropList();
        private CropList banana = new CropList();
        private CropList barley = new CropList();
        private CropList bean = new CropList();
        private CropList cashew = new CropList();
        private CropList cassava = new CropList();
        private CropList cereal = new CropList();
        private CropList cocoa_bean = new CropList();
        private CropList coffee_bean = new CropList();
        private CropList grapes = new CropList();
        private CropList maize = new CropList();
        private CropList orange = new CropList();
        private CropList palm_oil = new CropList();
        private CropList pea = new CropList();
        private CropList potato = new CropList();
        private CropList rapeseed = new CropList();
        private CropList rice = new CropList();
        private CropList rye = new CropList();
        private CropList seasame = new CropList();
        private CropList soybean = new CropList();
        private CropList sugar_beet = new CropList();
        private CropList sugar_cane = new CropList();
        private CropList sunflower_seed = new CropList();
        private CropList sweet_potato = new CropList();
        private CropList tea = new CropList();
        private CropList tobacco = new CropList();
        private CropList tomato = new CropList();
        private CropList wheat = new CropList();
        private CropList yams = new CropList();
    #endregion Crop Data Containers

    [System.Serializable]
    public class CropData
    {
        public string cd_entity;
        public string cd_year;
        public string cd_tonnes;
    }

    [System.Serializable]
    public class CropList
    {
        public CropData[] crops;
    }

    private void PopulateCropDataContainer()
    {
        crop_data_container.Add("apple", apple);
        crop_data_container.Add("avocado", avocado);
        crop_data_container.Add("banana", banana);
        crop_data_container.Add("barley", barley);
        crop_data_container.Add("bean", bean);
        crop_data_container.Add("cashew", cashew);
        crop_data_container.Add("cassava", cassava);
        crop_data_container.Add("cereal", cereal);
        crop_data_container.Add("cocoa bean", cocoa_bean);
        crop_data_container.Add("coffee bean", coffee_bean);
        crop_data_container.Add("grapes", grapes);
        crop_data_container.Add("maize", maize);
        crop_data_container.Add("orange", orange);
        crop_data_container.Add("palm oil", palm_oil);
        crop_data_container.Add("pea", pea);
        crop_data_container.Add("potato", potato);
        crop_data_container.Add("rapeseed", rapeseed);
        crop_data_container.Add("rice", rice);
        crop_data_container.Add("rye", rye);
        crop_data_container.Add("seasame", seasame);
        crop_data_container.Add("soybean", soybean);
        crop_data_container.Add("sugar beet", sugar_beet);
        crop_data_container.Add("sugar cane", sugar_cane);
        crop_data_container.Add("sunflower seed", sunflower_seed);
        crop_data_container.Add("sweet potato", sweet_potato);
        crop_data_container.Add("tea", tea);
        crop_data_container.Add("tobacco", tobacco);
        crop_data_container.Add("tomato", tomato);
        crop_data_container.Add("wheat", wheat);
        crop_data_container.Add("yams", yams);

    }
    private void ReadCSVCrop(TextAsset _txt_asset, CropList _crop_list)
    {
        string[] data = _txt_asset.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        int table_size = data.Length / 4;
        _crop_list.crops = new CropData[table_size];

        for (int i = 0; i < table_size; i++)
        {
            _crop_list.crops[i] = new CropData();
            _crop_list.crops[i].cd_entity = data[(4 * i)];
            //crop_list.crop[i].cd_code = data[(4 * i) + 1];
            _crop_list.crops[i].cd_year = data[(4 * i) + 2];
            _crop_list.crops[i].cd_tonnes = data[(4 * i) + 3];
        }
    }

    private void Start()
    {
        PopulateCropDataContainer();

        int i = 0;
        foreach(var (key, value) in crop_data_container)
        {
            ReadCSVCrop(crop_data_sets[i++], value);            
        }

        GetDataForCountry("apple", "Afghanistan", "2000");
    }

    public void GetDataForCountry(string _crop, string _coutnry_name, string _production_year)
    {
        foreach (CropData data in crop_data_container[_crop].crops)
        {
            if (data.cd_entity == _coutnry_name && data.cd_year == _production_year)
            {
                Debug.Log(data.cd_tonnes);
            }
        }

        //for (int i = 0; i < crop_data_container.Count; i++) // For each crop type
        //{
        //   for (int j = 0; j < (crop_data_container[i].crops.Length); j++) // For each crop entry
        //    {
        //        if (crop_data_container[i].crops[j].cd_entity == country_name) // If input name equals data entry entity(name)
        //        {
        //            if (crop_data_container[i].crops[j].cd_year == production_year)
        //            {
        //                
        //            }
        //        }
        //    }
        //}

    }
}
