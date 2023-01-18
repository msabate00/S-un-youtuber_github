using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desactivadorarray1 : MonoBehaviour {

	public GameObject[] Activar;
	public GameObject[] Adesactivar;

	public void COJONESENTUBOCA () {
		Debug.Log("lal");
		foreach (GameObject pollada in Activar)
		{
			if (pollada != null)
            {
				pollada.SetActive(true);
			}
			
		}
		foreach (GameObject pollada in Adesactivar)
		{
			if (pollada != null)
			{
				pollada.SetActive(false);
			}
			
		}
	}
	
	// Update is called once per frame
	void OnMouseDown () {

		COJONESENTUBOCA();

	}
	
}
