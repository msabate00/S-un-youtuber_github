using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enviador : MonoBehaviour {

	public int num;
	private GameObject[] enemigosputos;

	void Start () {
		 
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Enemy")
        {
			other.GetComponent<BoxCollider>().enabled = false;		
			enemigosputos = other.transform.gameObject.GetComponent<aquihaycosas>().enemigosgays;

			if (gameObject.GetComponent<MeshRenderer>().enabled == true)
			{
				GameObject.Find("Controlador").GetComponent<Instanciadorenemigo>().basesdestruidas += 1;
				GameObject.Find("Controlador").SendMessage("Sonidosgays", 2);
			}
			GameObject.Find("Controlador").GetComponent<Instanciadorenemigo>().desactivador(num, enemigosputos);
			
		     	GameObject.Find("Controlador").GetComponent<Instanciadorenemigo>().enemigosdestruidos += 1;
			//Time.timeScale = 0;




		}
	}
}
