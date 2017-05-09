using UnityEngine;

// controls the player's movement and ensures that it doesn't penetrate any surfaces we'd like to assume are solid
public class PlayerController : MonoBehaviour
{
    // teh speed at which the player moves
    public float _moveSpeed = 10f;

    // the speed at which the player rotates
    public float _rotationSpeed = 10f;

    // the name of the axis from which we will infer the amount of movement in the horizontal direction
    public string _leftRightAxis = "horizontal";

    // the name of the axis from which we will infer the amount of movement in the forward backward direction
    public string _forwardBackAxis = "vertical";

    // the name of the axis from which we will infer the rotation direction
    public string _rotationAxis = "turning";

    // the rigidbody that we assume is attached to the player which takes care of things like moving through walls
    private Rigidbody _rigidbody;

    private void Start()
    {
        // get the Rigidbody object from the GameObject this script (or component) is attached to
        // so that we may interface with it to deal with physics calculations without much stress
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // get the values from the axes
        // for more information about this, see https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
        float horizontalAmount = Input.GetAxis(_leftRightAxis);
        float verticalAmount = Input.GetAxis(_forwardBackAxis);
        float rotationAmount = Input.GetAxis(_rotationAxis);

        // compute the displacement from the axes
        Vector3 horizontalDisplacement = Vector3.right * horizontalAmount * _moveSpeed * Time.deltaTime;
        Vector3 verticalDisplacement = Vector3.forward * verticalAmount * _moveSpeed * Time.deltaTime;

        // compute the rotation from the axis
        Quaternion rotation = Quaternion.identity;
        if (!Mathf.Approximately(rotationAmount, 0))
        {
            rotation = Quaternion.AngleAxis(rotationAmount * _rotationSpeed * Time.deltaTime, Vector3.up);
        }

        // compute the desired next position of the player
        Vector3 nextPosition = transform.position + horizontalDisplacement + verticalDisplacement;

        // use the rigidbody to make sure the desired position is physically possible to go to
        _rigidbody.MovePosition(nextPosition);
        _rigidbody.MoveRotation(rotation);
    }
}
