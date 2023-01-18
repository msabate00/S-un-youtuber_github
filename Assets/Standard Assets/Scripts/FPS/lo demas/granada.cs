using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class granada : MonoBehaviour {

    public Transform yo;
	private Rigidbody rb;
	public float amplitud;
	public float longitud;
	public float vertical;
	public float parriba = 4;
	private float vertical2;
	public GameObject Visual;
	public GameObject particulas;

	public float tiempoinv = 0.1f;
	private bool polla = true;
	public float radius = 5.0F;
	public float power = 1000.0F;
	private float tiempodemierda;
	private bool penepolla = false;

	void Start () {
		
		if (Time.timeScale == 1)
        {
			//tiempodemierda = 0.06f;
		}
        else
        {
			//tiempodemierda = 0.06f / Time.timeScale;
        }
		Invoke("ensiende", 0.14f);
		vertical2 = vertical;
		vertical2 /= 1.2f;
		float arriba = Random.Range(vertical2, vertical);
		float derecha = Random.Range(-amplitud, amplitud);
		rb = yo.gameObject.GetComponent<Rigidbody>();
		if (Time.fixedDeltaTime != 0.02)
		{
			arriba *= 0.02f / Time.fixedDeltaTime;
			derecha *= 0.02f / Time.fixedDeltaTime;
			longitud *= 0.02f / Time.fixedDeltaTime;
		}
		if (Time.timeScale != 1)
		{
			arriba /= Time.timeScale;
			derecha /= Time.timeScale;
			longitud /= Time.timeScale;
		}
		rb.AddForce(transform.up * arriba);
		rb.AddForce(transform.right * derecha);
		rb.AddForce(transform.forward * longitud);
	}

	// Update is called once per frame
	void OnTriggerEnter(Collider other) {		

		if (polla)
		{
			if (other.tag == "pene" || other.tag == "Enemy" || other.tag == "cristal" || other.tag == "Blanco")
			{
				penepolla = true;
				Visual.GetComponent<MeshRenderer>().enabled = false;
				Instantiate(particulas, transform.position, Quaternion.identity);
				yo.gameObject.GetComponent<Rigidbody>().isKinematic = true;
				Collider[] Arround = Physics.OverlapSphere(transform.position, 15.0f);
				Collider[] ArroundNear = Physics.OverlapSphere(transform.position, 7.0f);

				foreach (Collider intoExp in ArroundNear)
				{


					if (intoExp.transform.tag == "Enemy")
					{

						intoExp.GetComponent<Collider>().transform.gameObject.SendMessage("ExplosionadoMuerto", yo, SendMessageOptions.DontRequireReceiver);


					}
					if (intoExp.transform.tag == "cristal")
					{

						intoExp.GetComponent<Collider>().transform.gameObject.SendMessage("Aplicacriticks", SendMessageOptions.DontRequireReceiver);
						intoExp.transform.SendMessage("bum", transform.position);

					}
					if (intoExp.transform.tag == "micuerpochingon" || intoExp.transform.tag == "Player")
					{
						//Controlador.vidahomosexual -= 15;

					}
					if (intoExp.transform.tag == "Blanco")
					{

						intoExp.GetComponent<Collider>().transform.gameObject.SendMessage("AplicaDamage", 80);


					}


				}
				
				foreach (Collider inExp in Arround)
				{



					if (inExp.transform.tag == "Enemy")
					{

						inExp.GetComponent<Collider>().transform.gameObject.SendMessage("Explosionado", yo, SendMessageOptions.DontRequireReceiver);

					}
					if (inExp.transform.tag == "cristal")
					{

						inExp.GetComponent<Collider>().transform.gameObject.SendMessage("Aplicacriticks");


					}
					if (inExp.transform.tag == "micuerpochingon" || inExp.transform.tag == "Player")
					{
						//Controlador.vidahomosexual -= 5;

					}
					if (inExp.transform.tag == "Blanco")
					{

						inExp.GetComponent<Collider>().transform.gameObject.SendMessage("AplicaDamage", 80);


					}

				}

				Invoke("gay", tiempoinv);
				Destroy(yo.gameObject, 0.2f);
				polla = false;

			}







		}
	}

	void gay()
    {

		Visual.GetComponent<MeshRenderer>().enabled = false;
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
		foreach (Collider hit in colliders)
		{
			Rigidbody rb = hit.GetComponent<Rigidbody>();

			//power *= 0.02f / Time.fixedDeltaTime;
		//	parriba *= 0.02f / Time.fixedDeltaTime;
		if (Time.timeScale != 1)
            {
				power *= 1.04f;
			}
			power *= 1.17f;
				if (rb != null && hit.tag != ("Player"))
				rb.AddExplosionForce(power / 3, explosionPos, radius, parriba);
		}

	}

	void ensiende()
    {
		if (!penepolla)
        {
			Visual.GetComponent<MeshRenderer>().enabled = true;
		}

	}

}
