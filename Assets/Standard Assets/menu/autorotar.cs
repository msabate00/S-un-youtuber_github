using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autorotar : MonoBehaviour {

	public Vector3 dir;
	public float vel;

	void Update () {
		 transform.Rotate(dir * vel * Time.deltaTime, Space.Self);
	}
}
