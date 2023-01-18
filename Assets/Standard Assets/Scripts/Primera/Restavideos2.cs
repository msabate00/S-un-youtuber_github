using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restavideos2 : MonoBehaviour {

    public static int diasguey = 0;
    int dias1 = 0;
    int dias2 = 0;
    int dias3 = 0;
    int dias4 = 0;
    int dias5 = 0;
    int dias6 = 0;
    int dias7 = 0;
    int dias8 = 0;
    int dias9 = 0;
    int dias10 = 0;
    int dias11 = 0;
    int dias12 = 0;
    int dias13 = 0;
    int dias14 = 0;
    int dias15 = 0;
    int dias16 = 0;
    int dias17 = 0;
    int dias18 = 0;
    int dias19 = 0;
    int dias20 = 0;
    int dias21 = 0;
    int dias22 = 0;
    int dias23 = 0;
    int dias24 = 0;
    int dias25 = 0;
    int dias26 = 0;
    int dias27 = 0;
    int dias28 = 0;
    int dias29 = 0;
    int dias30 = 0;
    int dias31 = 0;
    int dias32 = 0;
    int dias33 = 0;
    int dias34 = 0;
    int dias35 = 0;

    void OnEnable () {
        dias1 += diasguey;
        dias2 += diasguey;
        dias3 += diasguey;
        dias4 += diasguey;
        dias5 += diasguey;
        dias6 += diasguey;
        dias7 += diasguey;
        dias8 += diasguey;
        dias9 += diasguey;
        dias10 += diasguey;
        dias11 += diasguey;
        dias12 += diasguey;
        dias13 += diasguey;
        dias14 += diasguey;
        dias15 += diasguey;
        dias16 += diasguey;
        dias17 += diasguey;
        dias18 += diasguey;
        dias19 += diasguey;
        dias20 += diasguey;
        dias21 += diasguey;
        dias22 += diasguey;
        dias23 += diasguey;
        dias24 += diasguey;
        dias25 += diasguey;
        dias26 += diasguey;
        dias27 += diasguey;
        dias28 += diasguey;
        dias29 += diasguey;
        dias30 += diasguey;
        dias31 += diasguey;
        dias32 += diasguey;
        dias33 += diasguey;
        dias34 += diasguey;
        dias35 += diasguey;
        if (Controlador.VideoGrabao == 1)
        {
            if (Controlador.Juegoselec == 1)
            {
                dias1 = 0;
            }
            if (Controlador.Juegoselec == 2)
            {
                dias2 = 0;
            }
            if (Controlador.Juegoselec == 3)
            {
                dias3 = 0;
            }
            if (Controlador.Juegoselec == 4)
            {
                dias4 = 0;
            }
            if (Controlador.Juegoselec == 5)
            {
                dias5 = 0;
            }
            if (Controlador.Juegoselec == 6)
            {
                dias6 = 0;
            }
            if (Controlador.Juegoselec == 7)
            {
                dias7 = 0;
            }
            if (Controlador.Juegoselec == 8)
            {
                dias8 = 0;
            }
            if (Controlador.Juegoselec == 9)
            {
                dias9 = 0;
            }
            if (Controlador.Juegoselec == 10)
            {
                dias10 = 0;
            }
            if (Controlador.Juegoselec == 11)
            {
                dias11 = 0;
            }
            if (Controlador.Juegoselec == 12)
            {
                dias12 = 0;
            }
            if (Controlador.Juegoselec == 13)
            {
                dias13 = 0;
            }
            if (Controlador.Juegoselec == 14)
            {
                dias14 = 0;
            }
            if (Controlador.Juegoselec == 15)
            {
                dias15 = 0;
            }
            if (Controlador.Juegoselec == 16)
            {
                dias16 = 0;
            }
            if (Controlador.Juegoselec == 17)
            {
                dias17 = 0;
            }
            if (Controlador.Juegoselec == 18)
            {
                dias18 = 0;
            }
            if (Controlador.Juegoselec == 19)
            {
                dias19 = 0;
            }
            if (Controlador.Juegoselec == 20)
            {
                dias20 = 0;
            }
            if (Controlador.Juegoselec == 21)
            {
                dias21 = 0;
            }
            if (Controlador.Juegoselec == 22)
            {
                dias22 = 0;
            }
            if (Controlador.Juegoselec == 23)
            {
                dias23 = 0;
            }
            if (Controlador.Juegoselec == 24)
            {
                dias24 = 0;
            }
            if (Controlador.Juegoselec == 25)
            {
                dias25 = 0;
            }
            if (Controlador.Juegoselec == 26)
            {
                dias26 = 0;
            }
            if (Controlador.Juegoselec == 27)
            {
                dias27 = 0;
            }
            if (Controlador.Juegoselec == 28)
            {
                dias28 = 0;
            }
            if (Controlador.Juegoselec == 29)
            {
                dias29 = 0;
            }
            if (Controlador.Juegoselec == 30)
            {
                dias30 = 0;
            }
            if (Controlador.Juegoselec == 31)
            {
                dias31 = 0;
            }
            if (Controlador.Juegoselec == 32)
            {
                dias32 = 0;
            }
            if (Controlador.Juegoselec == 33)
            {
                dias33 = 0;
            }
            if (Controlador.Juegoselec == 34)
            {
                dias34 = 0;
            }
            if (Controlador.Juegoselec == 35)
            {
                dias35 = 0;
            }
        }
        if (dias1 >= 14)
        {
            Videojuegos.juego1int += 2;
            dias1 = 0;
        }
        if (dias2 >= 14)
        {
            Videojuegos.juego2int += 2;
            dias2 = 0;
        }
        if (dias3 >= 14)
        {
            Videojuegos.juego3int += 2;
            dias3 = 0;
        }
        if (dias4 >= 14)
        {
            Videojuegos.juego4int += 2;
            dias4 = 0;
        }
        if (dias5 >= 14)
        {
            Videojuegos.juego5int += 2;
            dias5 = 0;
        }
        if (dias6 >= 14)
        {
            Videojuegos.juego6int += 2;
            dias6 = 0;
        }
        if (dias7 >= 14)
        {
            Videojuegos.juego7int += 2;
            dias7 = 0;
        }
        if (dias8 >= 14)
        {
            Videojuegos.juego8int += 2;
            dias8 = 0;
        }
        if (dias9 >= 14)
        {
            Videojuegos.juego9int += 2;
            dias9 = 0;
        }
        if (dias10 >= 14)
        {
            Videojuegos.juego10int += 2;
            dias10 = 0;
        }
        if (dias11 >= 14)
        {
            Videojuegos.juego11int += 2;
            dias11 = 0;
        }
        if (dias12 >= 14)
        {
            Videojuegos.juego12int += 2;
            dias12 = 0;
        }
        if (dias13 >= 14)
        {
            Videojuegos.juego13int += 2;
            dias13 = 0;
        }
        if (dias14 >= 14)
        {
            Videojuegos.juego14int += 2;
            dias14 = 0;
        }
        if (dias15 >= 14)
        {
            Videojuegos.juego15int += 2;
            dias15 = 0;
        }
        if (dias16 >= 14)
        {
            Videojuegos.juego16int += 2;
            dias16 = 0;
        }
        if (dias17 >= 14)
        {
            Videojuegos.juego17int += 2;
            dias17 = 0;
        }
        if (dias18 >= 14)
        {
            Videojuegos.juego18int += 2;
            dias18 = 0;
        }
        if (dias19 >= 14)
        {
            Videojuegos.juego19int += 2;
            dias19 = 0;
        }
        if (dias20 >= 14)
        {
            Videojuegos.juego20int += 2;
            dias20 = 0;
        }
        if (dias21 >= 14)
        {
            Videojuegos.juego21int += 2;
            dias21 = 0;
        }
        if (dias22 >= 14)
        {
            Videojuegos.juego22int += 2;
            dias22 = 0;
        }
        if (dias23 >= 14)
        {
            Videojuegos.juego23int += 2;
            dias23 = 0;
        }
        if (dias24 >= 14)
        {
            Videojuegos.juego24int += 2;
            dias24 = 0;
        }
        if (dias25 >= 14)
        {
            Videojuegos.juego25int += 2;
            dias25 = 0;
        }
        if (dias26 >= 14)
        {
            Videojuegos.juego26int += 2;
            dias26 = 0;
        }
        if (dias27 >= 14)
        {
            Videojuegos.juego27int += 2;
            dias27 = 0;
        }
        if (dias28 >= 14)
        {
            Videojuegos.juego28int += 2;
            dias28 = 0;
        }
        if (dias29 >= 14)
        {
            Videojuegos.juego29int += 2;
            dias29 = 0;
        }
        if (dias30 >= 14)
        {
            Videojuegos.juego30int += 2;
            dias30 = 0;
        }
        if (dias31 >= 14)
        {
            Videojuegos.juego31int += 2;
            dias31 = 0;
        }
        if (dias32 >= 14)
        {
            Videojuegos.juego32int += 2;
            dias32 = 0;
        }
        if (dias33 >= 14)
        {
            Videojuegos.juego33int += 2;
            dias33 = 0;
        }
        if (dias34 >= 14)
        {
            Videojuegos.juego34int += 2;
            dias34 = 0;
        }
        if (dias35 >= 14)
        {
            Videojuegos.juego35int += 2;
            dias35 = 0;
        }

        diasguey = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
