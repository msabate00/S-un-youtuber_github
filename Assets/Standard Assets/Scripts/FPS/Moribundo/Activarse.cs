using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activarse : MonoBehaviour {
    private bool mous = false;
    public float range;
    void Start () {
		
	}

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("JODER");
            mous = true;
            Raycastman.Activao = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("SHIT");
            mous = false;
            Raycastman.Activao = false;
            Raycastman.alul = false;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            if (mous)
            {
                Raycastman.alul = true;



            }
        }

    }







}
