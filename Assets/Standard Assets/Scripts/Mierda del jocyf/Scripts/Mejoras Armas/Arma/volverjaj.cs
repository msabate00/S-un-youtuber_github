using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volverjaj : MonoBehaviour {

    private Vector3 finalPosition = Vector3.zero;
    public float smooth;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition, Time.deltaTime * smooth);
    }
}
