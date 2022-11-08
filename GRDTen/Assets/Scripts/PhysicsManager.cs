using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
    private GameObject physicsObjectManager;
    private GameObject collectableManager;
    private float originalFixedDt;

    void Start()
    {
        physicsObjectManager = GameObject.FindGameObjectWithTag("PhysicsObjectManager");
        collectableManager = GameObject.FindGameObjectWithTag("CollectableManager");
        originalFixedDt = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("This is the original fixed dt: " + originalFixedDt + ", this is the current fixed dt: " + Time.fixedDeltaTime);
        if (physicsObjectManager.transform.childCount + collectableManager.transform.childCount <= 900)
            return;

        if (physicsObjectManager.transform.childCount + collectableManager.transform.childCount > 1000)
            Time.fixedDeltaTime = 0.03f;
        else
            Time.fixedDeltaTime = originalFixedDt;
    }

    private void OnApplicationQuit()
    {
        Time.fixedDeltaTime = originalFixedDt;
    }
}
