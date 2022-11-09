using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuInfo : MonoBehaviour
{
    [SerializeField] private GameObject info_panel;
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OpenInfoPanel);
    }

    void OpenInfoPanel()
    {
        info_panel.SetActive(true);
    }
}
