using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muevo1 : MonoBehaviour {

    public float speed = 10;
    private Rigidbody rig;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {

        float ha = Input.GetAxis("Horizontal");
        float va = Input.GetAxis("Vertical");
        Vector3 mov = new Vector3(ha, 0, va) * speed * Time.deltaTime;
        rig.MovePosition(transform.position + mov);
    }






}