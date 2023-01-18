using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class darcosas : MonoBehaviour {

    public int cosasadar;
    public bool tocho;
    public bool normal;
    public bool camper;

    void Start () {
        Controlador.usos += cosasadar;
        Controlador.vidahomosexual += 32;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
