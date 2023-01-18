using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icono : MonoBehaviour {

	public Transform flamas;
	private Transform T;
	public GameObject audioicono;
	public AudioClip au;
	
	void OnEnable () {

		//transform.parent.GetComponent<AudioSource>().Play();
		GameObject o = Instantiate(audioicono);
		o.GetComponent<AudioSource>().volume = o.GetComponent<AudioSource>().volume * Controlador.volumenef;
		o.GetComponent<AudioSource>().PlayOneShot(au);
	}
	void OnDisable()
	{
		//transform.parent.GetComponent<AudioSource>().Stop();
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, -180 * Time.deltaTime, Space.Self);
		
		if (T == null)
        {
			if (GameObject.FindGameObjectWithTag("estoyaquicerda"))
            {
				T = GameObject.FindGameObjectWithTag("estoyaquicerda").transform;
			}
			
			return;
			
		}
		
		flamas.rotation = Quaternion.LookRotation(transform.position - T.position);
		flamas.localEulerAngles = new Vector3(0, flamas.localEulerAngles.y, 0);
	}
}
