using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour {

    public int vel = 3;
    public GameObject yocam;
    public GameObject yocam2;
    public GameObject yo;
    public GameObject yomismo;
    public GameObject spawn;
    public static bool vamos;
    public static bool tierra;
    public static bool Dale;
    public float tiempo;
    public Collider Box;
    public CharacterController control;
    void Start () {
        FPCStatus.accionando = false;
        Controlador.times = 0;
        tierra = true;
        vamos = true;
       // yo.GetComponent<Muevete2>().enabled = false;
        // yo.gameObject.GetComponent<Animator>().enabled = false;
        //  generar = GameObject.Find("generar");
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.W))
        {
            vamos = false;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            vamos = true;
        }


        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (tierra && !FPCStatus.accionando)
                {

                    if (vamos)
                    {
                        yo.GetComponent<CharacterMotor>().enabled = false;
                        control.enabled = false;
                        Box.enabled = false;
                        Controlador.times += 1;
                        yo.GetComponent<Movimiento>().enabled = false;
                        yocam2.GetComponent<MouseLook>().enabled = false;
                        yocam.GetComponent<MouseLook>().enabled = false;
                        yocam.GetComponent<lukat2>().enabled = true;
                        tierra = false;
                        yomismo.GetComponent<GO>().enabled = true;
                        //  Invoke("Deletethis", tiempo);
                        penes();

                    }
                }
                if (!vamos)

                {
                    Debug.Log("Lo siento tio");
                }

            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (tierra && !FPCStatus.accionando)
                {

                    if (vamos)
                    {
                        yo.GetComponent<CharacterMotor>().enabled = false;
                        control.enabled = false;
                        Box.enabled = false;
                        Controlador.times += 1;
                        yo.GetComponent<Movimiento>().enabled = false;
                        yocam2.GetComponent<MouseLook>().enabled = false;
                        yocam.GetComponent<MouseLook>().enabled = false;
                        yocam.GetComponent<lukat2>().enabled = true;
                        tierra = false;
                        yomismo.GetComponent<GO1>().enabled = true;
                        //  Invoke("Deletethis", tiempo);
                        penes();

                    }
                }
                if (!vamos)

                {
                    Debug.Log("Lo siento tio");
                }

            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (tierra && !FPCStatus.accionando)
                {

                    if (vamos)
                    {
                        yo.GetComponent<CharacterMotor>().enabled = false;
                        control.enabled = false;
                        Box.enabled = false;
                        Controlador.times += 1;
                        yo.GetComponent<Movimiento>().enabled = false;
                        yocam2.GetComponent<MouseLook>().enabled = false;
                        yocam.GetComponent<MouseLook>().enabled = false;
                        yocam.GetComponent<lukat2>().enabled = true;
                        tierra = false;
                        yomismo.GetComponent<GO3>().enabled = true;
                        penes();
                        //  Invoke("Deletethis", tiempo);

                    }
                }
                if (!vamos)

                {
                    Debug.Log("Lo siento tio");
                }

            }
        }






    }

  void penes()
    {
        Controlador.mestoylevantandojoder = true;
    }
    void Deletethis()
    {
        spawn.GetComponent<Teleport2>().enabled = true;
        Debug.Log("OH wow");
        //yo.gameObject.GetComponent<Animator>().enabled = false;
        //  transform.eulerAngles = new Vector3(0, 0, 0);
    }     


}
