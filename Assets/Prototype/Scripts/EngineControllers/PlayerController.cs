using UnityEngine;

// controls the player's movement and ensures that it doesn't penetrate any surfaces we'd like to assume are solid
public class PlayerController : MonoBehaviour
{
    // the speed at which the player moves
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

    private void FixedUpdate()
    {
        // get the values from the axes
        // for more information about this, see https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
        float horizontalAmount = Input.GetAxis(_leftRightAxis);
        float verticalAmount = Input.GetAxis(_forwardBackAxis);

		Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
		forward.y = 0;
		forward = forward.normalized;
		Vector3 right  = new Vector3(forward.z, 0, -forward.x);


        // compute the displacement from the axes
        Vector3 horizontalDisplacement = right * horizontalAmount * _moveSpeed * Time.fixedDeltaTime;
        Vector3 verticalDisplacement = forward * verticalAmount * _moveSpeed * Time.fixedDeltaTime;

		// rotate with mouse
		float h = _rotationSpeed * Input.GetAxis("Mouse X");
		transform.Rotate(0, 0, h);

        // compute the desired next position of the player
        Vector3 nextPosition = transform.position + horizontalDisplacement + verticalDisplacement;

		// check if player would go through a wall and if so don't go through the wall
		foreach (var hit in Physics.RaycastAll(transform.position, (horizontalDisplacement + verticalDisplacement).normalized)) {
			if (hit.transform.tag == "Level") {
				var point = hit.point;
				var distance = Vector3.Distance (transform.position, point);
				if (distance < 1) {
					nextPosition = transform.position;
				}
			}
		}

        // move the player's position
		transform.position = nextPosition;
    }
}
