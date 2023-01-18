using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidosnaves : MonoBehaviour {

	public AudioClip Disparo;
	public AudioClip Enemigomuerte;
	public AudioClip Jugadormuerte;
	public AudioClip Finalronda;
	public AudioClip Rondawena;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Reproducir (int pollas) {
		
		if (pollas == 1)
        {
			gameObject.GetComponent<AudioSource>().PlayOneShot(Disparo);
        }
		if (pollas == 2)
		{
			gameObject.GetComponent<AudioSource>().PlayOneShot(Enemigomuerte);
		}
		if (pollas == 3)
		{
			gameObject.GetComponent<AudioSource>().PlayOneShot(Jugadormuerte);
		}
		if (pollas == 4)
		{
			gameObject.GetComponent<AudioSource>().PlayOneShot(Finalronda);
		}
		if (pollas == 5)
		{
			gameObject.GetComponent<AudioSource>().PlayOneShot(Rondawena);
		}
	}
}
