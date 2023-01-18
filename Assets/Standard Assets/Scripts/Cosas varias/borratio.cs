using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borratio : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		
		if (other.GetComponent<DisparoSelectivo>() != null)
        {
			DisparoSelectivo s = other.GetComponent<DisparoSelectivo>();

			s.Insertar(2);
		}

	}
}
