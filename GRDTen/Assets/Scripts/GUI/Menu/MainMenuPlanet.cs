using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPlanet : MonoBehaviour
{
    [SerializeField] private float roatation_speed = 3.0f;

    void Update()
    {
        this.transform.Rotate(0, 0, roatation_speed * Time.deltaTime);
    }
}
