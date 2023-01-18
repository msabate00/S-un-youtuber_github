using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stats : MonoBehaviour {

    public static float Primero; //visitas
    public static float Segundo;
    public static float Tercero;
    public static float Cuarto;
    public static float Quinto;

    public static float d1;
    public static float d2;
    public static float d3; //dinero
    public static float d4;
    public static float d5;

    public static string n1; //nombre vidéo
    public static string n2;
    public static string n3;
    public static string n4;
    public static string n5;

    void OnEnable()
    {
        if (Controlador.VideoGrabao == 0)
        {
            Debug.Log("JODER PUTA MIERDA TIO");
            Debug.Log("JODER PUTA MIERDA TIO");
            Debug.Log("JODER PUTA MIERDA TIO");
            Debug.Log("JODER PUTA MIERDA TIO");
            Debug.Log("JODER PUTA MIERDA TIO");

        }
        if (Controlador.VideoGrabao == 1)
        {
            listagrafico.grabao = true;
             n5 = n4;
            Quinto = Cuarto;
            d5 = d4;
            Conversorini();
 
        }
    }
    void Conversorini()
    {
        n4 = n3;
        Cuarto = Tercero;
        d4 = d3;
        Conversor();

    }

    void Conversor()
    {
        n3 = n2;
        Tercero = Segundo;
        d3 = d2;
        Conversor2();

    }

    void Conversor2()
    {
        n2 = n1;
        Segundo = Primero;
        d2 = d1;
        Conversor3();

    }

    void Conversor3()
    {
        n1 = Controlador.nombrevid;
        Primero = Controlador.Visualizaciones;
        d1 = Controlador.dinerobid;

    }
}
