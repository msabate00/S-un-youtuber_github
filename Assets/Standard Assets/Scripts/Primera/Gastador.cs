using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gastador : MonoBehaviour {

	private float gastar;
	private Controlador con;
	private int el1 = 0;
	private int el2 = 0;
	private int el3 = 0;
	List<int> ah = new List<int>();
	private bool activao = false;
	public telelista tele;
	public static int dias;

	void OnDisable()
    {
		activao = false;
    }
	
	void cosas()
    {
		con = GameObject.Find("Controladora").GetComponent<Controlador>();


		for (int i = 0; i <= 8; i++)
		{

			ah.Clear();
			gastar = Random.Range(1, 4);
			gastar = gastar * con.habitosint[i];

			gastar = gastar + con.habman[i];

			Debug.Log(gastar);
			float pollas = dias;
			pollas = pollas / 7;
			Debug.Log(gastar);
			gastar = gastar * pollas;
			Debug.Log(pollas);
			Debug.Log(dias);
			Debug.Log(gastar);
			gastar = Mathf.RoundToInt(gastar);
			Debug.Log(gastar);
			//int vecesnetos = gastar;

			if (i == 0) { el1 = 0; el2 = 10; el3 = -1; } //energia nuclear
			else if (i == 1) { el1 = 1; el2 = 2; el3 = -1; } //alcohol
			else if (i == 2) { el1 = 8; el2 = 9; el3 = -1; } //bebidas neutrales
			else if (i == 3) { el1 = 3; el2 = 5; el3 = -1; } //snacks gan y ruf
			else if (i == 4) { el1 = 4; el2 = 7; el3 = -1; } //snacks saludables
			else if (i == 5) { el1 = 6; el2 = -1; el3 = -1; } //chocolate
			else if (i == 6) { el1 = 11; el2 = 15; el3 = 16; } //comida basura
			else if (i == 7) { el1 = 14; el2 = 17; el3 = -1; } //comida saludable
			else if (i == 8) { el1 = 12; el2 = 13; el3 = -1; } //comida neutral

			while (gastar > 0)
			{
				ah.Clear();


				if (el1 >= 0 && con.objetos[el1] > 0)
				{
					ah.Add(el1);
				}
				if (el2 >= 0 && con.objetos[el2] > 0)
				{
					ah.Add(el2);
				}
				if (el3 >= 0 && con.objetos[el3] > 0)
				{
					ah.Add(el3);
				}



				if (ah.Count == 0)
				{
					//Ta triste o algo
					gastar = gastar - triste(i);
					Controlador.Moral = Controlador.Moral - moral(i);


				}
				else
				{
					float lol = gastar; // por cada 1 que baje de 0 es gastar es como que gastas mas de la cuenta y da una recompensa y lol dependiendo de la categoria pos hay mas
					lol = lol - con.habman[i];

					int selec = Random.Range(0, ah.Count);
					con.objetos[ah[selec]]--;
					if (lol <= 0) { Controlador.Moral = Controlador.Moral + recompensa(ah[selec]); }
					gastar = gastar - gas(ah[selec]);


				}

			}




		}

		activao = true;
	}


	void OnEnable () {

		if (!activao)
		{
			tele.autogay();
			Invoke("cosas", 0.1f);
		}
		
	}
	
	int recompensa(float polla)
    {
		     if (polla == 0) { return 1; }
		else if (polla == 1) { return 1; }
		else if (polla == 2) { return 1; }
		else if (polla == 3) { return 1; }
		else if (polla == 4) { return 1; }
		else if (polla == 5) { return 1; }
		else if (polla == 6) { return 1; }
		else if (polla == 7) { return 1; }
		else if (polla == 8) { return 1; }
		else if (polla == 9) { return 1; }
		else if (polla == 10) { return 1; }
		else if (polla == 11) { return 1; }
		else if (polla == 12) { return 1; }
		else if (polla == 13) { return 1; }
		else if (polla == 14) { return 1; }
		else if (polla == 15) { return 1; }
		else if (polla == 16) { return 1; }
		else if (polla == 17) { return 1; }
		return 0;
	}

	float gas(int pene)
    {
             if (pene == 0) { return 1; }
		else if (pene == 1) { return 1; }
		else if (pene == 2) { return 1; }
		else if (pene == 3) { return 1; }
		else if (pene == 4) { return 1; }
		else if (pene == 5) { return 1; }
		else if (pene == 6) { return 1; }
		else if (pene == 7) { return 1; }
		else if (pene == 8) { return 1; }
		else if (pene == 9) { return 1; }
		else if (pene == 10) { return 1; }
		else if (pene == 11) { return 1; }
		else if (pene == 12) { return 1; }
		else if (pene == 13) { return 1; }
		else if (pene == 14) { return 1; }
		else if (pene == 15) { return 1; }
		else if (pene == 16) { return 1; }
		else if (pene == 17) { return 1; }

		else { Debug.Log("NO FUNCIONA COJONES"); return 1; }

	}
	
	float triste(float polla)
    {
             if (polla == 0) { return 1; }
		else if (polla == 1) { return 1; }
		else if (polla == 2) { return 1; }
		else if (polla == 3) { return 1; }
		else if (polla == 4) { return 1; }
		else if (polla == 5) { return 1; }
		else if (polla == 6) { return 1; }
		else if (polla == 7) { return 1; }
		else if (polla == 8) { return 1; }

		else { Debug.Log("NO FUNCIONA COJONES"); return 1; }
	}

	int moral(int polla)
	{
		if (polla == 0) { return 1; }
		else if (polla == 1) { return 1; }
		else if (polla == 2) { return 1; }
		else if (polla == 3) { return 1; }
		else if (polla == 4) { return 1; }
		else if (polla == 5) { return 1; }
		else if (polla == 6) { return 1; }
		else if (polla == 7) { return 1; }
		else if (polla == 8) { return 1; }

		else { Debug.Log("NO FUNCIONA COJONES"); return 1; }
	}

}
