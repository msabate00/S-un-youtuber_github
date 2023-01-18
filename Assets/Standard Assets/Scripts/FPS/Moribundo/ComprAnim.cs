using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprAnim : MonoBehaviour {

    private bool ostia = false;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (ostia)
        {
            Debug.Log("TU PUTISIMIMISMADRE");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obstaculo") || other.gameObject.CompareTag("pene"))
        {
            Debug.Log("OH VAYA ORIGINAL");
            Comprovador.derecha = true;
            ostia = true;
        }
    }
}
