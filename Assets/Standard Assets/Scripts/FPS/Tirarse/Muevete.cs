using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muevete : MonoBehaviour {

    public float pene = 1;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(Vector3.left * Time.deltaTime * pene);
    }
}
