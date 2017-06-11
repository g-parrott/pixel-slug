/**
 * VisibilityToggle.cs
 * Author: Gabriel Parrott
 */

using UnityEngine;

// Toggles a GameObject between activated/deactivated states when a key is pressed
public class VisibilityToggle : MonoBehaviour
{
    // the key which will toggle the state
    public KeyCode _toggleKey = KeyCode.Space;

    // the GameObject which will be toggled
    public GameObject _toToggle;

    private void Start()
    {
        // Uncomment for debugging 
        //if (_toToggle == null)
        //{
        //    Debug.Log("VisibilityToggle Warning: GameObject is not assigned to any reference in the scene. This script will break.");
        //}
    }

    private void Update()
    {
        if (Input.GetKeyDown(_toggleKey))
        {
            _toToggle.SetActive(!_toToggle.activeInHierarchy);
        }
    }
}