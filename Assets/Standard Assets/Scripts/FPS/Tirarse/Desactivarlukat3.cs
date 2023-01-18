using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivarlukat3 : MonoBehaviour {
    public GameObject yo;
    public GameObject yo2;
    public Camera camaritawey;
    public Animator polla;
    public float pene;
	void OnEnable () {
		Invoke("alamierda", pene);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

void alamierda()
    {
        
        camaritawey.enabled = true;
    //    Debug.Log("A la mierda");
        yo.GetComponent<lukat1>().enabled = false;
        // yo2.GetComponent<Salto8>().enabled = true;
        polla.Play("Animacion");
    }


}
