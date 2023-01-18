using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movedorlista : MonoBehaviour {

	public RectTransform puto;
	private Vector2 pos;
	public Slider putoslider;

	void Start () {
		puto = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {

		putoslider.value += entrada();

		pos = puto.anchoredPosition;
		float lol = putoslider.value;

		lol = lol * 2242;
		pos.y = lol;
		puto.anchoredPosition = pos;
		
	}

	float entrada()
    {
		float valorputo = 0.015f;
		if (Mathf.Abs(Input.GetAxis("Vertical")) > 0) { return -Input.GetAxis("Vertical") * valorputo; }
		if (Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")) > 0) { return -Input.GetAxis("Mouse ScrollWheel") * 0.25f; }
		return 0;

	}
}
