using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    private bool mapOpen;
    [SerializeField]
    private RawImage map;
    private
    void Start()
    {
        mapOpen = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        { mapOpen = !mapOpen; }
        map.enabled = mapOpen;
    }
}
