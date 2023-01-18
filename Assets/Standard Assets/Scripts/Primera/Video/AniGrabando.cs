using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniGrabando : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void OnEnable()
    {
        GetComponent<Animation>().Play("Randomizador");
    }
}
