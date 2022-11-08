using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayGUIYear : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gui_year;

    void LateUpdate()
    {
        if (gui_year != null)
        {
            gui_year.text = Calendar.instance.year.ToString();
        }
    }
}
