using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigidgays : MonoBehaviour {

	// Use this for initialization
	private Rigidbody[] AllColliders;
	void Start () {
		AllColliders = GetComponentsInChildren<Rigidbody>();
		foreach (var col in AllColliders)
		{
			col.collisionDetectionMode = CollisionDetectionMode.Continuous;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
