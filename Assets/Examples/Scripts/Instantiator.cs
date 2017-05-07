using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    // the prefab we will instantiate
    public GameObject _toInstantiate;

    // used to determine the radius of the sphere
    // we will randomly place the object in
    public float _radius = 10f;

    // the origin of the sphere we will
    // randomly place the object in
    public Vector3 _origin = Vector3.zero;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // a random position in a sphere of radius _radius centered at _origin
        Vector3 randomPosition = Random.insideUnitSphere * _radius + _origin;

        // a random rotation to be applied to the object
        // rotationUniform means the distribution of rotations in uniform
        // (in case that wasn't clear)
        Quaternion randomRotation = Random.rotationUniform;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // instantiate has many overloads
            // this one takes parameters:
            //     (GameObject, Vector3, Quaternion)
            // which represent the prefab we'd like to create, the position we'd like to create it at, and the rotation it starts with, respectively
            Instantiate(_toInstantiate, randomPosition, randomRotation);
        }
    }
}
