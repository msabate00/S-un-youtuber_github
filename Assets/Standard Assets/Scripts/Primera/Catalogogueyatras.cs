using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catalogogueyatras : MonoBehaviour {

    public GameObject catalogo;
    public GameObject texto;
    public GameObject texto2;
    public GameObject texto3;
    public GameObject texto4;
    public GameObject texto5;
    public GameObject texto7;
    void Start () {
		
	}
	
	// Update is called once per frame
	void OnMouseDown () {        

        texto.SetActive(true);
        texto2.SetActive(true);
        texto3.SetActive(true);
        texto4.SetActive(true);
        texto5.SetActive(true);
        texto7.SetActive(true);
        catalogo.SetActive(false);
    }
}
