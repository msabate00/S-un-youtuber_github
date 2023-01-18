using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlFPC : MonoBehaviour {

    public GameObject camara;
    public GameObject camara2;
    public GameObject yo;
    public float pene;
    public float polla;
    public GameObject sfera;
    public Collider Box;
    void OnEnable () {
        camara.GetComponent<FUCKMIERDA>().enabled = false;
        camara2.GetComponent<FUCKMIERDA>().enabled = false;
        camara.GetComponent<lukat>().enabled = true;
        Invoke("Lukat", pene);
    }
	void Start()
    {
        Controlador.mestoylevantandojoder = true;
    }
	// Update is called once per frame
	void Lukat () {
        sfera.SetActive(true);
        Debug.Log("Se hiso");
        Invoke("FPC", polla);
    }

    void FPC()
    {
        Box.enabled = false;
        yo.GetComponent<GO2>().enabled = true;

    }
 }
