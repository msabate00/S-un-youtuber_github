using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botongenerico : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnMouseDown () {
        GetComponentInParent<Animation>().Play("Sobar2");
    }
}
