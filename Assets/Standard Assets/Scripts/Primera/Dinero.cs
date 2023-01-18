using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinero : MonoBehaviour {


    public float dinerobruto = 1;
    public float dinerin;
    public GameObject yo;

    void Start() {

    }

    // Update is called once per frame
    void OnEnable() {
        
       if (Controlador.trabajando && Controlador.diasinpaga >= 30)
        {
            Controlador.Dinero = Controlador.Dinero + 300;
            Controlador.diasinpaga = 0;
        }
        
        if (Controlador.VideoGrabao == 0)

        {
            //yo.GetComponent<Dinero>().enabled = false;
        }


        if (Controlador.VideoGrabao == 1)

        {
            int polla = Random.Range(1, 101);
            Debug.Log(polla);
            if (Controlador.TipoEdicion == 1)
            {
                if (polla >= 90)
                {
                    Controlador.Copy = true;
                }
                if (polla <= 89)
                {
                    Debug.Log("NO COPY HAHAH POLLASENTUBOCA");
                    Debug.Log("NO COPY HAHAH POLLASENTUBOCA");
                    Debug.Log("NO COPY HAHAH POLLASENTUBOCA");
                }
            }

            if (Controlador.TipoEdicion == 2)
            {
                if (polla >= 75)
                {
                    Controlador.Copy = true;
                }
                if (polla <= 74)
                {
                    Debug.Log("NO COPY HAHAH POLLASENTUBOCA"); // probabilidad de que te salga el copy segun el tipo de ediçâo
                    Debug.Log("NO COPY HAHAH POLLASENTUBOCA");
                    Debug.Log("NO COPY HAHAH POLLASENTUBOCA");
                }
            }

            if (Controlador.TipoEdicion == 3)
            {
                if (polla >= 63)
                {
                    Controlador.Copy = true;
                }
                if (polla <= 62)
                {
                    Debug.Log("NO COPY HAHAH POLLASENTUBOCA");
                    Debug.Log("NO COPY HAHAH POLLASENTUBOCA");
                    Debug.Log("NO COPY HAHAH POLLASENTUBOCA");
                }
            }


            if (!Controlador.Copy)
            {
                Debug.Log("VERIFICACION DE LA HOMOSEXUALIDAD BRUTAL POLICIAL PENES");
                dinerobruto = Controlador.Visualizaciones;
                dinerobruto /= 500;
                Youtube();
            }
            if (Controlador.Copy)
            {
                Controlador.dinerobid = 0;
                Debug.Log("DESMONETIZADO PUTA!");
                Debug.Log("DESMONETIZADO PUTA!");
                Debug.Log("DESMONETIZADO PUTA!");
            }
        }
        Controlador.TipoEdicion = 0;
    }
        void Youtube()
    {
            dinerobruto *= Controlador.DineroYoutube;
            dinerobruto /= 100;
            Network();
        }

        void Network()
    {
            dinerobruto *= Controlador.DineroNetwork;
            dinerobruto /= 100;
            Estado();
        }

        void Estado()
    {
            dinerobruto *= Controlador.DineroEstado;
            dinerobruto /= 100;
            Redondear();
        }

        void Redondear()
    {
            dinerin = dinerobruto;
      //  dinerin = System.Math.Round(dinerobruto, 2);
        Controlador.dinerobid = dinerin;
        Controlador.Dinero += dinerin;
        Debug.Log(Controlador.Dinero);
            Debug.Log(dinerin);
          //  yo.GetComponent<Dinero>().enabled = false;        
        }
    }

