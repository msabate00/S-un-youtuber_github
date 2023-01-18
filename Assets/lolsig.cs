using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lolsig : MonoBehaviour {

	// Use this for initialization
	public Transform sig;
	public bool cabeza = false;
	public bool elegido = false;

	void Update () {
		if (GetComponent<Animator>() != null && elegido)
        {
			esenake.norgay = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;
			//Debug.Log(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime);
		}
	}
	
	// Update is called once per frame
	void OnTriggerStay (Collider dicks) {
		if (dicks.tag == "Comida" && cabeza)
		{
			GameObject.Find("Main Camera").GetComponent<esenake>().comidogays(dicks.transform, false);
			GameObject.Find("Main Camera").GetComponent<esenake>().sonidos(1);
		}

		if (dicks.tag == "Cuerpo" && !esenake.muerto)
		{
			//GetComponent<BoxCollider>().enabled = false;
			esenake.muerto = true;
			GameObject.Find("Main Camera").GetComponent<esenake>().textamen();
			GameObject.Find("Main Camera").GetComponent<esenake>().sonidos(2);
		}
		if (dicks.tag == "Pared")
            {
			Debug.Log("PUTO");
			if (dicks.transform.position.x == 24)
            {
				Vector3 lel = transform.position;
				lel.x = -23;
				transform.position = lel;
            }
			if (dicks.transform.position.x == -24)
			{
				Vector3 lel = transform.position;
				lel.x = 23;
				transform.position = lel;
			}
			if (dicks.transform.position.y == 13)
			{
				Vector3 lel = transform.position;
				lel.y = -12;
				transform.position = lel;
			}
			if (dicks.transform.position.y == -13)
			{
				Vector3 lel = transform.position;
				lel.y = 12;
				transform.position = lel;
			}
		}
	}
}
