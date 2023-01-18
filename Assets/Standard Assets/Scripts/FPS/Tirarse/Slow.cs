using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{

    public int vel = 3;
    public GameObject yo;
    public Animator polla;
    public bool vamos;
    public bool tierra;
    public static bool Fuckit;
    void Start()
    {
        tierra = true;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            vamos = false;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            vamos = true;
        }


        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (tierra)
                {

                    if (vamos)
                    {
                        polla.SetTrigger("FUCK");
                        Debug.Log("Pene");                       
                        yo.GetComponent<Movimiento>().enabled = false;
                        
                    }
                }
                if (!vamos)

                {
                    Debug.Log("Lo siento tio");
                }

            }
        }

        if (Fuckit)
        {
            polla.SetTrigger("FUCK2");
            Debug.Log("Ha salio vien");
            Fuckit = false;
        }

    }

   

}
