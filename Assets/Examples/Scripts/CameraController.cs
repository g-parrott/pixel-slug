using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script, when attached to a camera, makes the camera follow a GameObject around
public class CameraController : MonoBehaviour
{
    // the game object the camera will follow
    public GameObject _following;

    // controls the speed at which the camera "catches up" with the _following object
    public float _followSpeed = 10f;

    // the relative position to the _following object that this camera will maintain
    public Vector3 _offset = new Vector3(0, 2, -5);

    // controls the speed at which the camera rotates to match the _following's orientation
    public float _rotationSpeed = 10f;

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
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();

        UpdateRotation();
    }

    private void UpdatePosition()
    {
        // linearly interpolate between the camera's current position and the offset position from _following
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, _following.transform.position + _offset, Time.deltaTime * _followSpeed);
    }

    private void UpdateRotation()
    {
        // linearly interpolate between the camer's current rotation and _follwing's rotation
        _camera.transform.rotation = Quaternion.Lerp(_camera.transform.rotation, _following.transform.rotation, Time.deltaTime * _rotationSpeed);
    }
}
