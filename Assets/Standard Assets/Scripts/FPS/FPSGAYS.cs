using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FPSGAYS : MonoBehaviour {

    public TextMeshProUGUI putotexto;
    private float deltaTime;
    private float pollas;
    private float fps;
    private float fps2;

    void Awake () {
        gameObject.SetActive(Controlador.ShowFPS);
	}
	
	// Update is called once per frame
	void Update () {
       fps += (Time.unscaledDeltaTime - fps) * 0.1f;
        fps2 = 1.0f / fps;
        if (Time.time > pollas)
        {
            putosgays();
        }
    }
    void putosgays()
    {
        putotexto.text = Mathf.Round(fps2).ToString();
        pollas = Time.time + 0.5f;
        //GuardTimeCheck = Time.time + this.GuardTime;
    }
}
