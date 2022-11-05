using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    public static Calendar instance;
    public int year = 1961;

    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    public void SetYear(int _year)
    {
        year = _year;
    }

    public void IncrimentYear()
    {
        year++;
    }

    public void DecrementYear()
    {
        year--;
    }

    private void Start()
    {
        year = Random.Range(1961, 2020);
    }
}
