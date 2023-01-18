using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class vidahomogay : MonoBehaviour
{
    public string gays;
   

    // Update is called once per frame
   public void Explo(Transform granadagay)
    {
        var layerMask = (1 << 9);
        layerMask |= (1 << 21);



        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Linecast(transform.position, granadagay.position, out hit, layerMask))
        {
            if (hit.collider.tag == "Granada")
            {
                //   Debug.DrawRay(transform.position, inExp.GetComponent<Collider>().transform.position, Color.yellow);
                // inExp.GetComponent<Collider>().transform.gameObject.SendMessage("Explo");
                print(gays);
            }
        }
    }

    public void Dead(Transform granadagay)
    {

        var layerMask = (1 << 9);
        layerMask |= (1 << 21);



        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Linecast(transform.position, granadagay.position, out hit, layerMask))
        {
            if (hit.collider.tag == "Granada")
            {
                //   Debug.DrawRay(transform.position, inExp.GetComponent<Collider>().transform.position, Color.yellow);
                // inExp.GetComponent<Collider>().transform.gameObject.SendMessage("Explo");
                print(gays);
            }
        }


    }




}
