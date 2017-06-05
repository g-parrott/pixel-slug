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

		// set the speed of movement
		anim.SetFloat ("Speed", move);

		// walk if we moved this frame
		if (move != 0) 
		{
			anim.SetBool ("walking", true);
		}

		// stay still if we didn't
		else
		{
			anim.SetBool ("walking", false);
		}
	}
}