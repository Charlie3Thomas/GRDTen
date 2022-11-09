using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuSources : MonoBehaviour
{
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OpenSources);
    }

    void OpenSources()
    {
        Application.OpenURL("https://ourworldindata.org/agricultural-production");
        Application.OpenURL("https://ourworldindata.org/grapher/hadcrut-surface-temperature-anomaly?time=1863&country=~DNK");
    }
}
