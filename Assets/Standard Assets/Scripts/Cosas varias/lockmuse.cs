using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class lockmuse : MonoBehaviour {

	public bool activao = false;
	private bool activao2 = false;

	void Update () {
		
		if (activao != activao2)
        {
			gay(activao);
			activao2 = activao;
        }

		gay(activao);
	}

	void gay(bool pene)
    {
		if (pene)
        {
			Cursor.lockState = CursorLockMode.Locked;
			//Cursor.lockState = CursorLockMode.Confined;
		}
        else
        {
			Cursor.lockState = CursorLockMode.None;
		}

    }
}
