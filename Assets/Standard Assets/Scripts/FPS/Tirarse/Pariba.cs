using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pariba : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position += transform.up * 500 * Time.deltaTime;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
