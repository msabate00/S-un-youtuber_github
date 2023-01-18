using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comunicadorgay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void mirandopalla() {

		if (gameObject.GetComponentInParent<indicadordistancia>() != null)
		{
			gameObject.GetComponentInParent<indicadordistancia>().gameObject.SendMessage("mirando");
		}
		if (gameObject.GetComponentInParent<Recogerdinero>() != null)
        {
			gameObject.GetComponentInParent<Recogerdinero>().gameObject.SendMessage("mirando");
		}
		if (gameObject.GetComponentInParent<Tiempotaladro>() != null)
		{
			gameObject.GetComponentInParent<Tiempotaladro>().gameObject.SendMessage("mirando");
		}
		if (gameObject.GetComponentInParent<Municionwenapack>() != null)
		{
			gameObject.GetComponentInParent<Municionwenapack>().gameObject.SendMessage("mirando");
		}
		if (gameObject.GetComponentInParent<Recogetaladro>() != null)
		{
			gameObject.GetComponentInParent<Recogetaladro>().gameObject.SendMessage("mirandoputo");
		}
		if (gameObject.GetComponentInParent<Salir>() != null)
		{
			gameObject.GetComponentInParent<Salir>().gameObject.SendMessage("mirandoputo");
		}

	}
}
