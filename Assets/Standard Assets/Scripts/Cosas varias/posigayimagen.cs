using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class posigayimagen : MonoBehaviour {

	public RectTransform elgay;
	public RectTransform aseguir;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		elgay.localPosition = aseguir.localPosition;
	}
}
