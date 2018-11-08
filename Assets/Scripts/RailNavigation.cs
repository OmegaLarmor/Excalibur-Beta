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

		Debug.Log(railEnd.position);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
