using UnityEngine;

public enum AxisCam
{
    X = 0,
    Y = 1,
    XY = 2
}

public class HeadbobberGun : MonoBehaviour
{
    public AxisCam AxisMov = AxisCam.X;
    public float bobbingSpeed = 8;
    public Vector2 bobbingAmount = new Vector2(0.1f, 0.05f);
    public float RecoilAmount = 0.1f;
    public float RecoilAmountMax = -0.2f;
    public float RotationAmount = 0.1f;
    public float RecoilRandomDispl = 0.1f;
    public float RotRandomDispl = 0.1f;
    public float bobbingRunSpeed = 12;
    private float OrigbobbingSpeed = 8;
    private Vector2 OrigbobbingAmount = new Vector2(0.1f, 0.05f);
    private float OrigRecoilAmount = 0.1f;
    private float OrigRecoilRandomDispl = 0.1f;
    public Vector2 HorizDispl = new Vector2(0.1f, 0.1f); // Desplazamiento horizontal del arma cuando te mueves a los lados
    public Vector2 VertDispl = new Vector2(0.1f, 0.1f); // Desplazamiento Vertical del arma cuando te avanzas/retrocedes
    private Vector2 OrigHorizDispl = Vector2.zero;
    private Vector2 OrigVertDispl = Vector2.zero;
    public bool DisableIfAiming = false;
    public float tiempoida;
    public float tiempopavolver = 0.07f;
    public float velosidapalla;
    public float velosidapallaNOAIM = 40;
    public float velosidapavuelta;
    public float velosidapavueltaNOAIM;
    public float velosidapallaROT;
    public float velosidapavueltaROT;
    public float vueltaNORECOIL = 10;

    private bool jejnormal = true;
    private float midpointX;
    private float midpointY;
    private float midpointX2;
    private float midpointY2;
    private float midpointDisplX;
    private float midpointDisplY;
    private Vector3 MyPos;
    private Vector3 MyPos2;
    private Quaternion MyRot;
    private Vector3 palla;
    private float timerX;
    private float timerY;
    private Transform Gun;
    private Transform Guneado;
    private Transform Gun2;
    private Transform GunRecoilgay;
    private Vector3 GunOriginalPosition;
    private Vector3 GunOriginalPosition2;
    private Vector3 Gunaima;
    private bool Recoil;
    private bool InmediateReturn;
    private GunStatus GunStatusScript;
    private Quaternion origrot;
    private Quaternion alla;
    private float lol;
    private float lel;
    private float timergay = 0;
    public float timergay2 = 0.9f;
    private bool parese = false;
    private float ultimoh;
    private float ultimov;
    public static float horigay;
    public static float vertigay;
    public static float vertigay2;
    private bool pollas;
    private float eldelta = 0.013f;
    [HideInInspector]
    public bool disparo2 = false;
    [HideInInspector]
    public bool hadisparao = false;

    // Asignar los valores iniciales de bob del arma. 
    // Al correr el desplazamiento del arma tambien cambia.
    // Al apuntar el arma se desplaza y estos valores cambian. SE llama desde la funcion AimDownSights
    public void ReasignOriginalValues(Vector3 NewGunPos)
    {
        GunOriginalPosition = NewGunPos;
        if (AxisMov == AxisCam.X)
        {
            midpointX = NewGunPos.x;
        }
        else if (AxisMov == AxisCam.Y)
        {
            midpointY = NewGunPos.y;
        }
        else if (AxisMov == AxisCam.XY)
        {
            midpointX = NewGunPos.x;
            midpointY = NewGunPos.y;
        }
    }

    public void ReasignOriginalValues2(Vector3 NewGunPos2)
    {
        GunOriginalPosition2 = NewGunPos2;
        if (AxisMov == AxisCam.X)
        {
            midpointX2 = NewGunPos2.x;
        }
        else if (AxisMov == AxisCam.Y)
        {
            midpointY2 = NewGunPos2.y;
        }
        else if (AxisMov == AxisCam.XY)
        {
            midpointX2 = NewGunPos2.x;
            midpointY2 = NewGunPos2.y;
        }
    }

    // Pasa lo mismo que con la posicion. La rotacion del arma cambiar entre andar, correr y apuntar.
    public void ReasignOriginalRotValues(Quaternion NewGunRot)
    {
        if (Gun != null)
        {
            Gun.localRotation = NewGunRot;
        }
    }

    // Restaura los valores originales de bob (andando)
    public void RestoreBobbingValues()
    {
        bobbingSpeed = OrigbobbingSpeed;
        bobbingAmount = OrigbobbingAmount;
        RecoilAmount = OrigRecoilAmount;
        RecoilRandomDispl = OrigRecoilRandomDispl;
    }

    void OnEnable()
    {
        MouseLook.rotationX2 = 0;
        MouseLook.rotationY2 = 0;
        lol = RecoilRandomDispl;
        lol /= 2;
    }
    void Start()
    {
        GunStatusScript = GetComponent<GunStatus>();
        Gun = GunStatusScript.GunNormal;
        Guneado = GunStatusScript.GunRecoil;
        GunRecoilgay = GunStatusScript.GunRecoil;
        //Gunaima = GunStatusScript.GunNormal.localPosition; ME LOS HE CARGAO PORQUE SE BUGIA
        Gun2 = GunStatusScript.GunNormal2;
        ReasignOriginalValues(GunStatusScript.OrigPosGunNormal);
        ReasignOriginalValues2(GunStatusScript.OrigPosGunNormal2);
        OrigbobbingSpeed = bobbingSpeed;
        OrigbobbingAmount = bobbingAmount;
        OrigRecoilAmount = RecoilAmount;
        OrigRecoilRandomDispl = RecoilRandomDispl;
        OrigHorizDispl = HorizDispl;
        OrigVertDispl = VertDispl;
        // origrot = Gun.localRotation; ESTE TAMBIEN SE BUGIA
        origrot = Guneado.localRotation;
        Gunaima = Vector3.zero;
        alla = GunStatusScript.Recoilrot;
    }


    void Update()
    {
        if (Time.timeScale != 1)
        {
            eldelta = Time.deltaTime;
        }
        if (Time.timeScale == 1)
        {
            eldelta = 0.013f;
        }
        if (Time.timeScale == 0 || Pausa.Pa.dentro) { return; }

        float wavesliceX = 0f;
        float wavesliceY = 0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        vertigay2 = vertical;
        if (Mathf.Abs(horizontal) > Mathf.Abs(ultimoh)) horigay = 1;
        if (Mathf.Abs(horizontal) < Mathf.Abs(ultimoh)) horigay = 0;
        if (Mathf.Abs(vertical) > Mathf.Abs(ultimov)) vertigay = 1;
        if (Mathf.Abs(vertical) < Mathf.Abs(ultimov)) vertigay = 0;
        ultimoh = horizontal;
        ultimov = vertical;
        MyPos = Gun.localPosition;
        MyPos2 = Gun2.localPosition;
        //Debug.Log(vertigay);

        // Si estamos disparando centro el arma y activo el retroceso del arma.
            if (FPCStatus.isShooting && !GunStatusScript.dual || FPCStatus.isShooting && GunStatusScript.dual && GunStatusScript.arma2 != null || GunStatusScript.dual && FPCStatus.isShooting2 && GunStatusScript.arma2 == null || hadisparao)
            {
            if (hadisparao)
            {
                FPCStatus.isShooting = true;
                if (GetComponent<recoilcam3>() != null)
                {
                    GetComponent<recoilcam3>().hedisparaosubnormal = true;
                }
                
            }
            hadisparao = false;
            pollas = true;
            alla.y = 0;
            MyRot.x = 0;
            MyRot.y = 0;
            MyRot.z = 0;
            lol = RecoilRandomDispl;
            lol /= 1.22f;
            lel = RotRandomDispl;
            lel /= 1.22f;
            parese = true;
            AssignCurrentValues(midpointX, midpointY);
            int pene = Random.Range(1, 100);
            int polla = Random.Range(1, 100);
            if (pene <= 50)
            {
                MyPos.x = MyPos.x + Random.Range(lol, RecoilRandomDispl);
                MyRot.y = MyRot.y + Random.Range(lel, RotRandomDispl);
                alla.y = alla.y + Random.Range(lel, RotRandomDispl);
            }
            if (pene >= 51)
            {
                MyPos.x = MyPos.x + Random.Range(-lol, -RecoilRandomDispl);
                MyRot.y = MyRot.y + Random.Range(-lel, -RotRandomDispl);
                alla.y = alla.y + Random.Range(-lel, -RotRandomDispl);
            }
            if (polla <= 50)
            {
                MyPos.y = MyPos.y + Random.Range(lol, RecoilRandomDispl);
            }
            if (polla >= 51)
            {
                MyPos.y = MyPos.y + Random.Range(-lol, -RecoilRandomDispl);
            }

            //  MyRot.x = MyRot.x + RotationAmount;
            MyPos.z = MyPos.z - RecoilAmount;
            if (FPCStatus.IsAiming)
            {
                if (MyPos.z < RecoilAmountMax) MyPos.z = RecoilAmountMax;
            }
            if (!FPCStatus.IsAiming)
            {
                if (MyPos.z < RecoilAmountMax) MyPos.z = RecoilAmountMax;
            }
            palla = MyPos;
            if (!Recoil)
            {
                Recoil = true;
            }
            timerX = 0f;
            timerY = 0f;
            return;
        }


        // Si se apunta se mira si hay que desactivar el balanceo y no se permite el desplazamiento horizontal/vertical del arma.
        if (FPCStatus.IsAiming)
        {
            if (this.DisableIfAiming) { return; } // Desactivar balanceo si asi esta configurado.
            HorizDispl = Vector2.zero; // No hay desplazamiento del arma.
            VertDispl = Vector2.zero;
        }
        else
        {
            HorizDispl = OrigHorizDispl;    // Se asigna el nuevo desplazamiento del arma.
            VertDispl = OrigVertDispl;
        }

        // Calculo los MidPoint y waveslice para posicionar el arma.

        if (Mathf.Abs(horigay) == 0 && Mathf.Abs(vertigay) == 0)
        {
            midpointDisplX = midpointX;
            midpointDisplY = midpointY;
            timerX = 0f;
            timerY = 0f;
            if (Recoil && !parese && jejnormal)
            {
                Gun.localPosition = Vector3.Lerp(Gun.localPosition, GunOriginalPosition, (3 * eldelta) * Time.deltaTime / 0.013f);
                if (Vector3.Distance(Gun.localPosition, GunOriginalPosition) < 0.001f)
                {
                    Gun.localPosition = GunOriginalPosition;
                    Recoil = false;
                }
            }
        }
        else
        {
            // Dependiendo del movimiento de raton en X, asigno el desplazamiento horizontal (positivo o negativo)
            if (jejnormal)
            {
                if (horizontal > 0)
                {
                    midpointDisplX = midpointX + HorizDispl.x;
                }
                else if (horizontal < 0)
                {
                    midpointDisplX = midpointX - HorizDispl.y;
                }
                else if (horizontal == 0)
                {
                    midpointDisplX = midpointX;
                }

                // Dependiendo del movimiento de raton en X, asigno el desplazamiento vertical (positivo o negativo)
                if (vertical > 0)
                {
                    midpointDisplY = midpointY - VertDispl.x;
                }
                else if (vertical < 0)
                {
                    midpointDisplY = midpointY + VertDispl.y;
                }
                else if (vertical == 0)
                {
                    midpointDisplY = midpointY;
                }

                // Calculo los tiempos del desplazamiento, tomando como referencia la vecidad elegida del bob.
                wavesliceX = Mathf.Sin(timerX);
                timerX = timerX + (bobbingSpeed * Time.deltaTime);
                if (timerX > (Mathf.PI * 2))
                {
                    timerX = timerX - (Mathf.PI * 2);
                }
                wavesliceY = Mathf.Sin(timerY);
                timerY = timerX * 2;
                if (timerY > (Mathf.PI * 2))
                {
                    timerY = timerY - (Mathf.PI * 2);
                }
            }
        }
        // Calculo los TranslateChange (desplazamientos)  para posicionar el arma, basandome en los valores
        // de waveslice y midpoint.
        if (wavesliceX != 0 || wavesliceY != 0)
        {
            float translateChangeX = wavesliceX * this.bobbingAmount.x;
            float totalAxesX = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxesX = Mathf.Clamp01(totalAxesX);
            translateChangeX = totalAxesX * translateChangeX;

            float translateChangeY = wavesliceY * this.bobbingAmount.y;
            float totalAxesY = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxesY = Mathf.Clamp01(totalAxesY);
            translateChangeY = totalAxesY * translateChangeY;

            AssignCurrentValues(midpointDisplX + translateChangeX, midpointDisplY + translateChangeY);
        }
        else
        {
            AssignCurrentValues(midpointDisplX, midpointDisplY);
        }
        // Posiciono el arma interpolando hacia la posicion final que he calculado.
        if (!Input.GetButton("Fire1"))
        {

            if (!FPCStatus.isRunning && GunStatusScript.Armasgays != Armasgaystipos.Duales1 && !FPCStatus.isRunning && GunStatusScript.Armasgays != Armasgaystipos.Duales2)
            {
                timergay2 += Time.deltaTime;
            }
            if (!FPCStatus.isRunning && GunStatusScript.Armasgays == Armasgaystipos.Duales1 && GunStatusScript.arma2 != null)
            {
                timergay2 += Time.deltaTime;
            }
        }
        if (!GunStatusScript.semiautomatica)
        {
            if (pollas && FPCStatus.especial)
            {
                timergay2 = 0;
                pollas = false;
            }
            if (Input.GetButton("Fire1"))
            {
                if (!FPCStatus.isRunning && FPCStatus.haybalas && GunStatusScript.Armasgays != Armasgaystipos.Duales1 || !FPCStatus.isRunning && FPCStatus.haybalas && GunStatusScript.Armasgays != Armasgaystipos.Duales2)
                {
                    timergay2 = 0;
                }
                if (!FPCStatus.haybalas && GunStatusScript.Armasgays == Armasgaystipos.Duales1 || !FPCStatus.haybalas && GunStatusScript.Armasgays == Armasgaystipos.Duales2)
                {
                     timergay2 += 0.1f;
                }
            }
        }
        if (GunStatusScript.semiautomatica)
        {
            
            timergay2 += Time.deltaTime;
            if (Input.GetButton("Fire1") && !FPCStatus.isRunning && pollas && GunStatusScript.BalasActualesEnCargador > 0)
            {
                if (GunStatusScript.Armasgays != Armasgaystipos.Duales1)
                {
                    Gun.localPosition = Vector3.zero;
                }
                else if (GunStatusScript.arma2 != null)
                {
                    Gun.localPosition = Vector3.zero;
                }
                //Debug.Log("TU PUTA MADRE");
                if (!FPCStatus.isRunning && pollas && GunStatusScript.Armasgays != Armasgaystipos.Duales1)
                {
                    
                    timergay2 = 0;
                    pollas = false;
                }
               

                    timergay2 = 0;
                    pollas = false;
                

            }
        }
        if (!Input.GetButton("Fire2") && GunStatusScript.Armasgays == Armasgaystipos.Duales1 && GunStatusScript.arma2 == null)
        {

            if (!FPCStatus.isRunning)
            {
                timergay2 += Time.deltaTime;
            }
            
        }
        if (!GunStatusScript.semiautomatica)
        {
            if (Input.GetButton("Fire2"))
            {
                if (!FPCStatus.isRunning && FPCStatus.haybalas)
                {
                  //  timergay2 = 0;
                    
                }
                
            }
            
        }

        if (FPCStatus.IsAiming)
        {
            Gun.localPosition = Vector3.zero;
        }

        if (GunStatusScript.semiautomatica && GunStatusScript.Armasgays == Armasgaystipos.Duales1 && GunStatusScript.arma2 == null || GunStatusScript.semiautomatica && GunStatusScript.Armasgays == Armasgaystipos.Duales2 && GunStatusScript.arma2 == null)
        {

            timergay2 += Time.deltaTime;
            if (Input.GetButton("Fire2") && !FPCStatus.isRunning && pollas && FPCStatus.haybalas || disparo2 && !FPCStatus.isRunning && GunStatusScript.Armasgays == Armasgaystipos.Duales2 && GunStatusScript.arma2 == null)
            {
               
                    Gun.localPosition = Vector3.zero;

              
                

                    timergay2 = 0;
                    pollas = false;
                    disparo2 = false;

                //
            }
        }



        if (Vector3.Distance(GunRecoilgay.localPosition, Gunaima) < 0.001f)
        {
            GunRecoilgay.localPosition = Gunaima;

        }
        if (!FPCStatus.IsAiming)
        {
            if (parese)
            {
                timergay += Time.deltaTime;
                GunRecoilgay.localPosition = Vector3.Lerp(GunRecoilgay.localPosition, palla, (velosidapallaNOAIM * eldelta) * (Time.deltaTime / 0.013f));
                GunRecoilgay.localRotation = Quaternion.Lerp(GunRecoilgay.localRotation, alla, (velosidapallaROT * eldelta) * (Time.deltaTime / 0.013f));
            }
            if (timergay >= tiempoida)
            {
                parese = false;
                timergay = 0;
            }
            if (!parese)
            {
                if (timergay2 > tiempopavolver)
                {
                    GunRecoilgay.localRotation = Quaternion.Lerp(GunRecoilgay.localRotation, origrot, (velosidapavueltaROT * eldelta) * (Time.deltaTime / 0.013f));
                    GunRecoilgay.localPosition = Vector3.Lerp(GunRecoilgay.localPosition, Gunaima, (vueltaNORECOIL * eldelta) * (Time.deltaTime / 0.013f));
                    // Gun.localPosition = Vector3.Lerp(Gun.localPosition, GunOriginalPosition, 5 * Time.deltaTime);
                    Gun.localPosition = Vector3.Lerp(Gun.localPosition, MyPos, (5 * eldelta) * (Time.deltaTime / 0.013f));
                    GunRecoilgay.localRotation = Quaternion.Lerp(GunRecoilgay.localRotation, origrot, velosidapavueltaROT * eldelta);
                    jejnormal = true;
                }
                if (timergay2 < tiempopavolver)
                {
                    GunRecoilgay.localPosition = Vector3.Lerp(GunRecoilgay.localPosition, GunOriginalPosition, (velosidapavueltaNOAIM * eldelta) * (Time.deltaTime / 0.013f));
                    GunRecoilgay.localRotation = Quaternion.Lerp(GunRecoilgay.localRotation, origrot, (velosidapavueltaROT * eldelta) * (Time.deltaTime / 0.013f));
                    if (!FPCStatus.isRunning)
                    {
                        jejnormal = false;
                    }
                }
            }
        }
        if (FPCStatus.isRunning)
        {
            timergay2 = 1;
            jejnormal = true;
        }

        if (FPCStatus.IsAiming)
        {
            if (parese)
            {
                //aquí la envío a la posición del puto recoil, lo del recoil esta en la 161 BOOORJA
                timergay += Time.deltaTime;
                Vector3 newPosition = GunRecoilgay.transform.localPosition;
                Vector3 newPosition2 = GunRecoilgay.transform.localPosition;
                timergay += Time.deltaTime;
                newPosition = Vector3.Lerp(newPosition, palla, (velosidapalla * eldelta) * (Time.deltaTime / 0.013f)); // cosas mmias jej original por si acaso subnormal Gun.localPosition = Vector3.Lerp(Gun.localPosition, palla, velosidapalla * Time.deltaTime);                
                newPosition2 = Vector3.Lerp(newPosition2, palla, (70 * eldelta) * (Time.deltaTime / 0.013f));
                newPosition.z = newPosition2.z;
                GunRecoilgay.localPosition = newPosition;
                GunRecoilgay.localRotation = Quaternion.Lerp(GunRecoilgay.localRotation, alla, (velosidapallaROT * eldelta) * (Time.deltaTime / 0.013f));

            }
            if (timergay >= tiempoida)
            {
                parese = false;
                timergay = 0;
            }
            if (!parese)
            {
                if (timergay2 > tiempopavolver)
                {
                    //este es para volver a la posición del aim pero a una velociad de la de no recoil tu ya sabes tio xq es una mierda esa y eso
                    Vector3 apollas = GunRecoilgay.transform.localPosition;
                    Vector3 apollas2 = GunRecoilgay.transform.localPosition;
                    apollas = Vector3.Lerp(apollas, MyPos, (10 * eldelta) * (Time.deltaTime / 0.013f)); //basura Gun.localPosition = Vector3.Lerp(Gun.localPosition, MyPos, velosidapavuelta * Time.deltaTime);
                    apollas2 = Vector3.Lerp(apollas2, MyPos, (10 * eldelta) * (Time.deltaTime / 0.013f));
                    apollas.z = apollas2.z;
                    Gun.localPosition = apollas;
                    // meh Gun.localPosition = Vector3.Lerp(Gun.localPosition, MyPos, 5 * Time.deltaTime);
                    jejnormal = true;
                    Gun.localRotation = Quaternion.Lerp(Gun.localRotation, origrot, (velosidapavueltaROT * eldelta) * (Time.deltaTime / 0.013f));
                    GunRecoilgay.localRotation = Quaternion.Lerp(GunRecoilgay.localRotation, origrot, (velosidapavueltaROT * eldelta) * (Time.deltaTime / 0.013f));
                    GunRecoilgay.localPosition = Vector3.Lerp(GunRecoilgay.localPosition, Gunaima, (vueltaNORECOIL * eldelta) * (Time.deltaTime / 0.013f));
                }
                if (timergay2 < tiempopavolver)
                {
                    //lo que hago pa volver a la posición del puto aim despu´´es de disparar ostia
                    Vector3 apollas = GunRecoilgay.transform.localPosition;
                    Vector3 apollas2 = GunRecoilgay.transform.localPosition;
                    apollas = Vector3.Lerp(apollas, Gunaima, (velosidapavuelta * eldelta) * (Time.deltaTime / 0.013f)); //basura Gun.localPosition = Vector3.Lerp(Gun.localPosition, MyPos, velosidapavuelta * Time.deltaTime);
                    apollas2 = Vector3.Lerp(apollas2, Gunaima, (30 * eldelta) * (Time.deltaTime / 0.013f));
                    apollas.z = apollas2.z;
                    GunRecoilgay.localPosition = apollas;
                    GunRecoilgay.localRotation = Quaternion.Lerp(GunRecoilgay.localRotation, origrot, (velosidapavueltaROT * eldelta) * (Time.deltaTime / 0.013f));
                    if (!FPCStatus.isRunning)
                    {
                        jejnormal = false;
                    }
                }
            }
        }
        if (Input.GetButton("Fire1") && !FPCStatus.isRunning && pollas && FPCStatus.haybalas && !FPCStatus.dual)
        {
            Gun.localPosition = Vector3.zero;
        }
        else if (Input.GetButton("Fire1") && !FPCStatus.isRunning && pollas && FPCStatus.haybalas && FPCStatus.dual && GunStatusScript.arma2 != null)
        {
            Gun.localPosition = Vector3.zero;
        }
        }

    private void AssignCurrentValues(float PosX, float PosY)
    {
        if (AxisMov == AxisCam.X)
        {
            MyPos.x = PosX;
        }
        else if (AxisMov == AxisCam.Y)
        {
            MyPos.y = PosY;
        }
        else if (AxisMov == AxisCam.XY)
        {
            MyPos.x = PosX;
            MyPos.y = PosY;
        }
    }

    private void AssignCurrentValues2(float PosdosX, float PosdosY)
    {
        if (AxisMov == AxisCam.X)
        {
            MyPos2.x = PosdosX;
        }
        else if (AxisMov == AxisCam.Y)
        {
            MyPos2.y = PosdosY;
        }
        else if (AxisMov == AxisCam.XY)
        {
            MyPos2.x = PosdosX;
            MyPos2.y = PosdosY;
        }
    }

}