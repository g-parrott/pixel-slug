using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	public bool isStart;
	public bool isQuit;

	void OnMouseUp () {
		if (isStart) {
			Debug.Log ("OMG you pressed Start woohoo");
			SceneManager.LoadScene ("prototype");
		}
		if (isQuit) {
			Application.Quit();
			Debug.Log ("OMG you pressed quit");
			GetComponent<Renderer>().material.color = Color.blue;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
