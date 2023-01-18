using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class telelista : MonoBehaviour
{


	public List<claselista> listagay = new List<claselista>();
	
	private telelista tele;
	public int boton = 0;
	public Transform spaun;
	public Transform slot;
	public float espacio = -70;
	private float acum = 0;
	public TextMeshProUGUI[] texto;
	public int idselec;
	public GameObject marco;
	private float dinerogay;
	private List<GameObject> sluts = new List<GameObject>();
	public string mierda2 = "penes";
	public Slider slid;
	public float dist = 0;

	
	public int id;

	public static int[] objprov = new int[18];

	public int cant;
	[HideInInspector]
	public bool si;
	[HideInInspector]
	public int numlista;

	[HideInInspector]
	public telelista telegays;
	public Alertacompra alerta;

	public bool tusmuertos;

	void OnEnable()
    {
		if (texto.Length > 0){
			texto[1].text = "Días restantes: " + Controlador.restantescompra.ToString();
		}
		if (tusmuertos) { actualizar(); }
		
	}

	void Update()
    {
		if (tusmuertos) { actualizar(); }

		if (slid != null)
        {
			if (listagay.Count < 12)
            {
				dist = 0.0001f;
			}
            else
            {
				float pene = listagay.Count;
				pene = pene * 14.083f;
				pene = pene - 160.7f;
				dist = pene;
            }

			if (Input.GetKey(KeyCode.UpArrow))
			{

				Vector2 lal = spaun.GetComponent<RectTransform>().anchoredPosition;
				lal.y -= 110 * Time.deltaTime;
				lal.y = Mathf.Clamp(lal.y, 0, dist);
				if (float.IsNaN(lal.y))
				{
					lal.y = 0;
				}
				if (dist == 0) { lal.y = 0; }
				spaun.GetComponent<RectTransform>().anchoredPosition = lal;

				
				slid.value = lal.y / dist;
				
			}
			else if (Input.GetKey(KeyCode.DownArrow))
			{
				Vector2 lal = spaun.GetComponent<RectTransform>().anchoredPosition;
				lal.y += 110 * Time.deltaTime;
				lal.y = Mathf.Clamp(lal.y, 0, dist);
				if (float.IsNaN(lal.y))
				{
					lal.y = 0;
				}
				if (dist == 0) { lal.y = 0; }
				spaun.GetComponent<RectTransform>().anchoredPosition = lal;

				
				slid.value = lal.y / dist;
			}
			
			else if (Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")) > 0)
			{
				Vector2 lal = spaun.GetComponent<RectTransform>().anchoredPosition;
				lal.y -= Input.GetAxis("Mouse ScrollWheel") * 70;
				lal.y = Mathf.Clamp(lal.y, 0, dist);
				if (float.IsNaN(lal.y))
				{
					lal.y = 0;
				}
				if (dist == 0) { lal.y = 0; }
					spaun.GetComponent<RectTransform>().anchoredPosition = lal;

				
				slid.value = lal.y / dist;
			}

			float lol = dist * slid.value;
			spaun.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,lol);

		}
	}
	
	public void COJONAZOS()
	{
		tele = transform.parent.parent.GetComponent<telelista>();

		if (tele.listagay.Count > 0)
        {
			for (int i = 0; i < tele.listagay.Count; i++)
			{
				claselista lol = tele.listagay[i];

				if (lol.id == boton)
				{

					tele.listagay.RemoveAt(i);
					tele.listagay.Insert(i, new claselista(lol.id, lol.cant + 1, lol.si));
					tele.spawner();
					return;
				}

			}
		}

		
		Debug.Log("PENE");
		tele.listagay.Add(new claselista(boton, 1, true));
		tele.spawner();
	}

	public void spawner()
    {
		dinerogay = 0;
		GameObject[] lol = GameObject.FindGameObjectsWithTag("TU MADRE ES GAY");
		acum = 0;
		Controlador con = GameObject.Find("Controladora").GetComponent<Controlador>();

		idselec = 0;
		foreach (GameObject pene in lol)
        {
			Destroy(pene.gameObject);
        }

		for (int i = 0; i < objprov.Length; i++)
        {
			objprov[i] = 0;
		}
		

		while (sluts.Count > 0)
        {
			Destroy(sluts[0]);
			sluts.RemoveAt(0);
		}

		for (int i = 0; i < listagay.Count; i++)
        {			
			Transform gay = Instantiate(slot, slot.position, slot.rotation, spaun);
			gay.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-177.7f, acum, 3.6f);
			gay.tag = "TU MADRE ES GAY";
			acum = acum + espacio;
			
			claselista lal = listagay[i];
			gay.GetComponent<telelista>().id = lal.id;
			gay.GetComponent<telelista>().cant = lal.cant;
			gay.GetComponent<telelista>().si = lal.si;
			gay.GetComponent<telelista>().numlista = i;
			gay.GetComponent<telelista>().telegays = transform.GetComponent<telelista>();
			gay.GetComponent<telelista>().telegays.spaun = spaun;
			gay.GetComponent<telelista>().telegays.mierda2 = "JODER";
			gay.GetComponent<telelista>().tusmuertos = true;
			gay.GetComponent<telelista>().telegays.actualizar();
			sluts.Add(gay.gameObject);
			dinerogay = dinerogay + con.precios[lal.id] * lal.cant;

			objprov[lal.id] = lal.cant;

			if (i == 0) { gay.GetChild(3).gameObject.SetActive(true); }
		}
		texto[0].text = dinerogay.ToString("F2") + "€";
		texto[1].text = "Días restantes: " + Controlador.restantescompra.ToString();
		texto[2].text = Controlador.Dinero.ToString("F2") + "€";

		GameObject[] pene2 = GameObject.FindGameObjectsWithTag("Fire");

		foreach (GameObject ah in pene2)
        {
			ah.transform.GetChild(3).SendMessage("ACTUALIZARMIERDA");
        }

	}

	public void autogay()
    {
		Debug.Log("ERES TONTO?");
		Controlador con = GameObject.Find("Controladora").GetComponent<Controlador>();
		float dinero = 0;

		if (Controlador.restantescompra < 1)
        {
			if (con.listauto.Count > 0 && Controlador.comprauto) {


				for (int i = 0; i < con.listauto.Count; i++)
				{
					claselista lal = con.listauto[i];
					dinero = dinero + con.precios[lal.id] * lal.cant;

				}

				if (Controlador.Dinero >= dinero)
				{
					for (int i = 0; i < con.listauto.Count; i++)
					{
						claselista lal = con.listauto[i];
						con.objetos[lal.id] = con.objetos[lal.id] + lal.cant;



					}
					Controlador.Dinero = Controlador.Dinero - dinero;
				}
			
				else
				{
					alerta.enabled = true;
				}
			}



			Controlador.restantescompra = Controlador.restantescompra + 7;
		}
		
	}
	
	public void compra()
    {
		Controlador con = GameObject.Find("Controladora").GetComponent<Controlador>();
		float dinero = 0;

		if (listagay.Count > 0)
		{

			for (int i = 0; i < listagay.Count; i++)
			{
				claselista lal = listagay[i];
				dinero = dinero + con.precios[lal.id] * lal.cant;

			}

			if (Controlador.Dinero >= dinero)
			{

				for (int i = 0; i < listagay.Count; i++)
				{
					claselista lal = listagay[i];
					con.objetos[lal.id] = con.objetos[lal.id] + lal.cant;
					
				}
				Controlador.Dinero = Controlador.Dinero - dinero;

				listagay.Clear();
				spawner();

			}
		
		}
	}

	public void actualizar()
    {

		Controlador con = GameObject.Find("Controladora").GetComponent<Controlador>();
		float polladas = con.precios[id] * cant;

		texto[0].text = tit(id) + " x" + cant.ToString();
		texto[1].text = polladas.ToString("F2") + "€";

		
	}

	string tit(int id)
    {
		switch (id)
        {
			case 0:
				return "Red Bull";
			case 1:
				return "Cerveza";
			case 2:
				return "Vino";
			case 3:
				return "Ganchitos";
			case 4:
				return "Pipas";
			case 5:
				return "Ruffles";
			case 6:
				return "Chocolate";
			case 7:
				return "Cacahuetes";
			case 8:
				return "Aquarius";
			case 9:
				return "Agua";
			case 10:
				return "Coca cola";
			case 11:
				return "Pizza";
			case 12:
				return "Ramen";
			case 13:
				return "Carne";
			case 14:
				return "Arroz";
			case 15:
				return "Hot Dogs";
			case 16:
				return "Kebab";
			case 17:
				return "Ensalada";
		}


		return "BUG";
    }

	public void NUMID()
    {
		telegays.idselec = numlista;
		GameObject[] pene = GameObject.FindGameObjectsWithTag("taladro");
		foreach (GameObject lol in pene)
        {
			lol.SetActive(false);
        }
		marco.SetActive(true);

	}

	public void borrar()
    {
		listagay.RemoveAt(idselec);
		spawner();
	}
	
	public void borrarto()
    {
		listagay.Clear();
		spawner();
	}

	public void asignar()
	{
		Debug.Log("ERES TONTO?");
		Controlador con = GameObject.Find("Controladora").GetComponent<Controlador>();

		con.listauto.Clear();
		for (int i = 0; i < listagay.Count; i++)
        {
			con.listauto.Add(listagay[i]);
        }
	}

	public void verlista()
    {
		Debug.Log("ERES TONTO?");
		Controlador con = GameObject.Find("Controladora").GetComponent<Controlador>();
		listagay.Clear();
		for (int i = 0; i < con.listauto.Count; i++)
		{
			listagay.Add(con.listauto[i]);
		}
		spawner();

	}

	public void autobool()
    {
		Controlador.comprauto = !Controlador.comprauto;
		if (Controlador.comprauto)
        {
			transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
			transform.GetChild(0).gameObject.SetActive(false);
		}

	}
}
