using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour 
{

	Animator anim;
	int walk = Animator.StringToHash("Walk");
	int idle = Animator.StringToHash("Idle");

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () 
	{

		// get the amount of movement this frame
		float move = Input.GetAxis ("Horizontal") + Input.GetAxis("Vertical");
		if (Input.GetKey (KeyCode.W)) {
			anim.SetBool ("Walking", true);
		} else if (Input.GetKey (KeyCode.S)) {
			anim.SetBool ("Walking", true);
		} else if (Input.GetKey (KeyCode.A)) {
			anim.SetBool ("Walking", true);
		} else if (Input.GetKey (KeyCode.D)) {
			anim.SetBool ("Walking", true);
		} else {
			anim.SetBool ("Walking", false);
		}
		// set the speed of movement
		anim.SetFloat ("Speed", move);

		// walk if we moved this frame
		/*if (move != 0) 
		{
			anim.SetBool ("Walking", true);
		}

		// stay still if we didn't
		else
		{
			anim.SetBool ("Walking", false);
		}*/
	}
}