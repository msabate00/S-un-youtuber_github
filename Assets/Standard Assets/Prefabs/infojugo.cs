using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class infojugo : MonoBehaviour {

	public int juego = 0;
	public RawImage fotopolla;
	public TextMeshProUGUI[] cosa;
	public Texture[] tetas;
	private int req;
	public GameObject prohi;
	public GameObject botones;
	private int gusto;

	public void sumar()
    {
		if (Controlador.horasgays[juego -1] < Controlador.horasmax && Controlador.horastot < Controlador.horastotmax)
        {
			Controlador.horastot++;
			Controlador.horasgays[juego - 1]++;
			cosa[1].text = "Horas asignadas: " + Controlador.horasgays[juego - 1].ToString() + "/" + Controlador.horasmax.ToString();
			transform.parent.gameObject.GetComponent<Horasdedic>().actualizartext();
		}
    }
	public void restar()
	{
		if (Controlador.horasgays[juego - 1] > 0)
		{
			Controlador.horastot--;
			Controlador.horasgays[juego - 1]--;
			cosa[1].text = "Horas asignadas: " + Controlador.horasgays[juego - 1].ToString() + "/" + Controlador.horasmax.ToString();
			transform.parent.gameObject.GetComponent<Horasdedic>().actualizartext();
		}
	}

	public void Cojonazos () {

		transform.parent.gameObject.GetComponent<Horasdedic>().actualizartext();
		fotopolla.texture = tetas[juego - 1];
		cosa[1].text = "Horas asignadas: " + Controlador.horasgays[juego - 1].ToString() + "/" + Controlador.horasmax.ToString();

		switch (juego)
		{
			case 1:

				cosa[0].text = "Counter Strike";
				req = Videojuegos.juego1req;
				gusto = Videojuegos.juego1;

				break;

			case 2:

				cosa[0].text = "Minecraft";
				req = Videojuegos.juego2req;
				gusto = Videojuegos.juego2;

				break;

			case 3:

				cosa[0].text = "League Of Legends";
				req = Videojuegos.juego3req;
				gusto = Videojuegos.juego3;

				break;

			case 4:

				cosa[0].text = "NBA";
				req = Videojuegos.juego4req;
				gusto = Videojuegos.juego4;
				break;

			case 5:

				cosa[0].text = "FIFA";
				req = Videojuegos.juego5req;
				gusto = Videojuegos.juego5;
				break;

			case 6:

				cosa[0].text = "F1";
				req = Videojuegos.juego6req;
				gusto = Videojuegos.juego6;
				break;

			case 7:

				cosa[0].text = "Age of empires";
				req = Videojuegos.juego7req;
				gusto = Videojuegos.juego7;
				break;

			case 8:

				cosa[0].text = "Final fantasy";
				req = Videojuegos.juego8req;
				gusto = Videojuegos.juego8;
				break;

			case 9:

				cosa[0].text = "Dark souls";
				req = Videojuegos.juego9req;
				gusto = Videojuegos.juego9;
				break;

			case 10:

				cosa[0].text = "Need For Speed";
				req = Videojuegos.juego10req;
				gusto = Videojuegos.juego10;
				break;

			case 11:

				cosa[0].text = "Grand Theft Auto";
				req = Videojuegos.juego11req;
				gusto = Videojuegos.juego11;
				break;

			case 12:

				cosa[0].text = "Portal";
				req = Videojuegos.juego12req;
				gusto = Videojuegos.juego12;
				break;

			case 13:

				cosa[0].text = "Assassin's Creed";
				req = Videojuegos.juego13req;
				gusto = Videojuegos.juego13;
				break;

			case 14:

				cosa[0].text = "Bioshock";
				req = Videojuegos.juego14req;
				gusto = Videojuegos.juego14;
				break;

			case 15:

				cosa[0].text = "Undertale";
				req = Videojuegos.juego15req;
				gusto = Videojuegos.juego15;
				break;

			case 16:

				cosa[0].text = "Fallout";
				req = Videojuegos.juego16req;
				gusto = Videojuegos.juego16;

				break;

			case 17:

				cosa[0].text = "Dragon Age";
				req = Videojuegos.juego17req;
				gusto = Videojuegos.juego17;
				break;

			case 18:

				cosa[0].text = "Devil May Cry";
				req = Videojuegos.juego18req;
				gusto = Videojuegos.juego18;
				break;

			case 19:

				cosa[0].text = "Diablo";
				req = Videojuegos.juego19req;
				gusto = Videojuegos.juego19;
				break;

			case 20:

				cosa[0].text = "World Of Warcraft";
				req = Videojuegos.juego20req;
				gusto = Videojuegos.juego20;
				break;

			case 21:

				cosa[0].text = "Call Of Duty";
				req = Videojuegos.juego21req;
				gusto = Videojuegos.juego21;
				break;

			case 22:

				cosa[0].text = "Destiny";
				req = Videojuegos.juego22req;
				gusto = Videojuegos.juego22;
				break;

			case 23:

				cosa[0].text = "Bloodborne";
				req = Videojuegos.juego23req;
				gusto = Videojuegos.juego23;
				break;

			case 24:

				cosa[0].text = "Unravel";
				req = Videojuegos.juego24req;
				gusto = Videojuegos.juego24;
				break;

			case 25:

				cosa[0].text = "Battlefield";
				req = Videojuegos.juego25req;
				gusto = Videojuegos.juego25;
				break;

			case 26:

				cosa[0].text = "Spiderman";
				req = Videojuegos.juego26req;
				gusto = Videojuegos.juego26;
				break;

			case 27:

				cosa[0].text = "Rainbow six";
				req = Videojuegos.juego27req;
				gusto = Videojuegos.juego27;
				break;

			case 28:

				cosa[0].text = "Forza horizon";
				req = Videojuegos.juego28req;
				gusto = Videojuegos.juego28;
				break;

			case 29:

				cosa[0].text = "No man's sky";
				req = Videojuegos.juego29req;
				gusto = Videojuegos.juego29;
				break;

			case 30:

				cosa[0].text = "Nier automata";
				req = Videojuegos.juego30req;
				gusto = Videojuegos.juego30;
				break;

			case 31:

				cosa[0].text = "The witcher";
				req = Videojuegos.juego31req;
				gusto = Videojuegos.juego31;
				break;

			case 32:

				cosa[0].text = "Kingdom hearts";
				req = Videojuegos.juego32req;
				gusto = Videojuegos.juego32;
				break;


			case 33:

				cosa[0].text = "God Of War";
				req = Videojuegos.juego33req;
				gusto = Videojuegos.juego33;
				break;

			case 34:

				cosa[0].text = "Red dead redemption";
				req = Videojuegos.juego34req;
				gusto = Videojuegos.juego34;
				break;

			case 35:

				cosa[0].text = "Fortnite";
				req = Videojuegos.juego35req;
				gusto = Videojuegos.juego35;
				break;
		}

		if (gusto == 2)
        {
			cosa[2].text = "Habilidad: Baja";
        }

		if (gusto == 5)
		{
			cosa[2].text = "Habilidad: Normal";
		}

		if (gusto == 8)
		{
			cosa[2].text = "Habilidad: Experto";
		}

		if (Controlador.Ordenador < req)
		{
			prohi.SetActive(true);
			botones.SetActive(false);
		}

	}
	
	
}
