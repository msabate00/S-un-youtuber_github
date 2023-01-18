using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autorotar2 : MonoBehaviour {

	public Transform target;
	public Vector3 gay;

	void Start () {

		if (!GameObject.FindGameObjectWithTag("ELPLAYERJODER")) { return; }
		//target = GameObject.FindGameObjectWithTag("ELPLAYERJODER").transform.GetChild(0);

	}
	
	// Update is called once per frame
	void Update () {

		if (target == null) {

			//if (GameObject.FindGameObjectWithTag("ELPLAYERJODER")) { target = GameObject.FindGameObjectWithTag("ELPLAYERJODER").transform.GetChild(0); }
			if (GameObject.FindGameObjectWithTag("Finish"))
            {
				target = GameObject.FindGameObjectWithTag("Finish").transform;
			}
            else
            {
				target = Camera.main.transform;
			}

			
			return;
		}

		transform.LookAt(target, gay);
		transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
	}
}
