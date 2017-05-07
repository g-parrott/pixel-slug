using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceApplier : MonoBehaviour
{
    public float _forceMagnitude = 10f;

    public Vector3 _forceDirection = Vector3.up;

    // Use this for initialization
    void Start()
    {
        // normalize the direction to ensure that we don't apply more
        // force than intended
        _forceDirection = _forceDirection.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        // apply the force if space is pressed (does not execute continuously)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Add force takes a vector which is interpreted by the physics engine (Havok i think)
            // and simulates the application of force upon the object in that direction 
            // (the assumed application point of the force is the object's center of mass, which is defined by the topology of the mesh)
            GetComponent<Rigidbody>().AddForce(_forceDirection * _forceMagnitude * Time.deltaTime);
        }
    }
}
