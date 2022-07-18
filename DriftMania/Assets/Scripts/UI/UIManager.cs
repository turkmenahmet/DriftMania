using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;

    [SerializeField] Button restartBtn;
    [SerializeField] Button settingsBtn;
    [SerializeField] Button exitBtn;

    public static bool gameIsPaused;

    private void Update()
    {
        PausePanel();
    }

    private void PausePanel()
    {        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }            
            
            else
            {
                Pause();
            }
        }
    }

    private void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    private void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void RestartButtonFunction()
    {
        SceneManager.LoadScene(0);
        Resume();
    }

    public void ExitButtonFunction()
    {
        Application.Quit();
    }

}
