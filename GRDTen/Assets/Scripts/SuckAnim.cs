using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckAnim : MonoBehaviour
{
    private GameObject collectableManager;
    private Animator anim;

    void Start()
    {
        collectableManager = GameObject.FindGameObjectWithTag("CollectableManager");
        anim = transform.GetComponent<Animator>();
    }

    void Update()
    {
        if (collectableManager == null)
            return;

        if (collectableManager.transform.childCount > 0)
            anim.SetTrigger("Expand");
        else
            anim.SetTrigger("Shrink");
    }
}
