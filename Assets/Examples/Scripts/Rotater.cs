using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// rotates an object around an axis at a supplied speed
public class Rotater : MonoBehaviour
{
    public float _rotationSpeed = 10f;

    public Vector3 _rotationAxis = Vector3.up;

    // Use this for initialization
    void Start()
    {
        // normalize the axis so we don't rotate more than we'd like
        _rotationAxis = _rotationAxis.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        // rotates the object when space is pressed
        if (Input.GetKey(KeyCode.Space))
        {
            // Rotate has many overloads depending on the method which is convenient
            // e.g. the information we might have available for rotation relative to reference points
            // this one is called an "axis-angle rotation" which means we rotate the object
            // around an axis by some angle.
            // the parameters are
            //     (Vector3 axis, float angle)
            // the deltaTime parameter ensures the rotation occurs independent of the framerate
            transform.Rotate(_rotationAxis, _rotationSpeed * Time.deltaTime);
        }
    }
}
