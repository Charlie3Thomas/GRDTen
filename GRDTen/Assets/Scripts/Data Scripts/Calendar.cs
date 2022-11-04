using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    public int year = 1961;

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
