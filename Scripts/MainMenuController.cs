using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("Scene1", LoadSceneMode.Single);
    }

    public void SettingsGame()
    {
        menuPanel.SetActive(true);
    }

    public void MenuGame()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}