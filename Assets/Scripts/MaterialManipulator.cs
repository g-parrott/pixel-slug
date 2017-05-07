using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class manipulates the color of a material and
// demonstrates the use of mathematics to manipulate the
// rate at which numbers change
public class MaterialManipulator : MonoBehaviour
{
    public Color _startColor = Color.red;

    public Color _endColor = Color.blue;

    private Color _currentColor;

    // Use this for initialization
    void Start()
    {
        _currentColor = _startColor;
    }

    // Update is called once per frame
    void Update()
    {
        // interpolate towards the end color
        // at a speed relative to the distance to the target color
        if (Input.GetKey(KeyCode.Space))
        {
            // compute the "distance" from the currentColor to the end color
            Color diff = _endColor - _currentColor;
            float magnitude = Vector3.Magnitude(new Vector3(diff.r, diff.g, diff.b));

            _currentColor = Color.Lerp(_currentColor, _endColor, Time.deltaTime * magnitude);
        }

        // interpolate towards the end color
        // at a speed relative to the distance to the target color
        else
        {
            Color diff = _currentColor - _startColor;
            float magnitude = Vector3.Magnitude(new Vector3(diff.r, diff.g, diff.b));

            _currentColor = Color.Lerp(_currentColor, _startColor, Time.deltaTime * magnitude);
        }
    }
}
