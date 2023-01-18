using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Municionwenapack : MonoBehaviour {

	public int munición1 = 2;
	public int munición2 = 2;
	public int munición3 = 2;
	public int munición4 = 2;
	public int jeringas = 2;
	private GunStatus Arma1;
	private GunStatus Arma2;
	private GunStatus Arma3;
	private GunStatus Arma4;
	private float polla;
	private int numerogay;
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
	private bool completao = false;
	private bool faltomunigay = true;
	public AudioClip sonido;

	void Start()
    {
		circulogayanimacion = canvasdemierda.gayanimacion;
		fondo = canvasdemierda.fondo;
		circulo = canvasdemierda.circulo;
		texto = canvasdemierda.textamen;
	}
	
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

		if (contadortexto > 0.2f && !polladas)
		{
			polladas = true;
			texto.gameObject.SetActive(false);
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
			texto.gameObject.SetActive(false);
			completao = true;
		}

		if (rellenadorahora == rellenador)
		{
			contador += 1 * Time.deltaTime;
		}

		if (FPCStatus.accionando && GetComponent<AudioSource>().isPlaying == false && pulsao)
		{
			GetComponent<AudioSource>().PlayOneShot(sonido, 1F);
		}
		if (!FPCStatus.accionando)
		{
			GetComponent<AudioSource>().Stop();
		}

	}

	// Update is called once per frame
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag.Contains("micuerpochingon"))
		{
			//numerogay = other.gameObject.GetComponentInParent<DisparoSelectivo>().NumeroArma;
			Arma1 = other.gameObject.GetComponentInParent<DisparoSelectivo>().Armas[0].GetComponent<GunStatus>();
			Arma2 = other.gameObject.GetComponentInParent<DisparoSelectivo>().Armas[1].GetComponent<GunStatus>();
			Arma3 = other.gameObject.GetComponentInParent<DisparoSelectivo>().Armas[2].GetComponent<GunStatus>();
			Arma4 = other.gameObject.GetComponentInParent<DisparoSelectivo>().Armas[3].GetComponent<GunStatus>();


			if (Arma1.CargadoresActuales == Arma1.CargadoresTotales && Arma2.CargadoresActuales == Arma2.CargadoresTotales && Arma3.CargadoresActuales == Arma3.CargadoresTotales && Arma4.CargadoresActuales == Arma4.CargadoresTotales
				&& Controlador.usos == 7)
			{
				faltomunigay = false;
			}
			else
            {
				faltomunigay = true;
            }


				if (completao)
			{
				Arma1.CargadoresActuales += munición1;
				Arma2.CargadoresActuales += munición2;
				Arma3.CargadoresActuales += munición3;
				Arma4.CargadoresActuales += munición4;
				Controlador.usos += jeringas;
				if (Controlador.usos > 7)
                {
					Controlador.usos = 7;
				}
				if (Arma1.CargadoresActuales > Arma1.CargadoresTotales)
				{
					Arma1.CargadoresActuales = Arma1.CargadoresTotales;
				}
				if (Arma2.CargadoresActuales > Arma2.CargadoresTotales)
				{
					Arma2.CargadoresActuales = Arma2.CargadoresTotales;
				}
				if (Arma3.CargadoresActuales > Arma3.CargadoresTotales)
				{
					Arma3.CargadoresActuales = Arma3.CargadoresTotales;
				}
				if (Arma4.CargadoresActuales > Arma4.CargadoresTotales)
				{
					Arma4.CargadoresActuales = Arma4.CargadoresTotales;
				}

				Debug.Log("AHH PINCHES PUTOS");
				completao = false;
			}
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
		if (posicionao && faltomunigay)
		{
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

		if (posicionao && !faltomunigay)
		{

			contadortexto = 0;
			polladas = false;
			texto.gameObject.SetActive(true);
			texto.text = "Ya tienes la munición máxima";
			
		}
	}





}
