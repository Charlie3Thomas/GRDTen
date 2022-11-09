using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayGUITemp : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI slider_text;

    private void Update()
    {
        slider.value = CountryTempHolder._INSTANCE.selected_country_temp;
        slider_text.text = CountryTempHolder._INSTANCE.selected_country_temp.ToString() + "°C";
    }
}
