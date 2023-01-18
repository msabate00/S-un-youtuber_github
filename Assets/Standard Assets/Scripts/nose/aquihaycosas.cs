using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aquihaycosas : MonoBehaviour
{

	[HideInInspector]
	public GameObject[] enemigosgays;
	public bool envia = false;

	void Start()
	{

	}

	// Update is called once per frame
	void posicionesgays(GameObject[] enemigos)
	{
		enemigosgays = enemigos;
		if (envia)
		{

			transform.GetChild(2).SendMessage("posicionesgays", enemigosgays);
			transform.GetChild(3).SendMessage("posicionesgays", enemigosgays);

		}
	}
}