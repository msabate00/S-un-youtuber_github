using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class bolsamierda : MonoBehaviour
{

	private float distangay;
	private Transform target;
	private bool polladas = false;
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
	public Image circulo;
	public TextMeshProUGUI texto;
	private Animation textoconcluidogay;
	private TextMeshProUGUI texto2;
	private bool llenando = false;

	void Start()
	{
		circulogayanimacion = canvasdemierda.gayanimacion;
		fondo = canvasdemierda.fondo;
		circulo = canvasdemierda.circulo;
		texto = canvasdemierda.textamen;
		textoconcluidogay = canvasdemierda.textoconclusion;
		texto2 = textoconcluidogay.gameObject.GetComponentInChildren<TextMeshProUGUI>();
	}

	// Update is called once per frame
	void Update()
	{
		rellenador = Mathf.Clamp(rellenador, 0, 100);
		elrellenado = rellenador;
		elrellenado /= 100;
		rellenadorahora = rellenador;
		contadortexto += 1 * Time.deltaTime;

		if (target == null && GameObject.FindWithTag("Player"))
		{
			target = GameObject.FindWithTag("Player").transform;
		}
		distangay = Vector3.Distance(transform.position, target.position);

		if (contador > 0.05f && !pene)
		{
			rellenador = 0;
			circulo.fillAmount = 0;
			pene = true;
			pulsao = false;
			FPCStatus.accionando = false;
			fondo.SetActive(false);
		}

		if (contadortexto > 0.2f && !polladas && !llenando)
		{
			polladas = true;
			texto.gameObject.SetActive(false);
		}

		if (rellenador == 100)
		{
			llenando = false;
			pulsao = false;
			Controlador.llevobolsa = true;
			rellenador = 0;
			circulo.fillAmount = 0;
			FPCStatus.accionando = false;
			texto.gameObject.SetActive(false);
			circulogayanimacion.gameObject.SetActive(true);
			circulogayanimacion.Play("circulogay");
			fondo.SetActive(false);
			texto.gameObject.SetActive(false);
			Destroy(transform.parent.gameObject);
		}

		if (rellenadorahora == rellenador)
		{
			contador += 1 * Time.deltaTime;
		}
	
	
	
	if (llenando)
        {
			FPCStatus.accionando = true;
			fondo.SetActive(true);
			pene = false;
			contador = 0;
			rellenador += 1 * velocidad * Time.deltaTime;
			circulo.fillAmount = elrellenado;
		}
		if (distangay > 9)
        {
			llenando = false;
		}
	}

	void mirandoputo()
	{

		if (distangay < 9 && !Controlador.llevobolsa)
		{
			Debug.Log(distangay);
			contadortexto = 0;
			polladas = false;
			texto.gameObject.SetActive(true);
			texto.text = textoamostrargay;
			if (Input.GetKeyDown(KeyCode.E))
			{
				pulsao = true;
			}
			if (Input.GetKeyUp(KeyCode.E))
			{
				pulsao = false;
				llenando = false;
			}
			if (Input.GetKey(KeyCode.E) && pulsao)
			{
				llenando = true;
				return;
			}
			rellenador = 0;
			circulo.fillAmount = 0;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "bolsafurgo")
		{
			textoconcluidogay.Stop();
			textoconcluidogay.Play("Textamen");
			texto2.text = "Se han asegurado 1000$";
			texto.gameObject.SetActive(false);
			rellenador = 0;
			circulo.fillAmount = 0;
			pene = true;
			pulsao = false;
			Controlador.dineroasegurado += 1000;

			Destroy(transform.parent.gameObject);

		}

	}
}
