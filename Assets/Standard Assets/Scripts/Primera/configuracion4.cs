using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class configuracion4 : MonoBehaviour {
    public GameObject yo;
    public GameObject yo2;
    public GameObject yo3;
    public GameObject yo4;
    public GameObject yo5;
    public GameObject yo6;
    public GameObject yo7;
    public GameObject yo8;
    public GameObject yo9;
    public GameObject yo11;
    public GameObject yo10;

    void Start () {
		
	}
	
	// Update is called once per frame
	void OnMouseDown () {
        Controlador.desrank = true;
        yo.SetActive(false);
        yo4.SetActive(false);
        yo2.SetActive(true);
        yo3.SetActive(true);
        yo5.SetActive(true);
        yo6.SetActive(true);
        yo7.SetActive(false);
        yo8.SetActive(true);
        yo9.SetActive(true);
        yo11.SetActive(true);
        yo10.SetActive(true);
    }
}








