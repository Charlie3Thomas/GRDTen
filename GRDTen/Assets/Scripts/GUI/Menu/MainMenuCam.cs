using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCam : MonoBehaviour
{
    [SerializeField] private Transform lookat_target;
    void Update()
    {
        this.transform.LookAt(lookat_target);
    }
}
