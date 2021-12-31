using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingObstables : MonoBehaviour
{
    public static List<GameObject> TouchingObjects;
    void Start()
    {
        TouchingObjects = new List<GameObject>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (!TouchingObjects.Contains(collision.gameObject) && collision.CompareTag("No Place"))
            TouchingObjects.Add(collision.gameObject);
    }

    void OnTriggerExit(Collider collision)
    {
        if (TouchingObjects.Contains(collision.gameObject))
            TouchingObjects.Remove(collision.gameObject);
    }
}