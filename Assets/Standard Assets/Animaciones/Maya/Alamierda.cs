using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alamierda : MonoBehaviour {

    public GameObject yo;
    public Rigidbody rb;
    void Start () {
		
	}
	
	// Update is called once per frame
	void OnEnable () {
        //Controlador.times += 1;
        yo.gameObject.GetComponent<Muevete2>().enabled = false;
        rb.isKinematic = false;        
        Salto3.vamos = true;
        Salto3.tierra = true;
        yo.gameObject.GetComponent<Alamierda>().enabled = false;
    }
}
