using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlasaltos : MonoBehaviour {

	public static float salto = 3f;
    public static float saltoanim = 0.1f;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Controlador.times >= 2)
        {
            Debug.Log("AHORA!");
            salto = 0.2f;
            saltoanim = 0.05f;
        }
	}
}
