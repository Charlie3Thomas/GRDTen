using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    [SerializeField] private Canvas calendar_ui;
    private GameObject[] countries;
    private CountryProperties[] ctos;
    public static Calendar instance;
    public int year = 1961;
    private int minYear = 1961;
    private int maxYear = 2020;

    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        countries = GameObject.FindGameObjectsWithTag("Country");
    }

    private void Update()
    {
        year = Mathf.Clamp(year, minYear, maxYear);
    }

    public void SetYear(int _year)
    {
        year = _year;
        ResetYearlyHarvest();
    }

    public void IncrimentYear()
    {
        year++;
        ResetYearlyHarvest();
    }

    public void DecrementYear()
    {
        year--;
        ResetYearlyHarvest();
    }

    private void ResetYearlyHarvest()
    {
        foreach (var country in countries)
        {
            country.GetComponent<CountryProperties>().SetHarvest(false);
        }
    }

    private void OnEnable()
    {
        //year = Random.Range(minYear, maxYear);
        year = 1997;
    }
}
