using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arenderizar : MonoBehaviour {

    public GameObject yo;
    public GameObject Renderizar;
    public GameObject out2;

    void Start () {
		
	}

    // Update is called once per frame
    void OnMouseDown() {

        yo.SetActive(false);
        Renderizar.SetActive(true);
        out2.SetActive(false);

    }
}
