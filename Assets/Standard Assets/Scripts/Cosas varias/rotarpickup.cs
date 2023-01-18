using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotarpickup : MonoBehaviour {

	public float sex = 1;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Time.time * sex) * 0.7f * Time.deltaTime, transform.position.z);
		transform.Rotate(Vector3.up * 30 * Time.deltaTime, Space.Self);
		
	}

}
