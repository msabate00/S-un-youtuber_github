using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interes : MonoBehaviour {

    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;
    public GameObject c5;
    public GameObject q1;
    public GameObject q2;
    public GameObject q3;
    public GameObject q4;
    public GameObject q5;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Videojuegos.juegoselecint == 0)
        {
            c1.SetActive(false);
            c2.SetActive(false);
            c3.SetActive(false);
            c4.SetActive(false);
            c5.SetActive(false);

        }
        if (Videojuegos.juegoselecint == 1)
        {
            c1.SetActive(true);
            c2.SetActive(false);
            c3.SetActive(false);
            c4.SetActive(false);
            c5.SetActive(false);

        }
        if (Videojuegos.juegoselecint == 2)
        {
            c1.SetActive(true);
            c2.SetActive(true);
            c3.SetActive(false);
            c4.SetActive(false);
            c5.SetActive(false);

        }
        if (Videojuegos.juegoselecint == 3)
        {
            c1.SetActive(true);
            c2.SetActive(true);
            c3.SetActive(true);
            c4.SetActive(false);
            c5.SetActive(false);

        }
        if (Videojuegos.juegoselecint == 4)
        {
            c1.SetActive(true);
            c2.SetActive(true);
            c3.SetActive(true);
            c4.SetActive(true);
            c5.SetActive(false);

        }
        if (Videojuegos.juegoselecint == 5)
        {
            c1.SetActive(true);
            c2.SetActive(true);
            c3.SetActive(true);
            c4.SetActive(true);
            c5.SetActive(true);

        }
        if (Videojuegos.juegoselecintmax == 0)
        {
            q1.SetActive(false);
            q2.SetActive(false);
            q3.SetActive(false);
            q4.SetActive(false);
            q5.SetActive(false);

        }
        if (Videojuegos.juegoselecintmax == 1)
        {
            q1.SetActive(true);
            q2.SetActive(false);
            q3.SetActive(false);
            q4.SetActive(false);
            q5.SetActive(false);

        }
        if (Videojuegos.juegoselecintmax == 2)
        {
            q1.SetActive(true);
            q2.SetActive(true);
            q3.SetActive(false);
            q4.SetActive(false);
            q5.SetActive(false);

        }
        if (Videojuegos.juegoselecintmax == 3)
        {
            q1.SetActive(true);
            q2.SetActive(true);
            q3.SetActive(true);
            q4.SetActive(false);
            q5.SetActive(false);

        }
        if (Videojuegos.juegoselecintmax == 4)
        {
            q1.SetActive(true);
            q2.SetActive(true);
            q3.SetActive(true);
            q4.SetActive(true);
            q5.SetActive(false);

        }
        if (Videojuegos.juegoselecintmax == 5)
        {
            q1.SetActive(true);
            q2.SetActive(true);
            q3.SetActive(true);
            q4.SetActive(true);
            q5.SetActive(true);

        }
    }
}
