using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour
{
    [SerializeField]
    private Toggle fullscreenTog;
    private void Awake()
    {
        fullscreenTog.isOn = Global_var_holder.fullscreen;
    }

    private void Update()
    {
        Screen.fullScreen = fullscreenTog.isOn;
        //
        //(fullscreenTog.isOn);
    }
    public void Quit()
    { SceneManager.LoadScene("Main Menu"); }

}
