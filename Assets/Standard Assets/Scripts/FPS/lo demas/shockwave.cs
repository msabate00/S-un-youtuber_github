using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shockwave : MonoBehaviour
{
    private float cdcheck = 0.8f;
    private bool dame = false;
    public int array = 8;
    public bool multiple = false;

    void Update()
    {
        cdcheck += Time.deltaTime;

        if (dame && !multiple)
        {
            dame = false;

            Controlador.vidahomosexual = Controlador.vidahomosexual - Controlador.dañoenemigogay[array];

            angolosahhdonde.yo.SendMessage("asignador", transform);

            Controlador.ah.SendMessage("actualizarvida");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("micuerpochingon") && cdcheck >= 0.7f)
        {
            if (multiple)
            {
                GetComponentInParent<swishgay>().sexo();
            }
            cdcheck = 0;
            dame = true;
        }

        
    }
}
