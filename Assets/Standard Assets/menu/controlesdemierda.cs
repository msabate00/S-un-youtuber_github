using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlesdemierda : MonoBehaviour {

	private Vector3 origtodo;

	IEnumerator transicionwapa()
	{
		RectTransform penis = GetComponent<RectTransform>();
		penis.anchoredPosition3D = origtodo + new Vector3(-1900, 0, 0);

		while (true)
		{
			penis.anchoredPosition3D = Vector3.MoveTowards(penis.anchoredPosition3D, origtodo, 7000 * Time.deltaTime);
			if (penis.anchoredPosition3D == origtodo) { break; }

			yield return new WaitForEndOfFrame();
		}
	}
	
	void Awake()
	{
		origtodo = GetComponent<RectTransform>().anchoredPosition3D;
	}

	public void aparecer()
	{
		menutrans.trans = true;
		menutrans.actual.desactivar3();
	
		gameObject.SetActive(true);	

		StopAllCoroutines();
		StartCoroutine(transicionwapa());
	}

	public void quitar()
	{
		//GetComponentInParent<AudioSource>().PlayOneShot(fua);
		if (menutrans.actual == null) { return; }
		menutrans.trans = false;
		menutrans.actual.reactivar();
		StopAllCoroutines();
		gameObject.SetActive(false);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) { quitar(); }
	}
}
