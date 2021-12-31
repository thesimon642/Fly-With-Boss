using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaxSpeed : MonoBehaviour
{
    [SerializeField]
    private Rigidbody myBody;
    private readonly float maxSpeed = 20;
    public int bonusEngines;
    private void Awake()
    {
        bonusEngines = 0;
    }
    void FixedUpdate()
    {
        if (myBody.velocity.magnitude > 0)
        { myBody.velocity *= Mathf.Min(maxSpeed + 50 * bonusEngines, myBody.velocity.magnitude) / myBody.velocity.magnitude; }

    }
}
