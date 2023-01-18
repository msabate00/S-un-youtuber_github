using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport2 : MonoBehaviour {

    //public GameObject pene;
    //public Vector3 zorra;
   // public GameObject vagina;
    public GameObject Animacion;
    public GameObject Sitio;
    public float tiempo;
    public Transform yojaj;
    public GameObject rendergay;
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
        rendergay.GetComponent<quiatrlayergay>().enabled = true;
        Animacion = Instantiate(Animacion, Sitio.transform.position, yojaj.rotation) as GameObject;
        Arma1 = gameObject.GetComponentInParent<DisparoSelectivo>().Armas[0].GetComponent<GunStatus>();
        Arma2 = gameObject.GetComponentInParent<DisparoSelectivo>().Armas[1].GetComponent<GunStatus>();
        Arma3 = gameObject.GetComponentInParent<DisparoSelectivo>().Armas[2].GetComponent<GunStatus>();
        Arma4 = gameObject.GetComponentInParent<DisparoSelectivo>().Armas[3].GetComponent<GunStatus>();

        Animacion.GetComponentInChildren<DisparoSelectivo>().Armas[0].GetComponent<GunStatus>().CargadoresActuales = Arma1.CargadoresActuales;
        Animacion.GetComponentInChildren<DisparoSelectivo>().Armas[0].GetComponent<GunStatus>().BalasActualesEnCargador = Arma1.BalasActualesEnCargador;
        Animacion.GetComponentInChildren<DisparoSelectivo>().Armas[1].GetComponent<GunStatus>().CargadoresActuales = Arma2.CargadoresActuales;
        Animacion.GetComponentInChildren<DisparoSelectivo>().Armas[1].GetComponent<GunStatus>().BalasActualesEnCargador = Arma2.BalasActualesEnCargador;
        Animacion.GetComponentInChildren<DisparoSelectivo>().Armas[2].GetComponent<GunStatus>().CargadoresActuales = Arma3.CargadoresActuales;
        Animacion.GetComponentInChildren<DisparoSelectivo>().Armas[2].GetComponent<GunStatus>().BalasActualesEnCargador = Arma3.BalasActualesEnCargador;
        Animacion.GetComponentInChildren<DisparoSelectivo>().Armas[3].GetComponent<GunStatus>().CargadoresActuales = Arma4.CargadoresActuales;
        Animacion.GetComponentInChildren<DisparoSelectivo>().Armas[3].GetComponent<GunStatus>().BalasActualesEnCargador = Arma4.BalasActualesEnCargador;
        Animacion.GetComponentInChildren<ReloadWeapon>().ReloadWeaponSpawn();

        angolosahhdonde lol = Animacion.GetComponentInChildren<angolosahhdonde>();
        angolosahhdonde lal = yojaj.GetComponent<angolosahhdonde>();
        lol.targets = lal.targets;
        lol.derecho = lal.derecho;
        lol.lel = lal.lel;
        lol.dir = lal.dir;
        lol.cont = lal.cont;
        lol.contalfa = lal.contalfa;

        Destroy(transform.parent.gameObject, tiempo);
    }



}
