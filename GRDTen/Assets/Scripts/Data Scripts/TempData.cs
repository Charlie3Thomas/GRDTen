using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempData : MonoBehaviour
{
    [SerializeField] private TextAsset temp_data;

    private Dictionary<string,
            Dictionary<int, float>> temps = 
        new Dictionary<string, 
            Dictionary<int, float>>();

    private void ReadCSVTemp()
    {
        string[] data = temp_data.text.Split(new string[] { ",", "\n"}, System.StringSplitOptions.None);
        int table_size = data.Length / 4;

        for (int i = 1; i < table_size; i++)
        {
            string td_entity = data[(4 * i) + 0];
            int td_year = Int32.Parse(data[(4 * i) + 2]);
            float td_temp = float.Parse(data[(4 * i) + 3]);

            if (!temps.ContainsKey(td_entity))
            {
                temps[td_entity] = new Dictionary<int, float>();
            }

            temps[td_entity][td_year] = td_temp;
        }
    }

    private void OnEnable()
    {
        ReadCSVTemp();
        Debug.Log(GetDataForCountry("Rwanda", 2011));
    }

    public float GetDataForCountry(string _country, int _year)
    {
        return temps[_country][_year];
    }

}
