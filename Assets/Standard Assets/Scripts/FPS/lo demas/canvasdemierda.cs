using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class canvasdemierda : MonoBehaviour {

	public Animation gayanimacion2;
	public GameObject fondo2;
	public Image circulo2;
	public TextMeshProUGUI textamen2;
	public Animation textoconcluada;
	public GameObject mensaje;

	public static Animation gayanimacion;
	public static Animation textoconclusion;
	public static GameObject fondo;
	public static Image circulo;
	public static TextMeshProUGUI textamen;

	void Awake () {
		Controlador.dineroasegurado = 0;
		gayanimacion = gayanimacion2;
		fondo = fondo2;
		circulo = circulo2;
		textamen = textamen2;
		textoconclusion = textoconcluada;
	}
	
	// Update is called once per frame
	void Update () {
		if (Controlador.llevobolsa)
        {
			mensaje.SetActive(true);
        }
        else
        {
			mensaje.SetActive(false);
		}
	}

	public void actualizarvida()
    {

    }

	public void asignarsexo(string penis)
    {
		Controlador.ah.listastats[Controlador.ah.posranking].Texto = penis;
    }
}
