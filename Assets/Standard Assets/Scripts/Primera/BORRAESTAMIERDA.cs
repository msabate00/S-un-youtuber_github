using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BORRAESTAMIERDA : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnMouseDown () {
        GetComponent<Animation>().Play("PUTAMIERDA");
    }
}
