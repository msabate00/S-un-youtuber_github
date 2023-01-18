using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menutrans : MonoBehaviour {

	public static bool trans = false;
	public bool menu = false;
	public menutrans anterior;
	public static menutrans actual;
	private RectTransform[] ijo;
	private List<RectTransform> ijo2 = new List<RectTransform>();
	public float espacio;
	public float offset;
	private Vector3[] cors;
	public float spid;
	public AudioClip sonidogay;
	private string poollas = "Continuar \n \n fds";
	public bool Qualitymenu = false;

	void Awake()
    {

		AudioListener.pause = false;
		Time.timeScale = 1;
		Time.fixedDeltaTime = 0.002f;

		ijo = transform.GetChild(0).GetComponentsInChildren<RectTransform>(false);
		cors = new Vector3[ijo.Length];
		for (int i = 0; i < ijo.Length; i++)
		{
			cors[i] = ijo[i].anchoredPosition3D;
			ijo2.Add(ijo[i]);
		}
		ijo2.RemoveAt(0);
	}
	
	void Start () {

		if (!menu) { return; }
		StartCoroutine(ah());

	}

	public void guardar()
    {
		Controlador.ah.guardar();
    }

	void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape)) { 
		
			if (trans) { return; }
			if (anterior == null) { return; }

			anterior.Desactivar();
			//Anterior();

		}
    }

	public void Desactivar()
    {		
		menutrans penis = actual;

		if (penis.Qualitymenu)
        {
			guardar();
		}
		penis.StopAllCoroutines();
		penis.gameObject.SetActive(false);
		gameObject.SetActive(true);

		for (int i = 0; i < ijo.Length; i++)
		{
			ijo[i].gameObject.SetActive(true);
		}

		StopAllCoroutines();
		StartCoroutine(ah());
    }



	IEnumerator ah () {

		trans = true;
		actual = this;

		for (int i = 1; i < ijo.Length; i++)
        {
			ijo[i].anchoredPosition3D = cors[i] + new Vector3((espacio * i) + offset, 0, 0);

		}
		
		int min = 0;
		while (min < ijo2.Count)
        {
			for (int i = min; i < ijo2.Count; i++)
			{
				ijo2[i].anchoredPosition3D = Vector3.MoveTowards(ijo2[i].anchoredPosition3D, cors[i +1], spid * Time.deltaTime);

				if (ijo2[min].anchoredPosition3D == cors[i +1]) { 
				
					min++;
					if (menu)
                    {
						GetComponent<AudioSource>().PlayOneShot(sonidogay);
					}
                    else if (min == ijo2.Count)
                    {
						GetComponent<AudioSource>().PlayOneShot(sonidogay);
					}
					
				
				}

			}

			yield return new WaitForEndOfFrame();
        }

		trans = false;
	}

	public void Salir()
    {
		Application.Quit();
    }

	public void CargarEscena(string escena)
    {
		Time.timeScale = 0;
		Time.fixedDeltaTime = 0;
		AudioListener.pause = true;

		Destroy(GameObject.Find("Controlador"));
		SceneManager.LoadSceneAsync(escena);
	}

	public void desactivar2()
    {
		StopAllCoroutines();
		gameObject.SetActive(false);
    }
	
	public void desactivar3()
    {
		StopAllCoroutines();
		for (int i = 0; i < ijo.Length; i++)
        {
			ijo[i].gameObject.SetActive(false);
        }
    }

	public void reactivar()
    {
		gameObject.SetActive(true);
		for (int i = 0; i < ijo.Length; i++)
		{
			ijo[i].gameObject.SetActive(true);
		}
		StartCoroutine(ah());
	}

	
}
