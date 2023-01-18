using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bahputavelocidad : MonoBehaviour {

    public float spollas;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * spollas * Time.deltaTime;
	}
}
