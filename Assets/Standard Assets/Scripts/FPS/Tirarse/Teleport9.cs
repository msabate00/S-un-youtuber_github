using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport9 : MonoBehaviour {

    //public GameObject pene;
    //public Vector3 zorra;
   // public GameObject vagina;
    public GameObject FPC;
    public GameObject Sitio;
    public float tiempo;
    public GameObject camaragay;
    private Vector3 zorrilla;
    void Awake () {
      //  zorra = vagina.transform.position;
    }
	
	// Update is called once per frame
	void OnEnable () {
        //    pene.transform.position = zorra;
       // zorrilla.z += 0.0843f;
       // zorrilla.x -= 0.055f;
        camaragay.GetComponent<AudioListener>().enabled = false;
        FPC = Instantiate(FPC, Sitio.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        FPC.transform.position += zorrilla;
        //  Destroy(transform.parent.gameObject, tiempo);
    }



}
