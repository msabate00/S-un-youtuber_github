using UnityEngine;

public enum TiposDisparo
{
    Inmediato = 0,
    Proyectil = 1,
    Rayo = 2,
    Escoputa = 3,
    Lanzagranadas = 4
}
public enum Armasgaystipos
{
    Arma0,
    Arma1,
    Arma2,
    Arma3,
    Arma4,
    Duales1,
    Duales2
}

public class GunStatus : MonoBehaviour
{
    public TiposDisparo Tipo = TiposDisparo.Inmediato;
    public Armasgaystipos Armasgays = new Armasgaystipos();
    public bool semiautomatica;
    public bool rotacionarriba; //esto lo hago xq la posicion chingona del trabuco al correr es vertical mientras que la del subfusigay es horizontal y eso que hay que diferenciarlo hostia. pepepepero falta el de la z tiiiiooooo KE TE CALLES LA BOCA JODER! SI ESTÁ ACTIVADO ES PARA LA ROTACIÓN DESEADA DEL ARMA AL CORRER EN CASO DE QUE SEA VERTICAL, REPITO GILIPOLLAS VERTICAL COJONES TIIIOOOOO
    public GameObject AnimacionesArma;
    public GameObject AnimacionesArmagays;
    public float DuracionRecarga = 1;
    public GunStatus arma2;
    public bool dual = false;
    public bool recargando = false;
    [HideInInspector]
    public bool disparo2 = false;
    public int NumArma = 0;
    public float recoiloffset = 0.05f;
    public Vector2 recoilx;
    public Vector2 recoily;

    [Header("Posiciones del Arma")]
    public Transform GunNormal;
    public Transform GunNormal2; // el parent del arma pal aim down sights ostia
    public Transform GunNormal3;
    public Transform GunRecoil;
    public Transform GunAiming;
    public Transform GunRunning;
    public Transform GunJumping;
    public Transform PuntoDisparo;
    public Transform RecoilRota;

    [Header("Cargadores")]
    public int CargadoresTotales = 10;// Esta es en realidad una var. interna.
    public int BalasTotalesPorCargador = 10;
    public int CargadoresActuales = 10; // Esta es en realidad una var. interna.
    public int BalasActualesEnCargador = 10;

    [Header("Propiedades de la bala")]
    public float TiempoDestruccion = 10;
    public float Aceleracion = 1;
    public bool UseRotation = false;
    public bool ProyectilAutoRotacion = false;
    public Vector3 VelocidadRotacion = new Vector3(2, 2, 2);

    [Header("Propiedades del arma")]
    public int Damage = 45;
    public int Stun = 20;
    public float Critico = 2;
    public float RatioDeDisparo = 1;
    public float Precision;
    public float aimPrecision;
    public float cambioarma;

    [Header("Objetos de referencia")]
    public GameObject SplashObject;
    public GameObject Decall;
    public GameObject Destello;
    public Transform PuntoCasquillo;

    

    //  Variables que deberian ser privadas pero son publicas para acceder rapidamente a ellas desde cualquier script
    // (la alternativa es hacer privadas y hacer unas funciones Get/Set para recoger su valor)
    [HideInInspector]
    public Vector3 OrigPosGunNormal = Vector3.zero;
    [HideInInspector]
    public Quaternion OrigRotGunNormal = Quaternion.identity;
    [HideInInspector]
    public Vector3 OrigPosGunAiming = Vector3.zero;
    [HideInInspector]
    public Quaternion OrigRotGunAiming = Quaternion.identity;
    [HideInInspector]
    public Vector3 OrigPosGunRunning = Vector3.zero;
    [HideInInspector]
    public Quaternion OrigRotGunRunning = Quaternion.identity;
    [HideInInspector]
    public Vector3 OrigPosGunJumping = Vector3.zero;
    [HideInInspector]
    public Quaternion OrigRotGunJumping = Quaternion.identity;

    [HideInInspector]
    public Vector3 OrigPosGunNormal2 = Vector3.zero;
    [HideInInspector]
    public Quaternion OrigRotGunNormal2 = Quaternion.identity;
    [HideInInspector]
    public Quaternion Recoilrot = Quaternion.identity;
    [HideInInspector]
    public Vector3 OrigPosGunAiming2 = Vector3.zero;
    [HideInInspector]
    public Quaternion OrigRotGunAiming2 = Quaternion.identity;
    [HideInInspector]
    public Vector3 OrigPosGunNormal3 = Vector3.zero;
    [HideInInspector]
    public Quaternion OrigRotGunNormal3 = Quaternion.identity;

    private bool paraostia = false;
    private bool paraostia2 = false;

    [HideInInspector]
    public bool isInicialized = false;

    void Start()
    {
        if (Armasgays == Armasgaystipos.Arma1)
        {
            Damage = Controlador.damage1;
            Stun = Controlador.stun1;
            Critico = Controlador.critico1;
        }
        if (Armasgays == Armasgaystipos.Arma2)
        {
            Damage = Controlador.damage2;
            Stun = Controlador.stun2;
            Critico = Controlador.critico2;
        }
        if (Armasgays == Armasgaystipos.Arma3)
        {
            Damage = Controlador.damage3;
            Stun = Controlador.stun3;
            Critico = Controlador.critico3;
        }
    }

    void Awake()
    {
        if (AnimacionesArma != null)
        {
            AnimacionesArma.GetComponent<Animation>().wrapMode = WrapMode.Once;
            AnimacionesArma.GetComponent<Animation>()["recargar"].layer = -1;
            AnimacionesArma.GetComponent<Animation>()["disparo"].layer = 0;
        }
        if (GunNormal != null)
        {
            OrigPosGunNormal = GunNormal.localPosition;
            OrigRotGunNormal = GunNormal.localRotation;
            OrigPosGunRunning = GunNormal.localPosition;
            OrigRotGunRunning = GunNormal.localRotation;
            OrigPosGunJumping = GunNormal.localPosition;
            OrigRotGunJumping = GunNormal.localRotation;
        }
        if (GunNormal2 != null)
        {
            OrigPosGunNormal2 = GunNormal2.localPosition;
            OrigRotGunNormal2 = GunNormal2.localRotation;

        }
        if (GunNormal3 != null)
        {
            OrigPosGunNormal3 = GunNormal3.localPosition;
            OrigRotGunNormal3 = GunNormal3.localRotation;

        }
        if (GunAiming != null)
        {
            OrigPosGunAiming = GunAiming.localPosition;
            OrigRotGunAiming = GunAiming.localRotation;
            OrigPosGunAiming2 = GunAiming.localPosition;
            OrigRotGunAiming2 = GunAiming.localRotation;
        }
        if (RecoilRota != null)
        {
            Recoilrot = RecoilRota.localRotation;
        }
        if (GunRunning != null)
        {
            OrigPosGunRunning = GunRunning.localPosition;
            OrigRotGunRunning = GunRunning.localRotation;
        }
        if (GunJumping != null)
        {
            OrigPosGunJumping = GunJumping.localPosition;
            OrigRotGunJumping = GunJumping.localRotation;
        }

        isInicialized = true;
    }

    // Asigno las posiciones originales que tiene que tener el arma al andar, correr, saltar y apuntar.
    void penepolla()
    {
        FPCStatus.haybalas = false;
    }
    void Update()
    {

        FPCStatus.dual = dual;
        GameMngr.balasact = BalasActualesEnCargador;
        GameMngr.balastot = CargadoresActuales;
        if (BalasActualesEnCargador > 0)
        {
            recoilcam2.haybalasjoder = true;
            FPCStatus.haybalas = true;
        }
        if (BalasActualesEnCargador <= 0)
        {
            Invoke("penepolla", 0.2f);

            recoilcam2.haybalasjoder = false;
        }
        if (FPCStatus.IsJumping && !FPCStatus.IsJumpingAntFrame)
        {
            gameObject.SendMessage("ReasignOriginalValues", OrigPosGunJumping);
            gameObject.SendMessage("ReasignOriginalRotValues", OrigRotGunJumping);
        }
        else if (!FPCStatus.IsJumping && FPCStatus.IsJumpingAntFrame && !FPCStatus.IsAiming)
        {
            if (FPCStatus.isRunning)
            {
                gameObject.SendMessage("ReasignOriginalValues", OrigPosGunRunning);
                gameObject.SendMessage("ReasignOriginalRotValues", OrigRotGunRunning);
            }
            else if (FPCStatus.isNormal)
            {
                gameObject.SendMessage("ReasignOriginalValues", OrigPosGunNormal);
                gameObject.SendMessage("ReasignOriginalRotValues", OrigRotGunNormal);
            }
        }
        else
        {
            if (FPCStatus.isRunning && !FPCStatus.IsJumping && !FPCStatus.IsAiming)
            {

                if (Mathf.Abs(HeadbobberGun.horigay) == 0 && Mathf.Abs(HeadbobberGun.vertigay) == 0)
                {
                    patras();
                }
               
                else
                {
                    
                        paraostia = false;
                        paraostia2 = false;
                        GunNormal3.localPosition = Vector3.Lerp(GunNormal3.localPosition, GunRunning.localPosition, 20 * Time.deltaTime);
                        GunNormal3.localRotation = Quaternion.Lerp(GunNormal3.localRotation, GunRunning.localRotation, 20 * Time.deltaTime);
                    
               }
            }

            //if (FPCStatus.isRunning && !FPCStatus.isRunningAntFrame) // ESTA MIERDA TELEPORTA EL ARMA PUNTO.
            //{

            //        GunNormal2.localPosition = Vector3.Lerp(GunNormal2.localPosition, GunRunning.localPosition, 20 * Time.deltaTime);
            // gameObject.SendMessage("ReasignOriginalValues", OrigPosGunRunning);
            // gameObject.SendMessage("ReasignOriginalRotValues", OrigRotGunRunning);
            // }
            else if (!FPCStatus.isRunning)
            {
                if (Vector3.Distance(GunNormal3.localPosition, OrigPosGunNormal3) < 0.001f)
                {
                    GunNormal3.localPosition = OrigPosGunNormal3;                   
                    paraostia = true;
                }
                if (rotacionarriba)
                {
                    if (Mathf.Abs(GunNormal3.localEulerAngles.x) < Mathf.Abs(OrigRotGunNormal3.x + 0.001f))
                    {
                        GunNormal3.localRotation = OrigRotGunNormal3;
                        paraostia2 = true;
                    }
                }
                if (!rotacionarriba)
                {
                    if (Mathf.Abs(GunNormal3.localEulerAngles.y) < Mathf.Abs(OrigRotGunNormal3.y + 0.001f))
                    {
                        GunNormal3.localRotation = OrigRotGunNormal3;
                        paraostia2 = true;
                    }
                }
                if (!paraostia)
                {
                    GunNormal3.localPosition = Vector3.Lerp(GunNormal3.localPosition, OrigPosGunNormal3, 20 * Time.deltaTime);
                }
                if (!paraostia2)
                {
                    GunNormal3.localRotation = Quaternion.Lerp(GunNormal3.localRotation, OrigRotGunNormal3, 20 * Time.deltaTime);
                }
            }
           // else  if ((FPCStatus.isNormal && !FPCStatus.isNormalAntFrame) && !FPCStatus.IsAiming)
          //  {
             //   gameObject.SendMessage("ReasignOriginalValues", OrigPosGunNormal);
            //    gameObject.SendMessage("ReasignOriginalRotValues", OrigRotGunNormal);
           // }
        }

        FPCStatus.isRunningAntFrame = FPCStatus.isRunning;
        FPCStatus.IsJumpingAntFrame = FPCStatus.IsJumping;
    }
    void patras()
    {
        if (Vector3.Distance(GunNormal3.localPosition, OrigPosGunNormal3) < 0.001f)
        {
            GunNormal3.localPosition = OrigPosGunNormal3;
            paraostia = true;
        }
        if (rotacionarriba)
        {
            if (Mathf.Abs(GunNormal3.localEulerAngles.x) < Mathf.Abs(OrigRotGunNormal3.x + 0.001f)) // esto lo hago xq la posicion chingona del trabuco al correr es vertical mientras que la del subfusigay es horizontal y eso que hay que diferenciarlo hostia. pepepepero falta el de la z tiiiiooooo KE TE CALLES LA BOCA JODER!
            {
                GunNormal3.localRotation = OrigRotGunNormal3;
                paraostia2 = true;
            }
        }
        if (!rotacionarriba)
        {
            if (Mathf.Abs(GunNormal3.localEulerAngles.y) < Mathf.Abs(OrigRotGunNormal3.y + 0.001f))
            {
                GunNormal3.localRotation = OrigRotGunNormal3;
                paraostia2 = true;
            }
        }

        if (!paraostia)
        {
            GunNormal3.localPosition = Vector3.Lerp(GunNormal3.localPosition, OrigPosGunNormal3, 20 * Time.deltaTime);
        }
        if (!paraostia2)
        {
            GunNormal3.localRotation = Quaternion.Lerp(GunNormal3.localRotation, OrigRotGunNormal3, 20 * Time.deltaTime);
        }
    }
}