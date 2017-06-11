using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AfroWalkWay : MonoBehaviour {

	// Use this for initialization
	public Transform target;
	NavMeshAgent agent;

	void Start () {
		//give reference to our agent
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		//tell our agent where to go
		agent.SetDestination(target.position);
	}
}
