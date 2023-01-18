using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lukat3 : MonoBehaviour
{

    public Transform target;
    public float rotationSpeed = 5;
    public float larotasion;

    void Start()
    {        
            target = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        if ((this.target == null))
        {
          //  Debug.Log("MIRA AMIGO, TU PUTA MADRE TE VA A ENCONTRAR EL PUTO OBJETIVO. A MI DEJA DE TOCARME LOS HUEVOS QUE NO SABES PROGRAMAR.");
            target = GameObject.FindWithTag("Player").transform;
        }
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(larotasion, transform.eulerAngles.y, 0);
        //transform.eulerAngles = new Vector3(10, yRotation, 0);
    }
    }