using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global_var_holder : MonoBehaviour
{
    public static Global_var_holder instance;
    //settings menu variables
    public static bool fullscreen;
    public static bool mute;
    public static float musicVolume;
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
        { instance = this; }
        else
        { Destroy(this.gameObject); }
        fullscreen = Screen.fullScreen;
        mute = false;
        musicVolume = 0.14f;
    }
}
