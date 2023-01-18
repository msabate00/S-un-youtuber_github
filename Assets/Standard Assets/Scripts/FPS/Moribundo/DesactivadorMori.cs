using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivadorMori : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Controlador.transition = false;
        Animaciones.Ahora = false;
        Animaciones.Rotacion = false;
        Animaciones.Distancia = false;
        Animaciones.Ahorayo = false;
        Animaciones.Yo = true;
        Animaciones.Laterales = false;
        Animaciones.Animacion = 0;
        Animaciones.Trigger = false;
        FPCStatus.transicion = false;
        FPCStatus.melee = false;
        Invoke("pollas", 1f);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void pollas()
    {
        Controlador.mestoylevantandojoder = false;
    }
}
