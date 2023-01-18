using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class configuracion3 : MonoBehaviour {
    public GameObject yo;
    public GameObject yo2;
    public GameObject yo3;
    public GameObject yo4;
    public GameObject rnk;
    public GameObject prefab;
    public GameObject yo5;
    public GameObject yo7;

    public Transform pollasitio;
    void Start () {
		
	}
	
	// Update is called once per frame
	void OnMouseDown () {

        Controlador.desrank = false;
        Instantiate(prefab, pollasitio.transform.position, Quaternion.identity);
        //rnk.SetActive(true);
        yo.SetActive(false);
        yo2.SetActive(false);
        yo3.SetActive(true);
        yo4.SetActive(true);
        yo5.SetActive(false);
        yo7.SetActive(false);
    }
}








