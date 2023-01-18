using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borrabasurilla : MonoBehaviour {

    public float radius = 1;
    public Vector3 dir;
    public float dis;

    void Update()
    {
        RaycastHit hit;

        // Cast a sphere wrapping character controller 10 meters forward
        // to see if it is about to hit anything.
        if (Physics.SphereCast(transform.position + transform.TransformDirection(dir), radius, transform.forward, out hit, dis))
        {
            Debug.Log("Sexo");
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
        {
            //Debug.Log("Sexo2");
        }
    }
}
