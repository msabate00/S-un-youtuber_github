using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lel : MonoBehaviour {

    public Transform prefab;
    void OnEnable () {
        Instantiate(prefab, new Vector3(), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
