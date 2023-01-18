using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nsetio : MonoBehaviour
{
    public GameObject yo;
   // public GUIText texto;
    //public GUIText texto2;
    //public GUIText texto3;
//    public GUIText texto4;
 //   public GUIText texto5;
    public static int primero = 0;
    public static int segundo = 0;
    public static int tercero = 0;
    public static int juego1max = 0;
    public static int juego2max = 0;
    int times = 0;

    void Update()
    {
        //texto.text = primero.ToString();
        //texto2.text = segundo.ToString();
        //texto3.text = tercero.ToString();
     //   texto5.text = times.ToString();
    }
    void OnEnable()
    {
        int polla = Random.Range(1, 16);
        primero = polla;
        dale();
    }

    // Update is called once per frame
    void dale()
    {
        times += 1;
        int penis = Random.Range(1, 16); // para trending de mas alante coger el random de la camara del efpies
        if (penis == primero)
        {
            dale();

        }
        if (penis != primero)
        {
            segundo = penis;
            dale2();
        }
    }

    void dale2()
    {
        times += 1;
        int penisman = Random.Range(1, 16);
        if (penisman == primero)
        {
            dale2();
            times += 1;
        }
        if (penisman == segundo)
        {
            dale2();
            times += 1;
        }
        if (penisman != primero && penisman != segundo)
        {
            tercero = penisman;
            asignar();
        }
    }
    

    void asignar()
    {
        Debug.Log(primero);
        Debug.Log(segundo);
        Debug.Log(tercero);
        Restavideos1.tend1 = false;
        Restavideos1.tend2 = false;
        Restavideos1.tend3 = false;
        Restavideos1.tend4 = false;
        Restavideos1.tend5 = false;
        Restavideos1.tend6 = false;
        Restavideos1.tend7 = false;
        Restavideos1.tend8 = false;
        Restavideos1.tend9 = false;
        Restavideos1.tend10 = false;
        Restavideos1.tend11 = false;
        Restavideos1.tend12 = false;
        Restavideos1.tend13 = false;
        Restavideos1.tend14 = false;
        Restavideos1.tend15 = false;
        if (primero == 1)
        {
            Videojuegos.juego1int = 5;
            Videojuegos.juego1intmax = 5;
            Restavideos1.tend1 = true;
        }
        if (primero == 2)
        {
            Videojuegos.juego2int = 5;
            Videojuegos.juego2intmax = 5;
            Restavideos1.tend2 = true;
        }
        if (primero == 3)
        {
            Videojuegos.juego3int = 5;
            Videojuegos.juego3intmax = 5;
            Restavideos1.tend3 = true;
        }
        if (primero == 4)
        {
            Videojuegos.juego4int = 5;
            Videojuegos.juego4intmax = 5;
            Restavideos1.tend4 = true;
        }
        if (primero == 5)
        {
            Videojuegos.juego5int = 5;
            Videojuegos.juego5intmax = 5;
            Restavideos1.tend5 = true;
        }
        if (primero == 6)
        {
            Videojuegos.juego6int = 5;
            Videojuegos.juego6intmax = 5;
            Restavideos1.tend6 = true;
        }
        if (primero == 7)
        {
            Videojuegos.juego7int = 4;
            Videojuegos.juego7intmax = 4;
            Restavideos1.tend7 = true;
        }
        if (primero == 8)
        {
            Videojuegos.juego8int = 5;
            Videojuegos.juego8intmax = 5;
            Restavideos1.tend8 = true;
        }
        if (primero == 9)
        {
            Videojuegos.juego9int = 5;
            Videojuegos.juego9intmax = 5;
            Restavideos1.tend9 = true;
        }
        if (primero == 10)
        {
            Videojuegos.juego10int = 5;
            Videojuegos.juego10intmax = 5;
            Restavideos1.tend10 = true;
        }
        if (primero == 11)
        {
            Videojuegos.juego11int = 5;
            Videojuegos.juego11intmax = 5;
            Restavideos1.tend11 = true;
        }
        if (primero == 12)
        {
            Videojuegos.juego12int = 5;
            Videojuegos.juego12intmax = 5;
            Restavideos1.tend12 = true;
        }
        if (primero == 13)
        {
            Videojuegos.juego13int = 5;
            Videojuegos.juego13intmax = 5;
            Restavideos1.tend13 = true;
        }
        if (primero == 14)
        {
            Videojuegos.juego14int = 5;
            Videojuegos.juego14intmax = 5;
            Restavideos1.tend14 = true;
        }
        if (primero == 15)
        {
            Videojuegos.juego15int = 5;
            Videojuegos.juego15intmax = 5;
            Restavideos1.tend15 = true;
        }





        if (segundo == 1)
        {
            Videojuegos.juego1int = 5;
            Videojuegos.juego1intmax = 5;
            Restavideos1.tend1 = true;
        }
        if (segundo == 2)
        {
            Videojuegos.juego2int = 5;
            Videojuegos.juego2intmax = 5;
            Restavideos1.tend2 = true;
        }
        if (segundo == 3)
        {
            Videojuegos.juego3int = 5;
            Videojuegos.juego3intmax = 5;
            Restavideos1.tend3 = true;
        }
        if (segundo == 4)
        {
            Videojuegos.juego4int = 5;
            Videojuegos.juego4intmax = 5;
            Restavideos1.tend4 = true;
        }
        if (segundo == 5)
        {
            Videojuegos.juego5int = 5;
            Videojuegos.juego5intmax = 5;
            Restavideos1.tend5 = true;
        }
        if (segundo == 6)
        {
            Videojuegos.juego6int = 5;
            Videojuegos.juego6intmax = 5;
            Restavideos1.tend6 = true;
        }
        if (segundo == 7)
        {
            Videojuegos.juego7int = 4;
            Videojuegos.juego7intmax = 4;
            Restavideos1.tend7 = true;
        }
        if (segundo == 8)
        {
            Videojuegos.juego8int = 5;
            Videojuegos.juego8intmax = 5;
            Restavideos1.tend8 = true;
        }
        if (segundo == 9)
        {
            Videojuegos.juego9int = 5;
            Videojuegos.juego9intmax = 5;
            Restavideos1.tend9 = true;
        }
        if (segundo == 10)
        {
            Videojuegos.juego10int = 5;
            Videojuegos.juego10intmax = 5;
            Restavideos1.tend10 = true;
        }
        if (segundo == 11)
        {
            Videojuegos.juego11int = 5;
            Videojuegos.juego11intmax = 5;
            Restavideos1.tend11 = true;
        }
        if (segundo == 12)
        {
            Videojuegos.juego12int = 5;
            Videojuegos.juego12intmax = 5;
            Restavideos1.tend12 = true;
        }
        if (segundo == 13)
        {
            Videojuegos.juego13int = 5;
            Videojuegos.juego13intmax = 5;
            Restavideos1.tend13 = true;
        }
        if (segundo == 14)
        {
            Videojuegos.juego14int = 5;
            Videojuegos.juego14intmax = 5;
            Restavideos1.tend14 = true;
        }
        if (segundo == 15)
        {
            Videojuegos.juego15int = 5;
            Videojuegos.juego15intmax = 5;
            Restavideos1.tend15 = true;
        }



        if (tercero == 1)
        {
            Videojuegos.juego1int = 5;
            Videojuegos.juego1intmax = 5;
            Restavideos1.tend1 = true;
        }
        if (tercero == 2)
        {
            Videojuegos.juego2int = 5;
            Videojuegos.juego2intmax = 5;
            Restavideos1.tend2 = true;
        }
        if (tercero == 3)
        {
            Videojuegos.juego3int = 5;
            Videojuegos.juego3intmax = 5;
            Restavideos1.tend3 = true;
        }
        if (tercero == 4)
        {
            Videojuegos.juego4int = 5;
            Videojuegos.juego4intmax = 5;
            Restavideos1.tend4 = true;
        }
        if (tercero == 5)
        {
            Videojuegos.juego5int = 5;
            Videojuegos.juego5intmax = 5;
            Restavideos1.tend5 = true;
        }
        if (tercero == 6)
        {
            Videojuegos.juego6int = 5;
            Videojuegos.juego6intmax = 5;
            Restavideos1.tend6 = true;
        }
        if (tercero == 7)
        {
            Videojuegos.juego7int = 4;
            Videojuegos.juego7intmax = 4;
            Restavideos1.tend7 = true;
        }
        if (tercero == 8)
        {
            Videojuegos.juego8int = 5;
            Videojuegos.juego8intmax = 5;
            Restavideos1.tend8 = true;
        }
        if (tercero == 9)
        {
            Videojuegos.juego9int = 5;
            Videojuegos.juego9intmax = 5;
            Restavideos1.tend9 = true;
        }
        if (tercero == 10)
        {
            Videojuegos.juego10int = 5;
            Videojuegos.juego10intmax = 5;
            Restavideos1.tend10 = true;
        }
        if (tercero == 11)
        {
            Videojuegos.juego11int = 5;
            Videojuegos.juego11intmax = 5;
            Restavideos1.tend11 = true;
        }
        if (tercero == 12)
        {
            Videojuegos.juego12int = 5;
            Videojuegos.juego12intmax = 5;
            Restavideos1.tend12 = true;
        }
        if (tercero == 13)
        {
            Videojuegos.juego13int = 5;
            Videojuegos.juego13intmax = 5;
            Restavideos1.tend13 = true;
        }
        if (tercero == 14)
        {
            Videojuegos.juego14int = 5;
            Videojuegos.juego14intmax = 5;
            Restavideos1.tend14 = true;
        }
        if (tercero == 15)
        {
            Videojuegos.juego15int = 5;
            Videojuegos.juego15intmax = 5;
            Restavideos1.tend15 = true;
        }

        //  yo.GetComponent<Nsetio>().enabled = false;






    }
}