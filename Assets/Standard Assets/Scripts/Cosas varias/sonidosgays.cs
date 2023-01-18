using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidosgays : MonoBehaviour {

	public AudioSource ambiente;
	public AudioSource normal;
	public AudioSource chillos;
	public AudioSource full;
	public AudioSource reentradatio;
	public AudioSource relax;
	private bool dale = false;
	public bool descanso;
	public bool entrar;
	public bool aumentador = false;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.O))
        {
			parao();
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			reentrada();
		}

		if (Controlador.detectao && !dale)
        {
			ambiente.enabled = false;
			normal.enabled = false;
			chillos.Play();
			Invoke("entramusicagay", 2);
			dale = true;
		}
	if (aumentador)
        {
			reentradatio.volume += 0.12f * Time.deltaTime;
			reentradatio.volume = Mathf.Clamp(reentradatio.volume, 0.5f, 0.7f);
		}
	}

	void entramusicagay()
    {
		relax.Stop();
		relax.enabled = false;
		reentradatio.Stop();
		reentradatio.enabled = false;
		full.enabled = true;
		full.Play();
		aumentador = false;
	}
	public void parao()
    {
		reentradatio.Stop();
		reentradatio.enabled = false;
		full.Stop();
		full.enabled = false;
		relax.enabled = true;
		relax.Play();
		aumentador = false;
	}
	public void reentrada()
	{
		reentradatio.volume = 0.5f;
		aumentador = true;
		relax.Stop();
		relax.enabled = false;
		reentradatio.enabled = true;
		reentradatio.Play();
		full.Stop();
		full.enabled = false;
		Invoke("entramusicagay", 7.26f);
	}

}
