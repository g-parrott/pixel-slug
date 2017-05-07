using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    // the time in seconds before the object will be destroyed
    // after the destruction is triggered
    // default value is 0 which means it will be destroyed immediately 
    public float _timeToDestroy = 0;

    // sentinel to determine if the destruction should activate
    public bool _shouldDestroy = false;

    // the time left before the object is destroyed
    private float _timeToDestruction; 

    // Use this for initialization
    void Start()
    {
        // initialize the timer
        _timeToDestruction = _timeToDestroy;
    }

    // Update is called once per frame
    void Update()
    {
        // flip the destruction switch
        // e.g. push the red button
        // e.g. start the countdown
        if (Input.GetKeyDown(KeyCode.Space) && !_shouldDestroy)
        {
            _shouldDestroy = true;
        }

        if (_shouldDestroy)
        {
            // subtract the time between frames (in seconds) from the destruction counter
            _timeToDestruction -= Time.deltaTime;

            // the counter has reached its final moments
            if (_timeToDestruction <= 0)
            {
                // Destroy takes a GameObject and removes it from the scene
                // by default, every script attached to a GameObject can access its parent GameObject with
                // the gameObject property
                Destroy(gameObject);
            }
        }
    }
}
