using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (IsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        IsPaused = false;
        Time.timeScale = 1.0f;
    }

    public void MainMenu()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("MenuScene");
        SceneManager.UnloadSceneAsync("FirstLevelScene");
        Resume();
    }

    public void Quit()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    private void Pause()
    {
        pauseMenu.SetActive(true);
        IsPaused = true;
        Time.timeScale = 0.0f;
    }

    
}
