using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merotobien : MonoBehaviour {

    private Vector3 cojones;
	void Start () {
        cojones = transform.localEulerAngles;
        cojones.x = 0;
        cojones.z = 0;
        transform.localEulerAngles = cojones;
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
