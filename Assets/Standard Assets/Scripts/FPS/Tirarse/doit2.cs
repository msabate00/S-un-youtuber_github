using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doit2 : MonoBehaviour {
    public GameObject yo;
    public GameObject yo2;
    public GameObject yo3;
    public GameObject teleport;
    public CharacterController control;
    public float timepenis;
    public float timedicks;
    [HideInInspector]
    public string tipomierda;
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Animaciones.Ahora == true) {

            Invoke("pene", timepenis);           

        }

        if (Animaciones.Ahorayo == true)
        {

            teleport.GetComponent<Teleport8>().tipodeloscojones = tipomierda;
            teleport.GetComponent<Teleport8>().enabled = true;
            
        }


    }
    void pene ()
    {
        yo3.GetComponent<Raycastman2>().enabled = true;
    }
    void OnEnable () {
        Invoke("emergencia", timedicks);
        yo2.GetComponent<lukat4>().enabled = true;
        yo2.GetComponent<Woa>().enabled = true;
        yo3.GetComponent<Mierda1>().enabled = true;
        yo3.GetComponent<Mierda>().enabled = false;
        yo3.GetComponent<lukat5>().enabled = true;
        yo3.GetComponent<MouseLook>().enabled = false;
        yo2.GetComponent<MouseLook>().enabled = false;
        yo2.GetComponent<CharacterMotor>().enabled = false;
        control.enabled = false;
        // yo2.GetComponent<Movimiento>().enabled = false;

    }
    void emergencia()
    {
        yo3.GetComponent<Raycastman2>().enabled = true;

    }

    }
