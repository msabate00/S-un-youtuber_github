using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reseteadorvideoselec : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
        Controlador.Juegoselec = 0;
        Controlador.VideoGrabao = 0;
        Videojuegos.juegoselecint = 0;
        Videojuegos.juegoselecintmax = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
