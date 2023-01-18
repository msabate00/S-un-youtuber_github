using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSubs : MonoBehaviour {

    public GameObject wow;
    public GameObject yo;

	void Start () {
		
	}
	
	// Update is called once per frame
	void OnEnable () {
        if (Controlador.Dias >= 1 )
        {
            yo.GetComponent<ControlSubs>().enabled = false;
            yo.GetComponent<Suscriptores>().enabled = true;
            Debug.Log("Mas subs");
        }

        if (Controlador.Dias == 0)
        {
            yo.GetComponent<Suscriptores>().enabled = false;
          //  yo.GetComponent<Seguidores>().enabled = true;
            // wow.SetActive(false);
            Debug.Log("Se acabo wey");
        }
    }
}
