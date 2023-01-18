using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recoilcam3 : MonoBehaviour {

    public float tiempoida;
    public float tiempoidaLAT;
    public float tiempovuelta;
    public float recarriba;
    public float recarribaNOAIM;
    public float recoilat;
    public float recuperabajo;
    public float recuperabajoNOAIM;
    public float recuperalateral;
    public float recuperalateralNOAIM;
    public float cosa;
    public float Smooth;
    public bool dual2 = false;

    private float velocityFov;
    private float jajaj = 1;
    private float jejej = 5;
    private bool recupera = false;
    private float timingay;
    private float timingay2;
    private float timingay3;
    private bool dale = false;
    private bool paraostia = false;
    private bool paraostia2 = false;
    private float distrec;
    private bool vamoh = true;
    [HideInInspector]
    public bool hedisparaosubnormal = false;

    void Start()
    {

    }


    void Update()
    {
        MouseLook.rotationX2 = Mathf.Clamp(MouseLook.rotationX2, 0, recoilat);
        if (FPCStatus.isShooting || FPCStatus.isShooting2 && dual2 || hedisparaosubnormal)
        {
            hedisparaosubnormal = false;
            vamoh = true;
            recupera = false;
            float pene = recoilat;
            pene /= 1.2f;
            float cojones = Random.Range(1, 101);
            if (cojones >= 51)
            {
                distrec = Random.Range(pene, recoilat); // esto hace el random pal lao derecho o el izquierdo
                distrec = -distrec;
            }
            if (cojones <= 50)
            {
                distrec = Random.Range(pene, recoilat);
            }
            timingay = 0;
            timingay2 = 0;
            timingay3 = 0;
            paraostia = false;
            paraostia2 = false;
            dale = true;
        }

        if (dale)
        {
            timingay += Time.deltaTime;
            timingay2 += Time.deltaTime;
            if (!paraostia)
            {
                if (timingay < tiempoida)
                {
                    if (FPCStatus.IsAiming)
                    {
                       // MouseLook.rotationY2 = recarriba;
                        MouseLook.rotationY2 = Mathf.Lerp(MouseLook.rotationY2, recarriba, Smooth * Time.deltaTime);
                    }
                    if (!FPCStatus.IsAiming)
                    {
                     //   MouseLook.rotationY2 = recarribaNOAIM;
                        MouseLook.rotationY2 = Mathf.Lerp(MouseLook.rotationY2, recarribaNOAIM, Smooth * Time.deltaTime);
                    }

                }

            }
            if (!paraostia2)
            {
                if (timingay2 < tiempoida)
                {
                    if (FPCStatus.IsAiming)
                    {
                        MouseLook.rotationX2 = Mathf.Lerp(MouseLook.rotationX2, distrec, Smooth * Time.deltaTime);
                     //   MouseLook.rotationX2 = distrec;
                    }
                    if (!FPCStatus.IsAiming)
                    {
                        distrec /= cosa;
                       // MouseLook.rotationX2 = distrec;
                        MouseLook.rotationX2 = Mathf.Lerp(MouseLook.rotationX2, distrec, Smooth * Time.deltaTime);
                    }

                }

            }
            if (recupera)
            {
                if (vamoh)
                {
                    timingay3 += Time.deltaTime;
                    if (FPCStatus.IsAiming)
                    {
                        //  MouseLook.rotationY2 = recuperabajo;
                        // MouseLook.rotationX2 = recuperalateral;
                        MouseLook.rotationX2 = Mathf.Lerp(MouseLook.rotationX2, recuperalateral, Smooth * Time.deltaTime);
                        MouseLook.rotationY2 = Mathf.Lerp(MouseLook.rotationY2, recuperabajo, Smooth * Time.deltaTime);
                    }
                    if (!FPCStatus.IsAiming)
                    {
                        //  MouseLook.rotationY2 = recuperabajoNOAIM;
                        //   MouseLook.rotationX2 = recuperalateralNOAIM;
                        MouseLook.rotationX2 = Mathf.Lerp(MouseLook.rotationX2, recuperalateralNOAIM, Smooth * Time.deltaTime);
                        MouseLook.rotationY2 = Mathf.Lerp(MouseLook.rotationY2, recuperabajoNOAIM, Smooth * Time.deltaTime);
                    }
                }
             }

            if (timingay > tiempoida)
            {
                paraostia = true;
                recupera = true;
            }
            if (timingay2 > tiempoidaLAT)
            {
                paraostia2 = true;
            }
            if (timingay3 > tiempovuelta)
            {
                
                vamoh = false;
                //  MouseLook.rotationX2 = 0;
                // MouseLook.rotationY2 = 0;
                
                    MouseLook.rotationX2 = Mathf.Lerp(MouseLook.rotationX2, 0, Smooth * Time.deltaTime);                               
                    MouseLook.rotationY2 = Mathf.Lerp(MouseLook.rotationY2, 0, Smooth * Time.deltaTime);


                if (Mathf.Abs(MouseLook.rotationX2) < 0.001f)
                {
                    MouseLook.rotationX2 = 0;
                }
                if (Mathf.Abs(MouseLook.rotationY2) < 0.001f)
                {
                    MouseLook.rotationY2 = 0;
                }


            }



            }
    }
}
