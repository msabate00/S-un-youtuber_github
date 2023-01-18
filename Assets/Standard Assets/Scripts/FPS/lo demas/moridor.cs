using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moridor : MonoBehaviour {

	// Use this for initialization
	private Rigidbody lol;
	private Vector3 vel;

	void Start () {
		GetComponentInChildren<Camera>().fieldOfView = Controlador.fov;
		lol = GetComponent<Rigidbody>();
	}
	
	public void sex (Quaternion lol, Vector3 mom) {

		vel = mom;
		transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
		Transform penis = GetComponentInChildren<Camera>().transform;
		penis.rotation = lol;
		penis.localEulerAngles = new Vector3(penis.localEulerAngles.x + -7, 0, 0);
		StartCoroutine(putas());
		//GetComponent<Animator>().Play("Muerte", 0, 0);
	}

	IEnumerator putas()
    {
		yield return null;
		GetComponent<Animator>().CrossFadeInFixedTime("Muerte", 0.2f, -1, 0, 0);
	}

	void Update()
    {
		lol.AddForce(Vector3.down * 140);
		vel = Vector3.MoveTowards(vel, Vector3.zero, 40 * Time.deltaTime);

		int layerMask = 1 << 15;
		RaycastHit hit;

		if (Physics.Raycast(transform.position, new Vector3(vel.x, 0, vel.z), out hit, (vel.magnitude + 0.5f) * Time.deltaTime, layerMask))
		{
			vel = vel.normalized; vel *= (Mathf.Clamp(hit.distance - 0.3f, 0, 100));
			transform.position += vel * Time.deltaTime;
			vel = Vector3.zero;
		}
		transform.position += vel * Time.deltaTime;
	}
}
