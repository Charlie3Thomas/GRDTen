using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extractor : MonoBehaviour
{
    public static Extractor instance { get; private set; }

    [SerializeField] private PhysicsLauncher pl;
    [SerializeField] private GameObject splash;
    [SerializeField] private GameObject blast;
    private float d_timer = 0.0f;

    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    private void Update()
    {
        d_timer += Time.deltaTime;

        if (d_timer >= 10.0f)
            Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.gameObject.layer == LayerMask.NameToLayer("Country"))
        {
            if(other.transform.GetComponent<CountryProperties>().GetHighlighed() && !other.transform.GetComponent<CountryProperties>().GetHarvest())
            {
                if (other.transform.childCount > 0)
                {
                    if (other.transform.GetChild(0).GetComponent<CountryDataLoader>() != null)
                        pl.amount = (other.transform.GetChild(0).GetComponent<CountryDataLoader>().GetCropDataInTime(CropSelectionManager.instance.GetCurrentCrop().name, Calendar.instance.year));
                    else
                        pl.amount = 0;
                }
                else
                    pl.amount = 0;

                Instantiate(blast.transform.gameObject, other.contacts[0].point, Quaternion.FromToRotation(transform.forward, other.contacts[0].normal));
                Instantiate(pl.transform.gameObject, other.contacts[0].point, Quaternion.FromToRotation(transform.forward, other.contacts[0].normal));
                //other.transform.GetComponent<CountryProperties>().SetHarvest(true);
            }
            AudioManager.Instance.PlayOneShotWithParameters("Explosion", transform);
        }

        else if (other.transform.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            AudioManager.Instance.PlayOneShotWithParameters("WaterSplash", transform);
            Instantiate(splash.transform.gameObject, other.contacts[0].point, Quaternion.FromToRotation(transform.forward, other.contacts[0].normal));
        }

        Destroy(gameObject);
    }
}
