using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExplodeParticle : MonoBehaviour
{
    private float countDown;
    private void Awake()
    {
        countDown = 1.2f;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.timeScale * Time.deltaTime;
        if (countDown <= 0)
        { Destroy(this.gameObject); }    
    }
}
