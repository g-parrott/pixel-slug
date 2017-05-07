using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// demonstrates the use of Unity's AudioClip
// and built-in distortion filter
// 
// Takes an audio clip, adds a sine wave to it,
// and modulates the distortion amount
public class AudioManipulator : MonoBehaviour
{
    public float _distortionSpeed = 1f;

    private AudioDistortionFilter _distortionFilter;

    // Use this for initialization
    void Start()
    {
        // warn if there is no audio source on this GameObject
        // as this script will throw an exception and break if there isn't
        if (GetComponent<AudioSource>() == null)
        {
            Debug.Log("AudioManipulator Warning: There is no AudioSource on this GameObject. This script will not work.");
        }

        // add a distortion filter if there wasn't one already
        if (GetComponent<AudioDistortionFilter>() == null)
        {
            _distortionFilter = gameObject.AddComponent<AudioDistortionFilter>();
        }

        _distortionFilter.distortionLevel = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // lerp the distortion to 1
        if (Input.GetKey(KeyCode.Space))
        {
            _distortionFilter.distortionLevel = Mathf.Lerp(_distortionFilter.distortionLevel, 1f, Time.deltaTime * _distortionSpeed);
        }

        // lerp the distortion to 0
        else
        {
            _distortionFilter.distortionLevel = Mathf.Lerp(_distortionFilter.distortionLevel, 0f, Time.deltaTime * _distortionSpeed);
        }
    }
}