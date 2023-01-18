using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    public GameObject Enemigo;

    void Start () {
		
	}
	
	// Update is called once per frame
	void OnEnable () {
        Destroy(Enemigo.gameObject);
    }
}
