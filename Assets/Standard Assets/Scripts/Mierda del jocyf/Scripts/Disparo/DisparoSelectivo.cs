using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

[System.Serializable]
public class DisparoSelectivo : MonoBehaviour
{
    public int NumeroArma;
    public static int NumeroArmagay;
    public int NumeroSlot;
    public ParticleSystem ps;
    public ParticleSystem ps2;
    public ParticleSystem ps3;
    public ParticleSystem ps4;
    public ParticleSystem ps5;
    public ParticleSystem ps6;
    public ParticleSystem ps7;
    public ParticleSystem ps8;
    public Vector3 offset;

    [Header("Armas y sus propiedades")]
    [Space(5)]
    public GameObject[] Armas;
    public GameObject[] Balas;
    public AudioClip[] Sonidos;
    public int[] Slots;

    [Header("GUI de las armas")]
    public GameObject ManejadorDeDibujoDeArmas;

    [Header("Sangre Wey")]
    public GameObject sangre;
    public GameObject sangrecilla;

    [Header("Nuevos Datos GUI")]
    public Image UIArmas;
    public Sprite[] UIspritesArmas;
    public TextMeshProUGUI UIBalas;

    [Header("Marcador Visual Runtime")]
    public bool DrawRay;

    private float transiciontiempo;
    [HideInInspector]
    public float TiempoDeDisparo;
    [HideInInspector]
    public float TiempoDeDisparo2;
    [HideInInspector]
    public GunStatus GunStatusScript;
    public static GunStatus GunStatusScript2;
    private ArmasEstado ArmasEstadoScript;
    [HideInInspector]
    public AudioSource FireSound;
    private DisparoSecundario secundario;

    private Transform transformPuntoDisparo;
    private Vector3 PuntoDisparo;
    private ParticleSystem.EmissionModule psad;
    private ParticleSystem.EmissionModule psad2;
    private ParticleSystem.EmissionModule psad3;
    private ParticleSystem.EmissionModule psad4;
    private ParticleSystem.EmissionModule psad5;
    private ParticleSystem.EmissionModule psad6;
    private ParticleSystem.EmissionModule psad7;
    private ParticleSystem.EmissionModule psad8;
    private float timergay = 0;
    [HideInInspector]
    public bool cola = false;
    public static float originalfov;
    private float velocityFov;
    public float tiempoballesta;
    public float tiempoballestaULT;
    public GameObject ballestabala;

    private Coroutine instansiao = null;
    private bool levantao = false;
    private Coroutine running = null;

    private normalizador nor;

    private float timerprecision;
    private float timerprecisionobj = 0.35f;

    public void hedisparao()
    {
        timerprecision = 0;
    }

    public void mishuevazos()
    {
        Debug.Log("tu madre la chupa");
    }

    public void ActualizarValoresBalas()
    {
        if (ArmasEstadoScript == null) { return; }
        ArmasEstadoScript.TiempoDestruccion = GunStatusScript.TiempoDestruccion;
        ArmasEstadoScript.Aceleracion = GunStatusScript.Aceleracion;
        ArmasEstadoScript.UseRotation = GunStatusScript.UseRotation;
        ArmasEstadoScript.ProyectilAutoRotacion = GunStatusScript.ProyectilAutoRotacion;
        ArmasEstadoScript.VelocidadRotacion = GunStatusScript.VelocidadRotacion;
        ArmasEstadoScript.Damage = GunStatusScript.Damage;
        ArmasEstadoScript.RatioDeDisparo = GunStatusScript.RatioDeDisparo;
        ArmasEstadoScript.SplashObject = GunStatusScript.SplashObject;
        ArmasEstadoScript.Decall = GunStatusScript.Decall;
    }

    private void ActualizarArma(int NumeroArma)
    {
        FPCStatus.IsAiming = false;
        desactivarpar2();
        cola = false;
        GunStatusScript = Armas[NumeroArma].GetComponent<GunStatus>();
        ArmasEstadoScript = Balas[NumeroArma].GetComponent<ArmasEstado>();
        transformPuntoDisparo = Armas[NumeroArma].GetComponentInChildren<DisableRender>().transform;
        PuntoDisparo = transformPuntoDisparo.position; /**/

        //GunStatusScript.AnimacionesArmagays.transform.localEulerAngles = Vector3.zero;
        // ManejadorDeDibujoDeArmas.SendMessage("ActivarArma", NumeroArma);
        ActivarArma(NumeroArma);

        // Actualizar UI In Game Guay!.

        // Actualizar GUI Antiguo.
        /*GUIArmas.texture = GUITexturasArmas[NumeroArma];
        GUICargadores.text = GunStatusScript.CargadoresActuales.ToString();
        GUIBalas.text = GunStatusScript.BalasActualesEnCargador.ToString();*/

        if (GunStatusScript.isInicialized)
        {
            Armas[NumeroArma].SendMessage("ReasignOriginalValues", GunStatusScript.OrigPosGunNormal);
            Armas[NumeroArma].SendMessage("ReasignOriginalRotValues", GunStatusScript.OrigRotGunNormal);
        }

        gameObject.GetComponent<DisparoSecundario>().GunStatusScript = GunStatusScript;
        gameObject.GetComponent<DisparoSecundario>().transformPuntoDisparo = transformPuntoDisparo;
        GameObject.Find("ArmasUI").GetComponent<RegenEspada>().actualizar(Slots[0], Slots[1]);
        Controlador.ah.gameObject.GetComponent<normalizador>().armaskit = Slots;
        Controlador.ah.gameObject.GetComponent<normalizador>().armaslot = NumeroSlot;
        Controlador.ah.gameObject.GetComponent<normalizador>().actarmas();
        GameObject.Find("MunicionesUIS").SendMessage("ActualizarGays");

        if (instansiao == null) { StartCoroutine(ComprovadorFOV()); }

        if (NumeroArma == 8 && GunStatusScript.BalasActualesEnCargador == 0)
        {
            ballestabala.SetActive(false);
        }
        else
        {
            ballestabala.SetActive(true);
        }
    }


    public Vector3 CalcularDireccionBala(Vector3 _direction)
    {
        Vector3 _bulletdirection = _direction;    // Precision de la bala normal.

        // Si estamos apuntando o la precision del arma no es maxima, calcuklamos la nueva precision (normal o apuntando).
        if (GunStatusScript.Precision != 0 && !FPCStatus.IsAiming)
        {
            float _precision = FPCStatus.IsAiming ? GunStatusScript.Precision : GunStatusScript.Precision;
            _bulletdirection = SprayDirection(_direction, _precision);
        }
        else if (GunStatusScript.aimPrecision != 0 && FPCStatus.IsAiming)
        {
            float _precision = FPCStatus.IsAiming ? GunStatusScript.aimPrecision : GunStatusScript.aimPrecision;
            _bulletdirection = SprayDirection(_direction, _precision);
        }

        //_bulletdirection.x = _bulletdirection.x + (FPCStatus.movimiento.x * 0.05f);


        return _bulletdirection;
    }


    void Start()
    {
        FPCStatus.transicion = false;
        FPCStatus.cambioarma = false;
        nor = Controlador.ah.gameObject.GetComponent<normalizador>();
        secundario = GetComponent<DisparoSecundario>();
        //NumeroArma = GameMngr.numerogayarma;
        originalfov = Controlador.fov;
        Slots = Controlador.ah.gameObject.GetComponent<normalizador>().armaskit;
        NumeroSlot = Controlador.ah.gameObject.GetComponent<normalizador>().armaslot;
        NumeroArma = Slots[NumeroSlot];
        NumeroArmagay = NumeroArma;
        psad8 = ps8.emission;
        psad7 = ps7.emission;
        psad6 = ps6.emission;
        psad5 = ps5.emission;
        psad4 = ps4.emission;
        psad3 = ps3.emission;
        psad2 = ps2.emission;
        psad = ps.emission;
        FireSound = GetComponent<AudioSource>();
        GunStatusScript = Armas[NumeroArma].GetComponent<GunStatus>();
        ArmasEstadoScript = Balas[NumeroArma].GetComponent<ArmasEstado>();
        ActualizarArma(NumeroArma);

        timerprecision = timerprecisionobj;



        // Actualizar UI In Game Guay!.
        //  UIArmas.sprite = UIspritesArmas[NumeroArma];
        //  UIBalas.text = GunStatusScript.CargadoresActuales.ToString() + "/" + GunStatusScript.BalasActualesEnCargador.ToString();

        // Actualizamos valores en pantalla
        /*GUIArmas.texture = this.GUITexturasArmas[this.NumeroArma];
        GUICargadores.text = this.GunStatusScript.CargadoresActuales.ToString();
        GUIBalas.text = this.GunStatusScript.BalasActualesEnCargador.ToString();*/

        transiciontiempo = Armas[NumeroArma].GetComponent<GunStatus>().cambioarma;
        Armas[NumeroArma].GetComponent<Animator>().enabled = true;

        transicion();
        Invoke("transicionvuelta", transiciontiempo);
        FPCStatus.transicion = true;
        ActualizarValoresBalas();

        //Controlador.ah.gameObject.SendMessage("actarmas");

        Invoke("tusputosmuertos", 0.05f);
    }

    void tusputosmuertos()
    {
        //Controlador.ah.gameObject.SendMessage("actarmas");
    }

    void transicionvuelta()
    {
        Armas[NumeroArma].GetComponent<Animator>().ResetTrigger("polladas");
        Armas[NumeroArma].GetComponent<Animator>().ResetTrigger("pollones");
        Armas[NumeroArma].GetComponent<Animator>().ResetTrigger("transigay");
        Armas[NumeroArma].GetComponent<Animator>().SetTrigger("pollones2");

        if (Armas[NumeroArma].GetComponent<GunStatus>().arma2 != null)
        {

            Armas[NumeroArma].GetComponent<GunStatus>().arma2.gameObject.GetComponent<Animator>().ResetTrigger("polladas");
            Armas[NumeroArma].GetComponent<GunStatus>().arma2.gameObject.GetComponent<Animator>().ResetTrigger("pollones");
            Armas[NumeroArma].GetComponent<GunStatus>().arma2.gameObject.GetComponent<Animator>().ResetTrigger("transigay");
            Armas[NumeroArma].GetComponent<GunStatus>().arma2.gameObject.GetComponent<Animator>().SetTrigger("pollones2");
            Armas[NumeroArma].GetComponent<GunStatus>().arma2.gameObject.GetComponent<Animator>().enabled = false;
        }

        Armas[NumeroArma].GetComponent<Animator>().enabled = false;
        FPCStatus.transicion = false;
        FPCStatus.cambioarma = false;
    }
    public void transicion()
    {
        timergay = 0;
        Armas[NumeroArma].GetComponent<Animator>().enabled = true;
        Armas[NumeroArma].GetComponent<Animator>().ResetTrigger("polladas");
        Armas[NumeroArma].GetComponent<Animator>().ResetTrigger("pollones");
        Armas[NumeroArma].GetComponent<Animator>().ResetTrigger("pollones2");
        Armas[NumeroArma].GetComponent<Animator>().SetTrigger("transigay");

        if (Armas[NumeroArma].GetComponent<GunStatus>().arma2 != null) {

            Armas[NumeroArma].GetComponent<GunStatus>().arma2.gameObject.GetComponent<Animator>().enabled = true;
            Armas[NumeroArma].GetComponent<GunStatus>().arma2.gameObject.GetComponent<Animator>().ResetTrigger("polladas");
            Armas[NumeroArma].GetComponent<GunStatus>().arma2.gameObject.GetComponent<Animator>().ResetTrigger("pollones");
            Armas[NumeroArma].GetComponent<GunStatus>().arma2.gameObject.GetComponent<Animator>().ResetTrigger("pollones2");
            Armas[NumeroArma].GetComponent<GunStatus>().arma2.gameObject.GetComponent<Animator>().SetTrigger("transigay");
        }
    }

    void Awake()
    {
        originalfov = Controlador.fov;
    }

    void ActivarArma(int num)
    {
        int i = 0;

        while (i < Armas.Length)
        {
            bool isActive = (i == num);
            Armas[i].GetComponent<Renderer>().enabled = isActive;
            Armas[i].SetActive(isActive);

            if (Armas[i].GetComponent<GunStatus>().arma2 != null)
            {

                Armas[i].GetComponent<GunStatus>().arma2.gameObject.SetActive(isActive);
                Armas[i].GetComponent<GunStatus>().arma2.gameObject.GetComponent<Renderer>().enabled = isActive;

            }

            i++;
        }

    }

    public void Insertar(int Numgay)
    {
        if (!FPCStatus.IsFire2Pressed && !FPCStatus.transicion)
        {
            if (FPCStatus.isReloading) { return; }
            if (FPCStatus.melee) { return; }
            if (Controlador.puntostotales < Controlador.ah.gameObject.GetComponent<normalizador>().listagay[Numgay].Desbloqueo) { return; }

            for (int i = 0; i < Slots.Length; i++)
            {
                if (Numgay == Slots[i]) { return; }
            }

            Slots[NumeroSlot] = Numgay;
            NumeroArma = Slots[NumeroSlot];
            NumeroArmagay = NumeroArma;
            transiciontiempo = Armas[NumeroArma].GetComponent<GunStatus>().cambioarma;
            Armas[NumeroArma].GetComponent<Animator>().enabled = true;
            ActualizarArma(NumeroArma);
            transicion();
            Invoke("transicionvuelta", transiciontiempo);
            FPCStatus.transicion = true;

        }
    }

    void Update()
    {
        timerprecision += Time.deltaTime;
        GunStatusScript2 = GunStatusScript;
        if (Time.timeScale == 0 || Pausa.Pa.dentro) { return; }

        var layerMask = (1 << 0);
        layerMask |= (1 << 2);
        layerMask |= (1 << 4);
        layerMask |= (1 << 8);
        layerMask |= (1 << 13);
        layerMask |= (1 << 14);
        layerMask |= (1 << 17);
        layerMask |= (1 << 22);
        layerMask |= (1 << 23);
        layerMask = ~layerMask;

        if (FPCStatus.transicion && timergay < 0.2f)
        {
            timergay += Time.deltaTime;
            Armas[NumeroArma].GetComponent<Animator>().SetTrigger("transigay");
        }

        /*
        if (GunStatusScript.BalasActualesEnCargador == 0 && FPCStatus.IsFire1Pressed)
        {
            if (GunStatusScript.arma2 == null)
            {
                desactivarpar2();
            }
            else if (GunStatusScript.arma2.BalasActualesEnCargador == 0)
            {
                desactivarpar2();
            }

        }
        */
        

        if (Input.GetButtonUp("Fire1") && NumeroArma == 8)
        {
            DisparoBallesta2();
        }

        if (FPCStatus.isRunning && FPCStatus.melee || Input.GetButtonUp("Fire1"))
        {
            psad.enabled = false;
            psad2.enabled = false;
            psad3.enabled = false;
            psad4.enabled = false;
            psad5.enabled = false;
            psad6.enabled = false;
            psad7.enabled = false;
            psad8.enabled = false;
        }
        if (!Controlador.acabado)
        {
           // if (FPCStatus.isReloading) { return; }
           // if (FPCStatus.transicion) { return; }
            if (FPCStatus.melee) { return; }
            //if (FPCStatus.IsAiming) { return; }
            if (Input.GetKeyDown(KeyCode.Q) && Slots.Length >= 1)
            {
                if (FPCStatus.isReloading) { cancelarecarga(); }
                if (FPCStatus.transicion) { cancelartrans(); }

                if (NumeroSlot == 0)
                {
                    NumeroSlot = 1;
                }
                else if (NumeroSlot == 1)
                {
                    NumeroSlot = 0;
                }
                
                NumeroArma = Slots[NumeroSlot];
                NumeroArmagay = NumeroArma;

                transiciontiempo = Armas[NumeroArma].GetComponent<GunStatus>().cambioarma;
                Armas[NumeroArma].GetComponent<Animator>().enabled = true;
                ActualizarArma(NumeroArma);
                transicion();
                Invoke("transicionvuelta", transiciontiempo);
                FPCStatus.transicion = true;
                FPCStatus.cambioarma = true;
            }
            else if (Input.GetKeyDown("1") && NumeroArma != 0 && Slots.Length >= 1)
            {
                if (FPCStatus.isReloading) { cancelarecarga(); }
                if (FPCStatus.transicion) { cancelartrans(); }

                if (NumeroSlot == 0) { return; }
                NumeroSlot = 0;
                NumeroArma = Slots[NumeroSlot];
                NumeroArmagay = NumeroArma;

                transiciontiempo = Armas[NumeroArma].GetComponent<GunStatus>().cambioarma;
                Armas[NumeroArma].GetComponent<Animator>().enabled = true;
                ActualizarArma(NumeroArma);
                transicion();
                Invoke("transicionvuelta", transiciontiempo);
                FPCStatus.transicion = true;
                FPCStatus.cambioarma = true;
            }
            else if (Input.GetKeyDown("2") && NumeroArma != 1 && Slots.Length >= 2)
            {
                if (FPCStatus.isReloading) { cancelarecarga(); }
                if (FPCStatus.transicion) { cancelartrans(); }

                if (NumeroSlot == 1) { return; }
                NumeroSlot = 1;
                NumeroArma = Slots[NumeroSlot];
                NumeroArmagay = NumeroArma;
                transiciontiempo = Armas[NumeroArma].GetComponent<GunStatus>().cambioarma;
                Armas[NumeroArma].GetComponent<Animator>().enabled = true;
                ActualizarArma(NumeroArma);
                transicion();
                Invoke("transicionvuelta", transiciontiempo);
                FPCStatus.transicion = true;
                FPCStatus.cambioarma = true;
            }
            else if (Input.GetKeyDown("3") && NumeroArma != 2 && Slots.Length >= 3)
            {
                if (FPCStatus.isReloading) { cancelarecarga(); }
                if (FPCStatus.transicion) { cancelartrans(); }

                if (NumeroSlot == 2) { return; }
                NumeroSlot = 2;
                NumeroArma = Slots[NumeroSlot];
                NumeroArmagay = NumeroArma;
                transiciontiempo = Armas[NumeroArma].GetComponent<GunStatus>().cambioarma;
                Armas[NumeroArma].GetComponent<Animator>().enabled = true;
                ActualizarArma(NumeroArma);
                transicion();
                Invoke("transicionvuelta", transiciontiempo);
                FPCStatus.transicion = true;
                FPCStatus.cambioarma = true;
            }
            else if (Input.GetKeyDown("4") && NumeroArma != 3 && Slots.Length >= 4)
            {
                if (FPCStatus.isReloading) { cancelarecarga(); }
                if (FPCStatus.transicion) { cancelartrans(); }

                if (NumeroSlot == 3) { return; }
                NumeroSlot = 3;
                NumeroArma = Slots[NumeroSlot];
                NumeroArmagay = NumeroArma;
                transiciontiempo = Armas[NumeroArma].GetComponent<GunStatus>().cambioarma;
                Armas[NumeroArma].GetComponent<Animator>().enabled = true;
                ActualizarArma(NumeroArma);
                transicion();
                Invoke("transicionvuelta", transiciontiempo);
                FPCStatus.transicion = true;
                FPCStatus.cambioarma = true;
            }
        }


        // Dibujar el rayo a donde ira la bala.
        if (DrawRay)
        {
            Vector3 direction = Camera.main.transform.TransformDirection(Vector3.forward);
            Vector3 Bulletdirection = CalcularDireccionBala(direction);    // Calculamos la direccion que tendra la bala

            direction.z += 0.1f;
            Debug.DrawRay(Camera.main.transform.position, Bulletdirection * 10, Color.green);
        }

        if (!FPCStatus.haybalas || !FPCStatus.IsFire1Pressed)
        {
            psad.enabled = false;
            psad2.enabled = false;
            psad3.enabled = false;
            psad4.enabled = false;
            psad5.enabled = false;
            psad6.enabled = false;
            psad7.enabled = false;
            psad8.enabled = false;
        }

        if (GunStatusScript.Armasgays == Armasgaystipos.Duales2 && FPCStatus.IsFire1Down && Time.time <= TiempoDeDisparo && GunStatusScript.BalasActualesEnCargador > 0)
        {

            if (TiempoDeDisparo - Time.time < 0.15f) { cola = true; }
        }
        if (cola)
        {
            FPCStatus.IsFire1Down = true;
        }

        if (Controlador.acabado) { return; }

        if (!FPCStatus.accionando && !FPCStatus.isRunning && !FPCStatus.melee && FPCStatus.IsFire1Pressed && Time.time > TiempoDeDisparo && !FPCStatus.especial || cola)
        {
            if (Time.time <= TiempoDeDisparo && cola || Time.time <= TiempoDeDisparo2 && cola) { return; }

            
            Controlador.detectao = true;
            if (GunStatusScript.semiautomatica)
            {
                if (FPCStatus.IsFire1Down || cola || NumeroArma == 8 && FPCStatus.IsFire1Pressed)
                {
                    cola = false;
                    // Sentencias de seguridad.
                    if (FPCStatus.IsJumping && !FPCStatus.IsAiming) { return; } // Si NO queremos que dispare miestras salta SIN apuntar. (Opcional)
                    if (FPCStatus.isReloading && GunStatusScript.Armasgays != Armasgaystipos.Duales1) { return; }   // No se puiede disprar mientras se recarga.
                    if (FPCStatus.transicion && GunStatusScript.Armasgays != Armasgaystipos.Duales1) { return; }
                    if (GunStatusScript.recargando) { return; } //AQUÍ PONER METODOGAY NUEVO
                    //if (NumeroArma == 8) { DisparoBallesta(); return; }
                    FPCStatus.isShooting = (GunStatusScript.BalasActualesEnCargador > 0);

                    // Crear el disparo.
                    if (GunStatusScript.Tipo == TiposDisparo.Proyectil)
                    {
                        if (GunStatusScript.BalasActualesEnCargador > 0)
                        {
                            if (NumeroArmagay == 8) { hedisparao(); }

                            PuntoDisparo = transformPuntoDisparo.position;

                            PuntoDisparo = transformPuntoDisparo.position;

                            
                            desactivarpar(true);

                            // Dibuja la bala, el destello en el cañon del arma y que suene un disparo.

                            Transform firepos = GunStatusScript.transform.GetComponentInChildren<DisableRender>().transform;

                            /*
                            RaycastHit hit2 = default(RaycastHit);
                            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit2, Mathf.Infinity, layerMask))
                            {
                                Vector3 relativePos = hit2.point - firepos.position;
                                firepos.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                            }
                            else
                            {
                                Vector3 relativePos = Camera.main.transform.TransformPoint(Vector3.forward * 100) - firepos.position;
                                firepos.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                            }
                            */

                            Vector3 Bulletdirection = CalcularDireccionBala(Vector3.zero);
                            Bulletdirection.z = 1;
                            Vector3 direction = Camera.main.transform.TransformDirection(Bulletdirection);




                            Vector3 des = Vector3.zero;
                            RaycastHit hit;
                            if (Physics.Raycast(Camera.main.transform.position, direction, out hit, 100, layerMask))
                            {
                                des = hit.point;
                            }
                            else
                            {
                                des = Camera.main.transform.position + Camera.main.transform.TransformDirection(0, 0, 100);
                            }

                            //   Vector3 Bulletdirection = CalcularDireccionBala(direction);    // Calculamos la direccion que tendra la bala

                            /**/
                            




                            firepos.rotation = Quaternion.LookRotation(direction, Vector3.up);

                            GameObject CloneFire = Instantiate(Balas[NumeroArma], PuntoDisparo, firepos.rotation);
                            Vector3 rel = des - CloneFire.transform.position;
                            CloneFire.transform.rotation = Quaternion.LookRotation(rel, Vector3.up);
                            Instantiate(GunStatusScript.Destello, PuntoDisparo, Camera.main.transform.rotation);
                            FireSound.PlayOneShot(Sonidos[NumeroArma]);
                            CloneFire.transform.tag = "Granada";
                            CloneFire.SendMessage("vels", GunStatusScript.Aceleracion);

                            if (GunStatusScript.Armasgays != Armasgaystipos.Duales1)
                            {

                                CloneFire.GetComponent<damagegay>().damagehomogay = nor.listagay[NumeroArma].Damage;
                                CloneFire.GetComponent<damagegay>().stun = nor.listagay[NumeroArma].Stun;
                                CloneFire.GetComponent<damagegay>().velbala = GunStatusScript.Aceleracion;
                            }
                            else
                            {
                                CloneFire.GetComponent<mustang>().damagehomosexual = nor.listagay[NumeroArma].Damage;
                                CloneFire.GetComponent<mustang>().stunhomosexual = nor.listagay[NumeroArma].Stun;
                            }
                            // Se calcula la direccion que va a seguir la bala disparada.
                            
                           
                            /**/
                           
                            ballestabala.SetActive(false);
                            TiempoDeDisparo = Time.time + GunStatusScript.RatioDeDisparo;

                            if (GunStatusScript.BalasActualesEnCargador > 0)
                            {

                                UIBalas.text = GunStatusScript.CargadoresActuales.ToString() + "/" + GunStatusScript.BalasActualesEnCargador.ToString();
                                //GUIBalas.text = GunStatusScript.BalasActualesEnCargador.ToString();
                                CancelInvoke("desactivarpar2");
                                Invoke("desactivarpar2", 0.05f);

                                GunStatusScript.BalasActualesEnCargador--;
                            }

                            hedisparao();
                        }
                    }
                    else if (GunStatusScript.Tipo == TiposDisparo.Lanzagranadas)
                    {

                        if (GunStatusScript.BalasActualesEnCargador > 0)
                        {

                            PuntoDisparo = transformPuntoDisparo.position;

                            CancelInvoke("desactivarpar2");
                            Invoke("desactivarpar2", 0.05f);
                            desactivarpar(true);
                            // Dibuja el destello en el cañon del arma y que suene un disparo.
                            Instantiate(GunStatusScript.Destello, PuntoDisparo, Camera.main.transform.rotation);
                            FireSound.PlayOneShot(Sonidos[NumeroArma]);
                            GameObject CloneFire = Instantiate(Balas[NumeroArma], PuntoDisparo, Camera.main.transform.rotation);
                            // CloneFire.GetComponent<Rigidbody>().AddRelativeForce(Bulletdirection, ForceMode.VelocityChange);



                        }


                        TiempoDeDisparo = Time.time + GunStatusScript.RatioDeDisparo;

                        // Decremento la municion y la escribo
                        if (GunStatusScript.BalasActualesEnCargador > 0)
                        {
                            GunStatusScript.BalasActualesEnCargador--;
                            UIBalas.text = GunStatusScript.CargadoresActuales.ToString() + "/" + GunStatusScript.BalasActualesEnCargador.ToString();
                            //GUIBalas.text = GunStatusScript.BalasActualesEnCargador.ToString();
                        }
                    }
                    else if (GunStatusScript.Tipo == TiposDisparo.Inmediato)
                    {
                        if (NumeroArma != 8)
                        {
                            if (GunStatusScript.BalasActualesEnCargador > 0)
                            {
                                PuntoDisparo = transformPuntoDisparo.position;

                                CancelInvoke("desactivarpar2");
                                Invoke("desactivarpar2", 0.05f);
                                desactivarpar(true);
                                // Dibuja el destello en el cañon del arma y que suene un disparo.
                                Instantiate(GunStatusScript.Destello, PuntoDisparo, Camera.main.transform.rotation);
                                FireSound.PlayOneShot(Sonidos[NumeroArma]);

                                Vector3 Bulletdirection = CalcularDireccionBala(Vector3.zero);    // Calculamos la direccion que tendra la bala
                                Bulletdirection.z = 1;
                                Vector3 direction = Camera.main.transform.TransformDirection(Bulletdirection);


                                RaycastHit hit = default(RaycastHit);



                                if (Physics.Raycast(Camera.main.transform.position + offset, direction, out hit, Mathf.Infinity, layerMask))
                                {
                                    //Debug.Log("Nombre  "+hit.transform.name);
                                    if (!hit.collider.tag.Contains("Enemy") && !hit.collider.tag.Contains("Player") &&
                                        !hit.collider.tag.Contains("Armas") && !hit.collider.gameObject.tag.Contains("EndGame") && !hit.collider.gameObject.tag.Contains("putasangre") && !hit.collider.gameObject.tag.Contains("abujero") && !hit.collider.gameObject.tag.Contains("cabesa") && !hit.collider.gameObject.tag.Contains("cuerpasoenemigo"))
                                    {
                                        // GameObject mySplashObj = CrearSplashObject(hit);
                                        //  if (mySplashObj != null){ ColoreaSplash(hit, mySplashObj); }  lo he desactivao yo xq es una puta mierda
                                        CrearDecall(hit);
                                    }
                                    if (hit.collider.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cuerpasoenemigo"))
                                    {
                                        Vector3 posa = hit.point;
                                        GameObject clone;
                                        Crearsangre(hit);
                                        GameObject mySplashObj = CrearSplashObject(hit);
                                        if (mySplashObj != null) { ColoreaSplash(hit, mySplashObj); }
                                        clone = Instantiate(sangre, posa, transform.rotation);
                                    }



                                    // Aplica damage
                                    if (hit.collider.tag.Contains("Blanco") || hit.collider.gameObject.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cristal"))
                                    {
                                        hit.collider.SendMessage("Posgay", hit.point);
                                        hit.collider.SendMessage("Aplicacriticks", nor.listagay[NumeroArma].Critico);
                                        hit.collider.SendMessage("AplicaDamage", nor.listagay[NumeroArma].Damage);
                                        hit.collider.SendMessage("AplicaStun", nor.listagay[NumeroArma].Stun);
                                    }

                                }
                            }


                            TiempoDeDisparo = Time.time + GunStatusScript.RatioDeDisparo;
                            hedisparao();

                            // Decremento la municion y la escribo
                            if (GunStatusScript.BalasActualesEnCargador > 0)
                            {
                                GunStatusScript.BalasActualesEnCargador--;
                                UIBalas.text = GunStatusScript.CargadoresActuales.ToString() + "/" + GunStatusScript.BalasActualesEnCargador.ToString();
                                //GUIBalas.text = GunStatusScript.BalasActualesEnCargador.ToString();
                            }

                            if (GunStatusScript.Armasgays == Armasgaystipos.Duales2 && GunStatusScript.arma2.BalasActualesEnCargador > 0)
                            {
                                cola = false;
                                StartCoroutine(gameObject.GetComponent<DisparoSecundario>().ActivarDisparo());

                            }
                        }
                        else
                        {
                            Disparoballestadef();
                        }
                        
                    }
                    else if (GunStatusScript.Tipo == TiposDisparo.Escoputa)
                    {

                        if (GunStatusScript.BalasActualesEnCargador > 0)
                        {
                            PuntoDisparo = transformPuntoDisparo.position;

                            CancelInvoke("desactivarpar2");
                            Invoke("desactivarpar2", 0.05f);
                            desactivarpar(true);
                            
                            // Dibuja el destello en el cañon del arma y que suene un disparo.
                            Instantiate(GunStatusScript.Destello, PuntoDisparo, Camera.main.transform.rotation);
                            FireSound.PlayOneShot(Sonidos[NumeroArma]);

                            hedisparao();

                            RaycastHit hit = default(RaycastHit);
                            for (int i = 0; i < 8; i++)
                            {

                                Vector3 direction = Camera.main.transform.TransformDirection(Vector3.forward);
                                Vector3 Bulletdirection = CalcularDireccionBala(direction);    // Calculamos la direccion que tendra la bala
                                direction.z += 0.1f;

                                if (Physics.Raycast(Camera.main.transform.position + direction + offset, Bulletdirection, out hit, 1000, layerMask))
                                {
                                    //Debug.Log("Nombre  "+hit.transform.name);
                                    if (!hit.collider.tag.Contains("Enemy") && !hit.collider.tag.Contains("Player") && !hit.collider.gameObject.tag.Contains("cabesa") && !hit.collider.gameObject.tag.Contains("cuerpasoenemigo") &&
                                        !hit.collider.tag.Contains("Armas") && !hit.collider.gameObject.tag.Contains("EndGame") && !hit.collider.gameObject.tag.Contains("putasangre") && !hit.collider.gameObject.tag.Contains("abujero"))
                                    {
                                        // GameObject mySplashObj = CrearSplashObject(hit);
                                        //  if (mySplashObj != null){ ColoreaSplash(hit, mySplashObj); }  lo he desactivao yo xq es una puta mierda
                                        CrearDecall(hit);
                                    }
                                    if (hit.collider.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cuerpasoenemigo"))
                                    {
                                        Vector3 posa = hit.point;
                                        GameObject clone;
                                        Crearsangre(hit);
                                        GameObject mySplashObj = CrearSplashObject(hit);
                                        if (mySplashObj != null) { ColoreaSplash(hit, mySplashObj); }
                                        clone = Instantiate(sangre, posa, transform.rotation);
                                    }



                                    // Aplica damage
                                    if (hit.collider.tag.Contains("Blanco") || hit.collider.gameObject.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cristal"))
                                    {
                                        float prc = nerfeo(hit);
                                        hit.collider.SendMessage("Posgay", transform.position);
                                        hit.collider.SendMessage("Aplicacriticks", nor.listagay[NumeroArma].Critico * prc);
                                        hit.collider.SendMessage("AplicaDamage", nor.listagay[NumeroArma].Damage * prc);
                                        hit.collider.SendMessage("AplicaStun", nor.listagay[NumeroArma].Stun * prc);
                                    }

                                }
                            }


                        }


                        TiempoDeDisparo = Time.time + GunStatusScript.RatioDeDisparo;

                        // Decremento la municion y la escribo
                        if (GunStatusScript.BalasActualesEnCargador > 0)
                        {
                            GunStatusScript.BalasActualesEnCargador--;
                            UIBalas.text = GunStatusScript.CargadoresActuales.ToString() + "/" + GunStatusScript.BalasActualesEnCargador.ToString();
                            //GUIBalas.text = GunStatusScript.BalasActualesEnCargador.ToString();
                        }

                        if (GunStatusScript.CargadoresActuales > 0 && GunStatusScript.BalasActualesEnCargador == 0)
                        {
                            //FPCStatus.transicion = true;
                            gameObject.GetComponent<ReloadWeapon>().delay = 0.05f;
                            secundario.lolsexual = StartCoroutine(gameObject.GetComponent<ReloadWeapon>()._ReloadWeapon(GunStatusScript, false, false));
                        }
                    }
                }
            }
            if (!GunStatusScript.semiautomatica)
            {


                // Sentencias de seguridad.
                if (FPCStatus.IsJumping && !FPCStatus.IsAiming) { return; } // Si NO queremos que dispare miestras salta SIN apuntar. (Opcional)
                if (FPCStatus.isReloading) { return; }   // No se puiede disprar mientras se recarga.
                if (FPCStatus.transicion) { return; }
                FPCStatus.isShooting = (GunStatusScript.BalasActualesEnCargador > 0);

                // Crear el disparo.
                if (GunStatusScript.Tipo == TiposDisparo.Proyectil)
                {

                    if (GunStatusScript.BalasActualesEnCargador > 0)
                    {
                        CancelInvoke("desactivarpar2");
                        Invoke("desactivarpar2", 0.05f);
                        desactivarpar(true);
                    }


                    if (GunStatusScript.BalasActualesEnCargador > 0 && Time.time > TiempoDeDisparo)
                    {
                        PuntoDisparo = transformPuntoDisparo.position;

                        GameObject CloneFire = Instantiate(Balas[NumeroArma], PuntoDisparo, Camera.main.transform.rotation);
                        //  Instantiate(GunStatusScript.Destello, PuntoDisparo, Camera.main.transform.rotation);
                        //FireSound.Stop();    
                        FireSound.PlayOneShot(Sonidos[NumeroArma]);

                        // Se calcula la direccion que va a seguir la bala disparada.
                        Vector3 a = CalcularDireccionBala(Vector3.forward);
                        a.z = 1;
                        Vector3 direction = Camera.main.transform.TransformDirection(a);

                        Vector3 des = Vector3.zero;
                        RaycastHit hit;
                        if (Physics.Raycast(Camera.main.transform.position, direction, out hit, 100, layerMask))
                        {
                            des = hit.point;
                        }
                        else
                        {
                            des = Camera.main.transform.position + Camera.main.transform.TransformDirection(0,0,100);
                        }

                        //   Vector3 Bulletdirection = CalcularDireccionBala(direction);    // Calculamos la direccion que tendra la bala

                        /**/
                        Vector3 rel = des - CloneFire.transform.position;
                        CloneFire.transform.rotation = Quaternion.LookRotation(rel, Vector3.up);
                        //CloneFire.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * GunStatusScript.Aceleracion, ForceMode.VelocityChange);
                        CloneFire.SendMessage("vels", GunStatusScript.Aceleracion);

                        CloneFire.GetComponent<damagegay>().damagehomogay = nor.listagay[NumeroArma].Damage;
                        CloneFire.GetComponent<damagegay>().stun = nor.listagay[NumeroArma].Stun;
                        CloneFire.GetComponent<damagegay>().velbala = GunStatusScript.Aceleracion;

                        GunStatusScript.BalasActualesEnCargador--; //Quizás haya que cargarse esto yokse
                        TiempoDeDisparo = Time.time + GunStatusScript.RatioDeDisparo;
                        hedisparao();
                    }
                }
                else if (GunStatusScript.Tipo == TiposDisparo.Inmediato)
                {

                    if (GunStatusScript.BalasActualesEnCargador > 0)
                    {
                        PuntoDisparo = transformPuntoDisparo.position;

                        CancelInvoke("desactivarpar2");
                        Invoke("desactivarpar2", 0.05f);
                        desactivarpar(true);
                        // Dibuja el destello en el cañon del arma y que suene un disparo.
                        Instantiate(GunStatusScript.Destello, PuntoDisparo, Camera.main.transform.rotation);
                        FireSound.PlayOneShot(Sonidos[NumeroArma]);

                        Vector3 direction = Camera.main.transform.TransformDirection(Vector3.forward);
                        Vector3 Bulletdirection = CalcularDireccionBala(direction);    // Calculamos la direccion que tendra la bala

                        RaycastHit hit = default(RaycastHit);
                        direction.z += 0.1f;
                        if (Physics.Raycast(Camera.main.transform.position + direction + offset, Bulletdirection, out hit, 1000, layerMask))
                        {
                            //Debug.Log("Nombre  "+hit.transform.name);
                            if (!hit.collider.tag.Contains("Enemy") && !hit.collider.tag.Contains("Player") && !hit.collider.gameObject.tag.Contains("cabesa") && !hit.collider.gameObject.tag.Contains("cuerpasoenemigo") &&
                                !hit.collider.tag.Contains("Armas") && !hit.collider.gameObject.tag.Contains("EndGame") && !hit.collider.gameObject.tag.Contains("putasangre") && !hit.collider.gameObject.tag.Contains("abujero"))
                            {
                                // GameObject mySplashObj = CrearSplashObject(hit);
                                //  if (mySplashObj != null){ ColoreaSplash(hit, mySplashObj); }  lo he desactivao yo xq es una puta mierda
                                CrearDecall(hit);
                            }
                            if (hit.collider.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cuerpasoenemigo"))
                            {
                                Vector3 posa = hit.point;
                                GameObject clone;
                                Crearsangre(hit);
                                GameObject mySplashObj = CrearSplashObject(hit);
                                if (mySplashObj != null) { ColoreaSplash(hit, mySplashObj); }
                                clone = Instantiate(sangre, posa, transform.rotation);
                            }



                            // Aplica damage
                            if (hit.collider.tag.Contains("Blanco") || hit.collider.gameObject.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cristal"))
                            {
                                hit.collider.SendMessage("Posgay", hit.point);
                                hit.collider.SendMessage("Aplicacriticks", nor.listagay[NumeroArma].Critico);
                                hit.collider.SendMessage("AplicaDamage", nor.listagay[NumeroArma].Damage);
                                hit.collider.SendMessage("AplicaStun", nor.listagay[NumeroArma].Stun);
                            }

                        }
                    }


                    TiempoDeDisparo = Time.time + GunStatusScript.RatioDeDisparo;
                    hedisparao();

                    // Decremento la municion y la escribo
                    if (GunStatusScript.BalasActualesEnCargador > 0)
                    {
                        GunStatusScript.BalasActualesEnCargador--;
                        UIBalas.text = GunStatusScript.CargadoresActuales.ToString() + "/" + GunStatusScript.BalasActualesEnCargador.ToString();
                        //GUIBalas.text = GunStatusScript.BalasActualesEnCargador.ToString();
                    }
                }
                else if (GunStatusScript.Tipo == TiposDisparo.Escoputa)
                {

                    if (GunStatusScript.BalasActualesEnCargador > 0)
                    {
                        PuntoDisparo = transformPuntoDisparo.position;

                        CancelInvoke("desactivarpar2");
                        Invoke("desactivarpar2", 0.05f);
                        desactivarpar(true);
                        // Dibuja el destello en el cañon del arma y que suene un disparo.
                        Instantiate(GunStatusScript.Destello, PuntoDisparo, Camera.main.transform.rotation);
                        FireSound.PlayOneShot(Sonidos[NumeroArma]);

                        Vector3 direction = Camera.main.transform.TransformDirection(Vector3.forward);
                        Vector3 direction2 = Camera.main.transform.TransformDirection(Vector3.forward);
                        Vector3 Bulletdirection = CalcularDireccionBala(direction);    // Calculamos la direccion que tendra la bala
                        Vector3 Bulletdirection2 = CalcularDireccionBala(direction);
                        Vector3 Bulletdirection3 = CalcularDireccionBala(direction);
                        Vector3 Bulletdirection4 = CalcularDireccionBala(direction);
                        Vector3 Bulletdirection5 = CalcularDireccionBala(direction);
                        Vector3 Bulletdirection6 = CalcularDireccionBala(direction);
                        Vector3 Bulletdirection7 = CalcularDireccionBala(direction);

                        RaycastHit hit = default(RaycastHit);
                        direction.z += 0.1f;
                        if (Physics.Raycast(Camera.main.transform.position + direction + offset, Bulletdirection, out hit, 1000, layerMask))
                        {
                            //Debug.Log("Nombre  "+hit.transform.name);
                            if (!hit.collider.tag.Contains("Enemy") && !hit.collider.tag.Contains("Player") && !hit.collider.gameObject.tag.Contains("cabesa") && !hit.collider.gameObject.tag.Contains("cuerpasoenemigo") &&
                                !hit.collider.tag.Contains("Armas") && !hit.collider.gameObject.tag.Contains("EndGame") && !hit.collider.gameObject.tag.Contains("putasangre") && !hit.collider.gameObject.tag.Contains("abujero"))
                            {
                                // GameObject mySplashObj = CrearSplashObject(hit);
                                //  if (mySplashObj != null){ ColoreaSplash(hit, mySplashObj); }  lo he desactivao yo xq es una puta mierda
                                CrearDecall(hit);
                            }
                            if (hit.collider.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cuerpasoenemigo"))
                            {
                                Vector3 posa = hit.point;
                                GameObject clone;
                                Crearsangre(hit);
                                GameObject mySplashObj = CrearSplashObject(hit);
                                if (mySplashObj != null) { ColoreaSplash(hit, mySplashObj); }
                                clone = Instantiate(sangre, posa, transform.rotation);
                            }



                            // Aplica damage
                            if (hit.collider.tag.Contains("Blanco") || hit.collider.gameObject.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cristal"))
                            {
                                hit.collider.SendMessage("Posgay", hit.point);
                                hit.collider.SendMessage("Aplicacriticks", nor.listagay[NumeroArma].Critico);
                                hit.collider.SendMessage("AplicaDamage", nor.listagay[NumeroArma].Damage);
                                hit.collider.SendMessage("AplicaStun", nor.listagay[NumeroArma].Stun);
                            }

                        }
                        if (Physics.Raycast(Camera.main.transform.position + direction + offset, Bulletdirection2, out hit, 1000, layerMask))
                        {
                            //Debug.Log("Nombre  "+hit.transform.name);
                            if (!hit.collider.tag.Contains("Enemy") && !hit.collider.tag.Contains("Player") && !hit.collider.gameObject.tag.Contains("cabesa") && !hit.collider.gameObject.tag.Contains("cuerpasoenemigo") &&
                                !hit.collider.tag.Contains("Armas") && !hit.collider.gameObject.tag.Contains("EndGame") && !hit.collider.gameObject.tag.Contains("putasangre") && !hit.collider.gameObject.tag.Contains("abujero"))
                            {
                                // GameObject mySplashObj = CrearSplashObject(hit);
                                //  if (mySplashObj != null){ ColoreaSplash(hit, mySplashObj); }  lo he desactivao yo xq es una puta mierda
                                CrearDecall(hit);
                            }
                            if (hit.collider.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cuerpasoenemigo"))
                            {
                                Vector3 posa = hit.point;
                                GameObject clone;
                                Crearsangre(hit);
                                GameObject mySplashObj = CrearSplashObject(hit);
                                if (mySplashObj != null) { ColoreaSplash(hit, mySplashObj); }
                                clone = Instantiate(sangre, posa, transform.rotation);
                            }



                            // Aplica damage
                            if (hit.collider.tag.Contains("Blanco") || hit.collider.gameObject.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cristal"))
                            {
                                hit.collider.SendMessage("Posgay", hit.point);
                                hit.collider.SendMessage("Aplicacriticks", nor.listagay[NumeroArma].Critico);
                                hit.collider.SendMessage("AplicaDamage", nor.listagay[NumeroArma].Damage);
                                hit.collider.SendMessage("AplicaStun", nor.listagay[NumeroArma].Stun);
                            }

                        }
                        if (Physics.Raycast(Camera.main.transform.position + direction + offset, Bulletdirection3, out hit, 1000, layerMask))
                        {
                            //Debug.Log("Nombre  "+hit.transform.name);
                            if (!hit.collider.tag.Contains("Enemy") && !hit.collider.tag.Contains("Player") && !hit.collider.gameObject.tag.Contains("cabesa") && !hit.collider.gameObject.tag.Contains("cuerpasoenemigo") &&
                                !hit.collider.tag.Contains("Armas") && !hit.collider.gameObject.tag.Contains("EndGame") && !hit.collider.gameObject.tag.Contains("putasangre") && !hit.collider.gameObject.tag.Contains("abujero"))
                            {
                                // GameObject mySplashObj = CrearSplashObject(hit);
                                //  if (mySplashObj != null){ ColoreaSplash(hit, mySplashObj); }  lo he desactivao yo xq es una puta mierda
                                CrearDecall(hit);
                            }
                            if (hit.collider.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cuerpasoenemigo"))
                            {
                                Vector3 posa = hit.point;
                                GameObject clone;
                                Crearsangre(hit);
                                GameObject mySplashObj = CrearSplashObject(hit);
                                if (mySplashObj != null) { ColoreaSplash(hit, mySplashObj); }
                                clone = Instantiate(sangre, posa, transform.rotation);
                            }



                            // Aplica damage
                            if (hit.collider.tag.Contains("Blanco") || hit.collider.gameObject.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cristal"))
                            {
                                hit.collider.SendMessage("Posgay", hit.point);
                                hit.collider.SendMessage("Aplicacriticks", nor.listagay[NumeroArma].Critico);
                                hit.collider.SendMessage("AplicaDamage", nor.listagay[NumeroArma].Damage);
                                hit.collider.SendMessage("AplicaStun", nor.listagay[NumeroArma].Stun);
                            }

                        }
                        if (Physics.Raycast(Camera.main.transform.position + direction + offset, Bulletdirection4, out hit, 1000, layerMask))
                        {
                            //Debug.Log("Nombre  "+hit.transform.name);
                            if (!hit.collider.tag.Contains("Enemy") && !hit.collider.tag.Contains("Player") && !hit.collider.gameObject.tag.Contains("cabesa") && !hit.collider.gameObject.tag.Contains("cuerpasoenemigo") &&
                                !hit.collider.tag.Contains("Armas") && !hit.collider.gameObject.tag.Contains("EndGame") && !hit.collider.gameObject.tag.Contains("putasangre") && !hit.collider.gameObject.tag.Contains("abujero"))
                            {
                                // GameObject mySplashObj = CrearSplashObject(hit);
                                //  if (mySplashObj != null){ ColoreaSplash(hit, mySplashObj); }  lo he desactivao yo xq es una puta mierda
                                CrearDecall(hit);
                            }
                            if (hit.collider.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cuerpasoenemigo"))
                            {
                                Vector3 posa = hit.point;
                                GameObject clone;
                                Crearsangre(hit);
                                GameObject mySplashObj = CrearSplashObject(hit);
                                if (mySplashObj != null) { ColoreaSplash(hit, mySplashObj); }
                                clone = Instantiate(sangre, posa, transform.rotation);
                            }



                            // Aplica damage
                            if (hit.collider.tag.Contains("Blanco") || hit.collider.gameObject.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cristal"))
                            {
                                hit.collider.SendMessage("Posgay", hit.point);
                                hit.collider.SendMessage("Aplicacriticks", nor.listagay[NumeroArma].Critico);
                                hit.collider.SendMessage("AplicaDamage", nor.listagay[NumeroArma].Damage);
                                hit.collider.SendMessage("AplicaStun", nor.listagay[NumeroArma].Stun);
                            }

                        }
                        if (Physics.Raycast(Camera.main.transform.position + direction + offset, Bulletdirection5, out hit, 1000, layerMask))
                        {
                            //Debug.Log("Nombre  "+hit.transform.name);
                            if (!hit.collider.tag.Contains("Enemy") && !hit.collider.tag.Contains("Player") && !hit.collider.gameObject.tag.Contains("cabesa") && !hit.collider.gameObject.tag.Contains("cuerpasoenemigo") &&
                                !hit.collider.tag.Contains("Armas") && !hit.collider.gameObject.tag.Contains("EndGame") && !hit.collider.gameObject.tag.Contains("putasangre") && !hit.collider.gameObject.tag.Contains("abujero"))
                            {
                                // GameObject mySplashObj = CrearSplashObject(hit);
                                //  if (mySplashObj != null){ ColoreaSplash(hit, mySplashObj); }  lo he desactivao yo xq es una puta mierda
                                CrearDecall(hit);
                            }
                            if (hit.collider.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cuerpasoenemigo"))
                            {
                                Vector3 posa = hit.point;
                                GameObject clone;
                                Crearsangre(hit);
                                GameObject mySplashObj = CrearSplashObject(hit);
                                if (mySplashObj != null) { ColoreaSplash(hit, mySplashObj); }
                                clone = Instantiate(sangre, posa, transform.rotation);
                            }



                            // Aplica damage
                            if (hit.collider.tag.Contains("Blanco") || hit.collider.gameObject.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cristal"))
                            {
                                hit.collider.SendMessage("Posgay", hit.point);
                                hit.collider.SendMessage("Aplicacriticks", nor.listagay[NumeroArma].Critico);
                                hit.collider.SendMessage("AplicaDamage", nor.listagay[NumeroArma].Damage);
                                hit.collider.SendMessage("AplicaStun", nor.listagay[NumeroArma].Stun);
                            }

                        }
                        if (Physics.Raycast(Camera.main.transform.position + direction + offset, Bulletdirection6, out hit, 1000, layerMask))
                        {
                            //Debug.Log("Nombre  "+hit.transform.name);
                            if (!hit.collider.tag.Contains("Enemy") && !hit.collider.tag.Contains("Player") && !hit.collider.gameObject.tag.Contains("cabesa") && !hit.collider.gameObject.tag.Contains("cuerpasoenemigo") &&
                                !hit.collider.tag.Contains("Armas") && !hit.collider.gameObject.tag.Contains("EndGame") && !hit.collider.gameObject.tag.Contains("putasangre") && !hit.collider.gameObject.tag.Contains("abujero"))
                            {
                                // GameObject mySplashObj = CrearSplashObject(hit);
                                //  if (mySplashObj != null){ ColoreaSplash(hit, mySplashObj); }  lo he desactivao yo xq es una puta mierda
                                CrearDecall(hit);
                            }
                            if (hit.collider.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cuerpasoenemigo"))
                            {
                                Vector3 posa = hit.point;
                                GameObject clone;
                                Crearsangre(hit);
                                GameObject mySplashObj = CrearSplashObject(hit);
                                if (mySplashObj != null) { ColoreaSplash(hit, mySplashObj); }
                                clone = Instantiate(sangre, posa, transform.rotation);
                            }



                            // Aplica damage
                            if (hit.collider.tag.Contains("Blanco") || hit.collider.gameObject.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cristal"))
                            {
                                hit.collider.SendMessage("Posgay", hit.point);
                                hit.collider.SendMessage("Aplicacriticks", nor.listagay[NumeroArma].Critico);
                                hit.collider.SendMessage("AplicaDamage", nor.listagay[NumeroArma].Damage);
                                hit.collider.SendMessage("AplicaStun", nor.listagay[NumeroArma].Stun);
                            }

                        }
                        if (Physics.Raycast(Camera.main.transform.position + direction + offset, Bulletdirection7, out hit, 1000, layerMask))
                        {
                            //Debug.Log("Nombre  "+hit.transform.namecristal
                            if (!hit.collider.tag.Contains("Enemy") && !hit.collider.tag.Contains("Player") && !hit.collider.gameObject.tag.Contains("cabesa") && !hit.collider.gameObject.tag.Contains("cuerpasoenemigo") && !hit.collider.gameObject.tag.Contains("micuerpochingon") &&
                                !hit.collider.tag.Contains("Armas") && !hit.collider.gameObject.tag.Contains("EndGame") && !hit.collider.gameObject.tag.Contains("putasangre") && !hit.collider.gameObject.tag.Contains("abujero"))
                            {
                                // GameObject mySplashObj = CrearSplashObject(hit);
                                //  if (mySplashObj != null){ ColoreaSplash(hit, mySplashObj); }  lo he desactivao yo xq es una puta mierda
                                CrearDecall(hit);
                            }
                            if (hit.collider.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cuerpasoenemigo"))
                            {
                                Vector3 posa = hit.point;
                                GameObject clone;
                                Crearsangre(hit);
                                GameObject mySplashObj = CrearSplashObject(hit);
                                if (mySplashObj != null) { ColoreaSplash(hit, mySplashObj); }
                                clone = Instantiate(sangre, posa, transform.rotation);
                            }



                            // Aplica damage
                            if (hit.collider.tag.Contains("Blanco") || hit.collider.gameObject.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cristal"))
                            {
                                hit.collider.SendMessage("Posgay", hit.point);
                                hit.collider.SendMessage("Aplicacriticks", nor.listagay[NumeroArma].Critico);
                                hit.collider.SendMessage("AplicaDamage", nor.listagay[NumeroArma].Damage);
                                hit.collider.SendMessage("AplicaStun", nor.listagay[NumeroArma].Stun);
                            }

                        }








                    }


                    TiempoDeDisparo = Time.time + GunStatusScript.RatioDeDisparo;
                    hedisparao();

                    // Decremento la municion y la escribo
                    if (GunStatusScript.BalasActualesEnCargador > 0)
                    {
                        GunStatusScript.BalasActualesEnCargador--;
                        UIBalas.text = GunStatusScript.CargadoresActuales.ToString() + "/" + GunStatusScript.BalasActualesEnCargador.ToString();
                        //GUIBalas.text = GunStatusScript.BalasActualesEnCargador.ToString();
                    }
                }
            }





        }
        else if (!FPCStatus.especial)
        {

                FPCStatus.isShooting = false;

        }
    }

    public void desactivarpar2()
    {
        ParticleSystem.EmissionModule psa = ps.emission;
        ParticleSystem.EmissionModule psa2 = ps2.emission;
        ParticleSystem.EmissionModule psa3 = ps3.emission;
        ParticleSystem.EmissionModule psa4 = ps4.emission;
        ParticleSystem.EmissionModule psa5 = ps5.emission;
        ParticleSystem.EmissionModule psa6 = ps6.emission;
        ParticleSystem.EmissionModule psa7 = ps7.emission;
        ParticleSystem.EmissionModule psa8 = ps8.emission;
        psa.enabled = false;
        psa2.enabled = false;
        psa3.enabled = false;
        psa4.enabled = false;
        psa5.enabled = false;
        psa6.enabled = false;
        psa7.enabled = false;
        psa8.enabled = false;
    }


    public void desactivarpar(bool a)
    {        
        ParticleSystem.EmissionModule psa = ps.emission;
        ParticleSystem.EmissionModule psa2 = ps2.emission;
        ParticleSystem.EmissionModule psa3 = ps3.emission;
        ParticleSystem.EmissionModule psa4 = ps4.emission;
        ParticleSystem.EmissionModule psa5 = ps5.emission;
        ParticleSystem.EmissionModule psa6 = ps6.emission;
        ParticleSystem.EmissionModule psa7 = ps7.emission;
        ParticleSystem.EmissionModule psa8 = ps8.emission;
        psa.enabled = a;
        psa2.enabled = a;
        psa3.enabled = a;
        psa4.enabled = a;
        psa5.enabled = a;
        psa6.enabled = a;
        psa7.enabled = a;
        psa8.enabled = a;
    }

    // Creamos el SplashObject apropiadamente.
    public GameObject CrearSplashObject(RaycastHit hit)
    {
        return gameObject;
        if (GunStatusScript.SplashObject == null) return null;

        Vector3 pos = hit.point;
        //Quaternion rot = GunStatusScript.UseRotation ? Quaternion.FromToRotation(Vector3.forward, hit.normal) : Quaternion.identity;
        // Quaternion rot = GunStatusScript.UseRotation ? Quaternion.LookRotation(hit.normal) : Quaternion.identity;
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, hit.normal);
        GameObject _splahObject = Instantiate(GunStatusScript.SplashObject, pos, rot);
        _splahObject.transform.position += _splahObject.transform.up * 0.1f;
        return _splahObject;
    }

    // Coloreamos la particula con el color del objeto con el que colisiona. Colorea la particula si existe el Renderer
    public void ColoreaSplash(RaycastHit hit, GameObject _splashObj)
    {
        if (hit.transform.GetComponent<Renderer>() == null) { return; } // Sentencia de seguridad.

        Color MyColor = hit.transform.GetComponent<Renderer>().material.color;
        _splashObj.SendMessage("CambiarColorParticula", MyColor);
        //ParticleChangeColor MyParticleColor = MySplashObj.GetComponent<ParticleChangeColor>();
        //MyParticleColor.MyColor = MyColor;
    }

    // Creamos en decal en la superfinie del objeto.
    public void CrearDecall(RaycastHit hit)
    {
        Vector3 pos = hit.point;
        Quaternion rotDecall = Quaternion.FromToRotation(Vector3.up, hit.normal);
        GameObject DecallObj = Instantiate(GunStatusScript.Decall, pos, rotDecall);
        DecallObj.SendMessage("lol", hit.transform.gameObject);
        /**/
        /*Vector3 _posAux = DecallObj.transform.position;
        _posAux.y = DecallObj.transform.position.y + 0.1f;
        DecallObj.transform.position = _posAux;*/
        DecallObj.transform.position += DecallObj.transform.up * 0.03f;
        if (hit.collider.tag.Contains("Blanco"))
        {
            DecallObj.transform.parent = hit.transform;
        }

        if (hit.transform.CompareTag("cristal"))
        {
            hit.transform.SendMessage("bum", hit.point);
            Debug.Log("sex2");
        }
        
        // DecallObj.transform.parent = hit.transform; NO TIO XQ EN LAS SUPERFICIES PLANAS ES GAY
    }
    public void Crearsangre(RaycastHit hit)
    {
        /*
         Vector3 pos = hit.point;
         Quaternion rotDecall = Quaternion.FromToRotation(Vector3.up, hit.normal);
         GameObject DecallObja = Instantiate(sangrecilla, pos, rotDecall);

         DecallObja.transform.position += DecallObja.transform.up * 0.03f;

         DecallObja.transform.parent = hit.transform;

         */
        hit.transform.SendMessage("sangrecilla", hit);

    }

    public Vector3 SprayDirection(Vector3 direction, float _precision)
    {
        if (timerprecision >= timerprecisionobj) { _precision = 0; }
        direction.x = direction.x + ((1 - (2 * Random.value)) * _precision);
        direction.y = direction.y + ((1 - (2 * Random.value)) * _precision);
        direction.z = direction.z + ((1 - (2 * Random.value)) * _precision);
        return direction;
    }



    public Vector3 AimSprayDirection(Vector3 direction, float _aimPrecision)
    {
        return SprayDirection(direction, _aimPrecision);
    }

    /*public Vector3 SprayDirection(Vector3 direction)
    {
        direction.x = direction.x + ((1 - (2 * Random.value)) * GunStatusScript.Precision);
        direction.y = direction.y + ((1 - (2 * Random.value)) * GunStatusScript.Precision);
        direction.z = direction.z + ((1 - (2 * Random.value)) * GunStatusScript.Precision);
        return direction;
    }

    public Vector3 AimSprayDirection(Vector3 direction)
    {
        direction.x = direction.x + ((1 - (2 * Random.value)) * GunStatusScript.aimPrecision);
        direction.y = direction.y + ((1 - (2 * Random.value)) * GunStatusScript.aimPrecision);
        direction.z = direction.z + ((1 - (2 * Random.value)) * GunStatusScript.aimPrecision);
        return direction;
    }*/

    public float nerfeo(RaycastHit man)
    {
        float dis = man.distance;

        float def = -1.8182f * dis; def += 132.73f; def = Mathf.Clamp(def, 60, 100); def /= 100;

        return def;
    }

    IEnumerator ComprovadorFOV()
    {
        while (true)
        {
            yield return null;
            Camera.main.fieldOfView = Mathf.SmoothDamp(Camera.main.fieldOfView, originalfov, ref velocityFov, 10 * 0.0065f);

            if (Camera.main.fieldOfView == originalfov || FPCStatus.IsAiming) { break; }
        }

        instansiao = null;
    }

    void DisparoBallesta()
    {
        tiempoballesta += Time.deltaTime;

        if (tiempoballesta < 0.3f) { return; }


        if (Time.time > Controlador.cd2ratio && Time.time > TiempoDeDisparo)
        {

            StartCoroutine(sexualsex());
        }
        else
        {
            DisparoBallesta2();
        }

    }

    IEnumerator sexualsex()
    {
        DisparoSecundario lel = GetComponent<DisparoSecundario>();
        GameObject CloneFire = Instantiate(lel.balas[0], transformPuntoDisparo.position + (Camera.main.transform.forward * 0.3f), Quaternion.FromToRotation(Vector3.up, Camera.main.transform.forward));
        //CloneFire.GetComponent<damagegay>().damagehomogay = GunStatusScript.Damage;
        //	CloneFire.GetComponent<damagegay>().velbala = GunStatusScript.Aceleracion;

        Vector3 Bulletdirection = Camera.main.transform.TransformDirection(CalcularDireccionBala(Vector3.forward));

        Vector3 dirwena = Vector3.zero;
        dirwena.y = GunStatusScript.Aceleracion;

        //CloneFire.transform.LookAt(CloneFire.transform.position + Bulletdirection);
        //CloneFire.GetComponent<Rigidbody>().AddRelativeForce(dirwena, ForceMode.VelocityChange);
        CloneFire.SendMessage("vels", GunStatusScript.Aceleracion);



        Controlador.cd2ratio = Time.time + Controlador.cd2;
        TiempoDeDisparo = Time.time + GunStatusScript.RatioDeDisparo;
        hedisparao();
        tiempoballesta = 0;
        FPCStatus.isShooting = true;
        GunStatusScript.gameObject.GetComponent<HeadbobberGun>().hadisparao = true;
        Instantiate(lel.ballestasonido, transform.position, transform.rotation);

        yield return null;
        FPCStatus.isShooting = false;
    }

    void DisparoBallesta2()
    {
        if (!FPCStatus.accionando && !FPCStatus.isRunning && !FPCStatus.melee && Time.time > TiempoDeDisparo && !FPCStatus.especial || cola)
        {
            cola = false;
            // Sentencias de seguridad.
            if (FPCStatus.isReloading && GunStatusScript.Armasgays != Armasgaystipos.Duales1) { return; }   // No se puiede disprar mientras se recarga.
            if (FPCStatus.transicion && GunStatusScript.Armasgays != Armasgaystipos.Duales1) { return; }
            if (GunStatusScript.recargando) { return; } //AQUÍ PONER METODOGAY NUEVO
            if (GunStatusScript.BalasActualesEnCargador <= 0) { return; }

            StartCoroutine(sexualsex2());
        }
    }
        IEnumerator sexualsex2()
        {

            FPCStatus.isShooting = (GunStatusScript.BalasActualesEnCargador > 0);

            var layerMask = (1 << 0);
            layerMask |= (1 << 2);
            layerMask |= (1 << 4);
            layerMask |= (1 << 13);
            layerMask |= (1 << 14);
            layerMask |= (1 << 17);
            layerMask |= (1 << 22);
            layerMask |= (1 << 23);
            layerMask = ~layerMask;

            if (GunStatusScript.BalasActualesEnCargador > 0)
            {
                PuntoDisparo = transformPuntoDisparo.position;


                desactivarpar(true);
                // Dibuja el destello en el cañon del arma y que suene un disparo.
                //Instantiate(GunStatusScript.Destello, PuntoDisparo, Camera.main.transform.rotation);
                FireSound.PlayOneShot(Sonidos[NumeroArma]);

                Vector3 Bulletdirection = CalcularDireccionBala(Vector3.zero);    // Calculamos la direccion que tendra la bala
                Bulletdirection.z = 1;
                Vector3 direction = Camera.main.transform.TransformDirection(Bulletdirection);


                RaycastHit hit = default(RaycastHit);



                if (Physics.Raycast(Camera.main.transform.position + offset, direction, out hit, Mathf.Infinity, layerMask))
                {
                    //Debug.Log("Nombre  "+hit.transform.name);
                    if (!hit.collider.tag.Contains("Enemy") && !hit.collider.tag.Contains("Player") &&
                        !hit.collider.tag.Contains("Armas") && !hit.collider.gameObject.tag.Contains("EndGame") && !hit.collider.gameObject.tag.Contains("putasangre") && !hit.collider.gameObject.tag.Contains("abujero") && !hit.collider.gameObject.tag.Contains("cabesa") && !hit.collider.gameObject.tag.Contains("cuerpasoenemigo"))
                    {
                        // GameObject mySplashObj = CrearSplashObject(hit);
                        //  if (mySplashObj != null){ ColoreaSplash(hit, mySplashObj); }  lo he desactivao yo xq es una puta mierda
                        CrearDecall(hit);
                    }
                    if (hit.collider.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cuerpasoenemigo"))
                    {
                        Vector3 posa = hit.point;
                        GameObject clone;
                        Crearsangre(hit);
                        GameObject mySplashObj = CrearSplashObject(hit);
                        if (mySplashObj != null) { ColoreaSplash(hit, mySplashObj); }
                        clone = Instantiate(sangre, posa, transform.rotation);
                    }



                    // Aplica damage
                    if (hit.collider.tag.Contains("Blanco") || hit.collider.gameObject.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cristal"))
                    {
                        hit.collider.SendMessage("Posgay", hit.point);
                        hit.collider.SendMessage("Aplicacriticks", nor.listagay[NumeroArma].Critico);
                        hit.collider.SendMessage("AplicaDamage", nor.listagay[NumeroArma].Damage);
                        hit.collider.SendMessage("AplicaStun", nor.listagay[NumeroArma].Stun);
                    }

                }
            }


            TiempoDeDisparo = Time.time + GunStatusScript.RatioDeDisparo;
        hedisparao();
        tiempoballesta = 0;

            // Decremento la municion y la escribo
            if (GunStatusScript.BalasActualesEnCargador > 0)
            {
                GunStatusScript.BalasActualesEnCargador--;
                UIBalas.text = GunStatusScript.CargadoresActuales.ToString() + "/" + GunStatusScript.BalasActualesEnCargador.ToString();
                //GUIBalas.text = GunStatusScript.BalasActualesEnCargador.ToString();
            }

            if (GunStatusScript.Armasgays == Armasgaystipos.Duales2 && GunStatusScript.arma2.BalasActualesEnCargador > 0)
            {
                cola = false;
                StartCoroutine(gameObject.GetComponent<DisparoSecundario>().ActivarDisparo());

            }

        yield return null;
        FPCStatus.isShooting = false;
    }

    void Disparoballestadef()
    {
        if (GunStatusScript.BalasActualesEnCargador > 0)
        {

            var layerMask = (1 << 0);
            layerMask |= (1 << 2);
            layerMask |= (1 << 4);
            layerMask |= (1 << 13);
            layerMask |= (1 << 14);
            layerMask |= (1 << 17);
            layerMask |= (1 << 22);
            layerMask |= (1 << 23);
            layerMask = ~layerMask;

            PuntoDisparo = transformPuntoDisparo.position;


            desactivarpar(true);
            // Dibuja el destello en el cañon del arma y que suene un disparo.
            //Instantiate(GunStatusScript.Destello, PuntoDisparo, Camera.main.transform.rotation);
            FireSound.PlayOneShot(Sonidos[NumeroArma]);

            Vector3 Bulletdirection = CalcularDireccionBala(Vector3.zero);    // Calculamos la direccion que tendra la bala
            Bulletdirection.z = 1;
            Vector3 direction = Camera.main.transform.TransformDirection(Bulletdirection);


            RaycastHit hit = default(RaycastHit);



            if (Physics.Raycast(Camera.main.transform.position + offset, direction, out hit, Mathf.Infinity, layerMask))
            {
                //Debug.Log("Nombre  "+hit.transform.name);
                GameObject balaqlera = Instantiate(Balas[8], hit.point, Quaternion.FromToRotation(Vector3.forward, direction));

                if (!hit.collider.tag.Contains("Enemy") && !hit.collider.tag.Contains("Player") &&
                    !hit.collider.tag.Contains("Armas") && !hit.collider.gameObject.tag.Contains("EndGame") && !hit.collider.gameObject.tag.Contains("putasangre") && !hit.collider.gameObject.tag.Contains("abujero") && !hit.collider.gameObject.tag.Contains("cabesa") && !hit.collider.gameObject.tag.Contains("cuerpasoenemigo"))
                {
                    // GameObject mySplashObj = CrearSplashObject(hit);
                    //  if (mySplashObj != null){ ColoreaSplash(hit, mySplashObj); }  lo he desactivao yo xq es una puta mierda
                    CrearDecall(hit);
                    balaqlera.GetComponent<sonidoballesta>().dalebro(0);
                }
                if (hit.collider.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cuerpasoenemigo"))
                {
                    Vector3 posa = hit.point;
                    GameObject clone;
                    Crearsangre(hit);
                    GameObject mySplashObj = CrearSplashObject(hit);
                    if (mySplashObj != null) { ColoreaSplash(hit, mySplashObj); }
                    clone = Instantiate(sangre, posa, transform.rotation);

                    balaqlera.transform.SetParent(hit.transform);
                    balaqlera.GetComponent<AudioSource>().volume = 1;
                    balaqlera.GetComponent<sonidoballesta>().dalebro(Random.Range(1, 3));
                }



                // Aplica damage
                if (hit.collider.tag.Contains("Blanco") || hit.collider.gameObject.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cristal"))
                {
                    hit.collider.SendMessage("Posgay", hit.point);
                    hit.collider.SendMessage("Aplicacriticks", nor.listagay[NumeroArma].Critico);
                    hit.collider.SendMessage("AplicaDamage", nor.listagay[NumeroArma].Damage);
                    hit.collider.SendMessage("AplicaStun", nor.listagay[NumeroArma].Stun);
                }

               

            }
        }

        ballestabala.SetActive(false);
        TiempoDeDisparo = Time.time + GunStatusScript.RatioDeDisparo;
        hedisparao();

        // Decremento la municion y la escribo
        if (GunStatusScript.BalasActualesEnCargador > 0)
        {
            GunStatusScript.BalasActualesEnCargador--;
            UIBalas.text = GunStatusScript.CargadoresActuales.ToString() + "/" + GunStatusScript.BalasActualesEnCargador.ToString();
            //GUIBalas.text = GunStatusScript.BalasActualesEnCargador.ToString();
        }

        if (GunStatusScript.Armasgays == Armasgaystipos.Duales2 && GunStatusScript.arma2.BalasActualesEnCargador > 0)
        {
            cola = false;
            StartCoroutine(gameObject.GetComponent<DisparoSecundario>().ActivarDisparo());

        }
    }

    void cancelartrans()
    {
        DisparoSecundario penisman = GetComponent<DisparoSecundario>();
        if (penisman.lolsexual != null)
        {
            StopCoroutine(GetComponent<DisparoSecundario>().lolsexual);
        }

        penisman.StopAllCoroutines();
        FireSound.Stop();

        FPCStatus.isReloading = false;
        CancelInvoke("transicionvuelta");
        CancelInvoke("tusputosmuertos");
        GetComponent<ReloadWeapon>().StopAllCoroutines();
        desactivarpar2();

        GunStatusScript.AnimacionesArmagays.transform.SendMessage("Resetear", SendMessageOptions.DontRequireReceiver);
        GunStatusScript.transform.GetComponent<Animator>().enabled = false;
        GunStatusScript.transform.localPosition = Vector3.zero;
        GunStatusScript.transform.localEulerAngles = Vector3.zero;
        
        Debug.Log(GunStatusScript.AnimacionesArmagays.transform.name);

        if (GunStatusScript.arma2 != null)
        {
            GunStatusScript.arma2.transform.GetComponent<Animator>().enabled = false;
            GunStatusScript.arma2.transform.localPosition = Vector3.zero;
            GunStatusScript.arma2.transform.localEulerAngles = Vector3.zero;
        }
    }

    void cancelarecarga()
    {
        if (GetComponent<DisparoSecundario>().lolsexual != null)
        {
            StopCoroutine(GetComponent<DisparoSecundario>().lolsexual);
        }
        FPCStatus.isReloading = false;
        GetComponent<ReloadWeapon>().StopAllCoroutines();
        //GetComponent<ReloadWeapon>().aud.Stop();
        


        Animator penis = GunStatusScript.AnimacionesArmagays.GetComponent<Animator>();

        foreach (var param in penis.parameters)
        {
            if (param.type == AnimatorControllerParameterType.Trigger)
            {
                penis.ResetTrigger(param.name);
            }
        }

        GunStatusScript.AnimacionesArmagays.GetComponent<Animator>().Play("New State");
        GunStatusScript.GetComponent<Animator>().Play("idleshite");
        GunStatusScript.AnimacionesArmagays.GetComponent<Animator>().enabled = false;
        GunStatusScript.AnimacionesArmagays.transform.localPosition = Vector3.zero; 
        GunStatusScript.AnimacionesArmagays.transform.localEulerAngles = Vector3.zero;
        GunStatusScript.AnimacionesArmagays.transform.SendMessage("Resetear", SendMessageOptions.DontRequireReceiver);

        Debug.Log(GunStatusScript.AnimacionesArmagays.transform.gameObject.name); 

        if (GunStatusScript.arma2 != null)
        {
            penis = GunStatusScript.arma2.AnimacionesArmagays.GetComponent<Animator>();
            GunStatusScript.arma2.recargando = false;
            

            foreach (var param in penis.parameters)
            {
                if (param.type == AnimatorControllerParameterType.Trigger)
                {
                    penis.ResetTrigger(param.name);
                }
            }

            GunStatusScript.arma2.AnimacionesArmagays.GetComponent<Animator>().Play("New State");
            GunStatusScript.arma2.GetComponent<Animator>().Play("idleshite");
            GunStatusScript.arma2.AnimacionesArmagays.GetComponent<Animator>().enabled = false;
            GunStatusScript.arma2.AnimacionesArmagays.transform.localPosition = Vector3.zero;
            GunStatusScript.arma2.AnimacionesArmagays.transform.localEulerAngles = Vector3.zero;
        }
    }

}
