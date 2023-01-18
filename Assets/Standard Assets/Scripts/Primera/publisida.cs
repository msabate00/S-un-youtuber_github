using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class publisida : MonoBehaviour {
    public GameObject pab1;
    public GameObject pab2;

    public GameObject pub1;
    public GameObject pub2;
    public Texture2D[] texturas;

    private int com1;
    private int com2;

    private bool doit = false;

    void OnEnable () {
        doit = false;
        pab1.GetComponent<GIF>().enabled = false;
        pab2.GetComponent<GIF>().enabled = false;        
        int index = Random.Range(0, 8);
        pub1.GetComponent<RawImage>().texture = texturas[index];
        com1 = index;
        siguiente();
    }
	void siguiente()
    {
        int indexwow = Random.Range(0, 8);
        pub2.GetComponent<RawImage>().texture = texturas[indexwow];
        com2 = indexwow;


        if (com1 == com2)
        {
            siguiente();
        }
        if (com1 != com2)
        {
            doit = true;
        }
    }

    void Update()
    {
        if (doit)
        {
            if (com1 == 2)
            {
                pab1.GetComponent<GIF>().enabled = true;
            }
            if (com2 == 2)
            {
                pab2.GetComponent<GIF>().enabled = true;
            }




        }
    }


}
