using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Permitidor1 : MonoBehaviour {

    public GameObject j11;
    public GameObject j12; //j= juego; 1= juego 1; 2= gameobject 2 seleccionado
    public GameObject j13;
    
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Videojuegos.juego1com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j11.SetActive(false);
            j12.SetActive(true);
            j13.SetActive(false);
        }
        if (Videojuegos.juego1com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j11.SetActive(true);
            j12.SetActive(false);
            j13.SetActive(false);
        }
        if (Videojuegos.juego1req > Controlador.Ordenador) //no lo es
        {
            j11.SetActive(false);
            j12.SetActive(false);
            j13.SetActive(true);
        }
        if (Videojuegos.juego1req <= Controlador.Ordenador)  //es accedible
        {
            j11.SetActive(true);
            j12.SetActive(false);
            j13.SetActive(false);
        }






















    }
}
