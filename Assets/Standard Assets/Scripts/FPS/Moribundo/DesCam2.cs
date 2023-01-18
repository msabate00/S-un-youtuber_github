using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesCam2 : MonoBehaviour {

    public Camera LOL;
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
		if (Animaciones.Yo)
        {
            LOL.enabled = true;
        }

        if (!Animaciones.Yo)
        {
            LOL.enabled = false;
        }
    }
}
