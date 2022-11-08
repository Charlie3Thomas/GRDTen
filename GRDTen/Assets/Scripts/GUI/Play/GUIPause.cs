using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIPause : MonoBehaviour
{
    [SerializeField] private GameObject ui_play;
    [SerializeField] private GameObject[] ui_pause;
    public static bool game_paused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (game_paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void Resume()
    {
        Debug.Log("Resume game.");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ui_play.SetActive(true);
        foreach (GameObject go in ui_pause)
        {
            go.SetActive(false);
        }        
        Time.timeScale = 1.0f;
        game_paused = false;
    }

    void Pause()
    {
        Debug.Log("Pause game.");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        ui_play.SetActive(false);
        foreach (GameObject go in ui_pause)
        {
            go.SetActive(true);
        }
        Time.timeScale = 0.0f;
        game_paused = true;
    }
}
