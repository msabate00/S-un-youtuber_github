using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Trigger : MonoBehaviour {
    public float magnitude;
    public float roughness;
    public float fadein;
    public float fadeout;
    // Use this for initialization
    void OnEnable () {
        CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadein, fadeout);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
