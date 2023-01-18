using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class mantengays : MonoBehaviour {

    public GameObject fondo;
    public TextMeshProUGUI texto;
    public Image circulo;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
            var layerMask = (1 << 4);
             layerMask |= (1 << 15);
            // layerMask |= (1 << 21);
            RaycastHit hit = default(RaycastHit);

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10000, layerMask))

            {
                if (hit.transform.tag == "taladro")
                {
                    hit.transform.gameObject.SendMessage("mirandopalla");
                }
            else if (hit.transform.tag == "dinero")
            {
                hit.transform.gameObject.SendMessage("mirandopalla");
            }
            else if (hit.transform.tag == "bolsa")
            {
                hit.transform.gameObject.SendMessage("mirandoputo");
            }
          
        }
        }   
}
