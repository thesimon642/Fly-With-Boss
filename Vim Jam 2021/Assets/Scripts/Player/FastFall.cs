using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastFall : MonoBehaviour
{
    private readonly Vector3 fastGrav = new Vector3(0,-30f,0);

    [SerializeField]
    private Rigidbody player;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        { player.AddForce(fastGrav); }
    }
}
