using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemigo : MonoBehaviour {

	[HideInInspector]
	public bool Generado = false;
	[HideInInspector]
	public int AIState = 1;
	//public AIState state = AIState.Patrol;
	public float velocidad = 1;
	public Transform rojo;
	public Transform enemigo;
	public Transform enemigocirculotio;
	public Transform enemigoraro;
	private Transform circ;
	private GameObject dosde;
	private GameObject circulogay;
	private GameObject circulogayraro;
	private float altura = 9;
	public Vector3 escala;
	private Vector3 escalaoraz;
	private Vector3 escalaorazgrande;

	private Transform enemigoplano;
	private Transform enemigocirculo;
	private Transform circuloraro;

	public GameObject[] enemigos;
	private float alturaverde = 9;

	private GameObject con;

	private bool derecho = false;

	[HideInInspector]
	public float velocidadlat = 100;
	[HideInInspector]
	public float velocidadsin = 1;
	[HideInInspector]
	public float rangosin = 220;

	private float tiempoespera;
	private bool cambio = false;

	private int nivelmax = 6;

	private float ranor;
	private float velor;

	private bool movifinal = false;

	[HideInInspector]
	public bool regatesfinales = false;
	[HideInInspector]
	public bool multiplicar = false;

	[HideInInspector]
	public int ronda;

	
	
	void Start()
	{

		escalaoraz.Set(0.1008545f, 0.446379f, -0.153028f);

		if (!Generado)
		{
			if (ronda == 1) //establecer el nivel a seleccionar según la ronda
			{
				nivelmax = 2;
			}

			selectoria();







			int pene = Random.Range(1, nivelmax);
			pene = 5;
			//AIState = pene;

			if (pene == 2) //hago cosas según el nivel seleccionado
			{
				if (Instanciadorenemigo.ronda > 3 && Instanciadorenemigo.ronda < 5)
				{
				//	velocidadsin = 0.5f;
				//	rangosin = 70;
				}
				if (ronda > 5 && ronda < 8)
				{
					//velocidadsin = 1f;
				//	rangosin = 170;
				}
				if (ronda > 8)
				{
				//	velocidadsin = 1f;
				//	rangosin = 220;
				}

				int polla = Random.Range(1, 3);
				if (polla == 1)
				{
				//	derecho = false;
				}
				if (polla == 2)
				{
					//derecho = true;
				}
			}


			if (pene == 4)
			{

				if (ronda > 3 && ronda < 7)
				{
					//velocidadlat = 60;
				//	velocidadsin = 1f;
					//rangosin = 70;
				}

				//tiempoespera = Time.time + 4;

				int polla = Random.Range(1, 3);
				if (polla == 1)
				{
			//		derecho = false;
				}
				if (polla == 2)
				{
					//derecho = true;
				}
			}


			if (pene == 5) //menos rango más lento
			{
			//	velocidadsin = 1f;
				//rangosin = 120;
				//velor = velocidadsin;
				//ranor = rangosin;
				//tiempoespera = Time.time + 3;
			}

			con = GameObject.Find("Controlador");
			generarcirculoraro();
			generarcirculo();
			generardosde();
		}
	}
	
	void generardosde()
    {
		dosde = GameObject.Find("2d");
		enemigoplano = Instantiate(enemigo);
		enemigoplano.parent = dosde.transform;
		enemigoplano.localScale = escala;
		Vector3 pos = Vector3.zero;
		pos.x = 21.15536f;
		pos.y = 8.6f;
		enemigoplano.localPosition = pos;

		enemigos[0] = transform.parent.gameObject;
		enemigos[1] = enemigoplano.gameObject;
		enemigos[2] = circuloraro.gameObject;
		enemigos[3] = enemigocirculo.gameObject;
		enemigoplano.GetChild(0).SendMessage("posicionesgays", enemigos);
		
		transform.parent.GetChild(1).GetChild(0).GetChild(0).SendMessage("posicionesgays", enemigos);
		Debug.Log(transform.parent.GetChild(1).GetChild(0).GetChild(0));
	}
	void generarcirculo()
	{
		circulogay = GameObject.Find("Circulo");
		enemigocirculo = Instantiate(enemigocirculotio);
		enemigocirculo.parent = circulogay.transform;
		enemigocirculo.localScale = escala;
		Vector3 pos;
		pos.x = 6.4f;
		pos.y = -0.1739178f;
		pos.z = -1.79f;
		enemigocirculo.localPosition = pos;

		Debug.Log(transform.parent.gameObject);
		
	}
	void generarcirculoclon(float alturagay)
	{
		circulogay = GameObject.Find("Circulo");
		enemigocirculo = Instantiate(enemigocirculotio);
		enemigocirculo.parent = circulogay.transform;
		enemigocirculo.localScale = escala;
		Vector3 alturaputo = enemigocirculo.GetChild(0).GetChild(0).localPosition;
		//alturaputo.x = 10.13653f;
		alturaputo.x = alturagay;
		

		Vector3 pos;
		pos.x = 6.4f;
		pos.y = -0.1739178f;
		pos.z = -1.79f;
		enemigocirculo.localPosition = pos;

		enemigocirculo.GetChild(0).GetChild(0).localPosition = alturaputo;

		Debug.Log(transform.parent.gameObject);

	}
	void generarcirculoraro()
	{
		circulogayraro = GameObject.Find("circulorarohomosexual");
		circuloraro = Instantiate(enemigoraro);
		circuloraro.parent = circulogayraro.transform;
		circuloraro.localScale = escala;
		circuloraro.localEulerAngles = Vector3.zero;
		Vector3 pos;
		pos.x = 0;
		pos.y = -5.5f;
		pos.z = 0;
		circuloraro.localPosition = pos;
		escalaorazgrande = circuloraro.GetChild(0).GetChild(0).localScale;
	}

   void selectoria()
    {
	//	Instanciadorenemigo.ronda = 21;
		if (Instanciadorenemigo.ronda == 1)
		{
			AIState = 1;
		}

		if (Instanciadorenemigo.ronda == 2)
		{
			AIState = 2;
			int polla = Random.Range(1, 3);
			if (polla == 1) { derecho = false; }
			if (polla == 2) { derecho = true; }
		}

		if (Instanciadorenemigo.ronda == 3)
		{
			AIState = 3;
			velocidadsin = 0.8f;
			rangosin = 60;
		}

		if (Instanciadorenemigo.ronda == 4)
		{
			AIState = 5;
			velocidadsin = 1f;
			rangosin = 110;
			velor = velocidadsin;
			ranor = rangosin;
			tiempoespera = Time.time + 3;
		}

		if (Instanciadorenemigo.ronda == 5)
		{
			AIState = 3;
		}

		if (Instanciadorenemigo.ronda == 6)
		{
			AIState = 1;
		}

		if (Instanciadorenemigo.ronda == 7)
		{
			AIState = 2;
			int polla = Random.Range(1, 3);
			if (polla == 1) { derecho = false; }
			if (polla == 2) { derecho = true; }
		}

		if (Instanciadorenemigo.ronda == 8)
		{
			AIState = 3;
			velocidadsin = 1f;
			rangosin = 180;
		}

		if (Instanciadorenemigo.ronda == 9)
		{
			AIState = 5;
			velocidadsin = 1f;
			rangosin = 140;
			velor = velocidadsin;
			ranor = rangosin;
			tiempoespera = Time.time + 3;
			regatesfinales = true;
		}

		if (Instanciadorenemigo.ronda == 10)
		{
			AIState = 3;
		}

		if (Instanciadorenemigo.ronda == 11)
		{
			AIState = 1;
		}

		if (Instanciadorenemigo.ronda == 12)
		{
			AIState = 2;
			int polla = Random.Range(1, 3);
			if (polla == 1) { derecho = false; }
			if (polla == 2) { derecho = true; }
		}

		if (Instanciadorenemigo.ronda == 13)
		{
			AIState = 4;
			tiempoespera = Time.time + 4;
			velocidadlat = 140;
			int polla = Random.Range(1, 3);
			if (polla == 1) { derecho = false; }
			if (polla == 2) { derecho = true; }
		}

		if (Instanciadorenemigo.ronda == 14)
		{
			AIState = 5;
			velocidadsin = 1f;
			rangosin = 150;
			velor = velocidadsin;
			ranor = rangosin;
			tiempoespera = Time.time + 3;
		}

		if (Instanciadorenemigo.ronda == 15)
		{
			AIState = 5;
			velocidadsin = 1f;
			rangosin = 160;
			velor = velocidadsin;
			ranor = rangosin;
			tiempoespera = Time.time + 3;
		}

		if (Instanciadorenemigo.ronda == 16)
		{
			AIState = 1;
			velocidad = Random.Range(1f, 3f);
		}

		if (Instanciadorenemigo.ronda == 17)
		{
			AIState = 2;
			int polla = Random.Range(1, 3);
			if (polla == 1) { derecho = false; }
			if (polla == 2) { derecho = true; }
		}

		if (Instanciadorenemigo.ronda == 18)
		{
			AIState = 3;
		}

		if (Instanciadorenemigo.ronda == 19)
		{
			AIState = 4;
			tiempoespera = Time.time + 4;
			velocidadlat = 130;
			int polla = Random.Range(1, 3);
			if (polla == 1) { derecho = false; }
			if (polla == 2) { derecho = true; }
		}

		if (Instanciadorenemigo.ronda == 20)
		{
			AIState = 3;
			regatesfinales = true;
			velocidadsin = 1f;
			rangosin = 170;
		}

		if (Instanciadorenemigo.ronda == 21)
		{
			AIState = 1;
			velocidad = Random.Range(1f, 3f);
			multiplicar = true;
		}

		if (Instanciadorenemigo.ronda == 22)
		{
			AIState = 2;
			int polla = Random.Range(1, 3);
			if (polla == 1) { derecho = false; }
			if (polla == 2) { derecho = true; }
		}

		if (Instanciadorenemigo.ronda == 23)
		{
			AIState = 3;
			multiplicar = true;
		}

		if (Instanciadorenemigo.ronda == 24)
		{
			AIState = 3;
			multiplicar = true;
		}

		if (Instanciadorenemigo.ronda > 24)
		{
			int polla = Random.Range(1, 6);
			AIState = polla;

			int polla1 = Random.Range(1, 101);
			if (polla1 > 70) { regatesfinales = true; }
			int polla2 = Random.Range(1, 101);
			if (polla2 > 60) { multiplicar = true; }

			
			if (AIState == 1)
			{
				velocidad = Random.Range(1f, 3f);
			}
			if (AIState == 2)
			{
				velocidadlat = Random.Range(70, 130);
			}
			if (AIState == 3)
			{
				velocidadsin = 1f;
				rangosin = 250;
			}
			if (AIState == 5)
			{
				velocidadsin = 1f;
				rangosin = 180;
				velor = velocidadsin;
				ranor = rangosin;
				tiempoespera = Time.time + 3;
			}

		}
		}

	
	
	void Update () {


		switch (AIState)
		{
			case 1: //cae en linea recta

				break;

		
			
			case 2: // va pa un lao;
				
				Vector3 pos = transform.eulerAngles;
				if (derecho && !movifinal)
                {

					pos.y += velocidadlat * Time.deltaTime;

				}
                if (!derecho && !movifinal)
                {
					
					pos.y -= velocidadlat * Time.deltaTime;

				}
				transform.eulerAngles = pos;

				if (regatesfinales && alturaverde < 1.2f)
				{
					movifinal = true;

					velocidadsin = 20f;
					rangosin = 30;
					tiempoespera = Time.time + 0.3f;
					
					Vector3 _newPosition = transform.eulerAngles;
					_newPosition.y += Mathf.Sin(Time.time * velocidadsin) * rangosin * Time.deltaTime;
					transform.eulerAngles = _newPosition;
				}
				break;
			
			
			
			case 3: // math sin constante

				//0.00714f
				
				if (regatesfinales && alturaverde <1.2f)
				{
					movifinal = true;
					
					velocidadsin = 20f;
					rangosin = 30;
					tiempoespera = Time.time + 0.3f;
				
					Vector3 _newPosition = transform.eulerAngles;
					_newPosition.y += Mathf.Sin(Time.time * velocidadsin) * rangosin * Time.deltaTime;
					transform.eulerAngles = _newPosition;
				}

				if (!movifinal)
				{
					Vector3 _newPosition = transform.eulerAngles;
					_newPosition.y += Mathf.Sin(Time.time * velocidadsin) * rangosin * Time.deltaTime;
					transform.eulerAngles = _newPosition;
				}

				break;


		
			case 4: //se va pa un lao pero cuando puto tiempo pasa hace math sin


				if (Time.time > tiempoespera)
                {
					velocidadsin = 1f;
					rangosin = 70;

					Vector3 posiciongay = transform.eulerAngles;
					posiciongay.y += Mathf.Sin(Time.time * velocidadsin) * rangosin * Time.deltaTime;
					transform.eulerAngles = posiciongay;
				}
                else
                {
					Vector3 posgay = transform.eulerAngles;
					if (derecho)
					{

						posgay.y += velocidadlat * Time.deltaTime;

					}
					else
					{

						posgay.y -= velocidadlat * Time.deltaTime;

					}
					transform.eulerAngles = posgay;
				}

				break;



			case 5: //math sin con filigranas

				
				
				Vector3 posiciongayputo = transform.eulerAngles;
				posiciongayputo.y += Mathf.Sin(Time.time * velocidadsin) * rangosin * Time.deltaTime;
				transform.eulerAngles = posiciongayputo;
				//				Debug.Log(tiempoespera);
				if (regatesfinales && alturaverde <1.2f)
				{
					movifinal = true;
					
					velocidadsin = 20f;
					rangosin = 30;
					tiempoespera = Time.time + 0.3f;
				}
				if (Time.time > tiempoespera && !movifinal)
				{
					if (!cambio)
                    {
						//filigranas

						velocidadsin = 25f;
						rangosin = 40;
						tiempoespera = Time.time + 0.3f;
					}
					if (cambio)
					{
						//normal
						rangosin = ranor;
						velocidadsin = velor;
						tiempoespera = Time.time + 3;
					}
					cambio = !cambio;
					
				}

					break;

			
			default:
				AIState = 1;
				break;
		}

		if (alturaverde < 4 && multiplicar)
        {
			Transform enemigogeneral = GameObject.Find("Controlador").GetComponent<Instanciadorenemigo>().enemigogeneral;
			GameObject spaun = GameObject.Find("Spawnergay");			

			Transform enemigo = Instantiate(enemigogeneral);
			enemigo.SetParent(spaun.transform, false);
			enemigo.localPosition = Vector3.zero;
			Vector3 cerda = enemigo.GetChild(0).position;
			cerda.y = transform.position.y;
			enemigo.GetChild(0).position = cerda;
			float pos = transform.eulerAngles.y;
			Vector3 rot = enemigo.GetChild(0).localEulerAngles;
			rot.y = pos;
			enemigo.GetChild(0).localEulerAngles = rot;
			enemigo.GetChild(0).GetComponent<Enemigo>().Generado = true;
			enemigo.GetChild(0).GetComponent<Enemigo>().AIState = 2;
			enemigo.GetChild(0).GetComponent<Enemigo>().derecho = false;

			Transform enemigo1 = Instantiate(enemigogeneral);
			enemigo1.SetParent(spaun.transform, false);
			enemigo1.localPosition = Vector3.zero;
			enemigo1.GetChild(0).position = cerda;
			float pos1 = transform.eulerAngles.y;
			Vector3 rot1 = enemigo1.GetChild(0).localEulerAngles;
			rot1.y = pos1;
			enemigo1.GetChild(0).localEulerAngles = rot1;
			enemigo1.GetChild(0).GetComponent<Enemigo>().Generado = true;
			enemigo1.GetChild(0).GetComponent<Enemigo>().AIState = 2;
			enemigo1.GetChild(0).GetComponent<Enemigo>().derecho = true;

			enemigo.GetChild(0).SendMessage("generarcirculoraro"); enemigo1.GetChild(0).SendMessage("generarcirculoraro");
			enemigo.GetChild(0).SendMessage("generarcirculoclon", enemigocirculo.GetChild(0).GetChild(0).localPosition.x); enemigo1.GetChild(0).SendMessage("generarcirculoclon", enemigocirculo.GetChild(0).GetChild(0).localPosition.x);
			enemigo.GetChild(0).SendMessage("generardosde"); enemigo1.GetChild(0).SendMessage("generardosde");

			GameObject.Find("Controlador").GetComponent<Instanciadorenemigo>().enemigosadestruir += 2;
			GameObject.Find("Controlador").GetComponent<Instanciadorenemigo>().enemigosgenerados += 2;

			if (Instanciadorenemigo.ronda > 24)
			{
				int estado = 0;
				int polladas = Random.Range(0, 101);
				if (polladas > 50) { estado = 2; }
				else { estado = 3; enemigo.GetChild(0).GetComponent<Enemigo>().rangosin = -rangosin; }

				enemigo.GetChild(0).GetComponent<Enemigo>().AIState = estado;
				enemigo1.GetChild(0).GetComponent<Enemigo>().AIState = estado;				
			}

			multiplicar = false;
		}
		
		rojogay();
		posplano();
		poscirc();
		poscircraro();
		acercar();
	}
	void acercar()
    {
		Vector3 pos = transform.position;
		pos.y -= velocidad * Time.deltaTime;
		transform.position = pos;
		altura = pos.y;
		rojo.position = transform.position;


		
		Vector3 plano = enemigoplano.localPosition;
		plano.y -= velocidad * Time.deltaTime;
		//enemigoplano.localPosition = plano;


		Vector3 plano2 = enemigocirculo.GetChild(0).GetChild(0).localPosition;

		plano2.x -= velocidad * Time.deltaTime;
		enemigocirculo.GetChild(0).GetChild(0).localPosition = plano2;

	}
	void posplano()
	{
		Vector3 plano = enemigoplano.localPosition;
		plano.y = altura;
		plano.y *= 1.0558f;
		plano.y += 6.0728f;
		alturaverde = enemigoplano.localPosition.y;
		enemigoplano.localPosition = plano;


		float posgen = transform.eulerAngles.y;
		posgen *= 16.34f;
		posgen /= 360;
		Vector3 posicion;
		posicion.x = enemigoplano.GetChild(0).localPosition.x;
		posicion.y = enemigoplano.GetChild(0).localPosition.y;
		posicion.z = posgen;
		enemigoplano.GetChild(0).localPosition = posicion;

	}
	void rojogay()
	{
		Vector3 posactwena = rojo.transform.eulerAngles;
		float penes = transform.eulerAngles.y;
		penes = 360 - penes;
		posactwena.y = penes;
		rojo.eulerAngles = posactwena;
	}
	void poscirc()
	{
		Vector3 pene = enemigocirculo.GetChild(0).GetChild(0).localScale; //escala
		pene.z = alturaverde;
		pene.z *= 0.441f;
		pene.z += 0.6889f;
		enemigocirculo.GetChild(0).GetChild(0).localScale = pene;


		Vector3 posact = enemigocirculo.GetChild(0).transform.localEulerAngles;
		//posact.z = 90;
		posact.y = transform.localEulerAngles.y;
		enemigocirculo.GetChild(0).localEulerAngles = posact;
	}
	void poscircraro()
	{
		float posicion = circuloraro.localPosition.y; //calcular radio
		posicion *= 0.0267f;
		posicion += 3.408f;
		Vector3 lapos = Vector3.zero;
		lapos.x = posicion;
		circuloraro.GetChild(0).localPosition = lapos;

		float eje = enemigoplano.localPosition.y; //distancia relativa
		eje *= -8.8175f;
		eje -= 0.6428f;
		Vector3 posiciongay;
		posiciongay.x = circuloraro.localPosition.x;
		posiciongay.y = eje;
		posiciongay.z = circuloraro.localPosition.z;
		circuloraro.localPosition = posiciongay;

		Vector3 posact = circuloraro.transform.localEulerAngles;
		//posact.z = 90;
		posact.y = transform.localEulerAngles.y;
		circuloraro.localEulerAngles = posact;


		//	0.2617652x 1.158565y -0.3971801z - 76.10054m

		//	0.1008545x 0.446379y -0.153028z - 21m   0.38461factor max

		

		if (circuloraro.localPosition.y > -21)
		{
			circuloraro.GetChild(0).GetChild(0).localScale = escalaoraz;
		}
        else
        {
			Vector3 polladas = escalaorazgrande;
			float dist = circuloraro.localPosition.y;
			dist *= -0.0112f;
			dist += 0.1501f;
			polladas *= dist;
			circuloraro.GetChild(0).GetChild(0).localScale = polladas;
		}

		circuloraro.GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = true;
	}
}