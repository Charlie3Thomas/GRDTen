using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryMatchUp : MonoBehaviour
{
    [SerializeField] private GameObject map;
    [SerializeField] private GameObject data;
    [SerializeField] private List<GameObject> _countries_models = new List<GameObject>();
    private List<GameObject> _countries_data = new List<GameObject>();

    private void Start()
    {
        //foreach (GameObject c_model in map.GetComponentsInChildren<GameObject>())
        //{
        //    _countries_models.Add(c_model);
        //}
        //foreach (GameObject c_data in data.GetComponentsInChildren<GameObject>())
        //{
        //    _countries_models.Add(c_data);
        //}
    }
}
