using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropSelectionManager : MonoBehaviour
{
    public static CropSelectionManager instance;
    [SerializeField] private List<GameObject> crops;
    public int selection = 0;
    private GameObject crop;

    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    private void Update()
    {
        crop = crops[selection];
    }

    public GameObject GetCurrentCrop()
    {
        return crop;
    }
}
