using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class gestionadorgay : MonoBehaviour {

	public TextMeshProUGUI[] cosa;
	private Controlador con;
	public int numero;
	public Image lel;
	public GameObject descuento;
	public Image textura;

	public void lol () {
		con = GameObject.Find("Controladora").GetComponent<Controlador>();
		cosa[0].text = con.pctexto[numero];
		cosa[1].text = con.pcfinal[numero].ToString("F2") + "€";
		GameObject.Find("Dinerototalputo").GetComponent<TextMeshProUGUI>().text = Controlador.Dinero.ToString("F2") + "€";
		if (con.pcdisp[numero])
        {
			cosa[2].text = "Adquirido";
			lel.color = Color.red;
			
		}
		if (con.pcdesc[numero] > 0)
		{
			descuento.SetActive(true);
			cosa[3].text = "-" + con.pcdesc[numero].ToString() + "%";
        }
        else
        {
			descuento.SetActive(false);
		}
	}
	
	// Update is called once per frame
	public void COMPRAR () {
		if (!con.pcdisp[numero] && Controlador.Dinero > con.pcfinal[numero])
		{
			Controlador.Dinero = Controlador.Dinero - con.pcfinal[numero];
			cosa[2].text = "Adquirido";
			lel.color = Color.red;
			con.pcdisp[numero] = true;
			GameObject.Find("Dinerototalputo").GetComponent<TextMeshProUGUI>().text = "Cuenta bancária: " + Controlador.Dinero.ToString("F2") + "€";
		}
		}
}
