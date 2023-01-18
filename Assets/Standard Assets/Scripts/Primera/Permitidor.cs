using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Permitidor : MonoBehaviour {

    public GameObject j11;
    public GameObject j12; //j= juego; 1= juego 1; 2= gameobject 2 seleccionado
    public GameObject j13;
    public GameObject j21;
    public GameObject j22; 
    public GameObject j23;
    public GameObject j31;
    public GameObject j32; 
    public GameObject j33;
    public GameObject j41;
    public GameObject j42;
    public GameObject j43;
    public GameObject j51;
    public GameObject j52;
    public GameObject j53;
    public GameObject j61;
    public GameObject j62;
    public GameObject j63;
    public GameObject j71;
    public GameObject j72;
    public GameObject j73;
    public GameObject j81;
    public GameObject j82;
    public GameObject j83;
    public GameObject j91;
    public GameObject j92;
    public GameObject j93;
    public GameObject j101;
    public GameObject j102;
    public GameObject j103;
    public GameObject j111;
    public GameObject j112;
    public GameObject j113;
    public GameObject j121;
    public GameObject j122;
    public GameObject j123;
    public GameObject j131;
    public GameObject j132;
    public GameObject j133;
    public GameObject j141;
    public GameObject j142;
    public GameObject j143;
    public GameObject j151;
    public GameObject j152;
    public GameObject j153;
    public GameObject j161;
    public GameObject j162;
    public GameObject j163;
    public GameObject j171;
    public GameObject j172;
    public GameObject j173;
    public GameObject j181;
    public GameObject j182;
    public GameObject j183;
    public GameObject j191;
    public GameObject j192;
    public GameObject j193;
    public GameObject j201;
    public GameObject j202;
    public GameObject j203;
    public GameObject j211;
    public GameObject j212;
    public GameObject j213;
    public GameObject j221;
    public GameObject j222;
    public GameObject j223;
    public GameObject j231;
    public GameObject j232;
    public GameObject j233;
    public GameObject j241;
    public GameObject j242;
    public GameObject j243;
    public GameObject j251;
    public GameObject j252;
    public GameObject j253;
    public GameObject j261;
    public GameObject j262;
    public GameObject j263;
    public GameObject j271;
    public GameObject j272;
    public GameObject j273;
    public GameObject j281;
    public GameObject j282;
    public GameObject j283;
    public GameObject j291;
    public GameObject j292;
    public GameObject j293;
    public GameObject j301;
    public GameObject j302;
    public GameObject j303;
    public GameObject j311;
    public GameObject j312;
    public GameObject j313;
    public GameObject j321;
    public GameObject j322;
    public GameObject j323;
    public GameObject j331;
    public GameObject j332;
    public GameObject j333;
    public GameObject j341;
    public GameObject j342;
    public GameObject j343;
    public GameObject j351;
    public GameObject j352;
    public GameObject j353;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Videojuegos.juego1com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j11.SetActive(false);
            j12.SetActive(true);
        }
        if (Videojuegos.juego1com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j11.SetActive(true);
            j12.SetActive(false);
        }
        if (Videojuegos.juego1req > Controlador.Ordenador) //no lo es
        {
            
            j11.SetActive(false);
            j13.SetActive(true);
        }
        if (Videojuegos.juego1req <= Controlador.Ordenador)  //es accedible
        {
         
            j13.SetActive(false);
        }




        if (Videojuegos.juego2com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j21.SetActive(false);
            j22.SetActive(true);
        }
        if (Videojuegos.juego2com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j21.SetActive(true);
            j22.SetActive(false);
        }
        if (Videojuegos.juego2req > Controlador.Ordenador) //no lo es
        {
            j21.SetActive(false);
            j23.SetActive(true);
        }
        if (Videojuegos.juego2req <= Controlador.Ordenador)  //es accedible
        {

            j23.SetActive(false);
        }




        if (Videojuegos.juego3com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j31.SetActive(false);
            j32.SetActive(true);
        }
        if (Videojuegos.juego3com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j31.SetActive(true);
            j32.SetActive(false);
        }
        if (Videojuegos.juego3req > Controlador.Ordenador) //no lo es
        {
            j31.SetActive(false);
            j33.SetActive(true);
        }
        if (Videojuegos.juego3req <= Controlador.Ordenador)  //es accedible
        {

            j33.SetActive(false);
        }


        if (Videojuegos.juego4com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j41.SetActive(false);
            j42.SetActive(true);
        }
        if (Videojuegos.juego4com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j41.SetActive(true);
            j42.SetActive(false);
        }
        if (Videojuegos.juego4req > Controlador.Ordenador) //no lo es
        {
            j41.SetActive(false);
            j43.SetActive(true);
        }
        if (Videojuegos.juego4req <= Controlador.Ordenador)  //es accedible
        {

            j43.SetActive(false);
        }


        if (Videojuegos.juego5com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j51.SetActive(false);
            j52.SetActive(true);
        }
        if (Videojuegos.juego5com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j51.SetActive(true);
            j52.SetActive(false);
        }
        if (Videojuegos.juego5req > Controlador.Ordenador) //no lo es
        {
            j51.SetActive(false);
            j53.SetActive(true);
        }
        if (Videojuegos.juego5req <= Controlador.Ordenador)  //es accedible
        {

            j53.SetActive(false);
        }


        if (Videojuegos.juego6com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j61.SetActive(false);
            j62.SetActive(true);
        }
        if (Videojuegos.juego6com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j61.SetActive(true);
            j62.SetActive(false);
        }
        if (Videojuegos.juego6req > Controlador.Ordenador) //no lo es
        {
            j61.SetActive(false);
            j63.SetActive(true);
        }
        if (Videojuegos.juego6req <= Controlador.Ordenador)  //es accedible
        {

            j63.SetActive(false);
        }



        if (Videojuegos.juego7com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j71.SetActive(false);
            j72.SetActive(true);
        }
        if (Videojuegos.juego7com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j71.SetActive(true);
            j72.SetActive(false);
        }
        if (Videojuegos.juego7req > Controlador.Ordenador) //no lo es
        {
            j71.SetActive(false);
            j73.SetActive(true);
        }
        if (Videojuegos.juego7req <= Controlador.Ordenador)  //es accedible
        {

            j73.SetActive(false);
        }


        if (Videojuegos.juego8com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j81.SetActive(false);
            j82.SetActive(true);
        }
        if (Videojuegos.juego8com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j81.SetActive(true);
            j82.SetActive(false);
        }
        if (Videojuegos.juego8req > Controlador.Ordenador) //no lo es
        {
            j81.SetActive(false);
            j83.SetActive(true);
        }
        if (Videojuegos.juego8req <= Controlador.Ordenador)  //es accedible
        {

            j83.SetActive(false);
        }

        if (Videojuegos.juego9com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j91.SetActive(false);
            j92.SetActive(true);
        }
        if (Videojuegos.juego9com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j91.SetActive(true);
            j92.SetActive(false);
        }
        if (Videojuegos.juego9req > Controlador.Ordenador) //no lo es
        {
            j91.SetActive(false);
            j93.SetActive(true);
        }
        if (Videojuegos.juego9req <= Controlador.Ordenador)  //es accedible
        {

            j93.SetActive(false);
        }

        if (Videojuegos.juego10com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j101.SetActive(false);
            j102.SetActive(true);
        }
        if (Videojuegos.juego10com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j101.SetActive(true);
            j102.SetActive(false);
        }
        if (Videojuegos.juego10req > Controlador.Ordenador) //no lo es
        {
            j101.SetActive(false);
            j103.SetActive(true);
        }
        if (Videojuegos.juego10req <= Controlador.Ordenador)  //es accedible
        {

            j103.SetActive(false);
        }


        if (Videojuegos.juego11com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j111.SetActive(false);
            j112.SetActive(true);
        }
        if (Videojuegos.juego11com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j111.SetActive(true);
            j112.SetActive(false);
        }
        if (Videojuegos.juego11req > Controlador.Ordenador) //no lo es
        {
            j111.SetActive(false);
            j113.SetActive(true);
        }
        if (Videojuegos.juego11req <= Controlador.Ordenador)  //es accedible
        {

            j113.SetActive(false);
        }


        if (Videojuegos.juego12com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j121.SetActive(false);
            j122.SetActive(true);
        }
        if (Videojuegos.juego12com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j121.SetActive(true);
            j122.SetActive(false);
        }
        if (Videojuegos.juego12req > Controlador.Ordenador) //no lo es
        {
            j121.SetActive(false);
            j123.SetActive(true);
        }
        if (Videojuegos.juego12req <= Controlador.Ordenador)  //es accedible
        {

            j123.SetActive(false);
        }


        if (Videojuegos.juego13com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j131.SetActive(false);
            j132.SetActive(true);
        }
        if (Videojuegos.juego13com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j131.SetActive(true);
            j132.SetActive(false);
        }
        if (Videojuegos.juego13req > Controlador.Ordenador) //no lo es
        {
            j131.SetActive(false);
            j133.SetActive(true);
        }
        if (Videojuegos.juego13req <= Controlador.Ordenador)  //es accedible
        {

            j133.SetActive(false);
        }


        if (Videojuegos.juego14com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j141.SetActive(false);
            j142.SetActive(true);
        }
        if (Videojuegos.juego14com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j141.SetActive(true);
            j142.SetActive(false);
        }
        if (Videojuegos.juego14req > Controlador.Ordenador) //no lo es
        {
            j141.SetActive(false);
            j143.SetActive(true);
        }
        if (Videojuegos.juego14req <= Controlador.Ordenador)  //es accedible
        {

            j143.SetActive(false);
        }

        if (Videojuegos.juego15com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j151.SetActive(false);
            j152.SetActive(true);
        }
        if (Videojuegos.juego15com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j151.SetActive(true);
            j152.SetActive(false);
        }
        if (Videojuegos.juego15req > Controlador.Ordenador) //no lo es
        {
            j151.SetActive(false);
            j153.SetActive(true);
        }
        if (Videojuegos.juego15req <= Controlador.Ordenador)  //es accedible
        {

            j153.SetActive(false);
        }


        if (Videojuegos.juego16com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j161.SetActive(false);
            j162.SetActive(true);
        }
        if (Videojuegos.juego16com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j161.SetActive(true);
            j162.SetActive(false);
        }
        if (Videojuegos.juego16req > Controlador.Ordenador) //no lo es
        {
            j161.SetActive(false);
            j163.SetActive(true);
        }
        if (Videojuegos.juego16req <= Controlador.Ordenador)  //es accedible
        {

            j163.SetActive(false);
        }

        if (Videojuegos.juego17com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j171.SetActive(false);
            j172.SetActive(true);
        }
        if (Videojuegos.juego17com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j171.SetActive(true);
            j172.SetActive(false);
        }
        if (Videojuegos.juego17req > Controlador.Ordenador) //no lo es
        {
            j171.SetActive(false);
            j173.SetActive(true);
        }
        if (Videojuegos.juego17req <= Controlador.Ordenador)  //es accedible
        {

            j173.SetActive(false);
        }

        if (Videojuegos.juego18com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j181.SetActive(false);
            j182.SetActive(true);
        }
        if (Videojuegos.juego18com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j181.SetActive(true);
            j182.SetActive(false);
        }
        if (Videojuegos.juego18req > Controlador.Ordenador) //no lo es
        {
            j181.SetActive(false);
            j183.SetActive(true);
        }
        if (Videojuegos.juego18req <= Controlador.Ordenador)  //es accedible
        {

            j183.SetActive(false);
        }

        if (Videojuegos.juego19com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j191.SetActive(false);
            j192.SetActive(true);
        }
        if (Videojuegos.juego19com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j191.SetActive(true);
            j192.SetActive(false);
        }
        if (Videojuegos.juego19req > Controlador.Ordenador) //no lo es
        {
            j191.SetActive(false);
            j193.SetActive(true);
        }
        if (Videojuegos.juego19req <= Controlador.Ordenador)  //es accedible
        {

            j193.SetActive(false);
        }

        if (Videojuegos.juego20com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j201.SetActive(false);
            j202.SetActive(true);
        }
        if (Videojuegos.juego20com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j201.SetActive(true);
            j202.SetActive(false);
        }
        if (Videojuegos.juego20req > Controlador.Ordenador) //no lo es
        {
            j201.SetActive(false);
            j203.SetActive(true);
        }
        if (Videojuegos.juego20req <= Controlador.Ordenador)  //es accedible
        {

            j203.SetActive(false);
        }

        if (Videojuegos.juego21com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j211.SetActive(false);
            j212.SetActive(true);
        }
        if (Videojuegos.juego21com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j211.SetActive(true);
            j212.SetActive(false);
        }
        if (Videojuegos.juego21req > Controlador.Ordenador) //no lo es
        {
            j211.SetActive(false);
            j213.SetActive(true);
        }
        if (Videojuegos.juego21req <= Controlador.Ordenador)  //es accedible
        {

            j213.SetActive(false);
        }

        if (Videojuegos.juego22com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j221.SetActive(false);
            j222.SetActive(true);
        }
        if (Videojuegos.juego22com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j221.SetActive(true);
            j222.SetActive(false);
        }
        if (Videojuegos.juego22req > Controlador.Ordenador) //no lo es
        {
            j221.SetActive(false);
            j223.SetActive(true);
        }
        if (Videojuegos.juego22req <= Controlador.Ordenador)  //es accedible
        {

            j223.SetActive(false);
        }

        if (Videojuegos.juego23com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j231.SetActive(false);
            j232.SetActive(true);
        }
        if (Videojuegos.juego23com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j231.SetActive(true);
            j232.SetActive(false);
        }
        if (Videojuegos.juego23req > Controlador.Ordenador) //no lo es
        {
            j231.SetActive(false);
            j233.SetActive(true);
        }
        if (Videojuegos.juego23req <= Controlador.Ordenador)  //es accedible
        {

            j233.SetActive(false);
        }

        if (Videojuegos.juego24com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j241.SetActive(false);
            j242.SetActive(true);
        }
        if (Videojuegos.juego24com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j241.SetActive(true);
            j242.SetActive(false);
        }
        if (Videojuegos.juego24req > Controlador.Ordenador) //no lo es
        {
            j241.SetActive(false);
            j243.SetActive(true);
        }
        if (Videojuegos.juego24req <= Controlador.Ordenador)  //es accedible
        {

            j243.SetActive(false);
        }

        if (Videojuegos.juego25com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j251.SetActive(false);
            j252.SetActive(true);
        }
        if (Videojuegos.juego25com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j251.SetActive(true);
            j252.SetActive(false);
        }
        if (Videojuegos.juego25req > Controlador.Ordenador) //no lo es
        {
            j251.SetActive(false);
            j253.SetActive(true);
        }
        if (Videojuegos.juego25req <= Controlador.Ordenador)  //es accedible
        {

            j253.SetActive(false);
        }


        if (Videojuegos.juego26com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j261.SetActive(false);
            j262.SetActive(true);
        }
        if (Videojuegos.juego26com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j261.SetActive(true);
            j262.SetActive(false);
        }
        if (Videojuegos.juego26req > Controlador.Ordenador) //no lo es
        {
            j261.SetActive(false);
            j263.SetActive(true);
        }
        if (Videojuegos.juego26req <= Controlador.Ordenador)  //es accedible
        {

            j263.SetActive(false);
        }


        if (Videojuegos.juego27com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j271.SetActive(false);
            j272.SetActive(true);
        }
        if (Videojuegos.juego27com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j271.SetActive(true);
            j272.SetActive(false);
        }
        if (Videojuegos.juego27req > Controlador.Ordenador) //no lo es
        {
            j271.SetActive(false);
            j273.SetActive(true);
        }
        if (Videojuegos.juego27req <= Controlador.Ordenador)  //es accedible
        {

            j273.SetActive(false);
        }


        if (Videojuegos.juego28com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j281.SetActive(false);
            j282.SetActive(true);
        }
        if (Videojuegos.juego28com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j281.SetActive(true);
            j282.SetActive(false);
        }
        if (Videojuegos.juego28req > Controlador.Ordenador) //no lo es
        {
            j281.SetActive(false);
            j283.SetActive(true);
        }
        if (Videojuegos.juego28req <= Controlador.Ordenador)  //es accedible
        {

            j283.SetActive(false);
        }


        if (Videojuegos.juego29com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j291.SetActive(false);
            j292.SetActive(true);
        }
        if (Videojuegos.juego29com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j291.SetActive(true);
            j292.SetActive(false);
        }
        if (Videojuegos.juego29req > Controlador.Ordenador) //no lo es
        {
            j291.SetActive(false);
            j293.SetActive(true);
        }
        if (Videojuegos.juego29req <= Controlador.Ordenador)  //es accedible
        {

            j293.SetActive(false);
        }


        if (Videojuegos.juego30com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j301.SetActive(false);
            j302.SetActive(true);
        }
        if (Videojuegos.juego30com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j301.SetActive(true);
            j302.SetActive(false);
        }
        if (Videojuegos.juego30req > Controlador.Ordenador) //no lo es
        {
            j301.SetActive(false);
            j303.SetActive(true);
        }
        if (Videojuegos.juego30req <= Controlador.Ordenador)  //es accedible
        {

            j303.SetActive(false);
        }

        if (Videojuegos.juego31com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j311.SetActive(false);
            j312.SetActive(true);
        }
        if (Videojuegos.juego31com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j311.SetActive(true);
            j312.SetActive(false);
        }
        if (Videojuegos.juego31req > Controlador.Ordenador) //no lo es
        {
            j311.SetActive(false);
            j313.SetActive(true);
        }
        if (Videojuegos.juego31req <= Controlador.Ordenador)  //es accedible
        {

            j313.SetActive(false);
        }


        if (Videojuegos.juego32com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j321.SetActive(false);
            j322.SetActive(true);
        }
        if (Videojuegos.juego32com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j321.SetActive(true);
            j322.SetActive(false);
        }
        if (Videojuegos.juego32req > Controlador.Ordenador) //no lo es
        {
            j321.SetActive(false);
            j323.SetActive(true);
        }
        if (Videojuegos.juego32req <= Controlador.Ordenador)  //es accedible
        {

            j323.SetActive(false);
        }


        if (Videojuegos.juego33com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j331.SetActive(false);
            j332.SetActive(true);
        }
        if (Videojuegos.juego33com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j331.SetActive(true);
            j332.SetActive(false);
        }
        if (Videojuegos.juego33req > Controlador.Ordenador) //no lo es
        {
            j331.SetActive(false);
            j333.SetActive(true);
        }
        if (Videojuegos.juego33req <= Controlador.Ordenador)  //es accedible
        {

            j333.SetActive(false);
        }

        if (Videojuegos.juego34com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j341.SetActive(false);
            j342.SetActive(true);
        }
        if (Videojuegos.juego34com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j341.SetActive(true);
            j342.SetActive(false);
        }
        if (Videojuegos.juego34req > Controlador.Ordenador) //no lo es
        {
            j341.SetActive(false);
            j343.SetActive(true);
        }
        if (Videojuegos.juego34req <= Controlador.Ordenador)  //es accedible
        {

            j343.SetActive(false);
        }

        if (Videojuegos.juego35com == 0)  //1 caratula 2 no comprao 3 no requisitos
        {
            j351.SetActive(false);
            j352.SetActive(true);
        }
        if (Videojuegos.juego35com == 1)  //1 caratula 2 no comprao 3 no requisitos
        {
            j351.SetActive(true);
            j352.SetActive(false);
        }
        if (Videojuegos.juego35req > Controlador.Ordenador) //no lo es
        {
            j351.SetActive(false);
            j353.SetActive(true);
        }
        if (Videojuegos.juego35req <= Controlador.Ordenador)  //es accedible
        {

            j353.SetActive(false);
        }

    }
}
