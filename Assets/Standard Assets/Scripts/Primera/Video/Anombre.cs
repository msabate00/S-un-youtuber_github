using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anombre : MonoBehaviour {
    public InputField textamen;
    public int limite = 32;
    public static string ohdios;
    public Text textaputa;
    public GameObject out2;
    public GameObject camaraman;
    public GameObject w1;
    public GameObject w2;
    public GameObject cama;

    void Start ()
    {
        textamen.characterLimit = limite;
    }
    void Update () {
        textaputa.text = ohdios; 
        ohdios = textamen.text;
        if (ohdios == "pene")
        {
            Debug.Log("Oh dios que pornoso");
        }
    }

    // Update is called once per frame
    void OnMouseDown() {

        Controlador.nombrevid = ohdios;
        quita();
    }

    void quita()
    {
        canciones.permiso = true;
        out2.SetActive(false);
        Controlador.VideoGrabao = 1;
        Controlador.amplia = 1;
        camaraman.GetComponent<Camara>().enabled = true;
        camaraman.GetComponent<Desactibaor>().enabled = false;
        w1.SetActive(true);
        w2.SetActive(false);
        cama.SetActive(true);
        Videojuegos.nota = 0;
        //      Controlador.TipoEdicion = 0;
        Debug.Log("TUPUTAMADRE");
        Debug.Log(Controlador.VideoGrabao);


    }


}
