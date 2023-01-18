using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeDestruyo : MonoBehaviour {

    public GameObject Sfera;
    public GameObject Trigger;
    public GameObject Raycast;
    public Collider Colision;
    void OnEnable () {
        Colision.enabled = false;
        Destroy(Trigger.gameObject);
        Destroy(Raycast.gameObject);
        Destroy(Sfera.gameObject);
        Colision.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
