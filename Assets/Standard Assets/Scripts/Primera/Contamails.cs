using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contamails : MonoBehaviour {

    int polla = 0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnEnable () {
        Debug.Log("EY VONES A TOTS EKI EN GUILIRECS COMENTANT");
        polla = 0;
        ostia();
    }
    void ostia()
    {

        if (Statsmails.v1 == 1)
        {
            polla += 1;
        }
        if (Statsmails.v2 == 1)
        {
            polla += 1;
        }
        if (Statsmails.v3 == 1)
        {
            polla += 1;
        }
        if (Statsmails.v4 == 1)
        {
            polla += 1;
        }
        if (Statsmails.v5 == 1)
        {
            polla += 1;
        }
        if (Statsmails.v6 == 1)
        {
            polla += 1;
        }
        if (Statsmails.v7 == 1)
        {
            polla += 1;
        }
        if (Statsmails.v8 == 1)
        {
            polla += 1;
        }
        if (Statsmails.v9 == 1)
        {
            polla += 1;
        }
        if (Statsmails.v10 == 1)
        {
            polla += 1;
        }
        if (Statsmails.v11 == 1)
        {
            polla += 1;
        }
        if (Statsmails.v12 == 1)
        {
            polla += 1;
        }
        if (Statsmails.v13 == 1)
        {
            polla += 1;
        }
        if (Statsmails.v14 == 1)
        {
            polla += 1;
        }
        if (Statsmails.v15 == 1)
        {
            polla += 1;
        }
        if (Statsmails.v16 == 1)
        {
            polla += 1;
        }
        if (Statsmails.v17 == 1)
        {
            polla += 1;
        }
        if (Statsmails.v18 == 1)
        {
            polla += 1;
        }
        if (Statsmails.v19 == 1)
        {
            polla += 1;
        }
        if (Statsmails.v20 == 1)
        {
            polla += 1;
        }

        Controlador.Mails = polla;
        Debug.Log(Controlador.Mails);








    }



}
