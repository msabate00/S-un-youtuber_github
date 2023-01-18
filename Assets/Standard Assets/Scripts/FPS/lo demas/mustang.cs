using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mustang : MonoBehaviour {

	public float damagehomosexual = 40;
	public float stunhomosexual = 40;
	public GameObject part;

	private float velocidadgay = 0;

	void Start()
    {
		Invoke("Activa", 0.01f);
    }

	void Activa()
    {
		transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
    }

	public void vels(float sex)
	{
		velocidadgay = sex;

	}

	void Update()
	{
		if (velocidadgay == 0) { return; }

		var layerMask2 = (1 << 2);
		layerMask2 |= (1 << 4);
		layerMask2 |= (1 << 14);
		layerMask2 |= (1 << 15);
		layerMask2 |= (1 << 22);
		RaycastHit hit2;
		Vector3 semen = transform.TransformDirection(Vector3.forward);

		if (Physics.Raycast(transform.position, semen, out hit2, velocidadgay * Time.deltaTime, layerMask2))
		{
			if (hit2.transform.CompareTag("pene") || hit2.transform.CompareTag("Enemy") || hit2.transform.CompareTag("cristal") || hit2.transform.CompareTag("Blanco"))
			{
				var layerMask = (1 << 10);
				layerMask |= (1 << 25);
				layerMask |= (1 << 26);

				Collider[] colliders = Physics.OverlapSphere(transform.position, 10, layerMask);

				foreach (Collider a in colliders)
				{
					if (a.GetComponent<ManageEnemyStatus1>())
					{
						float d = Vector3.Distance(transform.position, a.transform.position);

						float damage = -16 * d + 180;
						damage = Mathf.Clamp(damage, 0, 100);
						float damageweno = damagehomosexual * damage / 100;

						Vector3 posfin = a.transform.position - (transform.position - transform.TransformDirection(Vector3.forward * 10));

						a.GetComponent<ManageEnemyStatus1>().posbala = new Vector3(posfin.x, posfin.y, posfin.z);
						a.GetComponent<ManageEnemyStatus1>().alturabala = transform.position.y - a.transform.position.y;

						//a.SendMessage("Aplicacriticks", GunStatusScript.Critico);
						a.SendMessage("AplicaDamage", damageweno);
						a.SendMessage("AplicaStun", stunhomosexual);
					}
				}
				Instantiate(part, transform.position - (transform.forward * 0.3f), transform.rotation);
				Destroy(gameObject);
			}

			if (hit2.transform.CompareTag("cristal"))
            {
				hit2.transform.SendMessage("bum", hit2.point);
            }
		}
		
			transform.position += semen * velocidadgay * Time.deltaTime;
		

	}

	void OnTriggerEnter (Collider other) {

		if (other.tag == "pene" || other.tag == "Enemy" || other.tag == "cristal" || other.tag == "Blanco")
		{
			var layerMask = (1 << 10);
			layerMask |= (1 << 25);
			layerMask |= (1 << 26);

			Collider[] colliders = Physics.OverlapSphere(transform.position, 10, layerMask);

			foreach (Collider a in colliders)
            {
				if (a.GetComponent<ManageEnemyStatus1>())
                {
					float d = Vector3.Distance(transform.position, a.transform.position);

					float damage = -16 * d + 180;
					damage = Mathf.Clamp(damage, 0, 100);
					float damageweno = damagehomosexual * damage / 100;

					Vector3 posfin = a.transform.position - (transform.position - transform.TransformDirection(Vector3.forward * 10));

					a.GetComponent<ManageEnemyStatus1>().posbala = new Vector3(posfin.x, posfin.y, posfin.z);
					a.GetComponent<ManageEnemyStatus1>().alturabala = transform.position.y - a.transform.position.y;

					//a.SendMessage("Aplicacriticks", GunStatusScript.Critico);
					a.SendMessage("AplicaDamage", damageweno);
					a.SendMessage("AplicaStun", stunhomosexual);
				}
            }
			Instantiate(part, transform.position - (transform.forward * 0.3f), transform.rotation);
			Destroy(gameObject);
		}
	}
}
