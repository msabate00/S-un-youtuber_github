using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesacLukat : MonoBehaviour
{
    public GameObject yo;
    public GameObject yo2;
    public Camera camaritawey;
    public Camera camaritawey2;
    public GameObject camaraman;
    public float pene;
    public CharacterController control;
    public GameObject rendergay;
    void OnEnable()
    {
        Invoke("alamierda", pene);
    }

    void alamierda()
    {
        rendergay.GetComponent<quiatrlayergay>().enabled = false;
        rendergay.GetComponent<pnrlayergay1>().enabled = true;
        camaraman.GetComponent<MouseLook>().enabled = true;
        yo2.GetComponent<MouseLook>().enabled = true;
        // yo2.GetComponent<Movimiento>().enabled = true;
        yo2.GetComponent<CharacterMotor>().enabled = true;        
        control.enabled = true;
        StartCoroutine(camaractivar());
        
        yo.GetComponent<lukat1>().enabled = false;
       
        if (yo.GetComponent<Salto>() != null)
        {
            yo.GetComponent<Salto>().enabled = true;
        }
    }

    IEnumerator camaractivar()
    {
        camaritawey.enabled = false;
        camaritawey2.enabled = false;

        camaritawey.enabled = true;
        yield return null;
        camaritawey2.enabled = true;
    }
}
