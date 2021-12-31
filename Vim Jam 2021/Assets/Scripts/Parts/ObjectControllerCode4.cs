using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControllerCode4 : MonoBehaviour
{
    //chair
    private Rigidbody parentBody;
    [SerializeField]
    private PartVar myPartVar;
    [SerializeField]
    private Transform myBody;
    private bool newlyAwake = true;
    [SerializeField]
    private Collider myCollider;
    private bool sitting;
    private Transform playerTransform;
    void Update()
    {
        if (newlyAwake)
        {
            newlyAwake = false;
            parentBody = this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>();
            Physics.IgnoreCollision(parentBody.gameObject.GetComponent<Collider>(),myCollider);
            sitting = false;
            playerTransform = GameObject.Find("Player").transform;
            myPartVar.activated = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.LeftControl))
        { 
            sitting = false;
            myCollider.enabled = true;
            myPartVar.activated = false;
        }
    }
    private void FixedUpdate()
    {
        if (newlyAwake)
        { return; }
        if (myPartVar.activated)
        {
            if (Input.GetMouseButton(1))
            { RunOnActivate(); }
            else
            { RunOnToggledOn(); }
        }
        else
        { RunOnToggledOff(); }
    }

    private void LateUpdate()
    {
       // Debug.Log(sitting);
        if (sitting)
        { playerTransform.position = transform.position + transform.up.normalized * 2; }
    }


    private void RunOnActivate()
    {

    }

    private void RunOnToggledOn()
    {
        sitting = true;
        myCollider.enabled = false;
    }
    private void RunOnToggledOff()
    {
        myCollider.enabled = true;
    }

}
