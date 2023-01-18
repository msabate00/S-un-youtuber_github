using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borrabro : MonoBehaviour {

	public Vector3 a;
	private Vector3 e;
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		transform.localEulerAngles = e;
		transform.localEulerAngles += a * Time.deltaTime;
		e = transform.localEulerAngles;
	}
}
