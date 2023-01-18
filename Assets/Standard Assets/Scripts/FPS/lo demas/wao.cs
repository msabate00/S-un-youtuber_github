using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class wao : MonoBehaviour
{
    // public GameObject ShootExplo;
    public Transform yo;


   
     void Update()
    {



       // GameObject explo = Instantiate(ShootExplo, transform.position, transform.rotation) as GameObject;
        Collider[] Arround = Physics.OverlapSphere(transform.position, 15f);
        Collider[] ArroundNear = Physics.OverlapSphere(transform.position, 7f);

        foreach (Collider intoExp in ArroundNear)
        {
            if (intoExp.transform.tag == "Enemy")
            {
               //print("M'ha dao");
               

                intoExp.GetComponent<Collider>().transform.gameObject.SendMessage("Dead", yo);

                
            }

            
        }

        foreach (Collider inExp in Arround)
        {



            if (inExp.transform.tag == "Enemy")
            {

                inExp.GetComponent<Collider>().transform.gameObject.SendMessage("Explo", yo);

            }
        }

    }




    







}
