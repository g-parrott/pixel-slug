using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script, when attached to a camera, makes the camera follow a GameObject around
public class CameraController : MonoBehaviour
{
    // the game object the camera will follow
    public GameObject _following;

    // the relative position to the _following object that this camera will maintain
    public Vector3 _offset = new Vector3(0, 2, -5);

	// set camera angle relative to player
    public float _lookUpAngle = 22.5f;

    // the camera this script controls
    private Camera _camera;

    // Use this for initialization
    void Start()
    {
        // get the main camera
        _camera = Camera.main;

        // set the camera's transform to be relative to the _following transform
        _camera.transform.position = _offset + _following.transform.position;

        // set the rotation to be relative to _following's orientation
        _camera.transform.rotation = _following.transform.rotation;

        // parent the transform of the camera to the following object
        _camera.transform.parent = _following.transform;

        // look at the following object
        _camera.transform.LookAt(_following.transform);

        // then rotate above the object's head a bit
        _camera.transform.RotateAround(_following.transform.position, -transform.right, _lookUpAngle);

        // and move the camera up a bit
        _camera.transform.Translate(Vector3.up * _offset.y);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
