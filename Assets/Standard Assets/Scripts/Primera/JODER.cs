using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JODER : MonoBehaviour {

	// Use this for initialization
	void Start () {
       int pene = Random.Range(1, 10);
        if (pene >= 5) {
            Debug.Log("pues ha salio vien");
        }
            Debug.Log(pene);
            }
	
	// Update is called once per frame
	void Update () {
		
	}
}
