using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class putosgays : MonoBehaviour {

	private float pts = 0;
	public float ptsm = 0; //ESTOS 3 SON DISPLAY
	private TextMeshProUGUI textogay;

	public float puntos = 100; //ESTE ES EL VERDADERO CLON

	public Image[] ª;
	public Sprite[] a;

	public float[] rango;
	public static int nivel = 0;
	public float tiempoaguante = 5;

	private bool reset = false;

	public float puntosprev;
	public float contador = 0;
	public float vel;

	public Color[] p;
	private Color a1;
	private Color a2;
	private Color obj;

	public Transform sitio;
	public Transform prefab;
	public float disgay = 50;
	public List<Puntosgays> ah = new List<Puntosgays>();
	public List <int> gm = new List<int>();
	public List<RectTransform> rekt = new List<RectTransform>();
	public string[] tiponombre;
	public string[] tipo;
	public float[] tiempo;
	public float[] puntitos;
	public float factor = 1;

	void Start()
    {
		//pts = puntos;
		nivel = 0;
		a1 = p[0];
		a2 = p[1];
		obj = a2;
		ª[1].color = a1;
		puntosprev = puntos;
		textogay = GetComponent<TextMeshProUGUI>();

		if (Controlador.dificultad == 0)
		{
			factor = 0.8f;
		}
		else if (Controlador.dificultad == 1)
		{
			factor = 1f;
		}
		else
		{
			factor = 1.2f;
		}

		aymimadreelbichoSUUUUUUUUUUU();
	}
	
    public void gays(float val, int idgay)
	{
		if (idgay != 17 && idgay != 18)
        {
			val *= factor;
		}

		if (idgay == 9 && DisparoSelectivo.NumeroArmagay == 2)
        {
			val /= 7;
			val = Mathf.RoundToInt(val);
		}

		for(int i = gm.Count -1; i>=0; i--)
        {
			if (idgay == gm[i])
            {
				Puntosgays lol = ah[i];
				if (!lol.mod) { continue; }

				lol.Pts += val + Mathf.RoundToInt(nivel * val);
				
				CancelInvoke(tipo[idgay]);
				Invoke(tipo[idgay], tiempo[idgay]);				

				rekt[i].GetComponent<TextMeshProUGUI>().text = tiponombre[idgay] + " " + lol.Pts;
				return;
            }
        } // NO HAY NADA JAJA PUTO BLANQUITO DE MIERDA	

		//AQUI PON INSTANCIAR TEXTO CON RECTTRANSFORMS GY LO METERES ELN EL LA VABARIABNLE DE ANCVAJO
		float valtotal = 0;
		if (idgay == 18 || idgay == 17) { valtotal = val; }
		else { valtotal = val + (val * nivel); }
		valtotal = Mathf.RoundToInt(valtotal);
		ah.Add(new Puntosgays(valtotal, idgay, true));		
		
		gm.Add(idgay);
		Invoke(tipo[idgay], tiempo[idgay]);

		Transform e = Instantiate(prefab, sitio);
		//e.parent = sitio.parent;
		e.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(sitio.GetComponent<RectTransform>().anchoredPosition.x, sitio.GetComponent<RectTransform>().anchoredPosition.y - disgay * (gm.Count -1), 0);
		rekt.Add(e.GetComponent<RectTransform>());
		 
		e.GetComponent<TextMeshProUGUI>().text = tiponombre[idgay] + " " + valtotal;
	}

	void Headshot()
    {
		for (int i = gm.Count - 1; i >= 0; i--)
		{
			if (9 == gm[i])
			{
				Puntosgays lol = ah[i];
				if (!lol.mod) { continue; }
				lol.mod = false;
				ah.RemoveAt(i);
				ah.Insert(0, lol);

				gm.RemoveAt(i);
				gm.Insert(0, i);

				RectTransform lolgay = rekt[i];
				rekt.RemoveAt(i);
				rekt.Insert(0, lolgay);

				StartCoroutine("Borrar", i);
				return;
			}
		}
	}
	void Ejecución()
	{
		for (int i = gm.Count - 1; i >= 0; i--)
		{
			if (8 == gm[i])
			{
				Puntosgays lol = ah[i];
				if (!lol.mod) { continue; }
				lol.mod = false;
				ah.RemoveAt(i);
				ah.Insert(0, lol);

				gm.RemoveAt(i);
				gm.Insert(0, i);

				RectTransform lolgay = rekt[i];
				rekt.RemoveAt(i);
				rekt.Insert(0, lolgay);

				StartCoroutine("Borrar", i);
				return;
			}
		}
	}
	void Bajas()
	{
		for (int i = gm.Count - 1; i >= 0; i--)
		{
			if (10 == gm[i])
			{
				Puntosgays lol = ah[i];
				if (!lol.mod) { continue; }
				lol.mod = false;
				ah.RemoveAt(i);
				ah.Insert(0, lol);

				gm.RemoveAt(i);
				gm.Insert(0, i);

				RectTransform lolgay = rekt[i];
				rekt.RemoveAt(i);
				rekt.Insert(0, lolgay);

				StartCoroutine("Borrar", i);
				return;
			}
		}
	}
	void Pistola()
	{
		for (int i = gm.Count - 1; i >= 0; i--)
		{
			if (0 == gm[i])
			{
				Puntosgays lol = ah[i];
				if (!lol.mod) { continue; }
				lol.mod = false;
				ah.RemoveAt(i);
				ah.Insert(0, lol);

				gm.RemoveAt(i);
				gm.Insert(0, i);

				RectTransform lolgay = rekt[i];
				rekt.RemoveAt(i);
				rekt.Insert(0, lolgay);

				StartCoroutine("Borrar", i);
				return;
			}
		}
	}
	void Subfusil()
	{
		for (int i = gm.Count - 1; i >= 0; i--)
		{
			if (1 == gm[i])
			{
				Puntosgays lol = ah[i];
				if (!lol.mod) { continue; }
				lol.mod = false;
				ah.RemoveAt(i);
				ah.Insert(0, lol);

				gm.RemoveAt(i);
				gm.Insert(0, i);

				RectTransform lolgay = rekt[i];
				rekt.RemoveAt(i);
				rekt.Insert(0, lolgay);

				StartCoroutine("Borrar", i);
				return;
			}
		}
	}
	void Escopeta()
	{
		for (int i = gm.Count - 1; i >= 0; i--)
		{
			if (2 == gm[i])
			{
				Puntosgays lol = ah[i];
				if (!lol.mod) { continue; }
				lol.mod = false;
				ah.RemoveAt(i);
				ah.Insert(0, lol);

				gm.RemoveAt(i);
				gm.Insert(0, i);

				RectTransform lolgay = rekt[i];
				rekt.RemoveAt(i);
				rekt.Insert(0, lolgay);

				StartCoroutine("Borrar", i);
				return;
			}
		}
	}
	void Lanzagranadas()
	{
		for (int i = gm.Count - 1; i >= 0; i--)
		{
			if (3 == gm[i])
			{
				Puntosgays lol = ah[i];
				if (!lol.mod) { continue; }
				lol.mod = false;
				ah.RemoveAt(i);
				ah.Insert(0, lol);

				gm.RemoveAt(i);
				gm.Insert(0, i);

				RectTransform lolgay = rekt[i];
				rekt.RemoveAt(i);
				rekt.Insert(0, lolgay);

				StartCoroutine("Borrar", i);
				return;
			}
		}
	}
	void Deagle()
	{
		for (int i = gm.Count - 1; i >= 0; i--)
		{
			if (4 == gm[i])
			{
				Puntosgays lol = ah[i];
				if (!lol.mod) { continue; }
				lol.mod = false;
				ah.RemoveAt(i);
				ah.Insert(0, lol);

				gm.RemoveAt(i);
				gm.Insert(0, i);

				RectTransform lolgay = rekt[i];
				rekt.RemoveAt(i);
				rekt.Insert(0, lolgay);

				StartCoroutine("Borrar", i);
				return;
			}
		}
	}
	void Plasma()
	{
		for (int i = gm.Count - 1; i >= 0; i--)
		{
			if (5 == gm[i])
			{
				Puntosgays lol = ah[i];
				if (!lol.mod) { continue; }
				lol.mod = false;
				ah.RemoveAt(i);
				ah.Insert(0, lol);

				gm.RemoveAt(i);
				gm.Insert(0, i);

				RectTransform lolgay = rekt[i];
				rekt.RemoveAt(i);
				rekt.Insert(0, lolgay);

				StartCoroutine("Borrar", i);
				return;
			}
		}
	}
	void Railgun()
	{
		for (int i = gm.Count - 1; i >= 0; i--)
		{
			if (6 == gm[i])
			{
				Puntosgays lol = ah[i];
				if (!lol.mod) { continue; }
				lol.mod = false;
				ah.RemoveAt(i);
				ah.Insert(0, lol);

				gm.RemoveAt(i);
				gm.Insert(0, i);

				RectTransform lolgay = rekt[i];
				rekt.RemoveAt(i);
				rekt.Insert(0, lolgay);

				StartCoroutine("Borrar", i);
				return;
			}
		}
	}
	void Sally()
	{
		for (int i = gm.Count - 1; i >= 0; i--)
		{
			if (7 == gm[i])
			{
				Puntosgays lol = ah[i];
				if (!lol.mod) { continue; }
				lol.mod = false;
				ah.RemoveAt(i);
				ah.Insert(0, lol);

				gm.RemoveAt(i);
				gm.Insert(0, i);

				RectTransform lolgay = rekt[i];
				rekt.RemoveAt(i);
				rekt.Insert(0, lolgay);

				StartCoroutine("Borrar", i);
				return;
			}
		}
	}
	
	void Desfibrilador()
	{
		for (int i = gm.Count - 1; i >= 0; i--)
		{
			if (11 == gm[i])
			{
				Puntosgays lol = ah[i];
				if (!lol.mod) { continue; }
				lol.mod = false;
				ah.RemoveAt(i);
				ah.Insert(0, lol);

				gm.RemoveAt(i);
				gm.Insert(0, i);

				RectTransform lolgay = rekt[i];
				rekt.RemoveAt(i);
				rekt.Insert(0, lolgay);

				StartCoroutine("Borrar", i);
				return;
			}
		}
	}

	void Espada()
	{
		for (int i = gm.Count - 1; i >= 0; i--)
		{
			if (12 == gm[i])
			{
				Puntosgays lol = ah[i];
				if (!lol.mod) { continue; }
				lol.mod = false;
				ah.RemoveAt(i);
				ah.Insert(0, lol);

				gm.RemoveAt(i);
				gm.Insert(0, i);

				RectTransform lolgay = rekt[i];
				rekt.RemoveAt(i);
				rekt.Insert(0, lolgay);

				StartCoroutine("Borrar", i);
				return;
			}
		}
	}

	void Energia()
	{
		for (int i = gm.Count - 1; i >= 0; i--)
		{
			if (13 == gm[i])
			{
				Puntosgays lol = ah[i];
				if (!lol.mod) { continue; }
				lol.mod = false;
				ah.RemoveAt(i);
				ah.Insert(0, lol);

				gm.RemoveAt(i);
				gm.Insert(0, i);

				RectTransform lolgay = rekt[i];
				rekt.RemoveAt(i);
				rekt.Insert(0, lolgay);

				StartCoroutine("Borrar", i);
				return;
			}
		}
	}
	
	void RailgunRayo()
	{
		for (int i = gm.Count - 1; i >= 0; i--)
		{
			if (14 == gm[i])
			{
				Puntosgays lol = ah[i];
				if (!lol.mod) { continue; }
				lol.mod = false;
				ah.RemoveAt(i);
				ah.Insert(0, lol);

				gm.RemoveAt(i);
				gm.Insert(0, i);

				RectTransform lolgay = rekt[i];
				rekt.RemoveAt(i);
				rekt.Insert(0, lolgay);

				StartCoroutine("Borrar", i);
				return;
			}
		}
	}

	void Ballesta()
	{
		for (int i = gm.Count - 1; i >= 0; i--)
		{
			if (15 == gm[i])
			{
				Puntosgays lol = ah[i];
				if (!lol.mod) { continue; }
				lol.mod = false;
				ah.RemoveAt(i);
				ah.Insert(0, lol);

				gm.RemoveAt(i);
				gm.Insert(0, i);

				RectTransform lolgay = rekt[i];
				rekt.RemoveAt(i);
				rekt.Insert(0, lolgay);

				StartCoroutine("Borrar", i);
				return;
			}
		}
	}

	void Ballesta2()
	{
		for (int i = gm.Count - 1; i >= 0; i--)
		{
			if (16 == gm[i])
			{
				Puntosgays lol = ah[i];
				if (!lol.mod) { continue; }
				lol.mod = false;
				ah.RemoveAt(i);
				ah.Insert(0, lol);

				gm.RemoveAt(i);
				gm.Insert(0, i);

				RectTransform lolgay = rekt[i];
				rekt.RemoveAt(i);
				rekt.Insert(0, lolgay);

				StartCoroutine("Borrar", i);
				return;
			}
		}
	}

	void Victoria()
	{
		for (int i = gm.Count - 1; i >= 0; i--)
		{
			if (17 == gm[i])
			{
				Puntosgays lol = ah[i];
				if (!lol.mod) { continue; }
				lol.mod = false;
				ah.RemoveAt(i);
				ah.Insert(0, lol);

				gm.RemoveAt(i);
				gm.Insert(0, i);

				RectTransform lolgay = rekt[i];
				rekt.RemoveAt(i);
				rekt.Insert(0, lolgay);

				StartCoroutine("Borrar", i);
				return;
			}
		}
	}

	void Ronda()
	{
		for (int i = gm.Count - 1; i >= 0; i--)
		{
			if (18 == gm[i])
			{
				Puntosgays lol = ah[i];
				if (!lol.mod) { continue; }
				lol.mod = false;
				ah.RemoveAt(i);
				ah.Insert(0, lol);

				gm.RemoveAt(i);
				gm.Insert(0, i);

				RectTransform lolgay = rekt[i];
				rekt.RemoveAt(i);
				rekt.Insert(0, lolgay);

				StartCoroutine("Borrar", i);
				return;
			}
		}
	}

	void Glorykill()
	{
		for (int i = gm.Count - 1; i >= 0; i--)
		{
			if (19 == gm[i])
			{
				Puntosgays lol = ah[i];
				if (!lol.mod) { continue; }
				lol.mod = false;
				ah.RemoveAt(i);
				ah.Insert(0, lol);

				gm.RemoveAt(i);
				gm.Insert(0, i);

				RectTransform lolgay = rekt[i];
				rekt.RemoveAt(i);
				rekt.Insert(0, lolgay);

				StartCoroutine("Borrar", i);
				return;
			}
		}
	}

	IEnumerator Borrar(int id)
	{
		yield return new WaitForSeconds(1);

		float xgays = 0;
		RectTransform gays = null;
		float container = 0;
		RectTransform oh = GetComponent<RectTransform>();
		for (int i = 0; i <gm.Count; i++)
		{
			if (id == gm[i])
			{
				Puntosgays lol = ah[i];
				if (lol.mod) { continue; }

				//puntos = lol.Pts;
				gm.RemoveAt(i);
				ah.RemoveAt(i);
				//Destroy(rekt[i].gameObject);
				gays = rekt[i];
				rekt.RemoveAt(i);
				Controlador.puntos += lol.Pts;
				Controlador.puntostotales += lol.Pts;
			    break;
			}
		}
		xgays = gays.anchoredPosition.x;

		float dislol = Mathf.Abs(106 - gays.anchoredPosition.y);
		TextMeshProUGUI p = gays.gameObject.GetComponent<TextMeshProUGUI>();
		while (container < 1)
        {
			p.color = new Color(p.color.r, p.color.g, p.color.b, p.color.a - (Time.deltaTime));
			gays.anchoredPosition = Vector2.MoveTowards(gays.anchoredPosition, new Vector2(gays.anchoredPosition.x, 106), dislol * Time.deltaTime);
			gays.anchoredPosition = new Vector2(xgays, gays.anchoredPosition.y);
			container += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		Destroy(gays.gameObject);
	}

	void Update () {

		for (int i = 0; i < rekt.Count; i++)
        {
			rekt[i].anchoredPosition = Vector2.Lerp(rekt[i].anchoredPosition, new Vector2(rekt[i].anchoredPosition.x, sitio.GetComponent<RectTransform>().anchoredPosition.y - disgay * i), 0.2f * (Time.deltaTime / 0.013f));
        }




		ª[1].color = Vector4.MoveTowards(ª[1].color, obj, vel * (Time.deltaTime / 0.013f));
		if (ª[1].color == obj)
        {
			if (obj == a1)
            {
				obj = a2;
            }
            else
            {
				obj = a1;
            }
        }

		pts = Mathf.Lerp(pts, Controlador.puntos, 0.05f * (Time.deltaTime / 0.013f));
		textogay.text = pts.ToString("F0");

		if (!reset) { Restar(); }
		

		if (ptsm > rango[nivel +1] && !reset) {

			if (nivel < 5)
			{

				puntos = puntos - rango[nivel +1];
				nivel++;
				//aymimadreelbichoSUUUUUUUUUUU();
				reset = true;
				StartCoroutine("Reset");
			}
			else
			{
				puntos = rango[5];
				return;
			}

			
		}
       
		else if (!reset)
        {
				lerp();		
			
        }
	}


	void lerp()
    {
		if (contador > tiempoaguante) { return; }

		ptsm = Mathf.Lerp(ptsm, puntos, 0.05f * (Time.deltaTime / 0.013f));
		ª[1].fillAmount = ptsm / rango[nivel +1];

	}

	void aymimadreelbichoSUUUUUUUUUUU()
    {

		ª[0].gameObject.SetActive(true);
		ª[1].gameObject.SetActive(true);

		switch (nivel)
		{
			case 0:
				ª[0].sprite = a[0];
				ª[1].sprite = a[1];
				a1 = p[0];
				a2 = p[1];
				ª[0].gameObject.SetActive(false);
				ª[1].gameObject.SetActive(false);
				break;
			case 1:
				ª[0].sprite = a[0];
				ª[1].sprite = a[1];
				a1 = p[2];
				a2 = p[3];
				break;
			case 2:
				ª[0].sprite = a[2];
				ª[1].sprite = a[3];
				a1 = p[4];
				a2 = p[5];
				break;
			case 3:
				ª[0].sprite = a[4];
				ª[1].sprite = a[5];
				a1 = p[6];
				a2 = p[7];
				break;
			case 4:
				ª[0].sprite = a[6];
				ª[1].sprite = a[7];
				a1 = p[8];
				a2 = p[9];
				break;
			case 5:
				ª[0].sprite = a[8];
				ª[1].sprite = a[9];
				a1 = p[10];
				a2 = p[11];
				break;

		}
		
		obj = a2;
		ª[1].color = a1;
	}
	
	void Restar()
    {
		
		if (puntosprev == puntos) { contador += Time.deltaTime; }
        else
        {
			contador = 0;
			puntosprev = puntos;
		}

		if (contador > tiempoaguante)
        {
			
			puntos = Mathf.MoveTowards(puntos, -5, rango[nivel +1] * 0.5f * Time.deltaTime);
			puntosprev = puntos;
			

			if (puntos < 0) { puntos = 0; }
			
			if (puntos <= 0 && nivel > 0) {

				nivel--;
				puntos = rango[nivel +1] -1;
				puntosprev = puntos;
				aymimadreelbichoSUUUUUUUUUUU();

			}

			ª[1].fillAmount = puntos / rango[nivel + 1];
			ptsm = puntos;
		}

    }

     IEnumerator Reset()
	{
		yield return new WaitForSeconds(0.3f);

		while (reset)
		{
			ptsm = Mathf.Lerp(ptsm, 0, 0.3f * (Time.deltaTime / 0.013f));
			
			ª[1].fillAmount = ptsm / rango[nivel + 1];

			if (ptsm <= 0.8)
            {
				contador = 0;
				reset = false;
				aymimadreelbichoSUUUUUUUUUUU();
				StopCoroutine("Reset");
			}
			yield return new WaitForEndOfFrame();
		}
	}

}