using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Prototype");
    }

    public static MainMenuController instance;
    private void Start()
    {
        if (instance == null)
        { instance = this; }
    }

    public void MainMenuLoad()
    {SceneManager.LoadScene("Main Menu");}


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&instance == this)
        { MainMenuLoad(); }
    }

    public void ExitGame()
    { Application.Quit(); }

    public void HowtoPlayLoad()
    { SceneManager.LoadScene("How to Play"); }

    public void ControlsLoad()
    { SceneManager.LoadScene("Controls"); }

    public void CreditsLoad()
    { SceneManager.LoadScene("Credits"); }

    public void VimJamLoad()
    { SceneManager.LoadScene("VimJam"); }
}
