using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public GameObject pene;
    public Vector3 zorra;
    public GameObject vagina;
	void Awake () {
        zorra = vagina.transform.position;	
	}
	
	// Update is called once per frame
	void OnEnable () {
        pene.transform.position = zorra;
	}



}
