using UnityEngine;
using System.Collections;
using UnityEngine.AI;

// Sistema de IA basico de un enemigo.
// Usa estados para controlar su comportamiento.
// Usa sistema de waypoints para ir de un sitio a otro a falta de un verdadero sistema de navegacion.


// Queremos estar seguros de que el gameobject tiene un character controller
[RequireComponent(typeof(CharacterController))]
public class AIRobotRusher : MonoBehaviour
{
    public AIState state = AIState.Patrol;
    public bool isRobotStatic = false;
    public GameObject yo;
    public AudioClip lel;

    [Header("Velocidad del enemigo")]
    public float speed = 3f;          // Velocidad de movimiento.
    public float jumpSpeed = 4f;      // Velocidad del salto.
    private float origSpeed = 3f;
    public float runSpeed = 6f;       // Velocidad de movimiento.
    public float rotationSpeed = 5f;  // Vel de giro
    public float velocidadbala = 350f;
    public float acercarsespeed = 2f;

    [Header("Rangos de accion")]
    public float shootRange = 15f;     // Rango de disparo (distancia a la que el enemigo disparara)
    public float attackRange = 30f;   // Rango de ataque.
    public float shootAngle = 4f;    // Angulo de disparo (cuanto ha de girar el enemigo para poder disparar).
    public float dontComeCloserRange = 5f;
    public float ComeCloserRange = 9f;
    public float dontComeCloserRangeWaypoint = 3f;// Distancia minima de proximidad a un punto.

    [Header("Cosas que he puesto yo pene")]
    public int burstmin = 3;
    public int burstmax = 7;
    public int waypointstotales = 3;
    public int eldamagetio = 5;

    [Header("Tiempos de accion")]
    public float RatioDisparo = 0.1f;
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
    public GameObject Bullet;                // Bala a disparar.

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
    private int waypointstotalesgays = 0;
    private bool elcomienso = true;
    private int penepolla = 0;
    private Vector3 miscojones;
    private bool maserco = false;
    private Animator Animasionchingona;
    private GameObject yolel;
    private float pollones;
    private float polladas;

    public enum AIState
    {
        Guard = 0,
        Patrol = 1,
        Chase = 2,
        Attach = 3,
        Golpiado = 4
    }
    public void waypoint(DirectionalWaypoint lol)
    {
        activeWaypoint = lol;
    }
    void Start()
    {
      //  Controlador.enemigostochos += 1;
        Animasionchingona = gameObject.GetComponent<Animator>();
        miscojones = transform.position;
        Animasion = yo.GetComponent<AIAnimation>();
        
       // BobberGun.RestoreBobbingValues();
        burst = Random.Range(burstmin, burstmax);
        //Busco al putonavemsh
        Soyelmovedorgay = GetComponent<NavMeshAgent>();
        
        // Buscamos al Player por Tag.
        if (target == null && GameObject.FindWithTag("Player"))
        {
            target = GameObject.FindWithTag("Player").transform;
        }
        if (cuerpochigadowey == null)
        {
            cuerpochigadowey = GameObject.FindWithTag("estoyaquicerda").transform;
        }
        FireSound = GetComponent<AudioSource>();
        character = GetComponent<CharacterController>();
        
        // Comprobamos que tengamos waypoint para patrullar (minimo 2)
        if (!activeWaypoint)
        {
            Debug.Log("You need to add any number of waypoint - 2 minimun");
            return;
        }
        // Comprobamos que tengamos un blanco al que buscar y disparar (el FPC).
        if (!target)
        {
            Debug.Log("There is no entity tagged 'Player' in the scene, shoud be your character");
            return;
        }
        origSpeed = speed;
    }

    //=================================
    //
    // Control de los estados de la IA.
    //
    //=================================
    void Update()
    {

        polladas = 1;
        pollones = Random.Range(-0.14f, 0.3f);
        polladas += pollones;
        gameObject.GetComponent<AudioSource>().pitch = polladas;

        if (yolel == null)
        {
            yolel = gameObject.GetComponent<ManageEnemyStatus>().spawnergay;
        }

        Soyelmovedorgay.speed = speed;
        if (speed == 0)
        {
            Soyelmovedorgay.enabled = false;
        }
        else
        {
            Soyelmovedorgay.enabled = true;
        }
       // FirePos.LookAt(target);
        if (target == null)
        {
            target = GameObject.FindWithTag("Player").transform;
        }
        
        switch (state)
        {
            case AIState.Patrol:
                norotesjoder = true;
                // Accion
                // MoveTowards(activeWaypoint.transform.position); LOHETOCAO
                if (elcomienso)
                {
                    Animasion.SetSpeed("camina");
                    elcomienso = false;
                }
                MoveTowards(activeWaypoint.transform.position);
                // Comprobar condiciones para cambio de estado.                
                activeWaypoint = activeWaypoint.CalculateDisponiblepollas(transform.position, dontComeCloserRangeWaypoint);

                if (activeWaypoint.CalculateDistance(transform.position) < dontComeCloserRangeWaypoint)
                {
                    state = AIState.Guard;
                }
                if (yolel.GetComponent<Spawner>().aporesecerdofascista == true)
                {
                    ChaseTimeCheck = Time.time + ChaseTime;
                    Animasion.SetSpeed("caminapuntando");
                    speed = runSpeed;
                    state = AIState.Chase;
                }
                if (CanSeeTarget())
                {
                    Animasion.SetSpeed("caminapuntando");
                    speed = acercarsespeed;
                    tiemporeaccion = Time.time + tiemporeaccsiondesprevenio;
                    state = AIState.Attach;

                }
                break;
            case AIState.Guard:
                norotesjoder = true;
                // Action
                activeWaypoint = activeWaypoint.CalculateTargetPosition(transform.position, dontComeCloserRangeWaypoint);
                if (speed > 0)
                {
                    speed = 0;
                    //   SendMessage("SetSpeed", "parao");
                  //  Animasion.gay = "parao";
                    Animasion.SetSpeed("parao");
                    GuardTimeCheck = Time.time + this.GuardTime;
                }
                // change Status Condition
                if (Time.time > this.GuardTimeCheck)
                {
                   // state = AIState.Patrol;
                  //  speed = origSpeed;
                    // SendMessage("SetSpeed", "camina");
                   // Animasion.gay = "camina";
                   // Animasion.SetSpeed("camina");
                   
                }
                if (yolel.GetComponent<Spawner>().aporesecerdofascista == true)
                {
                    ChaseTimeCheck = Time.time + ChaseTime;
                    Animasion.SetSpeed("caminapuntando");
                    speed = runSpeed;
                    state = AIState.Chase;
                }
                if (CanSeeTarget())
                {
                    tiemporeaccion = Time.time + tiemporeaccsiondesprevenio;
                    state = AIState.Attach;
                }
                break;
            case AIState.Chase:
                norotesjoder = true;

                if (yolel.GetComponent<Spawner>().aporesecerdofascista == true)
                {
                    SearchPlayer(target.position);
                }
                if (yolel.GetComponent<Spawner>().aporesecerdofascista == false)
                {
                    SearchPlayer(lastVisiblePlayerPosition);
                }
                

                // Player not visible anymore - stop attacking

                if (Time.time >= ChaseTimeCheck)
                {
                    if (!CanSeeTarget())
                    {
                        Debug.Log("TU PUTA MADRE");
                        //Debug.Log("Back to Patrol.");
                        speed = origSpeed;
                        Animasion.SetSpeed("camina");
                        //SendMessage("SetSpeed", 1f);
                        state = AIState.Patrol;
                        return;
                    }
                    else
                    {
                        //Debug.Log("Back to Attack.");
                        state = AIState.Attach;
                    }
                }
                break;
            case AIState.Attach:
                norotesjoder = false;
                if (isRobotStatic)
                    AttackPlayerStatic();
                else
                    StartCoroutine(AttackPlayer());
                break;
            case AIState.Golpiado:
                if (Time.time > tiempogolpeadowebon)
                {
                    if (gameObject.GetComponent<ManageEnemyStatus>().health > 0)
                    {
                        Animasion.SetSpeed("apunta");
                        state = AIState.Attach;
                    }
                    }

                break;
        }

        if (cuerpochigadowey2 == null)
        {
            cuerpochigadowey2 = GameObject.FindWithTag("micuerpochingon").transform;
        }

    }

    public void finishgay()
    {
        tiempogolpeadowebon = Time.time + 20;
        state = AIState.Golpiado;
        Animasion.SetSpeed("parao");        
    }
    public void hasmoridolol()
    {
     //   Controlador.enemigostochos -= 1;
    }
    public void ahmanmegolpiaronwey()
    {
        Debug.Log("HOLA RUYBIOS SUOY TU FAN PORFAVBOR SALUDAME");
        tiempogolpeadowebon = Time.time + tiempogolpeado;
        if (gameObject.GetComponent<ManageEnemyStatus>().health > 0)
        {
            Animasion.SetSpeed("golpeado");
        }
        state = AIState.Golpiado;
    }
    // Moverse hacia un punto rotando a la vez hacia el blanco.
    public void SumadorRetraso(int veces)
    {
        waypointstotalesgays += veces;
    }
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

        // Modify speed so we slow down when we are not facing the target
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float speedModifier = Vector3.Dot(forward, direction.normalized);
        speedModifier = Mathf.Clamp01(speedModifier);

       

        // Move the character
        // direction = forward * speed * speedModifier;
        // direction.y += vSpeed;
        //character.Move(direction * Time.deltaTime);
        
        Soyelmovedorgay.SetDestination(position);
        if (penepolla < 5)
        {
            Soyelmovedorgay.Warp(miscojones);
            penepolla += 1;
        }
        // SendMessage("SetSpeed", speed * speedModifier, SendMessageOptions.DontRequireReceiver);
    }

    // Rotar para encarar un punto (solo la rotacion, sin movimiento).
    private void RotateTowards(Vector3 position)
    {
        Vector3 direction = position - this.transform.position;
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

            if (distance < dontComeCloserRange && Time.time >= timeRateSustractionCheck)
            {
                GameMngr.Instance.nSalud = (int) (GameMngr.Instance.nSalud - (SustractHealth * Time.deltaTime));
                timeRateSustractionCheck = Time.time + timeRateSustraction;
            }

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
           

            // Calculo la distancia y el angulo en que se encuentra el player.
            float distance = Vector3.Distance(transform.position, target.position);

            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 targetDirection = lastVisiblePlayerPosition - transform.position;
            targetDirection.y = 0;
            float angle = Vector3.Angle(targetDirection, forward);

            lastVisiblePlayerPosition = this.target.position;

       //     Debug.Log(distance);
   //         Debug.Log(maserco);
            if (distance > ComeCloserRange)
            {

                maserco = true;
                
            }
           
           else if (distance < dontComeCloserRange)
            {
                maserco = false;
               
                if (speed != 0 || !Animasionchingona.GetCurrentAnimatorStateInfo(0).IsName("apuntando"))
                {
                    speed = 0;
                    Animasion.SetSpeed("apunta");
                }
                
                // SendMessage("SetSpeed", "parao");
                //   Animasion.gay = "parao";
            }
            if (maserco)
            {
//                Debug.Log("AHAHAHHA BAMOS A MORIR TOODOODODOS");
                ComeCloser(target.position);
                // SendMessage("SetSpeed", "parao");
                //   Animasion.gay = "parao";
                
                if (speed != acercarsespeed || !Animasionchingona.GetCurrentAnimatorStateInfo(0).IsName("acercarse"))
                {
                    Animasion.SetSpeed("caminapuntando");
                    speed = acercarsespeed;
                }
            }

            if (angle >= shootAngle && distance < shootRange) // Añadido de rotacion en parado.
            {
                RotateTowards(target.position);
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
                speed = origSpeed;
                state = AIState.Chase;
                Animasion.SetSpeed("caminapuntando");
            }
          }

        return;
    }


    // Funcion que mira si puedo ver al player.
    private bool CanSeeTarget()
    {
        RaycastHit hit = default(RaycastHit);
        if (Vector3.Distance(transform.position, target.position) > attackRange)
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
        layerMask = ~layerMask;
        //  layerMask = 1 << 16;
        if (Physics.Linecast(cojones.position, target.position, out hit, layerMask))
        {
            Debug.DrawRay(cojones.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
    //        Debug.Log("Hit en : "+hit.transform.name);
            return hit.transform == target;
        }
        Debug.Log("Hit en : " + hit.transform.name);
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
        if (state != AIState.Attach && state != AIState.Chase) {
            yolel.GetComponent<Spawner>().aporesecerdofascista = true;
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
        
       // speed = 0;
        // SendMessage("SetSpeed", "apunta");
       // Animasion.gay = "apunta";
       // Animasion.SetSpeed("apunta");
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
            Vector3 direction = FirePos.TransformDirection(Vector3.forward);
            Vector3 Bulletdirection = CalcularDireccionBala(direction);    // Calculamos la direccion que tendra la bala
            int layerMask = 1 << 2;
            layerMask = ~layerMask;
            RaycastHit hit = default(RaycastHit);
            direction.z += 0.1f;



          
            if (Physics.Raycast(FirePos.position + direction, Bulletdirection, out hit, 1000))
            {
                Debug.DrawRay(FirePos.position + direction, Bulletdirection, Color.blue);
               // Debug.Log("Hit en : " + hit.transform.name);
                if (hit.collider.tag.Contains("Player"))
                {
                //    Debug.Log("AY TE DI PUTA ZORRA");

                }



                }

            Vector3 pos = FirePos.position;
            GameObject CloneFire = Instantiate(Bullet, pos, Quaternion.identity);
            CloneFire.GetComponent<damagegay>().damagehomogay = eldamagetio;
            CloneFire.GetComponent<damagegay>().original = transform;
            if (FireSound == null)
            {
                FireSound = GetComponent<AudioSource>();
            }
            //  FireSound.Play();

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


            ArmasEstado aiScript = CloneFire.GetComponent<ArmasEstado>();
            Vector3 direction2 = FirePos.TransformDirection(Vector3.forward);
            Vector3 Bulletdirection2 = CalcularDireccionBala2(direction2);    // Calculamos la direccion que tendra la bala

            /**/
            RaycastHit hat = default(RaycastHit);
            if (Physics.Raycast(FirePos.position, Bulletdirection2, out hat, 1000, layerMask))
            {
                direction2 = transform.position - hat.point;
               // Bulletdirection2.z = Bulletdirection2.z + velocidadbala;
                CloneFire.transform.LookAt(hat.point);
            //    CloneFire.GetComponent<Rigidbody>().AddRelativeForce(Bulletdirection2, ForceMode.VelocityChange);
            }
            else
            {
                direction2 = transform.TransformDirection(Vector3.forward);
                Bulletdirection2 = SprayDirection(direction2, aiScript.Precision);
              //  Bulletdirection2.z = Bulletdirection2.z + aiScript.Aceleracion;
              //  CloneFire.GetComponent<Rigidbody>().AddRelativeForce(Bulletdirection2, ForceMode.VelocityChange);
            }




            Vector3 direccion = CloneFire.transform.TransformDirection(Vector3.forward);
            //Vector3 direccion = CloneFire.transform.forward;
            Rigidbody CloneRb = CloneFire.GetComponent<Rigidbody>();

            //CloneRb.velocity = Vector3.zero;
            //CloneRb.angularVelocity = Vector3.zero;
           
            //CloneRb.AddForce(direccion * aiScript.Aceleracion, ForceMode.VelocityChange);
            CloneRb.AddRelativeForce(Vector3.forward * velocidadbala, ForceMode.VelocityChange);
            nextFire = Time.time + RatioDisparo; // RATIO DISPARO COJONES
            

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
    private Vector3 CalcularDireccionBala(Vector3 _direction)
    {
        Vector3 _bulletdirection = _direction;    // Precision de la bala normal.

        // Si estamos apuntando o la precision del arma no es maxima, calcuklamos la nueva precision (normal o apuntando).
        
            
            _bulletdirection = SprayDirection(_direction, precision);
        

        return _bulletdirection;
    }
    private Vector3 CalcularDireccionBala2(Vector3 _direction)
    {
        Vector3 _bulletdirection = _direction;    // Precision de la bala normal.

        // Si estamos apuntando o la precision del arma no es maxima, calcuklamos la nueva precision (normal o apuntando).


        _bulletdirection = SprayDirection(_direction, precision);


        return _bulletdirection;
    }
}