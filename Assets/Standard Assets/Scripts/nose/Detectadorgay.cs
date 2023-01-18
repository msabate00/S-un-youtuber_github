using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Detectadorgay : MonoBehaviour {
	[HideInInspector]
	public GameObject original;
	private GameObject rojo;
	private GameObject azul;
	private GameObject verde;
	private GameObject amarillo;
	public GameObject particulasgays;
	private GameObject[] enemigosputos;

	public Transform[] cosas;

	public bool jugador = false;

	public static int vidas = 4;

	private bool pausao = false;

	void Start () {

		rojo = GameObject.Find("JugadorRojoVisual");
		verde = GameObject.Find("JugadorVerde");
		amarillo = GameObject.Find("JugadorAmarillo");
		azul = GameObject.Find("JugadorAzul");

		Time.timeScale = 1;
		Time.fixedDeltaTime = 0.002f;
		AudioListener.pause = false;

	}
	
	void muerto()
    {
		foreach (GameObject lols in enemigosputos)
        {
			Destroy(lols);
        }
		
		GameObject rojog = Instantiate(particulasgays, rojo.transform.position, rojo.transform.rotation);
		GameObject azulg = Instantiate(particulasgays, azul.transform.GetChild(0).GetChild(0).position, azul.transform.GetChild(0).GetChild(0).rotation);
		GameObject amarillog = Instantiate(particulasgays, amarillo.transform.GetChild(0).position, amarillo.transform.GetChild(0).rotation);
		GameObject verdeg = Instantiate(particulasgays, verde.transform.position, verde.transform.rotation);

		Vector3 penesgays = verdeg.transform.localEulerAngles;
		penesgays.z = -90;
		verdeg.transform.localEulerAngles = penesgays;
		Vector3 penes = Vector3.zero;
		penes.Set(4, 4, 4);
		Vector3 penes2 = Vector3.zero;
		penes2.Set(1.8f, 1.8f, 1.8f);
		Vector3 penes3 = Vector3.zero;
		penes3.Set(2.63f, 4, 4);

		cosas[0] = rojog.transform;
		cosas[1] = rojog.transform.GetChild(0);
		cosas[2] = rojog.transform.GetChild(1);
		cosas[3] = rojog.transform.GetChild(2);

		foreach (Transform t in cosas)
		{
				t.gameObject.layer = 1;
		}

		rojog.transform.localScale = penes2;
		azulg.transform.localScale = penes;
		amarillog.transform.localScale = penes;
		verdeg.transform.localScale = penes3;

		rojog.GetComponent<Animation>().Play("circulocolorojo");
		azulg.GetComponent<Animation>().Play("circulocolorazul");
		amarillog.GetComponent<Animation>().Play("circulocoloramar");
		verdeg.GetComponent<Animation>().Play("circulocolorverde");

		ehhyokse.muerto = true;
		transform.parent.GetChild(0).gameObject.GetComponent<BoxCollider>().enabled = false;
		transform.parent.GetChild(1).gameObject.GetComponent<BoxCollider>().enabled = false;
		rojo.GetComponent<MeshRenderer>().enabled = false;
		amarillo.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().enabled = false;
		transform.parent.GetChild(2).gameObject.GetComponent<MeshRenderer>().enabled = false;
		azul.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().enabled = false;
		Invoke("desmorir", 2);

	}
	void desmorir()
    {

		vidas--;
		if (vidas == 0) { SceneManager.LoadSceneAsync("menu");

			if (pausao) { return; }
			pausao = true;
			SceneManager.LoadSceneAsync("menu");
			AudioListener.pause = true;
			Time.timeScale = 0;
			Time.fixedDeltaTime = 0;

			return; }

		ehhyokse.muerto = false;
		rojo.GetComponent<MeshRenderer>().enabled = true;
		amarillo.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().enabled = true;
		transform.parent.GetChild(2).gameObject.GetComponent<MeshRenderer>().enabled = true;
		azul.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().enabled = true;

		rojo.GetComponent<Animation>().Play("parpadeo");
		verde.GetComponentInChildren<Animation>().Play("parpadeo");
		amarillo.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Animation>().Play("parpadeo");
		azul.GetComponentInChildren<Animation>().Play("parpadeo");

		Invoke("colisionactiva", 2.7f);
		
		//2.5 segundos
	}
	void colisionactiva()
    {
		transform.parent.GetChild(0).gameObject.GetComponent<BoxCollider>().enabled = true;
		transform.parent.GetChild(1).gameObject.GetComponent<BoxCollider>().enabled = true;
	}
	
	void OnTriggerEnter (Collider other) {
		
		if (other.tag == "Enemy" && !jugador)
        {
			other.GetComponent<BoxCollider>().enabled = false;
			GameObject.Find("Controlador").GetComponent<Instanciadorenemigo>().enemigosdestruidos += 1;
			GameObject.Find("Controlador").SendMessage("Sonidosgays", 2);
			//Time.timeScale = 0;
			original.SendMessage("particulas", other.transform.gameObject.GetComponent<aquihaycosas>().enemigosgays);
        }
		if (other.tag == "Enemy" && jugador)
		{
			GameObject.Find("Controlador").SendMessage("Sonidosgays", 3);
			other.GetComponent<BoxCollider>().enabled = false;
			Instanciadorenemigo.vidas -= 1;
			GameObject.Find("Controlador").GetComponent<Instanciadorenemigo>().enemigosdestruidos += 1;
			Debug.Log("cojonazospollas");
			enemigosputos = other.transform.gameObject.GetComponent<aquihaycosas>().enemigosgays;
			GetComponent<BoxCollider>().enabled = false;
			//Time.timeScale = 0;
			muerto();
		}
	}

	
}
