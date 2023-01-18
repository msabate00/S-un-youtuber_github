using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Irrelevante : MonoBehaviour {

    public Animator polla;
    public GameObject yo;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.P))
        {
            yo.GetComponent<lukat>().enabled = true;
            polla.SetTrigger("FUCK");
        }
    }
}
