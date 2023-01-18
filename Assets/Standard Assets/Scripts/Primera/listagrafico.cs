using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listagrafico : MonoBehaviour {

	public static bool grabao = false;

	void OnEnable () {
		if (grabao)
        {
			Controlador.videos.Add(Controlador.nombrevid);
			Controlador.calidadvideos.Add(Controlador.Video2);
			Controlador.Visualizacionestotales = Controlador.Visualizacionestotales + Controlador.Visualizaciones;
			grabao = false;
		}

		while (Controlador.videos.Count > 7)
		{
			Controlador.videos.RemoveAt(0);
		}
		while (Controlador.calidadvideos.Count > 7)
		{
			Controlador.calidadvideos.RemoveAt(0);
		}
		while (Controlador.suscribersgays.Count > 7)
		{
			Controlador.suscribersgays.RemoveAt(0);
		}

		int lel = Controlador.semanas[Controlador.semanas.Count - 1] +1;
		Controlador.semanas.Add(lel);

		Controlador.listadinero.Add(Controlador.Dinero);

		int lal = Controlador.Suscriptores;
		int lol = lal - Controlador.suscriptoresult;
		Controlador.suscribersgays.Add(lol);
		Controlador.suscriptoresult = Controlador.Suscriptores;
	}
	
	
}
