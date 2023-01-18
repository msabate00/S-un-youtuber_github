using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gestorgay : MonoBehaviour {

	public float distancia;
	public Transform gen;
	private float acum = 0;
	public string[] titulo;
	private Controlador con;
	public bool generador = true;
	public int num = 0;

	void Start()
	{

		con = GameObject.Find("Controladora").GetComponent<Controlador>();
		if (generador)
		{
			acum = 0;
			for (int i = 0; i < 9; i++)
			{
				Transform lol = Instantiate(gen, transform.position, transform.rotation, transform);
				lol.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, acum);
				acum = acum + distancia;
				lol.GetChild(0).GetComponent<TextMeshProUGUI>().text = titulo[i];
				lol.GetChild(1).GetComponent<TextMeshProUGUI>().text = con.habman[i].ToString();
				lol.GetComponent<gestorgay>().num = i;
			}
        }
        else
        {
			transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "+" + con.habman[num].ToString();





		}
	
	
	
	
	}
	
	public void sumar()
    {
		con.habman[num]++; transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "+" + con.habman[num].ToString();
	}
	public void restar()
    {
		con.habman[num]--;
		if (con.habman[num] < 0) { con.habman[num] = 0; }
		transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "+" + con.habman[num].ToString();
	}
}
