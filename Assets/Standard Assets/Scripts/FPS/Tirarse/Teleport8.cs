using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport8 : MonoBehaviour {

    //public GameObject pene;
    //public Vector3 zorra;
    // public GameObject vagina;
    public GameObject Animacionlol;
    public GameObject Animaciontocha;
    public GameObject Sitio;
    public GameObject yo;
    public GameObject yo2;
    public float tiempo;
    public CharacterController control;
    public Transform yojaj;
    [HideInInspector]
    public string tipodeloscojones;
    private GunStatus Arma1;
    private GunStatus Arma2;
    private GunStatus Arma3;
    private GunStatus Arma4;

    void Awake () {
      //  zorra = vagina.transform.position;
    }
	
	// Update is called once per frame
	void OnEnable () {
        //    pene.transform.position = zorra;
        Debug.Log(Animaciones.Animacion);
        Debug.Log(Animaciones.Animacion);
        Debug.Log(Animaciones.Animacion);
        Debug.Log(Animaciones.Animacion);
        control.enabled = false;
        yo2.GetComponent<CharacterMotor>().enabled = false;
        if (tipodeloscojones == "tocho")
        {
            Animacionlol = Instantiate(Animaciontocha, Sitio.transform.position, yojaj.rotation) as GameObject;
        }
        if (tipodeloscojones == "normal")
        {
            Animacionlol = Instantiate(Animacionlol, Sitio.transform.position, yojaj.rotation) as GameObject;
        }
        if (tipodeloscojones == "campero")
        {
            Animacionlol = Instantiate(Animacionlol, Sitio.transform.position, yojaj.rotation) as GameObject;
        }

        Arma1 = gameObject.GetComponentInParent<DisparoSelectivo>().Armas[0].GetComponent<GunStatus>();
        Arma2 = gameObject.GetComponentInParent<DisparoSelectivo>().Armas[1].GetComponent<GunStatus>();
        Arma3 = gameObject.GetComponentInParent<DisparoSelectivo>().Armas[2].GetComponent<GunStatus>();
        Arma4 = gameObject.GetComponentInParent<DisparoSelectivo>().Armas[3].GetComponent<GunStatus>();


        Animacionlol.GetComponentInChildren<Teleport4>().arma1CargadoresActuales = Arma1.CargadoresActuales;
        Animacionlol.GetComponentInChildren<Teleport4>().arma1BalasActualesEnCargador = Arma1.BalasActualesEnCargador;
        Animacionlol.GetComponentInChildren<Teleport4>().arma2CargadoresActuales = Arma2.CargadoresActuales;
        Animacionlol.GetComponentInChildren<Teleport4>().arma2BalasActualesEnCargador = Arma2.BalasActualesEnCargador;
        Animacionlol.GetComponentInChildren<Teleport4>().arma3CargadoresActuales = Arma3.CargadoresActuales;
        Animacionlol.GetComponentInChildren<Teleport4>().arma3BalasActualesEnCargador = Arma3.BalasActualesEnCargador;
        Animacionlol.GetComponentInChildren<Teleport4>().arma4CargadoresActuales = Arma4.CargadoresActuales;
        Animacionlol.GetComponentInChildren<Teleport4>().arma4BalasActualesEnCargador = Arma4.BalasActualesEnCargador;


        angolosahhdonde lol = Animacionlol.GetComponentInChildren<angolosahhdonde>();
        angolosahhdonde lal = yo2.GetComponent<angolosahhdonde>();
        lol.targets = lal.targets;
        lol.derecho = lal.derecho;
        lol.lel = lal.lel;
        lol.dir = lal.dir;
        lol.cont = lal.cont;
        lol.contalfa = lal.contalfa;


        yo.GetComponent<AutoDestruir>().enabled = true;



        Destroy(transform.parent.gameObject, tiempo);
    }



}
