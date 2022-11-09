using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryYieldHolder : MonoBehaviour
{
    public static CountryYieldHolder _INSTANCE;
    public long selected_country_yield = 0;

    private void Awake()
    {
        if (_INSTANCE != null)
            Destroy(this.gameObject);
        else
            _INSTANCE = this;
    }
}
