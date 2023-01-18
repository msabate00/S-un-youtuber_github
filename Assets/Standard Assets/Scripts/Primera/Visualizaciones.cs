using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualizaciones : MonoBehaviour
{

    public GameObject yo;
    void Start()
    {

    }

    // Update is called once per frame
    void OnEnable()
    {
        Edicion.basta = 0;
        if (Controlador.VideoGrabao == 1)

        {
            if (Controlador.Suscriptores >= 0 && Controlador.Suscriptores <= 999)
            {
                if (Controlador.Video >= 0 && Controlador.Video <= 14)

                {
                    int polla = Random.Range(10, 100);
                    Debug.Log(polla);
                    Debug.Log("polla1");
                    Controlador.Visualizaciones = polla;
                   

                }

                if (Controlador.Video >= 15 && Controlador.Video <= 29)


                {
                    int polla = Random.Range(80, 250);
                    Debug.Log(polla);
                    Debug.Log("polla2");
                    Controlador.Visualizaciones = polla;


                }

                if (Controlador.Video >= 30 && Controlador.Video <= 40)

                {
                    int polla = Random.Range(200, 500);
                    Debug.Log(polla);
                    Debug.Log("polla3");
                    Controlador.Visualizaciones = polla;

                }

            }

            if (Controlador.Suscriptores >= 1000 && Controlador.Suscriptores <= 9999)
            {
                if (Controlador.Video >= 0 && Controlador.Video <= 14)

                {
                    int polla = Random.Range(100, 700);
                    Debug.Log(polla);
                    Debug.Log("polla4");
                    Controlador.Visualizaciones = polla;


                }

                if (Controlador.Video >= 15 && Controlador.Video <= 29)


                {
                    int polla = Random.Range(200, 2000);
                    Debug.Log(polla);
                    Debug.Log("polla5");
                    Controlador.Visualizaciones = polla;


                }

                if (Controlador.Video >= 30 && Controlador.Video <= 40)

                {
                    int polla = Random.Range(700, 7000);
                    Debug.Log(polla);
                    Debug.Log("polla6");
                    Controlador.Visualizaciones = polla;

                }

            }

            if (Controlador.Suscriptores >= 10000 && Controlador.Suscriptores <= 100000)
            {
                if (Controlador.Video >= 0 && Controlador.Video <= 14)

                {
                    int polla = Random.Range(5000, 20000);
                    Debug.Log(polla);
                    Debug.Log("polla7");
                    Controlador.Visualizaciones = polla;


                }

                if (Controlador.Video >= 15 && Controlador.Video <= 29)


                {
                    int polla = Random.Range(10000, 80000);
                    Debug.Log(polla);
                    Debug.Log("polla8");
                    Controlador.Visualizaciones = polla;


                }

                if (Controlador.Video >= 30 && Controlador.Video <= 40)

                {
                    int polla = Random.Range(20000, 100000);
                    Debug.Log(polla);
                    Debug.Log("polla9");
                    Controlador.Visualizaciones = polla;

                }

            }




        }

      //  yo.GetComponent<Visualizaciones>().enabled = false;

    }
}