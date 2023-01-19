using UnityEngine;
using System.Collections;
using UnityEngine.AI;

// Sistema de IA basico de un enemigo.
// Usa estados para controlar su comportamiento.
// Usa sistema de waypoints para ir de un sitio a otro a falta de un verdadero sistema de navegacion.


// Queremos estar seguros de que el gameobject tiene un character controller
[RequireComponent(typeof(CharacterController))]
public class AIRobot2 : MonoBehaviour
{
    public enum AIState
    {
        Guard = 0,
        Patrol = 1,
        Chase = 2,
        Attach = 3,
        Golpiado = 4,
        Aturdido = 5,
        Melee = 6
    }

    public AIState state = AIState.Patrol;
    public bool isRobotStatic = false;
    public AudioClip lel;
    public GameObject destello;
    public bool melee = false;
    public GameObject meleeostia;

    [Header("Velocidad del enemigo")]
    public float speed = 3f;          // Velocidad de movimiento.
    public float jumpSpeed = 4f;      // Velocidad del salto.
    private float origSpeed = 3f;
    public float runSpeed = 6f;       // Velocidad de movimiento.
    public float rotationSpeed = 5f;  // Vel de giro
    public float velocidadbala = 350f;

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
    public float ratiodisparo = 0.1f;

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
    private GameObject yolel;
    private float pollones;
    private float polladas;
    private agarre2 ag;
    private Vector3 pospawn;
    private Vector3 waypos;


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
        // Buscamos al Player por Tag.
      
        FireSound = GetComponent<AudioSource>();
        FireSound.volume = FireSound.volume * Controlador.volumenef;
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
                    state = AIState.Attach;

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
                    Animasion.SetSpeed("parao");
                    GuardTimeCheck = Time.time + GuardTime;
                }
                // change Status Condition
                if (Time.time > GuardTimeCheck)
                {
                    state = AIState.Patrol;
                    speed = origSpeed; 
                    Animasion.SetSpeed("camina");
                }
               
                if (CanSeeTarget())
                {
                    Animasion.SetSpeed("apunta");
                    state = AIState.Attach;
                }
                break;
          
            case AIState.Attach:
               
                
                if (!melee)
                {
                    norotesjoder = false;
                    AttackPlayerStatic();
                }
                else
                {
                    norotesjoder = true;
                    AttackPlayer2();
                }
                
             
                break;
           
            case AIState.Chase:
                norotesjoder = true;

                if (target == null) { return; }
                SearchPlayer(target.position);
                //  SearchPlayer(lastVisiblePlayerPosition);

                // Player not visible anymore - stop attacking

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
                    else
                    {
                        //Debug.Log("Back to Attack.");
                        tiemporeaccion = Time.time + tiemporeaccsiondesprevenio;
                        state = AIState.Attach;
                    }
                }
                if (CanSeeTarget())
                {
                    Animasion.SetSpeed("caminapuntando");
                    state = AIState.Attach;
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
                    Animasion.SetSpeed("apunta");
                    Soyelmovedorgay.enabled = true;
                    state = AIState.Attach;
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
    
    public void aturdir(float tiempo)
    {
        contadoratur = Time.time + tiempo;
        state = AIState.Aturdido;

        //NUEVO
        if (Animasion == null)
        {
            Animasion = GetComponent<AIAnimation>();
            Soyelmovedorgay = GetComponent<NavMeshAgent>();
            ag = gameObject.GetComponent<agarre2>();
        }


        Animasion.SetSpeed("aturdido");
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
                    Invoke("meleedamage", 0.45f);
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

    void meleedamage()
    {
        GameObject gay = Instantiate(meleeostia, transform.position, transform.rotation);
        gay.SendMessage("elorig", transform);
    }

    // Funcion que mira si puedo ver al player.
    private bool CanSeeTarget()
    {

        if (target == null) { return false; }
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
        if (state != AIState.Attach && state != AIState.Chase && state != AIState.Melee)
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
            CloneFire.SendMessage("elorig", transform);
            CloneFire.GetComponent<DamageBalaEnemiga>().bala = true;
            //CloneFire.GetComponent<damagegay>().damagehomogay = eldamagetio;
            //CloneFire.GetComponent<damagegay>().original = transform;

            //  FireSound.Play();
            if (FireSound == null)
            {
                FireSound = GetComponent<AudioSource>();
            }
            
            FireSound.pitch = 1 + Random.Range(-0.14f, 0.3f);
            FireSound.PlayOneShot(lel, 1f);
            Instantiate(destello, FirePos.position, FirePos.rotation, FirePos);
            if (cuerpochigadowey != null)
            {
                //FirePos.LookAt(cuerpochigadowey.position);

                Vector3 relativePos = (cuerpochigadowey.position - (Vector3.up * 1.5f))- FirePos.position;
                FirePos.rotation = Quaternion.LookRotation(relativePos, Vector3.up); ;
            }
            else
            {
                // cuerpochigadowey = GameObject.FindWithTag("estoyaquicerda").transform;
                FirePos.LookAt(target);
            }


            Vector3 direction2 = CalcularDireccionBala2(Vector3.zero);
            direction2.z = 1;
            Vector3 Bulletdirection2 = FirePos.TransformDirection(direction2);


            CloneFire.transform.rotation = Quaternion.FromToRotation(Vector3.forward, Bulletdirection2);
            //CloneFire.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,0, velocidadbala), ForceMode.VelocityChange); DISPARO CON RIGIDBODY
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
        Destroy(GetComponent<ManageEnemyStatus1>().Icono);
        StopAllCoroutines();
        this.enabled = false;
    }
}