using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidosgays : MonoBehaviour {

	[HideInInspector]
	public int lol;
	public AudioClip[] audios;
	void Start () {
		GetComponent<AudioSource>().PlayOneShot(audios[lol]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
