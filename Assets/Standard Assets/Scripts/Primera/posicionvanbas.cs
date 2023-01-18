using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posicionvanbas : MonoBehaviour {

	public RectTransform m_Canvas;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pollas = transform.position;
		pollas.z = -1000;
		transform.position = pollas;
	}
}
