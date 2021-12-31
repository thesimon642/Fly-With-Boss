using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool paused;
    public static bool firstFrameAfterUpdate;
    [SerializeField]
    private FirstPersonAIO playerFPS;
    [SerializeField]
    private GameObject pauseMenu;
    private GameObject storePauseMenu;

    public static PauseController instance;
    private void Start()
    {
        paused = false;
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TriggerPause();
        }
        //if (paused)
        //{
        //    if (!playerFPS.controllerPauseState)
        //    { playerFPS.ControllerPause(); }
        //}
        //else
        //{
        //    if (playerFPS.controllerPauseState)
        //    { playerFPS.ControllerPause(); }
        //}


        //        Time.timeScale = paused ? 0 : 1;
    }

    private void TriggerPause()
    {

        paused = !paused;
        //playerFPS.ControllerPause();
        firstFrameAfterUpdate = true;
        AudioListener.pause = paused;

        if (paused)
        {
            Time.timeScale = 0;
            storePauseMenu = Instantiate(pauseMenu);
            //if (playerFPS.controllerPauseState)
            //{ playerFPS.ControllerPause(); }
        }
        else
        {
            Time.timeScale = 1;
            //if (!playerFPS.controllerPauseState)
            //{ playerFPS.ControllerPause(); }
            Destroy(storePauseMenu);
        }
        playerFPS.ControllerPause();
    }

    private void LateUpdate()
    {
        firstFrameAfterUpdate = false;
    }

    public static void UnPause()
    {
        PauseController.instance.TriggerPause();
    }
}
