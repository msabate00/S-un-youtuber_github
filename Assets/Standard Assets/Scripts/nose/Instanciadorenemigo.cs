using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Instanciadorenemigo : MonoBehaviour {

	public GameObject sonidosputos;


	public static int ronda = 1;

	public static int vidas = 3;

	public int cantidad;

	public float enemigosadestruir;
	public int enemigosdestruidos;
	public int enemigosgenerados = 0;

	public int basesdestruidas = 0;
	public int primero;
	public int segundo;
	public int tercero;
	public int cuarto;

	private bool tiempovaria = false;

	private float tiempoani = 0.035f;

	private bool lehedaotio = false;


	public Transform enemigogeneral;
//	private Transform enemigo;
	[HideInInspector]
	public GameObject spaun;

	public RectTransform rojui;
	public RectTransform amui;
	public RectTransform verdui;
	public RectTransform azui;

	public GameObject[] rojo;
	public GameObject[] amarillo;
	public GameObject[] verde;
	public GameObject[] azul;

	public Vector3[][] arraysizes = new Vector3[4][];
	public Vector3[] asignarsizes = new Vector3[4];
	public Vector2[][] arraypos = new Vector2[4][];
	public Vector2[] asignarpos = new Vector2[4];

	public Vector3[] verdesizes = new Vector3[4];
	public Vector3[] rojosizes = new Vector3[3];
	public Vector3[] azulsizes = new Vector3[3];
	public Vector3[] amsizes = new Vector3[3];

	public Vector2[] verdepos = new Vector2[7];
	public Vector2[] ampos = new Vector2[7];
	public Vector2[] rojopos = new Vector2[7];
	public Vector2[] azulpos = new Vector2[7];

	public GameObject particulasgays;

	public Transform[] cosas;

	public float tiempoespera = 0.5f;
	private float tiempogay;
	public bool instanciar = false;

	private int rondact;

	private bool permiso = false;

	private Vector2 verdefullpos = new Vector2(0.1f, 0); //full screen
	private Vector2 verdeiz = new Vector2(-378, 100); //mitad izquierda
	private Vector2 verdede = new Vector2(378, 100); //mitad derecha
	private Vector2 verdecuiz = new Vector2(-460, 274); //cuarto arriba izquierda
	private Vector2 verdecude = new Vector2(581, 274); //cuarto arriba derecha
	private Vector2 verdecuabde = new Vector2(581, -277); //cuarto abajo derecha
	private Vector2 verdecuabiz = new Vector2(-472, -277); //cuarto abajo izquierda
	private Vector3 verdefullsize = new Vector3(6.218644f, 8.5721f, 19.49963f);
	private Vector3 verdeizsize = new Vector3(3.7493f, 6.979038f, 15.93133f);
	private Vector3 verdecusize = new Vector3(2.199409f, 4.094034f, 9.345615f);

	private Vector2 amfullpos = new Vector2(0, 0);
	private Vector2 amde = new Vector2(500, -135);
	private Vector2 amiz = new Vector2(-450, -30);
	private Vector2 amcude = new Vector2(581, 250);
	private Vector2 amcuiz = new Vector2(-469, 250);
	private Vector2 amcuabiz = new Vector2(-469, -260);
	private Vector2 amcuabde = new Vector2(586, -260);
	private Vector3 amfullsize = new Vector3(12.1166f, 9.235042f, 21.08114f);
	private Vector3 amdesize = new Vector3(9.216324f, 7.024504f, 16.03507f);
	private Vector3 amcusize = new Vector3(5.768626f, 4.396735f, 10.03658f);

	private Vector2 rojfullpos = new Vector2(0, 0);
	private Vector2 rojde = new Vector2(423, -101);
	private Vector2 rojiz = new Vector2(-423, -101);
	private Vector2 rojcude = new Vector2(590, 271);
	private Vector2 rojcuabde = new Vector2(629, -282);
	private Vector2 rojcuabiz = new Vector2(-432, -282);
	private Vector2 rojcuiz = new Vector2(-432, 271);
	private Vector3 rojfullsize = new Vector3(16.99739f, 9.544738f, 21.78816f);
	private Vector3 rojdesize = new Vector3(10.12235f, 7.715055f, 17.61147f);
	private Vector3 rojcusize = new Vector3(5.949425f, 4.534533f, 10.35116f);

	private Vector2 azfullpos = new Vector2(0, 0);
	private Vector2 azde = new Vector2(491, -129);
	private Vector2 aziz = new Vector2(-465, -111);
	private Vector2 azcuabiz = new Vector2(-465, -277);
	private Vector2 azcuabde = new Vector2(590, -277);
	private Vector2 azcude = new Vector2(590, 280);
	private Vector2 azcuiz = new Vector2(-478, 280);
	private Vector3 azfullsize = new Vector3(12.55747f, 9.571046f, 21.84818f);
	private Vector3 azdesize = new Vector3(9.731695f, 7.4173f, 16.93174f);
	private Vector3 azcusize = new Vector3(5.949432f, 4.534536f, 10.35115f);

	private Vector2 fuera = new Vector2(1050, 1000);

	
	private Vector3 sizever;
	private Vector3 sizeam;
	private Vector3 sizeroj;
	private Vector3 sizeaz;

	private Vector2 posver;
	private Vector2 posam;
	private Vector2 posroj;
	private Vector2 posaz;

	private bool pausao = false;

	void vista1()
	{
		asignarsizes[primero] = arraysizes[primero][0];
		asignarpos[primero] = arraypos[primero][0];


		if (0 != primero)
		{
			asignarsizes[0] = arraysizes[0][3];
			asignarpos[0] = arraypos[0][7];
		}
		if (1 != primero)
		{
			asignarsizes[1] = arraysizes[1][3];
			asignarpos[1] = arraypos[1][7];
		}
		if (2 != primero)
		{
			asignarsizes[2] = arraysizes[2][3];
			asignarpos[2] = arraypos[2][7];
		}
		if (3 != primero)
		{

			asignarsizes[3] = arraysizes[3][3];
			asignarpos[3] = arraypos[3][7];
		}
	}

	void vista2()
	{

		asignarsizes[primero] = arraysizes[primero][1];
		asignarpos[primero] = arraypos[primero][1];
				
		asignarsizes[segundo] = arraysizes[segundo][1];
		asignarpos[segundo] = arraypos[segundo][2];

		


		if (0 != primero && 0 != segundo)
        {
			asignarsizes[0] = arraysizes[0][3];
			asignarpos[0] = arraypos[0][7];
		}
		if (1 != primero && 1 != segundo)
		{
			asignarsizes[1] = arraysizes[1][3];
			asignarpos[1] = arraypos[1][7];
		}
		if (2 != primero && 2 != segundo)
		{
			asignarsizes[2] = arraysizes[2][3];
			asignarpos[2] = arraypos[2][7];
		}
		if (3 != primero && 3 != segundo)
		{
			
			asignarsizes[3] = arraysizes[3][3];
			asignarpos[3] = arraypos[3][7];
		}
	}

	void vista3()
	{
		Debug.Log("putogay");
		int pene = Random.Range(0, 4);
		int borrado = 0;
		if (pene == 0)
        {
			borrado = primero;
			primero = 4;
        }
		if (pene == 1)
		{
			borrado = segundo;
			segundo = 4;
		}
		if (pene == 2)
		{
			borrado = tercero;
			tercero = 4;
		}
		if (pene == 3)
		{
			borrado = cuarto;
			cuarto = 4;
		}
				
		
		if (primero != 4)
        {
			asignarsizes[primero] = arraysizes[primero][2];
			asignarpos[primero] = arraypos[primero][3];
		}

		if (segundo != 4)
		{
			asignarsizes[segundo] = arraysizes[segundo][2];
			asignarpos[segundo] = arraypos[segundo][4];
		}

		if (tercero != 4)
		{
			asignarsizes[tercero] = arraysizes[tercero][2];
			asignarpos[tercero] = arraypos[tercero][5];
		}
		if (cuarto != 4)
		{
			asignarsizes[cuarto] = arraysizes[cuarto][2];
			asignarpos[cuarto] = arraypos[cuarto][6];
		}




		if (0 != primero && 0 != segundo && 0 != tercero && 0 != cuarto || 0 == borrado)
		{
			asignarsizes[0] = arraysizes[0][3];
			asignarpos[0] = arraypos[0][7];
		}
		if (1 != primero && 1 != segundo && 1 != tercero && 1 != cuarto || 1 == borrado)
		{
			asignarsizes[1] = arraysizes[1][3];
			asignarpos[1] = arraypos[1][7];
		}
		if (2 != primero && 2 != segundo && 2 != tercero && 2 != cuarto || 2 == borrado)
		{
			asignarsizes[2] = arraysizes[2][3];
			asignarpos[2] = arraypos[2][7];
		}
		if (3 != primero && 3 != segundo && 3 != tercero && 3 != cuarto || 3 == borrado)
		{

			asignarsizes[3] = arraysizes[3][3];
			asignarpos[3] = arraypos[3][7];
		}
	}

	void vista4()
	{
		asignarsizes[primero] = arraysizes[primero][2];
		asignarpos[primero] = arraypos[primero][3];

		asignarsizes[segundo] = arraysizes[segundo][2];
		asignarpos[segundo] = arraypos[segundo][4];

		asignarsizes[tercero] = arraysizes[tercero][2];
		asignarpos[tercero] = arraypos[tercero][5];

		asignarsizes[cuarto] = arraysizes[cuarto][2];
		asignarpos[cuarto] = arraypos[cuarto][6];





		if (0 != primero && 0 != segundo && 0 != tercero && 0 != cuarto)
		{
			asignarsizes[0] = arraysizes[0][3];
			asignarpos[0] = arraypos[0][7];
		}
		if (1 != primero && 1 != segundo && 1 != tercero && 1 != cuarto)
		{
			asignarsizes[1] = arraysizes[1][3];
			asignarpos[1] = arraypos[1][7];
		}
		if (2 != primero && 2 != segundo && 2 != tercero && 2 != cuarto)
		{
			asignarsizes[2] = arraysizes[2][3];
			asignarpos[2] = arraypos[2][7];
		}
		if (3 != primero && 3 != segundo && 3 != tercero && 3 != cuarto)
		{

			asignarsizes[3] = arraysizes[3][3];
			asignarpos[3] = arraypos[3][7];
		}
	}

	void asignarcosas()
	{
		permiso = true;

		azulpos[0] = azfullpos;
		azulpos[1] = aziz;
		azulpos[2] = azde;
		azulpos[3] = azcuiz;
		azulpos[4] = azcude;
		azulpos[5] = azcuabde;
		azulpos[6] = azcuabiz;
		azulpos[7] = fuera;

		rojopos[0] = rojfullpos;
		rojopos[1] = rojiz;
		rojopos[2] = rojde;
		rojopos[3] = rojcuiz;
		rojopos[4] = rojcude;
		rojopos[5] = rojcuabde;
		rojopos[6] = rojcuabiz;
		rojopos[7] = fuera;

		ampos[0] = amfullpos;
		ampos[1] = amiz;
		ampos[2] = amde;
		ampos[3] = amcuiz;
		ampos[4] = amcude;
		ampos[5] = amcuabde;
		ampos[6] = amcuabiz;
		ampos[7] = fuera;

		verdepos[0] = verdefullpos;
		verdepos[1] = verdeiz;
		verdepos[2] = verdede;
		verdepos[3] = verdecuiz;
		verdepos[4] = verdecude;
		verdepos[5] = verdecuabde;
		verdepos[6] = verdecuabiz;
		verdepos[7] = fuera;


		verdesizes[0] = verdefullsize;
		verdesizes[1] = verdeizsize;
		verdesizes[2] = verdecusize;
		verdesizes[3] = Vector3.zero;

		rojosizes[0] = rojfullsize;
		rojosizes[1] = rojdesize;
		rojosizes[2] = rojcusize;
		rojosizes[3] = Vector3.zero;

		azulsizes[0] = amfullsize;
		azulsizes[1] = amdesize;
		azulsizes[2] = amcusize;
		azulsizes[3] = Vector3.zero;

		amsizes[0] = azfullsize;
		amsizes[1] = azdesize;
		amsizes[2] = azcusize;
		amsizes[3] = Vector3.zero;

		arraysizes[0] = verdesizes;
		arraysizes[1] = amsizes;
		arraysizes[2] = rojosizes;
		arraysizes[3] = azulsizes;

		arraypos[0] = verdepos;
		arraypos[1] = ampos;
		arraypos[2] = rojopos;
		arraypos[3] = azulpos;

		asignarsizes[0] = sizever;
		asignarsizes[1] = sizeam;
		asignarsizes[2] = sizeroj;
		asignarsizes[3] = sizeaz;

		asignarpos[0] = posver;
		asignarpos[1] = posam;
		asignarpos[2] = posroj;
		asignarpos[3] = posaz;


		

		Debug.Log(arraysizes[0][2]);
		Debug.Log(arraysizes[1][2]);
		Debug.Log(arraysizes[2][2]);
		Debug.Log(arraysizes[3][2]);
	}

	void selectorcams()
    {


		asignarcosas();

		segundo = 0;
		tercero = 0;
		cuarto = 0;

		cantidad = Random.Range(1, 5);
		cantidad = 3;
		int pene = Random.Range(0, 4);
		while (pene == primero) {
			pene = Random.Range(0, 4);
		}
		if (pene != primero)
        {
			primero = pene;
		}



		dos();
	}
	
	void dos()
    {
		if (cantidad < 2) { vista1(); return; }
		int pene1 = Random.Range(0, 4);
		while (pene1 == primero)
		{
			pene1 = Random.Range(0, 4);
			
		}
		if (pene1 != primero)
        {
			segundo = pene1;
			tres();
		}
	}

	void tres()
	{
		if (cantidad < 3) { vista2(); return; }
		int pene1 = Random.Range(0, 4);
		while (pene1 == primero || pene1 == segundo)
		{
			pene1 = Random.Range(0, 4);

		}
		if (pene1 != primero && pene1 != segundo)
		{
			tercero = pene1;
		}
		if (cantidad == 3)
        {
			trespartedos();
		}

		if (cantidad == 4)
		{
			cuatro();
		}
	}

	void trespartedos()
    {
		int pene1 = Random.Range(0, 4);
		while (pene1 == primero || pene1 == segundo || pene1 == tercero)
		{
			pene1 = Random.Range(0, 4);

		}
		if (pene1 != primero && pene1 != segundo && pene1 != tercero)
		{
			cuarto = pene1;
		}
		vista3();
	}
	void cuatro()
	{
		if (cantidad < 4) { vista3(); return; }
		int pene1 = Random.Range(0, 4);
		while (pene1 == primero || pene1 == segundo || pene1 == tercero)
		{
			pene1 = Random.Range(0, 4);

		}
		if (pene1 != primero && pene1 != segundo && pene1 != tercero)
		{
			cuarto = pene1;
		}
		vista4();
		
	}

	



	void Awake()
    {
		//Application.targetFrameRate = 120;
		QualitySettings.maxQueuedFrames = 0;
		ehhyokse.muerto = false;
	}

	void Start () {
		
		spaun = GameObject.Find("Spawnergay");
		ronda = 1;
		posiciones();
		

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

		if (enemigosdestruidos >= enemigosadestruir && !lehedaotio)
        {
			ronda += 1;
			Sonidosgays(4);
			Invoke("posiciones", 1.069f);
			Invoke("activador", 1.069f);
			lehedaotio = true;

		}


		//	posiciones();

		//Debug.Log(amui.anchoredPosition);
		//	Debug.Log(amui.localScale);
		if (ronda > 24 && permiso)
		{
			sizever = asignarsizes[0];
			sizeam = asignarsizes[1];
			sizeroj = asignarsizes[2];
			sizeaz = asignarsizes[3];

			posver = asignarpos[0];
			posam = asignarpos[1];
			posroj = asignarpos[2];
			posaz = asignarpos[3];
		}
		verdui.anchoredPosition = Vector2.Lerp(verdui.anchoredPosition, posver, tiempoani * (Time.deltaTime / 0.013f));
		verdui.localScale = Vector3.Lerp(verdui.localScale, sizever, tiempoani);

		rojui.anchoredPosition = Vector2.Lerp(rojui.anchoredPosition, posroj, tiempoani * (Time.deltaTime / 0.013f));
		rojui.localScale = Vector3.Lerp(rojui.localScale, sizeroj, tiempoani * (Time.deltaTime / 0.013f));

		amui.anchoredPosition = Vector2.Lerp(amui.anchoredPosition, posam, tiempoani * (Time.deltaTime / 0.013f));
		amui.localScale = Vector3.Lerp(amui.localScale, sizeam, tiempoani * (Time.deltaTime / 0.013f));

		azui.anchoredPosition = Vector2.Lerp(azui.anchoredPosition, posaz, tiempoani * (Time.deltaTime / 0.013f));
		azui.localScale = Vector3.Lerp(azui.localScale, sizeaz, tiempoani * (Time.deltaTime / 0.013f));
		
		if (Time.time > tiempogay && instanciar && enemigosgenerados < enemigosadestruir)
        {
			enemigosgenerados += 1;
			Transform enemigo = Instantiate(enemigogeneral);
			enemigo.SetParent(spaun.transform, false);
			enemigo.localPosition = Vector3.zero;

			float pos = Random.Range(0, 361);
			Vector3 rot = enemigo.GetChild(0).localEulerAngles;
			rot.y = pos;
			enemigo.GetChild(0).localEulerAngles = rot;

			enemigo.GetChild(0).GetComponent<Enemigo>().ronda = rondact;

			if (tiempovaria)
            {
				tiempoespera = Random.Range(0.8f, 2.5f);
            }

			tiempogay = Time.time + tiempoespera;
		}
		
	}

	
	
	void posiciones()
    {
		enemigosadestruir = 4;
		enemigosdestruidos = 0;
		enemigosgenerados = 0;

		if (ronda == 1)
        {
			enemigosadestruir = 4;
			tiempoespera = 2f;
			tiempovaria = false;
			sizever = verdefullsize;
			posver = verdefullpos;

			sizeroj = Vector3.zero;
			posroj = fuera;

			sizeam = Vector3.zero;
			posam = fuera;

			sizeaz = Vector3.zero;
			posaz = fuera;
			
		}

		if (ronda == 2)
		{
			enemigosadestruir = 4;
			tiempoespera = 2f;
			tiempovaria = false;
			sizever = Vector3.zero;
			posver = fuera;

			sizeroj = Vector3.zero;
			posroj = fuera;

			sizeam = amfullsize;
			posam = amfullpos;

			sizeaz = Vector3.zero;
			posaz = fuera;
		}

		if (ronda == 3)
		{
			enemigosadestruir = 4;
			tiempoespera = 1.5f;
			tiempovaria = false;
			sizever = verdeizsize;
			posver = verdeiz;

			sizeroj = Vector3.zero;
			posroj = fuera;

			sizeam = amdesize;
			posam = amde;

			sizeaz = Vector3.zero;
			posaz = fuera;
		}

		if (ronda == 4)
		{
			enemigosadestruir = 4;
			tiempoespera = 1.5f;
			tiempovaria = false;
			sizever = Vector3.zero;
			posver = fuera;

			sizeroj = Vector3.zero;
			posroj = fuera;

			sizeam = Vector3.zero;
			posam = fuera;

			sizeaz = azfullsize;
			posaz = azfullpos;
		}

		if (ronda == 5)
		{
			enemigosadestruir = 4;
			tiempoespera = 1.5f;
			tiempovaria = false;
			sizever = verdeizsize;
			posver = verdeiz;

			sizeroj = Vector3.zero;
			posroj = fuera;

			sizeam = Vector3.zero;
			posam = fuera;

			sizeaz = azdesize;
			posaz = azde;
		}
		
		if (ronda == 6)
		{
			enemigosadestruir = 8;
			tiempoespera = 1.5f;
			tiempovaria = true;
			sizever = Vector3.zero;
			posver = fuera;

			sizeroj = Vector3.zero;
			posroj = fuera;

			sizeam = amdesize;
			posam = amde;

			sizeaz = azdesize;
			posaz = aziz;
		}
		
		if (ronda == 7)
		{
			enemigosadestruir = 8;
			tiempoespera = 1.5f;
			tiempovaria = true;
			sizever = verdefullsize;
			posver = verdefullpos;

			sizeroj = Vector3.zero;
			posroj = fuera;

			sizeam = amfullsize;
			posam = amfullpos;

			sizeaz = Vector3.zero;
			posaz = fuera;
		}

		if (ronda == 8)
		{
			enemigosadestruir = 8;
			tiempoespera = 1.5f;
			tiempovaria = false;
			sizever = Vector3.zero;
			posver = fuera;

			sizeroj = rojfullsize;
			posroj = rojfullpos;

			sizeam = Vector3.zero;
			posam = fuera;

			sizeaz = Vector3.zero;
			posaz = fuera;
		}

		if (ronda == 9)
		{
			enemigosadestruir = 8;
			tiempoespera = 1.5f;
			tiempovaria = false;
			sizever = verdeizsize;
			posver = verdeiz;

			sizeroj = rojdesize;
			posroj = rojde;

			sizeam = Vector3.zero;
			posam = fuera;

			sizeaz = Vector3.zero;
			posaz = fuera;
		}

		if (ronda == 10)
		{
			enemigosadestruir = 8;
			tiempoespera = 1.5f;
			tiempovaria = true;
			sizever = Vector3.zero;
			posver = fuera;

			sizeroj = Vector3.zero;
			posroj = fuera;

			sizeam = amfullsize;
			posam = amfullpos;

			sizeaz = azfullsize;
			posaz = azfullpos;
		}

		if (ronda == 11)
		{
			enemigosadestruir = 10;
			tiempoespera = 1.1f;
			tiempovaria = false;
			sizever = Vector3.zero;
			posver = fuera;

			sizeroj = rojdesize;
			posroj = rojde;

			sizeam = amdesize;
			posam = amiz;

			sizeaz = Vector3.zero;
			posaz = fuera;
		}

		if (ronda == 12)
		{
			enemigosadestruir = 14;
			tiempoespera = 1.5f;
			tiempovaria = false;
			sizever = Vector3.zero;
			posver = fuera;

			sizeroj = rojfullsize;
			posroj = rojfullpos;

			sizeam = amfullsize;
			posam = amfullpos;

			sizeaz = Vector3.zero;
			posaz = fuera;
		}

		if (ronda == 13)
		{
			enemigosadestruir = 13;
			tiempoespera = 1.5f;
			tiempovaria = false;
			sizever = verdecusize;
			posver = verdecuiz;

			sizeroj = Vector3.zero;
			posroj = fuera;

			sizeam = amcusize;
			posam = amcude;

			sizeaz = azcusize;
			posaz = azcuabiz;
		}

		if (ronda == 14)
		{
			enemigosadestruir = 11;
			tiempoespera = 1.8f;
			tiempovaria = false;
			sizever = verdeizsize;
			posver = verdeiz;

			sizeroj = rojdesize;
			posroj = rojde;

			sizeam = Vector3.zero;
			posam = fuera;

			sizeaz = Vector3.zero;
			posaz = fuera;
		}

		if (ronda == 15)
		{
			enemigosadestruir = 10;
			tiempoespera = 1.7f;
			tiempovaria = false;
			sizever = verdecusize;
			posver = verdecuiz;

			sizeroj = rojcusize;
			posroj = rojcuabde;

			sizeam = Vector3.zero;
			posam = fuera;

			sizeaz = azcusize;
			posaz = azcuabiz;
		}

		if (ronda == 16)
		{
			enemigosadestruir = 11;
			tiempoespera = 1.5f;
			tiempovaria = true;
			sizever = verdefullsize;
			posver = verdefullpos;

			sizeroj = Vector3.zero;
			posroj = fuera;

			sizeam = Vector3.zero;
			posam = fuera;

			sizeaz = azfullsize;
			posaz = azfullpos;
		}

		if (ronda == 17)
		{
			enemigosadestruir = 19;
			tiempoespera = 1.5f;
			tiempovaria = false;
			sizever = Vector3.zero;
			posver = fuera;

			sizeroj = rojdesize;
			posroj = rojde;

			sizeam = Vector3.zero;
			posam = fuera;

			sizeaz = azdesize;
			posaz = aziz;
		}

		if (ronda == 18)
		{
			enemigosadestruir = 15;
			tiempoespera = 1.7f;
			tiempovaria = false;
			sizever = Vector3.zero;
			posver = fuera;

			sizeroj = rojcusize;
			posroj = rojcuabde;

			sizeam = amcusize;
			posam = amcude;

			sizeaz = azcusize;
			posaz = azcuabiz;
		}

		if (ronda == 19)
		{
			enemigosadestruir = 14;
			tiempoespera = 1.2f;
			tiempovaria = false;
			sizever = Vector3.zero;
			posver = fuera;

			sizeroj = rojfullsize;
			posroj = rojfullpos;

			sizeam = Vector3.zero;
			posam = fuera;

			sizeaz = azfullsize;
			posaz = azfullpos;
		}

		if (ronda == 20)
		{
			enemigosadestruir = 13;
			tiempoespera = 1.5f;
			tiempovaria = false;
			sizever = verdefullsize;
			posver = verdefullpos;

			sizeroj = rojcusize;
			posroj = rojcuabde;

			sizeam = amcusize;
			posam = amcude;

			sizeaz = Vector3.zero;
			posaz = fuera;
		}

		if (ronda == 21)
		{
			enemigosadestruir = 15;
			tiempoespera = 2.0f;
			tiempovaria = false;
			sizever = verdefullsize;
			posver = verdefullpos;

			sizeroj = rojfullsize;
			posroj = rojfullpos;

			sizeam = Vector3.zero;
			posam = fuera;

			sizeaz = Vector3.zero;
			posaz = fuera;
		}

		if (ronda == 22)
		{
			enemigosadestruir = 20;
			tiempoespera = 1.8f;
			tiempovaria = false;
			sizever = verdecusize;
			posver = verdecuiz;

			sizeroj = rojcusize;
			posroj = rojcuabde;

			sizeam = amcusize;
			posam = amcude;

			sizeaz = azcusize;
			posaz = azcuabiz;
		}

		if (ronda == 23)
		{
			enemigosadestruir = 15;
			tiempoespera = 2.3f;
			tiempovaria = false;
			sizever = verdefullsize;
			posver = verdefullpos;

			sizeroj = Vector3.zero;
			posroj = fuera;

			sizeam = amfullsize;
			posam = amfullpos;

			sizeaz = azfullsize;
			posaz = azfullpos;

			
		}

		if (ronda == 24)
		{
			enemigosadestruir = 15;
			tiempoespera = 2.2f;
			tiempovaria = false;
			sizever = verdecusize;
			posver = verdecuabiz;

			sizeroj = rojcusize;
			posroj = rojcuiz;

			sizeam = Vector3.zero;
			posam = fuera;

			sizeaz = azcusize;
			posaz = azcude;


		}

		if (ronda > 24)
        {		
			selectorcams();

			float penes = ronda;
			penes /= 2;
			penes = Mathf.Round(penes);
			enemigosadestruir = penes;
			tiempovaria = true;
		}
		lehedaotio = false;
		
	}
	
	void activador()
    {
		if (basesdestruidas == 0)
        {
			Sonidosgays(5);
		}
		basesdestruidas = 0;
		foreach (GameObject pene in rojo)
        {
			pene.GetComponent<MeshRenderer>().enabled = true;
        }
		foreach (GameObject pene in amarillo)
		{
			pene.GetComponent<MeshRenderer>().enabled = true;
		}
		
		foreach (GameObject pene in azul)
		{
			pene.GetComponent<MeshRenderer>().enabled = true;
		}
		foreach (GameObject pene in verde)
		{
			pene.GetComponent<MeshRenderer>().enabled = true;
		}
	}
	public void desactivador (int lol, GameObject[] penes) {
	
		if (rojo[lol].GetComponent<MeshRenderer>().enabled)
        {
			rojo[lol].GetComponent<MeshRenderer>().enabled = false;
			amarillo[lol].GetComponent<MeshRenderer>().enabled = false;
			azul[lol].GetComponent<MeshRenderer>().enabled = false;
			verde[lol].GetComponent<MeshRenderer>().enabled = false;

			GameObject rojog = Instantiate(particulasgays, penes[0].transform.GetChild(1).GetChild(0).position, penes[0].transform.GetChild(1).rotation);
			GameObject azulg = Instantiate(particulasgays, penes[2].transform.GetChild(0).GetChild(0).position, azul[lol].transform.rotation);
			GameObject amarillog = Instantiate(particulasgays, penes[3].transform.GetChild(0).GetChild(0).position, amarillo[lol].transform.rotation);
			GameObject verdeg = Instantiate(particulasgays, penes[1].transform.GetChild(0).position, verde[lol].transform.rotation);

			Vector3 escala1 = Vector3.zero;
			escala1.Set(1.7f, 1.7f, 1.7f);
			Vector3 escala2 = Vector3.zero;
			escala2.Set(2f, 2f, 2f);
			Vector3 escala3 = Vector3.zero;
			escala3.Set(8.43f, 12.87f, 12.87f);

			Vector3 pene = Vector3.zero;
			pene.z = -90;
			verdeg.transform.localEulerAngles = pene;

			Vector3 cojones = rojog.transform.localEulerAngles;
			cojones.x = -90;
			rojog.transform.localEulerAngles = cojones;

			cosas[0] = rojog.transform;
			cosas[1] = rojog.transform.GetChild(0);
			cosas[2] = rojog.transform.GetChild(1);
			cosas[3] = rojog.transform.GetChild(2);

			foreach (Transform t in cosas)
			{
				t.gameObject.layer = 1;
			}

			rojog.transform.localScale = escala1;
			azulg.transform.localScale = escala2;
			amarillog.transform.localScale = escala2;
			verdeg.transform.localScale = escala3;

			rojog.GetComponent<Animation>().Play("circulocolorojo");
			azulg.GetComponent<Animation>().Play("circulocolorazul");
			amarillog.GetComponent<Animation>().Play("circulocoloramar");
			verdeg.GetComponent<Animation>().Play("circulocolorverde");
		}
		

	

		foreach (GameObject pollas in penes)
		{
			Destroy(pollas);
		}
	}

	void Sonidosgays(int pollas)
    {		
			GameObject pene = Instantiate(sonidosputos);
			pene.SendMessage("Reproducir", pollas);		
	}

}

