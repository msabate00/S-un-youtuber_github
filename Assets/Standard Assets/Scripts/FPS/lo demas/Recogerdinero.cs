using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Recogerdinero : MonoBehaviour {

	//public GameObject elconjunto;
	private bool polladas = false;
	private bool posicionao = false;
	private bool pulsao = false;
	private float rellenador = 0;
	private float rellenadorahora = 0;
	private float contador = 0;
	private float contadortexto = 0;
	private float elrellenado;
	private bool pene = false;
	public float velocidad = 35;
	public Animation circulogayanimacion;
	public GameObject fondo;
	public string textoamostrargay;
	public AudioClip sonido;
	public GameObject objetoactivado;
	public Image circulo;
	public TextMeshProUGUI texto;
	private BoxCollider[] visual;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Siguiente()
    {
		GetComponent<BoxCollider>().enabled = true;
		//GetComponentInChildren<BoxCollider>().enabled = true;
		visual = GetComponentsInChildren<BoxCollider>();

		foreach (BoxCollider visual in visual)
        {
			visual.enabled = true;
		}
	}
	void Update () {
		
		rellenador = Mathf.Clamp(rellenador, 0, 100);
		elrellenado = rellenador;
		elrellenado /= 100;
		rellenadorahora = rellenador;
		contadortexto += 1 * Time.deltaTime;

		if (rellenador == 100)
		{
			pulsao = false;
			Controlador.llevobolsa = true;
			rellenador = 0;
			circulo.fillAmount = 0;
			FPCStatus.accionando = false;
			texto.gameObject.SetActive(false);
			circulogayanimacion.gameObject.SetActive(true);
			circulogayanimacion.Play("circulogay");
			fondo.SetActive(false);
			objetoactivado.SendMessage("Siguiente");
			texto.gameObject.SetActive(false);
			Destroy(gameObject);
		}

		if (contador > 0.05f && !pene)
		{
			rellenador = 0;
			circulo.fillAmount = 0;
			pene = true;
			pulsao = false;
			FPCStatus.accionando = false;
			fondo.SetActive(false);
		}

		if (contadortexto > 0.2f && !polladas)
		{
			polladas = true;
			texto.gameObject.SetActive(false);
		}
		if (FPCStatus.accionando && GetComponent<AudioSource>().isPlaying == false && pulsao)
		{
			GetComponent<AudioSource>().PlayOneShot(sonido, 1F);
		}
		if (!FPCStatus.accionando)
		{
			GetComponent<AudioSource>().Stop();
		}
		if (rellenadorahora == rellenador)
		{
			contador += 1 * Time.deltaTime;
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "micuerpochingon")
		{
			posicionao = true;
		}

	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "micuerpochingon")
		{
			posicionao = false;
			pulsao = false;
		}

	}

	void mirando()
	{
		if (posicionao && rellenador != 100)
		{
			contadortexto = 0;
			polladas = false;
			texto.gameObject.SetActive(true);
			texto.text = textoamostrargay;
			if (Input.GetKeyDown(KeyCode.E) && !Controlador.llevobolsa)
			{
				pulsao = true;
			}
			if (Input.GetKey(KeyCode.E) && pulsao)
			{
				FPCStatus.accionando = true;
				fondo.SetActive(true);
				pene = false;
				contador = 0;
				rellenador += 1 * velocidad * Time.deltaTime;
				circulo.fillAmount = elrellenado;
				return;
			}
			rellenador = 0;
			circulo.fillAmount = 0;
		}
	}
}
