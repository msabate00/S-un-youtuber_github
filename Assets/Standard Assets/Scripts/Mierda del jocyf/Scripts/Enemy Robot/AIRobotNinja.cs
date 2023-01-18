using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

// Sistema de IA basico de un enemigo.
// Usa estados para controlar su comportamiento.
// Usa sistema de waypoints para ir de un sitio a otro a falta de un verdadero sistema de navegacion.


// Queremos estar seguros de que el gameobject tiene un character controller
[RequireComponent(typeof(CharacterController))]
public class AIRobotNinja : MonoBehaviour
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
        Block = 7,
        Dash = 8,
        AttackDash = 9,
        Shurikens = 10
    }

    public AIState state = AIState.Patrol;
    public bool isRobotStatic = false;
    public AudioClip lel;
    public bool melee = false;

    [Header("Velocidad del enemigo")]
    public float speed = 3f;          // Velocidad de movimiento.
    public float jumpSpeed = 4f;      // Velocidad del salto.
    private float origSpeed = 3f;
    public float runSpeed = 6f;       // Velocidad de movimiento.
    public float dashSpeed = 30f;
    public float rotationSpeed = 5f;  // Vel de giro
    public float velocidadbala = 350f;
    public float walkspeed = 3f;

    [Header("Rangos de accion")]
    public float shootRange = 15f;     // Rango de disparo (distancia a la que el enemigo disparara)
    public float attackRange = 30f;   // Rango de ataque.
    public float shootAngle = 4f;    // Angulo de disparo (cuanto ha de girar el enemigo para poder disparar).
    public float dontComeCloserRange = 5f;   // Distancia minima de proximidad a un punto.
    public float dontComeCloserRangeWaypoint = 3f;// Distancia minima de proximidad a un punto.

    [Header("Cosas que he puesto yo pene")]
    public int burstmin = 3;
    public int burstmax = 7;
    public int eldamagetio = 5;
    public float randparry = 20;
    public float randdash = 20;
    public float ratiodisparo = 0.1f;
    public bool parrysentido = false;
    public AudioClip[] parrys;
    public bool transicion = false;
    public List<AnimacionesMelee> AnimsMelee = new List<AnimacionesMelee>();
    public AudioClip charge;

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
    private float contadorblock;

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
    public Transform FirePosMelee;
    public GameObject Bullet;                // Bala a disparar.
    public Transform meleedamage;

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
    private float origangularspeed;
    private bool gay = false;
    private bool sijoder = false;
    private bool espera = false;
    private ManageEnemyStatus1 vida;
    private Vector3 posadonde;


    void Start()
    {
        
        pospawn = transform.position;
        waypointsdef();

        ag = gameObject.GetComponent<agarre2>();
        Animasion = GetComponent<AIAnimation>();

        // BobberGun.RestoreBobbingValues();
        burst = Random.Range(burstmin, burstmax);
        //Busco al putonavemsh
        Soyelmovedorgay = GetComponent<NavMeshAgent>();
        origangularspeed = Soyelmovedorgay.angularSpeed;
        // Buscamos al Player por Tag.
        
        FireSound = GetComponent<AudioSource>();
        character = GetComponent<CharacterController>();
        animador = GetComponent<Animator>();
        vida = GetComponent<ManageEnemyStatus1>();

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
        if (animador == null) { animador = GetComponent<Animator>(); }

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
                    Animasion.SetSpeed2("Walk");
                    elcomienso = false;
                }
                if (CanSeeTarget() && Vector3.Distance(target.position, transform.position) < attackRange)
                {
                    cambioestado(AIState.Chase);

                }
                if (Vector3.Distance(transform.position, waypos) < dontComeCloserRangeWaypoint)
                {
                    state = AIState.Guard;
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
                    Animasion.SetSpeed2("Idle");
                    GuardTimeCheck = Time.time + GuardTime;
                }
                // change Status Condition
                if (Time.time > GuardTimeCheck)
                {
                    state = AIState.Patrol;
                    speed = origSpeed; 
                    Animasion.SetSpeed2("Walk");
                }
               
                if (CanSeeTarget())
                {
                    cambioestado(AIState.Chase);
                }
                break;
          
            case AIState.Attach:

                if (transicion) { return; }
                StopCoroutine(AttackNinja());
                StartCoroutine(AttackNinja());
               // return;

               
                
             
                break;
           
            case AIState.Chase:
                norotesjoder = true;
                if (target == null) { return; }
                float posman = Vector3.Distance(transform.position, target.position);

                if (Vector3.Distance(transform.position, posadonde) < dontComeCloserRangeWaypoint) { transicion = false;  state = AIState.Shurikens; }

                Vector3 targetDirection2 = target.position - transform.position;
                targetDirection2.y = 0;
                float angle2 = Vector3.Angle(targetDirection2, transform.forward);
                if (posman < dontComeCloserRange && angle2 < shootAngle)
                {
                    transicion = false;
                    state = AIState.Attach;
                    return;
                }
                
                if (posman < shootRange && Time.time > nextFire)
                {
                    transicion = false;
                    state = AIState.Shurikens;
                    return;
                }
                MoveTowards(posadonde);
                //  SearchPlayer(lastVisiblePlayerPosition);

                // Player not visible anymore - stop attacking
                /*
                StopCoroutine(Caminanigga());
                sijoder = true;
                state = AIState.Dash;

                StartCoroutine(Caminanigga());
                */

                

                if (Time.time >= ChaseTimeCheck)
                {
                    if (!CanSeeTarget())
                    {
                        Debug.Log("TU PUTA MADRE");
                        //Debug.Log("Back to Patrol.");
                        speed = origSpeed;
                        Animasion.SetSpeed2("Walk");
                        //SendMessage("SetSpeed", 1f);
                        state = AIState.Patrol;
                        return;
                    }
                    
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
                    cambioestado(AIState.Chase);
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

            case AIState.Block:

                norotesjoder = false;
                RotateTowards(target.position);

                /*
                 if (contadorblock - Time.time < 1.4f)
                 {
                     GetComponent<Animator>().CrossFadeInFixedTime("parry3", 1.1f, -1, 0, 0);
                 }
                 */

                Vector3 targetDirection = target.position - transform.position;
                targetDirection.y = 0;
                float angle = Vector3.Angle(targetDirection, transform.forward);

                if (Vector3.Distance(target.position, transform.position) < dontComeCloserRange && angle < shootAngle)
                {
                    transicion = false;
                    state = AIState.Attach;
                }

                if (Time.time > contadorblock)
                {
                    //Animasion.SetSpeed("caminapuntando");
                   
                    // GetComponent<Animator>().CrossFadeInFixedTime("caminapuntando", 0.17f, -1, 0, 0);
                    Soyelmovedorgay.enabled = true;
                    cambioestado(AIState.Chase);
                }

                break;

            case AIState.Dash:

                
                if (target == null) { StopAllCoroutines(); cambioestado(AIState.Chase); }
                if (transicion) { parrysgays(gay); }
                

                break;

            case AIState.AttackDash:

                if (transicion) { return; }
                StopCoroutine(AttackNinjaDash());
                StartCoroutine(AttackNinjaDash());
                // return;




                break;

            case AIState.Shurikens:
                
                if (transicion) { return; }
                StopCoroutine(Shurikensgays());
                StartCoroutine(Shurikensgays());


                break;
        }

    }
    Vector3 waypointsdef()
    {
        Vector2 a = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1)).normalized;
        a *= Random.Range(7, 14);

        Vector3 newpos = new Vector3(a.x, pospawn.y, a.y);

        var layerMask = (1 << 10);
        layerMask |= (1 << 15);

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(pospawn, newpos, out hit, a.magnitude, layerMask))
        {
            float d = Vector3.Distance(pospawn, hit.point);
            d -= 1.5f;

            a = a.normalized;
            a *= d;

            newpos = new Vector3(a.x, pospawn.y, a.y);
            waypos = pospawn + newpos;
        }
        else
        {
            waypos = pospawn + newpos;
        }
        return waypos;
    }
    
    void cambioestado(AIState gays)
    {
        if (gays == AIState.Chase) {

            nextFire = Time.time + ratiodisparo;
            animador.SetLayerWeight(1, 0);
            animador.SetLayerWeight(2, 0);
            animador.SetLayerWeight(3, 0);
            tiemporeaccion = Time.time + tiemporeaccsiondesprevenio;
            ChaseTimeCheck = Time.time + ChaseTime;
            newpos();            
            Animasion.transicionlol("Walk");
            state = AIState.Chase;
            speed = origSpeed;
        }
        
    }

    public void aturdir(float tiempo)
    {
        CancelInvoke("regresablock");
        StopAllCoroutines();
        animador.SetLayerWeight(1,0);
        animador.SetLayerWeight(2, 0);
        animador.SetLayerWeight(3, 0);
        contadoratur = Time.time + tiempo;
        state = AIState.Aturdido;
        Animasion.transicionlol("Stunneao");
        Soyelmovedorgay.enabled = false;
        ag.mareao = true;
        if (GetComponent<ManageEnemyStatus1>().Icono.activeSelf) { return; }
        GetComponent<ManageEnemyStatus1>().Icono.SetActive(true);
    }
    
    void regresablock()
    {
        GetComponent<Animator>().CrossFadeInFixedTime("parry3", 1.1f, -1, 0, 0);
    }
    
    public void hasmoridolol()
    {
       // Controlador.enemigosnormales -= 1;
    }
    public void Block()
    {

        if (transicion && state != AIState.Dash) { return; }
        if (state == AIState.Aturdido) { return; }

        if (contadorblock - Time.time > 1.97) { return; }

        if (state == AIState.Dash)
        {
            if (!transicion) { return; }

            if (Random.Range(0, 101) < randparry)
            {
                StopAllCoroutines();
                StartCoroutine(DashniggaALT());
                animador.SetLayerWeight(1, 0);
                animador.SetLayerWeight(2, 0);
                animador.SetLayerWeight(3, 0);

                
            }
            

            // StopCoroutine("putes");
            // StartCoroutine(putes(gay));
            gay = !gay;
            sijoder = false;
            FireSound.pitch = 1;
            FireSound.PlayOneShot(parrys[Random.Range(0, parrys.Length)]);

            return;
        }
        
        if (state == AIState.Chase || state == AIState.Block)
        {
            if (Random.Range(0, 101) < randdash)
            {
                
                if (Vector3.Distance(target.position, transform.position) < shootRange)
                {
                    StopCoroutine(Caminanigga());
                    sijoder = true;
                    state = AIState.Dash;

                    StartCoroutine(Caminanigga());
                }
                else
                {
                    StopCoroutine(AttackNinjaRun());
                    sijoder = true;
                    state = AIState.Dash;

                    StartCoroutine(AttackNinjaRun());
                }


                return;

            }

            
        }

        FireSound.pitch = 1;
        FireSound.volume = 0.6f * Controlador.volumenef;
        FireSound.PlayOneShot(parrys[Random.Range(0,parrys.Length)]);
        contadorblock = Time.time + 2f;
        parrysentido = !parrysentido;

        CancelInvoke("regresablock");
        Invoke("regresablock", 0.6f);

        if (parrysentido)
        {
            GetComponent<Animator>().CrossFadeInFixedTime("parry1", 0.05f, -1, 0, 0);
        }
        else
        {
            GetComponent<Animator>().CrossFadeInFixedTime("parry2", 0.05f, -1, 0, 0);
        }
        

        
        state = AIState.Block;
        Soyelmovedorgay.enabled = false;
        
    }

    void reiniciador()
    {
        StopCoroutine("putes");
        StartCoroutine(putes(gay));
        Debug.Log("FOLLAME JODER PUTA MIERDA");
    }
    
    void parrysgays(bool oh)
    {
        float vel = 14;
        float velregreso = 1;

        if (!sijoder)
        {

            if (oh)
            {

                animador.SetLayerWeight(1, Mathf.MoveTowards(animador.GetLayerWeight(1), 0, vel * Time.deltaTime));
                animador.SetLayerWeight(2, Mathf.MoveTowards(animador.GetLayerWeight(2), 0, vel * Time.deltaTime));
                animador.SetLayerWeight(3, Mathf.MoveTowards(animador.GetLayerWeight(3), 1, vel * Time.deltaTime));

                if (animador.GetLayerWeight(2) == 0 && animador.GetLayerWeight(3) == 1) { sijoder = true; }
            }
            else
            {
                animador.SetLayerWeight(1, Mathf.MoveTowards(animador.GetLayerWeight(1), 0, vel * Time.deltaTime));
                animador.SetLayerWeight(2, Mathf.MoveTowards(animador.GetLayerWeight(2), 1, vel * Time.deltaTime));
                animador.SetLayerWeight(3, Mathf.MoveTowards(animador.GetLayerWeight(3), 0, vel * Time.deltaTime));

                if (animador.GetLayerWeight(2) == 1 && animador.GetLayerWeight(3) == 0) { sijoder = true; }
            }
            return;
        }



            animador.SetLayerWeight(1, Mathf.MoveTowards(animador.GetLayerWeight(1), 1, velregreso * Time.deltaTime));
            animador.SetLayerWeight(2, Mathf.MoveTowards(animador.GetLayerWeight(2), 0, velregreso * Time.deltaTime));
            animador.SetLayerWeight(3, Mathf.MoveTowards(animador.GetLayerWeight(3), 0, velregreso * Time.deltaTime));

    }
    
    IEnumerator putes(bool oh)
    {

        float vel = 14;
        float velregreso = 1;
        float timer = 0;
        
        while (true)
        {

            if (oh)
            {

                animador.SetLayerWeight(1, Mathf.MoveTowards(animador.GetLayerWeight(1), 0, vel * Time.deltaTime));
                animador.SetLayerWeight(2, Mathf.MoveTowards(animador.GetLayerWeight(2), 0, vel * Time.deltaTime));
                animador.SetLayerWeight(3, Mathf.MoveTowards(animador.GetLayerWeight(3), 1, vel * Time.deltaTime));

                if (animador.GetLayerWeight(2) == 0 && animador.GetLayerWeight(3) == 1) { break; }
            }
            else
            {
                animador.SetLayerWeight(1, Mathf.MoveTowards(animador.GetLayerWeight(1), 0, vel * Time.deltaTime));
                animador.SetLayerWeight(2, Mathf.MoveTowards(animador.GetLayerWeight(2), 1, vel * Time.deltaTime));
                animador.SetLayerWeight(3, Mathf.MoveTowards(animador.GetLayerWeight(3), 0, vel * Time.deltaTime));

                if (animador.GetLayerWeight(2) == 1 && animador.GetLayerWeight(3) == 0) { break; }
            }

            timer += Time.deltaTime;
            if (timer > vel) { reiniciador(); }

            Debug.Log("Soy una putilla");
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(0.3f);

        while (true)
        {
            animador.SetLayerWeight(1, Mathf.MoveTowards(animador.GetLayerWeight(1), 1, velregreso * Time.deltaTime));
            animador.SetLayerWeight(2, Mathf.MoveTowards(animador.GetLayerWeight(2), 0, velregreso * Time.deltaTime));
            animador.SetLayerWeight(3, Mathf.MoveTowards(animador.GetLayerWeight(3), 0, velregreso * Time.deltaTime));

            yield return new WaitForEndOfFrame();
        }

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
    

    void newpos()
    {
        if (target == null) { return; }
        Vector3 relpos = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));

        RaycastHit hit;
        var layerMask = (1 << 10);
        layerMask |= (1 << 15);
        if (Physics.Raycast(target.position, relpos, out hit, relpos.magnitude + 0.5f, layerMask))
        {
            relpos = relpos.normalized;
            relpos *= (hit.distance - 0.5f);
        }

        posadonde = new Vector3(target.position.x + relpos.x, transform.position.y, target.position.z + relpos.z);
    }

    IEnumerator Shurikensgays()
    {
        if (!CanSeeTarget())
        {
            cambioestado(AIState.Chase);
            transicion = false;
            yield break;
        }

        vida.parry = false;
        transicion = true;
        speed = 0;

        while (true)
        {
            if (target == null)
            {
                cambioestado(AIState.Chase);
                transicion = false;
                vida.parry = true;
                nextFire = Time.time + ratiodisparo;
                yield break;
            }
            RotateTowardsLOL(target.position);

            Vector3 targetDirection2 = target.position - transform.position;
            targetDirection2.y = 0;
            float angle2 = Vector3.Angle(targetDirection2, transform.forward);

            if (angle2 < shootAngle) { break; }

            yield return new WaitForEndOfFrame();
        }

        Animasion.transicionlol("Shuriken");
        StartCoroutine(rotacionprov());
        yield return new WaitForSeconds(0.13f);
        disparashurs();
        newpos();
        StopCoroutine(rotacionprov());
        yield return new WaitForSeconds(0.350f - 0.13f);

        cambioestado(AIState.Chase);
        transicion = false;
        vida.parry = true;
        nextFire = Time.time + ratiodisparo;
    }

    IEnumerator rotacionprov()
    {
        float oh = Time.time + 0.13f;
        while (oh > Time.time)
        {
            if (target == null) { yield break; }
            Vector3 direction = target.position - transform.position;
            direction.y = 0;

            // Rotamos hacia el blanco. LO HEPUTODESACTIVADO
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            yield return new WaitForEndOfFrame();
        }
        
    }

    void disparashurs()
    {

        if (target == null) { return; }

        Vector3 relativePos = target.position - FirePos.position;

        // the second argument, upwards, defaults to Vector3.up
        FirePos.rotation = Quaternion.LookRotation(relativePos, Vector3.up);

        Vector3 pos = FirePos.position;
        GameObject CloneFire = Instantiate(Bullet, pos, Quaternion.identity);
        CloneFire.SendMessage("elorig", transform);
        CloneFire.GetComponent<DamageBalaEnemiga>().bala = true;
        //CloneFire.GetComponent<damagegay>().damagehomogay = eldamagetio;
        //CloneFire.GetComponent<damagegay>().original = transform;


        FireSound.volume = 0.3f * Controlador.volumenef;
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


        Vector3 Bulletdirection2 = FirePos.TransformDirection(Vector3.forward);


        CloneFire.transform.rotation = Quaternion.FromToRotation(Vector3.forward, Bulletdirection2);
        //CloneFire.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, velocidadbala), ForceMode.VelocityChange);
        CloneFire.SendMessage("vel", velocidadbala);
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
    private void MoveTowards2(Vector3 position, float speedgay)
    {

        //RotateTowards(position);


        character.Move(position * speedgay * Time.deltaTime);
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
    private void RotateTowardsLOLDash(Vector3 position, float speedgay)
    {
        Vector3 direction = position - transform.position;
        direction.y = 0;
        if (direction.magnitude < 0.1f)
        {
            //  return;
        }

        // Rotamos hacia el blanco. LO HEPUTODESACTIVADO
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), speedgay * Time.deltaTime);
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

    IEnumerator AttackNinjaRun()
    {
        CancelInvoke("regresablock");
        transicion = false;
        vida.parry = false;
        Vector3 pos = new Vector3(target.position.x + Random.Range(-20, 20), target.position.y, target.position.z + Random.Range(-20, 20));
        Vector3 relpos = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));

        RaycastHit hit;
        var layerMask = (1 << 10);
        layerMask |= (1 << 15);
        if (Physics.Raycast(target.position, relpos, out hit, relpos.magnitude + 0.5f, layerMask))
        {
            relpos = relpos.normalized;
            relpos *= (hit.distance - 0.5f);
        }

        pos = new Vector3(target.position.x + relpos.x, transform.position.y, target.position.z + relpos.z);
        Animasion.transicionlol("Correrse");
        speed = runSpeed;

        while (true)
        {
            if (Vector3.Distance(transform.position, pos) < 3) { break; }
            if (Vector3.Distance(transform.position, target.position) < 10) { break; }
            MoveTowards(pos);
            yield return new WaitForEndOfFrame();
        }

        float timergay = Time.time + 2.3f;
        Animasion.transicionlol("CargaDash");
        FireSound.PlayOneShot(charge);
        while (true)
        {
            Vector3 direction = target.position - transform.position;
            direction.y = 0;

            // Rotamos hacia el blanco. LO HEPUTODESACTIVADO
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 40 * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            Vector3 semen = new Vector3(target.position.x, transform.position.y, target.position.z);
            semen = semen - transform.position;

            if (Vector3.Angle(semen, transform.forward) < shootAngle) { break; }

            yield return new WaitForEndOfFrame();
        }

       
        while (true)
        {
            MoveTowards2(transform.forward, dashSpeed);
            RotateTowardsLOLDash(target.position, 75);

            Vector3 gay = new Vector3(target.position.x, transform.position.y, target.position.z);
            if (Vector3.Distance(transform.position, gay) < 5) { break; }
            if (Time.time > timergay) { break; }

            yield return new WaitForEndOfFrame();
        }

        state = AIState.AttackDash;
    
    }
    


    
    IEnumerator AttackNinja()
    {
        vida.parry = false;
        transicion = true;
        speed = 0;
        int lol = Random.Range(0, AnimsMelee.Count);
        SendMessage("transicionlol", AnimsMelee[lol].Nombre);
        yield return new WaitForSeconds(AnimsMelee[lol].DelayDamage / AnimsMelee[lol].Speed);
        //Instanciar daño
        Transform penis = Instantiate(meleedamage, FirePosMelee.position, FirePosMelee.rotation);
        penis.SendMessage("elorig", transform);
        yield return new WaitForSeconds((AnimsMelee[lol].Length - AnimsMelee[lol].DelayDamage) / AnimsMelee[lol].Speed);
        transicion = false;
        vida.parry = true;
        cambioestado(AIState.Chase);

    }

    IEnumerator AttackNinjaDash()
    {
        vida.parry = false;
        transicion = true;
        speed = 0;
        SendMessage("transicionlol", "AtaqueDash");
        yield return new WaitForSeconds(0.06f);
        //Instanciar daño
        Transform penis = Instantiate(meleedamage, FirePosMelee.position, FirePosMelee.rotation);
        penis.SendMessage("elorig", transform);
        yield return new WaitForSeconds(0.517f - 0.06f);
        transicion = false;
        cambioestado(AIState.Chase);
        vida.parry = true;

    }

    IEnumerator Caminanigga()
    {
        if (target == null) { cambioestado(AIState.Chase); yield break; }
        CancelInvoke("regresablock");
        espera = false;
        vida.parry = true;
        float tiempomax = Time.time + (4 + Random.Range(-0.5f, 0.6f));
        //tiempomax = Time.time + 40;
        speed = 0;
        Animasion.transicionlol("Andar derecha");
        speed = walkspeed;
        transicion = true;

        while (Time.time < tiempomax)
        {
            if (target == null) { cambioestado(AIState.Chase);  yield break; }
            RotateTowardsLOL(target.position);
            MoveTowards2(transform.right, speed);

            if (Vector3.Distance(target.position, transform.position) < dontComeCloserRange)
            {
                transicion = false;
                state = AIState.Attach;
                animador.SetLayerWeight(1, 0);
                animador.SetLayerWeight(2, 0);
                animador.SetLayerWeight(3, 0);
                yield break;
            }

            yield return new WaitForEndOfFrame();
        }
        
        transicion = false;
        speed = 0;

        vida.parry = false;

        espera = true;
        Animasion.transicionlol("CargaDash");

        FireSound.PlayOneShot(charge);

        animador.SetLayerWeight(1, 0);
        animador.SetLayerWeight(2, 0);
        animador.SetLayerWeight(3, 0);

        float soyzorrita = Time.time + 1.3f;
        while (Time.time < soyzorrita)
        {
            if (target == null) { cambioestado(AIState.Chase); yield break; }
            RotateTowardsLOL(target.position);

            yield return new WaitForEndOfFrame();
        }

        espera = false;
        StartCoroutine(Dashnigga());


    }

    IEnumerator Dashnigga()
    {
        float timergay = Time.time + 1.5f;
        while (true)
        {
            if (target == null) { cambioestado(AIState.Chase); yield break; }
            MoveTowards2(transform.forward, dashSpeed);
            RotateTowardsLOLDash(target.position, 75);

            Vector3 gay = new Vector3(target.position.x, transform.position.y, target.position.z);
            if (Vector3.Distance(transform.position, gay) < 5) { break; }
            if (Time.time > timergay) { break; }

            yield return new WaitForEndOfFrame();
        }

        state = AIState.AttackDash;
    }

    void desmierdas()
    {
        vida.parry = false;
    }
    
    IEnumerator DashniggaALT()
    {
        Invoke("desmierdas", 0.01f);
        if (target == null) { cambioestado(AIState.Chase); yield break; }
        transicion = false;
        bool chupapijas = false;
        if (Vector3.Distance(target.position, transform.position) < 25)
        {
            chupapijas = true;
        }
        else
        {
            chupapijas = false;
        }
        

        if (chupapijas)
        {
            float timergay = Time.time + 2.3f;

            float dashspeed2 = dashSpeed * 0.4f;

            while (true)
            {
                if (target == null) { cambioestado(AIState.Chase); yield break; }
                MoveTowards2(transform.forward, dashspeed2);
                RotateTowardsLOLDash(target.position, 75);

                Vector3 gay = new Vector3(target.position.x, transform.position.y, target.position.z);
                if (Vector3.Distance(transform.position, gay) < 5) { break; }
                if (Time.time > timergay) { break; }

                yield return new WaitForEndOfFrame();
            }

            state = AIState.AttackDash;
        }
        else
        {
            Vector3 pos = new Vector3(target.position.x + Random.Range(-20, 20), target.position.y, target.position.z + Random.Range(-20, 20));
            Vector3 relpos = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));

            RaycastHit hit;
            var layerMask = (1 << 10);
            layerMask |= (1 << 15);
            if (Physics.Raycast(target.position, relpos, out hit, relpos.magnitude + 0.5f, layerMask))
            {
                relpos = relpos.normalized;
                relpos *= (hit.distance - 0.5f);
            }
            
            pos = new Vector3(target.position.x + relpos.x, transform.position.y, target.position.z + relpos.z);
            Animasion.transicionlol("Correrse");
           
            while (true)
            {
                if (target == null) { cambioestado(AIState.Chase); yield break; }
                if (Vector3.Distance(transform.position, pos) < 3) { break; }
                if (Vector3.Distance(transform.position, target.position) < 10) { break; }
                MoveTowards(pos);
                speed = runSpeed;
                yield return new WaitForEndOfFrame();
            }

            float timergay = Time.time + 2.3f;
            Animasion.transicionlol("CargaDash");
            FireSound.PlayOneShot(charge);
            while (true)
            {
                if (target == null) { cambioestado(AIState.Chase); yield break; }
                Vector3 direction = target.position - transform.position;
                direction.y = 0;

                // Rotamos hacia el blanco. LO HEPUTODESACTIVADO
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 40 * Time.deltaTime);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

                Vector3 semen = new Vector3(target.position.x, transform.position.y, target.position.z);
                semen = semen - transform.position;

                if (Vector3.Angle(semen, transform.forward) < shootAngle) { break; } 

                yield return new WaitForEndOfFrame();
            }
            
            while (true)
            {
                if (target == null) { cambioestado(AIState.Chase); yield break; }
                MoveTowards2(transform.forward, dashSpeed);
                RotateTowardsLOLDash(target.position, 75);

                Vector3 gay = new Vector3(target.position.x, transform.position.y, target.position.z);
                if (Vector3.Distance(transform.position, gay) < 5) { break; }
                if (Time.time > timergay) { break; }

                yield return new WaitForEndOfFrame();
            }

            state = AIState.AttackDash;

        }
        
        
        
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
            MoveTowards(position);
        }
        else
        {
            RotateTowardsLOL(position);

            Vector3 targetDirection = position - transform.position;
            targetDirection.y = 0;
            float angle = Vector3.Angle(targetDirection, transform.forward);

            if (angle < shootAngle)
            {
                transicion = false;
                state = AIState.Attach;           
            }
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
        if (state == AIState.Guard || state == AIState.Patrol)
        {
            lastVisiblePlayerPosition = this.target.position;
            beingStopped = false;
            speed = this.runSpeed;
            cambioestado(AIState.Chase);
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
            //CloneFire.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,0, velocidadbala), ForceMode.VelocityChange);
            CloneFire.SendMessage("vel", velocidadbala);
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
        animador.SetLayerWeight(3, 0);
        Destroy(this);
    }
}