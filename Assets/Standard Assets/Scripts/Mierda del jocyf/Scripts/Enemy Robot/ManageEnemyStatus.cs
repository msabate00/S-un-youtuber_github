using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AI;

public class ManageEnemyStatus : MonoBehaviour
{
    public GameObject cuerpaso;
    public GameObject Desactivadorwaypoint;
    public GameObject raycastman;
    public string tipoenemigogay;
    public float resiststun = 100;
    public float resist = 100;
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
    public GameObject Ragdollhomosexual;

    [Tooltip("Puntos a conseguir si matas a este enemigo.")]
    public int DestroyPoints = 10;

    [Tooltip("Efecto visual que se vera cuando este enemigo muera.")]
    public GameObject SplashObject;

    private TextMeshProUGUI myScoreText;
    //private GUIText ScoreText;
    private GameObject enemyObject;
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
  
    private Vector3 lacosaesa2;
    public GameObject yo;
    private AIAnimation Animasion;
    private float cojonazos = 0;
    private bool amorido = false;
    private float tiempoputochingon = 0.1f;
    private float tiempoputochingonazo;
    private UnityEngine.AI.NavMeshAgent Soyelmovedorgay;
    private CharacterController colisionadorgay;
    private float pollones;
    private float tiempodesaparaceorig;
    private bool muertoputo = false;
    private Collider[] AllColliders;
    private Collider[] AllColliders2;
    public GameObject spawnergay;

    private CharacterController yocolisionadorgay;

    void Awake()
    {
        yocolisionadorgay = GetComponent<CharacterController>();
        AllColliders = GetComponentsInChildren<CapsuleCollider>(false);
        AllColliders2 = GetComponentsInChildren<BoxCollider>(false);
        foreach (var col in AllColliders)
        {
            col.enabled = false;
        }
        foreach (var col in AllColliders2)
        {
            col.enabled = false;
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
                print("gays");
                AplicaDamage(Controlador.damage4);
                AplicaStun(Controlador.stun4);
            }
        }
    }

    public void ExplosionadoMuerto(Transform granadagay)
    {
        print("gays de mierda");
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
                print("gays putos gays");
                MoridoExplosionado();
            }
        }
    }

    void MoridoExplosionado()
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

        foreach (var col in AllColliders2)
        {
            col.enabled = true;
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

    }

    void Update()
    {
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
    public void AplicaDamage(float damage)
    {
        //health -= Damage;
        //SendMessage("StartChaseStatus", SendMessageOptions.DontRequireReceiver);

        damage *= resist;
        damage /= 100;
        health -= damage;
        health = Mathf.Clamp(health, 0, int.MaxValue);
        //Debug.Log("FPCManageEnemyStatus -> ApplyDamage() -> Damage: " + damage + " Enemy Health: " + health);

        // transform.localScale.y > 1.0f

        if (health > 0)
        {
            SendMessage("StartChaseStatus", SendMessageOptions.DontRequireReceiver);
            if (GetComponent<AIRobotCamper>() == null)
            {
                Instantiate(Desactivadorwaypoint, transform.position, transform.rotation);
            }

        }
        else
        {
            KillEnemy();
        }
    }

    public void AplicaStun(float stun)
    {
        if (!amorido)
        {
            stunact *= resiststun;
            stunact /= 100;
            stunact += stun;
            stunact = Mathf.Clamp(stunact, 0f, stunmax);
            tiempoesperastun = Time.time + resistenciastun;
        }
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
        print("TU PADRE CHI8NGON ME CHINGASTE LA PORONGA");
            tiempoputochingonazo = Time.time + tiempoputochingon;
            gameObject.SendMessage("ahmanmegolpiaronwey");
    }

    void Start()
    {
        Soyelmovedorgay = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Animasion = yo.GetComponent<AIAnimation>();
        //imagengay = GetComponent<Image>();
        /*GameObject ScoreObj = GameObject.Find("GUI Score");
        ScoreText = ScoreObj.GetComponent<GUIText>();*/

        GameObject ScoreObj = GameObject.Find("Puntos TextMeshPro");

        enemyObject = this.transform.gameObject;	// get the hole Enemy Object so we can destroy it if he dies.
    }
   public void hasmorio()
    {
        if (!muertoputo)
        {
            //  gameObject.SendMessage("hasmoridolol");
            if (tocho)
            {
                spawnergay.GetComponent<Spawner>().enemigosahora -= 1;
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
                spawnergay.GetComponent<Spawner>().enemigosahora -= 1;
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
            
            /*
               GameObject pollada = Instantiate(municion, transform.position, transform.rotation);
               if (tocho)
                {
                    pollada.GetComponent<Municionwena>().municion4 = 1;
                }
            */
               
            muertoputo = true;
        }
    }

    // Check emeny's health. If <= zero update enemy's variables (to die) and destroy it in X seconds
    private void KillEnemy()
    {
        Destroy(raycastman);
        Instantiate(Desactivadorwaypoint, transform.position, transform.rotation);
        hasmorio();
        
        colisionadorgay = GetComponent<CharacterController>();
        colisionadorgay.enabled = false;
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
        gameObject.SendMessage("ahmanmegolpiaronwey");
        Destroy(enemyObject, 10f);
        Animasion.SetSpeed("muereputa");
        Soyelmovedorgay.enabled = false;
    }

    private void KillEnemyGranada()
    {
        print("POLLASPOLLASPOLLASPO0LLAS");
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
 }