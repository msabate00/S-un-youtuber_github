using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Horasdedic : MonoBehaviour {

	public float distanciagay = 73;
	public List<int> listagay = new List<int>();
	public GameObject prefabgay;
	private float distgay = 0;
	public float dismax;
	public Slider slidergay;
	public TextMeshProUGUI cosa;

	void OnEnable () {
		listagay.Clear();

		comprovar();
	}
	
	public void actualizartext()
    {
		cosa.text = "Horas totales: " + Controlador.horastot.ToString() + "/" + Controlador.horastotmax.ToString();

	}
	
	void comprovar()
    {
		GameObject[] cosas = GameObject.FindGameObjectsWithTag("TU MADRE ES GAY");
		foreach (GameObject ah in cosas)
        {
			Destroy(ah);
        }
		
		distgay = 0;
		listagay.Clear();
		if (Videojuegos.juego1com == 1) { listagay.Add(1); }
		if (Videojuegos.juego2com == 1) { listagay.Add(2); }
		if (Videojuegos.juego3com == 1) { listagay.Add(3); }
		if (Videojuegos.juego4com == 1) { listagay.Add(4); }
		if (Videojuegos.juego5com == 1) { listagay.Add(5); }
		if (Videojuegos.juego6com == 1) { listagay.Add(6); }
		if (Videojuegos.juego7com == 1) { listagay.Add(7); }
		if (Videojuegos.juego8com == 1) { listagay.Add(8); }
		if (Videojuegos.juego9com == 1) { listagay.Add(9); }
		if (Videojuegos.juego10com == 1) { listagay.Add(10); }
		if (Videojuegos.juego11com == 1) { listagay.Add(11); }
		if (Videojuegos.juego12com == 1) { listagay.Add(12); }
		if (Videojuegos.juego13com == 1) { listagay.Add(13); }
		if (Videojuegos.juego14com == 1) { listagay.Add(14); }
		if (Videojuegos.juego15com == 1) { listagay.Add(15); }
		if (Videojuegos.juego16com == 1) { listagay.Add(16); }
		if (Videojuegos.juego17com == 1) { listagay.Add(17); }
		if (Videojuegos.juego18com == 1) { listagay.Add(18); }
		if (Videojuegos.juego19com == 1) { listagay.Add(19); }
		if (Videojuegos.juego20com == 1) { listagay.Add(20); }
		if (Videojuegos.juego21com == 1) { listagay.Add(21); }
		if (Videojuegos.juego22com == 1) { listagay.Add(22); }
		if (Videojuegos.juego23com == 1) { listagay.Add(23); }
		if (Videojuegos.juego24com == 1) { listagay.Add(24); }
		if (Videojuegos.juego25com == 1) { listagay.Add(25); }
		if (Videojuegos.juego26com == 1) { listagay.Add(26); }
		if (Videojuegos.juego27com == 1) { listagay.Add(27); }
		if (Videojuegos.juego28com == 1) { listagay.Add(28); }
		if (Videojuegos.juego29com == 1) { listagay.Add(29); }
		if (Videojuegos.juego30com == 1) { listagay.Add(30); }
		if (Videojuegos.juego31com == 1) { listagay.Add(31); }
		if (Videojuegos.juego32com == 1) { listagay.Add(32); }
		if (Videojuegos.juego33com == 1) { listagay.Add(33); }
		if (Videojuegos.juego34com == 1) { listagay.Add(34); }
		if (Videojuegos.juego35com == 1) { listagay.Add(35); }

		if (listagay.Count <= 4) {
			dismax = 0;
		}
		else if (listagay.Count >= 5)
        {
			dismax = listagay.Count;
			dismax = dismax * 63f;
			dismax = dismax - 269.62f;
        }

		for(int i = 0; i < listagay.Count; i++)
        {
			GameObject pene = Instantiate(prefabgay, transform.position, transform.rotation, transform);
			pene.transform.tag = "TU MADRE ES GAY";
			pene.GetComponent<infojugo>().juego = listagay[i];
			pene.GetComponent<RectTransform>().anchoredPosition = new Vector2 (0, distgay);
			distgay = distgay + distanciagay;
			pene.GetComponent<infojugo>().Cojonazos();

		}
	}

	void Update()
    {
		if (Input.GetKey(KeyCode.UpArrow)) {

			Vector2 lol = transform.GetComponent<RectTransform>().anchoredPosition;
			lol.y -= 110 * Time.deltaTime;
			transform.GetComponent<RectTransform>().anchoredPosition = lol;

			slidergay.value = lol.y / dismax;
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			Vector2 lol = transform.GetComponent<RectTransform>().anchoredPosition;
			lol.y += 110 * Time.deltaTime;
			transform.GetComponent<RectTransform>().anchoredPosition = lol;

			slidergay.value = lol.y / dismax;
		}

			else if (Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")) > 0) {
			Vector2 lol = transform.GetComponent<RectTransform>().anchoredPosition;
			lol.y -= Input.GetAxis("Mouse ScrollWheel") * 70;
			transform.GetComponent<RectTransform>().anchoredPosition = lol;

			slidergay.value = lol.y / dismax;			
		}


		float pene = slidergay.value;
		pene = pene * dismax;
		transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, pene);
    }


}
