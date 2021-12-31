using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemPlacerController : MonoBehaviour
{

    [SerializeField]
    private Camera playerCamera;
    [SerializeField]
    private GameObject propellerShell;
    [SerializeField]
    private Transform playerTransform;
    private int layerMask;
    [SerializeField]
    private MeshRenderer shellMesh;
    [SerializeField]
    private Collider shellCollider;
    [SerializeField]
    private Material shellColour;
    [SerializeField]
    private MeshFilter shellFilter;

    private float indexOfRotation;

    //controls which item is selected INPUTS

    [SerializeField]
    private GameObject[] propellerReal;
    [SerializeField]
    private Mesh[] shellShape;
    [SerializeField]
    private bool[] itemsPlaceable;
    [SerializeField]
    public int[] woodCost;
    [SerializeField]
    public int[] ironCost;
    [SerializeField]
    public float[] placeHeight;


    void Update()
    {
        if (PauseController.firstFrameAfterUpdate||PauseController.paused)
        { return; }

        for (int number = 1; number <= 9; number++)
        {
            if (Input.GetKeyDown(number.ToString()))
                InventoryController.currentItemID = number - 1;
        }



        if (!itemsPlaceable[InventoryController.currentItemID])
        {
            shellMesh.enabled = false;
            return;
        }


        shellFilter.sharedMesh = shellShape[InventoryController.currentItemID];
        RaycastHit hit;
        layerMask = 1 << 10;

        if (Physics.Raycast(playerTransform.position, playerCamera.transform.forward, out hit, 40f, layerMask))
        {
            shellMesh.enabled = true;
            propellerShell.transform.position = hit.point + placeHeight[InventoryController.currentItemID] * hit.normal;
            propellerShell.transform.up = hit.normal;
            propellerShell.transform.RotateAround(propellerShell.transform.position, hit.normal, indexOfRotation);
            if (TouchingObstables.TouchingObjects.Count == 0)
            {
                shellColour.color = new Color(0.508989f, 0.8113207f, 0.7606484f, 0.7529412f);
                if (Input.GetMouseButtonDown(0) && SufficientResources())
                {
                    GameObject newObject = Instantiate(propellerReal[InventoryController.currentItemID], shellMesh.transform.position, shellMesh.transform.rotation);
                    newObject.transform.SetParent(hit.transform);
                    InventoryController.ironCount -= ironCost[InventoryController.currentItemID];
                    InventoryController.woodCount -= woodCost[InventoryController.currentItemID];
                }
            }
            else
            {
                shellColour.color = new Color(1, 0, 0, 0.7529412f);
            }

        }
        else
        {
            shellMesh.enabled = false;
        }
        if (Input.GetKey(KeyCode.R))
        {
            indexOfRotation = (indexOfRotation + Time.deltaTime * 50) % 360;
        }
    }

    private bool SufficientResources()
    {
        return (InventoryController.ironCount >= ironCost[InventoryController.currentItemID] && InventoryController.woodCount >= woodCost[InventoryController.currentItemID]);
    }
}
