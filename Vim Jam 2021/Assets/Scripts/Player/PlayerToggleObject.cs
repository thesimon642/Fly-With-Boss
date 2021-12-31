using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToggleObject : MonoBehaviour
{
    private int layerMask;
    [SerializeField]
    private Camera playerCamera;
    [SerializeField]
    private Transform playerTransform;
    private PartVar tempPartVar;
    [SerializeField]
    private LineRenderer actionLine;
    private float lineTimer;
    //private bool sitting;
    private Transform activeChair;
    //private void Start()
    //{
    //    sitting = false;
    //}

    private void Update()
    {
        if (PauseController.firstFrameAfterUpdate || PauseController.paused)
        { return; }
        RaycastHit hit;
        layerMask = 1 << 11;

        //if (sitting && Input.GetKeyDown(KeyCode.E))
        //{ sitting = false; }

        if (Physics.Raycast(playerTransform.position, playerCamera.transform.forward, out hit, 60f, layerMask))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //if (hit.transform.CompareTag("Seat"))
                //{
                //    sitting = true;
                //    activeChair = hit.transform;
                //}
                //else
                //{
                    tempPartVar = hit.collider.gameObject.GetComponent<PartVar>();
                    tempPartVar.activated = !tempPartVar.activated;
                    lineTimer = 0.1f;
                    actionLine.positionCount = 2;
                    Vector3[] points = { playerCamera.transform.position + new Vector3(0f, -1f, 0f), hit.point };
                    actionLine.SetPositions(points);
                //}
            }
        }

        //if (sitting)
        //{ playerTransform.position = activeChair.position + activeChair.up.normalized * 2; }

        
        if (lineTimer > Time.deltaTime)
        { lineTimer -= Time.deltaTime; }
        else
        { actionLine.positionCount = 0; }
    }

}
