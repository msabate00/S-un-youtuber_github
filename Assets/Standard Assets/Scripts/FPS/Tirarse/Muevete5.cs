using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muevete5 : MonoBehaviour {
    public GameObject yo;
    public Rigidbody rb;
    [RangeAttribute(-3.0f, 0.0f)]
    public float pene = -3.0f;

    void Update()
    {
      //  Vector3 movement = new Vector3(pene * Time.deltaTime, 0);
        //rb.MovePosition(transform.position + movement);
       transform.position += transform.up * pene *Time.deltaTime;


    }

}