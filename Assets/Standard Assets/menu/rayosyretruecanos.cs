using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayosyretruecanos : MonoBehaviour {

	private float ah;
	public Light lus;
	public float fader;
	public float antifader;
	public float parpadeo;
	public Vector2 c1R;
	public Vector2 c2R;
	public Vector2 intrand;
	public AudioClip[] a;
	private int last;
	private AudioSource tetas;
	private AudioSource[] tetas2;
	private float[] orig;

	void Start () {

		tetas = GetComponent<AudioSource>();
		tetas2 = GetComponentsInChildren<AudioSource>();
		orig = new float[tetas2.Length];

		for (int i = 0; i < orig.Length; i++)
        {
			orig[i] = tetas2[i].volume;
        }

		StartCoroutine(oh());
		StartCoroutine(volumenmierda());
	}

	

	IEnumerator volumenmierda()
    {
        while (true)
        {
			for (int i = 0; i < orig.Length; i++)
			{
				tetas2[i].volume = orig[i] * Controlador.volumenef;
				yield return null;
			}
		}
		
	}
	
	IEnumerator lerpeador()
    {
        while (true)
        {
			lus.intensity = Mathf.MoveTowards(lus.intensity, ah, antifader * Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}
    }


	IEnumerator oh()
    {
		last = 69;
		lus.intensity = 0;
		Coroutine follar = null;
		List<int> gay = new List<int>();

		while (true)
        {
			
			float c1 = Time.time + Random.Range(c1R.x, c1R.y);
			StopCoroutine("lerpeador");

			while (Time.time < c1)
            {
				lus.intensity = Mathf.MoveTowards(lus.intensity , 0, fader * Time.deltaTime);
				yield return new WaitForEndOfFrame();
			}

			gay.Clear();
			for (int i = 0; i <a.Length; i++)
            {
				gay.Add(i);
				if (i == last) { gay.Remove(last); }
            }

			last = gay[Random.Range(0, gay.Count)];
			c1 = Time.time + Random.Range(c2R.x, c2R.y);
			lus.intensity = Random.Range(intrand.x, intrand.y);
			follar = StartCoroutine(lerpeador());
			tetas.PlayOneShot(a[last]);

			while (Time.time < c1)
			{
				yield return new WaitForEndOfFrame();
				yield return new WaitForSeconds(parpadeo);
				ah = Random.Range(intrand.x, intrand.y);
						
			}
			StopCoroutine(follar);

		}
    }
}
