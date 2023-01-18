using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dormir : MonoBehaviour {

    public GameObject textodemierda;
    public GameObject fondo;

	void Start () {
        textodemierda.SetActive(false);
    }
	
	// Update is called once per frame
	void OnMouseOver() {
        textodemierda.SetActive(true);
	}
    void OnMouseExit()
    {
        textodemierda.SetActive(false);
    }
    void OnMouseDown()
    {
        //  Sobao.GetComponent<Suscriptores>().enabled = true;
        // fondo.SetActive(true);
        GetComponent<Animation>().Play("Sobar");
    }

}
