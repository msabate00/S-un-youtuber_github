using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanzarputasbolsas : MonoBehaviour {

	public GameObject bolsa;
	public float longitud = 300;
	public float vertical = 100;
	private float vertical2;
	public float amplitud = 50;
	public Transform posision;
	private float masa;

	private float longitudorig;
	void Start () {
		longitudorig = longitud;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.G))
        {
			if (Controlador.llevobolsa)
            {
				GetComponent<AudioSource>().Play();
				vertical2 = vertical;
				vertical2 /= 1.2f;
				float arriba = Random.Range(vertical2, vertical);
				float derecha = Random.Range(-amplitud, amplitud);

				GameObject bolsitagay = Instantiate(bolsa, posision.position, transform.rotation);
				masa = bolsitagay.GetComponentInChildren<Rigidbody>().mass;
				arriba *= masa;
				derecha *= masa;
				longitud = longitudorig;
				longitud *= masa;
				bolsitagay.GetComponentInChildren<Rigidbody>().AddForce(transform.up * arriba);
				bolsitagay.GetComponentInChildren<Rigidbody>().AddForce(transform.right * derecha);
				bolsitagay.GetComponentInChildren<Rigidbody>().AddForce(transform.forward * longitud);
				Controlador.llevobolsa = false;
			}
        }
	}
}
