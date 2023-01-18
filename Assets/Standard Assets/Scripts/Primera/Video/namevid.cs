using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class namevid : MonoBehaviour
{
    public InputField textamen;
    public int limite = 15;
    public static string ohdios;
    float pollas = 34529744;
    float pollas2 = 0;
    void Start()
    {
        //Changes the character limit in the main input field.
        textamen.characterLimit = limite;

    }
    void Update()
    {
        ohdios = textamen.text;
        if (ohdios == "pene")
        {
            Debug.Log("Oh dios que pornoso");
        }
    }
}