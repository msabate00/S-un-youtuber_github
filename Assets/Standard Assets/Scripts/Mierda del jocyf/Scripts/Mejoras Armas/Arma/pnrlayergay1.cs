using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pnrlayergay1 : MonoBehaviour {

    public GameObject yo;
	void OnEnable ()
    {
        yo.layer = 12;
        foreach (Transform yo in yo.GetComponentsInChildren<Transform>(true))
        {
            yo.gameObject.layer = 13;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
