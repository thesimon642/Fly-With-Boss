using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControllerCode2 : MonoBehaviour
{
    //sideways thruster
    private Rigidbody parentBody;
    [SerializeField]
    private PartVar myPartVar;
    [SerializeField]
    private Transform myBody;
    private bool newlyAwake = true;
    [SerializeField]
    private Collider myCollider;

    private bool newlyActivated;
    void Update()
    {
        if (newlyAwake)
        {
            newlyAwake = false;
            parentBody = this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>();
            Physics.IgnoreCollision(parentBody.gameObject.GetComponent<Collider>(),myCollider);
            myPartVar.activated = true;
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




    private void RunOnActivate()
    { 
        parentBody.velocity += (20*myBody.TransformDirection(Vector3.left));
        if (newlyActivated)
        {
            newlyActivated = false;
            InstantAudioController.sideways.Play();
        }
    }

    private void RunOnToggledOn()
    {
        newlyActivated = true;
    }
    private void RunOnToggledOff()
    {
        newlyActivated = true;
    }

}
