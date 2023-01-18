using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto2 : MonoBehaviour {

    public int vel = 3;
    public GameObject yo;
    public Animator polla;
    public Camera pene;
    void Start () {

     //   yo.gameObject.GetComponent<Animator>().enabled = false;
        //  generar = GameObject.Find("generar");
    }
	
	// Update is called once per frame
	void Update () {
       
        if (Input.GetKeyDown(KeyCode.F))
        {
          //  yo.gameObject.GetComponent<Animator>().enabled = true;
           // polla.Play("Pruebashit");
            polla.SetTrigger("FUCK");
            Debug.Log("JODER OSTIA PUTA YA");
            Invoke ("alamierda", 2);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
           // yo.gameObject.GetComponent<Animator>().enabled = false;
            Debug.Log("CAGOENTODOJODER");
        }

        if (Input.GetKey(KeyCode.B))
        {

            polla.SetTrigger("FUCK2");
        }

    }

    void alamierda()
    {
        //  yo.gameObject.GetComponent<Animator>().enabled = false;
        //  transform.eulerAngles = new Vector3(0, 0, 0);
       
        polla.SetTrigger("FUCK");

    }



}
