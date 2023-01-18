using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transisao2 : MonoBehaviour {

    public GameObject yo;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Controlador.transition)
        {
            yo.gameObject.GetComponent<Muevete5>().enabled = false;
        }
        if (!Controlador.transition)
        {
            yo.gameObject.GetComponent<Muevete5>().enabled = true;
        }
    }
}
