using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chest"))
        { 
            InventoryController.goldCount += 1;
            InventoryController.healthLeft = 100f;
            InstantAudioController.gold.Play();
            Destroy(other.gameObject);
        }
    }
}
