using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MenuState
{
    MainMenu,
    Options,
}
public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        MenuState _currentState = MenuState.MainMenu; 
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void GoToSettings()
    {
        Application.Quit();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
