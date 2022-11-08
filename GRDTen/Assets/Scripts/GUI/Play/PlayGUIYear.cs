using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayGUIYear : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gui_year;

    void Update()
    {
        gui_year.text = Calendar.instance.year.ToString();
    }
}
