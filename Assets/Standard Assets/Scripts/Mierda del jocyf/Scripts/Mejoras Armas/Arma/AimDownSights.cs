using UnityEngine;

public class AimDownSights : MonoBehaviour
{
    public bool activao = false;
    public float multsens = 1;
    public Camera camaritawey;
    public Camera camaritawey2;
    private Transform Gun;
    private Transform AimPos;
    [Range(10, 100)]
    public float AimFov = 40f;
    private float velocityFov;
    [Range(1, 50)]
    public float SmoothTime = 20;
    [Range(1, 50)]
    public float SmoothTimeAim = 20;
    [Range(1, 20)]
    public float AimedWalkSpeed = 2;
    public Vector2 AimedSensitivity = new Vector2(2, 2);
    private float AimedOrigWalkSpeed = 6;
    private Vector2 AimedOrigSensitivity = new Vector2(15, 10);
    public Vector2 AimBobblingAmount = new Vector2(0.1f, 0.05f);
    [Range(1, 20)]
    public float AimBobblingSpeed = 8;
    [Range(0.001f, 1)]
    public float AimRecoilAmount = 0.1f;
    [Range(0.001f, 1)]
    public float AimRecoilRandomDispl = 0.1f;

    private Vector3 AimOriginalPos;
    private bool paraostia = false;
    private Quaternion AimOriginalRot;
    private Vector3 AimTempPos = Vector3.zero;
    private Quaternion AimTempRot = Quaternion.identity;
    private float AimTempFov;

    private GameObject MiFPC;
    private HeadbobberGun BobberGun;
    private GunStatus GunStatusScript;

    private CharacterMotor cm;
    private MouseLook myMouseLookSrc;
    private MouseLook camMouseLookSrc;



    // Inicializo las variables que necesito para realizar todas las operaciones.
    void Awake()
    {
        if (camaritawey != null)
        {
            camaritawey.enabled = true;
            camaritawey2.enabled = true;
        }
        //Camera.main.fieldOfView = DisparoSelectivo.originalfov;
        FPCStatus.IsAiming = false;
        MouseLook.mult = 1;

    }
    public void ActualizarFOV()
    {
        if (gameObject.GetComponent<AimDownSights>().isActiveAndEnabled == true)
        {
            //AimTempFov = DisparoSelectivo.originalfov;
            if (FPCStatus.IsAiming)
            {
                AimTempFov = Controlador.fov - (90 - AimFov);
            }
            else
            {
                AimTempFov = Controlador.fov;
            }
            
        }
        else
        {
            Camera.main.fieldOfView = Controlador.fov;
        }
    }
    void OnEnable()
    {
        AimTempFov = DisparoSelectivo.originalfov;
        FPCStatus.IsAiming = false;
        MouseLook.mult = 1;
        Invoke("pollasgays", 0.03f);
    }
    void pollasgays()
    {
        FPCStatus.IsAiming = false;
        MouseLook.mult = 1;
    }
    void Start()
    {
        float xgay = AimedSensitivity.x / 3;
        float ygay = AimedSensitivity.y / 3;

        AimedSensitivity = new Vector2(xgay * Controlador.sensibilidad, ygay * Controlador.sensibilidad);

        FPCStatus.IsAiming = false;
        Camera.main.fieldOfView = DisparoSelectivo.originalfov;
        MiFPC = GameObject.Find("FPC");
        BobberGun = GetComponentInChildren<HeadbobberGun>();
        GunStatusScript = GetComponent<GunStatus>();
        
        myMouseLookSrc = MiFPC.GetComponent<MouseLook>();
        AimedOrigSensitivity.x = Controlador.sensibilidad;

        camMouseLookSrc = Camera.main.GetComponent<MouseLook>();
        AimedOrigSensitivity.y = Controlador.sensibilidad;

        cm = MiFPC.GetComponent<CharacterMotor>();
        AimedOrigWalkSpeed = cm.movement.maxForwardSpeed;
        Gun = GunStatusScript.GunNormal2;
        AimPos = GunStatusScript.GunAiming;

        // Guardo los valores originales de todas las opciones de las armas, para poder cambiar el arma
        // entre unas posiciones (arma normal) y otras (arma apuntando).
        AimOriginalPos = GunStatusScript.GunNormal2.localPosition;
        AimOriginalRot = GunStatusScript.GunNormal2.localRotation;
        AimTempPos = AimOriginalPos;
        AimTempRot = AimOriginalRot;
        AimTempFov = DisparoSelectivo.originalfov;
    }

    
    void Update()
    {
        if (Time.timeScale == 0 || Pausa.Pa.dentro) { return; }

        Gun.localPosition = Vector3.Lerp(Gun.localPosition, AimTempPos, SmoothTime * Time.deltaTime);
        Gun.localRotation = Quaternion.Lerp(Gun.localRotation, AimTempRot, SmoothTime * Time.deltaTime);
        //Debug.Log("Pos Arma : "+Gun.localPosition+" - Pos Temp Aim : "+AimTempPos);
        Camera.main.fieldOfView = Mathf.SmoothDamp(Camera.main.fieldOfView, AimTempFov, ref velocityFov, SmoothTimeAim * 0.0065f);

        if (!activao) { return; }

        Vector2 AimedSensitivitygay = new Vector2(0.6f, 0.6f);
      //  AimedSensitivity = AimedSensitivitygay;
        if (!FPCStatus.IsFire2Pressed && Camera.main.fieldOfView != DisparoSelectivo.originalfov)
        {
            FPCStatus.IsAiming = false;
            MouseLook.mult = 1;
            //Camera.main.fieldOfView = AimOriginalFov;
        }
        if (FPCStatus.IsAiming && activao)
        {
            ApplyAimBobbingValues();
        }
        if (!FPCStatus.IsAiming && activao) // ESTO LO HE PUESTO YO XQ HE TOCAO COSAS Y NO FUNSIONA LO DEL !BOBBERGUN.ENABLED ASI QUE AQUI LO PONGO JEJ CHUPAMELA
        {
            if (paraostia)
            {
                BobberGun.RestoreBobbingValues();
                paraostia = false;
            }
            }
        // Realiza el movimiento del arma hasta que el FOV de la camara ya es casi el FOV final.
        if (Gun == null)
        {

        }
           
        

        // Si ya casi ha acabado con el movimiento, muevo directamente el arma a su punto de destino y asigno nuevos valores de BOB
        // en la funcion de aputar. Esto solo se hace una vez (mirando si el script de apuntar esta desactivado).
         if (!BobberGun.enabled && activao)
        {
            Gun.localPosition = AimTempPos;
            Camera.main.fieldOfView = AimTempFov;
            if (FPCStatus.IsAiming)
            {
                BobberGun.ReasignOriginalValues2(AimPos.localPosition);
                ApplyAimBobbingValues();
            }
            else
            {
                BobberGun.ReasignOriginalValues2(AimOriginalPos);
                BobberGun.RestoreBobbingValues();
            }

            BobberGun.enabled = true;
        }

        // Si pulso la tecla del raton, inicia el proceso de movimiento del arma a la posicion de apuntando.
        // Desactivo el script de Aiming para que no interfiera hasta que acabe de mover el arma a su nueva posicion.
        if (FPCStatus.IsFire2Pressed && !FPCStatus.isRunning && !FPCStatus.transicion && !FPCStatus.melee && activao && !FPCStatus.isReloading)
        {
            paraostia = true;
            FPCStatus.IsAiming = true;
            MouseLook.mult = (Controlador.fov / 90) * multsens;
            // BobberGun.enabled = false; no lo necesitas más puta zorrilla

            //adjust viewpoint and Gun position
            AimTempPos = AimPos.localPosition;
            AimTempRot = AimPos.localRotation;
            //float sex = (90 - AimFov) 
            AimTempFov = Controlador.fov - (90 - AimFov);

            //slow down turning and movement speed
            cm.movement.maxForwardSpeed = AimedWalkSpeed;
            MouseLook.sensitivityX = AimedSensitivity.x;
            MouseLook.sensitivityY = AimedSensitivity.y;
        }
        else if (FPCStatus.IsFire2Up && activao)    // Al soltar el boton, vuelve a la posicion normal.
        {
            
            FPCStatus.IsAiming = false;
            MouseLook.mult = 1;
            //  BobberGun.enabled = false; no lo necesitas más puta zorrilla

            //adjust viewpoint and Gun position
            AimTempPos = AimOriginalPos;
            AimTempRot = AimOriginalRot;
            AimTempFov = DisparoSelectivo.originalfov;

            //speed up turning and movement speed
            cm.movement.maxForwardSpeed = AimedOrigWalkSpeed;
            MouseLook.sensitivityX = AimedOrigSensitivity.x;
            MouseLook.sensitivityY = AimedOrigSensitivity.y;
        }
    }

    
    private void ApplyAimBobbingValues()
    {
        BobberGun.bobbingSpeed = AimBobblingSpeed;
        BobberGun.bobbingAmount = AimBobblingAmount;
        BobberGun.RecoilAmount = AimRecoilAmount;
        BobberGun.RecoilRandomDispl = AimRecoilRandomDispl;
    }
   
    public void restablecer()
    {
        AimTempPos = AimOriginalPos;
        AimTempRot = AimOriginalRot;
        AimTempFov = DisparoSelectivo.originalfov;

        MouseLook.mult = 1;
        MouseLook.sensitivityX = Controlador.sensibilidad;
        MouseLook.sensitivityY = Controlador.sensibilidad;
    }
}