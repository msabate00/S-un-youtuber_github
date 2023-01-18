using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borraputagay : MonoBehaviour {

	public Transform dos;
	public Transform pollada;
	private Vector3 lal;
	private Vector3 lol;
	private float pollas;
	public Transform amover;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		Vector3 targetDirection = dos.position - transform.position;
		//Debug.Log(targetDirection.magnitude);
		Vector3 targetDirection2 = targetDirection;
		targetDirection2 *= 0.5f;
		lal = transform.position + targetDirection2;
		lal.y += 5;
		pollada.position = lal;
		float angle = Vector3.Angle(targetDirection, forward);
		pollas = Mathf.Sin(Time.time);
		float penes = pollas;
		penes = Mathf.Abs(penes);
		Debug.Log(penes);

		Vector3 posisao = amover.position;
		
		lol = Vector3.Lerp(posisao, lal, Time.deltaTime);
		posisao.y += penes;
		amover.position = lol;
	//	Debug.Log(Mathf.Abs(pollas));
	//	Debug.Log(angle);
	}
}
