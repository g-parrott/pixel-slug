using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.Events;

public class GUIManipulator : MonoBehaviour
{
    // editor configurable parameters
    public string _onText = "Switched On";

    public string _offText = "Switched Off";


    // internal state variables
    private string _countText;

    private string _switchText;

    private bool _on = false;

    private int _timesPressed = 0;


    // Unity Components
    private Button _button;

    private Text _buttonText;

    // Use this for initialization
    void Start()
    {
        // get the button component from this GameObject
        _button = GetComponent<Button>();

        // warn if there is no button attached to this game object, as the script will break
        if (_button == null)
        {
            Debug.Log("GUIManipulator Warning: There is no Button attached to this GameObject. This script will break");
        }

        // get the text component from the subobject of the Button
        _buttonText = _button.gameObject.GetComponentInChildren<Text>();

        // warn that the script will break if there is no text attached to the button
        if (_buttonText == null)
        {
            Debug.Log("GUIManipulator Warning: There is no Text attached to the button. This script will break");
        }

        // set the default count text
        _countText = "Space Pressed " + _timesPressed + " Times";

        // set the default switch text
        _switchText = (_on) ? _onText : _offText;

        // setup function for button press
        _button.onClick.AddListener(new UnityAction(
            // this is called a lambda function
            // it allows us to pass a function to the Button's internal
            // list of "EventListeners" which are called when the button is pressed
            // it is possible to have more than one listener for any given button
            () =>
            {
                // toggle the bool to its opposite
                _on = !_on;
            }));


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _timesPressed += 1;
        }

        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        _buttonText.text = GetButtonText();
    }

    private void UpdateCountText()
    {
        _countText = "Space Pressed " + _timesPressed + " Times";
    }

    private void UpdateSwitchText()
    {
        _switchText = (_on) ? _onText : _offText;
    }

    private string GetButtonText()
    {
        UpdateCountText();
        UpdateSwitchText();
        return _switchText + "\n" + _countText;
    }
}