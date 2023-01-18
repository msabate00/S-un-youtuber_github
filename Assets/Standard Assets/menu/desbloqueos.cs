using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class desbloqueos : MonoBehaviour {

	public bool desblmenu = true;
	public GameObject norm;
	public TextMeshProUGUI[] txt;
	public Color yes;
	public Color no;
	
	void Awake()
    {
		if (desblmenu)
        {
			gay();
		}
        else
        {
			homersexual();
		}
		
    }
	
	void homersexual()
    {
		normalizador nor = norm.GetComponent<normalizador>();

		if (Controlador.puntostotales < nor.nivelesextra[0]) { txt[0].gameObject.GetComponent<Button>().interactable = false; txt[0].transform.GetChild(0).gameObject.SetActive(true); }
		if (Controlador.puntostotales < nor.nivelesextra[1]) { txt[1].gameObject.GetComponent<Button>().interactable = false; txt[1].transform.GetChild(0).gameObject.SetActive(true); }

	}
	
	void gay () {

		normalizador nor = norm.GetComponent<normalizador>();

		TextMeshProUGUI penis = txt[0];
		penis.color = shiet(nor.listagay[3].Desbloqueo, 0);

		penis = txt[1];
		penis.color = shiet(nor.listagay[5].Desbloqueo, 1);

		penis = txt[2];
		penis.color = shiet(nor.listagay[6].Desbloqueo, 2);

		penis = txt[3];
		penis.color = shiet(nor.listagay[7].Desbloqueo, 3);

		penis = txt[4];
		penis.color = shiet(nor.nivelesextra[0], 4);

		penis = txt[5];
		penis.color = shiet(nor.nivelesextra[1], 5);

		penis = txt[6];
		penis.color = shiet(nor.listagay[8].Desbloqueo, 6);

	}
		
	Color shiet(float pts, int index)
    {	
		
		if (Controlador.puntostotales >= pts)
        {
			txt[index].gameObject.GetComponentInChildren<Image>().enabled = false;
			return yes;
        }
        else
        {
			txt[index].gameObject.GetComponentInChildren<Image>().enabled = true;
			string pts2 = ponerpuntos(pts);
			string puntostotales = ponerpuntos(Controlador.puntostotales);
			txt[index].text += ": " + puntostotales + " / " + pts2 + " pts.";
			return no;
		}
				
    }

	string ponerpuntos(float pts)
    {
		string sex = "";
		char[] charsgays = pts.ToString("F0").ToCharArray();
		int cont = 0;
		for (int follame = charsgays.Length - 1; follame >= 0; follame--)
		{
			if (cont == 3) { sex = "." + sex; cont = 0; }
			sex = charsgays[follame] + sex;
			cont++;
		}
		return sex;
	}
}
