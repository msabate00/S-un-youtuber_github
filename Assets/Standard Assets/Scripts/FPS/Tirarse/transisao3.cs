using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transisao3 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerStay(Collider polla)
    {
        if (polla.gameObject.tag == "pene" && polla.gameObject.layer == 15)

        {
          //  Debug.Log("INVICTO");
            Salto.tierra = true;
        }

    }
    void OnTriggerExit(Collider polla)
    {
        if (polla.gameObject.tag == "pene" && polla.gameObject.layer == 15)

        {
         //   Debug.Log("UN VERDADERO MACHO ALFA SOLO DESCANSA CUANDO MUERE, MIRAD AL SOL");
            Salto.tierra = false;
        }
    }


}