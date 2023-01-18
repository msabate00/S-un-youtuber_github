using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class gestorpc : MonoBehaviour, IPointerEnterHandler
{
	public float dist = -10;
	public int num;
	public List<int> lol = new List<int>();
	public List<GameObject> borrameesta = new List<GameObject>();
	public RectTransform ah;
	public Transform opciones;
	private float acum = 0;
	public Transform sitio;
	private Controlador con;
	public Color basegay;
	public Color destino;
	public Color deselec;
	public Color selec;
	public TextMeshProUGUI joder;
	public TextMeshProUGUI joder2;
	public GameObject Outio;
	[HideInInspector]
	public TextMeshProUGUI textoriginal;
	public TextMeshProUGUI calidad;
	[HideInInspector]
	public int nivel;
	private float alfagay;
	private float destinogay = 1;
	public Image[] paneles;
	public int id = 0;
	private int numerosgays = 0;

	void Update()
    {
		alfagay = Mathf.Lerp(alfagay, destinogay, 0.4f);
		basegay = Color.Lerp(basegay, destino, 0.2f);
		joder.color = basegay;
		joder.color = new Color(basegay.r, basegay.g, basegay.b, alfagay);
		if (paneles[0] != null)
        {
			paneles[0].color = new Color(paneles[0].color.r, paneles[0].color.g, paneles[0].color.b, alfagay);
			paneles[1].color = new Color(paneles[1].color.r, paneles[1].color.g, paneles[1].color.b, alfagay);
			joder2.color = new Color(basegay.r, basegay.g, basegay.b, alfagay);
		}
	}

	void OnEnable()
    {
		con = GameObject.Find("Controladora").GetComponent<Controlador>();
		for (int i = 0; i < 8; i++)
        {
			if (i == num)
            {
				if (con.pcselec[i] < 0)
				{
					joder.text = menosuno(num);
					if(calidad != null)
                    {
						calidad.text = "";
						
						int gay = 22 + num;

						for (int a = 0; a > con.pcafect[gay]; a--)
						{
							calidad.text = calidad.text + "-";
						}
						calidad.color = Color.red;
					}
					
				}
                else
                {
					joder.text = con.pctexto[con.pcselec[i]];
					if (calidad != null)
					{
						if (con.pcafect[con.pcselec[num]] >= 0)
						{
							calidad.text = "";
							calidad.text = calidad.text + "+";
							calidad.color = Color.green;
							for (int a = 0; a < con.pcafect[con.pcselec[num]]; a++)
							{
								calidad.text = calidad.text + "+";
								calidad.color = Color.green;
							}
						}
						else
						{
							Debug.Log("JODER");
							int gay = 22 + nivel;
							calidad.text = "";
							calidad.color = Color.red;
							for (int a = 0; a > con.pcafect[con.pcselec[num]]; a--)
							{
								calidad.text = calidad.text + "-";
							}
						}
					}
				}
				
				break;
			}
        }
			

	}
	
	public void OnPointerEnter(PointerEventData eventData)
	{
		
		destino = selec;
		
	}
	
	string menosuno(int n)
    {
		switch (n)
        {
			case 0:
				return "Ordenador mierda";

			case 1:
				return "Ratón genérico";

			case 2:
				return "--------------------";

			case 3:
				return "--------------------";

			case 4:
				return "Auriculares genéricos";

			case 5:
				return "--------------------";

			case 6:
				Debug.Log("COJONES");
				return "Movie Maker";

			case 7:
				Debug.Log("COJONES");
				return "Atube Catcher";

			default:
				return "Ah no sé joder";
		}
    }

	public void actualizar()
    {
		alfagay = 0.15f;
		destinogay = 1;
		con = GameObject.Find("Controladora").GetComponent<Controlador>();
		if (num < 0)
        {
			joder2.text = "-" + menosuno(nivel);
			transform.GetComponent<TextMeshProUGUI>().text = "";
		}
        else
        {
			joder2.text = "-" + con.pctexto[num];
			transform.GetComponent<TextMeshProUGUI>().text = "";
		}
		
		

	}

	public void DESELECCIONAR()
    {
		destino = deselec;
	}
	public void Out()
    {
		GameObject[] gays = GameObject.FindGameObjectsWithTag("TU MADRE ES GAY");
		foreach (GameObject pene in gays)
		{
			pene.GetComponent<gestorpc>().destinogay = 0;

		}

		if (Outio == null && GameObject.Find("Outjodermierda"))
		{
			Outio = GameObject.Find("Outjodermierda");
		}
		


	//	Invoke("destroyer", 0.3f);

		GameObject[] gays2 = GameObject.FindGameObjectsWithTag("TU MADRE ES GAY");
		foreach (GameObject pene in gays2)
		{
			
				//Destroy(pene);
				pene.SendMessage("destprogr", 0.3f);
			


		}
		Outio.SetActive(false);
	}
	
	public void destprogr()
    {
		Destroy(gameObject);
    }
	
	public void OHSINENA()
    {
		calidad.text = "";
		con.pcselec[nivel] = num;
		if (num < 0)
		{
			textoriginal.text = menosuno(nivel);
			calidad.text = "";
			calidad.color = Color.red;

			int gay = 22 + nivel;

			for (int a = 0; a > con.pcafect[gay]; a--)
			{
				calidad.text = calidad.text + "-";
			}
		}
        else
        {
			textoriginal.text = con.pctexto[num];
			
			if (con.pcafect[con.pcselec[nivel]] >= 0){
				calidad.text = calidad.text + "+";
				calidad.color = Color.green;
				for (int a = 0; a < con.pcafect[con.pcselec[nivel]]; a++)
				{
					calidad.text = calidad.text + "+";
					calidad.color = Color.green;
				}
			}
            else
            {
				Debug.Log("JODER");
				int gay = 22 + nivel;
				calidad.text = "";
				calidad.color = Color.red;
				for (int a = 0; a > con.pcafect[con.pcselec[nivel]]; a--)
				{
					calidad.text = calidad.text + "-";
				}
			}
			
		}

		con.valoracion = 0;
		for (int i = 1; i < 8; i++)
        {
			int lol = 22;
			if (con.pcselec[i] < 0)
            {
				lol = 22;
				lol = lol + i;
            }
            else
            {
				lol = con.pcselec[i];
            }
			con.valoracion = con.valoracion + con.pcafect[lol];
		}
		
		Out();
	}
	
	public void COJONAZOS()
	{
		nivel = num;
		GameObject[] gays = GameObject.FindGameObjectsWithTag("TU MADRE ES GAY");
		foreach (GameObject pene in gays)
		{
			
				Destroy(pene);
			
			
		}
		

		numerosgays = 0;
		lol.Clear();

		if (num == 0)
		{
			lol.Add(-1);
			lol.Add(0);
			lol.Add(1);
			lol.Add(2);
			
			
		}
		if (num == 1)
		{
			lol.Add(-1);
			lol.Add(3);
			lol.Add(4);
			lol.Add(5);


		}
		if (num == 2)
		{
			lol.Add(-1);
			lol.Add(6);
			lol.Add(7);
			lol.Add(8);
		}
		if (num == 3)
		{
			lol.Add(-1);
			lol.Add(9);
			lol.Add(10);
			lol.Add(11);
		}
		if (num == 4)
		{
			lol.Add(-1);
			lol.Add(12);
			lol.Add(13);
			lol.Add(14);
		}
		if (num == 5)
		{
			lol.Add(-1);
			lol.Add(15);
			lol.Add(16);
			lol.Add(17);
		}
		if (num == 6)
		{
			lol.Add(-1);
			lol.Add(18);
			lol.Add(19);
		}
		if (num == 7)
		{
			lol.Add(-1);
			lol.Add(20);
			lol.Add(21);
		}

		borrameesta.Clear();
		for (int i = 0; i < lol.Count; i++)
		{
			if (lol[i] > 0 && !con.pcdisp[lol[i]])
			{
				//borrameesta.Add(lol[i]);
				lol.Remove(lol[i]);
				i--;
			}
		}
		/*
		for (int i = 0; i < borrameesta.Count; i++)
		{
			lol.Remove(borrameesta[i]);
		}
		*/
			acum = 0;
		id++;
		for (int i = 0; i < lol.Count; i++)
        {
			acum = acum + dist;
			Transform lols = Instantiate(opciones);
			lols.tag = "TU MADRE ES GAY";
			lols.GetComponent<gestorpc>().num = lol[i];
			lols.GetComponent<gestorpc>().nivel = nivel;
			lols.GetComponent<gestorpc>().textoriginal = joder;
			lols.GetComponent<gestorpc>().id = id;
			lols.GetComponent<gestorpc>().calidad = calidad;
			borrameesta.Add(lols.gameObject);
			numerosgays++;
			lols.SendMessage("actualizar");
			
			lols.parent = transform;
			lols.GetComponent<RectTransform>().anchoredPosition3D = ah.anchoredPosition3D;
			lols.GetComponent<RectTransform>().localScale = ah.localScale;
			lols.GetComponent<RectTransform>().anchoredPosition = new Vector2(lols.GetComponent<RectTransform>().anchoredPosition.x - 4, lols.GetComponent<RectTransform>().anchoredPosition.y + acum); // x= -15.9
			lols.parent = sitio;

		}
		
		Outio.SetActive(true);
	}
	}
