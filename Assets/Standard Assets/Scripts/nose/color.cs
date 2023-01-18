using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color : MonoBehaviour {

	Color lerpedColor = Color.white;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		lerpedColor = Color.Lerp(Color.white, Color.black, 0.3f);
		GetComponent<MeshRenderer>().material.color = lerpedColor;
	}
}
