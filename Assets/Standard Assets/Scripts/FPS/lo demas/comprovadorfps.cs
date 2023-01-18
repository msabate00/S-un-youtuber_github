using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comprovadorfps : MonoBehaviour
{
    public int lao;
    public GameObject yo;
    private int contamierdas = 0;
    void Update()
    {
       // Debug.Log(contamierdas);
    }

    // Update is called once per frame
    void OnTriggerStay(Collider Other)
    {
        if (Other.tag == "pene")
        {
            if (lao == 1)
            {
                yo.GetComponent<Movedorsangre>().ar = true;
            }
            if (lao == 2)
            {
                yo.GetComponent<Movedorsangre>().ab = true;
            }
            if (lao == 3)
            {
                yo.GetComponent<Movedorsangre>().de = true;
            }
            if (lao == 4)
            {
                yo.GetComponent<Movedorsangre>().iz = true;
            }


        }

        if (Other.tag == "putasangre")
        {
            contamierdas = 0;
            if (lao == 1)
            {
                contamierdas += 1;
                yo.GetComponent<Movedorsangre>().jej = true;
            }
            if (lao == 2)
            {
                contamierdas += 1;
                yo.GetComponent<Movedorsangre>().jej = true;
            }
            if (lao == 3)
            {
                contamierdas += 1;
                yo.GetComponent<Movedorsangre>().jej = true;
            }
            if (lao == 4)
            {
                contamierdas += 1;
                yo.GetComponent<Movedorsangre>().jej = true;
            }


        }


    }
    void OnTriggerExit(Collider Other)
    {
        if (Other.tag == "pene")
        {
            if (lao == 1)
            {
                yo.GetComponent<Movedorsangre>().ar = false;
            }
            if (lao == 2)
            {
                yo.GetComponent<Movedorsangre>().ab = false;
            }
            if (lao == 3)
            {
                yo.GetComponent<Movedorsangre>().de = false;
            }
            if (lao == 4)
            {
                yo.GetComponent<Movedorsangre>().iz = false;
            }
        }

    }
}