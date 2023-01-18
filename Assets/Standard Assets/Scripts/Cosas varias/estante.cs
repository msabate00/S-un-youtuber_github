using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estante : MonoBehaviour {

	public int arma = 0;
	public GameObject barrera;
	
	// Update is called once per frame
	public void a (DisparoSelectivo e) {

			e.Insertar(arma);

	}

	void Start()
    {
		if (Controlador.puntostotales < Controlador.ah.gameObject.GetComponent<normalizador>().listagay[arma].Desbloqueo)
        {
			barrera.SetActive(true);
        }
        else
        {
			barrera.SetActive(false);
		}
    }
}
