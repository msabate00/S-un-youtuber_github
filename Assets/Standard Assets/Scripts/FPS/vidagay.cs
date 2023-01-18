using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;

public class vidagay : MonoBehaviour {

    public TextMeshProUGUI putotexto;
    public bool mostrarvida;
    private float deltaTime;
    private float pollas;
    private float fps;
    private float fps2;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
        if (mostrarvida)
        {
            fps = Controlador.vidahomosexual;
            fps = Mathf.Clamp(fps, 0, 100);
            putotexto.text = fps.ToString("F0") + "+";
        }
        if (!mostrarvida)
        {
            putotexto.text = Controlador.usos.ToString("F0");
        }
    }
   
}
