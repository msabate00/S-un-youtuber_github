using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animar : MonoBehaviour {

    public GameObject polla;
    void Start () {
		
	}
	
	// Update is called once per frame
	void OnEnable () {
        polla.GetComponent<Animation>().Play("BOOOM");
    }
}
