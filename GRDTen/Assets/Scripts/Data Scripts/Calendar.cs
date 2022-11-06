using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour
{
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

    private void Update()
    {
        year = Mathf.Clamp(year, minYear, maxYear);

        if(PlayerInputManager.instance.rewind)
        {
            DecrementYear();
        }

        if (PlayerInputManager.instance.fastForward)
        {
            IncrimentYear();
        }
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
        year = Random.Range(minYear, maxYear);
    }
}
