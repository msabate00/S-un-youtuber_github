using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacionpc : MonoBehaviour {

	public int idles;
	private Animator aiAnimation;
	public bool wao = false;

	void Start () {

		aiAnimation = gameObject.GetComponent<Animator>();
		if (idles == 1)
        {
			aiAnimation.SetTrigger("idle1");
		}
		if (idles == 2)
		{
			aiAnimation.SetTrigger("idle2");
		}
		if (idles == 3)
		{
			aiAnimation.SetTrigger("idle3");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (wao)
        {
			Controlador.detectao = true;
		}
		if (Controlador.detectao == true)
        {
			aiAnimation.SetTrigger("palsuelo");
		}
	}
}
