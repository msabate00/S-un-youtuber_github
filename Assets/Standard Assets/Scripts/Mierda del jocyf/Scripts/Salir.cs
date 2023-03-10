using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Salir : MonoBehaviour {

	// Use this for initialization
	private float rellenador = 0;
	private float rellenadorahora = 0;
	private float contador = 0;
	private float contadortexto = 0;
	private float elrellenado;
	private bool pene = false;
	private bool polladas = false;
	private bool posicionao = false;
	private bool pulsao = false;
	public float velocidad = 35;
	private Animation circulogayanimacion;
	private GameObject fondo;
	public string textoamostrargay;
	private Image circulo;
	private TextMeshProUGUI texto;
	public TextMesh textgay;
	private Transform target;
	private Vector3 lol;
	private Vector3 cojonazos;
	private Vector3 cojonazos2;
	private Vector3 original;
	private Vector3 originalobjetado;
	public GameObject posicionador;
	private float polla;

	void Awake()
	{
		original = textgay.transform.localScale;
		originalobjetado = transform.localScale;
	}

	void Start()
	{
		textgay.gameObject.SetActive(true);
		circulogayanimacion = canvasdemierda.gayanimacion;
		fondo = canvasdemierda.fondo;
		circulo = canvasdemierda.circulo;
		texto = canvasdemierda.textamen;
	}

	// Update is called once per frame
	void Update () {

		rellenador = Mathf.Clamp(rellenador, 0, 100);
		elrellenado = rellenador;
		elrellenado /= 100;
		rellenadorahora = rellenador;
		contadortexto += 1 * Time.deltaTime;

		if (contador > 0.05f && !pene)
		{
			rellenador = 0;
			circulo.fillAmount = 0;
			pene = true;
			pulsao = false;
			FPCStatus.accionando = false;
			fondo.SetActive(false);
		}

		if (rellenador == 100)
		{
			pulsao = false;
			rellenador = 0;
			circulo.fillAmount = 0;
			FPCStatus.accionando = false;
			texto.gameObject.SetActive(false);
			circulogayanimacion.gameObject.SetActive(true);
			circulogayanimacion.Play("circulogay");
			fondo.SetActive(false);
			SceneManager.LoadScene("hasganao");
		}

		if (contadortexto > 0.2f && !polladas)
		{
			polladas = true;
			texto.gameObject.SetActive(false);
		}
		if (rellenadorahora == rellenador)
		{
			contador += 1 * Time.deltaTime;
		}

		if (target == null && GameObject.FindWithTag("Player"))
		{
			target = GameObject.FindWithTag("Player").transform;
		}

		polla = Vector3.Distance(transform.position, target.position);
		textgay.text = polla.ToString("#") + "m";
		;
		textgay.transform.LookAt(target);
		lol = textgay.transform.localEulerAngles;
		lol.x = 0;
		textgay.transform.localEulerAngles = lol;
		float jaj = polla;
		float joj = polla;
		jaj *= 0.0008f;
		jaj += 0.0217f;
		joj *= 0.0242f;
		joj += 0.7582f;
		if (polla < 10)
		{
			cojonazos = original;
			cojonazos2 = originalobjetado;

		}
		if (polla > 10)
		{
			cojonazos.x = -jaj;
			cojonazos.z = jaj;
			cojonazos.y = jaj;
			cojonazos2.x = joj;
			cojonazos2.z = joj;
			cojonazos2.y = joj;
		}

		textgay.transform.localScale = cojonazos;
		//transform.localScale = cojonazos2; lo desactivo porque agrandar objetos es raro y tal al contrario de mi polla
		textgay.transform.position = posicionador.transform.position;
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

	void mirandoputo()
	{
		Debug.Log("TUP UTA MARE");
		if (posicionao)
		{
			Debug.Log("TUP UTA MARE");
			contadortexto = 0;
			polladas = false;
			texto.gameObject.SetActive(true);
			texto.text = textoamostrargay;
			if (Input.GetKeyDown(KeyCode.E))
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
