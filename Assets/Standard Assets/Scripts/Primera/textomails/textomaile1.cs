using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class textomaile1 : MonoBehaviour {
    public GameObject cosa;
    public GameObject textamen;
    public GameObject textamen2;
    public GameObject textamen3;
    public TextMeshProUGUI texto;
    public TextMeshProUGUI texto2;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    void Start () {
		
	}

    // Update is called once per frame
    void OnMouseOver()
    {
        cosa.SetActive(true);
        if (Statsmails.v1 != 0)
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }
    }
    void OnMouseExit()
    {
        cosa.SetActive(false);
        if (Statsmails.v1 != 0)
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }
    void OnMouseDown () {
        if (Statsmails.v1 != 0)
        {
            texto2.text = Statsmails.z1 + ": " + Statsmails.Primero;
            textamen3.SetActive(true);
            texto.text = Statsmails.x1;
            Statsmails.v1 = 2;
            textamen.SetActive(true);
            textamen2.SetActive(true);
            
        }
     }

   



}
