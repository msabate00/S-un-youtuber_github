using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GO2 : MonoBehaviour {

    public GameObject spawn;
    public static bool Dale;
    public float pene;
    void Start () {
		
	}
	
	// Update is called once per frame
	void OnEnable () {
      //  if (Dale)
       // {
            spawn.GetComponent<Teleport4>().enabled = true;
            Debug.Log("OH wow");
            Destroy(gameObject, pene);
       // }
     }
}
