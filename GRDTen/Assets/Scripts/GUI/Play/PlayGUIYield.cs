using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayGUIYield : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI slider_text;

    private void Update()
    {
        slider_text.text = CountryYieldHolder._INSTANCE.selected_country_yield.ToString() + " tonnes";
    }
}
