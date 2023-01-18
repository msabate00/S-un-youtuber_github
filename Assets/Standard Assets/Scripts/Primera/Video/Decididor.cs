using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decididor : MonoBehaviour {

    //  public GameObject Grabar;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Videojuegos.nota == 0)
        {
            //  Grabar.SetActive(false);
        }
        if (Videojuegos.nota == 1)
        {
            Controlador.Min1 = 97;
            Controlador.Max1 = 100;
            Controlador.Min2 = 73;
            Controlador.Max2 = 96;
            Controlador.Min3 = 1;
            Controlador.Max3 = 72;
            //      Grabar.SetActive(true);
        }
        if (Videojuegos.nota == 2)
        {
            Controlador.Min1 = 93;
            Controlador.Max1 = 100;
            Controlador.Min2 = 61;
            Controlador.Max2 = 92;
            Controlador.Min3 = 1;
            Controlador.Max3 = 60;
            //      Grabar.SetActive(true);
        }
        if (Videojuegos.nota == 3)
        {
            Controlador.Min1 = 89;
            Controlador.Max1 = 100;
            Controlador.Min2 = 51;
            Controlador.Max2 = 88;
            Controlador.Min3 = 1;
            Controlador.Max3 = 50;
            //     Grabar.SetActive(true);
        }
        if (Videojuegos.nota == 4)
        {
            Controlador.Min1 = 94;
            Controlador.Max1 = 100;
            Controlador.Min2 = 64;
            Controlador.Max2 = 93;
            Controlador.Min3 = 1;
            Controlador.Max3 = 63;
            //        Grabar.SetActive(true);
        }
        if (Videojuegos.nota == 5)
        {
            Controlador.Min1 = 88;
            Controlador.Max1 = 100;
            Controlador.Min2 = 48;
            Controlador.Max2 = 87;
            Controlador.Min3 = 1;
            Controlador.Max3 = 47;
            //     Grabar.SetActive(true);
        }
        if (Videojuegos.nota == 6)
        {
            Controlador.Min1 = 83;
            Controlador.Max1 = 100;
            Controlador.Min2 = 41;
            Controlador.Max2 = 82;
            Controlador.Min3 = 1;
            Controlador.Max3 = 40;
            //       Grabar.SetActive(true);
        }
        if (Videojuegos.nota == 7)
        {
            Controlador.Min1 = 91;
            Controlador.Max1 = 100;
            Controlador.Min2 = 56;
            Controlador.Max2 = 90;
            Controlador.Min3 = 1;
            Controlador.Max3 = 55;
            //      Grabar.SetActive(true);
        }
        if (Videojuegos.nota == 8)
        {
            Controlador.Min1 = 86;
            Controlador.Max1 = 100;
            Controlador.Min2 = 46;
            Controlador.Max2 = 85;
            Controlador.Min3 = 1;
            Controlador.Max3 = 45;
            //       Grabar.SetActive(true);
        }
        if (Videojuegos.nota == 9)
        {
            Controlador.Min1 = 81;
            Controlador.Max1 = 100;
            Controlador.Min2 = 38;
            Controlador.Max2 = 80;
            Controlador.Min3 = 1;
            Controlador.Max3 = 37;
          //  Grabar.SetActive(true);
        }
    }
}
