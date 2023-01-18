using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecAnim : MonoBehaviour {

	public Animator PUTA;
    void OnEnable () {
         //    Animaciones.Animacion = 3;
        if (Animaciones.Animacion == 1)
        {
            PUTA.SetTrigger("ostiapata");
        }
        if (Animaciones.Animacion == 2)
        {
            PUTA.SetTrigger("cuello");
        }       
        if (Animaciones.Animacion == 3)
        {
            PUTA.SetTrigger("apuñaladowey");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
