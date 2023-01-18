using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JODERPUTAMIERDA : MonoBehaviour {

    public float tiempoputochingon;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > tiempoputochingon)
        {
            Debug.Log("TU PADRE CHI8NGON ME CHINGASTE LA PORONGA");
            Debug.Log(tiempoputochingon);
            tiempoputochingon = Time.time + tiempoputochingon;

        }
    }
}
