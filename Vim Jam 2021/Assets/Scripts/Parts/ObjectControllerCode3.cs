using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControllerCode3 : MonoBehaviour
{
    //engine
    private Rigidbody parentBody;
    [SerializeField]
    private PartVar myPartVar;
    [SerializeField]
    private Transform myBody;
    private bool newlyAwake = true;
    [SerializeField]
    private Collider myCollider;
    private SetMaxSpeed parentSpeedMax;
    private bool PreviousToggle;
    void Update()
    {
        if (newlyAwake)
        {
            newlyAwake = false;
            parentBody = this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>();
            Physics.IgnoreCollision(parentBody.gameObject.GetComponent<Collider>(),myCollider);
            parentSpeedMax = this.gameObject.transform.parent.gameObject.GetComponent<SetMaxSpeed>();
            myPartVar.activated = true;
        }

    }
    private void FixedUpdate()
    {
        if (newlyAwake)
        { return; }
            //only run if been toggled since last update
            if (PreviousToggle != myPartVar.activated)
            {
                if (myPartVar.activated)
                {
                    RunOnToggledOn();
                }
                else
                { RunOnToggledOff(); }
            }

        if (myPartVar.activated)
        {
            if (!ContinueAudio.engine.isPlaying)
            {
                ContinueAudio.engine.Play();
            }
        }
            PreviousToggle = myPartVar.activated;
        
    }



    private void RunOnActivate()
    { 

    }

    private void RunOnToggledOn()
    {
        parentSpeedMax.bonusEngines += 1;
    }
    private void RunOnToggledOff()
    {
        parentSpeedMax.bonusEngines -= 1;
    }

}
