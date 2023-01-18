using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pccomponentes : MonoBehaviour {

	public Slider gay;
	public Transform slot;
	public Transform spawner;
	public Transform estrellagay;
	public Sprite[] estrella;
	public float lateral;
	public float vertical;
	public float salto;
	private float acumlat;
	private float acumver;
	private int contadorlat;
	public int[] contadorsaltos;
	private int spawneados;
	private int nivel = 0;
	private Controlador con;
	private float acumestrella;
	private int contadorestrella;
	private int pene;
	public Sprite[] texturasgays;
	public TextMeshProUGUI dinerotot;

	void OnEnable () {
		
		Spawn();
	}


	void Spawn()
    {
		con = GameObject.Find("Controladora").GetComponent<Controlador>();
		acumlat = 0;
		acumver = 0;
		nivel = 0;
		spawneados = 0;
		contadorlat = 0;
		pene = 0;

		if (con.pcfinal[0] == 0)
		{
			for (int i = 0; i < 22; i++)
			{				
					con.pcfinal[i] = con.pcprecios[i];			
			}
		}

		GameObject[] putos = GameObject.FindGameObjectsWithTag("TU MADRE ES GAY");
		foreach (GameObject pene in putos)
        {
			Destroy(pene);
        }

		foreach (int lol in contadorsaltos)
        {
			pene = pene + lol;
        }
		for (int i = 0; i < pene; i++)
		{
			acumestrella = 0;
			contadorestrella = 0;

			if (spawneados == contadorsaltos[nivel])
            {
				contadorlat = 0;
				acumlat = 0;
				acumver = acumver + salto;
				nivel++;
				spawneados = 0;
			}
			if (contadorlat == 3)
            {
				acumver = acumver + vertical;
				contadorlat = 0;
				acumlat = 0;
			}
			Transform lol = Instantiate(slot, spawner.position, spawner.rotation, spawner);
			lol.GetComponent<gestionadorgay>().numero = i;
			lol.GetComponent<gestionadorgay>().textura.sprite = texturasgays[i];
			lol.tag = "TU MADRE ES GAY";
			lol.localPosition = lol.localPosition + new Vector3(acumlat, acumver, lol.localPosition.z);
			acumlat = acumlat + lateral;
			contadorlat++;
			spawneados++;

			
			lol.SendMessage("lol");
			Transform estrellas = lol.GetChild(7);
			
			
			for (int a = 0; a < 5; a++)
			{
				
				Transform gay = Instantiate(estrellagay, estrellas.position, estrellas.rotation, lol);
				gay.GetComponent<RectTransform>().anchoredPosition = new Vector2(-5.089f + acumestrella, 8.077f);
				acumestrella = acumestrella + 0.084f;

				if (contadorestrella >= con.pccalidad[i])
				{
					gay.GetComponent<Image>().sprite = estrella[1];
				}
				contadorestrella++;



			}
			}

	}
	
	void Update()
    {
		dinerotot.text = "Cuenta bancária: " + Controlador.Dinero.ToString("F2") + "€";
		if (Mathf.Abs(Input.GetAxis("Vertical")) > 0){
			
			GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition - new Vector2(-8, 20 * Input.GetAxis("Vertical"));
			gay.value = GetComponent<RectTransform>().anchoredPosition.y / 440;
		}
		if (Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")) > 0)
        {
			GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition - new Vector2(-8, 180 * Input.GetAxis("Mouse ScrollWheel"));
			gay.value = GetComponent<RectTransform>().anchoredPosition.y / 440;
		}


			float pene = 440 * gay.value;
		GetComponent<RectTransform>().anchoredPosition = new Vector2(-8, pene);
    }
	
}

//90.133 separación labbelsgays
//440