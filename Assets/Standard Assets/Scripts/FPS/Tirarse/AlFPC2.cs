using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlFPC2 : MonoBehaviour {

    public GameObject camara;
    public GameObject camara2;
    public GameObject yo;
    public float pene;
    public float polla;
    public GameObject sfera;
    public Collider Box;
    void OnEnable () {
        Box.enabled = false;
        camara.GetComponent<FUCKMIERDA>().enabled = false;
        camara2.GetComponent<FUCKMIERDA>().enabled = false;        
        Invoke("Lukat", pene);
    }
	
	// Update is called once per frame
	void Lukat () {
        sfera.SetActive(true);
        Debug.Log("Se hiso");
        Invoke("FPC", polla);
    }

    void FPC()
    {
        yo.GetComponent<GO2>().enabled = true;

    }
 }
