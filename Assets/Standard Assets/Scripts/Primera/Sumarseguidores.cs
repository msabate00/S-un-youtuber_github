using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sumarseguidores : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
        Visualizarint.activao = 1;
        Controlador.Seguidores += Controlador.Seguidoresprov;
        Controlador.Seguidoresprov = 0;       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
