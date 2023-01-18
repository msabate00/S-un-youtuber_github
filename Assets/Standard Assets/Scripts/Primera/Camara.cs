using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {

    public GameObject Cam;
    public GameObject obj;
    public GameObject outt;

	void Start () {
        Cam.SetActive(true);
        obj.SetActive(false);
        outt.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Controlador.amplia == 1)
        {
            GetComponent<Animation>().Play("lol");
            obj.SetActive(false);
            outt.SetActive(false);
        }

        if (Controlador.amplia == 2)
        {
            GetComponent<Animation>().Play("lel");
            obj.SetActive(true);
            outt.SetActive(true);
        }
    }
}


