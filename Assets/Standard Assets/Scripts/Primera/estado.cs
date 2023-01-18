using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class estado : MonoBehaviour {

	public TextMeshProUGUI[] texto;
	private string ah;

	float lol (float puto) {
		
		if (puto >= 1000000)
		{
			puto = puto / 1000000;
			ah = "M";
			return puto;
		}
		ah = "";
		return puto;
	}
	
	// Update is called once per frame
	void OnEnable () {
		float sus = Controlador.Seguidores;
		sus = sus / 60;
		sus = sus * 100;

		int pene = 30;
		pene = pene - Controlador.diasinpaga;
		
		texto[0].text = Controlador.nuser;
		texto[1].text = lol(Controlador.Suscriptores).ToString() + ah;
		texto[2].text = lol(Controlador.Visualizacionestotales).ToString() + ah;
		texto[3].text = sus.ToString("F0") + "%";
		texto[4].text = Controlador.Moral.ToString("F0") + "%";
		texto[5].text = Controlador.Dinero.ToString("F2") + "€";
		if (Controlador.trabajando)
		{
			texto[6].text = pene.ToString();
		}
		else
		{
			texto[6].text = "N/D";
		}
		
	}
}
