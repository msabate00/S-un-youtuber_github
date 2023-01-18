using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seteadorsangreanims : MonoBehaviour {

	public GameObject particulas;
	public GameObject particulas2;
	public List<AnimacionesSangre> lista = new List<AnimacionesSangre>();
	private ParticleSystem par;

	public void ComprovadorSangre (string Nom) {
		for (int i = 0; i < lista.Count; i++)
        {
			if (Nom == lista[i].Nombre)
            {
				StartCoroutine(follar(i));
				return;
            }
        }
	}
	
	IEnumerator follar(int a)
    {
		par = particulas.GetComponent<ParticleSystem>();


		var main = par.main;
		main.startSize = lista[a].StartSize;
		main.startSpeed = lista[a].StartSpeed;

		var Shape = par.shape;
		Shape.angle = lista[a].angle;

		var Burst = par.emission.burstCount;
		Burst = lista[a].burst;

		particulas.transform.localEulerAngles = lista[a].rot;
		particulas.transform.localPosition = lista[a].pos;
		particulas2.transform.localPosition = lista[a].posburst;

		yield return new WaitForSeconds(lista[a].t1);
		particulas.SetActive(true);
		if (lista[a].boomejec) { particulas2.SetActive(true); }

		yield return new WaitForSeconds(lista[a].t2 - lista[a].t1);
		var emission = par.emission;
		emission.enabled = false;
	}
}
