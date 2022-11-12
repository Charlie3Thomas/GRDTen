using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckSoundAndAnim : MonoBehaviour
{
    private GameObject collectableManager;
    private Animator anim;
    private FMODUnity.StudioEventEmitter sound;
    private bool soundPlaying = false;
    private float timer = 0.0f;

    void Start()
    {
        collectableManager = GameObject.FindGameObjectWithTag("CollectableManager");
        anim = transform.GetComponent<Animator>();
        sound = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    void Update()
    {
        if (collectableManager == null)
            return;

        if (collectableManager.transform.childCount > 0)
        {
            if (anim != null)
                anim.SetTrigger("Expand");

            timer = 0.0f;
            if(!soundPlaying)
            {
                sound.Play();
                soundPlaying = true;
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > 0.5f)
            {
                if (anim != null)
                    anim.SetTrigger("Shrink");
            }
            if (timer > 1.25f)
            {
                soundPlaying = false;
                sound.AllowFadeout = true;
                sound.Stop();
                timer = 0.0f;
            }
        }
    }
}
