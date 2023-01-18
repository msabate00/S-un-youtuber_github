using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posicionadorputamadre39 : MonoBehaviour {
    public static float mierda = 0.0f;
    // Use this for initialization
    void Update()
    {
        mierda = genteyutuf.grefg2;
        SetTransformX(mierda);
    }

    // Update is called once per frame
    void SetTransformX(float n)
    {
        transform.position = new Vector3(n, transform.position.y, transform.position.z);
    }
}
