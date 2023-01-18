using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotador : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 5);
		GetComponent<AudioSource>().volume = GetComponent<AudioSource>().volume * Controlador.volumenef;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + (360 * 3) * Time.deltaTime, transform.localEulerAngles.z);
	}
}
