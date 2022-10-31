using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadExel : MonoBehaviour
{
    [SerializeField] private TextAsset text_asset_data;
    [SerializeField] private TMP_InputField text_input;
    [SerializeField] private string s_text;

    private TextMeshProUGUI region;
    private TextMeshProUGUI year;
    private TextMeshProUGUI median_temperature;
    private TextMeshProUGUI upper_temperature;
    private TextMeshProUGUI lower_temperature;

    private void Update()
    {
        s_text = text_input.text;
    }

    private void Search()
    {
        string[] data = text_asset_data.text.Split(new string[] { ",", "\n" }, System.StringSplitOptions.None);

        for (int i = 0; i < data.Length; i++)
        {
            if(s_text == data[i])
            {
                region.text = data[i+1];
                year.text = data[i+2];
                median_temperature.text = data[i+3];
                upper_temperature.text = data[i+4];
                lower_temperature.text = data[i+5];
            }
        }
    }
}
