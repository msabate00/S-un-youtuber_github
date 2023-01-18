using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoverde : MonoBehaviour {

	private RenderTexture rtiz;
	private RenderTexture rtde;
	private Camera cam1;
	private Camera cam2;

	void Start () {
		rtde = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
		rtde.useMipMap = true;
		rtde.autoGenerateMips = true;
		rtde.Create();
		cam1 = transform.GetChild(3).gameObject.GetComponentInChildren<Camera>();
		cam1.targetTexture = rtde;

		rtiz = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
		rtiz.useMipMap = true;
		rtiz.autoGenerateMips = true;
		rtiz.Create();
		cam2 = transform.GetChild(4).gameObject.GetComponentInChildren<Camera>();
		cam2.targetTexture = rtiz;
	}

	// Update is called once per frame
	void Update () {
		if (transform.GetChild(0).localPosition.z < 0.6f)
        {
			transform.GetChild(1).gameObject.SetActive(true);
			transform.GetChild(3).gameObject.SetActive(true);
			transform.GetChild(2).gameObject.SetActive(false);
			transform.GetChild(4).gameObject.SetActive(false);

			transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", rtde);
		}
		if (transform.GetChild(0).localPosition.z > 15.9f)
		{
			transform.GetChild(1).gameObject.SetActive(false);
			transform.GetChild(3).gameObject.SetActive(false);
			transform.GetChild(2).gameObject.SetActive(true);
			transform.GetChild(4).gameObject.SetActive(true);

			transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", rtiz);
		}
	}
}