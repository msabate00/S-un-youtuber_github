using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activartrending : MonoBehaviour {
    public GameObject yo;
	// Use this for initialization
	void OnEnable () {
		if (Controlador.Diasdesdetrending >= 10) // seran 40 dias o yokse
        {
            Controlador.trendactivao = true;
            yo.GetComponent<Nsetio>().enabled = true;
            Controlador.Diasdesdetrending = 0;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
