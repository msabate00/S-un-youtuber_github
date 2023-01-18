using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gestor1 : MonoBehaviour {

	public AudioClip fua;
	public GameObject con;
	public GameObject jugador;
	public RectTransform GestorPaneles;
	public GameObject panel;
	public Camera[] cam;
	public GameObject[] enemigoprefab;
	public float espacio;
	public float vel;

	private List<GameObject> penes = new List<GameObject>();
	private Vector3 orig;
	private Vector3 des;
	private Vector3 origtodo;
	private int actual = 0;
	private GameObject[] armas = new GameObject[9];
	private float[] Damages = new float[9];
	private float[] Stun = new float[9];
	public float[] Ratio = new float[9];
	private float[] Precision = new float[9];
	private float[] Municion = new float[9];
	private float[] Critico = new float[9];
	public string[] nombres;

	private float[] Max = new float[6];
	private float[][] arrays;

	private List<string> Tgays = new List<string>();
	private string T1 = "Una superescopeta capaz de disparar 2 veces a la vez. Muy eficaz a corta distancia pero su punto débil es el alcance. \nA parte de su poder endiablado de destrucción viene equipada con un gancho de carnicero que permite acercarse a un enemigo para contrarrestar su debilidad principal.";
	private string T2 = "Capaz de reventar enemigos en área de un solo disparo, el lanzagranadas es el arma pensada para acabar con tus enemigos rápidamente por excelencia. \nPor muy tentador que suene utilizarla recuerda que su limitada munición te puede jugar una mala pasada.";
	private string T3 = "Con el subfusil de plasma acabar con tus enemigos nunca fue tan placentero. Su decente precisión y alta cadencia de disparo hacen de este arma un aliado formidable. \nAdemás viene equipado con un lanzador de \"Orbes de energía\" que se autodireccionan hacia los enemigos tras un rebote.";
	private string T4 = "Un arma de alcance y ratio de disparo decente, el rifle acaba con los enemigos débiles de forma relativamente fácil. \nPara hacer de este arma un destructor temible, trae incluido un \"Railgun\" que encadenará \"Collateral\" y reventará fácilmente a los enemigos débiles.";
	private string T5 = "La legendaria arma de la serie \"Call Of Duty\", la Sally & mustang dispara proyectiles explosivos con daño de área. Las diferencias principales respecto al lanzagranadas son la carencia de gravedad y daño reducido, pero compensado con mayor cadencia de disparo y mucha más munición.";
	private string T6 = "Que hay mejor que una Desert eagle? Correcto, dos Desert eagle. Ésta doble arma aparte de tener una alta cadencia de disparo dispara 2 veces, tiene una excelente precisión apuntando y un daño decente, lo que la convierte en un arma ideal para combates lejanos.";
	private string T7 = "La ballesta es lo más parecido a un Sniper, tiene un daño excelente y una precisión perfecta apuntando. Es capaz de matar enemigos débiles de un disparo y es una auténtica pesadilla para los cyborgs. \nPor si fuera poco, viene agregado un lanzador de flechas explosivas que se adhieren al cuerpo de los enemigos y realiza un daño de área.";
	private string T8 = "Después de la épica batalla entre Kratos y Zeus el paradero de la Espada del Olimpo fue un misterio hasta hace poco. Un arma forjada de los Cielos y la Tierra durante la Gran Guerra para desterrar a los Titanes al Tártaro que a día de hoy sigue conservando el gran poder que el Dios de la Guerra empuñó una vez. Este arma es capaz de aniquilar enemigos de uno en uno de forma instantánea y además instancia el cuádruple de munición que con una ejecución estándar.";
	private string T9 = "El mítico desfibrilador del anterior God Of Valde vuelve reconvertido en un arma destructora, es capaz de acabar con tus enemigos de forma instantánea en un daño de área. \nSi bien ahora tiene un gran poder de aniquilación, ya no puede usarse en uno mismo para curarse.";

	void Start () {
		//Debug.Log(enemigoprefab[0].GetComponent<ManageEnemyStatus1>().health);

		GameObject[] armas2 = jugador.GetComponentInChildren<DisparoSelectivo>().Armas;

		orig = GestorPaneles.anchoredPosition3D;
		des = orig;

		float acum = 0;
		for (int i = 0; i < cam.Length; i++)
		{
			penes.Add(Instantiate(panel, panel.transform.position, panel.transform.rotation, transform.GetChild(3)));
			penes[penes.Count - 1].GetComponent<RectTransform>().anchoredPosition3D += new Vector3(acum, 0, 0);
			acum = acum + espacio;
		}

		panel.SetActive(false);

		int damagemax = 0;
		for (int i = 0; i < cam.Length; i++)
		{
			switch (i)
			{
				case 0:
					Tgays.Add(T1);
					armas[i] = armas2[2];
					Damages[i] = con.GetComponent<normalizador>().listagay[2].Damage * 7;
					Stun[i] = con.GetComponent<normalizador>().listagay[2].Stun * 7;
					Municion[i] = con.GetComponent<normalizador>().listagay[2].CargadoresAct;
					Critico[i] = con.GetComponent<normalizador>().listagay[2].Critico;
					break;
				case 1:
					Tgays.Add(T2);
					armas[i] = armas2[3];
					Damages[i] = con.GetComponent<normalizador>().listagay[3].Damage;
					Stun[i] = con.GetComponent<normalizador>().listagay[3].Stun;
					Municion[i] = con.GetComponent<normalizador>().listagay[3].CargadoresAct;
					Critico[i] = con.GetComponent<normalizador>().listagay[3].Critico;
					break;
				case 2:
					Tgays.Add(T3);
					armas[i] = armas2[5];
					Damages[i] = con.GetComponent<normalizador>().listagay[5].Damage;
					Stun[i] = con.GetComponent<normalizador>().listagay[5].Stun;
					Municion[i] = con.GetComponent<normalizador>().listagay[5].BalasAct;
					Critico[i] = con.GetComponent<normalizador>().listagay[5].Critico;
					break;
				case 3:
					Tgays.Add(T4);
					armas[i] = armas2[6];
					Damages[i] = con.GetComponent<normalizador>().listagay[6].Damage;
					Stun[i] = con.GetComponent<normalizador>().listagay[6].Stun;
					Municion[i] = con.GetComponent<normalizador>().listagay[6].BalasAct;
					Critico[i] = con.GetComponent<normalizador>().listagay[6].Critico;
					break;
				case 4:
					Tgays.Add(T5);
					armas[i] = armas2[7];
					Damages[i] = con.GetComponent<normalizador>().listagay[7].Damage;
					Stun[i] = con.GetComponent<normalizador>().listagay[7].Stun;
					Municion[i] = con.GetComponent<normalizador>().listagay[7].CargadoresAct;
					Critico[i] = con.GetComponent<normalizador>().listagay[7].Critico;
					break;
				case 5:
					Tgays.Add(T6);
					armas[i] = armas2[4];
					Damages[i] = con.GetComponent<normalizador>().listagay[4].Damage;
					Stun[i] = con.GetComponent<normalizador>().listagay[4].Stun;
					Municion[i] = con.GetComponent<normalizador>().listagay[4].CargadoresAct;
					Critico[i] = con.GetComponent<normalizador>().listagay[4].Critico;
					break;
				case 6:
					Tgays.Add(T7);
					armas[i] = armas2[4];
					Damages[i] = con.GetComponent<normalizador>().listagay[8].Damage;
					Stun[i] = con.GetComponent<normalizador>().listagay[8].Stun;
					Municion[i] = con.GetComponent<normalizador>().listagay[8].CargadoresAct;
					Critico[i] = con.GetComponent<normalizador>().listagay[8].Critico;
					break;
				case 7:
					Tgays.Add(T8);
					armas[i] = armas2[4];
					Damages[i] = 70;
					Stun[i] = 70;
					Municion[i] = 50;
					Critico[i] = 2;
					break;
				case 8:
					Tgays.Add(T9);
					armas[i] = armas2[4];
					Damages[i] = 70;
					Stun[i] = 70;
					Municion[i] = 50;
					Critico[i] = 2;
					break;
			}
		}

		for (int i = 0; i < armas.Length; i++) //Asignar valores a cada array
		{
			GunStatus af = armas[i].GetComponent<GunStatus>();

			Precision[i] = af.Precision;
			Ratio[i] = (1 / af.RatioDeDisparo) * 60;
			if (i == 5 ) { Precision[i] = af.aimPrecision; }
			if ( i == 6) { Precision[i] = 0.01f; }
		}

		arrays = new float[][] { Damages, Stun, Ratio, Precision, Municion, Critico }; //Hago el doble array

		Max = new float[arrays.Length];
		for (int i = 0; i < arrays.Length; i++) //Asignar valores máximos
		{
			Max[i] = Mathf.Max(arrays[i]);
			//if (i == 2) { Max[i] = Mathf.Min(arrays[i]); }
			if (i == 3) { Max[i] = Mathf.Min(arrays[i]); }
		}

		for (int i = 0; i < cam.Length; i++)
		{
			cam[i].transform.parent.gameObject.SetActive(true);

			RenderTexture tex = new RenderTexture(516, 516, 16, RenderTextureFormat.ARGB32);
			tex.Create();

			cam[i].targetTexture = tex;
			penes[i].GetComponentInChildren<RawImage>().texture = tex;

			penes[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = Tgays[i];

			penes[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = nombres[i];

			for (int o = 0; o < arrays.Length; o++) //Lol k cojones
            {
				penes[i].transform.GetChild(2).GetChild(o).GetChild(2).GetComponent<Image>().fillAmount = arrays[o][i] / Max[o];
				penes[i].transform.GetChild(2).GetChild(o).GetChild(4).GetComponent<TextMeshProUGUI>().text = arrays[o][i].ToString();

				if (o == 2) { penes[i].transform.GetChild(2).GetChild(o).GetChild(4).GetComponent<TextMeshProUGUI>().text = arrays[o][i].ToString("F0"); }
				//if (o == 2) { penes[i].transform.GetChild(2).GetChild(o).GetChild(2).GetComponent<Image>().fillAmount = Max[o] / arrays[o][i]; }
				if (o == 3) { penes[i].transform.GetChild(2).GetChild(o).GetChild(2).GetComponent<Image>().fillAmount = Max[o] / arrays[o][i]; }

				if (i == 7 || i == 8)
				{
					Destroy(penes[i].transform.GetChild(2).gameObject);

				}

			}

			
			

		}

		for (int i = 0; i < penes.Count; i++)
		{
			penes[i].SetActive(false);
		}
		penes[0].SetActive(true);

	}

	public void actualizar(bool derecha)
    {
		GetComponentInParent<AudioSource>().PlayOneShot(fua);
		if (derecha) { actual++; }
        else { actual--; }

		if (actual < 0) { actual = 0; }
        else if (actual >= cam.Length) { actual = cam.Length - 1; }
		des = orig + new Vector3(espacio * -actual, 0, 0);

		for (int i = 0; i < penes.Count; i++)
		{
			penes[i].SetActive(true);
		}
	}

	public void quitar()
    {
		//GetComponentInParent<AudioSource>().PlayOneShot(fua);
		menutrans.trans = false;
		menutrans.actual.reactivar();
		StopAllCoroutines();
		gameObject.SetActive(false);
	}

	public void aparecer()
    {
		menutrans.trans = true;
		menutrans.actual.desactivar3();
		actual = 0;
		des = orig;
		GestorPaneles.anchoredPosition3D = orig;
		gameObject.SetActive(true);

		if (penes.Count > 0)
		{
			for (int i = 0; i < penes.Count; i++)
			{
				penes[i].SetActive(false);
			}

			penes[0].SetActive(true);
		}

		StopAllCoroutines();
		StartCoroutine(transicionwapa());
	}

	IEnumerator transicionwapa()
	{
		RectTransform penis = GetComponent<RectTransform>();
		penis.anchoredPosition3D = origtodo + new Vector3(-1900, 0, 0);

		while (true)
		{
			penis.anchoredPosition3D = Vector3.MoveTowards(penis.anchoredPosition3D, origtodo, 7000 * Time.deltaTime);
			if (penis.anchoredPosition3D == origtodo) { break; }

			yield return new WaitForEndOfFrame();
		}
	}

	void Awake()
    {
		origtodo = GetComponent<RectTransform>().anchoredPosition3D;
	}

	void Update()
    {
		GestorPaneles.anchoredPosition3D = Vector3.Lerp(GestorPaneles.anchoredPosition3D, des, vel);

		if (Input.GetKeyDown(KeyCode.Escape)) { quitar(); }
	}
	
	
}
