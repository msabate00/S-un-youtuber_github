using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tiempotaladro : MonoBehaviour {

	public float tiemporestante = 50;
	public TextMeshProUGUI texto;
	public Image barra;
	private float tiemporig;
	private float pollones;
	public Transform puerta;
	public Transform to;
	private bool abrecojones = false;
	public AudioClip taladrando;
	public AudioClip abrir;
	public bool funcionando = true;
	private float incrementadorlol = 10;
	public AudioSource taladrandotio;
	public AudioSource atascao;
	public AudioSource ariendotio;
	public GameObject objetoactivado;
	public GameObject salircojones;
	private MeshRenderer[] visual;
	public Animation putaszorras;
	public GameObject taladroroto;
	public GameObject raycastgay;
	public int randomlol = 90;

	public float tiempored;
	public float noventa;
	public float ochenta;
	public float setenta;
	public float sesenta;
	public float cincuenta;
	public float cuarenta;
	public float treinta;
	public float veinte;
	public float diez;

	public bool nueve = false;
	public bool ocho = false;
	public bool siete = false;
	public bool seis = false;
	public bool cinco = false;
	public bool cuatro = false;
	public bool tres = false;
	public bool dos = false;
	public bool uno = false;
	private int contador = 0;

	private bool polladas = false;
	private bool pulsao = false;
	private float rellenador = 0;
	private float rellenadorahora = 0;
	private float contadormierda = 0;
	private float contadortexto = 0;
	private float elrellenado;
	private bool pene = false;
	public float velocidad = 35;
	private Animation circulogayanimacion;
	private GameObject fondo;
	public string textoamostrargay;
	private Image circulo;
	private TextMeshProUGUI textolol;
	public TextMeshProUGUI objetivo;
	private bool posicionao = false;
	private bool lehedaocojones = false;
	private bool miscojones = false;
	private bool pollas = true;
	private bool pollas1 = false;
	private bool penesgays = false;

	void Start () {
		tiemporig = tiemporestante;
		//puerta.Play("puertagay");
		determinador();

		circulogayanimacion = canvasdemierda.gayanimacion;
		fondo = canvasdemierda.fondo;
		circulo = canvasdemierda.circulo;
		textolol = canvasdemierda.textamen;
	}
	
	// Update is called once per frame
	
	void determinador()
    {
		noventa = tiemporig;
		noventa *= 90;
		noventa /= 100;
		noventa = Mathf.Round(noventa);

		ochenta = tiemporig;
		ochenta *= 80;
		ochenta /= 100;
		ochenta = Mathf.Round(ochenta);

		setenta = tiemporig;
		setenta *= 70;
		setenta /= 100;
		setenta = Mathf.Round(setenta);

		sesenta = tiemporig;
		sesenta *= 60;
		sesenta /= 100;
		sesenta = Mathf.Round(sesenta);

		cincuenta = tiemporig;
		cincuenta *= 50;
		cincuenta /= 100;
		cincuenta = Mathf.Round(cincuenta);

		cuarenta = tiemporig;
		cuarenta *= 40;
		cuarenta /= 100;
		cuarenta = Mathf.Round(cuarenta);

		treinta = tiemporig;
		treinta *= 30;
		treinta /= 100;
		treinta = Mathf.Round(treinta);

		veinte = tiemporig;
		veinte *= 20;
		veinte /= 100;
		veinte = Mathf.Round(veinte);

		diez = tiemporig;
		diez *= 10;
		diez /= 100;
		diez = Mathf.Round(diez);

		int lol = Random.Range(0, 101);
		if (lol >= randomlol && contador <=3)
        {
			nueve = true;
			contador += 1;
		}

		int lol2 = Random.Range(0, 101);
		if (lol2 >= randomlol && contador <= 3)
		{
			ocho = true;
			contador += 1;
		}

		int lol3 = Random.Range(0, 101);
		if (lol3 >= randomlol && contador <= 3)
		{
			siete = true;
			contador += 1;
		}

		int lol4 = Random.Range(0, 101);
		if (lol4 >= randomlol && contador <= 3)
		{
			seis = true;
			contador += 1;
		}

		int lol5 = Random.Range(0, 101);
		if (lol5 >= randomlol && contador <= 3)
		{
			cinco = true;
			contador += 1;
		}

		int lol6 = Random.Range(0, 101);
		if (lol6 >= randomlol && contador <= 3)
		{
			cuatro = true;
			contador += 1;
		}

		int lol7 = Random.Range(0, 101);
		if (lol7 >= randomlol && contador <= 3)
		{
			tres = true;
			contador += 1;
		}

		int lol8 = Random.Range(0, 101);
		if (lol8 >= randomlol && contador <= 3)
		{
			dos = true;
			contador += 1;
		}

		int lol9 = Random.Range(0, 101);
		if (lol9 >= randomlol && contador <= 3)
		{
			uno = true;
			contador += 1;
			contador += 1;
			contador += 1;
		}

	}
	void incrementovolumen()
    {
		incrementadorlol += 1 * 20 * Time.deltaTime;
		incrementadorlol = Mathf.Clamp(incrementadorlol, 0, 50);
		float lil = incrementadorlol;
		lil /= 100;
		taladrandotio.volume = lil;
	}

	void Comprovador()
    {
		if (!lehedaocojones)
        {
			if (tiempored == noventa && nueve)
			{
				funcionando = false;
				lehedaocojones = true;
				nueve = false;
			}
			if (tiempored == ochenta && ocho)
			{
				funcionando = false;
				lehedaocojones = true;
				ocho = false;
			}
			if (tiempored == setenta && siete)
			{
				funcionando = false;
				lehedaocojones = true;
				siete = false;
			}
			if (tiempored == sesenta && seis)
			{
				funcionando = false;
				lehedaocojones = true;
				seis = false;
			}
			if (tiempored == cincuenta && cinco)
			{
				funcionando = false;
				lehedaocojones = true;
				cinco = false;
			}
			if (tiempored == cuarenta && cuatro)
			{
				funcionando = false;
				lehedaocojones = true;
				cuatro = false;
			}
			if (tiempored == treinta && tres)
			{
				funcionando = false;
				lehedaocojones = true;
				tres = false;
			}
			if (tiempored == veinte && dos)
			{
				funcionando = false;
				lehedaocojones = true;
				dos = false;
			}
			if (tiempored == diez && uno)
			{
				funcionando = false;
				lehedaocojones = true;
				uno = false;
			}
		}
		
	}

	void Update () {
		Comprovador();
		incrementovolumen();
		tiempored = tiemporestante;
		tiempored = Mathf.Round(tiempored);
		if (funcionando && taladrandotio.isPlaying == false && !abrecojones)
		{
			atascao.Stop();
			taladrandotio.enabled = true;
			atascao.enabled = false;
			taladrandotio.Play();
		}
		if (!funcionando && atascao.isPlaying == false && !abrecojones)
		{
			taladrandotio.Stop();
			taladrandotio.enabled = false;
			atascao.enabled = true;
			atascao.Play();
		}
		if (!funcionando && !abrecojones)
        {
			taladroroto.SetActive(true);
			visual = GetComponentsInChildren<MeshRenderer>();
			raycastgay.SetActive(true);

			foreach (MeshRenderer visual in visual)
            {
				visual.enabled = false;
			}

		}
		if (funcionando && !abrecojones)
		{
			lehedaocojones = false;
			taladroroto.SetActive(false);
			visual = GetComponentsInChildren<MeshRenderer>();
			raycastgay.SetActive(false);

			foreach (MeshRenderer visual in visual)
			{
				visual.enabled = true;
			}
			

		}
		if (funcionando && !abrecojones && pollas)
		{
			putaszorras.Play("activar");
			pollas = false;
			pollas1 = true;
		}
		if (!funcionando && !abrecojones && pollas1)
		{
			miscojones = false;
			putaszorras.Play("desactivar");
			pollas1 = false;
			pollas = true;
		}
		if (!abrecojones && funcionando)
        {
			tiemporestante = Mathf.Clamp(tiemporestante, 0, 100000);
			tiemporestante -= 1 * Time.deltaTime;
			texto.gameObject.SetActive(true);
			texto.text = tiemporestante.ToString("#") + "segundos";
			pollones = tiemporestante;
			pollones /= tiemporig;
			barra.fillAmount = pollones;
		}
		if (tiemporestante < 0)
        {
			tiemporestante = 0;
			abrecojones = true;
		}
			if (abrecojones)
        {
			salircojones.SetActive(true);
			atascao.Stop();
			taladrandotio.Stop();
			raycastgay.SetActive(false);
			puerta.rotation = Quaternion.Lerp(puerta.rotation, to.rotation, Time.time * 0.001f);
			texto.gameObject.SetActive(false);
			objetoactivado.SendMessage("Siguiente");

			visual = GetComponentsInChildren<MeshRenderer>();

			foreach (MeshRenderer visual in visual)
				visual.enabled = false;
			GetComponent<BoxCollider>().enabled = false;
			atascao.volume = 0;
			taladrandotio.volume = 0;
			gameObject.GetComponent<BoxCollider>().enabled = false;
			Destroy(gameObject, 3);
		}
		
		if (abrecojones && !penesgays)
        {
			objetivo.text = "Asegura el dinero o huye como una perra";
			ariendotio.PlayOneShot(abrir, 1F);
			putaszorras.Play("desactivar");
			penesgays = true;
		}



		rellenador = Mathf.Clamp(rellenador, 0, 100);
		if (rellenador == 100 && !miscojones)
		{
			funcionando = true;
			rellenador = 0;
			circulo.fillAmount = 0;
			FPCStatus.accionando = false;
			textolol.gameObject.SetActive(false);
			circulogayanimacion.gameObject.SetActive(true);
			circulogayanimacion.Play("circulogay");
			fondo.SetActive(false);
			incrementadorlol = 10;
			miscojones = true;
			//Destroy(textgay.gameObject);
			//Destroy(elconjunto);
		}
		elrellenado = rellenador;
		elrellenado /= 100;
		rellenadorahora = rellenador;
		contadortexto += 1 * Time.deltaTime;
		if (contadormierda > 0.05f && !pene)
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
			textolol.gameObject.SetActive(false);
		}

		if (FPCStatus.accionando && GetComponent<AudioSource>().isPlaying == false && pulsao)
		{
			//GetComponent<AudioSource>().PlayOneShot(sonido, 1F);
		}
		
		if (rellenadorahora == rellenador)
		{
			contadormierda += 1 * Time.deltaTime;
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
		if (posicionao && !funcionando)
		{
			contadortexto = 0;
			polladas = false;
			textolol.gameObject.SetActive(true);
			textolol.text = textoamostrargay;
			if (Input.GetKeyDown(KeyCode.E))
			{
				pulsao = true;
			}
			if (Input.GetKey(KeyCode.E) && pulsao)
			{
				FPCStatus.accionando = true;
				fondo.SetActive(true);
				pene = false;
				contadormierda = 0;
				rellenador += 1 * velocidad * Time.deltaTime;
				circulo.fillAmount = elrellenado;
				return;
			}
			rellenador = 0;
			circulo.fillAmount = 0;
		}
	}
}
