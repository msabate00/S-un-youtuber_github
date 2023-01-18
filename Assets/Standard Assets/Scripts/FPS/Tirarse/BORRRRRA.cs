using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BORRRRRA : MonoBehaviour {

  //  public Collider Box;
   public CharacterController control;
    public GameObject yo;

    void Start () {
        //   Box.enabled = false;
        yo.GetComponent<CharacterMotor>().enabled = false;
        control.enabled = false;        
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
