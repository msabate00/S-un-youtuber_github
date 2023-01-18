using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltodef : MonoBehaviour {

    public int vel = 3;
    public GameObject yo;
    public bool vamos;
    public bool tierra;
    public Rigidbody rb;
    void Start () {

       
        
    }
	
	// Update is called once per frame
	void OnEnable () {

      
                        yo.GetComponent<Rigidbody>().useGravity = true;
                        Debug.Log("Pene");
                        yo.GetComponent<Rigidbody>().AddForce(transform.up * 700 * 3);
                        yo.GetComponent<Rigidbody>().AddForce(transform.right * 840 * 3);
                        Time.timeScale = 0.15F;
                        Time.fixedDeltaTime = Time.timeScale * 0.02f;
                       // yo.GetComponent<Movimiento>().enabled = false;
                        //tierra = false;
                    
              

        }

   

    private void OnCollisionEnter(Collision cul)
    {
        if(cul.gameObject.CompareTag("pene"))
        {
            
            Time.timeScale = 1F;
            Debug.Log("Tu puta madre");
            yo.GetComponent<Movimiento>().enabled = true;
            Slow.Fuckit = true;
           // rb.isKinematic = true;
            yo.GetComponent<Saltodef>().enabled = false;

        }
    }


}
