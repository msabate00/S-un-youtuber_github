using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeninjadamage : MonoBehaviour {

	public AudioClip[] aciertos;
	public AudioClip[] fallos;
	private Transform original;
	public int tipo = 2;

	void Start () {
		Invoke("fallo", 0.05f);
		Invoke("desactivar", 0.1f);
	}
	
	void fallo()
    {
		GetComponent<AudioSource>().PlayOneShot(fallos[Random.Range(0, fallos.Length)]);
    }

	void OnTriggerEnter(Collider other)
    {
		if (other.CompareTag("micuerpochingon"))
        {
			CancelInvoke("fallo");
			GetComponent<AudioSource>().PlayOneShot(aciertos[Random.Range(0, aciertos.Length)]);
			
			Controlador.vidahomosexual = Controlador.vidahomosexual - Controlador.dañoenemigogay[tipo];

			angolosahhdonde.yo.SendMessage("asignador", original);

			Controlador.ah.SendMessage("actualizarvida");
		}
    }

	public void elorig(Transform o)
	{
		original = o;
	}

	void desactivar()
    {
		GetComponent<Collider>().enabled = false;
    }
}
