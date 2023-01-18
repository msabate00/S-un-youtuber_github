using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atraedor : MonoBehaviour {

	private Rigidbody rb;
	public float f;	
	public bool trigeado = false;
	private Transform target;
	public float vel;
	private bool permisogay = false;
	public Vector2 altura;
	public bool cerca = false;
	public bool detectador = false;
	public AudioClip morido;
	public bool curacion = false;
	public Vector2 id;
	public Vector2 mun;
	public int id2;
	public int mun2;
	public static bool actualizar = false;

	void Start () {

		if (trigeado) { return; }

		rb = GetComponent<Rigidbody>();
		StartCoroutine(gays());
	}
	
	IEnumerator gays()
    {
		rb.AddForce(new Vector3(Random.Range(-f, f), Random.Range(altura.x, altura.y), Random.Range(-f, f)), ForceMode.Impulse);


		yield return new WaitForSeconds(1.1f);

		permisogay = true;

		while (true)
        {
			rb.isKinematic = false;

			while (true)
			{
				yield return null;

				if (target == null)
                {
					if (GameObject.FindGameObjectWithTag("ELPLAYERJODER")) { target = GameObject.FindGameObjectWithTag("ELPLAYERJODER").transform.GetChild(0); }
					continue;
                }

				if (Vector3.Distance(transform.position, target.position) < 15) { break; }
			}

			rb.isKinematic = true;

            while (true)
            {
				yield return null;

				if (target == null)
				{
					break;
				}

				transform.position = Vector3.MoveTowards(transform.position, target.position + (Vector3.up * 2), vel * Time.deltaTime);
				if (Vector3.Distance(transform.position, target.position) > 15) { break; }
			}
		}
    }

	void OnTriggerEnter(Collider other)
    {
		if (other.CompareTag("Player")) {

			if (detectador)
            {
				GetComponentInParent<atraedor>().cerca = true;
			}
            else
            {
				GetComponentInParent<atraedor>().trigeado = true;
			}
			

		}
		
    }

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{

			if (detectador)
			{
				GetComponentInParent<atraedor>().cerca = false;
			}

		}
	}

	void Update()
    {
		if (permisogay && trigeado) {

			if (morido != null)
            {
				penisman();
				AudioSource[] penis = GameObject.FindGameObjectWithTag("Audio Sourcesgays").GetComponents<AudioSource>();
				penis[0].Stop();
				penis[0].PlayOneShot(morido);
			}
			
				
			Destroy(gameObject);

		}
    }

	void penisman()
    {
		int factor = 1;
		if (agarre2.espadahit)
        {
			factor = 4;
        }
		if (curacion)
        {
			if (Controlador.vidahomosexual == 100) { return; }

			float orig = Controlador.vidahomosexual;

			Controlador.vidahomosexual = Controlador.vidahomosexual + Random.Range(id.x, id.y);

			Controlador.vidahomosexual = Mathf.Clamp(Controlador.vidahomosexual, 0, 100);

			float dif = Controlador.vidahomosexual - orig;

			mostradorUI mierdas = GameObject.Find("VidaUI").GetComponent<mostradorUI>();

			mierdas.SendMessage("actualizar");

			mierdas.SendMessage("interfaz", dif);
		}
        else
        {
			normalizador weon = GameObject.Find("Controlador").GetComponent<normalizador>();
			DisparoSelectivo gay = GameObject.FindGameObjectWithTag("ELPLAYERJODER").GetComponentInChildren<DisparoSelectivo>();

			if (weon.listagay[Mathf.FloorToInt(id.x)].CargadoresAct == 0)
            {
				int pollas = Mathf.FloorToInt(id.x);

				GunStatus rabos = gay.Armas[pollas].GetComponent<GunStatus>();

				rabos.BalasActualesEnCargador += Mathf.FloorToInt(mun.x * factor);

				rabos.BalasActualesEnCargador = Mathf.Clamp(rabos.BalasActualesEnCargador, 0, weon.listagay[pollas].BalasAct);

				weon.listagay2[pollas].BalasAct = rabos.BalasActualesEnCargador;
			}
            else
            {
				int pollas = Mathf.FloorToInt(id.x);

				GunStatus rabos = gay.Armas[pollas].GetComponent<GunStatus>();

				rabos.CargadoresActuales += Mathf.FloorToInt(mun.x * factor);

				rabos.CargadoresActuales = Mathf.Clamp(rabos.CargadoresActuales, 0, weon.listagay[pollas].CargadoresAct + weon.listagay[pollas].BalasAct + weon.listagay[pollas].BalasActArma2 - (weon.listagay2[pollas].BalasAct + weon.listagay2[pollas].BalasActArma2));

				weon.listagay2[pollas].CargadoresAct = rabos.CargadoresActuales;
			}


			if (weon.listagay[Mathf.FloorToInt(id.y)].CargadoresAct == 0)
			{
				int pollas = Mathf.FloorToInt(id.y);

				GunStatus rabos = gay.Armas[pollas].GetComponent<GunStatus>();

				rabos.BalasActualesEnCargador += Mathf.FloorToInt(mun.y * factor);

				rabos.BalasActualesEnCargador = Mathf.Clamp(rabos.BalasActualesEnCargador, 0, weon.listagay[pollas].BalasAct);

				weon.listagay2[pollas].BalasAct = rabos.BalasActualesEnCargador;
			}
			else
			{
				int pollas = Mathf.FloorToInt(id.y);

				GunStatus rabos = gay.Armas[pollas].GetComponent<GunStatus>();

				rabos.CargadoresActuales += Mathf.FloorToInt(mun.y * factor);

				rabos.CargadoresActuales = Mathf.Clamp(rabos.CargadoresActuales, 0, weon.listagay[pollas].CargadoresAct + weon.listagay[pollas].BalasAct + weon.listagay[pollas].BalasActArma2 - (weon.listagay2[pollas].BalasAct + weon.listagay2[pollas].BalasActArma2));

				weon.listagay2[pollas].CargadoresAct = rabos.CargadoresActuales;
			}

			if (mun2 > 0)
            {
				if (weon.listagay[Mathf.FloorToInt(id2)].CargadoresAct == 0)
				{
					int pollas = Mathf.FloorToInt(id2);

					GunStatus rabos = gay.Armas[pollas].GetComponent<GunStatus>();

					rabos.BalasActualesEnCargador += Mathf.FloorToInt(mun2 * factor);

					rabos.BalasActualesEnCargador = Mathf.Clamp(rabos.BalasActualesEnCargador, 0, weon.listagay[pollas].BalasAct);

					weon.listagay2[pollas].BalasAct = rabos.BalasActualesEnCargador;
				}
				else
				{
					int pollas = Mathf.FloorToInt(id2);

					GunStatus rabos = gay.Armas[pollas].GetComponent<GunStatus>();

					rabos.CargadoresActuales += Mathf.FloorToInt(mun2 * factor);

					rabos.CargadoresActuales = Mathf.Clamp(rabos.CargadoresActuales, 0, weon.listagay[pollas].CargadoresAct + weon.listagay[pollas].BalasAct + weon.listagay[pollas].BalasActArma2 - (weon.listagay2[pollas].BalasAct + weon.listagay2[pollas].BalasActArma2));

					weon.listagay2[pollas].CargadoresAct = rabos.CargadoresActuales;
				}
			}
			

			actualizar = true;

		}

    }
}
