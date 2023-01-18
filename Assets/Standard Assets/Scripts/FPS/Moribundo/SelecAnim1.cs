using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecAnim1 : MonoBehaviour {

	public Animator PUTA;
    void OnEnable () {
        if (Animaciones.Animacion == 1)
        {
            PUTA.SetTrigger("AHORA");
        }
        if (Animaciones.Animacion == 2)
        {
            PUTA.SetTrigger("CUELLO");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
