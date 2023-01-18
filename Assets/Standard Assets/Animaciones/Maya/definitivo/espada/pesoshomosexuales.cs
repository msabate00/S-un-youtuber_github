using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pesoshomosexuales : MonoBehaviour {

	private Animator a;
	private bool gay = false;
	public float vel = 1;
	public float velregreso = 1;
	public float tiempoespera = 0.3f;

	void Start () {
		a = GetComponent<Animator>();
		a.Play("Andar derecha");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.B))
        {
			StopAllCoroutines();
			StartCoroutine(putes(gay));
			gay = !gay;
		}
	
	}


    IEnumerator putes(bool oh)
    {
		while (true)
        {
			
			if (oh) {

				a.SetLayerWeight(1, Mathf.MoveTowards(a.GetLayerWeight(1), 0, vel * Time.deltaTime));
				a.SetLayerWeight(2, Mathf.MoveTowards(a.GetLayerWeight(2), 0, vel * Time.deltaTime));
				a.SetLayerWeight(3, Mathf.MoveTowards(a.GetLayerWeight(3), 1, vel * Time.deltaTime));

				if (a.GetLayerWeight(2) == 0 && a.GetLayerWeight(3) == 1) { break; }
			}
            else
            {
				a.SetLayerWeight(1, Mathf.MoveTowards(a.GetLayerWeight(1), 0, vel * Time.deltaTime));
				a.SetLayerWeight(2, Mathf.MoveTowards(a.GetLayerWeight(2), 1, vel * Time.deltaTime));
				a.SetLayerWeight(3, Mathf.MoveTowards(a.GetLayerWeight(3), 0, vel * Time.deltaTime));

				if (a.GetLayerWeight(2) == 1 && a.GetLayerWeight(3) == 0) { break; }
			}

			
			yield return new WaitForEndOfFrame();
		}

		yield return new WaitForSeconds(tiempoespera);
        
		while (true)
        {
			a.SetLayerWeight(1, Mathf.MoveTowards(a.GetLayerWeight(1), 1, velregreso * Time.deltaTime));
			a.SetLayerWeight(2, Mathf.MoveTowards(a.GetLayerWeight(2), 0, velregreso * Time.deltaTime));
			a.SetLayerWeight(3, Mathf.MoveTowards(a.GetLayerWeight(3), 0, velregreso * Time.deltaTime));

			yield return new WaitForEndOfFrame();
		}

	}

}
