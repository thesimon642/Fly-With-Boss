using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource serpropeller;
    [SerializeField]
    private AudioSource serengine;

    public static AudioSource propeller;
    public static AudioSource engine;


    private void Start()
    {
        propeller = serpropeller;
        engine = serengine;
    }
}
