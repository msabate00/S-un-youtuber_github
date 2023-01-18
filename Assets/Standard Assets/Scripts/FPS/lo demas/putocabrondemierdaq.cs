using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putocabrondemierdaq : MonoBehaviour {

	void Start () {
		
	}

    // Update is called once per frame
    void OnTriggerStay(Collider target)
    {

            if (target.tag == "micuerpochingon")
            {
                Debug.Log("TU PUTA MADRE");

            }
        
    }
}
