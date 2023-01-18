using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Representamailes1 : MonoBehaviour {

    public TextMeshProUGUI texto;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Controlador.Mails == 0)
        {
            texto.text = "MAILS";
        }
        if (Controlador.Mails != 0)
        {
            texto.text = "MAILS (" + Controlador.Mails + ")";
        }
    }
}
