using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguidores : MonoBehaviour
{

    public GameObject yo;

    void Start()
    {

    }

    // Update is called once per frame
    void OnEnable()
    {
        Controlador.Times += 1;
        if (Controlador.VideoGrabao == 1)
        {
            if (Controlador.Video >= 0 && Controlador.Video <= 12)
            {
                if (Controlador.Seguidores >= 0 && Controlador.Seguidores <= 14)
                {
                    Controlador.Diaspasaos = 0;
                    Controlador.Seguidoresprov -= 5;
                    Controlador.Video2 = Controlador.Video;
                    yo.GetComponent<Seguidores>().enabled = false;

                    if (Controlador.Seguidores <= 0)
                    {
                        Controlador.Seguidores = 3;
                        Controlador.Video2 = Controlador.Video;
                        yo.GetComponent<Seguidores>().enabled = false;
                    }

                }

                if (Controlador.Seguidores >= 15 && Controlador.Seguidores <= 30)
                {

                    Controlador.Diaspasaos = 0;
                    Controlador.Seguidoresprov -= 8;
                    Controlador.Video2 = Controlador.Video;
                    yo.GetComponent<Seguidores>().enabled = false;
                }

                if (Controlador.Seguidores >= 31 && Controlador.Seguidores <= 44)
                {

                    Controlador.Diaspasaos = 0;
                    Controlador.Seguidoresprov -= 7;
                    Controlador.Video2 = Controlador.Video;
                    yo.GetComponent<Seguidores>().enabled = false;
                }

                if (Controlador.Seguidores >= 45 && Controlador.Seguidores <= 60)
                {

                    Controlador.Diaspasaos = 0;
                    Controlador.Seguidoresprov -= 5;
                    Controlador.Video2 = Controlador.Video;
                    yo.GetComponent<Seguidores>().enabled = false;
                }
            }

            if (Controlador.Video >= 13 && Controlador.Video <= 24)
            {
                if (Controlador.Seguidores >= 0 && Controlador.Seguidores <= 14)
                {
                    Controlador.Diaspasaos = 0;
                    Controlador.Seguidoresprov -= 3;
                    Controlador.Video2 = Controlador.Video;
                    yo.GetComponent<Seguidores>().enabled = false;
                    if (Controlador.Seguidores <= 0)
                    {
                        Controlador.Seguidores = 3;
                        Controlador.Video2 = Controlador.Video;
                        yo.GetComponent<Seguidores>().enabled = false;
                    }

                }

                if (Controlador.Seguidores >= 15 && Controlador.Seguidores <= 30)
                {

                    Controlador.Diaspasaos = 0;
                    Controlador.Seguidoresprov -= 5;
                    Controlador.Video2 = Controlador.Video;
                    yo.GetComponent<Seguidores>().enabled = false;
                }

                if (Controlador.Seguidores >= 31 && Controlador.Seguidores <= 44)
                {

                    Controlador.Diaspasaos = 0;
                    Controlador.Seguidoresprov += 2;
                    Controlador.Video2 = Controlador.Video;
                    yo.GetComponent<Seguidores>().enabled = false;
                }

                if (Controlador.Seguidores >= 45 && Controlador.Seguidores <= 60)
                {

                    Controlador.Diaspasaos = 0;
                    Controlador.Seguidoresprov -= 1;
                    Controlador.Video2 = Controlador.Video;
                    yo.GetComponent<Seguidores>().enabled = false;

                }



            }

            if (Controlador.Video >= 25 && Controlador.Video <= 33)
            {
                if (Controlador.Seguidores >= 0 && Controlador.Seguidores <= 14)
                {
                    Controlador.Diaspasaos = 0;
                    Controlador.Seguidoresprov += 3;
                    Controlador.Video2 = Controlador.Video;
                    yo.GetComponent<Seguidores>().enabled = false;

                    if (Controlador.Seguidores <= 0)
                    {
                        Controlador.Seguidores = 3;
                        Controlador.Video2 = Controlador.Video;
                        yo.GetComponent<Seguidores>().enabled = false;
                    }

                }

                if (Controlador.Seguidores >= 15 && Controlador.Seguidores <= 30)
                {

                    Controlador.Diaspasaos = 0;
                    Controlador.Seguidoresprov += 4;
                    Controlador.Video2 = Controlador.Video;
                    yo.GetComponent<Seguidores>().enabled = false;
                }

                if (Controlador.Seguidores >= 31 && Controlador.Seguidores <= 44)
                {

                    Controlador.Diaspasaos = 0;
                    Controlador.Seguidoresprov += 5;
                    Controlador.Video2 = Controlador.Video;
                    yo.GetComponent<Seguidores>().enabled = false;
                }

                if (Controlador.Seguidores >= 45 && Controlador.Seguidores <= 60)
                {

                    Controlador.Diaspasaos = 0;
                    Controlador.Seguidoresprov += 3;
                    Controlador.Video2 = Controlador.Video;
                    yo.GetComponent<Seguidores>().enabled = false;
                }



            }

            if (Controlador.Video >= 34 && Controlador.Video <= 40)
            {
                if (Controlador.Seguidores >= 0 && Controlador.Seguidores <= 14)
                {
                    Controlador.Diaspasaos = 0;
                    Controlador.Seguidoresprov += 7;
                    Controlador.Video2 = Controlador.Video;
                    yo.GetComponent<Seguidores>().enabled = false;
                    if (Controlador.Seguidores <= 0)
                    {
                        Controlador.Seguidores = 3;
                        Controlador.Video2 = Controlador.Video;
                        yo.GetComponent<Seguidores>().enabled = false;
                    }

                }

                if (Controlador.Seguidores >= 15 && Controlador.Seguidores <= 30)
                {

                    Controlador.Diaspasaos = 0;
                    Controlador.Seguidoresprov += 8;
                    Controlador.Video2 = Controlador.Video;
                    yo.GetComponent<Seguidores>().enabled = false;
                }

                if (Controlador.Seguidores >= 31 && Controlador.Seguidores <= 44)
                {

                    Controlador.Diaspasaos = 0;
                    Controlador.Seguidoresprov += 7;
                    Controlador.Video2 = Controlador.Video;
                    yo.GetComponent<Seguidores>().enabled = false;
                }

                if (Controlador.Seguidores >= 45 && Controlador.Seguidores <= 60)
                {

                    Controlador.Diaspasaos = 0;
                    Controlador.Seguidoresprov += 5;
                    Controlador.Video2 = Controlador.Video;
                    yo.GetComponent<Seguidores>().enabled = false;
                }



            }
            
            Debug.Log(Controlador.Seguidores);
            Debug.Log(Controlador.Video2);
            Debug.Log(Controlador.Diaspasaos);
        }

        if (Controlador.VideoGrabao == 0)
        {
            if (Controlador.Diaspasaos >= 0 && Controlador.Diaspasaos <= 6)
            {
                yo.GetComponent<Seguidores>().enabled = false;
            }

                if (Controlador.Diaspasaos >= 7 && Controlador.Diaspasaos <= 12)
            {
                if (Controlador.Seguidores >= 0 && Controlador.Seguidores <= 14)
                {
                    Controlador.Seguidoresprov += 7;
                    yo.GetComponent<Seguidores>().enabled = false;
                }

                if (Controlador.Seguidores >= 15 && Controlador.Seguidores <= 30)
                {

                    Controlador.Seguidoresprov += 5;
                    yo.GetComponent<Seguidores>().enabled = false;
                }

                if (Controlador.Seguidores >= 31 && Controlador.Seguidores <= 44)
                {

                    Controlador.Seguidoresprov -= 5;
                    yo.GetComponent<Seguidores>().enabled = false;
                }

                if (Controlador.Seguidores >= 45 && Controlador.Seguidores <= 60)
                {

                    Controlador.Seguidoresprov -= 8;
                    yo.GetComponent<Seguidores>().enabled = false;
                }


            }

            if (Controlador.Diaspasaos >= 13 && Controlador.Diaspasaos <= 24)
            {

                if (Controlador.Seguidores >= 0 && Controlador.Seguidores <= 14)
                {
                    Controlador.Seguidoresprov += 5;
                    yo.GetComponent<Seguidores>().enabled = false;
                }

                if (Controlador.Seguidores >= 15 && Controlador.Seguidores <= 30)
                {

                    Controlador.Seguidoresprov += 5;
                    yo.GetComponent<Seguidores>().enabled = false;
                }

                if (Controlador.Seguidores >= 31 && Controlador.Seguidores <= 44)
                {

                    Controlador.Seguidoresprov -= 8;
                    yo.GetComponent<Seguidores>().enabled = false;
                }

                if (Controlador.Seguidores >= 45 && Controlador.Seguidores <= 60)
                {

                    Controlador.Seguidoresprov -= 15;
                    yo.GetComponent<Seguidores>().enabled = false;
                }

            }

            if (Controlador.Diaspasaos >= 25 && Controlador.Diaspasaos <= 37)
            {

                if (Controlador.Seguidores >= 0 && Controlador.Seguidores <= 14)
                {
                    Controlador.Seguidoresprov -= 2;
                    yo.GetComponent<Seguidores>().enabled = false;
                    if (Controlador.Seguidores <= 0)
                    {
                        Controlador.Seguidores = 3;
                        yo.GetComponent<Seguidores>().enabled = false;
                    }

                }

                if (Controlador.Seguidores >= 15 && Controlador.Seguidores <= 30)
                {

                    Controlador.Seguidoresprov -= 3;
                    yo.GetComponent<Seguidores>().enabled = false;
                }

                if (Controlador.Seguidores >= 31 && Controlador.Seguidores <= 44)
                {

                    Controlador.Seguidoresprov -= 10;
                    yo.GetComponent<Seguidores>().enabled = false;
                }

                if (Controlador.Seguidores >= 45 && Controlador.Seguidores <= 60)
                {

                    Controlador.Seguidoresprov -= 15;
                    yo.GetComponent<Seguidores>().enabled = false;
                }

            }

            if (Controlador.Diaspasaos >= 38)
            {

                if (Controlador.Seguidores >= 0 && Controlador.Seguidores <= 14)
                {
                    Controlador.Seguidoresprov -= 2;
                    yo.GetComponent<Seguidores>().enabled = false;

                    if (Controlador.Seguidores <= 0)
                    {
                        Controlador.Seguidores = 3;
                        yo.GetComponent<Seguidores>().enabled = false;
                    }

                }

                if (Controlador.Seguidores >= 15 && Controlador.Seguidores <= 30)
                {

                    Controlador.Seguidoresprov -= 5;
                    yo.GetComponent<Seguidores>().enabled = false;
                }

                if (Controlador.Seguidores >= 31 && Controlador.Seguidores <= 44)
                {

                    Controlador.Seguidoresprov -= 10;
                    yo.GetComponent<Seguidores>().enabled = false;
                }

                if (Controlador.Seguidores >= 45 && Controlador.Seguidores <= 60)
                {

                    Controlador.Seguidoresprov -= 15;
                    yo.GetComponent<Seguidores>().enabled = false;
                }

            }
            Debug.Log(Controlador.Seguidores);

        }

        


    }
}
