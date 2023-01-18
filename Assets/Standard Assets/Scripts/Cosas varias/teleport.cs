using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport : MonoBehaviour {

	public Transform p;
	public Vector3 pos;
	
	void OnTriggerEnter (Collider other) {
		
		if (other.tag == "Blanco")
        {
			SceneManager.LoadScene("prototipo");
		}

	}
}
