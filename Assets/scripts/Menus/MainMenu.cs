using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void HandlePlayButtonOnClick()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void HandleQuitButtonOnClick()
    {
        Application.Quit();
    }
    public void HandleHelpButtonOnClick()
    {
        SceneManager.LoadScene("HelpMenu");
    }
}
