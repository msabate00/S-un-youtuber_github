using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesCam : MonoBehaviour {
   private bool desactiva2 = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnEnable () {
        desactiva2 = true;
        if (Animaciones.Trigger)
        {
            if (desactiva2)
            {
                if (Animaciones.Yo)
                {
                    Animaciones.Yo = false;
                    desactiva2 = false;
                }
            }
            if (desactiva2)
            {
                if (!Animaciones.Yo)
                {
                    Animaciones.Yo = true;
                    desactiva2 = false;
                }
            }
        }
	}
}
