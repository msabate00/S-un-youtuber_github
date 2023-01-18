using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport3 : MonoBehaviour {

    //public GameObject pene;
    //public Vector3 zorra;
   // public GameObject vagina;
    public GameObject Animacion;
    public GameObject Sitio;
    void Awake () {
      //  zorra = vagina.transform.position;
    }
	
	// Update is called once per frame
	void OnEnable () {
        //    pene.transform.position = zorra;
        Animacion = Instantiate(Animacion, Sitio.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
   //     Destroy(transform.parent.gameObject);
    }



}
