using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseController : MonoBehaviour
{
    private bool win;
    public static bool lose;
    [SerializeField]
    private Transform playerBody;
    [SerializeField]
    private FirstPersonAIO playerFPS;
    private void Start()
    {
        win = false;
        lose = false;
    }

    private void Update()
    {
        if (InventoryController.healthLeft <= 0)
        { lose = true; }
        if (playerBody.position.y <= -100)
        { lose = true; }
        if (lose)
        {
            if (!playerFPS.controllerPauseState)
            { playerFPS.ControllerPause(); }

            SceneManager.LoadScene("Lose"); 
        }
        if (InventoryController.maxCoin <= InventoryController.goldCount)
        { win = true; }
        if (win)
        { SceneManager.LoadScene("Win Screen"); }


    }
}
