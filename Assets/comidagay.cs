using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comidagay : MonoBehaviour {

	
	private float tiempo;
	void Start()
	{
		tiempo = Time.time + 0.1f;
		Destroy(gameObject, 25);
	}

	// Update is called once per frame
	void OnTriggerStay(Collider puto)
	{
		if (puto.tag == "Cuerpo" || puto.tag == "Comida" || puto.tag == "Mierda")
		{

			if (Time.time < tiempo)
			{				
				if (puto.tag == "Cuerpo" && puto.gameObject.GetComponent<lolsig>().cabeza == false || puto.tag != "Cuerpo")
                {
					GameObject.Find("Main Camera").GetComponent<esenake>().comidogays(transform, true);
				}
				
			}
		}

	}
}
