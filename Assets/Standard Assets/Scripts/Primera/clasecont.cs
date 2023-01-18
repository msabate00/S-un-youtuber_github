using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class clasecont
{

    public string titulo;
    public string texto;
    public Texture2D imagen;

    public clasecont(string tit, string text, Texture2D foto)
    {
        titulo = tit;
        texto = text;
        imagen = foto;
    }

}

[System.Serializable]
public class claselista
{

    public int id;
    public int cant;
    public bool si;

    public claselista(int id2, int cant2, bool si2)
    {
        id = id2;
        cant = cant2;
        si = si2;
    }

}

[System.Serializable]
public class listautogay
{

    public int id;
    public int cant;
    public bool si;

    public listautogay(int id2, int cant2, bool si2)
    {
        id = id2;
        cant = cant2;
        si = si2;
    }

}

[System.Serializable]
public class animejec
{

    public string nom;
    public float X;
    public float Y;
    public float tiempesito;
    public bool cuchillo;
    public bool espada;
    public Vector3 offset; 
    public static Vector3 wifi;

    public static float tiempo;

    public animejec(string nom2, float X2, float Y2, float tiempo2, bool cuchillo2, Vector3 offset2, bool espada2)
    {
        nom = nom2;
        X = X2;
        Y = Y2;
        offset = offset2;
        wifi = offset2;
        tiempesito = tiempo2;
        tiempo = tiempesito;
        Teleport10.tiempo = tiempesito;
        cuchillo = cuchillo2;
        espada = espada2;
    }


}

[System.Serializable]
public class Miras
{

    public float Distancia;
    public float Distanciaim;
    public Vector3 Pos;
    public Vector3 Posaim;
    public bool Punto;

    public Miras(float Distancia2, float Distancia2aim, Vector3 Pos2, Vector3 Posaim2, bool Punto2)
    {
        Distancia = Distancia2;
        Distanciaim = Distancia2aim;
        Pos = Pos2;
        Posaim = Posaim2;
        Punto = Punto2;
    }

}

[System.Serializable]
public class Puntosgays
{

    public float Pts;
    public int Id;
    public bool mod = true;

    public Puntosgays(float Pts2, int Id2, bool mod2)
    {
        Pts = Pts2;
        Id = Id2;
        mod = mod2;
    }

}

[System.Serializable]
public class armastats
{

    public string Nombre;
    public int Damage;
    public int Stun;
    public int CargadoresAct;
    public int BalasAct;
    public int BalasActArma2;
    public float Critico;
    public float Desbloqueo;

    public armastats(int Damage2, int Stun2, int CargadoresAct2, int BalasAct2, int BalasActArma2lol, string Nombre2, float Critico2, float Desbloqueo2)
    {
        Damage = Damage2;
        Stun = Stun2;
        CargadoresAct = CargadoresAct2;
        BalasAct = BalasAct2;
        Nombre = Nombre2;
        BalasActArma2 = BalasActArma2lol;
        Critico = Critico2;
        Desbloqueo = Desbloqueo2;
    }

}

[System.Serializable]
public class AnimacionesMelee
{

    public string Nombre;
    public float DelayDamage;
    public float Length;
    public float Speed;

    public AnimacionesMelee(string Nombre2, float DelayDamage2, float Length2, float Speed2)
    {
        Nombre = Nombre2;
        DelayDamage = DelayDamage2;
        Length = Length2;
        Speed = Speed2;
    }

}

[System.Serializable]
public class AnimacionesSangre
{

    public string Nombre;
    public float t1;
    public float t2;
    public float StartSpeed;
    public float StartSize;
    public Vector3 pos;
    public Vector3 rot;
    public bool boomejec;
    public int burst;
    public float angle;
    public Vector3 posburst;

    public AnimacionesSangre(string Nombre2, float t12, float t22, float StartSpeed2, float StartSize2, Vector3 pos2, Vector3 rot2, bool boomejec2, int burst2, float angle2, Vector3 posburst2)
    {
        t1 = t12;
        t2 = t22;
        Nombre = Nombre2;
        StartSpeed = StartSpeed2;
        StartSize = StartSize2;
        pos = pos2;
        rot = rot2;
        boomejec = boomejec2;
        burst = burst2;
        angle = angle2;
        posburst = posburst2;
    }

}

[System.Serializable]
public class GestorgayStats
{

    public string Texto;
    public float Putos;

    public GestorgayStats(string Texto2, float Putos2)
    {

        Texto = Texto2;
        Putos = Putos2;



    }

}

[System.Serializable]
public class DesbloqueosGays
{

    public string Texto;
    public float Putos;

    public DesbloqueosGays(string Texto2, float Putos2)
    {

        Texto = Texto2;
        Putos = Putos2;


    }

}

[System.Serializable]
public class Spawners
{
    public float tiempoesperaronda;
    public int enemigosbajas;
    public float randesp;
    public float tiempoespera;
    public int maxen;
    public int maxesp;
    public int[] spawnersid;
    public List<bumtio> bumlol = new List<bumtio>();
    public bool explosion;

    public Spawners(int enemigosbajas2, float randesp2, float tiempoespera2, Vector3[] bum2, int maxen2, int maxesp2)
    {

        enemigosbajas = enemigosbajas2;
        randesp = randesp2;
        tiempoespera = tiempoespera2;
        maxen = maxen2;
        maxesp = maxesp2;

    }

}

[System.Serializable]
public class bumtio
{

    public Vector4 bum;
    public AudioClip opcional;

}

[System.Serializable]
public class pausagay
{

    public RectTransform[] rectos;
    public Vector3[] cors;
   
    public pausagay()
    {

    }

}

[System.Serializable]
public class listacans
{

    public AudioClip[] cancion;

    public listacans()
    {

    }

}

[System.Serializable]
public class recargas
{
    public int Id;
    public recargas2[] Audio;
    public float[] timer;
    public float volumen;

    public recargas()
    {

    }

}

[System.Serializable]
public class recargas2
{
    public AudioClip[] Audiogays;

    public recargas2()
    {

    }

}

[System.Serializable]
public class drops
{
    public int Id = -1;
    public Transform spawn;
}

[System.Serializable]
public class ListaDrops
{
    public List<drops> Disponibles = new List<drops>();
    public List<drops> Ocupados = new List<drops>();
    public List<ElDrop> DropsDisponibles = new List<ElDrop>();
    public List<ElDrop> DropsAcabados = new List<ElDrop>();
}

[System.Serializable]
public class ElDrop
{
    public int Id;
    public int Disponibles;
    public GameObject Drop;
}