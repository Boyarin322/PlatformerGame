using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private bool gamePaused = false;
    [SerializeField] private GameObject pauseMenuUI;
    public void ResumeGame()
    {
        Time.timeScale = 1;
        gamePaused= false;
        ShowPausePanel(gamePaused);

    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        gamePaused = true;
        ShowPausePanel(gamePaused);
    }
    private void ShowPausePanel(bool isPaused)
    {
        pauseMenuUI.SetActive(isPaused);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GoToOptions()
    {

    }
}