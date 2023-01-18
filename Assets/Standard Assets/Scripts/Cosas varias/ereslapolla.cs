using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ereslapolla : MonoBehaviour {

	public TextMeshProUGUI textamen;
	void Start () {
		textamen.text = "Enhorabuena tio eres la polla." + Controlador.dineroasegurado + "$";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
