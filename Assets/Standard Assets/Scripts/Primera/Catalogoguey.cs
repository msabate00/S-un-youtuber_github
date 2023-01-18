using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catalogoguey : MonoBehaviour {

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
        catalogo.SetActive(true);
        texto.SetActive(false);
        texto2.SetActive(false);
        texto3.SetActive(false);
        texto4.SetActive(false);
        texto5.SetActive(false);
        texto7.SetActive(false);
        
    }
}
