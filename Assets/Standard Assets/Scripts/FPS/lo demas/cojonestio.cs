using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cojonestio : MonoBehaviour {

    public GameObject sangre;
    public GameObject yo;
    void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {

       
        if (other.transform.tag.Contains("Enemy"))
        {
            GameObject clone;
            clone = Instantiate(sangre, yo.transform.position, yo.transform.rotation);



        

    }
}
}
