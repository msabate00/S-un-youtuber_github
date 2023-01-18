using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class configuracion5 : MonoBehaviour
{
    public GameObject yo;
    public GameObject yo2;
    public GameObject nots;
    public GameObject camaraman;
    public GameObject out2;
    public GameObject menu2;
    public GameObject menu3;
    public GameObject menu4;
    public GameObject menu5;

    void Start()
    {

    }

    // Update is called once per frame
    void OnMouseDown()
    {
        camaraman.GetComponent<Camara>().enabled = false;
        camaraman.GetComponent<Desactibaor>().enabled = true;
        Controlador.amplia = 2;
        Debug.Log(Controlador.amplia);
        //  desactiver.SetActive(false);
        nots.SetActive(true);
        menu2.SetActive(false);
        yo.SetActive(false);
        yo2.SetActive(false);
        out2.SetActive(true);
        menu3.SetActive(false);
        menu4.SetActive(false);
        menu5.SetActive(false);
    }
}








