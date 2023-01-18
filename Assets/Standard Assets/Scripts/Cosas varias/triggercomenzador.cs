using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggercomenzador : MonoBehaviour {

	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (!other.CompareTag("Player")) { return; }
		spawnerweno.zona = true;
	}

	void OnTriggerExit(Collider other)
    {
		if (!other.CompareTag("Player")) { return; }
		spawnerweno.zona = false;
	}
}
