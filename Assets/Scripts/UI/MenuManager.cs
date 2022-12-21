using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    private Button playButton;
    private Button optionsButton;
    private Button quitButton;

    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        playButton = root.Q<Button>("PlayButton");
        optionsButton = root.Q<Button>("OptionsButton");
        quitButton = root.Q<Button>("QuitButton");

        playButton.clicked += PlayGame;
        optionsButton.clicked += GoToSettings;
        quitButton.clicked += QuitGame;
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
