using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
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
