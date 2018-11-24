using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RailNavigation : MonoBehaviour {

	public Transform railBegin;
	public Transform railEnd;

	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		
		agent = GetComponent<NavMeshAgent>();

		agent.SetDestination(railEnd.position);

		Debug.Log(agent.destination);

	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetAxis("Horizontal") == 1) {
			agent.SetDestination(railBegin.position);
		}
		else if (Input.GetAxis("Horizontal") == -1) {
			agent.SetDestination(railEnd.position);
		}
		else {
			agent.SetDestination(transform.position);
		}
	}
}
