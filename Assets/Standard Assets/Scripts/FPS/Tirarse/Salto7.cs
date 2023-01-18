using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto7 : MonoBehaviour {

    public GameObject yo;
    public Animator polla;
    public Rigidbody rb;
   // public GameObject MousLuk;
    //public GameObject MousLuk2;
    //public GameObject ElOtroMousLuk;
    void OnEnable () {

        yo.GetComponent<Muevete4>().enabled = true;
        polla.Play("Se tira xd");
        Debug.Log("Pene");
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
            Time.timeScale = 1F;
            Debug.Log("Tu puta madre");
            yo.GetComponent<Muevete4>().enabled = false;
            
        }
    }


}
