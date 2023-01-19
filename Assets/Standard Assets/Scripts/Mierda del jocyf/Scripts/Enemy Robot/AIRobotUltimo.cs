using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

// Sistema de IA basico de un enemigo.
// Usa estados para controlar su comportamiento.
// Usa sistema de waypoints para ir de un sitio a otro a falta de un verdadero sistema de navegacion.


// Queremos estar seguros de que el gameobject tiene un character controller
[RequireComponent(typeof(CharacterController))]
public class AIRobotUltimo : MonoBehaviour
{
    public enum AIState
    {
        Guard = 0,
        Patrol = 1,
        Chase = 2,
        Attach = 3,
        Golpiado = 4,
        Aturdido = 5,
        Melee = 6,
        Decidir = 7
    }

    public AIState state = AIState.Patrol;
    public bool isRobotStatic = false;
    public AudioClip lel;
    public bool melee = false;

    [Header("Velocidad del enemigo")]
    public float speed = 3f;          // Velocidad de movimiento.
    public float walkSpeed = 3f;
    public float jumpSpeed = 4f;      // Velocidad del salto.
    private float origSpeed = 3f;
    public float runSpeed = 6f;       // Velocidad de movimiento.
    public float rotationSpeed = 5f;  // Vel de giro
    public float velocidadbala = 350f;

    [Header("Rangos de accion")]
    public float meleerange = 15f;
    public float shootRange = 15f;     // Rango de disparo (distancia a la que el enemigo disparara)
    public float attackRange = 30f;   // Rango de ataque.
    public float shootAngle = 4f;    // Angulo de disparo (cuanto ha de girar el enemigo para poder disparar).
    public float dashRange = 14;
    public float dashRangeMax = 30f;
    public float dontComeCloserRange = 5f;   // Distancia minima de proximidad a un punto.
    public float dontComeCloserRangeWaypoint = 3f;// Distancia minima de proximidad a un punto.

    [Header("Cosas que he puesto yo pene")]
    public int burstmin = 3;
    public int burstmax = 7;
    public int eldamagetio = 5;
    public float ratiodisparo = 0.1f;
    public List<AnimacionesMelee> AnimsMelee = new List<AnimacionesMelee>();
    public AudioClip[] sonidoataque;
    private GameObject bola1;
    private GameObject bola2;
    public Transform[] manos;
    private Quaternion[] rots;

    [Header("Tiempos de accion")]
    public float delayShootTime = 0.3f;        // Tiempo de retardo para el disparo.
    public float GuardTime = 3;             // Tiempo de espera en un punto. Estando en modo guardia.
    private float GuardTimeCheck;       // Var Interna que controla el ratio del tiempo de modo Guardia.
    public float ChaseTime = 3;            // Tiempo de espera en un punto. Estando en modo guardia.
    private float ChaseTimeCheck;       // Var Interna que controla el ratio del tiempo de modo Guardia.
    public float ComeCloserTime = 2;
    private float ComeCloserTimeCheck;
    public float tiemporeaccsion = 0.1f;
    public float tiemporeaccsiondesprevenio = 0.5f;
    private float tiemporeaccion; //var interna gay
    public float burstespera = 0.5f;
    private int burstdisparos = 0; //var interna gay
    private int burst;
    private float burstesperatio;
    public float tiempogolpeado = 0.5f;
    private float tiempogolpeadowebon;
    private bool elcomienso = true;
    public float tiempoaturdido = 4;
    private float contadoratur;
    private float contadormelee;
    private float saltocheckcooldown;
    private float lanzadorcheck;
    private float puñocheckcooldown;
    public float PuñoTime = 1.5f;

    [Header("Danio por cercania")]
    public int SustractHealth = 1;
    public float timeRateSustraction = 1;
    private float timeRateSustractionCheck;
    public float precision;
    [Header("Referencias necesarias")]
    private Transform target;                // Blanco al que disparara (el FPC)
    private Transform cuerpochigadowey;
    public DirectionalWaypoint activeWaypoint;   // Waypoint activo al que dirigirse en modo Patrulla.
    public Transform FirePos;                // Posicion del punto de disparo
    public Transform FirePos2;                // Posicion del punto de disparo
    public GameObject Bullet;                // Bala a disparar.
    public GameObject Swish;                // Bala a disparar.
    public GameObject meleedamage;
    public GameObject meleearea;
    public GameObject meleecontact;
    public GameObject particulas;
    public AudioClip[] bum;

    private AudioSource FireSound;
    private float nextFire;             // Var. Interna que controla el ratio de disparo-.
    private Vector3 lastVisiblePlayerPosition;  // Ultima posicion del player (para perseguirlo) en modo ataque.
    private bool beingStopped;           // Se ha parado el enemigo (para disparar).
    private bool jump;                  // Var. Interna que controla el la velocidad del salto.
    private float vSpeed;               // Var. Interna que controla el la velocidad del salto.
    private float gravity = 1;
    private CharacterController character;
    private float tiempobusqueda = 0;
    public Transform cojones;
    private Transform cuerpochigadowey2;
    private NavMeshAgent Soyelmovedorgay;
    private bool norotesjoder;
    private AIAnimation Animasion;
    private Animator animador;
    private GameObject yolel;
    private float pollones;
    private float polladas;
    private agarre2 ag;
    private Vector3 pospawn;
    private Vector3 waypos;
    private bool movido = false;
    private bool transicion = false;
    private Vector3 posadonde;
    private ManageEnemyStatus1 vida;
    private string ultimo = "";

    public Transform lanzadoriz;
    public Transform lanzadorde;
    public AudioClip fuegosonido;

    private Coroutine transwapa;

    void Start()
    {
        rots = new Quaternion[manos.Length];

        for (int i = 0; i < manos.Length; i++)
        {
            rots[i] = manos[i].localRotation;
        }

        lanzadorcheck = Time.time + 2;
        vida = GetComponent<ManageEnemyStatus1>();
        pospawn = transform.position;
        waypointsdef();

        ag = gameObject.GetComponent<agarre2>();
        Animasion = GetComponent<AIAnimation>();
        animador = GetComponent<Animator>();

        // BobberGun.RestoreBobbingValues();
        burst = Random.Range(burstmin, burstmax);
        //Busco al putonavemsh
        Soyelmovedorgay = GetComponent<NavMeshAgent>();
        // Buscamos al Player por Tag.
       
        FireSound = GetComponent<AudioSource>();
        character = GetComponent<CharacterController>();
       
        origSpeed = speed;

        if (target == null && GameObject.FindWithTag("Player"))
        {
            target = GameObject.FindWithTag("Player").transform;
        }
        if (cuerpochigadowey == null && GameObject.FindWithTag("estoyaquicerda"))
        {
            cuerpochigadowey = GameObject.FindWithTag("estoyaquicerda").transform;
        }

    }

   
    void Update()
    {

        Soyelmovedorgay.speed = speed;

        if (speed == 0)
        {
            Soyelmovedorgay.enabled = false;
        }
        else
        {
            Soyelmovedorgay.enabled = true;
        }
        if (target == null && GameObject.FindWithTag("Player"))
        {
            target = GameObject.FindWithTag("Player").transform;
        }

        switch (state)
        {
            case AIState.Patrol:
                norotesjoder = true;
                // Accion
               
                if (elcomienso)
                {
                    Animasion.SetSpeed("camina");
                    elcomienso = false;
                }
                if (CanSeeTarget())
                {
                    tiemporeaccion = Time.time + tiemporeaccsiondesprevenio;
                    cambioestado(AIState.Decidir);

                }
                if (Vector3.Distance(transform.position, waypos) < dontComeCloserRangeWaypoint)
                {
                    cambioestado(AIState.Guard);
                    waypos = waypointsdef();
                }

                MoveTowards(waypos);

                break;
        
            case AIState.Guard:
                norotesjoder = true;
                // Action
                if (speed > 0)
                {
                    speed = 0;
                    //   SendMessage("SetSpeed", "parao");
                    //  Animasion.gay = "parao";
                    Animasion.SetSpeed("parao");
                    GuardTimeCheck = Time.time + GuardTime;
                }
                // change Status Condition
                if (Time.time > GuardTimeCheck)
                {
                    cambioestado(AIState.Patrol);
                    speed = origSpeed; 
                    Animasion.SetSpeed("camina");
                }
               
                if (CanSeeTarget())
                {
                    cambioestado(AIState.Decidir);
                }
                break;
          
            case AIState.Attach:
               
         
                
             
                break;
           
            case AIState.Chase:
                norotesjoder = true;
                if (target == null) { cambioestado(AIState.Guard); }

                MoveTowards(target.position);
               
                if (Vector3.Distance(posadonde, transform.position) < dontComeCloserRangeWaypoint) { newpos(); }

                if (Time.time >= ChaseTimeCheck)
                {
                    if (!CanSeeTarget())
                    {
                        //Debug.Log("Back to Patrol.");
                        speed = origSpeed;
                        Animasion.SetSpeed("camina");
                        //SendMessage("SetSpeed", 1f);
                        state = AIState.Patrol;
                        return;
                    }
                    else if (Vector3.Distance(target.position, transform.position) < dashRangeMax)
                    {
                        cambioestado(AIState.Decidir);
                    }
                   
                }
                /*
                if (CanSeeTarget())
                {
                    ChaseTimeCheck = Time.time + ChaseTime;
                }
                */

                float dis = Vector3.Distance(target.position, transform.position);

                if (dis < shootRange)
                {
                    cambioestado(AIState.Attach);
                }

                if (dis < dashRangeMax && dis > dashRange)
                {
                    cambioestado(AIState.Decidir);
                }

                break;

            case AIState.Golpiado:
                if (Time.time > tiempogolpeadowebon)
                {

                    if (gameObject.GetComponent<ManageEnemyStatus1>().health > 0)
                    {
                        Animasion.SetSpeed("apunta");
                        state = AIState.Attach;
                    }
                }

                break;

            case AIState.Aturdido:
                if (Time.time > contadoratur)
                {
                    GetComponent<ManageEnemyStatus1>().Icono.SetActive(false);
                    ag.mareao = false;
                    state = AIState.Decidir;
                }

                break;
           
            case AIState.Melee:
                if (Time.time > contadormelee)
                {
                    Animasion.SetSpeed("apunta");
                    Soyelmovedorgay.enabled = true;
                    state = AIState.Attach;
                }

                break;

            case AIState.Decidir:

                norotesjoder = false;
                if (target == null) { cambioestado(AIState.Guard); return; }
                if (transicion) { return; }

                float disgay = Vector3.Distance(target.position, transform.position);

                speed = runSpeed;
                MoveTowards(target.position);
                Animasion.SetSpeed2("Correrse");

                if (RotateTowardsAngle2(target.position) < shootAngle)
                {
                    if (disgay < meleerange)
                    {
                        cambioestado(AIState.Attach);
                        Animasion.SetSpeed("apunta");
                        Soyelmovedorgay.enabled = true;
                        state = AIState.Attach;
                        return;
                    }

                    if (Time.time > puñocheckcooldown && CanSeeTarget()) {

                        TipoAtaque();

                    }

                    


                    /*
                    else if (disgay > dashRange && disgay < dashRangeMax && Time.time > puñocheckcooldown)
                    {
                        StartCoroutine(ostiasalto());
                        return;
                    }
                    else if (disgay < dashRangeMax && Time.time > lanzadorcheck && CanSeeTarget())
                    {
                        StartCoroutine(lanzamiento());
                        return;
                    }
                    */
                }              

                break;
        }

    }

    void cambioestado(AIState gays)
    {
        if (gays == AIState.Chase)
        {

            nextFire = Time.time + ratiodisparo;
            tiemporeaccion = Time.time + tiemporeaccsiondesprevenio;
            ChaseTimeCheck = Time.time + ChaseTime;
            Animasion.transicionlol("Walk");
            newpos();
            state = AIState.Chase;
            speed = origSpeed;
        }
        
        else if (gays == AIState.Decidir)
        {
            movido = false;
            transicion = false;

            state = AIState.Decidir;
            //Animasion.transicionlol2("Idle", 0.4f);
            Animasion.transicionlol2("Correrse", 0.2f);
            speed = runSpeed;
            //speed = 0;           

            if (transwapa != null) { StopCoroutine(transwapa); }
            transwapa = StartCoroutine(transicionsexual(0, 5, 1));
            StartCoroutine(transicionsexual(0, 5, 2));
            animador.SetLayerWeight(1, 0);
            animador.SetLayerWeight(2, 0);
        }

        else if (gays == AIState.Attach)
        {
            state = AIState.Attach;
            StartCoroutine(ostias());
        }

        else if (gays == AIState.Guard)
        {
            pospawn = transform.position;
            StopAllCoroutines();
            animador.SetLayerWeight(1, 0);
            animador.SetLayerWeight(2, 0);
            state = AIState.Guard;
            speed = 0;
            Animasion.transicionlol2("Idle", 0.4f);
            GuardTimeCheck = Time.time + 2;
            transwapa = StartCoroutine(transicionsexual(0, 5, 1));
        }

        else if (gays == AIState.Patrol)
        {
            animador.SetLayerWeight(1, 0);
            animador.SetLayerWeight(2, 0);
            state = AIState.Patrol;
            speed = origSpeed;
            Animasion.transicionlol2("Walk", 0.4f);
        }

    }

    void TipoAtaque()
    {
        float dis = Vector3.Distance(transform.position, target.position);
        List<string> lista = new List<string>();

        if (dis < shootRange)
        {
            lista.Add("puñosuelo");
            lista.Add("disparos");
            lista.Add("disparomult");
            lista.Add("puñocielo");
            lista.Add("combo");
            lista.Add("combounico");
        }
        
        lista.Remove(ultimo);

        if (lista.Count > 0)
        {
            int elegido = Random.Range(0, lista.Count);
            ultimo = lista[elegido];
            StartCoroutine(lista[elegido]);
        }
    }

    void newpos()
    {
        if (target == null) { cambioestado(AIState.Guard); return; }
        Vector3 relpos = new Vector3(Random.Range(-1, 1.1f), 0, Random.Range(-1, 1.1f));
        relpos = relpos.normalized; relpos *= Random.Range(1, 3f);

        RaycastHit hit;
        var layerMask = (1 << 10);
        layerMask |= (1 << 15);
        if (Physics.Raycast(pospawn, relpos, out hit, relpos.magnitude + 0.5f, layerMask))
        {
            relpos = relpos.normalized;
            relpos *= (hit.distance - 0.5f);
        }

        posadonde = new Vector3(pospawn.x + relpos.x, pospawn.y, pospawn.z + relpos.z);
    }

    IEnumerator ostiasalto()
    {
        if (target == null) { cambioestado(AIState.Guard); yield break; }
        state = AIState.Attach;
        float y = transform.position.y;
        float checktime = Time.time + 0.56f;
        transicion = true;
        speed = 0;
        Animasion.transicionlol2("Ataque Salto", 0.3f);
        FireSound.PlayOneShot(sonidoataque[Random.Range(0, sonidoataque.Length)]);
        while (Time.time < checktime)
        {
            if (target == null) { cambioestado(AIState.Guard); yield break; }
            RotateTowardsAngle(target.position);
            yield return new WaitForEndOfFrame();
        }

        if (target == null) { cambioestado(AIState.Guard); yield break; }
        float rangogay = 5;
        checktime = Time.time + 0.94f;
        Vector3 pos = new Vector3(target.position.x, y, target.position.z) + new Vector3(Random.Range(-rangogay, rangogay), 0, Random.Range(-rangogay, rangogay));
        float speedgay = Vector3.Distance(pos, transform.position);
        GameObject gay = Instantiate(meleecontact, transform.position, transform.rotation);
        gay.SendMessage("elorig", transform);
        gay.GetComponent<DamageBalaEnemiga>().tipo = 3;
        gay.transform.parent = transform;
        CharacterController con = GetComponent<CharacterController>();

        while (Time.time < checktime)
        {
            Vector3 rel = pos - transform.position;
            rel = rel.normalized;

            con.Move(rel * ((speedgay / 0.94f) * Time.deltaTime));
            //transform.position = Vector3.MoveTowards(transform.position, pos, (speedgay / 0.94f) * Time.deltaTime);
            speed = 0;
            yield return new WaitForEndOfFrame();

            Vector3 direction = pos - transform.position;
            direction.y = 0;
            if (direction.magnitude < 0.5f)
            {
                continue;
            }

            // Rotamos hacia el blanco. LO HEPUTODESACTIVADO
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
        //Instanciamos daño de mierda
        Destroy(gay);
        speed = 0;
        GameObject gay2 = Instantiate(meleearea, transform.position, transform.rotation);
        gay2.SendMessage("elorig", transform);
        GameObject pargays = Instantiate(particulas, transform.position + (Vector3.up * 1f), transform.rotation);
        pargays.GetComponent<AudioSource>().volume = pargays.GetComponent<AudioSource>().volume * Controlador.volumenef;
        pargays.GetComponent<AudioSource>().PlayOneShot(bum[Random.Range(0, bum.Length)]);
        gay2.GetComponent<DamageBalaEnemiga>().tipo = 4;
        yield return new WaitForSeconds(0.767f);
        GuardTimeCheck = Time.time + GuardTime;
        saltocheckcooldown = Time.time + 3;
        cambioestado(AIState.Decidir);

    }

    IEnumerator ostias()
    {

        if (target == null) { cambioestado(AIState.Guard); yield break; }
        transicion = true;
        speed = runSpeed;
        Animasion.transicionlol2("Correrse", 0.1f);

        if (Vector3.Distance(target.position, transform.position) > shootRange)
        {

            float timermierda = Time.time + 1.2f;

            while (true)
            {
                if (target == null) { cambioestado(AIState.Guard); yield break; }
                MoveTowards(target.position);
                if (Time.time > timermierda || Vector3.Distance(target.position, transform.position) < shootRange) { break; }
                yield return new WaitForEndOfFrame();
            }
            if (Time.time > timermierda) { 
               
                GuardTimeCheck = Time.time + GuardTime;
                cambioestado(AIState.Decidir); 
                yield break;
            }

        }
        speed = 0;

        //FireSound.PlayOneShot(sonidoataque[Random.Range(0, sonidoataque.Length)]);
        int lol = Random.Range(0, AnimsMelee.Count);
        Animasion.transicionlol2(AnimsMelee[lol].Nombre, 0.3f);
        yield return new WaitForSeconds(AnimsMelee[lol].DelayDamage / AnimsMelee[lol].Speed);
        //Instanciar daño
        GameObject gay = Instantiate(meleedamage, FirePos.position, FirePos.rotation);
        gay.SendMessage("elorig", transform);
        gay.GetComponent<DamageBalaEnemiga>().tipo = 5;
        yield return new WaitForSeconds((AnimsMelee[lol].Length - AnimsMelee[lol].DelayDamage) / AnimsMelee[lol].Speed);

        GuardTimeCheck = Time.time + GuardTime;
        cambioestado(AIState.Decidir);
    }
    
    IEnumerator puñosuelo()
    {
        if (target == null) { cambioestado(AIState.Guard); yield break; }
        state = AIState.Attach;
        speed = 0;
        transicion = true;
        Animasion.transicionlol2("puñosuelo", 0.2f);
        float timertotal = Time.time + 1.68f;

        yield return new WaitForSeconds(1.17f);

        GameObject sex = Instantiate(meleearea, transform.position + (Vector3.up * 0.1f), transform.rotation);
        FireSound.PlayOneShot(sonidoataque[3]);

        yield return new WaitForSeconds(timertotal - Time.time);
        GuardTimeCheck = Time.time + GuardTime;
        puñocheckcooldown = Time.time + PuñoTime;
        cambioestado(AIState.Decidir);

    }

    IEnumerator combounico()
    {
        if (target == null) { cambioestado(AIState.Guard); yield break; }
        state = AIState.Attach;
        speed = runSpeed;
        transicion = true;

        Animasion.transicionlol2("Combos", 0.25f);
        Animasion.transicionlol3("Combos", 0.25f, 1);
        Animasion.transicionlol3("Correrse", 0.25f, 2);

        int[] lol = { 1, 2 };

        if (transwapa != null) { StopCoroutine(transwapa); }
        Coroutine layer1 = StartCoroutine(transicionsexual(1, 5, 1));
        Coroutine layer2 = StartCoroutine(transicionsexual(1, 5, 2));

        float[] timerstotales = new float[] { Time.time + 0.33f, Time.time + 0.83f, Time.time + 1.7f, Time.time + 2f };
        float[] rot = new float[] { -5, -32, 35 };

        float timer1 = Time.time + 0.33f;
        float timer2 = Time.time + 1.15f;

        bool lehedao = false;

        for (int i = 0; i < 4; i++)
        {
            float timer = timerstotales[i];

            if (i >= 2)
            {
                speed = 0;
                if (!lehedao)
                {
                    lehedao = true;
                    if (layer2 != null) { StopCoroutine(layer2); }
                    layer2 = StartCoroutine(transicionsexual(0, 5, 2));
                    float sex = animador.GetCurrentAnimatorStateInfo(1).normalizedTime * 2.1f;
                    //animador.CrossFadeInFixedTime("Combos", 0.25f, 2, sex, 0);
                }
            }

            while (timer > Time.time)
            {
                if (target == null)
                {
                    if (layer1 != null) { StopCoroutine(layer1); }
                    if (layer2 != null) { StopCoroutine(layer2); }
                    cambioestado(AIState.Guard); yield break;
                }

                MoveTowards(target.position);

                yield return null;
            }

            if (i == 3)
            {
                break;
            }

            Disparocombo(rot[i]);
            FireSound.PlayOneShot(sonidoataque[4]);

            break;
        }

        if (layer1 != null) { StopCoroutine(layer1); }
        if (layer2 != null) { StopCoroutine(layer2); }
        GuardTimeCheck = Time.time + GuardTime;
        puñocheckcooldown = Time.time + PuñoTime;
        cambioestado(AIState.Decidir);

    }

    IEnumerator combo()
    {
        if (target == null) { cambioestado(AIState.Guard); yield break; }
        state = AIState.Attach;
        speed = runSpeed;
        transicion = true;

        Animasion.transicionlol2("Combos", 0.25f);
        Animasion.transicionlol3("Combos", 0.25f, 1);
        Animasion.transicionlol3("Correrse", 0.25f, 2);
        
        int[] lol = { 1, 2 };

        if (transwapa != null) { StopCoroutine(transwapa); }
        Coroutine layer1 = StartCoroutine(transicionsexual(1, 5, 1));
        Coroutine layer2 = StartCoroutine(transicionsexual(1, 5, 2));

        float[] timerstotales = new float[] { Time.time + 0.33f, Time.time + 0.83f, Time.time + 1.7f, Time.time + 2f };
        float[] rot = new float[] { -10, -32, 35 };

        float timer1 = Time.time + 0.33f;
        float timer2 = Time.time + 1.15f;

        bool lehedao = false;

        for (int i = 0; i < 4; i++)
        {
            float timer = timerstotales[i];

            if (i >= 2)
            {
                speed = 0;
                if (!lehedao)
                {
                    lehedao = true;
                    if (layer2 != null) { StopCoroutine(layer2); }
                    layer2 = StartCoroutine(transicionsexual(0, 5, 2));
                    float sex = animador.GetCurrentAnimatorStateInfo(1).normalizedTime * 2.1f;
                    //animador.CrossFadeInFixedTime("Combos", 0.25f, 2, sex, 0);
                }
            }

            while (timer > Time.time)
            {
                if (target == null)
                {
                    if (layer1 != null) { StopCoroutine(layer1); }
                    if (layer2 != null) { StopCoroutine(layer2); }
                    cambioestado(AIState.Guard); yield break;
                }

                MoveTowards(target.position);

                yield return null;
            }

            if (i == 3)
            {
                break;
            }

            Disparocombo(rot[i]);
            FireSound.PlayOneShot(sonidoataque[5]);

        }

        if (layer1 != null) { StopCoroutine(layer1); }
        if (layer2 != null) { StopCoroutine(layer2); }
        GuardTimeCheck = Time.time + GuardTime;
        puñocheckcooldown = Time.time + PuñoTime;
        cambioestado(AIState.Decidir);

    }

    void Disparocombo(float offset)
    {
        if (target == null) { return; }

        Vector3 rel = (target.position - (Vector3.up * 1.5f)) - FirePos2.position;
        Quaternion rotation = Quaternion.LookRotation(rel, Vector3.up);

        GameObject bullet = Instantiate(Swish, FirePos2.position, rotation);

        Vector3 wao = bullet.transform.eulerAngles;
        wao.z = offset;
        bullet.transform.eulerAngles = wao;      
    }

    IEnumerator puñocielo()
    {
        if (target == null) { cambioestado(AIState.Guard); yield break; }
        state = AIState.Attach;
        speed = 0;
        transicion = true;
        Animasion.transicionlol2("puñocielo", 0.25f);
        float timertotal = Time.time + 1.68f;

        yield return new WaitForSeconds(1.17f);

        GameObject sex = Instantiate(meleearea, transform.position + (Vector3.up * 9.5f), transform.rotation);
        FireSound.PlayOneShot(sonidoataque[2]);

        yield return new WaitForSeconds(timertotal - Time.time);
        GuardTimeCheck = Time.time + GuardTime;
        puñocheckcooldown = Time.time + PuñoTime;
        cambioestado(AIState.Decidir);

    }

    IEnumerator disparomult()
    {
        if (target == null) { cambioestado(AIState.Guard); yield break; }
        state = AIState.Attach;
        speed = 0;
        transicion = true;
        Animasion.transicionlol2("DisparoQuieto", 0.25f);
        float speedsexual = 1f;
        float timertotal = Time.time + (0.65f / speedsexual);
        float timertotal2 = Time.time + (0.97f / speedsexual);

        float altura = target.position.y - 1;
        while (Time.time < timertotal)
        {
            if (target == null) { cambioestado(AIState.Guard); yield break; }
            mirameostia(target);
            yield return null;
        }

        float offset = -10;
        float sumador = 5;

        for (int i = 0; i < 5; i++)
        {
            Vector3 rel = new Vector3(target.position.x, altura, target.position.z) - FirePos.position;
            FirePos.rotation = Quaternion.LookRotation(rel, Vector3.up);

            Vector3 shit = FirePos.eulerAngles;
            shit.y += offset;
            FirePos.eulerAngles = shit;
            offset += sumador;

            GameObject bala = Instantiate(Bullet, FirePos.position, FirePos.rotation);
            bala.SendMessage("elorig", transform);
            bala.GetComponent<DamageBalaEnemiga>().bala = true;
            bala.SendMessage("vel", velocidadbala);
            Debug.Log(bala.transform.root);
        }

        FireSound.PlayOneShot(sonidoataque[1]);

        while (Time.time < timertotal2)
        {
            if (target == null) { cambioestado(AIState.Guard); yield break; }
            mirameostia(target);
            yield return null;
        }

        GuardTimeCheck = Time.time + GuardTime;
        puñocheckcooldown = Time.time + PuñoTime;
        cambioestado(AIState.Decidir);
    }

    IEnumerator disparos()
    {
        if (target == null) { cambioestado(AIState.Guard); yield break; }
        state = AIState.Attach;
        speed = 0;
        transicion = true;
        bool siu = true;
        float timer = 0;
        float dir = 1;

        if (transwapa != null) { StopCoroutine(transwapa); }
        transwapa = StartCoroutine(transicionsexual(1, 7, 1));

        for (int i = 0; i < 3; i++)
        {
            string cual = "";
            if (siu)
            {
                cual = "CorrerAlante";
                dir = 1;
            }
            else
            {
                cual = "CorrerAtras";
                dir = -1;
            }

            Animasion.transicionlol2(cual, 0.2f);
            Animasion.transicionlol3("Disparo", 0.14f, 1);

            timer = Time.time + 0.7f;
            float timerdisparo = Time.time + 0.25f;
            bool disparao = false;
            siu = !siu;

            if (i == 0) { timerdisparo = 0.5f; }

            while (timer > Time.time)
            {
                if (target == null) { cambioestado(AIState.Guard); yield return null; }

                if (Time.time > timerdisparo && !disparao)
                {
                    disparao = true;
                    Disparo();
                    FireSound.PlayOneShot(sonidoataque[0]);
                }
                mirameostia(target);
                Vector3 dirgay = transform.forward * 15 * dir;
                character.Move(dirgay * Time.deltaTime);

                yield return null;
            }
        }

        GuardTimeCheck = Time.time + GuardTime;
        puñocheckcooldown = Time.time + PuñoTime;
        cambioestado(AIState.Decidir);

    }

    void Disparo()
    {
        Vector3 rel = target.position - FirePos.position;        
        FirePos.rotation = Quaternion.LookRotation(rel, Vector3.up);

        GameObject bala = Instantiate(Bullet, FirePos.position, FirePos.rotation);
        bala.SendMessage("elorig", transform);
        bala.GetComponent<DamageBalaEnemiga>().bala = true;
        bala.SendMessage("vel", velocidadbala);
        Debug.Log(bala.transform.root);
    }

    void mirameostia(Transform target)
    {
        Vector3 rel = target.position - transform.position;
        rel.y = 0;
        Quaternion adonde = Quaternion.FromToRotation(-Vector3.right, rel);
        transform.rotation = Quaternion.Slerp(transform.rotation, adonde, rotationSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);       
    }

    IEnumerator transicionsexual(float des, float vel, int layer)
    {

        while (true)
        {
            animador.SetLayerWeight(layer, Mathf.MoveTowards(animador.GetLayerWeight(layer), des, vel * Time.deltaTime));
            if (animador.GetLayerWeight(layer) == des)
            {
                break;
            }

            yield return null;
        }

        transwapa = null;
        yield break;
    }

    IEnumerator muevo()
    {
        speed = 0;
        transicion = true;
        movido = true;
        float timecheck = Time.time + 1.4f;
        Animasion.transicionlol2("CorremeAtras", 0.2f);

        while (Time.time < timecheck)
        {
            if (target == null) { cambioestado(AIState.Decidir); yield break; }
            MoveTowards2(-transform.forward, walkSpeed);
            yield return new WaitForEndOfFrame();
        }

        Animasion.transicionlol2("Idle", 0.8f);
        transicion = false;

    }

    private void MoveTowardsPutilla(Vector3 position)
    {
        Vector3 direction = position - transform.position;
        direction.y = 0;
        
        Soyelmovedorgay.SetDestination(position);

    }

    private void MoveTowards2(Vector3 position, float speedgay)
    {

        //RotateTowards(position);


        character.Move(position * speedgay * Time.deltaTime);
        // SendMessage("SetSpeed", speed * speedModifier, SendMessageOptions.DontRequireReceiver);
    }

    private float RotateTowardsAngle2(Vector3 pos)
    {
        Vector3 direction = pos - transform.position;
        direction.y = transform.position.y;
        
        float angle = Vector3.Angle(direction, transform.forward);
        return angle;
    }

    private float RotateTowardsAngle(Vector3 pos)
    {
        Vector3 direction = pos - transform.position;
        direction.y = 0;

        if (speed == 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }

        float angle = Vector3.Angle(direction, transform.forward);
        return angle;
    }

    Vector3 waypointsdef()
    {
        Vector2 a = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized;
        a *= Random.Range(14, 24);

        Vector3 newpos = new Vector3(a.x, transform.position.y, a.y);

        var layerMask = (1 << 10);
        layerMask |= (1 << 15);

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, newpos, out hit, a.magnitude, layerMask))
        {
            float d = Vector3.Distance(pospawn, hit.point);
            d -= 1.5f;

            a = a.normalized;
            a *= d;

            newpos = new Vector3(a.x, 0, a.y);
            waypos = transform.position + newpos;
        }
        else
        {
            waypos = transform.position + newpos;
        }
        return waypos;
    }
    
    public void aturdir(float tiempo)
    {
        StopAllCoroutines();
        animador.SetLayerWeight(1, 0);
        animador.SetLayerWeight(2, 0);
        contadoratur = Time.time + tiempo;
        state = AIState.Aturdido;
        Animasion.transicionlol2("Stunneao", 0.2f);
        Soyelmovedorgay.enabled = false;
        ag.mareao = true;
        StartCoroutine(activaricono());
    }

    IEnumerator activaricono()
    {
        yield return null;

        if (GetComponent<ManageEnemyStatus1>().Icono.activeSelf) { yield break; }
        GetComponent<ManageEnemyStatus1>().Icono.SetActive(true);
    }

    public void hasmoridolol()
    {
       // Controlador.enemigosnormales -= 1;
    }
    public void finishgay()
    {
        tiempogolpeadowebon = Time.time + 20;
        state = AIState.Golpiado;
        Animasion.SetSpeed("parao");
    }
    public void ahmanmegolpiaronwey()
    {
        tiempogolpeadowebon = Time.time + tiempogolpeado;
        if (gameObject.GetComponent<ManageEnemyStatus1>().health > 0)
        {
            Animasion.SetSpeed("golpeado");
        }
        state = AIState.Golpiado;
    }
    // Moverse hacia un punto rotando a la vez hacia el blanco.
    private void MoveTowards(Vector3 position)
    {
        
        Vector3 direction = position - transform.position;
        direction.y = 0;
        if (direction.magnitude < 0.5f)
        {
            //  SendMessage("SetSpeed", "parao");
          //  Animasion.gay = "parao";
            Animasion.SetSpeed("parao");
            return;
        }
        // Rotate towards the target
        RotateTowards(position);
        Soyelmovedorgay.SetDestination(position);
        // SendMessage("SetSpeed", speed * speedModifier, SendMessageOptions.DontRequireReceiver);
    }

    // Rotar para encarar un punto (solo la rotacion, sin movimiento).
    private void RotateTowards(Vector3 position)
    {
        Vector3 direction = position - transform.position;
        direction.y = 0;
        if (direction.magnitude < 0.1f)
        {
            return;
        }

        // Rotamos hacia el blanco. LO HEPUTODESACTIVADO
        if (!norotesjoder)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }
    private void RotateTowardsLOL(Vector3 position)
    {
        Vector3 direction = position - transform.position;
        direction.y = 0;
        if (direction.magnitude < 0.1f)
        {
          //  return;
        }

        // Rotamos hacia el blanco. LO HEPUTODESACTIVADO
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    // if collided with some wall or block, jump
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag.Contains("Player") || hit.gameObject.tag.Contains("Armas")) { return; }

        // only check lateral collisions
        if (Mathf.Abs(hit.normal.y) < 0.5f)
        {
            this.jump = true; // jump if collided laterally
        }
    }

    IEnumerator lanzamiento()
    {
        speed = 0;
        state = AIState.Attach;

        float timer = Time.time + Random.Range(0.2f, 1.2f);
        float timer2 = Time.time + 0.2f;
        Vector3 dir = target.position;
        bool lanzaosonido = false;

        Animasion.transicionlol2("Carga", 0.5f);

        bola1 = Instantiate(Bullet, lanzadoriz.position, Quaternion.identity);
        bola2 = Instantiate(Bullet, lanzadorde.position, Quaternion.identity);
        bola1.transform.parent = lanzadoriz;
        bola2.transform.parent = lanzadorde;
        bola1.GetComponent<AudioSource>().enabled = false;
        bola2.GetComponent<AudioSource>().enabled = false;
        StartCoroutine(bola1.GetComponent<DamageBalaEnemiga>().desactivarcol());
        StartCoroutine(bola2.GetComponent<DamageBalaEnemiga>().desactivarcol());
        FireSound.PlayOneShot(fuegosonido, 1);

        while (timer > Time.time)
        {
            if (Time.time > timer2 && !lanzaosonido)
            {
                FireSound.PlayOneShot(sonidoataque[Random.Range(0, sonidoataque.Length)]);
                lanzaosonido = true;
            }
            if (target != null)
            {
                RotateTowardsLOL(target.position);
            }
            
            yield return null;
        }        

        Animasion.transicionlol2("lanz iz", 0.3f);

        timer = Time.time + (Random.Range(0.6f, 1.2f) / 2);
        timer2 = Time.time + (0.28f / 2);

        while (timer2 > Time.time)
        {
            if (target == null) { cambioestado(AIState.Guard); yield return null; }
            dir = target.position;
            RotateTowardsLOL(target.position);
            yield return null;
        }

        //lanzar
        if (target == null) { cambioestado(AIState.Guard); yield return null; }
        //lanzabro(lanzadoriz, dir);
        lanzabro2(lanzadoriz, dir, bola1);

        yield return new WaitWhile(() => timer > Time.time);
        timer = Time.time + (1.05f / 2.5f);
        timer2 = Time.time + (0.28f / 2.5f);
        Animasion.transicionlol2("lanz de", 0.2f);

        while (timer2 > Time.time)
        {
            if (target == null) { cambioestado(AIState.Guard); yield return null; }
            dir = target.position;
            RotateTowardsLOL(target.position);
            yield return null;
        }

        //lanzar
        if (target == null) { cambioestado(AIState.Guard); yield return null; }
        //lanzabro(lanzadorde, dir);
        lanzabro2(lanzadorde, dir, bola2);

        yield return new WaitWhile(() => timer > Time.time);
        lanzadorcheck = Time.time + 2;
        cambioestado(AIState.Decidir);
    }

    void lanzabro(Transform lanzadorgay, Vector3 dir) {

        if (target == null) { return; }

        Vector3 dir2 = (target.position - dir).normalized;
        float vel = ((target.position - dir).magnitude / Time.deltaTime) / 28;
        dir2 *= (Vector3.Distance(target.position, transform.position) * (0.23f * vel));
        if (Random.Range(0, 100) >= 60) { dir2 = Vector3.zero; }

        Vector3 rel = (new Vector3(target.position.x, target.position.y, target.position.z) + dir2) - lanzadorgay.position;
        lanzadorgay.rotation = Quaternion.LookRotation(rel, Vector3.up);

        GameObject CloneFire = Instantiate(Bullet, lanzadorgay.position, Quaternion.identity);
        CloneFire.SendMessage("elorig", transform);
        CloneFire.GetComponent<DamageBalaEnemiga>().bala = true;

        Vector3 Bulletdirection2 = lanzadorgay.TransformDirection(Vector3.forward);


        CloneFire.transform.rotation = Quaternion.LookRotation(rel, Vector3.up);
        //CloneFire.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, velocidadbala), ForceMode.VelocityChange);
        CloneFire.SendMessage("vel", velocidadbala);

        FireSound.PlayOneShot(fuegosonido);
    }

    void lanzabro2(Transform lanzadorgay, Vector3 dir, GameObject bola)
    {

        if (target == null) { return; }

        Vector3 dir2 = (target.position - dir).normalized;
        float vel = ((target.position - dir).magnitude / Time.deltaTime) / 28;
        dir2 *= (Vector3.Distance(target.position, transform.position) * (0.23f * vel));
        if (Random.Range(0, 100) >= 60) { dir2 = Vector3.zero; }

        Vector3 rel = (new Vector3(target.position.x, target.position.y, target.position.z) + dir2) - lanzadorgay.position;
        lanzadorgay.rotation = Quaternion.LookRotation(rel, Vector3.up);

        GameObject CloneFire = bola;
        CloneFire.transform.parent = null;
        CloneFire.GetComponent<AudioSource>().enabled = true;
        CloneFire.SendMessage("elorig", transform);
        CloneFire.GetComponent<DamageBalaEnemiga>().bala = true;

        Vector3 Bulletdirection2 = lanzadorgay.TransformDirection(Vector3.forward);


        CloneFire.transform.rotation = Quaternion.LookRotation(rel, Vector3.up);
        //CloneFire.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, velocidadbala), ForceMode.VelocityChange);
        CloneFire.SendMessage("vel", velocidadbala);

        
    }

    // Funcion de ataque al payer. Se compone de tres fases
    // 1.- Correr hacia el player hasta alcanzar la distancia minima de disparo.
    // 2.- Disparar hasta matarlo o hasta que huye.
    // 3.- Si huye buscarlo otra vez y si no lo encuentra, volver a patrullar.
    IEnumerator AttackPlayer()
    {
        if (CanSeeTarget())
        {
            // El blanco esta muerto, vuelve a patrullar.
            if (target == null)
            {
                //Debug.Log("Player Dead");
                beingStopped = false;
                speed = origSpeed;
                //SendMessage("SetSpeed", this.speed);
                state = AIState.Patrol;
                yield break;
            }
            

            // Calculo la distancia y el angulo en que se encuentra el player.
            float distance = Vector3.Distance(transform.position, target.position);

            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 targetDirection = lastVisiblePlayerPosition - transform.position;
            targetDirection.y = 0;
            float angle = Vector3.Angle(targetDirection, forward);

            lastVisiblePlayerPosition = this.target.position;

            // Si estoy en el angulo y la distancia de disparo
            if (distance < shootRange && angle < shootAngle)
            {
                if (!character.isGrounded)  // Si estoy en el aire, acercate mas al player
                {
                    ComeCloser(target.position);
                }
                else if (!beingStopped && Time.time >= ComeCloserTimeCheck) // Si ya ha pasado el tiempo asignado para acercarse al player, dispara.
                {
                    //Debug.Log("Shoot - TimeCheck :"+ComeCloserTimeCheck+" Time : "+Time.time); // "shoot" Animation is played.
                    StartCoroutine(Shoot());
                }
                else if (beingStopped && distance < dontComeCloserRange) // si me he parado y no puedo hacercarme mas, dispara
                {
                    ComeCloser(target.position);
                    FireEnemy(); // Instantiate the bullet (without animation).
                }
                else if (distance > dontComeCloserRange)      // Si me puedo acercar mas, o me acerco o disparo.
                {
                    //Debug.Log("Come Closer");
                    if (Time.time >= ComeCloserTimeCheck)
                    {
                        //yield return new WaitForSeconds(GetComponent<Animation>()["shoot"].length - delayShootTime);
                        beingStopped = false;
                        speed = runSpeed;
                        ComeCloserTimeCheck = Time.time + ComeCloserTime;
                        ComeCloser(target.position);
                    }
                    else
                    {
                        //Debug.Log("TimeCheck :"+ComeCloserTimeCheck+" Time : "+Time.time);
                        ComeCloser(target.position);
                    }
                }
            }
            else
            {
                 // Persigue al player acercandote a el.
                //Debug.Log("Run After Player");
                beingStopped = false;
                speed = runSpeed;
                ComeCloser(lastVisiblePlayerPosition);
            }
        }
        else
        {
             // Busca al player diriguiendote a su ultima posicion conocida.
            beingStopped = false;
            speed = runSpeed;
            ChaseTimeCheck = Time.time + ChaseTime;
            state = AIState.Chase;
            Animasion.SetSpeed("caminapuntando");
        }

        yield break;
    }


    public void AttackPlayerStatic()
    {
        if (this.CanSeeTarget())
        {
            // El blanco esta muerto, vuelve a patrullar.
            if (target == null)
            {
                //Debug.Log("Player Dead");
                beingStopped = false;
                speed = origSpeed;
               // SendMessage("SetSpeed", this.speed);
                state = AIState.Patrol;
                return;
            }
            if (speed > 0)
            {
                speed = 0;
                // SendMessage("SetSpeed", "parao");
             //   Animasion.gay = "parao";
                Animasion.SetSpeed("parao");
            }

            // Calculo la distancia y el angulo en que se encuentra el player.
            float distance = Vector3.Distance(transform.position, target.position);

            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 targetDirection = lastVisiblePlayerPosition - transform.position;
            targetDirection.y = 0;
            float angle = Vector3.Angle(targetDirection, forward);

            lastVisiblePlayerPosition = this.target.position;

            if (angle >= shootAngle) // Añafido de rotacion en parado.
            {
                RotateTowards(lastVisiblePlayerPosition);
            }

            if (distance < dontComeCloserRange && Time.time >= timeRateSustractionCheck)
            {
                GameMngr.Instance.nSalud = (int)(GameMngr.Instance.nSalud - (SustractHealth * Time.deltaTime));
                timeRateSustractionCheck = Time.time + timeRateSustraction;
            }



            // Si estoy en el angulo y la distancia de disparo
            if (distance < shootRange && angle < shootAngle)
            {
                if (!beingStopped)
                {
                    StartCoroutine(Shoot()); // shoot with animation.
                }
                else
                {
                    FireEnemy(); // Instantiate the bullet (without animation).
                }
            }
        }
        else
        {
            // Busca al player dirigiendose a su ultima posicion conocida.
            tiemporeaccion = Time.time + tiemporeaccsion;
            tiempobusqueda += Time.deltaTime;
            if (tiempobusqueda > GuardTime)
            {
                ChaseTimeCheck = Time.time + ChaseTime;
                beingStopped = false;
                speed = runSpeed;
                state = AIState.Chase;
                Animasion.SetSpeed("caminapuntando");
            }
          }

        return;
    }

    public void AttackPlayer2()
    {
        if (this.CanSeeTarget())
        {
            // El blanco esta muerto, vuelve a patrullar.
            if (target == null)
            {
                //Debug.Log("Player Dead");
                beingStopped = false;
                speed = origSpeed;
                // SendMessage("SetSpeed", this.speed);
                state = AIState.Patrol;
                return;
            }

           

            // Calculo la distancia y el angulo en que se encuentra el player.
            float distance = Vector3.Distance(transform.position, target.position);

            lastVisiblePlayerPosition = target.position;
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 targetDirection = lastVisiblePlayerPosition - transform.position;
            targetDirection.y = 0;
            float angle = Vector3.Angle(targetDirection, forward);

            

            if (angle >= shootAngle) // Añafido de rotacion en parado.
            {
               // RotateTowards(lastVisiblePlayerPosition);
            }


            if (distance < dontComeCloserRange)
            {               
                speed = 0;
                Animasion.SetSpeed("apunta");
                RotateTowardsLOL(target.position);
            }
            else
            {
                speed = runSpeed;
                Animasion.SetSpeed("caminapuntando");
                MoveTowards(target.position);
            }

           

            // Si estoy en el angulo y la distancia de disparo
            if (distance < shootRange && angle < shootAngle)
            {
                if (distance > dontComeCloserRange)
                {
                    FireEnemy(); // Instantiate the bullet (without animation).
                }
                else
                {
                    //PONER ANIMACIONE DE MELLEE BAL ETIUO EKSK ME DA PALKAO+
                    Soyelmovedorgay.enabled = false;
                    contadormelee = Time.time + Animasion.Durum("Pegame");
                    transform.rotation =  Quaternion.LookRotation(targetDirection);
                    transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                    Animasion.SetSpeed("Pegame");
                    state = AIState.Melee;
                }
               
            }
        }
        else
        {
            // Busca al player dirigiendose a su ultima posicion conocida.
            tiemporeaccion = Time.time + tiemporeaccsion;
            tiempobusqueda += Time.deltaTime;
            if (tiempobusqueda > GuardTime)
            {
                ChaseTimeCheck = Time.time + ChaseTime;
                beingStopped = false;
                speed = runSpeed;
                state = AIState.Chase;
                Animasion.SetSpeed("caminapuntando");
            }
        }

        return;
    }

    // Funcion que mira si puedo ver al player.
    private bool CanSeeTarget()
    {
        if (target == null) { return false; }
        RaycastHit hit = default(RaycastHit);
        if (Vector3.Distance(transform.position + (Vector3.up * 2), target.position) > attackRange)
        {
            return false;
        }

        //int layerMask;  ESTO IGNORA PUTOS LAYERS EN LA 399 Y LA 400 YO ESTOY DICIENDO QU EEL LAYER 2 Y 13 SE IGNOREN CRUCK. SI USAS EL LAYERMASK EL 2 DEL IGNORERAYCAST DEJA DE FUNSIONAR ASI QUE EESPECIFICALO TAMBIEN BALE? PÒS ESO
        var layerMask = (1 << 2);
        layerMask |= (1 << 4);
        layerMask |= (1 << 13);
        layerMask |= (1 << 14);
        layerMask |= (1 << 17);
        layerMask |= (1 << 18);
        layerMask |= (1 << 22);
        layerMask |= (1 << 26);
        layerMask = ~layerMask;
        //  layerMask = 1 << 16;
        if (Physics.Linecast(transform.position + (Vector3.up * 2), target.position, out hit, layerMask))
        {
            if (hit.transform.gameObject.layer == 15) { return false; }
            return true;
        }

        return false;
    }
    private bool CanSeeCuerpochingon()
    {
        
        if (cuerpochigadowey2 != null)
        {
            RaycastHit hit = default(RaycastHit);
            if (Vector3.Distance(transform.position, cuerpochigadowey2.position) > attackRange)
            {
                return false;
            }
            var layerMask = (1 << 2);
            layerMask |= (1 << 4);
            layerMask |= (1 << 13);
            layerMask |= (1 << 17);
            layerMask |= (1 << 18);
            layerMask |= (1 << 22);
            layerMask = ~layerMask;
            if (Physics.Linecast(cojones.position, cuerpochigadowey2.position, out hit, layerMask))
            {
                //        Debug.Log("Hit en : "+hit.transform.name);
                return hit.transform == cuerpochigadowey2;
            }
            //Debug.Log("Hit en : " + hit.transform.name);
        }
        
        return false;
    }

    // Funcion que busca al player.
    private void SearchPlayer(Vector3 position)
    {
        float distance = Vector3.Distance(this.transform.position, position);
        if (distance > dontComeCloserRange)
        {
            MoveTowards(position);
        }
        else
        {
            RotateTowards(position);
        }
        if (CanSeeTarget())
        {
            ChaseTimeCheck = Time.time;
        }
    }

    // Funcion que hace que el enemigo se acerque un poco mas al player.
    private void ComeCloser(Vector3 position)
    {
        float distance = Vector3.Distance(transform.position, position);
        if (distance > dontComeCloserRange)
        {
            MoveTowards(position);
        }
        else
        {
            RotateTowards(position);
        }
    }

    // cambia a estado de busqueda del enemigo sabiendo de antemano su posicion aunque no haya atacado nunca.
    // Se usara para attacar al player en caso de recibir un disparo.
    private void StartChaseStatus()
    {
        
        GuardTimeCheck = Time.time;

        if (saltocheckcooldown - Time.time > 0.3f)
        {
            saltocheckcooldown = Time.time + 0.3f;
        }

        if (state == AIState.Patrol || state == AIState.Guard)
        {
            lastVisiblePlayerPosition = this.target.position;
            beingStopped = false;
            speed = this.runSpeed;
            ChaseTimeCheck = Time.time + this.ChaseTime;
            Animasion.SetSpeed("caminapuntando");
            state = AIState.Chase;
        }
    }

    // Dispara una sola vez, haciendo la animacion de disparar.
    IEnumerator Shoot()
    {
        
        speed = 0;
        // SendMessage("SetSpeed", "apunta");
       // Animasion.gay = "apunta";
        Animasion.SetSpeed("apunta");
        beingStopped = true;
        // Start shoot animation
       // GetComponent<Animation>().CrossFade("shoot", this.delayShootTime);

        // Wait until half the animation has played
        yield return new WaitForSeconds(0);
     //   GetComponent<Animation>().Stop();
        FireEnemy();
    }

    // Realiza el disparo en si, instanciando la bala.
    private void FireEnemy()
    {
        if (burstdisparos > burst)
        {
            burstdisparos = 0;
            burst = Random.Range(burstmin, burstmax);
            float burstesperatio2 = Random.Range(0.1f, 0.5f);
            burstesperatio = Time.time + burstespera + burstesperatio2;
        }
        if (Time.time > nextFire && Time.time > tiemporeaccion && Time.time > burstesperatio && !Controlador.mestoylevantandojoder)
        {
            burstdisparos += 1;
            tiempobusqueda = 0;


            Vector3 pos = FirePos.position;
            GameObject CloneFire = Instantiate(Bullet, pos, Quaternion.identity);
            //CloneFire.GetComponent<damagegay>().damagehomogay = eldamagetio;
            //CloneFire.GetComponent<damagegay>().original = transform;

            //  FireSound.Play();
            if (FireSound == null)
            {
                FireSound = GetComponent<AudioSource>();
            }
            FireSound.pitch = 1 + Random.Range(-0.14f, 0.3f);
            FireSound.PlayOneShot(lel, 1f);
            if (cuerpochigadowey != null)
            {
                // cuerpochigadowey = GameObject.FindWithTag("estoyaquicerda").transform;
                FirePos.LookAt(cuerpochigadowey);
            }
            if (cuerpochigadowey == null)
            {
                // cuerpochigadowey = GameObject.FindWithTag("estoyaquicerda").transform;
                FirePos.LookAt(target);
            }


            Vector3 direction2 = CalcularDireccionBala2(Vector3.zero);
            direction2.z = 1;
            Vector3 Bulletdirection2 = FirePos.TransformDirection(direction2);


            CloneFire.transform.rotation = Quaternion.FromToRotation(Vector3.forward, Bulletdirection2);
            CloneFire.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,0, velocidadbala), ForceMode.VelocityChange);
            nextFire = Time.time + ratiodisparo; // RATIO DISPARO COJONES
            

            if (!CanSeeCuerpochingon())
            {
                cuerpochigadowey = GameObject.FindWithTag("Player").transform;
            }
            if (CanSeeCuerpochingon())
            {             
                cuerpochigadowey = GameObject.FindWithTag("micuerpochingon").transform;
            }
           // Debug.Log(cuerpochigadowey.tag);
        }
    }

    public Vector3 SprayDirection(Vector3 direction, float precision)
    {
        float cojones = Random.Range(1, 101);
        if (cojones >= 40) {
              direction.x = direction.x + ((1 - (2 * Random.value)) * precision);
              direction.y = direction.y + ((1 - (2 * Random.value)) * precision);
              direction.z = direction.z + ((1 - (2 * Random.value)) * precision);
          //  direction.x = Mathf.Clamp(direction.x, 0, 10);
           // direction.y = Mathf.Clamp(direction.y, 0, 10);
          //  direction.z = Mathf.Clamp(direction.z, 0, 10);
        }
        return direction;
    }

    private Vector3 CalcularDireccionBala2(Vector3 _direction)
    {
        Vector3 _bulletdirection = _direction;    // Precision de la bala normal.

        // Si estamos apuntando o la precision del arma no es maxima, calcuklamos la nueva precision (normal o apuntando).


        _bulletdirection = SprayDirection(_direction, precision);


        return _bulletdirection;
    }
    public void desactivar()
    {
        Destroy(vida.Icono);
        StopAllCoroutines();
        animador.SetLayerWeight(1, 0);
        animador.SetLayerWeight(2, 0);
        Destroy(this);
    }

    private void LateUpdate()
    {
        for (int i = 0; i < manos.Length; i++)
        {
            manos[i].localRotation = rots[i];
        }
    }
}