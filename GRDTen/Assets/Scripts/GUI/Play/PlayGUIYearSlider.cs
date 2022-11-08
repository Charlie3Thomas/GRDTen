using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayGUIYearSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI slider_text;

    private void Update()
    {
        slider.value = Calendar.instance.year - 1961;
        slider_text.text = Calendar.instance.year.ToString();
    }

    private void Start()
    {
        slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        //Debug.Log("                   " + Calendar.instance.year);
        slider.value = Calendar.instance.year - 1961;
        slider_text.text = Calendar.instance.year.ToString();
    }

    private void ValueChangeCheck()
    {
        //Debug.Log(slider.value);
        Calendar.instance.year = ((int)slider.value + 1961); // update calendar year
        slider_text.text = Calendar.instance.year.ToString(); // update text to show calendar year
    }

}
