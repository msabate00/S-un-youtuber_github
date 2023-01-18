using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprAnim1 : MonoBehaviour
{
    private bool ostia = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (ostia)
        {
            Debug.Log("TU PUTISIMIMISMADRE");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obstaculo") || other.gameObject.CompareTag("pene"))
        {
            Debug.Log("OH VAYA");
            Comprovador.izquierda = true;
            ostia = true;
        }
    }
}