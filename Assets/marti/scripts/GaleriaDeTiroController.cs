using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GaleriaDeTiroController : MonoBehaviour
{

    public TextMeshProUGUI puntuacion_text;
    public float puntuacion;
    public vidacosa[] dianas;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puntuacion_text.text = puntuacion.ToString() + "/10";
    }


    public void resetSistema() {

        puntuacion = 0;
        foreach (vidacosa diana in dianas)
        {
            diana.salud = 1;
            diana.morido = false;
            diana.gameObject.GetComponent<GaleriaDeTiroCount>().tocado = false;
        }
    }

    public void sumarPuntuacion(float puntuacion) {
        this.puntuacion += puntuacion;
    
    }


   

}
