using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour {
	public Color color = new Color (184, 79, 22);
	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.color = color; 
	}
	
	// Update is called once per frame
	void OnMouseEnter () {
		GetComponent<Renderer>().material.color = Color.blue; 
	}

	void OnMouseExit() {
		GetComponent<Renderer>().material.color = color; 
	}
}
