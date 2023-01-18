using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAVID : MonoBehaviour
{

    public GameObject yo;
    public GameObject grabando;
    public GameObject out2;
    private Controlador con;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       // Texto1.text = Controlador.Video.ToString();
    }

    void OnMouseDown()
    {

        int pene = Random.Range(1, 101);
        Debug.Log(pene);
        if (pene >= Controlador.Min1 && pene <= Controlador.Max1)

        {
            Debug.Log("Dios");
            //video puta madre

            int polla = Random.Range(27, 33);
         //   Debug.Log(polla);
            Controlador.Video = polla;
            Debug.Log(Controlador.Video);
        }
        if (pene >= Controlador.Min2 && pene <= Controlador.Max2)
        {
            Debug.Log("Meh");
            int polla2 = Random.Range(15, 22);
        //    Debug.Log(polla2);
            //video meh
            Controlador.Video = polla2;
            Debug.Log(Controlador.Video);

        }
        if (pene >= Controlador.Min3 && pene <= Controlador.Max3)

        {
            Debug.Log("Puta mierda");
            int polla3 = Random.Range(1, 10);
       //     Debug.Log(polla3);
            //video mierda
            Controlador.Video = polla3;
            Debug.Log(Controlador.Video);

        }

        con = GameObject.Find("Controladora").GetComponent<Controlador>();
        con.valoracion = 0;
        for (int i = 1; i < 8; i++)
        {
            int lol = 22;
            if (con.pcselec[i] < 0)
            {
                lol = 22;
                lol = lol + i;
            }
            else
            {
                lol = con.pcselec[i];
            }
            con.valoracion = con.valoracion + con.pcafect[lol];
        }
        Controlador.Video = Controlador.Video + con.valoracion;
        Controlador.Video = Mathf.Clamp(Controlador.Video, 0, 40);
        Debug.Log(Controlador.Video);

        yo.SetActive(false);
        grabando.SetActive(true);
        out2.SetActive(false);
    }
}