using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// translates e.g. moves an object in a given direction at a given speed
public class Translator : MonoBehaviour
{
    public float _translationSpeed = 10f;

    public Vector3 _translationDirection = Vector3.up;

    // Use this for initialization
    void Start()
    {
        // normalize the direction so we don't translate more than we'd like
        _translationDirection = _translationDirection.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        // move the object in the direction when space is pressed
        if (Input.GetKey(KeyCode.Space))
        {
            // Translate moves on object along some Vector
            // in this case we are translating along the _translationDirection vector
            // at speed (which you can think of as velocity) _translationSpeed
            // the deltaTime parameter ensures the translation is independent of framerate as we discusses in class
            transform.Translate(_translationDirection * _translationSpeed * Time.deltaTime);
        }
    }
}
