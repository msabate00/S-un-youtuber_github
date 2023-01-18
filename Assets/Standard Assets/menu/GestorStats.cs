using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GestorStats : MonoBehaviour {

	public RectTransform[] linea;
	public Controlador con;
	public float siguiente;
	public float siguiente2;
	public GameObject panelgay;
	public GameObject panelgay2;
	public Transform gestorpaneles;
	public Transform gestorpaneles2;
	public Color c1;
	public Color c2;
	private bool gay = true;
	private bool gay2 = true;
	private List<Vector3> des = new List<Vector3>();
	private List<Vector3> des2 = new List<Vector3>();
	private List<GameObject> pans = new List<GameObject>();
	private List<GameObject> pans2 = new List<GameObject>();
	public float vel;
	private float desgay;
	private Vector3 orig;
	private float[] stats;
	private string[] textos;

	void Awake()
    {
		orig = GetComponent<RectTransform>().anchoredPosition3D;
		desgay = linea[0].anchoredPosition3D.y;

		stats = new float[11] {Controlador.bajas[2], Controlador.bajas[3], Controlador.bajas[4], Controlador.bajas[5], Controlador.bajas[6], Controlador.bajas[7], Controlador.bajas[8], Controlador.bajas[9], Controlador.bajastotales, Controlador.muertes, Controlador.puntostotales };
		textos = new string[11] { "Bajas escopeta", "Bajas lanzagranadas", "Bajas deagle duales", "Bajas subfusil plasma", "Bajas rifle", "Bajas sally & mustang", "Bajas ballesta", "Bajas ejecuciones", "Bajas totales", "Muertes", "Puntos totales" };
	}
	
	void OnEnable () {
		con = Controlador.ah;

		StopAllCoroutines();

		StartCoroutine(follame());

		StartCoroutine(Stats());
	}

	IEnumerator Stats()
    {
		gay2 = true;

		panelgay2.SetActive(true);

		for (int a = 0; a < pans2.Count; a++)
		{
			Destroy(pans2[a]);
		}

		pans2.Clear();
		des2.Clear();

		for (int i = textos.Length - 1; i >= 0; i--)
		{
			GameObject uf = Instantiate(panelgay2, transform.position, transform.rotation, gestorpaneles2);
			uf.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;
			des2.Insert(0, new Vector3(0, siguiente2 * i, 0));
			pans2.Insert(0, uf);

			uf.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = textos[i];
			
			string sex = "";
			char[] charsgays = stats[i].ToString("F0").ToCharArray();
			int cont = 0;
			for (int follame = charsgays.Length - 1; follame >= 0; follame--)
			{
				if (cont == 3) { sex = "." + sex; cont = 0; }
				sex = charsgays[follame] + sex;
				cont++;
			}

			uf.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = sex;
			if (gay2) { uf.transform.GetChild(0).GetComponent<Image>().color = c1; }
			else { uf.transform.GetChild(0).GetComponent<Image>().color = c2; }

			gay2 = !gay2;
		}

		panelgay2.SetActive(false);

		for (int o = 0; o < des2.Count; o++)
		{
			RectTransform p = pans2[o].GetComponent<RectTransform>();

			while (true)
			{
				p.anchoredPosition3D = Vector3.Lerp(p.anchoredPosition3D, des2[o], vel);

				if (Vector3.Distance(p.anchoredPosition3D, des2[o]) < 0.01f) { p.anchoredPosition3D = des2[o]; break; }
				yield return new WaitForEndOfFrame();
			}
		}
	}

	IEnumerator follame()
    {
		StartCoroutine(transicionwapa());
		panelgay.SetActive(true);
		
		for (int i = 0; i < linea.Length; i++)
		{
			linea[i].anchoredPosition3D = new Vector3(linea[i].anchoredPosition3D.x, 84.5f, 0);
			linea[i].localScale = new Vector3(linea[i].localScale.x, 0, 1);
		}

		for (int a = 0; a < pans.Count; a++)
		{
			Destroy(pans[a]);
		}
		pans.Clear();
		des.Clear();

		gay = true;

		for (int i = con.listastats.Count -1; i >= 0; i--)
		{
			GameObject uf = Instantiate(panelgay, transform.position, transform.rotation, gestorpaneles);
			uf.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;
			des.Insert(0, new Vector3(0, siguiente * i, 0));
			pans.Insert(0, uf);

			uf.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = con.listastats[i].Texto;

			string sex = "";
			char[] charsgays = con.listastats[i].Putos.ToString("F0").ToCharArray();
			int cont = 0;
			for (int follame = charsgays.Length -1; follame >= 0; follame--)
			{
				if (cont == 3) { sex = "." + sex; cont = 0; }
				sex = charsgays[follame] + sex;
				cont++;
			}

			uf.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = sex;
			uf.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = (i + 1).ToString("F0");
			if (gay) { uf.transform.GetChild(0).GetComponent<Image>().color = c1; }
			else { uf.transform.GetChild(0).GetComponent<Image>().color = c2; }

			gay = !gay;
		}

		panelgay.SetActive(false);
		StartCoroutine(lineasgays());

		for (int o = 0; o < des.Count; o++)
        {
			RectTransform p = pans[o].GetComponent<RectTransform>();

			while (true)
            {
				p.anchoredPosition3D = Vector3.Lerp(p.anchoredPosition3D, des[o], vel);

				if (Vector3.Distance(p.anchoredPosition3D, des[o]) < 0.01f) { p.anchoredPosition3D = des[o]; break; }
				yield return new WaitForEndOfFrame();
            }
        }

	}

	IEnumerator lineasgays()
    {
		float mierda = 84.5f - desgay;
		float timergay = Time.time + 1.4f;
		
		while (Time.time < timergay)
        {
			for (int i = 0; i < linea.Length; i++)
			{
				linea[i].anchoredPosition = new Vector2(linea[i].anchoredPosition.x, Mathf.MoveTowards(linea[i].anchoredPosition.y, desgay, (mierda / 1.2f) * Time.deltaTime));
				linea[i].localScale = new Vector3(linea[i].localScale.x, Mathf.MoveTowards(linea[i].localScale.y, 1, (1/1.2f) * Time.deltaTime), 1);
			}
			
			yield return new WaitForEndOfFrame();
		}
    }

	public void aparece()
    {
		menutrans.actual.desactivar2();
		gameObject.SetActive(true);
    }

	public void quitar()
	{
		menutrans.trans = false;
		menutrans.actual.reactivar();
		StopAllCoroutines();
		gameObject.SetActive(false);
	}

	IEnumerator transicionwapa()
    {
		RectTransform penis = GetComponent<RectTransform>();
		penis.anchoredPosition3D = orig + new Vector3(-1900, 0, 0);

		while (true)
        {
			penis.anchoredPosition3D = Vector3.MoveTowards(penis.anchoredPosition3D, orig, 7000 * Time.deltaTime);		
			if (penis.anchoredPosition3D == orig) { break; }

			yield return new WaitForEndOfFrame();
		}
    }

	public void aparecerControles()
	{
		menutrans.trans = true;
		menutrans.actual.desactivar3();
		menutrans.actual.gameObject.SetActive(false);

		gameObject.SetActive(true);

		StopAllCoroutines();
		StartCoroutine(transicionwapa());
	}

	void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape)) { quitar(); }
    }

}
