using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDisableOnStart : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(false);
    }
}
