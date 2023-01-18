using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class Raycastman : MonoBehaviour {
    public Transform PuntoDisparo;
    public GameObject aymegolpiaste;
    public static bool Activao;
    public static bool efectivamentelehedao = false;
    public static bool alul = false;
    float pulla;
    public float range;
    public GameObject yo;
    public int velocidadregeneracion = 80;
    private bool yaempeso = false;
    public GameObject meleegay;
    public GameObject curasionhomosexual;
    public GameObject FPC;
    public GameObject[] Armas;
    private int NumeroArma;
    public GameObject armasgays1;
    public GameObject armasgays2;
    public GameObject armasgays3;
    public GameObject armasgays4;
    private bool estoyenellojoder = false;
    private float transiciontiempo;
    private bool vamoscojones = false;
    private bool otravez = true;
    private bool lehevolvidoadar = false;
    private bool matandoguey = false;
    private float tiempo;
    private int anteriorgay;
    private int cojonazos;
    private float sumador = 0;
    private float cosadelblur = 0;
    private bool lasdrogastio = false;
    private float cosavingage = 0;
    private float vidact;
    private float regenerasao;
    private bool meregenerojoder = false;
    private float vidaarecuperar;
    private float capullo;
    [HideInInspector]
    private string mishuevos;
    VignetteAndChromaticAberration chromatic_Vignette;
    void Awake () {
        Activao = false;
        matandoguey = false;
    }
    void Start ()
    {
       chromatic_Vignette = gameObject.GetComponent<VignetteAndChromaticAberration>();
        yaempeso = false;
        estoyenellojoder = false;
        meleegay.SetActive(false);
        curasionhomosexual.SetActive(false);
    }
     void Update()
    {

        Controlador.vidahomosexual = Mathf.Clamp(Controlador.vidahomosexual, 0, 100);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Curasiongay();
        }
        if (!alul && !Activao)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                melee();
            }
        }
        if (alul)
        {
            lul();
        }
        if (Animaciones.Ahora)
        {
            lul();
        }
        if (estoyenellojoder)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
               // lehevolvidoadar = true;
              //  vamoscojones = true;
            }
        }
        if (vamoscojones)
        {
            melee();
        }

        if (lasdrogastio)
        {
            drogasi();
        }
        if (!lasdrogastio)
        {
            drogano();
        }
        if (meregenerojoder)
        {
            mestoycurandojoder();
        }
    }


     void lul()
    {
      //  Debug.Log("QUE COJONES ES ESTA PUTA MIERDA");
        if (Activao)
        {
            Debug.Log("MISCOJONAZOSPUTA");
           
            int layerMask = 1 << 8;
            layerMask = ~layerMask;
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range))

            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log(hit.transform.name);

                doit target = hit.transform.GetComponent<doit>();
                alul = false;
                //Debug.Log(target.moribundotio);
                if (target == null)
                {
                    Debug.Log("JODER TIO PUTA MIERDA");
                }
                    if (target != null)
                {
                    if (target.moribundotio) {
                        if (target.tipogay == "campero")
                        {
                            int pene = Random.Range(1, 3);  //RANDOM ANIMACIONES
                            Debug.Log(pene);
                            Animaciones.Animacion = pene;
                            mishuevos = "normal";
                        }
                        if (target.tipogay == "normal")
                        {
                            int pene = Random.Range(1, 3);  //RANDOM ANIMACIONES
                            Debug.Log(pene);
                            Animaciones.Animacion = pene;
                            mishuevos = "normal";
                        }
                        if (target.tipogay == "tocho")
                        {
                            int pene = 3;  //RANDOM ANIMACIONES
                            Animaciones.Animacion = pene;
                            mishuevos = "tocho";
                        }


                    Controlador.mestoylevantandojoder = true;
                    FPC.GetComponent<CharacterController>().enabled = false;
                    Debug.Log("ENVIAO");
                    target.polla = 2;
                    target.sfera = true;
                    target.yaaempezao = true;
                    yaempeso = true;
                    yo.GetComponent<doit2>().enabled = true;
                    yo.GetComponent<doit2>().tipomierda = mishuevos;
                    alul = false;
                    meleegay.SetActive(false);
                    matandoguey = true;
                    }
                    else
                    {
                        melee();
                    }
                }
                if (target == null && !yaempeso)
                {
                    melee();
                }
                }
            else {
                
                alul = false;
                Debug.Log("ME CAGO EN LA PUTA");

                }
            }
        else
        {
          //  melee();
        }
    }
    
    void melee()
    {
        MouseLook.rotationX2 = 0;
        //        Debug.Log("JOJOJO MIS COJONAZOS");
        if (estoyenellojoder) { return; }
        //if (Input.GetButton("Fire1")) { return; }
        if (FPCStatus.IsAiming) { return; }
        if (FPCStatus.IsJumping) { return; }
        if (FPCStatus.isReloading) { return; }
        if (FPCStatus.transicion) { return; }
        if (FPCStatus.accionando) { return; }
        if (matandoguey) { return; }
        meleegay.SetActive(true);
        int polla = Random.Range(1, 4);
        if (polla == anteriorgay)
        {
            cojonazos = polla;
            if (cojonazos == 1)
            {
                polla = 2;
            }
            if (cojonazos == 2)
            {
                polla = 3;
            }
            if (cojonazos == 3)
            {
                polla = 1;
            }
        }
        if (polla == 1)
        {
            tiempo = lehedaoxd.timingpincho;
        }
        if (polla == 2)
        {
            tiempo = lehedaoxd.timingapu;
        }
        if (polla == 3)
        {
            tiempo = lehedaoxd.timingarrastre;
        }
        anteriorgay = polla;
        Invoke("elgolpiador", tiempo);
        otravez = false;
        vamoscojones = false;
        lehevolvidoadar = false;
        efectivamentelehedao = false;
        estoyenellojoder = true;
        armasgays1.SetActive(false);
        armasgays2.SetActive(false);
        armasgays3.SetActive(false);
        armasgays4.SetActive(false);
        FPCStatus.melee = true;
        meleegay.SetActive(true);
        // PA CUANDO TENGAS 3 ANIMACIONES GAYS
        if (polla == 1)
        {
            meleegay.GetComponent<Animator>().Play("pincho");
        }
        if (polla == 2)
        {
            meleegay.GetComponent<Animator>().Play("apu");
        }
        if (polla == 3)
        {
            meleegay.GetComponent<Animator>().Play("arrastrao");
        }
        
    //    meleegay.GetComponent<Animator>().ResetTrigger("pinchito");
        Debug.Log("JOJOJO MIS COJONAZOS");
        //  meleegay.GetComponent<Animator>().SetTrigger("pinchito");
        if (Input.GetKeyDown(KeyCode.F))
        {
           // melee();
           // return;
        }
        Invoke("desactiva", 0.5f);
      //  Invoke("otraves", 0.5f);
    }
    void elgolpiador()
    {
        GameObject golpeadorputamadre = Instantiate(aymegolpiaste, PuntoDisparo.position, PuntoDisparo.rotation);
        golpeadorputamadre.GetComponent<golpiador>().animacion = anteriorgay;

      //  Instantiate(aymegolpiaste, PuntoDisparo.position, PuntoDisparo.rotation);

    }
    void otraves()
    {
        estoyenellojoder = false;
        otravez = true;
    }
    void desactiva()
    {
        if (efectivamentelehedao)
        {
            estoyenellojoder = false;
            melee();
            return;
        }
        
        transiciontiempo = Armas[NumeroArma].GetComponent<GunStatus>().cambioarma;
        FPCStatus.transicion = true;
        estoyenellojoder = false;
        armasgays1.SetActive(true);
        armasgays2.SetActive(true);
        armasgays3.SetActive(true);
        armasgays4.SetActive(true);
        NumeroArma = GameMngr.numerogayarma;
        Armas[NumeroArma].GetComponent<Animator>().enabled = true;
        Armas[NumeroArma].GetComponent<Animator>().ResetTrigger("polladas");
        Armas[NumeroArma].GetComponent<Animator>().ResetTrigger("pollones");
        Armas[NumeroArma].GetComponent<Animator>().ResetTrigger("pollones2");
        Armas[NumeroArma].GetComponent<Animator>().SetTrigger("transigay");
        
        meleegay.SetActive(false);
        curasionhomosexual.SetActive(false);
        Invoke("transicionvuelta", transiciontiempo);
    }
    void transicionvuelta()
    {
        lasdrogastio = false;
        FPCStatus.melee = false;
        Armas[NumeroArma].GetComponent<Animator>().ResetTrigger("polladas");
        Armas[NumeroArma].GetComponent<Animator>().ResetTrigger("pollones");
        Armas[NumeroArma].GetComponent<Animator>().ResetTrigger("transigay");
        Armas[NumeroArma].GetComponent<Animator>().SetTrigger("pollones2");
        Armas[NumeroArma].GetComponent<Animator>().enabled = false;
        FPCStatus.transicion = false;
    }

    void Curasiongay()
    {
        if (FPCStatus.IsAiming) { return; }
        if (FPCStatus.IsJumping) { return; }
        if (FPCStatus.isReloading) { return; }
        if (FPCStatus.transicion) { return; }
        if (matandoguey) { return; }
        if (FPCStatus.melee) { return; }
        if (Controlador.vidahomosexual >= 100) { return; }
        if (Controlador.usos <=  0) { return; }
        armasgays1.SetActive(false);
        armasgays2.SetActive(false);
        armasgays3.SetActive(false);
        armasgays4.SetActive(false);
        meleegay.SetActive(false);
        FPCStatus.melee = true;
        estoyenellojoder = true;
        curasionhomosexual.SetActive(true);
        curasionhomosexual.GetComponent<Animator>().Play("curasiongay");
        Invoke("desactiva", 1.25f);
        Invoke("trigergay", 0.7f);
        Invoke("curarsemangay", 0.7f);
    }

    void curarsemangay()
    {
        meleegay.SetActive(false);
        vidact = Controlador.vidahomosexual;
        regenerasao = vidact;
        meregenerojoder = true;
        Controlador.usos -= 1;
        capullo = vidact += 62;
        if (capullo > 100)
        {
            capullo = 100;
        }
    }
    void mestoycurandojoder()
    {

        if (vidaarecuperar > 0)
        {
            Controlador.vidahomosexual += 1 * Time.deltaTime * velocidadregeneracion;
            regenerasao += 1 * Time.deltaTime * velocidadregeneracion;
            meleegay.SetActive(false);
        }
        else
        {
         //   meregenerojoder = false;
        }
        vidaarecuperar = capullo - regenerasao;


    }

    void trigergay()
    {
        lasdrogastio = true;
    }
    void drogasi()
    {
        sumador += 1 * Time.deltaTime * 200;
        sumador = Mathf.Clamp(sumador, 0, 30);
        chromatic_Vignette.chromaticAberration = sumador;
        cosadelblur = 0.6f;
        chromatic_Vignette.blur = cosadelblur;
        cosavingage = 0.18f;
      //  chromatic_Vignette.intensity = cosavingage;
    }
    void drogano()
    {
        cosavingage -= 1 * Time.deltaTime * 0.3f;
        cosadelblur -= 1 * Time.deltaTime;
        cosavingage = Mathf.Clamp(cosavingage, 0, 2);
        cosadelblur = Mathf.Clamp(cosadelblur, 0, 1);
        sumador -= 1 * Time.deltaTime * 40;
        sumador = Mathf.Clamp(sumador, 0, 30);
        chromatic_Vignette.chromaticAberration = sumador;
        chromatic_Vignette.blur = cosadelblur;
      //  chromatic_Vignette.intensity = cosavingage;
    }

}

