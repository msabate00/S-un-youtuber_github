using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calidadvideo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnMouseDown () {
        Controlador.Video += Controlador.Edicion;
        Controlador.Video += Controlador.Comunicacion;
        Controlador.Video += Controlador.Skill;
        Debug.Log(Controlador.Video);
    }
}
