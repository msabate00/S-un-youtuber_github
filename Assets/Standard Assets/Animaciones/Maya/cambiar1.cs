using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiar1 : MonoBehaviour {

    public Animator polla;
    public GameObject yo;
    void Start () {
		
	}
	
	// Update is called once per frame
	void OnEnable () {
        
        
        yo.gameObject.GetComponent<Muevete2>().enabled = false;
        yo.gameObject.GetComponent<cambiar1>().enabled = false;
    }
}
