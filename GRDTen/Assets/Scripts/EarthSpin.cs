using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpin : MonoBehaviour
{
    public static EarthSpin instance { get; private set; }

    [SerializeField] private float rotSpeed = 10f;
    void Update()
    {
        transform.Rotate(0, 0, rotSpeed * Time.deltaTime);
    }
}
