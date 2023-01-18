#if false

using UnityEngine;
using System.Collections;

// Sistema de IA basico de un enemigo.
// Usa estados para controlar su comportamiento.
// Usa sistema de waypoints para ir de un sitio a otro a falta de un verdadero sistema de navegacion.
public enum AIState_Static
{
    Guard = 0,
    Patrol = 1,
    Chase = 2,
    Shoot = 3
}

[System.Serializable]
 // Velocidad de movimiento.
 // Velocidad de movimiento.
 // Velocidad de movimiento.
 // Vel de giro
 // Rango de disparo (distancia a la que el enemigo disparara)
 // Rango de ataque.
 // Angulo de disparo (cuanto ha de girar el enemigo para poder disparar).
 // Distancia minima de proximidad a un punto.
 // Tiempo de retardo para el disparo.
 // Tiempo de espera en un punto. Estando en modo guardia.
 // Var Interna que controla el ratio del tiempo de modo Guardia.
 // Tiempo de espera en un punto. Estando en modo guardia.
 // Var Interna que controla el ratio del tiempo de modo Guardia.
 // Var Interna que controla el ratio del tiempo de modo Guardia.
 // Blanco al que disparara (el FPC)
 // Waypoint activo al que dirigirse en modo Patrulla.
 // Posicion del punto de disparo
 // Bala a disparar.
 // Var. Interna que controla el ratio de disparo-.
 // Ultima posicion del player (para perseguirlo) en modo ataque.
 // Se ha parado el enemigo (para disparar).
// Queremos estar seguros de que el gameobject tiene un character controller
[UnityEngine.RequireComponent(typeof(CharacterController))]
public partial class AIRobotStatic : MonoBehaviour
{
    public AIState_Static state;
    public float speed;
    private float origSpeed;
    public float runSpeed;
    public float rotationSpeed;
    public float shootRange;
    public float attackRange;
    public float shootAngle;
    public float dontComeCloserRange;
    public float delayShootTime;
    public float GuardTime;
    private float GuardTimeCheck;
    public float ChaseTime;
    private float ChaseTimeCheck;
    public float ComeCloserTime;
    private float ComeCloserTimeCheck;
    public int SustractHealth;
    public float timeRateSustraction;
    private float timeRateSustractionCheck;
    private Transform target;
    public DirectionalWaypoint activeWaypoint;
    public Transform FirePos;
    public GameObject Bullet;
    private AudioSource FireSound;
    private float nextFire;
    private Vector3 lastVisiblePlayerPosition;
    private bool beingStopped;
    public virtual void Start()
    {
        // Buscamos al Player por Tag.
        if ((this.target == null) && GameObject.FindWithTag("Player"))
        {
            this.target = GameObject.FindWithTag("Player").transform;
        }
        this.FireSound = ((AudioSource) this.GetComponent(typeof(AudioSource))) as AudioSource;
        // Comprobamos que tengamos waypoint para patrullar (minimo 2)
        if (!this.activeWaypoint)
        {
            Debug.Log("You need to add any number of waypoint - 2 minimun");
            return;
        }
        // Comprobamos que tengamos un blanco al que buscar y disparar (el FPC).
        if (!this.target)
        {
            Debug.Log("There is no entity tagged 'Player' in the scene, shoud be your character");
            return;
        }
        this.origSpeed = this.speed;
    }

    //=================================
    //
    // Control de los estados de la IA.
    //
    //=================================
    public virtual void Update()
    {
        switch (this.state)
        {
            case AIState_Static.Patrol:
                // Accion
                this.MoveTowards(this.activeWaypoint.transform.position);
                // Comprobar condiciones para cambio de estado.
                if (this.activeWaypoint.CalculateDistance(this.transform.position) < this.dontComeCloserRange)
                {
                    this.state = AIState_Static.Guard;
                }
                if (this.CanSeeTarget())
                {
                    this.state = AIState_Static.Shoot;
                }
                break;
            case AIState_Static.Guard:
                // Action
                if (this.speed > 0)
                {
                    this.speed = 0;
                    this.SendMessage("SetSpeed", 0f);
                    this.GuardTimeCheck = Time.time + this.GuardTime;
                }
                // change Status Condition
                if (Time.time > this.GuardTimeCheck)
                {
                    this.state = AIState_Static.Patrol;
                    this.speed = this.origSpeed;
                    this.SendMessage("SetSpeed", this.speed);
                    this.activeWaypoint = this.activeWaypoint.CalculateTargetPosition(this.transform.position, this.dontComeCloserRange);
                }
                if (this.CanSeeTarget())
                {
                    this.state = AIState_Static.Shoot;
                }
                break;
            case AIState_Static.Chase:
                this.SearchPlayer(this.lastVisiblePlayerPosition);
                // Player not visible anymore - stop attacking
                if (Time.time >= this.ChaseTimeCheck)
                {
                    if (!this.CanSeeTarget())
                    {
                        //Debug.Log("Back to Patrol.");
                        this.speed = this.origSpeed;
                        //SendMessage("SetSpeed", 1f);
                        this.state = AIState_Static.Patrol;
                        return;
                    }
                    else
                    {
                        //Debug.Log("Back to Attack.");
                        this.state = AIState_Static.Shoot;
                    }
                }
                break;
            case AIState_Static.Shoot:
                this.AttackPlayer();
                break;
        }
    }

    // Moverse hacia un punto rotando a la vez hacia el blanco.
    public virtual void MoveTowards(Vector3 position)
    {
        Vector3 direction = position - this.transform.position;
        direction.y = 0;
        if (direction.magnitude < 0.5f)
        {
            this.SendMessage("SetSpeed", 0f);
            return;
        }
        // Rotate towards the target
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), this.rotationSpeed * Time.deltaTime);
        this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y, 0);
        // Modify speed so we slow down when we are not facing the target
        Vector3 forward = this.transform.TransformDirection(Vector3.forward);
        float speedModifier = Vector3.Dot(forward, direction.normalized);
        speedModifier = Mathf.Clamp01(speedModifier);
        // Move the character
        direction = (forward * this.speed) * speedModifier;
        CharacterController MyController = ((CharacterController) this.GetComponent(typeof(CharacterController))) as CharacterController;
        MyController.SimpleMove(direction);
        this.SendMessage("SetSpeed", this.speed * speedModifier, SendMessageOptions.DontRequireReceiver);
    }

    // Rotar para encarar un punto (solo la rotacion, sin movimiento).
    public virtual void RotateTowards(Vector3 position)
    {
        Vector3 direction = position - this.transform.position;
        direction.y = 0;
        if (direction.magnitude < 0.1f)
        {
            return;
        }
        // Rotamos hacia el blanco.
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), this.rotationSpeed * Time.deltaTime);
        this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y, 0);
    }

    // Funcion de ataque al payer. Se compone de tres fases
    // 1.- Correr hacia el player hasta alcanzar la distancia minima de disparo.
    // 2.- Disparar hasta matarlo o hasta que huye.
    // 3.- Si huye buscarlo otra vez y si no lo encuentra, volver a patrullar.
    public virtual void AttackPlayer()
    {
        if (this.CanSeeTarget())
        {
            // El blanco esta muerto, vuelve a patrullar.
            if (this.target == null)
            {
                //Debug.Log("Player Dead");
                this.beingStopped = false;
                this.speed = this.origSpeed;
                this.SendMessage("SetSpeed", this.speed);
                this.state = AIState_Static.Patrol;
                return;
            }
            if (this.speed > 0)
            {
                this.speed = 0;
                this.SendMessage("SetSpeed", 0f);
            }
            // Calculo la distancia y el angulo en que se encuentra el player.
            float distance = Vector3.Distance(this.transform.position, this.target.position);
            Vector3 forward = this.transform.TransformDirection(Vector3.forward);
            Vector3 targetDirection = this.lastVisiblePlayerPosition - this.transform.position;
            targetDirection.y = 0;
            float angle = Vector3.Angle(targetDirection, forward);
            this.lastVisiblePlayerPosition = this.target.position;
            if (angle >= this.shootAngle)
            {
                this.RotateTowards(this.lastVisiblePlayerPosition);
            }
            if ((distance < this.dontComeCloserRange) && (Time.time >= this.timeRateSustractionCheck))
            {
                GameMngr.Instance.nSalud = (int) (GameMngr.Instance.nSalud - (this.SustractHealth * Time.deltaTime));
                this.timeRateSustractionCheck = Time.time + this.timeRateSustraction;
            }
            // Si estoy en el angulo y la distancia de disparo
            if ((distance < this.shootRange) && (angle < this.shootAngle))
            {
                if (!this.beingStopped)
                {
                    this.StartCoroutine(this.Shoot()); // shoot with animation.
                }
                else
                {
                    this.FireEnemy(); // Instantiate the bullet (without animation).
                }
            }
        }
        else
        {
             // Busca al player dirigiendose a su ultima posicion conocida.
            this.beingStopped = false;
            this.speed = this.origSpeed;
            this.state = AIState_Static.Patrol;
        }
        return;
    }

    // Funcion que mira si puedo ver al player.
    public virtual bool CanSeeTarget()
    {
        RaycastHit hit = default(RaycastHit);
        if (Vector3.Distance(this.transform.position, this.target.position) > this.attackRange)
        {
            return false;
        }
        int layerMask = 1 << 9;
        layerMask = ~layerMask;
        if (Physics.Linecast(this.transform.position, this.target.position, out hit, layerMask))
        {
            //Debug.Log("Hit en : "+hit.transform.name);
            return hit.transform == this.target;
        }
        return false;
    }

    // Funcion que busca al player.
    public virtual void SearchPlayer(Vector3 position)
    {
        float distance = Vector3.Distance(this.transform.position, position);
        if (distance > this.dontComeCloserRange)
        {
            this.MoveTowards(position);
        }
        else
        {
            this.RotateTowards(position);
        }
        if (this.CanSeeTarget())
        {
            this.ChaseTimeCheck = Time.time;
        }
    }

    // Funcion que hace que el enemigo se acerque un poco mas al player.
    public virtual void ComeCloser(Vector3 position)
    {
        float distance = Vector3.Distance(this.transform.position, position);
        if (distance > this.dontComeCloserRange)
        {
            this.MoveTowards(position);
        }
        else
        {
            this.RotateTowards(position);
        }
    }

    // Dispara una sola vez, haciendo la animacion de disparar.
    public virtual IEnumerator Shoot()
    {
        this.speed = 0;
        this.SendMessage("SetSpeed", 0f);
        this.beingStopped = true;
        // Start shoot animation
        this.GetComponent<Animation>().CrossFade("shoot", this.delayShootTime);
        // Wait until half the animation has played
        yield return new WaitForSeconds(this.GetComponent<Animation>()["shoot"].length - this.delayShootTime);
        this.GetComponent<Animation>().Stop();
        this.FireEnemy();
    }

    // Realiza el disparo en si, instanciando la bala.
    public virtual void FireEnemy()
    {
        if (Time.time > this.nextFire)
        {
            Vector3 pos = this.FirePos.position;
            GameObject CloneFire = UnityEngine.Object.Instantiate(this.Bullet, pos, Quaternion.identity);
            if (this.FireSound != null)
            {
                this.FireSound.Play();
            }
            pos = this.target.position;
            CloneFire.transform.LookAt(pos);
            CloneFire.GetComponent<Rigidbody>().transform.LookAt(pos);
            ArmasEstado aiScript = ((ArmasEstado) CloneFire.GetComponent(typeof(ArmasEstado))) as ArmasEstado;
            CloneFire.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f, 0f, aiScript.Aceleracion), ForceMode.VelocityChange);
            this.nextFire = Time.time + aiScript.RatioDeDisparo;
        }
    }

    public AIRobotStatic()
    {
        this.state = AIState_Static.Patrol;
        this.speed = 3f;
        this.origSpeed = 3f;
        this.runSpeed = 6f;
        this.rotationSpeed = 5f;
        this.shootRange = 15f;
        this.attackRange = 30f;
        this.shootAngle = 4f;
        this.dontComeCloserRange = 5f;
        this.delayShootTime = 0.3f;
        this.GuardTime = 3;
        this.ChaseTime = 3;
        this.ComeCloserTime = 2;
        this.SustractHealth = 1;
        this.timeRateSustraction = 1;
    }

}

#endif