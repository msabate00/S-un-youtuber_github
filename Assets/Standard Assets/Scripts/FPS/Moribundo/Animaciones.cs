using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animaciones : MonoBehaviour {

    public static bool Distancia = false;
    public static bool Rotacion = false;
    public static bool Ahora = false;
    public static bool Ahorayo = false;
    public static int Animacion = 0;
    public static int Cosa = 1;
    public static bool Laterales = false;
    public static bool Yo = true;
    public static bool Trigger = false;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      //  Debug.Log(Animacion);
        if (Distancia == true)
        {
            
            if (Rotacion == true)
            {
                //Debug.Log("AHORAAAAAAAAAAAAAAAAAAAAAAAA");
                Ahora = true;

            }

        }
        }
}
