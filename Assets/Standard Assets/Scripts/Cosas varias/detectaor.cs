using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectaor : MonoBehaviour {

	public GameObject coches;
	public GameObject spawners;
	public GameObject asaltoicono;
	public sonidosgays musica;
	private bool pene = false;
	private float tiempo = 0;
	public float tiempoasalto = 50;
	public float tiempoespera = 20;
	private bool polladas = false;

	void Update () {
		if (Controlador.detectao && !pene)
        {
			
			Invoke("spawner", 10);
			Invoke("spawner2", 20);
			pene = true;
		}
		if (polladas)
        {
			tiempo += 1 * Time.deltaTime;
			controladortiempo();
		}
	}

	// Update is called once per frame
	void controladortiempo()
    {
		float tiempa = tiempo;
		tiempa = Mathf.Round(tiempa);
		Debug.Log(tiempa);
		if (tiempa == tiempoasalto && Controlador.asalto)
        {
			tiempo = 0;
			musica.parao();
			asaltoicono.SetActive(false);
			Controlador.asalto = false;
        }
		if (tiempa == tiempoespera && !Controlador.asalto)
		{
			tiempo = 0;
			musica.reentrada();
			asaltoicono.SetActive(true);
			Controlador.asalto = true;
		}
	}
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag.Contains("micuerpochingon") || other.gameObject.tag.Contains("Player"))
		{
			Controlador.detectao = true;
		}

	}

	void spawner()
    {
		GetComponent<AudioSource>().Play();
		coches.SetActive(true);
		asaltoicono.SetActive(true);
		polladas = true;
		Controlador.asalto = true;
	}

	void spawner2()
	{
		spawners.SetActive(true);
	}
}
