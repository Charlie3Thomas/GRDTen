using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuCloseInfo : MonoBehaviour
{
    [SerializeField] private GameObject info_panel;
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(CloseInfoPanel);
    }

    void CloseInfoPanel()
    {
        info_panel.SetActive(false);
    }
}
