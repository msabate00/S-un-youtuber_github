using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycastman2 : MonoBehaviour {
    public static bool Activao = true;
    public static bool alul = true;
    float pulla;
    public float range;
    public GameObject yo;
    [HideInInspector]
    private string mishuevos;
    void Start () {
		
	}

     void Update()
    {
        
            lul();
        
    }


     void lul()
    {
        

            int layerMask = 1 << 8;
            layerMask = ~layerMask;
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range))

            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log(hit.transform.name);

                doit target = hit.transform.GetComponent<doit>();
                alul = false;
                if (target != null)
                {
                if (target.moribundotio)
                {
                    if (target.tipogay == "normal")
                    {
                        int pene = Random.Range(1, 3);  //RANDOM ANIMACIONES
                        Debug.Log(pene);
                        Animaciones.Animacion = pene;
                        mishuevos = "normal";
                    }
                    if (target.tipogay == "tocho")
                    {
                        int pene = 3;  //RANDOM ANIMACIONES
                        Animaciones.Animacion = pene;
                        mishuevos = "tocho";
                    }
                    if (target.tipogay == "campero")
                    {
                        int pene = Random.Range(1, 3);  //RANDOM ANIMACIONES
                        Debug.Log(pene);
                        Animaciones.Animacion = pene;
                        mishuevos = "campero";
                    }
                    Debug.Log("ENVIAO");
                    target.polla = 2;
                    target.pene = true;                    
                    yo.GetComponent<doit2>().tipomierda = mishuevos;
                    yo.GetComponent<doit2>().enabled = true;
                    alul = false;
                    Animaciones.Ahorayo = true;
                }
                }
            }
            else {
                alul = false;
                Debug.Log("ME CAGO EN LA PUTA");
                }
            

    }
    



}

