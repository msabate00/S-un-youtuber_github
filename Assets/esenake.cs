using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class esenake : MonoBehaviour {

	public Vector3 dir = Vector3.right;
	public Vector3 diract = Vector3.zero;
	public Transform cabeza;
	public Transform suelo;
	public GameObject comidaputo;
	public GameObject moridura;
	public Transform serpienteputo;
	private float act;
	private float sig;
	public bool nuvo = false;
	public Transform cuerpo;
	public Transform serpiente;
	private Vector3 gorda = new Vector3(1.2f, 1.2f, 0.003707022f);
	private Vector3 normal = new Vector3(1, 1, 0.003707022f);
	private int latmax = 24;
	private int vertmax = 13;
	public Transform terreno;
	private int numgay = -1; //49
	private int numver = -1; //27

	private Transform[] horab = new Transform[49];
	private Transform[] horar = new Transform[49];
	private Transform[] verde = new Transform[27];
	public Transform[] veriz = new Transform[27];

	public TextMeshProUGUI textogay;

	public GameObject sonidosgays;

	public AudioClip[] lals;

	public float tiempo;
	private float tiemporespawn;
	private float tiempoespera = 0;

	public static bool muerto = false;

	private int primero;
	private int segundo;
	private int tercero;

	public static float norgay;

	private bool pausao = false;

	void Awake () {

		iniciar();

		Time.timeScale = 1;
		Time.fixedDeltaTime = 0.002f;
		AudioListener.pause = false;

	}
	
	public void sonidos(int pene)
    {
		switch (pene)
        {
			case 1:
				GameObject pussy = Instantiate(sonidosgays);
				pussy.GetComponent<sonidosgays>().lol = pene;
				Destroy(pussy, 1);
				break;
			
			case 2:
				GameObject pussy1 = Instantiate(sonidosgays);
				pussy1.GetComponent<sonidosgays>().lol = pene;
				Destroy(pussy1, 1);
				break;
		}
    }
	void iniciar()
    {
		tiempoespera = Time.time + 0.1f;
		dir = Vector3.right;
	    diract = Vector3.zero;
	    cabeza = null;
		nuvo = false;
		int mierda = Random.Range(0, 7);
		while (mierda == primero || mierda == segundo || mierda == tercero)
        {
			mierda = Random.Range(0, 7);
		}
		tercero = segundo;
		segundo = primero;
		primero = mierda;
		GetComponent<AudioSource>().Stop();
		GetComponent<AudioSource>().loop = true;
		GetComponent<AudioSource>().clip = lals[mierda];
		GetComponent<AudioSource>().Play();

		textogay.gameObject.SetActive(false);
		serpiente = Instantiate(serpienteputo, serpienteputo.transform.position, serpienteputo.transform.rotation);
		cabeza = serpiente.GetChild(0);
		int lat = -24;
		int ver = -13;
		Vector3 pos = new Vector3(0, -13, -0.4f);

		int lat2 = Random.Range(-23, 24);
		int ver2 = Random.Range(-12, 13);
		Vector3 pos2 = Vector3.zero;
		pos2.x = lat2;
		pos2.y = ver2;
		Instantiate(comidaputo, pos2, Quaternion.identity);

		numgay = -1; //49
	    numver = -1;

		while (lat <= latmax)
		{
			pos.x = lat;
			Transform creao = Instantiate(suelo, pos, Quaternion.identity, terreno);
			numgay++;
			lat++;
			horab[numgay] = creao;
		}
		while (ver <= vertmax)
		{
			pos.y = ver;
			Transform creao = Instantiate(suelo, pos, Quaternion.identity, terreno);
			ver++;
			numver++;
			verde[numver] = creao;
		}
		lat = 24;
		numgay = 49;
		while (lat >= -latmax)
		{
			pos.x = lat;
			Transform creao = Instantiate(suelo, pos, Quaternion.identity, terreno);
			numgay--;
			lat--;
			horar[numgay] = creao;
		}
		ver = 13;
		numver = 27;
		while (ver >= -vertmax)
		{
			pos.y = ver;
			Transform creao = Instantiate(suelo, pos, Quaternion.identity, terreno);
			ver--;
			numver--;
			veriz[numver] = creao;
		}
		muerto = false;
		norgay = 0;
		act = Time.time;
	}


	public void comidogays(Transform comidapene, bool reap)
    {
		if (!reap) { nuvo = true; }

		Destroy(comidapene.gameObject);
		int lat = Random.Range(-23, 24);
		int ver = Random.Range(-12, 13);

		Vector3 pos = Vector3.zero;
		pos.x = lat;
		pos.y = ver;
		Instantiate(comidaputo, pos, Quaternion.identity);
	}

	
	public void generarmierda()
    {
		int lat = Random.Range(-23, 24);
		int ver = Random.Range(-12, 13);

		Vector3 pos = Vector3.zero;
		pos.x = lat;
		pos.y = ver;

		Instantiate(moridura, pos, Quaternion.identity);
		
	}
	public void textamen()
    {

		GetComponent<AudioSource>().Stop();
		GetComponent<AudioSource>().loop = false;
		GetComponent<AudioSource>().clip = lals[7];
		GetComponent<AudioSource>().Play();

		int rand = Random.Range(1, 7);

		switch (rand){
			case 1:
				textogay.text = "ERES MALÍSIMO CABRÓN";
				break;
			case 2:
				textogay.text = "OH DIOS MÍO DAS ASCO! AUTO-DESINSTALANDO!";
				break;
			case 3:
				textogay.text = "ME CAGO EN LA PUTA, EN SERIO?";
				break;
			case 4:
				textogay.text = "¿CÓMO COJONES ERES TAN MALO EN ESTE JUEGO?";
				break;
			case 5:
				textogay.text = "CÓMO LA PUEDES CAGAR TANTO, DIOS";
				break;
			case 6:
				textogay.text = "HAS MUERTO, ENHORABUENA COMEMIERDAS";
				break;



		}
    }

	void OnGUI()
	{
		Event e = Event.current;
		if (e.isKey && Time.time > tiemporespawn && muerto)
		{
		
			GameObject[] mierdas = GameObject.FindGameObjectsWithTag("Mierda");
			GameObject[] terreno = GameObject.FindGameObjectsWithTag("Pared");
			GameObject[] comida = GameObject.FindGameObjectsWithTag("Comida");
			GameObject serpienteputo = GameObject.FindGameObjectWithTag("Respawn");
			Destroy(serpienteputo);
			foreach (GameObject lel in mierdas)
            {
				Destroy(lel);
            }
			foreach (GameObject lel in terreno)
			{
				Destroy(lel);
			}
			foreach (GameObject lel in comida)
			{
				Destroy(lel);
			}
			iniciar();
		
			}
	}

	float positivono(float sex)
    {
		if (sex < 0)
        {
			return -1;
        }
        else
        {
			return 1;
        }
    }

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
        {
			if (pausao) { return; }
			pausao = true;
			SceneManager.LoadSceneAsync("menu");
			AudioListener.pause = true;
			Time.timeScale = 0;
			Time.fixedDeltaTime = 0;
		}

		if (muerto)
        {
			textogay.gameObject.SetActive(true);			
		}
		if (!muerto)
		{
			tiemporespawn = Time.time + 2;
			textogay.gameObject.SetActive(false);
			if (Time.time > sig)
			{
				generarmierda();
				sig = Time.time + 0.55f;
			}

			if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.3f && diract.x == 0 && Time.time > tiempoespera || Mathf.Abs(Input.GetAxisRaw("HorizontalNavesXbox")) >= 0.72f && diract.x == 0 && Time.time > tiempoespera)
			{
				float sexual = 0;

				if (Input.GetAxisRaw("Horizontal") == 0)
				{
					sexual = Input.GetAxisRaw("HorizontalNavesXbox");
				}
				else
				{
					sexual = Input.GetAxisRaw("Horizontal");
				}

				dir.x = (sexual / sexual) * positivono(sexual);
				dir.y = 0;
			}
			if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.3f && diract.y == 0 && Time.time > tiempoespera || Mathf.Abs(Input.GetAxisRaw("VerticalNavesXbox")) >= 0.72f && diract.y == 0 && Time.time > tiempoespera)
			{
				float sexual = 0;

				if (Input.GetAxisRaw("Vertical") == 0)
                {
					sexual = Input.GetAxisRaw("VerticalNavesXbox");
				}
                else
                {
					sexual = Input.GetAxisRaw("Vertical");
				}
				
				dir.y = (sexual / sexual) * positivono(sexual);
				dir.x = 0;
			}

			if (Time.time > act)
			{
				diract = dir;
				if (!nuvo)
				{
					Transform amover = cabeza.GetComponent<lolsig>().sig;
					amover.localScale = normal;
					amover.position = cabeza.position + dir;
					cabeza.GetComponent<lolsig>().cabeza = false;
					cabeza = amover;
					amover.GetComponent<lolsig>().cabeza = true;
				}
				if (nuvo)
				{
					Transform nuevo = Instantiate(cuerpo, cabeza.position + dir, Quaternion.identity, serpiente);
					nuevo.localScale = gorda;
					nuevo.GetComponent<Animator>().Play("epilepsiawapa",0, norgay);
					nuevo.GetComponent<lolsig>().sig = cabeza.GetComponent<lolsig>().sig;
					cabeza.GetComponent<lolsig>().sig = nuevo;
					cabeza.GetComponent<lolsig>().cabeza = false;
					cabeza = nuevo;
					nuevo.GetComponent<lolsig>().cabeza = true;
					nuvo = false;
				}

				
				act = Time.time + 0.15f;

			}

		}
	}
}
