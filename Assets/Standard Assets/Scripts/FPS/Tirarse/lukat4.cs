using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lukat4 : MonoBehaviour
{

    public Transform target;
    public float rotationSpeed = 5;
    public float larotasion;

    void Awake()
    {
        return;    
        target = GameObject.FindWithTag("TargetEnemy").transform;
    }
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(larotasion, transform.eulerAngles.y, 0);
        //transform.eulerAngles = new Vector3(10, yRotation, 0);
    }
    }