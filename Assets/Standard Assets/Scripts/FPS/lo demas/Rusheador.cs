using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rusheador : MonoBehaviour {

    public static bool aporesecerdofascista = false;
    public bool aporelgay = false;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (aporelgay)
        {
            aporesecerdofascista = true;
        }
        if (!aporelgay)
        {
            aporesecerdofascista = false;
        }
    }
}
