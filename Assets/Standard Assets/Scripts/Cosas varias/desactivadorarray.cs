using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desactivadorarray : MonoBehaviour {

	public GameObject[] Activar;
	public GameObject[] Adesactivar;
	public GameObject camaraman;
	public bool esout = false;
	public Canvas m_Canvas;

	public void AHPUTA () {
		if (esout)
        {
			camaraman.GetComponent<Camara>().enabled = true;
			camaraman.GetComponent<Desactibaor>().enabled = false;
			Controlador.amplia = 1;
			foreach (GameObject pollada in Activar)
			{
				pollada.SetActive(true);
			}
			foreach (GameObject pollada in Adesactivar)
			{
				pollada.SetActive(false);
			}
		}
	}
	
	// Update is called once per frame
	void OnMouseDown () {
		

		camaraman.GetComponent<Camara>().enabled = false;
		camaraman.GetComponent<Desactibaor>().enabled = true;
		Controlador.amplia = 2;
		foreach (GameObject pollada in Activar)
		{
			pollada.SetActive(true);
		}
		foreach (GameObject pollada in Adesactivar)
		{
			pollada.SetActive(false);
		}
		if (esout)
		{

			Vector3 pollas = m_Canvas.transform.position;
			pollas.z = -100;
			m_Canvas.transform.position = pollas;
		}
	}
}
