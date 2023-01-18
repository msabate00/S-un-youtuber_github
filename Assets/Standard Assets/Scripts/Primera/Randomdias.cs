using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomdias : MonoBehaviour {

    public GameObject Controlsuvs;

	void Start () {
		
	}
	
	// Update is called once per frame
	void OnEnable () {
        int pene = Random.Range(3, 8);
        Restavideos2.diasguey += pene;
        Controlador.Diasdesdetrending += pene;
        Controlador.Diasgente = pene;
        Controlador.Dias = pene;
        Controlador.Dias2 = pene;
        Controlador.Diastotales += pene;
        Controlador.Diaspasaos += pene;
        Controlador.diasinpaga += pene;
        Controlador.restantescompra -= pene;
        Gastador.dias = pene;


        Debug.Log(pene);
        Debug.Log(Controlador.Diaspasaos);
        Activaos();      
    }

    void Activaos()
    {
        Controlsuvs.GetComponent<ControlSubs>().enabled = true;
    }

}
