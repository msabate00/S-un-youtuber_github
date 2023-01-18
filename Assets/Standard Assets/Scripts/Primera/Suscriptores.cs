using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suscriptores : MonoBehaviour {

    public GameObject yo;
	void Start () {
		
	}

    // Update is called once per frame
    void OnEnable()
    {
        if (Controlador.Suscriptores >= 0 && Controlador.Suscriptores <= 10000)
        {
            if (Controlador.Seguidores >= 0 && Controlador.Seguidores <= 17) //25%

            {
                int polla = Random.Range(-1000, 400);
                Debug.Log(polla);
                Controlador.Suscriptores += polla;
                Controlador.Seguidores = 20;
                Controlador.Dias -= 1;
                yo.GetComponent<Suscriptores>().enabled = false;
                yo.GetComponent<ControlSubs>().enabled = true;

            }

            if (Controlador.Seguidores >= 18 && Controlador.Seguidores <= 28) 

            {
                int polla = Random.Range(50, 400);
                Debug.Log(polla);
                Controlador.Suscriptores += polla;
                Controlador.Dias -= 1;
                yo.GetComponent<Suscriptores>().enabled = false;
                yo.GetComponent<ControlSubs>().enabled = true;

            }

            if (Controlador.Seguidores >= 29 && Controlador.Seguidores <= 39)

            {
                int polla = Random.Range(400, 800);
                Debug.Log(polla);
                Controlador.Suscriptores += polla;
                Controlador.Dias -= 1;
                yo.GetComponent<Suscriptores>().enabled = false;
                yo.GetComponent<ControlSubs>().enabled = true;

            }

            if (Controlador.Seguidores >= 40 && Controlador.Seguidores <= 50)

            {
                int polla = Random.Range(700, 1200);
                Debug.Log(polla);
                Controlador.Suscriptores += polla;
                Controlador.Dias -= 1;
                yo.GetComponent<Suscriptores>().enabled = false;
                yo.GetComponent<ControlSubs>().enabled = true;

            }

            if (Controlador.Seguidores >= 51 && Controlador.Seguidores <= 61)

            {
                int polla = Random.Range(900, 1500);
                Debug.Log(polla);
                Controlador.Suscriptores += polla;
                Controlador.Dias -= 1;
                yo.GetComponent<Suscriptores>().enabled = false;
                yo.GetComponent<ControlSubs>().enabled = true;

            }
        }

        if (Controlador.Suscriptores >= 10001 && Controlador.Suscriptores <= 100000)
        {
            if (Controlador.Seguidores >= 0 && Controlador.Seguidores <= 17) //25%

            {
                int polla = Random.Range(-3000, 400);
                Debug.Log(polla);
                Controlador.Suscriptores += polla;
                Controlador.Seguidores = 20;
                Controlador.Dias -= 1;
                yo.GetComponent<Suscriptores>().enabled = false;
                yo.GetComponent<ControlSubs>().enabled = true;

            }

            if (Controlador.Seguidores >= 18 && Controlador.Seguidores <= 28)

            {
                int polla = Random.Range(200, 600);
                Debug.Log(polla);
                Controlador.Suscriptores += polla;
                Controlador.Dias -= 1;
                yo.GetComponent<Suscriptores>().enabled = false;
                yo.GetComponent<ControlSubs>().enabled = true;

            }

            if (Controlador.Seguidores >= 29 && Controlador.Seguidores <= 39)

            {
                int polla = Random.Range(400, 1400);
                Debug.Log(polla);
                Controlador.Suscriptores += polla;
                Controlador.Dias -= 1;
                yo.GetComponent<Suscriptores>().enabled = false;
                yo.GetComponent<ControlSubs>().enabled = true;

            }

            if (Controlador.Seguidores >= 40 && Controlador.Seguidores <= 50)

            {
                int polla = Random.Range(900, 2800);
                Debug.Log(polla);
                Controlador.Suscriptores += polla;
                Controlador.Dias -= 1;
                yo.GetComponent<Suscriptores>().enabled = false;
                yo.GetComponent<ControlSubs>().enabled = true;

            }

            if (Controlador.Seguidores >= 51 && Controlador.Seguidores <= 61)

            {
                int polla = Random.Range(1500, 4000);
                Debug.Log(polla);
                Controlador.Suscriptores += polla;
                Controlador.Dias -= 1;
                yo.GetComponent<Suscriptores>().enabled = false;
                yo.GetComponent<ControlSubs>().enabled = true;

            }
        }




    }
}
