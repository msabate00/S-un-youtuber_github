using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moridura : MonoBehaviour {

	private float tiempo;
	private float tiempodestr;

	void Start () {
		tiempo = Time.time + 0.1f;
		tiempodestr = Time.time + 25;
		Invoke("destruir", 25);
		Invoke("activargays", 0.04f);
	}
	
	void destruir()
    {
		if (!esenake.muerto)
        {
			Destroy(gameObject);
		}
    }
	
	void activargays()
    {
		GetComponent<MeshRenderer>().enabled = true;
    }
	void Update()
    {
		if (Time.time > tiempodestr && !esenake.muerto) { Destroy(gameObject); }		
		
	}
	void OnTriggerStay (Collider puto) {
		if (puto.tag == "Cuerpo" || puto.tag == "Comida" || puto.tag == "Mierda")
        {
		
			if (Time.time < tiempo)
            {
				Destroy(gameObject);
			}
            else
            {
				if (puto.tag == "Cuerpo" && !esenake.muerto)
				{
					//GetComponent<BoxCollider>().enabled = false;
					esenake.muerto = true;
					GameObject.Find("Main Camera").GetComponent<esenake>().textamen();
					GameObject.Find("Main Camera").GetComponent<esenake>().sonidos(2);
					Destroy(gameObject);
				}
            }
			
		}
		
	}
}
