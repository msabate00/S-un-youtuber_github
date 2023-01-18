using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activaseg : MonoBehaviour {

    public GameObject yo;
	void OnEnable () {        
        yo.GetComponent<Seguidores>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
