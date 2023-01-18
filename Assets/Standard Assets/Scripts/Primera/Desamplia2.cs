using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desamplia2 : MonoBehaviour {

    public GameObject w1;
    public GameObject w3;
    public GameObject w2;
    public GameObject w4;
    public GameObject w5;
    public GameObject w6;
    public GameObject w7;
    public GameObject w8;
    public GameObject w9;
    public GameObject w10;
    public GameObject w11;
    public GameObject w12;
    public GameObject w13;
    public GameObject w14;
    public GameObject w15;
    public GameObject w16;
    public GameObject w17;
    public GameObject w18;
    public GameObject w19;
    public GameObject w20;
    public GameObject w21;
    public GameObject w22;
    public GameObject w23;
    public GameObject w24;
    public GameObject w25;
    public GameObject w26;
    public GameObject w27;
    public GameObject w28;
    public GameObject w29;
    public GameObject w30;
    public GameObject w31;
    public GameObject w32;
    public GameObject yo; 
    public GameObject camaraman;
    public GameObject cama;

    
    void desactivaralt () {
        Controlador.desrank = true;
        Controlador.amplia = 1;
        camaraman.GetComponent<Camara>().enabled = true;
        camaraman.GetComponent<Desactibaor>().enabled = false;
    }
	
	// Update is called once per frame
	void OnMouseDown () {
        Controlador.desrank = true;
        Controlador.amplia = 1;
        camaraman.GetComponent<Camara>().enabled = true;
        camaraman.GetComponent<Desactibaor>().enabled = false;
        w1.SetActive(true);
        w2.SetActive(false);
        w3.SetActive(false);
        w4.SetActive(false);
        w5.SetActive(false);
        w6.SetActive(false);
        w7.SetActive(false);
        w8.SetActive(false);
        w9.SetActive(true);
        w10.SetActive(true);
        w11.SetActive(false);
        w12.SetActive(false);
        w13.SetActive(true);
        w14.SetActive(false);
        w15.SetActive(false);
        w16.SetActive(false);
        w17.SetActive(false);
        w18.SetActive(false);
        w19.SetActive(false);
        w20.SetActive(false);
        w21.SetActive(false);
        w22.SetActive(false);
        w23.SetActive(false);
        w24.SetActive(false);
        w25.SetActive(false);
        w26.SetActive(false);
        w27.SetActive(false);
        w28.SetActive(false);
        w29.SetActive(false);
        w30.SetActive(true);
        w31.SetActive(true);
        w32.SetActive(true);
        yo.SetActive(false);
        cama.SetActive(true);
        Debug.Log("TUPUTAMADRE");
    }
}