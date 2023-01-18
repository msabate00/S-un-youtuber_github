using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto3 : MonoBehaviour {

    public int vel = 3;
    public GameObject yo;
    public Animator polla;
    public static bool vamos;
    public static bool tierra;
    public Rigidbody rb;
    public GameObject MousLuk;
    public GameObject MousLuk2;
    public GameObject ElOtroMousLuk;
    void Start () {

        tierra = true;
        vamos = true;
        yo.GetComponent<Muevete2>().enabled = false;
        // yo.gameObject.GetComponent<Animator>().enabled = false;
        //  generar = GameObject.Find("generar");
    }
	
	// Update is called once per frame
	void Update () {

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
                    //    yo.GetComponent<Rigidbody>().useGravity = true;
                        Debug.Log("Pene");
                        //    Time.timeScale = 0.3F;
                        //  Time.fixedDeltaTime = Time.timeScale * 0.02f;
                        // yo.GetComponent<Movimiento>().enabled = false;
                        //polla.SetTrigger("Fuck");                          
                        yo.GetComponent<Muevete2>().enabled = true;
                        polla.Play("Se tira xd");
                        tierra = false;
                    }
                }
                if (!vamos)

                {
                    Debug.Log("Lo siento tio");
                }

            }
        }

        if (Input.GetKey(KeyCode.B))
        {
            ElOtroMousLuk.GetComponent<FUCKMIERDA>().enabled = false;
        }

        if (Input.GetKey(KeyCode.V))
        {
            ElOtroMousLuk.GetComponent<FUCKMIERDA>().enabled = true;
        }


        if (Input.GetKey(KeyCode.Q))
        {
            MousLuk2.GetComponent<MouseLook>().enabled = false;
            MousLuk.GetComponent<MouseLook>().enabled = false;
            //  yo.GetComponent<Muevete2>().enabled = true;            
            Debug.Log("JODER");
         //   polla.Play("Se tira xd");
           // polla.SetTrigger("FUCK");
        }
        if (Input.GetKey(KeyCode.W))
        {
            MousLuk2.GetComponent<MouseLook>().enabled = true;
            MousLuk.GetComponent<MouseLook>().enabled = true;
            //  yo.GetComponent<Muevete2>().enabled = true;            
            Debug.Log("JODER");
            //   polla.Play("Se tira xd");
            // polla.SetTrigger("FUCK");
        }


        if (polla.GetCurrentAnimatorStateInfo(0).IsName("Se tira xd") &&
    polla.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {

            alamierda();

        }

    }

    void alamierda()
    {
        Debug.Log("OH wow");
        //yo.gameObject.GetComponent<Animator>().enabled = false;
        //  transform.eulerAngles = new Vector3(0, 0, 0);
    }

    private void OnCollisionEnter(Collision cul)
    {
        if(cul.gameObject.CompareTag("pene"))
        {
            rb.isKinematic = true;
            // polla.Play("Levanta");
            Slow.Fuckit = true;
            Time.timeScale = 1F;
            Debug.Log("Tu puta madre");
            yo.GetComponent<Muevete3>().enabled = false;
            tierra = true;
            
        }
    }


}
