using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacher : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        { player.transform.SetParent(other.gameObject.transform); }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        { player.transform.parent = null; }
    }
}
