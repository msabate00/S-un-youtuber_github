using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musica : MonoBehaviour {

	private AudioSource a;
	public static float prop = 1;
	private Coroutine uf;
	public AudioClip[] af;
	public listacans[] Canciones;
	public AudioClip[] ambiente;
	public List<int> usadas;

	public enum tipo
    {
		Menu,
		Nivel,
		Nada
    }

	public tipo tipogay = tipo.Nivel;

	void Awake()
    {

		Controlador.acabado = false;

	}

	void Start () {

		

		if (GameObject.Find("Controlador"))
		{
			Controlador.ah.GetComponent<normalizador>().ResetWapo();
		}

		if (tipogay == tipo.Menu)
        {
			Controlador.ah.gameObject.SendMessage("cambio", lol());
			StartCoroutine(aparao());
			Controlador.ah.Reseteogay();
		}
        else if (tipogay == tipo.Nivel)
        {
			/*
			Controlador.ah.gameObject.SendMessage("objetivoprop", 1);
			a = Controlador.ah.gameObject.GetComponent<AudioSource>();
			a.clip = af[0];
			a.Stop();
			a.Play();
			*/
			Controlador.ah.gameObject.GetComponent<audiosglobal>().trans = StartCoroutine(inicio());
			
        }
        else
        {

        }
	}
	
	IEnumerator aparao()
    {
		yield return null;
		yield return null;

		a = Controlador.ah.gameObject.GetComponent<AudioSource>();
		a.loop = false;

		while (true)
        {
			yield return null;
			
			if (!a.isPlaying)
			{
				yield return null;

				if (!a.isPlaying) {
					Debug.Log("SEXUAL");
					Controlador.ah.gameObject.SendMessage("cambio", lol());
					yield return new WaitForSeconds(1.5f);

				}
                
				
			}
		}
    }

	AudioClip lol()
    {
		AudioClip ult = Controlador.ah.gameObject.GetComponent<audiosglobal>().ultima;

		List<AudioClip> listagay = new List<AudioClip>();
		for (int i = 0; i < af.Length; i++)
        {
			if (af[i] == ult) { continue; }
			listagay.Add(af[i]);
        }
		if (listagay.Count == 0) { listagay.Add(ult); }

		return listagay[Random.Range(0, listagay.Count)];

    }

	public void darle(float t)
    {
		if (uf != null) { StopCoroutine(uf); }
		uf = StartCoroutine(bajosubo(t));
    }
	
	IEnumerator bajosubo(float t)
    {
		
		float timer = Time.time + t;
		float dest = 0.23f;
		float vel = 4f;
		a = Controlador.ah.gameObject.GetComponent<AudioSource>();

        while (prop > dest)
        {
			prop = Mathf.MoveTowards(prop, dest, vel * Time.deltaTime);
			a.volume = Controlador.volumenmusica * prop * audiosglobal.prop2;
			yield return null;
        }

		yield return new WaitForSeconds(timer - Time.time);

		while (prop < 1)
		{
			prop = Mathf.MoveTowards(prop, 1, vel * Time.deltaTime);
			a.volume = Controlador.volumenmusica * prop * audiosglobal.prop2;
			yield return null;
		}
	}

	public void aplicador()
    {
		audiosglobal[] gays2 = (audiosglobal[])GameObject.FindObjectsOfType(typeof(audiosglobal));
		//Controlador.ah.gameObject.SendMessage("Actulizar");
		for (int i = 0; i < gays2.Length; i++)
		{
			if (gays2 == null) { continue; }
			gays2[i].SendMessage("Actulizar");
		}
		
	}

	IEnumerator inicio()
    {
		yield return new WaitUntil(() => !Controlador.adelante);
		if (audiosglobal.prop2 < 1)
        {
			yield return new WaitUntil(() => audiosglobal.prop2 == 0);
		}
		
		//Controlador.ah.gameObject.SendMessage("objetivoprop", 1);

		AudioSource ah = Controlador.ah.gameObject.GetComponent<AudioSource>();
		ah.Stop();
		AudioClip[] lel = GameObject.Find("Musica").GetComponent<musica>().ambiente;
		AudioClip sex = lel[Random.Range(0, lel.Length)];
		ah.clip = sex;
		ah.Play();
		ah.loop = true;

		float delta1 = 0;

		while (true)
		{
			delta1 = Time.realtimeSinceStartup;

			yield return null;

			float num = Time.deltaTime;
			if (Time.timeScale == 0) { num = Time.realtimeSinceStartup - delta1; }
			audiosglobal.prop2 = Mathf.MoveTowards(audiosglobal.prop2, 1, 2f * num);
			audiosglobal.prop2 = Mathf.Clamp(audiosglobal.prop2, 0, 1);
			ah.volume = 1 * Controlador.volumenmusica * Pausa.Pa.propmus * audiosglobal.prop2;

			if (audiosglobal.prop2 == 1) { break; }
			yield return null;
			yield return null;
			yield return null;
			yield return null;
		}
	}
}
