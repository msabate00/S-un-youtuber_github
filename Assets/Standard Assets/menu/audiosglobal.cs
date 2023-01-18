using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiosglobal : MonoBehaviour {

	private float[] volorig;
	public bool musica = false;
	private AudioSource[] a;
	private float prop = 1;
	public bool menu = false;
	public bool menubotonesmierda = false;
	public static float prop2 = 1;
	public Coroutine trans = null;
	public Coroutine trans2 = null;
	public AudioClip ultima;

	void Start () {
	    	
		a = GetComponentsInChildren<AudioSource>();
		volorig = new float[a.Length];
		for (int i = 0; i < a.Length; i++)
        {
			volorig[i] = a[i].volume;
		}

		foreach (AudioSource e in a)
        {
			e.volume = e.volume * Controlador.volumenef;
        }
		
		if (musica)
        {
			for (int i = 0; i < a.Length; i++)
			{
				a[i].volume = volorig[i] * Controlador.volumenmusica;
			}
		}

		if (menubotonesmierda)
		{
			return;
		}

		gestor(true);
	}

	void OnEnable()
    {
		if (menubotonesmierda) { StartCoroutine(fuckyou()); }
    }

	public void Actulizar () {

		for (int i = 0; i < a.Length; i++)
		{
			a[i].volume = volorig[i] * Controlador.volumenef;
		}

		if (musica)
		{
			for (int i = 0; i < a.Length; i++)
			{
				a[i].volume = volorig[i] * Controlador.volumenmusica;
			}
		}
	}
	
	public void gestor(bool sex)
    {
		if (menu) { return; }

		//StopAllCoroutines();
		StartCoroutine(hacedor(sex));
    }

	IEnumerator hacedor(bool sex)
    {
		yield return null;
		yield return null;

		float obj = 0;
		float timer = 0;
		float timer2 = 0;
		float vel = 2;
		if (musica) { vel = 3.3f; }

		if (Pausa.Pa.obj == 1 && Pausa.Pa.prop == 1 && Pausa.Pa.propmus == 1)
		{
			yield break;
		}

		if (Pausa.Pa.obj == 0)
        {
			obj = 0;
		}
        else
        {
			obj = 1;


				for (int i = 0; i < a.Length; i++)
				{
					a[i].volume = volorig[i] * Controlador.volumenef * Pausa.Pa.prop * prop2;
				    a[i].UnPause();
			    }
				if (musica)
				{
					actgay(true);
				}
            
			
		}

		while (true)
		{
			timer = Time.realtimeSinceStartup;
			yield return null;

			timer2 = Time.realtimeSinceStartup - timer;
			prop = Mathf.MoveTowards(prop, obj, vel * timer2);
			
			if (musica)
			{
				actgay(true);
			}
            else
            {
				actgay(false);
            }
			if (Pausa.Pa.prop == Pausa.Pa.obj) { 
				
				if (Pausa.Pa.obj == 0)
                {
					for (int i = 0; i < a.Length; i++)
					{
						a[i].Pause();
					}
				}
				if (Pausa.Pa.obj == 0) { continue; }
				break; 	
			}
			
		}

	}

	void actgay(bool musicagay)
    {
		if (musicagay)
        {
			for (int i = 0; i < a.Length; i++)
			{
				a[i].volume = volorig[i] * Controlador.volumenmusica * Pausa.Pa.propmus * prop2;
			}
		}
        else
        {
			for (int i = 0; i < a.Length; i++)
			{
				if (a[i] == null) { continue; }
				a[i].volume = volorig[i] * Controlador.volumenef * Pausa.Pa.prop;
			}
		}
    }

	public void objetivoprop(float sex)
    {
		if (trans != null) { StopCoroutine(trans); trans = null; }
		trans = StartCoroutine(pinchesputos(sex));
	}

	IEnumerator pinchesputos(float sex)
    {
		float delta1 = 0;
		yield return null;

        while (true)
        {
			delta1 = Time.realtimeSinceStartup;
			yield return null;

			float num = Time.deltaTime;
			if (Time.timeScale == 0) { num = Time.realtimeSinceStartup - delta1; }
			prop2 = Mathf.MoveTowards(prop2, sex, num);
			prop2 = Mathf.Clamp(prop2, 0, 1);
			actgay(true);

			if (prop2 == sex) { break; }
		}
    }

	public void cambio(AudioClip sex)
    {

		if (trans != null) { StopCoroutine(trans); trans = null; }
		StopAllCoroutines();
		trans = StartCoroutine(cambiogay(sex, 2, 1));
	}
	public void rular(AudioClip sex, float vel, float obj)
	{

		if (trans != null) { StopCoroutine(trans); trans = null; }
		trans = StartCoroutine(cambiogay(sex, vel, obj));
	}

	IEnumerator cambiogay(AudioClip sex, float vel, float obj)
    {
		float delta1 = 0;
		AudioSource a = GetComponent<AudioSource>();
		yield return null;
		while (true)
		{
			if (a.clip == null) { break; }

			delta1 = Time.realtimeSinceStartup;
			yield return null;

			float num = Time.deltaTime;
			if (Time.timeScale == 0) { num = Time.realtimeSinceStartup - delta1; }
			prop2 = Mathf.MoveTowards(prop2, 0, vel * num);
			prop2 = Mathf.Clamp(prop2, 0, 1);
			//actgay(true);
			a.volume = 1 * Controlador.volumenmusica * prop2;

			if (prop2 == 0) { break; }
		}
		float sexuales = 1;
		if (a.clip == null) { sexuales = 0; }

		yield return new WaitForSeconds(sexuales);


		a.Stop();
		a.clip = sex;
		ultima = sex;
		a.Play();
		while (true)
		{
			delta1 = Time.realtimeSinceStartup;
			yield return null;

			float num = Time.deltaTime;
			if (Time.timeScale == 0) { num = Time.realtimeSinceStartup - delta1; }
			prop2 = Mathf.MoveTowards(prop2, obj, vel * num);
			prop2 = Mathf.Clamp(prop2, 0, 1);
			//actgay(true);
			a.volume = 1 * Controlador.volumenmusica * prop2;

			if (prop2 == obj) { break; }
		}
	}

	IEnumerator fuckyou()
    {
        while (true)
        {
			for (int i = 0; i < a.Length; i++)
			{
				a[i].volume = volorig[i] * Controlador.volumenef;
			}
			yield return null;
		}
    }

	public int adar() {

		musica mus = GameObject.Find("Musica").GetComponent<musica>();

		int num = mus.Canciones.Length -1;
		List<int> numeros = new List<int>();
		for (int i = 0; i < num; i++)
		{
			bool sigan = true;
			for (int a = 0; a < mus.usadas.Count; a++)
			{
				if (i == mus.usadas[a]) { sigan = false; break; }
			}

			if (!sigan) { continue; }
			numeros.Add(i);
		}

		int elegido = -1;
		if (numeros.Count > 0)
		{
			elegido = numeros[Random.Range(0, numeros.Count)];
			mus.usadas.Add(elegido);
		}

		return elegido;
	}

	public void parartodas()
    {
		StopAllCoroutines();
    }

	public IEnumerator transwapa()
    {
		if (trans != null)
		{
			StopCoroutine(trans);
		}
						
		float delta1 = 0;
		AudioSource ah = GetComponent<AudioSource>();
		yield return null;

		while (true)
		{
			delta1 = Time.realtimeSinceStartup;
			yield return null;

			float num = Time.deltaTime;
			if (Time.timeScale == 0) { num = Time.realtimeSinceStartup - delta1; }
			//prop2 = Mathf.MoveTowards(prop2, 0, 0.035f * num);
			prop2 -= 0.4f * num;
			prop2 = Mathf.Clamp(prop2, 0, 1);
			for (int i = 0; i < a.Length; i++)
			{
				a[i].volume = volorig[i] * Controlador.volumenmusica * prop2;
			}

			if (prop2 == 0) { break; }

		}

		yield return new WaitUntil(() => GameObject.Find("Musica") != null);

		Controlador.adelante = false;
		if (GameObject.Find("TransicionGay"))
        {
			GameObject.Find("TransicionGay").transform.GetChild(0).SendMessage("listowey");
        }
		//FOLLAME		
	}

	public void darle(float t)
	{		
		if (trans2 != null) { StopCoroutine(trans2); }
		trans2 = StartCoroutine(bajosubo(t));
	}

	IEnumerator bajosubo(float t)
	{

		float timer = Time.time + t;
		float dest = 0.47f;
		float vel = 4f;
		AudioSource a = Controlador.ah.gameObject.GetComponent<AudioSource>();

		while (prop2 > dest)
		{
			prop2 = Mathf.MoveTowards(prop2, dest, vel * Time.deltaTime);
			a.volume = Controlador.volumenmusica * prop2;
			yield return null;
		}

		yield return new WaitForSeconds(timer - Time.time);

		while (prop2 < 1)
		{
			prop2 = Mathf.MoveTowards(prop2, 1, vel * Time.deltaTime);
			a.volume = Controlador.volumenmusica * prop2;
			yield return null;
		}
	}

}
