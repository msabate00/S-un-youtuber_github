using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class putfield : MonoBehaviour
{
    public InputField textamen;
    public int limite = 5;
    public Text pinus;
    public Text pinus2;
    public static string ohdios;
    float pollas = 34529744;
    float pollas2 = 0;
    void Start()
    {
        pollas2 = pollas;
        pollas2 /= 1000000;
        //Changes the character limit in the main input field.
        textamen.characterLimit = limite;

    }
void Update()
    {
        pinus2.text = pollas2.ToString("#.000") + "M";
        ohdios = textamen.text;
        //Debug.Log(textamen.text);
        pinus.text = ohdios;
        if (ohdios == "pene")
        {
            Debug.Log("Oh dios que pornoso");
        }
    }
}