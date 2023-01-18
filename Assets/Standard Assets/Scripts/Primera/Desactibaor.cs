using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactibaor : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Controlador.amplia == 1)
        {
            GetComponent<Animation>().Play("lol");
        }

        if (Controlador.amplia == 2)
        {
            GetComponent<Animation>().Play("lel");
        }
    }
}
