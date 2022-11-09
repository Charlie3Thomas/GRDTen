using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayGUICntName : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gui_country_name;

    void Update()
    {
        if (gui_country_name != null)
        {
            gui_country_name.text = CountryNameHolder._INSTANCE.selected_country_name;
        }
    }
}
