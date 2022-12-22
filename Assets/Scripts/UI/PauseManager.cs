using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseManager : MonoBehaviour
{
    private bool gamePaused = false;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private AudioMixer globalAudioMixer;
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
        pauseMenuUI.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void ExitOptions() 
    {
        pauseMenuUI.SetActive(true);
        optionsMenu.SetActive(false);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen= isFullscreen;
    }
    public void SetVolume(float volume)
    {
        globalAudioMixer.SetFloat("volume", volume);
    }
}
