using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gestor : MonoBehaviour {

	public AudioClip fua;
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
	public string[] nombres;

	private float[] Damages = new float[4];
	private float[] Vida = new float[4];
	private float[] Stun = new float[4];

	private float[] Max = new float[4];
	private float[][] arrays;

	private List<string> Tgays = new List<string>();
	private string T1 = "Hijo de generaciones pasadas de maestros shinobi, ha heredado dicha habilidad y junto con años de práctica es capaz de desviar la mayoría de proyectiles de armas de fuego. \nSu único punto débil es saltarle por encima, pues su velocidad y capacidad de reacción es suficientemente alta como para acabar contigo antes de que te des cuenta.";
	private string T2 = "Fabricado en laboratorios experimentales, el cyborg es un temible adversario si te pilla por sorpresa. Con su poderoso ataque en salto y ataques pirómanos buscará aniquilarte sin mostrar resentimiento. Aunque tenga menos vida que el ninja no te confundas, en manada es un auténtico peligro. \nMantener las distancias es la forma más sensata de acabar con él.";
	private string T3 = "Él es el típico soldado de fin de semana que no le gusta que le interrumpan su hora de los donuts. En solitario no presenta gran peligro, pero en grupo puede ser un verdadero problema.";
	private string T4 = "El ninja supremo lleva décadas practicando el arte de la espada para orgullecer a su espíritu. Es una imparable máquina de matar y por si fuera poco fusionó su cuerpo junto a la tecnología moderna para hacer de éste el rival perfecto. \nProcura tomártelo con calma contra este enemigo, salta los ataques de explosión a ras de suelo pero ten cuidado de no confundirlo con su otro ataque de explosión aérea.";

	void Start () {

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

		for (int i = 0; i < cam.Length; i++)
		{
			switch (i)
			{
				case 0:
					Tgays.Add(T1);
					break;
				case 1:
					Tgays.Add(T2);
					break;
				case 2:
					Tgays.Add(T3);
					break;
				case 3:
					Tgays.Add(T4);
					break;
			}
		}

		for (int i = 0; i < Damages.Length; i++) //Asignar valores a cada array
		{
			ManageEnemyStatus1 af = enemigoprefab[i].GetComponent<ManageEnemyStatus1>();

			Damages[i] = af.Damage;
			Vida[i] = af.health;
			Stun[i] = af.stunmax;

			if (af.resiststunparry < 100)
            {
				Vida[i] = Vida[i] / (af.resistparry / 100);
				Stun[i] = Stun[i] / (af.resiststunparry / 100);
			}
		}

		arrays = new float[][] { Damages, Vida, Stun }; //Hago el doble array

		Max = new float[arrays.Length];
		for (int i = 0; i < arrays.Length; i++) //Asignar valores máximos
		{
			Max[i] = Mathf.Max(arrays[i]);
		}

		for (int i = 0; i < cam.Length; i++)
		{
			cam[i].transform.parent.gameObject.SetActive(true);

			RenderTexture tex = new RenderTexture(516, 516, 16, RenderTextureFormat.ARGB32);
			tex.Create();

			cam[i].targetTexture = tex;
			penes[i].GetComponentInChildren<RawImage>().texture = tex;

			penes[i].GetComponentInChildren<TextMeshProUGUI>().text = Tgays[i];

			penes[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = nombres[i];

			for (int o = 0; o < arrays.Length; o++) //Lol k cojones
			{
				penes[i].transform.GetChild(2).GetChild(o).GetChild(2).GetComponent<Image>().fillAmount = arrays[o][i] / Max[o];
				penes[i].transform.GetChild(2).GetChild(o).GetChild(4).GetComponent<TextMeshProUGUI>().text = arrays[o][i].ToString("F0");				

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
