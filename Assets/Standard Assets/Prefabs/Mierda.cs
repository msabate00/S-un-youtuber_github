using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mierda : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        var layerMask = (1 << 2);
        layerMask |= (1 << 14);
        layerMask |= (1 << 17);
        layerMask = ~layerMask;

        GetComponent<Camera>().fieldOfView = Controlador.fov;
    }

    // Update is called once per frame
    void Update()
    {
     //   raycastgaytaladro();
        if (transform.localEulerAngles.x >= -2 && transform.localEulerAngles.x <= 2)
        {
            GO.Dale = true;
            GO1.Dale = true;
            GO3.Dale = true;
            // Debug.Log("LOOOOL");
        }
        else
        {
            GO1.Dale = false;
            GO.Dale = false;
            GO3.Dale = false;
            //  Debug.Log("No amigo");
        }
        var layerMask = (1 << 10);
        layerMask |= (1 << 15);
        layerMask |= (1 << 21);
        RaycastHit hit = default(RaycastHit);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10000, layerMask))

        {
            ManageEnemyStatus target = hit.transform.GetComponent<ManageEnemyStatus>();
            critico target2 = hit.transform.GetComponent<critico>();
            ManageEnemyStatus1 target3 = hit.transform.GetComponent<ManageEnemyStatus1>();

            if (target != null)
            {
               // target.activao = Time.time + target.tiempodesaparace;
                target.SendMessage("tiempobarra");
            }

            if (target2 != null)
            {             
                    target2.SendMessage("tiempobarra");
            }
            if (target3 != null)
            {
                target3.SendMessage("tiempobarra");
            }

            if (hit.collider.CompareTag("Estante"))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    hit.collider.GetComponent<estante>().a(GetComponentInParent<DisparoSelectivo>());
                }
            }


        }
    }
    void raycastgaytaladro()
    {
       
        var layerMask = (1 << 4);
        // layerMask |= (1 << 15);
        // layerMask |= (1 << 21);
        RaycastHit hit = default(RaycastHit);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10000, layerMask))

        {
            if (hit.transform.tag == "taladro")
            {
                hit.transform.gameObject.SendMessage("mirandopalla");
            }
                        
        }
    }
}