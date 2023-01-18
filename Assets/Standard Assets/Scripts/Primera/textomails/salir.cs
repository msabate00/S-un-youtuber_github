using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salir : MonoBehaviour {

    public GameObject yo;
    public GameObject yo2;
    public GameObject yo3;
    void Start () {
		
	}
	
	// Update is called once per frame
	void OnMouseDown () {
        yo.SetActive(false);
        yo2.SetActive(false);
        yo3.SetActive(false);
    }
}
