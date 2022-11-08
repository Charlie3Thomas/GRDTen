using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPlanet : MonoBehaviour
{
    void Update()
    {
        this.transform.Rotate(0, 0, 1 * Time.deltaTime);
    }
}
