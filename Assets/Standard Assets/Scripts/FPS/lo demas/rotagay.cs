using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotagay : MonoBehaviour {

	public float pollades = 50;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, pollades, Space.Self);
	}
}
