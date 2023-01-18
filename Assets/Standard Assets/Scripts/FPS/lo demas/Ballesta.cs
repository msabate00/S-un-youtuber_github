using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballesta : MonoBehaviour {

	public int oh = 0;
	public Collider[] PUTAMIERDA;
	private bool para = false;
	public GameObject particulas;
	private Vector3 posgay = Vector3.zero;
	private Transform ene;

	private float velocidadgay = 0;

	void Update()
    {
		if (velocidadgay == 0) { return; }

		var layerMask2 = (1 << 2);
		layerMask2 |= (1 << 4);
		layerMask2 |= (1 << 15);
		layerMask2 |= (1 << 22);
		layerMask2 |= (1 << 26);
		RaycastHit hit2;
		Vector3 semen = transform.TransformDirection(Vector3.up);

		if (Physics.Raycast(transform.position, semen, out hit2, velocidadgay * Time.deltaTime, layerMask2))
		{
			if (!para)
			{

				if (hit2.transform.CompareTag("Enemy") || hit2.transform.CompareTag("pene") || hit2.transform.CompareTag("cristal"))
				{
					//GetComponent<Rigidbody>().isKinematic = true;
					velocidadgay = 0;
					transform.position = hit2.point;
					para = true;

					GetComponent<AudioSource>().Play();
					Invoke("pene", 1.34f);
					StartCoroutine(gaysman());
					if (hit2.transform.CompareTag("Enemy"))
					{
						Vector3 pos = transform.position;
						Quaternion rot = transform.rotation;
						transform.SetParent(hit2.transform);
						//transform.position = pos;
						//transform.rotation = rot;

						ene = hit2.transform;
						posgay = transform.position - hit2.transform.position;
					}
				}
			}
		}
        else
        {
			transform.position += semen * velocidadgay * Time.deltaTime;
		}
		
	}

	public void vels(float sex)
	{
		velocidadgay = sex;

	}

	void OnTriggerEnter (Collider other) {

		if (!para)
		{

			if (other.tag == "Enemy" || other.tag == "pene")
			{
				GetComponent<Rigidbody>().isKinematic = true;
				para = true;

				GetComponent<AudioSource>().Play();
				Invoke("pene", 1.34f);
				StartCoroutine(gaysman());
				if (other.tag == "Enemy")
				{
					Vector3 pos = transform.position;
					Quaternion rot = transform.rotation;
					transform.SetParent(other.transform);
					//transform.position = pos;
					//transform.rotation = rot;

					ene = other.transform;
					posgay = transform.position - other.transform.position;
				}
			}				
		}
	}

	IEnumerator gaysman()
    {
        Light semen = transform.GetComponentInChildren<Light>();
		semen.intensity = 0;
		while (true)
        {
			semen.intensity += 60 * Time.deltaTime;

			if (semen.intensity > 12) { semen.intensity = 0; }

			yield return null;
        }
    }
		

	void pene()
    {
		
		var layerMask = (1 << 10);

		PUTAMIERDA = Physics.OverlapSphere(transform.position, 15, layerMask);
		for (int i = 0; i < PUTAMIERDA.Length; i++)
		{
			if (PUTAMIERDA[i].GetComponent<ManageEnemyStatus1>() != null)
			{
				//PUTAMIERDA[i].GetComponent<ManageEnemyStatus1>().KillEnemy(false);
				PUTAMIERDA[i].GetComponent<ManageEnemyStatus1>().AplicaDamage5(400);
				oh++;
			}
		}

		//Invoke("a", 0.14f);
		a();
	}

	void a()
    {
		var layerMask = (1 << 26);

		PUTAMIERDA = Physics.OverlapSphere(transform.position, 15, layerMask);
		foreach (Collider hit in PUTAMIERDA)
		{

			Rigidbody rb = hit.GetComponent<Rigidbody>();
			GetComponent<MeshRenderer>().enabled = false;
			if (rb != null)
			{
				//rb.AddExplosionForce(3000, transform.position + transform.TransformDirection(Vector3.down * 2), 5, 2.0F);

				Vector3 oh = transform.position + transform.TransformDirection(Vector3.down) - rb.transform.position;
				oh.y = 0;
				oh = oh.normalized;

				rb.AddForce(-oh * 45, ForceMode.Impulse);
			}


		}
		Instantiate(particulas, transform.position, transform.rotation);
		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<Collider>().enabled = false;
		StopAllCoroutines();
		Destroy(transform.GetChild(0).gameObject);
		Destroy(gameObject, 2);
	}
	
}
