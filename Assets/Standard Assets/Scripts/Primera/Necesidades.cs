using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Necesidades : MonoBehaviour {

	public TextMeshProUGUI[] cosa = new TextMeshProUGUI[9];
	public TextMeshProUGUI[] cosa1 = new TextMeshProUGUI[9];
	public TextMeshProUGUI[] cosa2 = new TextMeshProUGUI[9];
	public TextMeshProUGUI[] cosa3 = new TextMeshProUGUI[9];
	public TextMeshProUGUI dias;
	private Controlador con;
	private int[] lel = new int[9];
	public telelista tele;
	private int[] cosasprov = new int[18];

	void OnEnable()
	{
		lol();
	}

	void lol() {

		if (dias != null)
        {
			dias.text = "Días restantes: " + Controlador.restantescompra.ToString();
		}
		
		for (int i = 0; i < 18; i++)
		{
			cosasprov[i] = 0;
		}

		if (tele.listagay.Count > 0 && tele != null) {
		for (int i = 0; i < tele.listagay.Count; i++)
		{
			claselista lol = tele.listagay[i];
			cosasprov[lol.id] = cosasprov[lol.id] + lol.cant;
		}
	    }

		con = GameObject.Find("Controladora").GetComponent<Controlador>();
		lel[0] = con.objetos[0] + con.objetos[10] + cosasprov[0] + cosasprov[10];
		lel[1] = con.objetos[1] + con.objetos[2] + cosasprov[1] + cosasprov[2];
		lel[2] = con.objetos[8] + con.objetos[9] + cosasprov[8] + cosasprov[9];
		lel[3] = con.objetos[3] + con.objetos[5] + cosasprov[3] + cosasprov[5];
		lel[4] = con.objetos[4] + con.objetos[7] + cosasprov[4] + cosasprov[7];
		lel[5] = con.objetos[6] + cosasprov[6];
		lel[6] = con.objetos[11] + con.objetos[15] + con.objetos[16] + cosasprov[11] + cosasprov[15] + cosasprov[16];
		lel[7] = con.objetos[14] + con.objetos[17] + cosasprov[14] + cosasprov[17];
		lel[8] = con.objetos[12] + con.objetos[13] + cosasprov[12] + cosasprov[13];

		
		cosa[0].text = "Bebidas enérgicas:";
		cosa[1].text = "Bebidas alcohólicas:";
		cosa[2].text = "Bebidas neutrales:";
		cosa[3].text = "Snacks:";
		cosa[4].text = "Snacks saludables:";
		cosa[5].text = "Chocolate:";
		cosa[6].text = "Comida basura:";
		cosa[7].text = "Comida saludable:";
		cosa[8].text = "Comida neutral:";

		for (int i = 0; i <= 8; i++)
        {		
			
			float tot = con.habitosint[i] * 3;
			tot = tot + con.habman[i];
			float polladas = con.habitosint[i] * 3;


			//	cosa1[i].text = lel[i].ToString() + "/" + tot.ToString(); EL WENO JODER
			cosa1[i].text = lel[i].ToString() + "/" + polladas.ToString() + "+" + con.habman[i];


			float uno = con.habitosint[i] * 3;
			uno = Mathf.RoundToInt(uno * 0.33f);
			float dos = con.habitosint[i] * 3;
			dos = Mathf.RoundToInt(dos * 0.67f);

			uno = uno + con.habman[i];
			dos = dos + con.habman[i];

			//Debug.Log(uno);
			//Debug.Log(dos);

			if (lel[i] >= 0 && lel[i] < uno) { cosa1[i].color = Color.red; } 
			else if (lel[i] >= uno && lel[i] < tot) { cosa1[i].color = Color.yellow; }
			else if (lel[i] >= tot) { cosa1[i].color = Color.green; }



		}
		for (int i = 0; i <= 8; i++)
		{
			string poner = "";
			if (con.habitosint[i] == 0) { poner = "Nulo"; cosa2[i].color = Color.magenta; }
			if (con.habitosint[i] == 1) { poner = "Bajo"; cosa2[i].color = Color.green; }
			if (con.habitosint[i] == 2) { poner = "Moderado"; cosa2[i].color = Color.yellow; }
			if (con.habitosint[i] == 3) { poner = "Alto"; cosa2[i].color = Color.red; }
			cosa2[i].text = poner;
		}

		cosa3[0].text = "-Bebidas enérgicas: Red Bull, Coca Cola";
		cosa3[1].text = "-Bebidas alcohólicas: Cerveza, Vino";
		cosa3[2].text = "-Bebidas neutrales: Aquarius, Agua";
		cosa3[3].text = "-Snacks: Ganchitos, Ruffles";
		cosa3[4].text = "-Snacks saludables: Pipas, Cacahuetes";
		cosa3[5].text = "-Chocolate: Chocolate";
		cosa3[6].text = "-Comida basura: Pizza, Hot dogs, Kebab";
		cosa3[7].text = "-Comida saludable: Arroz, Ensalada";
		cosa3[8].text = "-Comida neutral: Ramen, Carne";
	}
	

}
