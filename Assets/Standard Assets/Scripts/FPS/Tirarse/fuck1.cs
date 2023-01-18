using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuck1 : MonoBehaviour {

	public GameObject polla;
    public Transform target;
    // public Vector3 pene;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = rotation;
        Debug.Log(target);
        // Vector3 pene = Vector3.RotateTowards(transform.forward, 0.0f, 3.0f, 0.0f);
        //transform.rotation = Quaternion.LookRotation(pene);

    }
}
//QUE TE FOLLEN PUTA PROGRAMACIÓN DE LOS COJONES QUE TE DEN POR EL PUTO CULO CABRONAZO FRIKI OTAKU DE MIERDA HIJO DE LA GRAN PUTA