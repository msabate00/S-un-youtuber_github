using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBalaEnemiga : MonoBehaviour {

	/*

	0 = enemigo normal
	1 = shuriken
	2 = melee ninja

	*/

	public int tipo;
	private Transform original;
	[HideInInspector]
	public bool bala = false;
	[HideInInspector]
	public float velocidadgay = 0;
	private Vector3 semen = Vector3.zero;
	private Vector3 semen2 = Vector3.zero;
	public float radio;
	public Vector3 offset;
	public GameObject decall;

	void elorig (Transform o) {

		original = o;
	}
	
	public void vel(float sex)
    {
		velocidadgay = sex;
		semen = transform.TransformDirection(Vector3.forward);
		semen2 = transform.TransformDirection(offset);
	}

	void Update()
    {
		if (velocidadgay == 0 || semen == Vector3.zero) { return; }

		var layerMask = (1 << 4);
		//layerMask |= (1 << 4);
		layerMask |= (1 << 14);
		layerMask |= (1 << 15);
		//layerMask |= (1 << 22);
		RaycastHit hit;
		

		if (Physics.SphereCast(transform.position + semen2, radio, semen, out hit, velocidadgay * Time.deltaTime, layerMask))
		{
			if (bala && hit.transform.CompareTag("pene"))
			{
				if (decall != null) { Instantiate(decall, transform.position, transform.rotation); }
				Destroy(gameObject);
			}
			if (hit.transform.CompareTag("micuerpochingon"))
			{
				Controlador.vidahomosexual = Controlador.vidahomosexual - Controlador.dañoenemigogay[tipo];

				angolosahhdonde.yo.SendMessage("asignador", original);

				Controlador.ah.SendMessage("actualizarvida");

				if (decall != null) { Instantiate(decall, transform.position, transform.rotation); }

				Destroy(gameObject);
			}
			if (hit.transform.CompareTag("cristal"))
			{
				hit.transform.SendMessage("bum", hit.point);
				Destroy(gameObject);
			}
		}
			
		transform.position += semen * (velocidadgay * Time.deltaTime);
    }

	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {

		if (bala && other.CompareTag("pene"))
        {
			Destroy(gameObject);
        }

		if (other.CompareTag("micuerpochingon"))
        {
			Controlador.vidahomosexual = Controlador.vidahomosexual - Controlador.dañoenemigogay[tipo];

			angolosahhdonde.yo.SendMessage("asignador", original);

			Controlador.ah.SendMessage("actualizarvida");

			Destroy(gameObject);
		}
	}
	
	public IEnumerator desactivarcol()
    {
		yield return new WaitForSeconds(5);
		enabled = false;
    }
}
