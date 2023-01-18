using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIMunicion : MonoBehaviour {

	public TextMeshProUGUI[] t;
	DisparoSelectivo gay;
	public GameObject[] tipo;
	private bool cambiocolor = true;
	public Color[] col;
	public Image[] marco;

	// Update is called once per frame
	void Update () {
		if (gay == null)
        {
			if (GameObject.FindGameObjectWithTag("ELPLAYERJODER"))
            {
				gay = GameObject.FindGameObjectWithTag("ELPLAYERJODER").GetComponentInChildren<DisparoSelectivo>();
			}

			return;
		}

		if (DisparoSelectivo.NumeroArmagay == 2)
        {
			t[0].text = gay.GunStatusScript.BalasActualesEnCargador.ToString();
			t[1].text = gay.GunStatusScript.CargadoresActuales.ToString();
		}
		else if (DisparoSelectivo.NumeroArmagay == 3)
		{
			t[0].text = gay.GunStatusScript.BalasActualesEnCargador.ToString();
			t[1].text = gay.GunStatusScript.CargadoresActuales.ToString();
		}
		else if (DisparoSelectivo.NumeroArmagay == 4)
		{
			t[3].text = gay.GunStatusScript.BalasActualesEnCargador.ToString() + "/" + gay.GunStatusScript.arma2.BalasActualesEnCargador.ToString();
			t[4].text = gay.GunStatusScript.CargadoresActuales.ToString();
		}
		else if (DisparoSelectivo.NumeroArmagay == 5)
		{
			t[2].text = gay.GunStatusScript.BalasActualesEnCargador.ToString();
			
		}
		else if (DisparoSelectivo.NumeroArmagay == 6)
		{
			t[2].text = gay.GunStatusScript.BalasActualesEnCargador.ToString();

		}
		else if (DisparoSelectivo.NumeroArmagay == 7)
		{
			t[3].text = gay.GunStatusScript.BalasActualesEnCargador.ToString() + "/" + gay.GunStatusScript.arma2.BalasActualesEnCargador.ToString();
			t[4].text = gay.GunStatusScript.CargadoresActuales.ToString();
		}
		else if (DisparoSelectivo.NumeroArmagay == 8)
		{
			t[0].text = gay.GunStatusScript.BalasActualesEnCargador.ToString();
			t[1].text = gay.GunStatusScript.CargadoresActuales.ToString();
		}

	}

	public void ActualizarGays()
    {

		if (DisparoSelectivo.NumeroArmagay == 2) {

			foreach (GameObject t in tipo)
			{
				t.SetActive(false);
			}
			tipo[0].SetActive(true);
			if (!cambiocolor) { return; }
			
			TextMeshProUGUI[] mierda = tipo[0].GetComponentsInChildren<TextMeshProUGUI>();
			foreach (TextMeshProUGUI t in mierda)
			{
				int uf = 8;
				t.color = new Color(col[uf].r, col[uf].g, col[uf].b, 1);
			}
			marco[0].color = col[6];
			marco[1].color = col[7];
			marco[2].color = col[8];
		}
		else if (DisparoSelectivo.NumeroArmagay == 3)
		{

			foreach (GameObject t in tipo)
			{
				t.SetActive(false);
			}
			tipo[0].SetActive(true);
			if (!cambiocolor) { return; }

			TextMeshProUGUI[] mierda = tipo[0].GetComponentsInChildren<TextMeshProUGUI>();
			foreach (TextMeshProUGUI t in mierda)
			{
				int uf = 17;
				t.color = new Color(col[uf].r, col[uf].g, col[uf].b, 1);
			}
			marco[0].color = col[15];
			marco[1].color = col[16];
			marco[2].color = col[17];
		}
		else if (DisparoSelectivo.NumeroArmagay == 4)
		{

			foreach (GameObject t in tipo)
			{
				t.SetActive(false);
			}
			tipo[2].SetActive(true);
			if (!cambiocolor) { return; }

			TextMeshProUGUI[] mierda = tipo[2].GetComponentsInChildren<TextMeshProUGUI>();
			foreach (TextMeshProUGUI t in mierda)
			{
				int uf = 11;
				t.color = new Color(col[uf].r, col[uf].g, col[uf].b, 1);
			}
			marco[0].color = col[9];
			marco[1].color = col[10];
			marco[2].color = col[11];
		}
		else if (DisparoSelectivo.NumeroArmagay == 5)
		{

			foreach (GameObject t in tipo)
			{
				t.SetActive(false);
			}
			tipo[1].SetActive(true);
			if (!cambiocolor) { return; }

			TextMeshProUGUI[] mierda = tipo[1].GetComponentsInChildren<TextMeshProUGUI>();
			foreach (TextMeshProUGUI t in mierda)
			{
				int uf = 2;
				t.color = new Color(col[uf].r, col[uf].g, col[uf].b, 1);
			}
			marco[0].color = col[0];
			marco[1].color = col[1];
			marco[2].color = col[2];
		}
		else if (DisparoSelectivo.NumeroArmagay == 6)
		{

			foreach (GameObject t in tipo)
			{
				t.SetActive(false);
			}
			tipo[1].SetActive(true);
			if (!cambiocolor) { return; }

			TextMeshProUGUI[] mierda = tipo[1].GetComponentsInChildren<TextMeshProUGUI>();
			foreach (TextMeshProUGUI t in mierda)
			{
				int uf = 5;
				t.color = new Color(col[uf].r, col[uf].g, col[uf].b, 1);
			}
			marco[0].color = col[3];
			marco[1].color = col[4];
			marco[2].color = col[5];
		}
		else if (DisparoSelectivo.NumeroArmagay == 7)
		{

			foreach (GameObject t in tipo)
			{
				t.SetActive(false);
			}
			tipo[2].SetActive(true);
			if (!cambiocolor) { return; }

			TextMeshProUGUI[] mierda = tipo[2].GetComponentsInChildren<TextMeshProUGUI>();
			foreach (TextMeshProUGUI t in mierda)
			{
				int uf = 14;
				t.color = new Color(col[uf].r, col[uf].g, col[uf].b, 1);
			}
			marco[0].color = col[12];
			marco[1].color = col[13];
			marco[2].color = col[14];
		}
		else if (DisparoSelectivo.NumeroArmagay == 8)
		{

			foreach (GameObject t in tipo)
			{
				t.SetActive(false);
			}
			tipo[0].SetActive(true);
			if (!cambiocolor) { return; }

			TextMeshProUGUI[] mierda = tipo[0].GetComponentsInChildren<TextMeshProUGUI>();
			foreach (TextMeshProUGUI t in mierda)
			{
				int uf = 14;
				t.color = new Color(col[uf].r, col[uf].g, col[uf].b, 1);
			}
			marco[0].color = col[12];
			marco[1].color = col[13];
			marco[2].color = col[14];
		}
	}
}
