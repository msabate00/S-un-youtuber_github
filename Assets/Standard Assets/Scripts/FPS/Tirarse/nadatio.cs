using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nadatio : MonoBehaviour {

    public Camera Camera;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.V))
        {
             transform.eulerAngles = new Vector3(0, 100, 0);
           // transform.RotateAround(transform.position, Vector3.up, 5);
            Debug.Log("JODERPUTAMIERDA");
        }
    }
}
