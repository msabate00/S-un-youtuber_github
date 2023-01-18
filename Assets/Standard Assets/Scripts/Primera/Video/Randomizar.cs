using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizar : MonoBehaviour {

    public GameObject yo;


    void OnEnable()
    { 
        int pene = Random.Range(1, 41);
        Controlador.Lenguaje = pene; 
       // Debug.Log(Controlador.Lenguaje);
        
    }
}
