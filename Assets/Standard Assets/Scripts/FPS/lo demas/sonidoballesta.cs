using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidoballesta : MonoBehaviour {

	public AudioClip[] audiosexuales;
	
	public void dalebro(int sex)
    {
		AudioSource a = GetComponent<AudioSource>();
		a.volume = a.volume * Controlador.volumenef * audiosglobal.prop2;
		a.clip = audiosexuales[sex];
		a.Play();

    }

}
