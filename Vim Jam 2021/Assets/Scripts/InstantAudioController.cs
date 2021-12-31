using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantAudioController : MonoBehaviour
{
    [SerializeField]
    private AudioSource serhammerMiss;
    [SerializeField]
    private AudioSource serhammerTree;
    [SerializeField]
    private AudioSource serhammerRock;
    [SerializeField]
    private AudioSource sersideways;
    [SerializeField]
    private AudioSource serfloater;
    [SerializeField]
    private AudioSource sergold;

    public static AudioSource hammerMiss;
    public static AudioSource hammerTree;
    public static AudioSource hammerRock; 
    public static AudioSource sideways; 
    public static AudioSource floater;
    public static AudioSource gold;

    private void Start()
    {
        hammerMiss = serhammerMiss;
        hammerTree = serhammerTree;
        hammerRock = serhammerRock;
        sideways = sersideways;
        floater = serfloater;
        gold = sergold;
    }

}
