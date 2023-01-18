using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruidorletal : MonoBehaviour {

    
	
	// Update is called once per frame
	void Update () {
		if (Controlador.desrank)
        {
            Debug.Log("Se ha ido a la puta");
            Destroy(gameObject);
        }
	}
}
