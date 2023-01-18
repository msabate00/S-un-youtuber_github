using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LenguajeEstimado : MonoBehaviour {

    

    void Start () {
		
	}
	
	// Update is called once per frame
	void OnEnable () {
        if (Controlador.Video >= 0 && Controlador.Video <= 14)
        {
            Controlador.Lenguaje = 2;
            Controlador.Lenguaje1 = 14;
        }

        if (Controlador.Video >= 15 && Controlador.Video <= 27)
        {
            Controlador.Lenguaje = 15;
            Controlador.Lenguaje1 = 24;
        }
        
        if (Controlador.Video >= 28 && Controlador.Video <= 35)
        {
            Controlador.Lenguaje = 25;
            Controlador.Lenguaje1 = 34;
        }

        if (Controlador.Video >= 36 && Controlador.Video <= 40)
        {
            Controlador.Lenguaje = 35;
            Controlador.Lenguaje1 = 40; 
        }

       
    }

}
