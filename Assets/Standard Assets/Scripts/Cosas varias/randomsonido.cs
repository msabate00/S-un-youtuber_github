using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomsonido : MonoBehaviour {

	public AudioClip[] sonidos;

	void Start () {
		GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1f);
		GetComponent<AudioSource>().clip = sonidos[Random.Range(0, sonidos.Length)];
		GetComponent<AudioSource>().Play();
	}
	
	
}
