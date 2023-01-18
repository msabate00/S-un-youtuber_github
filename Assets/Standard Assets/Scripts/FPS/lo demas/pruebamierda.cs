using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebamierda : MonoBehaviour {

    public float cosa;
    public float cosa2;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MouseLook.rotationY2 = cosa;
        MouseLook.rotationX2 = cosa2;

    }
}
