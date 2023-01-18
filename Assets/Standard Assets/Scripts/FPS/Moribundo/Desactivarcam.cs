using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivarcam : MonoBehaviour {

    public GameObject cam;
    void Start () {

        
       
	}
	
	// Update is called once per frame
	void Update () {
		if (Animaciones.Laterales)
        {

            cam.SetActive(false);

        }
	}
}
