using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer hammerVisual;
    [SerializeField]
    private Animator myAnimator;
    [SerializeField]
    private Camera playerCamera;
    [SerializeField]
    private Transform playerTransform;
    private int layerMask;
    [SerializeField]
    private GameObject exploder;
    void Update()
    {
        if (PauseController.firstFrameAfterUpdate || PauseController.paused)
        { return; }
        if (InventoryController.currentItemID != 0)
        {
            hammerVisual.enabled = false;
            return;
        }
        hammerVisual.enabled = true;

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            layerMask = 1 << 12;
            if (Physics.Raycast(playerTransform.position, playerCamera.transform.forward, out hit, 15f, layerMask))
            {
                if (hit.transform.CompareTag("Tree"))
                {
                    Destroy(hit.transform.gameObject);
                    InventoryController.woodCount = Mathf.Min(InventoryController.woodCount + 5, 99);
                    InstantAudioController.hammerTree.Play();
                    Instantiate(exploder, hit.point, Quaternion.identity);
                }
                if (hit.transform.CompareTag("Rock"))
                {
                    Destroy(hit.transform.gameObject);
                    InventoryController.ironCount = Mathf.Min(InventoryController.ironCount + 4, 99);
                    InstantAudioController.hammerRock.Play();
                }
            }
            else
            //if(myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Hammer Idle") || myAnimator.IsInTransition(0))
            //{ InstantAudioController.hammerMiss.Play(); }
            myAnimator.SetBool("Swing", true);
        }
        else
        {
            myAnimator.SetBool("Swing", false);
        }
    }
}
