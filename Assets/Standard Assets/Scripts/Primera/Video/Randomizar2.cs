using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizar2 : MonoBehaviour
{

    public GameObject yo;


    void OnEnable()
    {
        int pene = Random.Range(1, 41);
        Controlador.Lenguaje1 = pene;
       // Debug.Log(Controlador.Lenguaje1);
       // yo.SetActive(false);
    }
}
