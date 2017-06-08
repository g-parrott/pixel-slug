using UnityEngine;

// Toggles a GameObject between activated/deactivated states when a key is pressed
public class VisibilityToggle : MonoBehaviour
{
    public KeyCode _toggleKey = KeyCode.Escape;

    public GameObject _toToggle;

    private void Start()
    {
        if (_toToggle == null)
        {
            Debug.Log("VisibilityToggle Warning: GameObject is not assigned to any reference in the scene. This script will break.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(_toggleKey))
        {
            _toToggle.SetActive(!_toToggle.activeInHierarchy);
        }
    }
}