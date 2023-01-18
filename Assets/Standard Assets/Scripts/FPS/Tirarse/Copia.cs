using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copia : MonoBehaviour {

    
    public static Vector3 pene;
     void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
            var target = GameObject.Find("FPC");
           Vector3 newRotation = new Vector3(target.transform.eulerAngles.x, target.transform.eulerAngles.y, target.transform.eulerAngles.z);
            this.transform.eulerAngles = newRotation;
        newRotation = pene;
        Debug.Log(pene);
    }
}
