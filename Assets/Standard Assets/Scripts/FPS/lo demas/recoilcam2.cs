using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recoilcam2 : MonoBehaviour {

    public float tiempoida;
    public float tiempoida2;
    public float tiempovuelta;
    public float recabajo;
    public float recabajonoaim; //cosa3
    public float cosa4; //cosa4 es el factor pa dividir el recoil lateral desde apuntar a no apuntar porque va como el culo si lo dejas rapido y rollo sensibilidad y esas mierdas
    public float cosa2; //cosa2 es el movimiento pabajo después de disparar
    public float recoil; // recoil lateral
    private float distrec;

    private float tiempoidafinal;
    private float timingay;
    private float timingay2;
    private float timingay3;
    private float timingay4;
    private float cosa2orig;
    private bool dale = false;
    private bool paraostia = false;
    private bool paraostia2 = false;
    private bool paraostia3 = false;
    public static bool haybalasjoder;

    void Start () {
        dale = false;
        cosa2orig = cosa2;
        tiempoidafinal = tiempoida2;
        tiempoidafinal /= 1.6f;
        MouseLook.rotationX2 = 0;
    }

	void Update () {
        if (FPCStatus.isShooting)
        {
            paraostia2 = true;
            timingay3 = 0;
            timingay = 0;
           // timingay2 = 0;
            paraostia = false;
            paraostia3 = false;
            float pene = recoil;
            pene /= 1.2f;
            dale = true;
            float cojones = Random.Range(1, 101);
            if (cojones >= 51)
            {
                distrec = Random.Range(-pene, -recoil); // esto hace el random pal lao derecho o el izquierdo
            }
            if (cojones <= 50)
            {
                distrec = Random.Range(pene, recoil);
            }
            
        }
        if (dale)
        {
            timingay += Time.deltaTime;
            if (!paraostia)
            {
                timingay2 += Time.deltaTime;
                if (timingay2 < tiempoida2)
                {
                    if (FPCStatus.IsAiming)
                    {
                        MouseLook.rotationX2 = distrec; // esto asigna el puto movimiento lateral hasta que pasa el puto tiempo asignado, lo suyo es la mitad del tiempo de espera entre puta bala y puta bala
                    }
                    if (!FPCStatus.IsAiming)
                    {
                        distrec /= cosa4;
                        MouseLook.rotationX2 = distrec;
                    }
                }
            }
            if (!paraostia3)
            {
                if (timingay < tiempoida)
                {
                    if (FPCStatus.IsAiming)
                    {
                        MouseLook.rotationY2 = recabajo; // este es como el de arriba pero es rollo csgo que hay que mirar todo el rato pa abajo entonces pa subfusiles lo sullo es el tiempo de espera entre bala y bala ostia
                    }
                    if (!FPCStatus.IsAiming)
                    {
                        MouseLook.rotationY2 = recabajonoaim;
                    }
                }
            }
            if (timingay2 > tiempoida2)
            {
                paraostia = true;
                MouseLook.rotationX2 = 0;
                timingay2 = 0;
            }
            if (timingay > tiempoida)
            {
                paraostia3 = true;
                MouseLook.rotationY2 = 0;
                timingay = 0;
            }
        }

        if (Input.GetButton("Fire1"))
        {
            timingay4 += Time.deltaTime * Time.deltaTime * 50;
            timingay4 = Mathf.Clamp(timingay4, 0, 1);
        }

            if (!Input.GetButton("Fire1"))
        {
            pabajo();
        }
        if (!haybalasjoder)
        {
            pabajo();
        }
     }
    void pabajo() // esta mierda hace un movimiento pa abajo cuando sueltas el boton de disparar y se multiplica entre 0 y 1 el valor ese de mierda segun el tiempo que hayas estado puto disparando joder
    {
        if (paraostia2)
        {
            cosa2 = cosa2orig;
            cosa2 *= timingay4;
            timingay4 = 0.1f;
            paraostia2 = false;
        }

        if (dale)
        {
            timingay3 += Time.deltaTime;
            if (timingay3 < tiempovuelta)
            {
                if (timingay2 > tiempoidafinal) //
                {                           //
                    MouseLook.rotationX2 = 0;// Si quieres quitar esta mierda lo que harás es que al disparar individualmente nada más soltar el puto botón el recoil en la x se para y eso, con esto pues hace el puto recoil hasta el tiempo asignado y luego para PUNTO.
                }                            //
                //MouseLook.rotationX2 = 0; 
                MouseLook.rotationY2 = cosa2;
            }
            if (timingay3 > tiempovuelta)
            {
                MouseLook.rotationX2 = 0;
                MouseLook.rotationY2 = 0;
                dale = false;
            }
        }
    }

}
