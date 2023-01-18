using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalizador : MonoBehaviour {

    public int damageputoarma1;
    public int damageputoarma2;
    public int damageputoarma3;
    public int damageputoarma4;
    public int stunputoarma1;
    public int stunputoarma2;
    public int stunputoarma3;
    public int stunputoarma4;
    public float criticoputoarma1;
    public float criticoputoarma2;
    public float criticoputoarma3;
    public float tiempogay = 1;
    private float fixedDeltaTime;

    public float cooldown1;
    public float cooldown2;
    public float cooldown3;
    public float cooldown4;
    public float cooldown5;

    public float[] enemigodaño;

    public int[] armaskit;
    [HideInInspector]
    public int[] armaskitorig;
    public int armaslot;
    public List<armastats> listagay = new List<armastats>();
    public List<armastats> listagay2 = new List<armastats>();
    public float[] nivelesextra;

    void Update () {
        //  Time.timeScale = tiempogay;
        // Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
    }
	
	// Update is called once per frame
	void Awake () {

        //if (Controlador.ah != null) { return; }
        armaskitorig = new int[armaskit.Length];
        for (int i = 0; i < armaskit.Length; i++)
        {
            armaskitorig[i] = armaskit[i];
        }

        Controlador.damage1 = damageputoarma1;
        Controlador.damage2 = damageputoarma2;
        Controlador.damage3 = damageputoarma3;
        Controlador.damage4 = damageputoarma4;
        Controlador.stun1 = stunputoarma1;
        Controlador.stun2 = stunputoarma2;
        Controlador.stun3 = stunputoarma3;
        Controlador.stun4 = stunputoarma4;
        Controlador.critico1 = criticoputoarma1;
        Controlador.critico2 = criticoputoarma2;
        Controlador.critico3 = criticoputoarma3;
        Controlador.cd1 = cooldown1;
        Controlador.cd2 = cooldown2;
        Controlador.cd3 = cooldown3;
        Controlador.cd4 = cooldown4;
        Controlador.cd5 = cooldown5;
        
        this.fixedDeltaTime = Time.fixedDeltaTime;
        igualador();
    }

    void igualador()
    {
        for (int i = 0; i < listagay.Count; i++)
        {
            listagay2[i].Nombre = listagay[i].Nombre;
            listagay2[i].Damage = listagay[i].Damage;
            listagay2[i].Stun = listagay[i].Stun;
            listagay2[i].CargadoresAct = listagay[i].CargadoresAct;
            listagay2[i].BalasAct = listagay[i].BalasAct;
            listagay2[i].BalasActArma2 = listagay[i].BalasActArma2;
            listagay2[i].Desbloqueo = listagay[i].Desbloqueo;
        }
    }


    void Start()
    {
        StopAllCoroutines();
        StartCoroutine("armasahora");

        Controlador.dañoenemigogay = new float[enemigodaño.Length];
        for (int i = 0; i < enemigodaño.Length; i++)
        {
            Controlador.dañoenemigogay[i] = enemigodaño[i];
        }
    }

    public void ResetWapo()
    {
        for (int i = 0; i < armaskit.Length; i++)
        {
            armaskit[i] = armaskitorig[i];
        }
        armaslot = 0;
        igualador();
        StopAllCoroutines();
        StartCoroutine("armasahora");     
    }

    public void actarmas()
    {
        //DisparoSelectivo dis = GameObject.FindGameObjectWithTag("ELPLAYERJODER").GetComponentInChildren<DisparoSelectivo>();
        //DisparoSelectivo dis = GameObject.FindGameObjectWithTag("ELPLAYERJODER").GetComponentInChildren<DisparoSelectivo>();
        GameObject[] a = GameObject.FindGameObjectWithTag("ELPLAYERJODER").GetComponentInChildren<DisparoSelectivo>().Armas;


            for (int i = 0; i < a.Length; i++)
            {

                a[i].GetComponent<GunStatus>().Damage = listagay2[i].Damage;
                a[i].GetComponent<GunStatus>().Stun = listagay2[i].Stun;
                a[i].GetComponent<GunStatus>().CargadoresActuales = listagay2[i].CargadoresAct;
                a[i].GetComponent<GunStatus>().BalasActualesEnCargador = listagay2[i].BalasAct;
                a[i].GetComponent<GunStatus>().Critico = listagay[i].Critico;

                if (a[i].GetComponent<GunStatus>().arma2 != null)
                {
                    a[i].GetComponent<GunStatus>().arma2.BalasActualesEnCargador = listagay2[i].BalasActArma2;
                    a[i].GetComponent<GunStatus>().arma2.Critico = listagay[i].Critico;
            }

            }
        
      
       
        /*
        for (int i = 0; i < a.Length; i++)
        {
            // armastats lol = listagay[i];

            listagay[i].Damage = a[i].GetComponent<GunStatus>().Damage;
            listagay[i].Stun = a[i].GetComponent<GunStatus>().Stun;
            listagay[i].CargadoresAct = a[i].GetComponent<GunStatus>().CargadoresActuales;
            listagay[i].BalasAct = a[i].GetComponent<GunStatus>().BalasActualesEnCargador;
        }
        */
    }

    void AutoRecarga()
    {
        if (DisparoSelectivo.NumeroArmagay == 2)
        {
            while (listagay2[DisparoSelectivo.NumeroArmagay].BalasAct < 2)
            {
                if (listagay2[DisparoSelectivo.NumeroArmagay].CargadoresAct == 0) { break; }
                listagay2[DisparoSelectivo.NumeroArmagay].CargadoresAct--;
                listagay2[DisparoSelectivo.NumeroArmagay].BalasAct++;
            }
        }
        else if (DisparoSelectivo.NumeroArmagay == 3)
        {
            while (listagay2[DisparoSelectivo.NumeroArmagay].BalasAct < 2)
            {
                if (listagay2[DisparoSelectivo.NumeroArmagay].CargadoresAct == 0) { break; }
                listagay2[DisparoSelectivo.NumeroArmagay].CargadoresAct--;
                listagay2[DisparoSelectivo.NumeroArmagay].BalasAct++;
            }
        }
        else if (DisparoSelectivo.NumeroArmagay == 8)
        {
            while (listagay2[DisparoSelectivo.NumeroArmagay].BalasAct < 1)
            {
                if (listagay2[DisparoSelectivo.NumeroArmagay].CargadoresAct == 0) { break; }
                listagay2[DisparoSelectivo.NumeroArmagay].CargadoresAct--;
                listagay2[DisparoSelectivo.NumeroArmagay].BalasAct++;
            }
        }
        else if (DisparoSelectivo.NumeroArmagay == 7)
        {
            if (listagay2[DisparoSelectivo.NumeroArmagay].BalasAct < 7 || listagay2[DisparoSelectivo.NumeroArmagay].BalasActArma2 < 7)
            {
                bool gay = false;
                while (true)
                {
                    if (listagay2[DisparoSelectivo.NumeroArmagay].BalasAct >= 7 && listagay2[DisparoSelectivo.NumeroArmagay].BalasActArma2 >= 7) { break; }
                    if (listagay2[DisparoSelectivo.NumeroArmagay].CargadoresAct == 0) { break; }
                    listagay2[DisparoSelectivo.NumeroArmagay].CargadoresAct--;
                    gay = !gay;

                    if (gay)
                    {
                        if (listagay2[DisparoSelectivo.NumeroArmagay].BalasAct < 7)
                        {
                            listagay2[DisparoSelectivo.NumeroArmagay].BalasAct++;
                            continue;
                        }
                        else if (listagay2[DisparoSelectivo.NumeroArmagay].BalasActArma2 < 7)
                        {
                            listagay2[DisparoSelectivo.NumeroArmagay].BalasActArma2++;
                            continue;
                        }
                        
                    }
                    else
                    {
                        if (listagay2[DisparoSelectivo.NumeroArmagay].BalasActArma2 < 7)
                        {
                            listagay2[DisparoSelectivo.NumeroArmagay].BalasActArma2++;
                            continue;
                        }
                        else if (listagay2[DisparoSelectivo.NumeroArmagay].BalasAct < 7)
                        {
                            listagay2[DisparoSelectivo.NumeroArmagay].BalasAct++;
                            continue;
                        }
                    }
                    
                }
            }
        }
        else if (DisparoSelectivo.NumeroArmagay == 4)
        {

            if (listagay2[DisparoSelectivo.NumeroArmagay].BalasAct < 20 || listagay2[DisparoSelectivo.NumeroArmagay].BalasActArma2 < 20)
            {
                bool gay = false;
                while (true)
                {
                    if (listagay2[DisparoSelectivo.NumeroArmagay].BalasAct == 20 && listagay2[DisparoSelectivo.NumeroArmagay].BalasActArma2 == 20) { break; }
                    if (listagay2[DisparoSelectivo.NumeroArmagay].CargadoresAct == 0) { break; }
                    listagay2[DisparoSelectivo.NumeroArmagay].CargadoresAct--;
                    gay = !gay;

                    if (gay)
                    {
                        listagay2[DisparoSelectivo.NumeroArmagay].BalasAct++;
                        continue;
                    }
                    listagay2[DisparoSelectivo.NumeroArmagay].BalasActArma2++;
                }
            }
                
        }


    }

    public void actarmasrecarga()
    {
        DisparoSelectivo gay = null;

            gay = GameObject.FindGameObjectWithTag("ELPLAYERJODER").GetComponentInChildren<DisparoSelectivo>();


        if (gay != null)
        {

            /*
             string Nom = listagay2[DisparoSelectivo.NumeroArmagay].Nombre;
             int Dam = listagay2[DisparoSelectivo.NumeroArmagay].Damage;
             int Stun = listagay2[DisparoSelectivo.NumeroArmagay].Stun;

             listagay2.RemoveAt(DisparoSelectivo.NumeroArmagay);
             listagay2.Insert(DisparoSelectivo.NumeroArmagay, new armastats(Dam, Stun, gay.Armas[DisparoSelectivo.NumeroArmagay].GetComponent<GunStatus>().CargadoresActuales, gay.Armas[DisparoSelectivo.NumeroArmagay].GetComponent<GunStatus>().BalasActualesEnCargador, Nom));
        */
            listagay2[DisparoSelectivo.NumeroArmagay].BalasAct = gay.GunStatusScript.BalasActualesEnCargador;
            listagay2[DisparoSelectivo.NumeroArmagay].CargadoresAct = gay.GunStatusScript.CargadoresActuales;

            if (gay.GunStatusScript.arma2 != null)
            {
                listagay2[DisparoSelectivo.NumeroArmagay].BalasActArma2 = gay.GunStatusScript.arma2.BalasActualesEnCargador;
            }
        }
    }

    IEnumerator armasahora()
    {

        DisparoSelectivo gay = null;
        
        while (true)
        {
            yield return new WaitUntil(() => FPCStatus.isShooting || FPCStatus.isShooting2);

            if (gay == null)
            {
                gay = GameObject.FindGameObjectWithTag("ELPLAYERJODER").GetComponentInChildren<DisparoSelectivo>();
            }
            if (gay != null)
            {

                /*
                 string Nom = listagay2[DisparoSelectivo.NumeroArmagay].Nombre;
                 int Dam = listagay2[DisparoSelectivo.NumeroArmagay].Damage;
                 int Stun = listagay2[DisparoSelectivo.NumeroArmagay].Stun;

                 listagay2.RemoveAt(DisparoSelectivo.NumeroArmagay);
                 listagay2.Insert(DisparoSelectivo.NumeroArmagay, new armastats(Dam, Stun, gay.Armas[DisparoSelectivo.NumeroArmagay].GetComponent<GunStatus>().CargadoresActuales, gay.Armas[DisparoSelectivo.NumeroArmagay].GetComponent<GunStatus>().BalasActualesEnCargador, Nom));
            */
                listagay2[DisparoSelectivo.NumeroArmagay].BalasAct = gay.GunStatusScript.BalasActualesEnCargador;
                listagay2[DisparoSelectivo.NumeroArmagay].CargadoresAct = gay.GunStatusScript.CargadoresActuales;

                if (gay.GunStatusScript.arma2 != null)
                {
                    listagay2[DisparoSelectivo.NumeroArmagay].BalasActArma2 = gay.GunStatusScript.arma2.BalasActualesEnCargador;
                }
            }
                
        }
        
    }
}
