using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiar3 : MonoBehaviour {

    public Animator polla;
    public GameObject yo;
    void Start () {
		
	}
	
	// Update is called once per frame
	void OnEnable () {

        yo.gameObject.GetComponent<Muevete4>().enabled = false;
    }

    void Update()
    {
        if (Controlador.transition)
        {
            polla.Play("Levanta");
            //  yo.gameObject.GetComponent<Muevete5>().enabled = false;
            yo.gameObject.GetComponent<cambiar3>().enabled = false;
        }

    }
}
