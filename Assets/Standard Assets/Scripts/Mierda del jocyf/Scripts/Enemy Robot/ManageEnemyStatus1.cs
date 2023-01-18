using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AI;

public class ManageEnemyStatus1 : MonoBehaviour
{
    public int id;
    public GameObject cuerpaso;
    public GameObject Desactivadorwaypoint;
    public GameObject raycastman;
    public GameObject sangremierda;
    public GameObject sparks;
    public float puntos = 100;
    public string tipoenemigogay;
    public float resiststun = 100; //Resistencia al incremento de stun
    public float resist = 100; //Resistencia al sustracto de vida
    public float resiststunparry = 100; //Resistencia al incremento de stun
    public float resistparry = 100; //Resistencia al sustracto de vida
    public float factormelee = 1;
    public float factormeleestun = 1;
    [Tooltip("Salud del enemigo.")]
    public float health = 100;
    public float stunmax = 100;
    public float stunact = 0;
    public int decrementostun = 10;
    public bool stuneable = true;
    public bool tocho;
    public bool normal;
    public bool camper;
    public bool especial;
    public GameObject Ragdollhomosexual;
    //[HideInInspector]
    public bool parry = false;

    [Tooltip("Puntos a conseguir si matas a este enemigo.")]
    public int DestroyPoints = 10;

    [Tooltip("Efecto visual que se vera cuando este enemigo muera.")]
    public GameObject SplashObject;

    private TextMeshProUGUI myScoreText;
    //private GUIText ScoreText;
    private GameObject enemyObject;
    public GameObject Icono;
    public GameObject vida;
    public GameObject stun;
    public GameObject fondo;
    public Image imagengay;
    public GameObject municion;
    private float vidaorig;
    private float vidamax;
    private float stunorig;
    private Vector3 lacosaesa;
    private float tiempoespera = 0.4f;
    
    [HideInInspector]
    public string tipo;
    [HideInInspector]
    public float activao = 0;
    [HideInInspector]
    public float tiempoesperastun = 0;
    public float resistenciastun = 2;
    public float tiempodesaparace = 1;
    public float Damage;
  
    private Vector3 lacosaesa2;
    public GameObject yo;
    private AIAnimation Animasion;
    private float cojonazos = 0;
    [HideInInspector]
    public bool amorido = false;
    private float tiempoputochingon = 0.1f;
    private float tiempoputochingonazo;
    private UnityEngine.AI.NavMeshAgent Soyelmovedorgay;
    private CharacterController colisionadorgay;
    private float pollones;
    private float tiempodesaparaceorig;
    private bool muertoputo = false;
    private Collider[] AllColliders;
    private Collider[] AllColliders2;
    private Rigidbody[] AllRig;
    public GameObject spawnergay;
    private bool pollas = false;
    [HideInInspector]
    public float alturabala;
    [HideInInspector]
    public Vector3 posbala;
    private bool parese = false;
    public Transform cubodemierda;
    private bool hamuertojoder = false;
    public GameObject explosion;
    [HideInInspector]
    public Rigidbody[] AllRigids;
    public AudioClip[] muertes;

    private CharacterController yocolisionadorgay;

    private float invul;

    private float multiplicadorfuerza = 2f;

    public Vector2Int rango;
    public GameObject prefab;
    private bool spawneao = false;
    private bool hemuertoupdate = false;

    private bool parchespawn = false;

    void Awake()
    {
        yocolisionadorgay = GetComponent<CharacterController>();
        AllColliders = GetComponentsInChildren<Collider>();
        AllRig = GetComponentsInChildren<Rigidbody>();


        foreach (Rigidbody a in AllRig)
        {
           // a.isKinematic = true;
        }
        foreach (Collider a in AllColliders)
        {
           // a.isTrigger = true;
        }

        tiempodesaparaceorig = tiempodesaparace;
        lacosaesa2 = stun.transform.localScale;
        lacosaesa = vida.transform.localScale;
        vidaorig = vida.transform.localScale.x;
        stunorig = stun.transform.localScale.x;
        vidamax = health;

    }
    public void tiempobarra()
    {
        activao = Time.time + tiempodesaparace;
    }

    public void Explosionado (Transform granadagay)
    {
        var layerMask = (1 << 15);
        layerMask |= (1 << 21);

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Linecast(transform.position, granadagay.position, out hit, layerMask))
        {
            if (hit.collider.tag == "Granada")
            {
                //   Debug.DrawRay(transform.position, inExp.GetComponent<Collider>().transform.position, Color.yellow);
                // inExp.GetComponent<Collider>().transform.gameObject.SendMessage("Explo");
                AplicaDamage(Controlador.damage4);
                AplicaStun(Controlador.stun4);
            }
        }
    }

    public void ExplosionadoMuerto(Transform granadagay)
    {

        if (!hamuertojoder)
        {
            
            var layerMask = (1 << 15);
            layerMask |= (1 << 21);



            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            Debug.Log("SEX");
            Vector3 rel = granadagay.position - transform.position;
            if (Physics.Linecast(transform.position + (Vector3.up * 1.5f), granadagay.position, out hit, layerMask))
            {
                Debug.Log(hit.transform.name);
                if (hit.collider.tag == "Granada")
                {
                    Debug.Log("sex2");
                    //   Debug.DrawRay(transform.position, inExp.GetComponent<Collider>().transform.position, Color.yellow);
                    // inExp.GetComponent<Collider>().transform.gameObject.SendMessage("Explo");

                    if (id!= 3)
                    {
                        hamuertojoder = true;
                        MoridoExplosionado();
                    }

                    else
                    {
                        AplicaDamage(Controlador.damage4 * 8);
                        AplicaStun(Controlador.stun4 * 5);
                    }
                    
                }
            }
        }
    }

    public void MoridoExplosionado()
    {
        Instantiate(Desactivadorwaypoint, transform.position, transform.rotation);
        amorido = true;
        yocolisionadorgay.enabled = false;
        GetComponent<Animator>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        foreach (var col in AllColliders)
        {
            col.enabled = true;
        }

        foreach (var col in AllColliders)
        {
            col.enabled = true;
        }

        foreach (Rigidbody r in AllRigids)
        {
            r.isKinematic = false;
        }

        Destroy(raycastman);
        Destroy(fondo);
        Destroy(stun);
        Destroy(vida);
        hasmorio();
        cuerpaso.layer = 18;
        Soyelmovedorgay.enabled = false;
        cojonazos = Time.time + tiempoespera;
        amorido = true;
        Destroy(enemyObject, 10f);
        KillEnemyGranada();
        if (GetComponent("AIRobot") != null)
        {
            GetComponent<AIRobot>().enabled = false;
        }
        if (GetComponent("AIRobotCamper") != null)
        {
            GetComponent<AIRobotCamper>().enabled = false;
        }
        if (GetComponent("AIRobotRusher") != null)
        {
            GetComponent<AIRobotRusher>().enabled = false;
        }
        if (GetComponent<AIRobot1>() != null)
        {
            GetComponent<AIRobot1>().enabled = false;
        }

    }

    void Update()
    {
        if (hemuertoupdate)
        {
            puntoshomosexuales();
            KillEnemy(true);
            hemuertoupdate = false;
        }

        if (Time.timeScale != 1)
        {
            pollones = Time.timeScale;
            float penegay = tiempodesaparaceorig;
            penegay *= pollones;
            tiempodesaparace = penegay;
        }
        if (Time.timeScale == 1 && tiempodesaparace != tiempodesaparaceorig)
        {
            tiempodesaparace = tiempodesaparaceorig;
        }
            if (amorido && Time.time > cojonazos)
        {
            stunact = 0;
        }


            if (Time.time < activao && health > 0)
        {
            if (!stuneable && stun != null)
            {
                stun.SetActive(false);
            }
            if (stuneable && stun != null)
            {
                stun.SetActive(true);
            }
            if (stun != null)
            {
                vida.SetActive(true);
                fondo.SetActive(true);
            }
            }
        else
        {
            if (fondo != null)
            {
                fondo.SetActive(false);
                stun.SetActive(false);
                vida.SetActive(false);
            }
          
        }
      
        stunact = Mathf.Clamp(stunact, 0f, stunmax);
        if (Time.time > tiempoesperastun)
        {
            stunact -= decrementostun * Time.deltaTime;
        }
        if (stunact == stunmax)
        {
           imagengay.color = Color.green;
           activao = Time.time + tiempodesaparace;
           parry = false;

        }
        else
        {
            imagengay.color = Color.yellow;
        }
        float puta = stunact;
        float cojones;
        float polla = health;
        float pene;
        cojones = puta / stunmax * stunorig;
        pene = polla / vidamax * vidaorig;
        pene = Mathf.Clamp(pene, 0f, 1f);        
        lacosaesa2.x = cojones;
        lacosaesa.x = pene;
        if (fondo != null)
        {
            vida.transform.localScale = lacosaesa;
            stun.transform.localScale = lacosaesa2;
        }
            
    }
    
    void puntoshomosexuales() //Puntos a bajas con armas
    {
        spawnear();

        parry = false;
        actualizarstats(false);
        Icono.SetActive(false);
        float gay = puntos * 0.2f;
        gay = gay * Controlador.multi;
        if (Controlador.multi == 1) { gay = 0; }
        gay = gay + puntos;
        //Controlador.puntos += gay;

        putosgays a = GameObject.Find("PutosPuntosGays").GetComponent<putosgays>();
        float sex = a.puntitos[DisparoSelectivo.NumeroArmagay];

        if (DisparoSelectivo.NumeroArmagay == 8) //Ballesta
        {
            a.gays(a.puntitos[15] + puntos, 15);
            //a.puntos += 500;
            sex = a.puntitos[15];
        }
        else
        {
            a.gays(a.puntitos[DisparoSelectivo.NumeroArmagay] + puntos, DisparoSelectivo.NumeroArmagay);
            //a.puntos += 500;
        }

        a.puntos += puntos * (sex/600);
      

    }

    void puntoshomosexuales1(int id) //Railgun
    {
        spawnear();

        parry = false;
        actualizarstats(false);
        Icono.SetActive(false);
        float gay = puntos * 0.2f;
        gay = gay * Controlador.multi;
        if (Controlador.multi == 1) { gay = 0; }
        gay = gay + puntos;
        //Controlador.puntos += gay;

        putosgays a = GameObject.Find("PutosPuntosGays").GetComponent<putosgays>();

        a.gays(a.puntitos[id] + puntos, id);
        a.puntos += 500;

    }

    void puntoshomosexuales2()
    {
        spawnear();

        parry = false;
        actualizarstats(false);
        Icono.SetActive(false);
        float gay = puntos * 0.2f;
        gay = gay * Controlador.multi;
        if (Controlador.multi == 1) { gay = 0; }
        gay = gay + puntos;
        //Controlador.puntos += gay;

        putosgays a = GameObject.Find("PutosPuntosGays").GetComponent<putosgays>();

        a.gays(a.puntitos[16], 16); //Ballesta explosiva
        a.puntos += 550;



    }

    void puntoshomosexualesDesf()
    {
        spawnear();

        parry = false;
        actualizarstats(false);
        Icono.SetActive(false);
        putosgays a = GameObject.Find("PutosPuntosGays").GetComponent<putosgays>();
        a.puntos += 380;

        a.gays(a.puntitos[11], 11);

    }

    public void sangrecilla(RaycastHit hit)
    {
        if (parry)
        {
            Vector3 relativePos = transform.position - hit.point;
            Quaternion ah = Quaternion.LookRotation(relativePos, Vector3.up);
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, hit.normal);
            GameObject _splahObject = Instantiate(sparks, hit.point, ah);
            _splahObject.transform.localEulerAngles = new Vector3(0, _splahObject.transform.localEulerAngles.y, 0);
            _splahObject.transform.position -= _splahObject.transform.forward * 1.8f;
            //_splahObject.transform.position -= _splahObject.transform.up * 1.8f;
            
        }
        else
        {
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, hit.normal);
            GameObject _splahObject = Instantiate(sangremierda, hit.point, rot);
            _splahObject.transform.position += _splahObject.transform.up * 0.1f;
        }
        
        
    }
    public void sangrecilla(ContactPoint hit)
    {
        if (parry)
        {
            Vector3 relativePos = transform.position - hit.point;
            Quaternion ah = Quaternion.LookRotation(relativePos, Vector3.up);
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, hit.normal);
            GameObject _splahObject = Instantiate(sparks, hit.point, ah);
            _splahObject.transform.localEulerAngles = new Vector3(0, _splahObject.transform.localEulerAngles.y, 0);
            _splahObject.transform.position -= _splahObject.transform.forward * 1.8f;
            //_splahObject.transform.position -= _splahObject.transform.up * 1.8f;
           
        }
        else
        {
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, hit.normal);
            GameObject _splahObject = Instantiate(sangremierda, hit.point, rot);
            _splahObject.transform.position += _splahObject.transform.up * 0.1f;
        }
    }

    public void AplicaDamage(float damage)
    {
        if (health == 0) { return; }
        //if (Time.time < invul) { return; }
        invul = Time.time + 0.05f;
        //health -= Damage;
        //SendMessage("StartChaseStatus", SendMessageOptions.DontRequireReceiver);
        if (!parry)
        {
            damage *= resist;
            damage /= 100;
            health -= damage;
            health = Mathf.Clamp(health, 0, int.MaxValue);
        }
        else
        {
            damage *= resistparry;
            damage /= 100;
            health -= damage;
            health = Mathf.Clamp(health, 0, int.MaxValue);
        }

        if (health < 90 && !pollas)
        {
            pollas = true;
        }
        //Debug.Log("FPCManageEnemyStatus -> ApplyDamage() -> Damage: " + damage + " Enemy Health: " + health);

        // transform.localScale.y > 1.0f

        if (health > 0)
        {
            SendMessage("StartChaseStatus", SendMessageOptions.DontRequireReceiver);
            if (parry && stunact < stunmax) { SendMessage("Block", SendMessageOptions.DontRequireReceiver); }
            if (GetComponent<AIRobotCamper>() == null)
            {
               // Instantiate(Desactivadorwaypoint, transform.position, transform.rotation);
            }

        }
        else if (!parese)
        {
            foreach (Rigidbody r in AllRigids)
            {
                if (r == null) { continue; }
                r.isKinematic = false;
            }

            hemuertoupdate = true;
            GetComponent<agarre2>().mareao = false;
            //puntoshomosexuales();
            parese = true;
            //KillEnemy(true);
            Quitarlayer();
        }
    }
    public void AplicaDamage2(float damage)
    {
        if (health == 0) { return; }
        if (Time.time < invul) { return; }
        invul = Time.time + 0.05f;

        if (!parry)
        {
            damage *= resist;
            damage /= 100;
            health -= damage;
            health = Mathf.Clamp(health, 0, int.MaxValue);
        }
        else
        {
            damage *= resistparry;
            damage /= 100;
            health -= damage;
            health = Mathf.Clamp(health, 0, int.MaxValue);
        }

        if (health < 90 && !pollas)
        {
            pollas = true;
        }
        //Debug.Log("FPCManageEnemyStatus -> ApplyDamage() -> Damage: " + damage + " Enemy Health: " + health);

        // transform.localScale.y > 1.0f

        if (health > 0)
        {
            SendMessage("StartChaseStatus", SendMessageOptions.DontRequireReceiver);
            if (parry && stunact < stunmax) { SendMessage("Block", SendMessageOptions.DontRequireReceiver); }
            if (GetComponent<AIRobotCamper>() == null)
            {
                // Instantiate(Desactivadorwaypoint, transform.position, transform.rotation);
            }

        }
        else if (!parese)
        {
            GetComponent<agarre2>().mareao = false;
            puntoshomosexuales1(14);
             parese = true;
            // KillEnemy(true);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    public void AplicaDamage3(float damage)
    {
        if (health == 0) { return; }
        if (Time.time < invul) { return; }
        invul = Time.time + 0.05f;

        if (!parry)
        {
            damage *= resist;
            damage /= 100;
            health -= damage;
            health = Mathf.Clamp(health, 0, int.MaxValue);
        }
        else
        {
            damage *= resistparry;
            damage /= 100;
            health -= damage;
            health = Mathf.Clamp(health, 0, int.MaxValue);
        }

        if (health < 90 && !pollas)
        {
            pollas = true;
        }
        //Debug.Log("FPCManageEnemyStatus -> ApplyDamage() -> Damage: " + damage + " Enemy Health: " + health);

        // transform.localScale.y > 1.0f

        if (health > 0)
        {
            SendMessage("StartChaseStatus", SendMessageOptions.DontRequireReceiver);
            if (parry && stunact < stunmax) { SendMessage("Block", SendMessageOptions.DontRequireReceiver); }
            if (GetComponent<AIRobotCamper>() == null)
            {
                // Instantiate(Desactivadorwaypoint, transform.position, transform.rotation);
            }

        }
        else if (!parese)
        {
            GetComponent<agarre2>().mareao = false;
            puntoshomosexualesDesf();
            parese = true;
            // KillEnemy(true);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void AplicaDamage4(float damage, int id)
    {
        if (health == 0) { return; }
        //if (Time.time < invul) { return; }
        invul = Time.time + 0.05f;
        //health -= Damage;
        //SendMessage("StartChaseStatus", SendMessageOptions.DontRequireReceiver);
        if (!parry)
        {
            damage *= resist;
            damage /= 100;
            health -= damage;
            health = Mathf.Clamp(health, 0, int.MaxValue);
        }
        else
        {
            damage *= resistparry;
            damage /= 100;
            health -= damage;
            health = Mathf.Clamp(health, 0, int.MaxValue);
        }

        if (health < 90 && !pollas)
        {
            pollas = true;
        }
        //Debug.Log("FPCManageEnemyStatus -> ApplyDamage() -> Damage: " + damage + " Enemy Health: " + health);

        // transform.localScale.y > 1.0f

        if (health > 0)
        {
            SendMessage("StartChaseStatus", SendMessageOptions.DontRequireReceiver);
            if (parry && stunact < stunmax) { SendMessage("Block", SendMessageOptions.DontRequireReceiver); }
            if (GetComponent<AIRobotCamper>() == null)
            {
                // Instantiate(Desactivadorwaypoint, transform.position, transform.rotation);
            }

        }
        else if (!parese)
        {
            foreach (Rigidbody r in AllRigids)
            {
                if (r == null) { continue; }
                r.isKinematic = false;
            }

            GetComponent<agarre2>().mareao = false;
            puntoshomosexuales1(id);
            parese = true;
            KillEnemy(true);
            Quitarlayer();
        }
    }

    public void AplicaDamage5(float damage)
    {
        if (health == 0) { return; }
        //if (Time.time < invul) { return; }
        invul = Time.time + 0.05f;
        //health -= Damage;
        //SendMessage("StartChaseStatus", SendMessageOptions.DontRequireReceiver);
        if (!parry)
        {
            damage *= resist;
            damage /= 100;
            health -= damage;
            health = Mathf.Clamp(health, 0, int.MaxValue);
        }
        else
        {
            damage *= resistparry;
            damage /= 100;
            health -= damage;
            health = Mathf.Clamp(health, 0, int.MaxValue);
        }

        if (health < 90 && !pollas)
        {
            pollas = true;
        }
        //Debug.Log("FPCManageEnemyStatus -> ApplyDamage() -> Damage: " + damage + " Enemy Health: " + health);

        // transform.localScale.y > 1.0f

        if (health > 0)
        {
            SendMessage("StartChaseStatus", SendMessageOptions.DontRequireReceiver);
            if (parry && stunact < stunmax) { SendMessage("Block", SendMessageOptions.DontRequireReceiver); }
            if (GetComponent<AIRobotCamper>() == null)
            {
                // Instantiate(Desactivadorwaypoint, transform.position, transform.rotation);
            }

        }
        else if (!parese)
        {
            foreach (Rigidbody r in AllRigids)
            {
                if (r == null) { continue; }
                r.isKinematic = false;
            }

            GetComponent<agarre2>().mareao = false;
            puntoshomosexuales2();
            parese = true;
            KillEnemy(true);
            Quitarlayer();
        }
    }

    public void AplicaStun(float stun)
    {
        if (health == 0) { return; }
        if (!amorido && health > 0)
        {
            if (parry)
            {
                stun *= resiststunparry;
                stun /= 100;
                stunact += stun;
                stunact = Mathf.Clamp(stunact, 0f, stunmax);
                if (stunact == stunmax)
                {
                    tiempoesperastun = Time.time + resistenciastun;
                    gameObject.SendMessage("aturdir", resistenciastun);
                }
            }
            else
            {
                stun *= resiststun;
                stun /= 100;
                stunact += stun;
                stunact = Mathf.Clamp(stunact, 0f, stunmax);
                tiempoesperastun = Time.time + resistenciastun;

                if (stunact == stunmax)
                {                    
                    gameObject.SendMessage("aturdir", resistenciastun);
                }
            }
           
           
        }
    }

    public void actualizarstats(bool sex)
    {
        Controlador.enemigosactuales--;
        Controlador.enemigoslista[id]--;
        if (especial) { Controlador.enemigosactualesesp--; }

        Controlador.bajaspartida++;
        Controlador.bajastotales++;
        if (!sex)
        {
            Controlador.bajas[DisparoSelectivo.NumeroArmagay]++;
            Controlador.bajaspartidagay[DisparoSelectivo.NumeroArmagay]++;
        }
       

        GameObject.Find("Spawners").SendMessage("sumarmuerte");
    }
   
    public void AplicaStunmelee(int stun)
    {
        float stunpollas = stun;
        stunpollas *= factormeleestun;

        AplicaStun(stunpollas);
    }


    public void Golpiado(int damagegay)
    {
        float damagemierda = damagegay;
        damagemierda *= factormelee;
            AplicaDamage(damagemierda);
        AplicaStunmelee(55);
        tiempoputochingonazo = Time.time + tiempoputochingon;


        putosgays a = GameObject.Find("PutosPuntosGays").GetComponent<putosgays>();
        a.gays(a.puntitos[19], 19);
        a.puntos += 250;

            //gameObject.SendMessage("ahmanmegolpiaronwey");
    }

    void Start()
    {
        asignarspawner();
        AllRigids = gameObject.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody r in AllRigids)
        {
            r.isKinematic = true;
            r.collisionDetectionMode = CollisionDetectionMode.Discrete;
        }

        Soyelmovedorgay = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Animasion = yo.GetComponent<AIAnimation>();
        //imagengay = GetComponent<Image>();
        /*GameObject ScoreObj = GameObject.Find("GUI Score");
        ScoreText = ScoreObj.GetComponent<GUIText>();*/

        GameObject ScoreObj = GameObject.Find("Puntos TextMeshPro");

        enemyObject = transform.gameObject;	// get the hole Enemy Object so we can destroy it if he dies.


    }

    public void asignarspawner()
    {
        if (parchespawn) { return; }

        parchespawn = true;
        Controlador.enemigoslista[id]++;
        Controlador.enemigosactuales++;
        if (especial) { Controlador.enemigosactualesesp++; }
    }

   public void hasmorio()
    {
        if (!muertoputo)
        {
            //  gameObject.SendMessage("hasmoridolol");
            if (tocho)
            {
               // spawnergay.GetComponent<Spawner>().enemigosahora -= 1;
                if (tipo == "tochoalpha")
                {
                    Controlador.enemigostochosalpha -= 1;
                }
                if (tipo == "tochobeta")
                {
                    Controlador.enemigostochosbeta -= 1;
                }
                if (tipo == "tochodelta")
                {
                    Controlador.enemigostochosdelta -= 1;
                }
                if (tipo == "tochogamma")
                {
                    Controlador.enemigostochosgamma -= 1;
                }

            }
            if (normal)
            {
              //  spawnergay.GetComponent<Spawner>().enemigosahora -= 1;
                if (tipo == "normalalpha")
                {
                    Controlador.enemigosnormalesalpha -= 1;
                }
                if (tipo == "normalbeta")
                {
                    Controlador.enemigosnormalesbeta -= 1;
                }
                if (tipo == "normaldelta")
                {
                    Controlador.enemigosnormalesdelta -= 1;
                }
                if (tipo == "normalgamma")
                {
                    Controlador.enemigosnormalesgamma -= 1;
                }

            }
            if (camper)
            {
                if (tipo == "camperoalpha")
                {
                    Controlador.enemigoscampersalpha -= 1;
                }
                if (tipo == "camperobeta")
                {
                    Controlador.enemigoscampersbeta -= 1;
                }
                if (tipo == "camperodelta")
                {
                    Controlador.enemigoscampersdelta -= 1;
                }
                if (tipo == "camperogamma")
                {
                    Controlador.enemigoscampersgamma -= 1;
                }

            }
            
               /*GameObject pollada = Instantiate(municion, transform.position, transform.rotation);
               if (tocho)
                {
                    pollada.GetComponent<Municionwena>().municion4 = 1;
                }           
               */

            muertoputo = true;
        }
    }

    // Check emeny's health. If <= zero update enemy's variables (to die) and destroy it in X seconds
    public void KillEnemy(bool ragdoll)
    {
        Destroy(raycastman);
        Instantiate(Desactivadorwaypoint, transform.position, transform.rotation);
        hasmorio();

        if (muertes.Length > 0)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(muertes[Random.Range(0, muertes.Length)], 1);
        }
        
        gameObject.SendMessage("desactivar");
        colisionadorgay = GetComponent<CharacterController>();
        colisionadorgay.enabled = false;
        stun.SetActive(false);
        vida.SetActive(false);
        cuerpaso.layer = 18;
        Soyelmovedorgay.enabled = false;
        cojonazos = Time.time + tiempoespera;
        amorido = true;
        
        GameMngr.Instance.Score += DestroyPoints;
        //myScoreText.text = "PUNTOS:\n"+GameMngr.Instance.Score.ToString();
        GameMngr.Instance.nEnemiesKilled++;

        //Debug.Log("ManageEnemyStatus -> KillEnemy() -> Enemy Die");


        gameObject.SendMessage("ahmanmegolpiaronwey");
        Destroy(enemyObject, 10f);
        Animasion.SetSpeed("muereputa");
        Soyelmovedorgay.enabled = false;

        /*
        GameObject a = Instantiate(Ragdollhomosexual, transform.position, transform.rotation);

        Vector3 ah = transform.position - GameObject.FindGameObjectWithTag("micuerpochingon").transform.position;
        
        GameObject[] chi = new GameObject[a.transform.childCount];
        foreach (Rigidbody t in a.GetComponentsInChildren<Rigidbody>())
        {
            if (t.gameObject.tag == "cabesa")
            {
                t.AddForce(ah.normalized * 7000);
            }
            else
            {
                t.AddForce(ah.normalized * 200);
            }
            

        }

        for (int i = 0; i < chi.Length; i++)
        {


        }

        Destroy(gameObject);
        */


        
        GetComponent<Animator>().enabled = false;
        Vector3 ah = transform.position - posbala;
        ah.y = 0;
        ah = ah.normalized;
        ah = posbala.normalized;
        //cubodemierda.position = transform.position + (ah * 10);
        

        //  GameObject a = Instantiate(Ragdollhomosexual, transform.position, transform.rotation);
        //damageweno[] lul = a.GetComponentsInChildren<damageweno>();
        damageweno[] lul = GetComponentsInChildren<damageweno>();

        if (ragdoll)
        {

            if (alturabala <= 2.0f)
            { // PIERNAS
                for (int i = 0; i < lul.Length; i++)
                {

                    if (lul[i] != null)
                    {

                        if (lul[i].estado == damageweno.Direction.Piernas)
                        {
                            lul[i].gameObject.GetComponent<Rigidbody>().AddForce(ah * ((140 * multiplicadorfuerza)), ForceMode.Impulse);
                        }
                        if (lul[i].estado == damageweno.Direction.Cabeza)
                        {
                            lul[i].gameObject.GetComponent<Rigidbody>().AddForce(ah * ((-50 * multiplicadorfuerza)), ForceMode.Impulse);
                        }

                    }
                }
            }
            else if (alturabala > 2.0f && alturabala <= 4.0f)
            {
                for (int i = 0; i < lul.Length; i++)
                {

                    if (lul[i] != null)
                    {

                        if (lul[i].estado == damageweno.Direction.Torso)
                        {
                            lul[i].gameObject.GetComponent<Rigidbody>().AddForce(ah * ((40 * multiplicadorfuerza)), ForceMode.Impulse);
                            lul[i].joder = "TUS PUTOS MUERTOS";
                        }

                    }
                }
            }
            else if (alturabala > 4.0f)
            {
                for (int i = 0; i < lul.Length; i++)
                {

                    if (lul[i] != null)
                    {

                        if (lul[i].estado == damageweno.Direction.Cabeza)
                        {
                            lul[i].gameObject.GetComponent<Rigidbody>().AddForce(ah * ((30 * multiplicadorfuerza)), ForceMode.Impulse);
                        }
                        if (lul[i].estado == damageweno.Direction.Torso)
                        {
                            lul[i].gameObject.GetComponent<Rigidbody>().AddForce(ah * ((25 * multiplicadorfuerza)), ForceMode.Impulse);
                        }

                    }
                }
            }
        }
        /*
        if (alturabala <= 2.0f)
        { // PIERNAS
            for (int i = 0; i < lul.Length; i++)
            {

                if (lul[i] != null)
                {                  

                    if (lul[i].estado == damageweno.Direction.Piernas)
                    {
                        lul[i].gameObject.GetComponent<Rigidbody>().AddForce(ah * 2700);
                    }
                    if (lul[i].estado == damageweno.Direction.Cabeza)
                    {
                        lul[i].gameObject.GetComponent<Rigidbody>().AddForce(ah * -4000);
                    }

                }
            }
        }
        else if (alturabala > 2.0f && alturabala <= 4.0f)
        {
            for (int i = 0; i < lul.Length; i++)
            {

                if (lul[i] != null)
                {
                   
                    if (lul[i].estado == damageweno.Direction.Torso)
                    {
                        lul[i].gameObject.GetComponent<Rigidbody>().AddForce(ah * 5000);
                        lul[i].joder = "TUS PUTOS MUERTOS";
                        Debug.Log(lul[i].gameObject.GetComponent<Rigidbody>());
                    }

                }
            }
        }
        else if (alturabala > 4.0f)
        {
            for (int i = 0; i < lul.Length; i++)
            {

                if (lul[i] != null)
                {
                   
                    if (lul[i].estado == damageweno.Direction.Cabeza)
                    {
                        lul[i].gameObject.GetComponent<Rigidbody>().AddForce(ah * 5000);
                    }
                    if (lul[i].estado == damageweno.Direction.Torso)
                    {
                        lul[i].gameObject.GetComponent<Rigidbody>().AddForce(ah * 2500);
                    }

                }
            }
        }
        */
        // Destroy(gameObject);

    }

    private void KillEnemyGranada()
    {
        foreach (Rigidbody r in AllRigids)
        {
            r.isKinematic = false;
        }

        puntoshomosexuales();

        Destroy(raycastman);
        Instantiate(Desactivadorwaypoint, transform.position, transform.rotation);
        hasmorio();
        
        fondo.SetActive(false);
        stun.SetActive(false);
        vida.SetActive(false);
        cuerpaso.layer = 18;
        Soyelmovedorgay.enabled = false;
        cojonazos = Time.time + tiempoespera;
        amorido = true;
        
        //  yo.GetComponent<AIRobot>().enabled = false;
        GameMngr.Instance.Score += DestroyPoints;
        //myScoreText.text = "PUNTOS:\n"+GameMngr.Instance.Score.ToString();
        GameMngr.Instance.nEnemiesKilled++;

        //Debug.Log("ManageEnemyStatus -> KillEnemy() -> Enemy Die");

        if (SplashObject)
            //   Instantiate(SplashObject, transform.position, Quaternion.identity);

            //SendMessage("Die", SendMessageOptions.DontRequireReceiver);

        Instantiate(Ragdollhomosexual, transform.position, transform.rotation);
        Destroy(gameObject);
        Soyelmovedorgay.enabled = false;
    }

    void spawnear()
    {
        if (Controlador.vidahomosexual > 50 || spawneao) { return; }
        spawneao = true;
            int def = Random.Range(rango.x, rango.y + 1);

            for (int a = 0; a < def - 1; a++)
            {
                Instantiate(prefab, transform.position + (Vector3.up), Quaternion.identity);
            }

    }

    void Quitarlayer()
    {        
        amorido = true;
    }
}