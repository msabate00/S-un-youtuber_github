using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reguladorjugos : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {


		for (int i = 0; i < 35; i++)
        {
			Controlador.horasgaystotales[i] = Controlador.horasgaystotales[i] -= 2;
			Controlador.horasgaystotales[i] = Mathf.Clamp(Controlador.horasgaystotales[i], 0, 5);
			Controlador.horasgaystotales[i] = Controlador.horasgaystotales[i] + Controlador.horasgays[i];
			Controlador.horasgaystotales[i] = Mathf.Clamp(Controlador.horasgaystotales[i], 0, 5);
		}

		lol();
	}
	
	// Update is called once per frame
	void lol () {
		
		if (Controlador.horasgaystotales[0] <= 2)
        {
			Videojuegos.juego1skill = -1;
		}
		if (Controlador.horasgaystotales[0] >= 3 && Controlador.horasgaystotales[0] <= 4)
		{
			Videojuegos.juego1skill = 0;
		}
		if (Controlador.horasgaystotales[0] == 5)
		{
			Videojuegos.juego1skill = 1;
		}


		if (Controlador.horasgaystotales[1] <= 2)
		{
			Videojuegos.juego2skill = -1;
		}
		if (Controlador.horasgaystotales[1] >= 3 && Controlador.horasgaystotales[1] <= 4)
		{
			Videojuegos.juego2skill = 0;
		}
		if (Controlador.horasgaystotales[1] == 5)
		{
			Videojuegos.juego2skill = 1;
		}


		if (Controlador.horasgaystotales[2] <= 2)
		{
			Videojuegos.juego3skill = -1;
		}
		if (Controlador.horasgaystotales[2] >= 3 && Controlador.horasgaystotales[2] <= 4)
		{
			Videojuegos.juego3skill = 0;
		}
		if (Controlador.horasgaystotales[2] == 5)
		{
			Videojuegos.juego3skill = 1;
		}


		if (Controlador.horasgaystotales[3] <= 2)
		{
			Videojuegos.juego4skill = -1;
		}
		if (Controlador.horasgaystotales[3] >= 3 && Controlador.horasgaystotales[3] <= 4)
		{
			Videojuegos.juego4skill = 0;
		}
		if (Controlador.horasgaystotales[3] == 5)
		{
			Videojuegos.juego4skill = 1;
		}


		if (Controlador.horasgaystotales[4] <= 2)
		{
			Videojuegos.juego5skill = -1;
		}
		if (Controlador.horasgaystotales[4] >= 3 && Controlador.horasgaystotales[4] <= 4)
		{
			Videojuegos.juego5skill = 0;
		}
		if (Controlador.horasgaystotales[4] == 5)
		{
			Videojuegos.juego5skill = 1;
		}


		if (Controlador.horasgaystotales[5] <= 2)
		{
			Videojuegos.juego6skill = -1;
		}
		if (Controlador.horasgaystotales[5] >= 3 && Controlador.horasgaystotales[5] <= 4)
		{
			Videojuegos.juego6skill = 0;
		}
		if (Controlador.horasgaystotales[5] == 5)
		{
			Videojuegos.juego6skill = 1;
		}


		if (Controlador.horasgaystotales[6] <= 2)
		{
			Videojuegos.juego7skill = -1;
		}
		if (Controlador.horasgaystotales[6] >= 3 && Controlador.horasgaystotales[6] <= 4)
		{
			Videojuegos.juego7skill = 0;
		}
		if (Controlador.horasgaystotales[6] == 5)
		{
			Videojuegos.juego7skill = 1;
		}


		if (Controlador.horasgaystotales[7] <= 2)
		{
			Videojuegos.juego8skill = -1;
		}
		if (Controlador.horasgaystotales[7] >= 3 && Controlador.horasgaystotales[7] <= 4)
		{
			Videojuegos.juego8skill = 0;
		}
		if (Controlador.horasgaystotales[7] == 5)
		{
			Videojuegos.juego8skill = 1;
		}


		if (Controlador.horasgaystotales[8] <= 2)
		{
			Videojuegos.juego9skill = -1;
		}
		if (Controlador.horasgaystotales[8] >= 3 && Controlador.horasgaystotales[8] <= 4)
		{
			Videojuegos.juego9skill = 0;
		}
		if (Controlador.horasgaystotales[8] == 5)
		{
			Videojuegos.juego9skill = 1;
		}


		if (Controlador.horasgaystotales[9] <= 2)
		{
			Videojuegos.juego10skill = -1;
		}
		if (Controlador.horasgaystotales[9] >= 3 && Controlador.horasgaystotales[9] <= 4)
		{
			Videojuegos.juego10skill = 0;
		}
		if (Controlador.horasgaystotales[9] == 5)
		{
			Videojuegos.juego10skill = 1;
		}


		if (Controlador.horasgaystotales[10] <= 2)
		{
			Videojuegos.juego11skill = -1;
		}
		if (Controlador.horasgaystotales[10] >= 3 && Controlador.horasgaystotales[10] <= 4)
		{
			Videojuegos.juego11skill = 0;
		}
		if (Controlador.horasgaystotales[10] == 5)
		{
			Videojuegos.juego11skill = 1;
		}


		if (Controlador.horasgaystotales[11] <= 2)
		{
			Videojuegos.juego12skill = -1;
		}
		if (Controlador.horasgaystotales[11] >= 3 && Controlador.horasgaystotales[11] <= 4)
		{
			Videojuegos.juego12skill = 0;
		}
		if (Controlador.horasgaystotales[11] == 5)
		{
			Videojuegos.juego12skill = 1;
		}


		if (Controlador.horasgaystotales[12] <= 2)
		{
			Videojuegos.juego13skill = -1;
		}
		if (Controlador.horasgaystotales[12] >= 3 && Controlador.horasgaystotales[12] <= 4)
		{
			Videojuegos.juego13skill = 0;
		}
		if (Controlador.horasgaystotales[12] == 5)
		{
			Videojuegos.juego13skill = 1;
		}


		if (Controlador.horasgaystotales[13] <= 2)
		{
			Videojuegos.juego14skill = -1;
		}
		if (Controlador.horasgaystotales[13] >= 3 && Controlador.horasgaystotales[13] <= 4)
		{
			Videojuegos.juego14skill = 0;
		}
		if (Controlador.horasgaystotales[13] == 5)
		{
			Videojuegos.juego14skill = 1;
		}


		if (Controlador.horasgaystotales[14] <= 2)
		{
			Videojuegos.juego15skill = -1;
		}
		if (Controlador.horasgaystotales[14] >= 3 && Controlador.horasgaystotales[14] <= 4)
		{
			Videojuegos.juego15skill = 0;
		}
		if (Controlador.horasgaystotales[14] == 5)
		{
			Videojuegos.juego15skill = 1;
		}


		if (Controlador.horasgaystotales[15] <= 2)
		{
			Videojuegos.juego16skill = -1;
		}
		if (Controlador.horasgaystotales[15] >= 3 && Controlador.horasgaystotales[15] <= 4)
		{
			Videojuegos.juego16skill = 0;
		}
		if (Controlador.horasgaystotales[15] == 5)
		{
			Videojuegos.juego16skill = 1;
		}


		if (Controlador.horasgaystotales[16] <= 2)
		{
			Videojuegos.juego17skill = -1;
		}
		if (Controlador.horasgaystotales[16] >= 3 && Controlador.horasgaystotales[16] <= 4)
		{
			Videojuegos.juego17skill = 0;
		}
		if (Controlador.horasgaystotales[16] == 5)
		{
			Videojuegos.juego17skill = 1;
		}


		if (Controlador.horasgaystotales[17] <= 2)
		{
			Videojuegos.juego18skill = -1;
		}
		if (Controlador.horasgaystotales[17] >= 3 && Controlador.horasgaystotales[17] <= 4)
		{
			Videojuegos.juego18skill = 0;
		}
		if (Controlador.horasgaystotales[17] == 5)
		{
			Videojuegos.juego18skill = 1;
		}


		if (Controlador.horasgaystotales[18] <= 2)
		{
			Videojuegos.juego19skill = -1;
		}
		if (Controlador.horasgaystotales[18] >= 3 && Controlador.horasgaystotales[18] <= 4)
		{
			Videojuegos.juego19skill = 0;
		}
		if (Controlador.horasgaystotales[18] == 5)
		{
			Videojuegos.juego19skill = 1;
		}


		if (Controlador.horasgaystotales[19] <= 2)
		{
			Videojuegos.juego20skill = -1;
		}
		if (Controlador.horasgaystotales[19] >= 3 && Controlador.horasgaystotales[19] <= 4)
		{
			Videojuegos.juego20skill = 0;
		}
		if (Controlador.horasgaystotales[19] == 5)
		{
			Videojuegos.juego20skill = 1;
		}


		if (Controlador.horasgaystotales[20] <= 2)
		{
			Videojuegos.juego21skill = -1;
		}
		if (Controlador.horasgaystotales[20] >= 3 && Controlador.horasgaystotales[20] <= 4)
		{
			Videojuegos.juego21skill = 0;
		}
		if (Controlador.horasgaystotales[20] == 5)
		{
			Videojuegos.juego21skill = 1;
		}


		if (Controlador.horasgaystotales[21] <= 2)
		{
			Videojuegos.juego22skill = -1;
		}
		if (Controlador.horasgaystotales[21] >= 3 && Controlador.horasgaystotales[21] <= 4)
		{
			Videojuegos.juego22skill = 0;
		}
		if (Controlador.horasgaystotales[21] == 5)
		{
			Videojuegos.juego22skill = 1;
		}


		if (Controlador.horasgaystotales[22] <= 2)
		{
			Videojuegos.juego23skill = -1;
		}
		if (Controlador.horasgaystotales[22] >= 3 && Controlador.horasgaystotales[22] <= 4)
		{
			Videojuegos.juego23skill = 0;
		}
		if (Controlador.horasgaystotales[22] == 5)
		{
			Videojuegos.juego23skill = 1;
		}


		if (Controlador.horasgaystotales[23] <= 2)
		{
			Videojuegos.juego24skill = -1;
		}
		if (Controlador.horasgaystotales[23] >= 3 && Controlador.horasgaystotales[23] <= 4)
		{
			Videojuegos.juego24skill = 0;
		}
		if (Controlador.horasgaystotales[23] == 5)
		{
			Videojuegos.juego24skill = 1;
		}


		if (Controlador.horasgaystotales[24] <= 2)
		{
			Videojuegos.juego25skill = -1;
		}
		if (Controlador.horasgaystotales[24] >= 3 && Controlador.horasgaystotales[24] <= 4)
		{
			Videojuegos.juego25skill = 0;
		}
		if (Controlador.horasgaystotales[24] == 5)
		{
			Videojuegos.juego25skill = 1;
		}


		if (Controlador.horasgaystotales[25] <= 2)
		{
			Videojuegos.juego26skill = -1;
		}
		if (Controlador.horasgaystotales[25] >= 3 && Controlador.horasgaystotales[25] <= 4)
		{
			Videojuegos.juego26skill = 0;
		}
		if (Controlador.horasgaystotales[25] == 5)
		{
			Videojuegos.juego26skill = 1;
		}


		if (Controlador.horasgaystotales[26] <= 2)
		{
			Videojuegos.juego27skill = -1;
		}
		if (Controlador.horasgaystotales[26] >= 3 && Controlador.horasgaystotales[26] <= 4)
		{
			Videojuegos.juego27skill = 0;
		}
		if (Controlador.horasgaystotales[26] == 5)
		{
			Videojuegos.juego27skill = 1;
		}


		if (Controlador.horasgaystotales[27] <= 2)
		{
			Videojuegos.juego28skill = -1;
		}
		if (Controlador.horasgaystotales[27] >= 3 && Controlador.horasgaystotales[27] <= 4)
		{
			Videojuegos.juego28skill = 0;
		}
		if (Controlador.horasgaystotales[27] == 5)
		{
			Videojuegos.juego28skill = 1;
		}


		if (Controlador.horasgaystotales[28] <= 2)
		{
			Videojuegos.juego29skill = -1;
		}
		if (Controlador.horasgaystotales[28] >= 3 && Controlador.horasgaystotales[28] <= 4)
		{
			Videojuegos.juego29skill = 0;
		}
		if (Controlador.horasgaystotales[28] == 5)
		{
			Videojuegos.juego29skill = 1;
		}


		if (Controlador.horasgaystotales[29] <= 2)
		{
			Videojuegos.juego30skill = -1;
		}
		if (Controlador.horasgaystotales[29] >= 3 && Controlador.horasgaystotales[29] <= 4)
		{
			Videojuegos.juego30skill = 0;
		}
		if (Controlador.horasgaystotales[29] == 5)
		{
			Videojuegos.juego30skill = 1;
		}


		if (Controlador.horasgaystotales[30] <= 2)
		{
			Videojuegos.juego31skill = -1;
		}
		if (Controlador.horasgaystotales[30] >= 3 && Controlador.horasgaystotales[30] <= 4)
		{
			Videojuegos.juego31skill = 0;
		}
		if (Controlador.horasgaystotales[30] == 5)
		{
			Videojuegos.juego31skill = 1;
		}


		if (Controlador.horasgaystotales[31] <= 2)
		{
			Videojuegos.juego32skill = -1;
		}
		if (Controlador.horasgaystotales[31] >= 3 && Controlador.horasgaystotales[31] <= 4)
		{
			Videojuegos.juego32skill = 0;
		}
		if (Controlador.horasgaystotales[31] == 5)
		{
			Videojuegos.juego32skill = 1;
		}


		if (Controlador.horasgaystotales[32] <= 2)
		{
			Videojuegos.juego33skill = -1;
		}
		if (Controlador.horasgaystotales[32] >= 3 && Controlador.horasgaystotales[32] <= 4)
		{
			Videojuegos.juego33skill = 0;
		}
		if (Controlador.horasgaystotales[32] == 5)
		{
			Videojuegos.juego33skill = 1;
		}


		if (Controlador.horasgaystotales[33] <= 2)
		{
			Videojuegos.juego34skill = -1;
		}
		if (Controlador.horasgaystotales[33] >= 3 && Controlador.horasgaystotales[33] <= 4)
		{
			Videojuegos.juego34skill = 0;
		}
		if (Controlador.horasgaystotales[33] == 5)
		{
			Videojuegos.juego34skill = 1;
		}


		if (Controlador.horasgaystotales[34] <= 2)
		{
			Videojuegos.juego35skill = -1;
		}
		if (Controlador.horasgaystotales[34] >= 3 && Controlador.horasgaystotales[34] <= 4)
		{
			Videojuegos.juego35skill = 0;
		}
		if (Controlador.horasgaystotales[34] == 5)
		{
			Videojuegos.juego35skill = 1;
		}


		

	}
}
