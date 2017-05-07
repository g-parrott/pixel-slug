using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// see the "Messages" section of https://docs.unity3d.com/ScriptReference/Collider.html for more ways to handle collision
// this class increments a value each time an object collide's with this object's collider
public class CollisionHandler : MonoBehaviour
{
    public int TimesCollided { get; private set; }

    // Use this for initialization
    void Start()
    {
        TimesCollided = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // when space is pressed, output the number of times collided to the debug log
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(TimesCollided);
        }
    }

    // this function is called whenever this GameObject's Collider collides with another object's Collider
    private void OnCollisionEnter(Collision collision)
    {
        TimesCollided += 1;
    }
}
