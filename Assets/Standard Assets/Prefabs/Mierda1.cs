using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mierda1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(transform.localEulerAngles.x);
        if (transform.localEulerAngles.x >= 280)
        {           
            Debug.Log("ROTACIÓN PUTA MADRE");
            Animaciones.Rotacion = true;
        }
        if (transform.localEulerAngles.x < 280 && transform.localEulerAngles.x > 250)
        {
            Animaciones.Rotacion = false;
        }
        if (transform.localEulerAngles.x <= 1)
        {
            Debug.Log("ROTACIÓN PUTA MADRE");
            Animaciones.Rotacion = true;
        }
        if (transform.localEulerAngles.x > 1 && transform.localEulerAngles.x < 200)
        {
            Animaciones.Rotacion = false;
        }
    }
}
