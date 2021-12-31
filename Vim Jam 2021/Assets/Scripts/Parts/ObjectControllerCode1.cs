using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControllerCode1 : MonoBehaviour
{
    //propeller
    private Rigidbody parentBody;
    [SerializeField]
    private PartVar myPartVar;
    [SerializeField]
    private Transform myBody;
    private bool newlyAwake = true;
    [SerializeField]
    private Collider myCollider;
    private bool initialPropellernoise;

    void Update()
    {
        if (newlyAwake)
        {
            newlyAwake = false;
            parentBody = this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>();
            Physics.IgnoreCollision(parentBody.gameObject.GetComponent<Collider>(),myCollider);
            myPartVar.activated = true;
            initialPropellernoise = false;
            ContinueAudio.propeller.playOnAwake = false;
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
        parentBody.velocity += (20*myBody.TransformDirection(Vector3.up));
        myBody.Rotate(0, 10, 0);
        ContinueAudio.propeller.enabled = true;
        if (!initialPropellernoise)
        {
            initialPropellernoise = true;
            ContinueAudio.propeller.Play();
            ContinueAudio.propeller.playOnAwake = true;
        }
    }

    private void RunOnToggledOn()
    {
        myBody.Rotate(0,1,0);
        ContinueAudio.propeller.enabled = false;
    }
    private void RunOnToggledOff()
    {
        ContinueAudio.propeller.enabled = false;
    }

}
