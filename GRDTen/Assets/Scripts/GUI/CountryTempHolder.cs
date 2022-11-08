using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryTempHolder : MonoBehaviour
{
    public static CountryTempHolder _INSTANCE;
    public float selected_country_temp = 0.0f;

    private void Awake()
    {
        if (_INSTANCE != null)
            Destroy(this.gameObject);
        else
            _INSTANCE = this;
    }
}
