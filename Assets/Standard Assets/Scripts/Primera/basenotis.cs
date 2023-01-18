using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class basenotis : MonoBehaviour {

	//public List<clasecont> listagay = new List<clasecont>();
	public clasecont[] arraygay;

	public Renderer fotogay;
	public TextMeshProUGUI[] textos;

	void OnEnable()
	{
		//listagay.Add(new clasecont(titulogay, valorgay));

		clasecont lal = arraygay[0];
		//clasecont lol = listagay[listagay.Count - 1];

		textos[0].text = lal.titulo;
		textos[1].text = lal.texto;
		fotogay.material.mainTexture = lal.imagen;
		//titfinal = lol.titulo;
		//valfinal = lol.valor;

	}
}
