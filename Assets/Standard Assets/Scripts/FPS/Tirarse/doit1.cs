using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doit1 : MonoBehaviour {
    public Animator pene;
    public GameObject yopadre;
    void Start () {
		
	}
	
	// Update is called once per frame
	void OnEnable () {
        
            yopadre.GetComponent<lukat3>().enabled = false;
        if (Animaciones.Animacion == 1)
        {
            pene.SetTrigger("AHORA");
        }
        if (Animaciones.Animacion == 2)
        {
            pene.SetTrigger("CUELLO");
        }
    }
}
