using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport4 : MonoBehaviour {

    //public GameObject pene;
    //public Vector3 zorra;
   // public GameObject vagina;
    public GameObject FPC;
    public GameObject Sitio;
    public float tiempo;
    public Transform yojaj;
    public GameObject camaragay;
    private Vector3 zorrilla;
    public bool cojones = true;
    private GunStatus Arma1;
    private GunStatus Arma2;
    private GunStatus Arma3;
    private GunStatus Arma4;
    public bool pollada = false;

    [HideInInspector]
    public int arma1CargadoresActuales;
    [HideInInspector]
    public int arma1BalasActualesEnCargador;
    [HideInInspector]
    public int arma2CargadoresActuales;
    [HideInInspector]
    public int arma2BalasActualesEnCargador;
    [HideInInspector]
    public int arma3CargadoresActuales;
    [HideInInspector]
    public int arma3BalasActualesEnCargador;
    [HideInInspector]
    public int arma4CargadoresActuales;
    [HideInInspector]
    public int arma4BalasActualesEnCargador;

    void Awake () {
      //  zorra = vagina.transform.position;
    }
	
	// Update is called once per frame
	void OnEnable () {
        //    pene.transform.position = zorra;
        // zorrilla.z += 0.0843f;
        // zorrilla.x -= 0.055f;
        Debug.Log(" ME CAGO EN TODOS TUS PUTOS MUERTOSfdfdf");
        camaragay.GetComponent<AudioListener>().enabled = false;
        if (cojones)
        {
            Debug.Log(" ME CAGO EN TODOS TUS PUTOS MUERTOSfdsa");
            Quaternion rotationgay = Quaternion.Euler(0, yojaj.rotation.y, 0);
            

            if (pollada)
            {
                Debug.Log("JODER");
                FPC = Instantiate(FPC, Sitio.transform.position, yojaj.rotation) as GameObject;
                FPC.transform.position += zorrilla;
                Debug.Log(" ME CAGO EN TODOS TUS PUTOS MUERTOS");
                FPC.GetComponentInChildren<DisparoSelectivo>().Armas[0].GetComponent<GunStatus>().CargadoresActuales = arma1CargadoresActuales;
                FPC.GetComponentInChildren<DisparoSelectivo>().Armas[0].GetComponent<GunStatus>().BalasActualesEnCargador = arma1BalasActualesEnCargador;
                FPC.GetComponentInChildren<DisparoSelectivo>().Armas[1].GetComponent<GunStatus>().CargadoresActuales = arma2CargadoresActuales;
                FPC.GetComponentInChildren<DisparoSelectivo>().Armas[1].GetComponent<GunStatus>().BalasActualesEnCargador = arma2BalasActualesEnCargador;
                FPC.GetComponentInChildren<DisparoSelectivo>().Armas[2].GetComponent<GunStatus>().CargadoresActuales = arma3CargadoresActuales;
                FPC.GetComponentInChildren<DisparoSelectivo>().Armas[2].GetComponent<GunStatus>().BalasActualesEnCargador = arma3BalasActualesEnCargador;
                FPC.GetComponentInChildren<DisparoSelectivo>().Armas[3].GetComponent<GunStatus>().CargadoresActuales = arma4CargadoresActuales;
                FPC.GetComponentInChildren<DisparoSelectivo>().Armas[3].GetComponent<GunStatus>().BalasActualesEnCargador = arma4BalasActualesEnCargador;

                angolosahhdonde lol = FPC.GetComponentInChildren<angolosahhdonde>();
                angolosahhdonde lal = transform.parent.GetComponentInChildren<angolosahhdonde>();
                lol.targets = lal.targets;
                lol.derecho = lal.derecho;
                lol.lel = lal.lel;
                lol.dir = lal.dir;
                lol.cont = lal.cont;
                lol.contalfa = lal.contalfa;
                return;
            }
            if (!pollada)
            {
                
                FPC = Instantiate(FPC, Sitio.transform.position, yojaj.rotation) as GameObject;
                FPC.transform.position += zorrilla;
                Arma1 = gameObject.GetComponentInParent<DisparoSelectivo>().Armas[0].GetComponent<GunStatus>();
                Arma2 = gameObject.GetComponentInParent<DisparoSelectivo>().Armas[1].GetComponent<GunStatus>();
                Arma3 = gameObject.GetComponentInParent<DisparoSelectivo>().Armas[2].GetComponent<GunStatus>();
                Arma4 = gameObject.GetComponentInParent<DisparoSelectivo>().Armas[3].GetComponent<GunStatus>();
                FPC.GetComponentInChildren<DisparoSelectivo>().Armas[0].GetComponent<GunStatus>().CargadoresActuales = Arma1.CargadoresActuales;
                FPC.GetComponentInChildren<DisparoSelectivo>().Armas[0].GetComponent<GunStatus>().BalasActualesEnCargador = Arma1.BalasActualesEnCargador;
                FPC.GetComponentInChildren<DisparoSelectivo>().Armas[1].GetComponent<GunStatus>().CargadoresActuales = Arma2.CargadoresActuales;
                FPC.GetComponentInChildren<DisparoSelectivo>().Armas[1].GetComponent<GunStatus>().BalasActualesEnCargador = Arma2.BalasActualesEnCargador;
                FPC.GetComponentInChildren<DisparoSelectivo>().Armas[2].GetComponent<GunStatus>().CargadoresActuales = Arma3.CargadoresActuales;
                FPC.GetComponentInChildren<DisparoSelectivo>().Armas[2].GetComponent<GunStatus>().BalasActualesEnCargador = Arma3.BalasActualesEnCargador;
                FPC.GetComponentInChildren<DisparoSelectivo>().Armas[3].GetComponent<GunStatus>().CargadoresActuales = Arma4.CargadoresActuales;
                FPC.GetComponentInChildren<DisparoSelectivo>().Armas[3].GetComponent<GunStatus>().BalasActualesEnCargador = Arma4.BalasActualesEnCargador;


                angolosahhdonde lol = FPC.GetComponentInChildren<angolosahhdonde>();
                angolosahhdonde lal = transform.GetComponentInParent<angolosahhdonde>();
                lol.targets = lal.targets;
                lol.derecho = lal.derecho;
                lol.lel = lal.lel;
                lol.dir = lal.dir;
                lol.cont = lal.cont;
                lol.contalfa = lal.contalfa;

            }
            

              
            
        }
        if (!cojones)
        {
            FPC = Instantiate(FPC, Sitio.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;

            Arma1 = gameObject.GetComponentInParent<DisparoSelectivo>().Armas[0].GetComponent<GunStatus>();
            Arma2 = gameObject.GetComponentInParent<DisparoSelectivo>().Armas[1].GetComponent<GunStatus>();
            Arma3 = gameObject.GetComponentInParent<DisparoSelectivo>().Armas[2].GetComponent<GunStatus>();
            Arma4 = gameObject.GetComponentInParent<DisparoSelectivo>().Armas[3].GetComponent<GunStatus>();

            FPC.GetComponentInChildren<DisparoSelectivo>().Armas[0].GetComponent<GunStatus>().CargadoresActuales = Arma1.CargadoresActuales;
            FPC.GetComponentInChildren<DisparoSelectivo>().Armas[0].GetComponent<GunStatus>().BalasActualesEnCargador = Arma1.BalasActualesEnCargador;
            FPC.GetComponentInChildren<DisparoSelectivo>().Armas[1].GetComponent<GunStatus>().CargadoresActuales = Arma2.CargadoresActuales;
            FPC.GetComponentInChildren<DisparoSelectivo>().Armas[1].GetComponent<GunStatus>().BalasActualesEnCargador = Arma2.BalasActualesEnCargador;
            FPC.GetComponentInChildren<DisparoSelectivo>().Armas[2].GetComponent<GunStatus>().CargadoresActuales = Arma3.CargadoresActuales;
            FPC.GetComponentInChildren<DisparoSelectivo>().Armas[2].GetComponent<GunStatus>().BalasActualesEnCargador = Arma3.BalasActualesEnCargador;
            FPC.GetComponentInChildren<DisparoSelectivo>().Armas[3].GetComponent<GunStatus>().CargadoresActuales = Arma4.CargadoresActuales;
            FPC.GetComponentInChildren<DisparoSelectivo>().Armas[3].GetComponent<GunStatus>().BalasActualesEnCargador = Arma4.BalasActualesEnCargador;

            angolosahhdonde lol = FPC.GetComponentInChildren<angolosahhdonde>();
            angolosahhdonde lal = transform.GetComponentInParent<angolosahhdonde>();
            lol.targets = lal.targets;
            lol.derecho = lal.derecho;
            lol.lel = lal.lel;
            lol.dir = lal.dir;
            lol.cont = lal.cont;
            lol.contalfa = lal.contalfa;

        }
            //  Destroy(transform.parent.gameObject, tiempo);
        }



}
