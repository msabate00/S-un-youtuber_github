using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualizarint : MonoBehaviour {

    public static int activao = 1;
    float visuales;
    float visualin;
    public GameObject yo;

    void Start() {

    }

    // Update is called once per frame
    void OnEnable() {

        if (activao == 1)
        {

            if (Controlador.VideoGrabao == 0)

            {
                activao = 0;
                yo.GetComponent<Visualizarint>().enabled = false;
            }


            if (Controlador.VideoGrabao == 1)

            {
                activao = 2;
                if (Videojuegos.juegoselecint == 1)
                {
                    visuales = Controlador.Visualizaciones;
                    visuales *= -0.5f;

                    Redondear();
                }
                if (Videojuegos.juegoselecint == 2)
                {
                    visuales = Controlador.Visualizaciones;
                    visuales *= -0.2f;

                    Redondear();
                }
                if (Videojuegos.juegoselecint == 3)
                {
                    visuales = Controlador.Visualizaciones;
                    visuales *= 0f;

                    Redondear();
                }
                if (Videojuegos.juegoselecint == 4)
                {
                    visuales = Controlador.Visualizaciones;
                    visuales *= 0.2f;

                    Redondear();
                }
                if (Videojuegos.juegoselecint == 5)
                {
                    visuales = Controlador.Visualizaciones;
                    visuales *= 0.5f;

                    Redondear();
                }

            }

        }
        if (activao == 0)
        {

            yo.GetComponent<Visualizarint>().enabled = false;


        }

        }

     

        void Redondear()
    {
            visualin = Mathf.Round(visuales);

        Controlador.Visualizaciones += visualin;
        Debug.Log(Controlador.Visualizaciones);
        activao = 0;
        yo.GetComponent<Visualizarint>().enabled = false;

    }
    }

