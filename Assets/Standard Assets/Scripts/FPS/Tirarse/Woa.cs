using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woa : MonoBehaviour
{
    public float spid;
    public Transform Objetivo;
    public Transform Player;
   private float distance;
    bool polla = true;
    void Start()
    {
        if ((this.Objetivo == null)) {
            Debug.Log("MIRA AMIGO, TU PUTA MADRE TE VA A ENCONTRAR EL PUTO OBJETIVO. A MI DEJA DE TOCARME LOS HUEVOS QUE NO SABES PROGRAMAR.");
        }
             this.Objetivo = GameObject.FindWithTag("TargetEnemy").transform;
    }

    // Update is called once per frame

    void Update()
    {
        if ((this.Objetivo == null))
        {
            this.Objetivo = GameObject.FindWithTag("TargetEnemy").transform;
            Debug.Log("MIRA AMIGO, TU PUTA MADRE TE VA A ENCONTRAR EL PUTO OBJETIVO. A MI DEJA DE TOCARME LOS HUEVOS QUE NO SABES PROGRAMAR.");
        }
        if (polla)
        {
            Vector3 lookAtPos = Player.position;
            lookAtPos.y = transform.position.y;
            transform.LookAt(lookAtPos);
            transform.position += transform.forward * spid * Time.deltaTime;
        }
        distance = Vector3.Distance(transform.position, Objetivo.position);
        Debug.Log(distance);
        if (distance >= 4.21f)
        {
            Debug.Log("WTFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF JODER ME CAGO EN LA PUTA");
            polla = true;
            spid = 20;
            Animaciones.Distancia = false;
        }
        if (distance <= 3.39f)
        {
            polla = true;
            spid = -20;
            Animaciones.Distancia = false;
        }
        if (distance >= 3.4f && distance <= 4.2f)
        {
            polla = false;
            Debug.Log("DISTANCIA DE PUTA MADRE");
            Animaciones.Distancia = true;
        }
        
    }


}



