using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Transform camPos;

    void Update()
    {
        if (camPos == null)
            return;

        transform.position = camPos.position;
    }
}
