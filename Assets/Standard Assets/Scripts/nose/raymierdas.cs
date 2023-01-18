using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raymierdas : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right), Color.red);
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, Mathf.Infinity))
		{
			
			if (hit.transform.tag == "Enemy")
            {
				//Debug.Log(hit.distance);
			//	Debug.Log(Vector3.Distance(transform.position, hit.point));
			//	Debug.Log(Vector3.Distance(transform.position, hit.transform.position));
            }
		}
		}
}
