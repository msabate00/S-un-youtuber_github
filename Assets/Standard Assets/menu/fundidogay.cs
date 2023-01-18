using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fundidogay : MonoBehaviour {

	private Image a;
	Coroutine sex = null;
	Coroutine sex2 = null;

	void Awake () {
		sex = StartCoroutine(uh());
	}
	

	// Update is called once per frame
	IEnumerator uh() {

		a = GetComponent<Image>();
		a.color = Color.black;
		yield return new WaitForEndOfFrame();

		while (true)
        {
			a.color = Vector4.MoveTowards(a.color, new Vector4(a.color.r, a.color.g, a.color.b, 0), 2 * Time.deltaTime);
			if (a.color.a == 0) { yield break; }
			yield return new WaitForEndOfFrame();

        }
		
	}

	public void cargar()
	{

		if (sex != null) { StopCoroutine(sex); }
		if (sex2 != null) { return; }
		sex2 = StartCoroutine(uh2());
	}

	IEnumerator uh2()
	{

		a = GetComponent<Image>();
		Color uf = a.color;
		yield return new WaitForEndOfFrame();

		while (true)
		{
			uf.a = Mathf.MoveTowards(uf.a, 1, 0.5f * Time.deltaTime);
			a.color = uf;
			if (uf.a == 1) { break; }
			yield return new WaitForEndOfFrame();

		}

		yield return new WaitForSeconds(1);
		SceneManager.LoadSceneAsync("carga");
	}
}
