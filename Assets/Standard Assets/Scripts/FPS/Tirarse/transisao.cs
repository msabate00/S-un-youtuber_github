using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transisao : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider polla)
    {
        if (polla.gameObject.tag == "pene")

        {
            Debug.Log("YO ME COMO EL FUET CON PLASTICO");
            Controlador.transition = true;
        }
        
    }
    void OnTriggerExit(Collider polla)
    {
        if (polla.gameObject.tag == "pene")

        {
            Debug.Log("TU TE COMES EL FUET CON PIEL");
            Controlador.transition = false;
        }
    }


}