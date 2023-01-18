using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class configuracion2 : MonoBehaviour {
    public GameObject yo;
    public GameObject yo2;
    public GameObject yutub;
    public GameObject yutubtxt;
    public GameObject grbtxt;
    public GameObject menutxt;
    public GameObject camaraman;
    public GameObject out2;
    public GameObject menu6;
    public GameObject menu7;
    public GameObject menu8;
    public GameObject menu9;

    void Start () {
		
	}
	
	// Update is called once per frame
	void OnMouseDown () {
        camaraman.GetComponent<Camara>().enabled = false;
        camaraman.GetComponent<Desactibaor>().enabled = true;
        Controlador.amplia = 2;
        Debug.Log(Controlador.amplia);
      //  desactiver.SetActive(false);
        yutub.SetActive(true);
        yutubtxt.SetActive(false);
        grbtxt.SetActive(false);
        menutxt.SetActive(false);
        yo.SetActive(false);
        yo2.SetActive(false);
        out2.SetActive(true);
        menu6.SetActive(false);
        menu7.SetActive(false);
        menu8.SetActive(false);
        menu9.SetActive(false);
    }
}








