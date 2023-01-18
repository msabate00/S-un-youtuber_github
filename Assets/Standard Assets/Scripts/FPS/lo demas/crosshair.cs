using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crosshair : MonoBehaviour {

	public RectTransform[] a;
	public float Distancia;
	public Vector3 Escala;

	public float tiempo;

	public List <Miras> ah = new List<Miras>();
	
	// Update is called once per frame
	void Update () {

		Miras lol = ah[DisparoSelectivo.NumeroArmagay];
		if (FPCStatus.IsAiming)
        {
			Distancia = lol.Distanciaim;
			Escala = lol.Posaim;
		}
        else
        {
			Distancia = lol.Distancia;
			Escala = lol.Pos;
		}


			a[0].localScale = Vector3.MoveTowards(a[0].localScale, Escala, tiempo);
			a[0].anchoredPosition = Vector2.MoveTowards(a[0].anchoredPosition, new Vector2(0, Distancia), tiempo * Time.deltaTime);

			a[1].localScale = Vector3.MoveTowards(a[1].localScale, Escala, tiempo); ;
			a[1].anchoredPosition = Vector2.MoveTowards(a[1].anchoredPosition, new Vector2(0, -Distancia), tiempo * Time.deltaTime);

			a[2].localScale = Vector3.MoveTowards(a[2].localScale, Escala, tiempo); ;
			a[2].anchoredPosition = Vector2.MoveTowards(a[2].anchoredPosition, new Vector2(Distancia, 0), tiempo * Time.deltaTime);

			a[3].localScale = Vector3.MoveTowards(a[3].localScale, Escala, tiempo); ;
			a[3].anchoredPosition = Vector2.MoveTowards(a[3].anchoredPosition, new Vector2(-Distancia, 0), tiempo * Time.deltaTime);

		    a[4].gameObject.GetComponent<RawImage>().enabled = lol.Punto;
		    a[4].anchoredPosition = Vector2.zero;
	}
}
