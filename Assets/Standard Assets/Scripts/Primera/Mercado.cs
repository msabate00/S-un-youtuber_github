using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mercado : MonoBehaviour {

	public TextMeshProUGUI dinerototal;
	public int boton;
	private Controlador con;
	public TextMeshProUGUI dinero;
	public TextMeshProUGUI objetos;
	private TextMeshProUGUI joder;

	void OnEnable()
    {
		con = GameObject.Find("Controladora").GetComponent<Controlador>();
		dinerototal.text = "Cuenta bancária: " + Controlador.Dinero.ToString("F2") + "€";
		dinero.text = con.precios[boton].ToString("F2") + "€";
		objetos.text = con.objetos[boton].ToString();
		transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Añadir";
		joder = transform.parent.GetChild(5).GetComponent<TextMeshProUGUI>();
	}
	
	public void COJONAZOSENTUBOCA()
    {
		/*
		if (Controlador.Dinero >= con.precios[boton])
		{
			con.objetos[boton]++;
			Controlador.Dinero = Controlador.Dinero - con.precios[boton];

			dinerototal.text = "Cuenta bancária: " + Controlador.Dinero.ToString("F2") + "€";
			dinero.text = con.precios[boton].ToString("F2") + "€";
			objetos.text = con.objetos[boton].ToString();
		}
		*/
	}
	
	public void ACTUALIZARMIERDA()
    {
		
		if (telelista.objprov[boton] == 0)
        {
			joder.text = "";
		}
        else
        {
			joder.text = telelista.objprov[boton].ToString();
		}
		
		dinerototal.text = "Cuenta bancária: " + Controlador.Dinero.ToString("F2") + "€";
		dinero.text = con.precios[boton].ToString("F2") + "€";
		objetos.text = con.objetos[boton].ToString();
	}

	void OnMouseDown () {
		COJONAZOSENTUBOCA();
	}


	/*
	0: Redbull
	1: Biara
	2: Vino
	3: Ganchitos
	4: Pipas
	5: Ruffles
	6: Chocolate
	7: Cacahuetes
	8: Aquarius
	9: Agua
	10: Coca cola
	11: Pizza
	12: Ramen
	13: Carne
	14: Arroz chino
	15: Hot dogs
	16: Kebab
	17: Ensalada


	 */
}
