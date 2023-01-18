using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lukat1 : MonoBehaviour
{

    public Transform target;
    public float rotationSpeed = 5;
    public float larotasion;

    void Start()
    {
        FPCStatus.isReloading = false;
        FPCStatus.transicion = false;
        FPCStatus.melee = false;
    }

    void Awake()
    {        
            target = GameObject.FindWithTag("Target").transform;
    }
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed);
        transform.eulerAngles = new Vector3(larotasion, transform.eulerAngles.y, 0);
        //transform.eulerAngles = new Vector3(10, yRotation, 0);
    }
    }