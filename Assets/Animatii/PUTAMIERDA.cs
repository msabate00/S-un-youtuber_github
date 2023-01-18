using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUTAMIERDA : MonoBehaviour {

    public Animation polla;
    public int pene;

    void OnEnable () {
        GetComponent<Animation>().Play("que te den por culo");
    }
	
	// Update is called once per frame
	void OnDisable () {
        GetComponent<Animation>().Stop("que te den por culo");
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
           
                polla["que te den por culo"].speed = 0;
                pene = 1;
            
            
        }
        if (Input.GetKey(KeyCode.B))
        {

            polla["que te den por culo"].speed = 1;
            pene = 1;


        }
    }
    
}
