using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edicion : MonoBehaviour {

	public GameObject simple;
    public GameObject normal;
    public GameObject complex;
    public GameObject yo;
    public static int basta = 0;
    public GameObject w1;
    public GameObject w2;
    public GameObject camaraman;
    public GameObject cama;

    public GameObject yo2;
    public GameObject nombre;
    public GameObject out2;

    void Start()
    {
       
    } 



    void Update () {
        if (Controlador.TipoEdicion == 0)
        {
            yo.GetComponent<BoxCollider>().enabled = false;
            simple.SetActive(false);
            normal.SetActive(false);
            complex.SetActive(false);
        }
        if (Controlador.TipoEdicion == 1)
        {
            yo.GetComponent<BoxCollider>().enabled = true;
            simple.SetActive(true);
            normal.SetActive(false);
            complex.SetActive(false);
        }
        if (Controlador.TipoEdicion == 2)
        {
            yo.GetComponent<BoxCollider>().enabled = true;
            simple.SetActive(false);
            normal.SetActive(true);
            complex.SetActive(false);
        }
        if (Controlador.TipoEdicion == 3)
        {
            yo.GetComponent<BoxCollider>().enabled = true;
            simple.SetActive(false);
            normal.SetActive(false);
            complex.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void OnMouseDown () {
        if (basta == 0)
        {

            if (Controlador.TipoEdicion == 1)
            {
                if (Controlador.Video >= 0 && Controlador.Video <= 11)
                {
                    Controlador.Video -= 3;
                    if (Controlador.Video <= 0)
                    {
                        Controlador.Video = 2;
                    }
                    Debug.Log(Controlador.Video);
                    basta = 1;
                }

                if (Controlador.Video >= 12 && Controlador.Video <= 24)
                {
                    Controlador.Video -= 5;
                    Debug.Log(Controlador.Video);
                    basta = 1;
                }

                if (Controlador.Video >= 25 && Controlador.Video <= 34)
                {
                    Controlador.Video -= 8;
                    Debug.Log(Controlador.Video);
                    basta = 1;
                }
            }

            if (Controlador.TipoEdicion == 2)
            {
                if (Controlador.Video >= 0 && Controlador.Video <= 11)
                {
                    if (basta == 0)
                    {
                        Controlador.Video += 3;
                        Debug.Log(Controlador.Video);
                        basta = 1;
                    }
                    }

                if (Controlador.Video >= 12 && Controlador.Video <= 24)
                {
                    if (basta == 0)
                    {
                        Controlador.Video += 5;
                        Debug.Log(Controlador.Video);
                        basta = 1;
                    }
                    }

                if (Controlador.Video >= 25 && Controlador.Video <= 34)
                {
                    if (basta == 0)
                    {
                        Controlador.Video += 2;
                        Debug.Log(Controlador.Video);
                        basta = 1;
                    }
                    }
            }

            if (Controlador.TipoEdicion == 3)
            {
                if (Controlador.Video >= 0 && Controlador.Video <= 11)
                {
                    if (basta == 0)
                    {
                        Controlador.Video += 8;
                        Debug.Log(Controlador.Video);
                        basta = 1;
                    }
                    }

                if (Controlador.Video >= 12 && Controlador.Video <= 24)
                {
                    if (basta == 0)
                    {
                        Controlador.Video += 7;
                    Debug.Log(Controlador.Video);
                    basta = 1;
                }
                }

                if (Controlador.Video >= 25 && Controlador.Video <= 34)
                {
                    if (basta == 0)
                    {
                        Controlador.Video += 4;
                        Debug.Log(Controlador.Video);
                        basta = 1;
                    }
                    }
            }

        }//AFECTARÁ A LA POPULARIDAD DEL CANAL Y AL DINERO
        quita2();
       // quita();
    }

    void quita2()
    {
        canciones.permiso = false;
        yo2.SetActive(false);
        nombre.SetActive(true);
        out2.SetActive(false);
    }






        void quita ()
    {
        Controlador.VideoGrabao = 1;
        Controlador.amplia = 1;
        camaraman.GetComponent<Camara>().enabled = true;
        camaraman.GetComponent<Desactibaor>().enabled = false;
        w1.SetActive(true);
        w2.SetActive(false);
        cama.SetActive(true);
        Videojuegos.nota = 0;
  //      Controlador.TipoEdicion = 0;
        Debug.Log("TUPUTAMADRE");
        Debug.Log(Controlador.VideoGrabao);


    }


}
