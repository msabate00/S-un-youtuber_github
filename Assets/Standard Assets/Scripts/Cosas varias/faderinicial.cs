using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class faderinicial : MonoBehaviour {

	public bool listo = false;
	private Coroutine uf;

	void Start () {
		uf = StartCoroutine(sex(true, false));

	}

	public void fadear()
    {
		if (uf != null) { StopCoroutine(uf); }
		uf = StartCoroutine(sex(false, true));
	}

	public void listowey()
    {
		listo = true;
    }

	IEnumerator sex(bool sexual, bool carga)
    {
		/*
		if (sexual)
        {
			Pausa.interactuable = false;

			yield return null;
			Time.timeScale = 0;
			float timersexual = Time.realtimeSinceStartup + 0.8f;
			bool putes = false;


			for (int i = 0; i < 15; i++)
			{
				if (putes)
				{
					QualitySettings.SetQualityLevel(Controlador.QualityLevel);
					Time.timeScale = 1;
				}
				else
				{
					QualitySettings.SetQualityLevel(5);
					Time.timeScale = 0;
				}

				putes = !putes;
				//yield return null;
				timersexual = Time.realtimeSinceStartup + 0.05f;
				yield return new WaitUntil(() => Time.realtimeSinceStartup > timersexual);
			}
			//yield return new WaitUntil(() => Time.realtimeSinceStartup > timersexual); //Bug iluminación pos parche de mierda
			QualitySettings.SetQualityLevel(Controlador.QualityLevel);
			Time.timeScale = 1;
			Pausa.interactuable = true;
		}
		*/

		listo = false;
		Image a = GetComponent<Image>();
		Color s = a.color;
		float alpha = 1;
		float des = 0;
		float vel = -0.5f;
		float timer = 0;
		if (!sexual) { des = 1; vel = 0.5f; alpha = s.a; }


		while (true)
        {
			timer = Time.realtimeSinceStartup;
			yield return null;
			float timer2 = Time.realtimeSinceStartup - timer;
			if (Time.timeScale > 0) { timer2 = Time.deltaTime; }
			alpha += vel * timer2;
			alpha = Mathf.Clamp(alpha, 0, 1);
			s.a = alpha;
			a.color = s;
			if (alpha == des) { break; }
        }

		if (carga) {

			yield return new WaitUntil(() => listo);

			//audiosglobal.prop2 = 1;
			Pausa.Pa.propmus = 1;
			SceneManager.LoadSceneAsync("menu");
			Controlador.ah.gameObject.GetComponent<AudioSource>().UnPause();
		}
    }

}
