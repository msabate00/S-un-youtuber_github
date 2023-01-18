using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Representastatas : MonoBehaviour {

    public TextMeshProUGUI texto1;
    public TextMeshProUGUI texto2;
    public TextMeshProUGUI texto3;
    public TextMeshProUGUI texto4;
    public TextMeshProUGUI texto5;

    public TextMeshProUGUI texto6;
    public TextMeshProUGUI texto7;
    public TextMeshProUGUI texto8;
    public TextMeshProUGUI texto9;
    public TextMeshProUGUI texto10;

    public TextMeshProUGUI texto11;
    public TextMeshProUGUI texto12;
    public TextMeshProUGUI texto13;
    public TextMeshProUGUI texto14;
    public TextMeshProUGUI texto15;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
        texto1.text = Stats.Primero.ToString();
        texto2.text = Stats.Segundo.ToString();
        texto3.text = Stats.Tercero.ToString();
        texto4.text = Stats.Cuarto.ToString();
        texto5.text = Stats.Quinto.ToString();
        texto6.text = Stats.d1.ToString("F2") + "$";
        texto7.text = Stats.d2.ToString("F2") + "$";
        texto8.text = Stats.d3.ToString("F2") + "$";
        texto9.text = Stats.d4.ToString("F2") + "$";
        texto10.text = Stats.d5.ToString("F2") + "$";
        texto11.text = Stats.n1;
        texto12.text = Stats.n2;
        texto13.text = Stats.n3;
        texto14.text = Stats.n4;
        texto15.text = Stats.n5;
        if (Stats.Primero == 0)
        {
            texto1.text = "";
            texto6.text = "";
            texto11.text = "";
        }
        if (Stats.Segundo == 0)
        {
            texto2.text = "";
            texto7.text = "";
            texto12.text = "";
        }
        if (Stats.Tercero == 0)
        {
            texto3.text = "";
            texto8.text = "";
            texto13.text = "";
        }
        if (Stats.Cuarto == 0)
        {
            texto4.text = "";
            texto9.text = "";
            texto14.text = "";
        }
        if (Stats.Quinto == 0)
        {
            texto5.text = "";
            texto10.text = "";
            texto15.text = "";
        }
    }
}
