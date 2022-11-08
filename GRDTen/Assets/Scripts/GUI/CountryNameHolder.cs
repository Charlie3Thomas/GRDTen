using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryNameHolder : MonoBehaviour
{
    public static CountryNameHolder _INSTANCE;
    public string selected_country_name = "none";

    private void Awake()
    {
        if (_INSTANCE != null)
            Destroy(this.gameObject);
        else
            _INSTANCE = this;
    }
}
