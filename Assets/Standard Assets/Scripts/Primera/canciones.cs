using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class canciones : MonoBehaviour
{
    public TextMeshProUGUI texto1;
    public TextMeshProUGUI texto2;

    public AudioSource polla;
    public AudioClip pollita1;
    public AudioClip pollita2;
    public AudioClip pollita3;
    public AudioClip pollita4;
    public AudioClip pollita5;
    public AudioClip pollita6;
    public AudioClip pollita7;
    public AudioClip pollita8;
    public AudioClip pollita9;
    public AudioClip pollita10;
    public AudioClip pollita11;
    public AudioClip pollita12;
    public AudioClip pollita13;
    public AudioClip pollita14;
    public AudioClip pollita15;
    public AudioClip pollita16;
    public AudioClip pollita17;
    public AudioClip pollita18;
    public AudioClip pollita19;
    public AudioClip pollita20;
    public AudioClip pollita21;
    public AudioClip pollita22;
    public AudioClip pollita23;

    private int ultima;
    private int ultima2;
    private int ultima3;
    private int ultima4;
    private int ultima5;
    private int ultima6;
    private int ultima7;

    public static bool permiso = true;

    public static bool c1 = true;
    public static bool c2 = true;
    public static bool c3 = true;
    public static bool c4 = true;
    public static bool c5 = true;
    public static bool c6 = true;
    public static bool c7 = true;
    public static bool c8 = true;
    public static bool c9 = true;
    public static bool c10 = true;
    public static bool c11 = true;
    public static bool c12 = true;
    public static bool c13 = true;
    public static bool c14 = true;
    public static bool c15 = true;
    public static bool c16 = true;
    public static bool c17 = true;
    public static bool c18 = true;
    public static bool c19 = true;
    public static bool c20 = true;
    public static bool c21 = true;
    public static bool c22 = true;
    public static bool c23 = true;

    private float contar = 0;
    private float gaysportoaspartes = 0.5f;
    void OnEnable()
    {
        OMG();
    }

    void Update()
    {
        //  Debug.Log(ultima);
        if (!polla.isPlaying)
        {
            contar += Time.deltaTime;
            if (contar > gaysportoaspartes)
            { 
            OMG();
            }

        }
        
            if (Input.GetKeyDown("space"))
        {
            if (permiso)
            {
                OMG();
            }
            }
        if (ultima == 1)
        {
            if (!c1)
            {
                OMG();
            }
        }
        if (ultima == 2)
        {
            if (!c2)
            {
                OMG();
            }
        }
        if (ultima == 3)
        {
            if (!c3)
            {
                OMG();
            }
        }
        if (ultima == 4)
        {
            if (!c4)
            {
                OMG();
            }
        }
        if (ultima == 5)
        {
            if (!c5)
            {
                OMG();
            }
        }
        if (ultima == 6)
        {
            if (!c6)
            {
                OMG();
            }
        }
        if (ultima == 7)
        {
            if (!c7)
            {
                OMG();
            }
        }
        if (ultima == 8)
        {
            if (!c8)
            {
                OMG();
            }
        }
        if (ultima == 9)
        {
            if (!c9)
            {
                OMG();
            }
        }
        if (ultima == 10)
        {
            if (!c10)
            {
                OMG();
            }
        }
        if (ultima == 11)
        {
            if (!c11)
            {
                OMG();
            }
        }
        if (ultima == 12)
        {
            if (!c12)
            {
                OMG();
            }
        }
        if (ultima == 13)
        {
            if (!c13)
            {
                OMG();
            }
        }
        if (ultima == 14)
        {
            if (!c14)
            {
                OMG();
            }
        }
        if (ultima == 15)
        {
            if (!c15)
            {
                OMG();
            }
        }
        if (ultima == 16)
        {
            if (!c16)
            {
                OMG();
            }
        }
        if (ultima == 17)
        {
            if (!c17)
            {
                OMG();
            }
        }
        if (ultima == 18)
        {
            if (!c18)
            {
                OMG();
            }
        }
        if (ultima == 19)
        {
            if (!c19)
            {
                OMG();
            }
        }
        if (ultima == 20)
        {
            if (!c20)
            {
                OMG();
            }
        }
        if (ultima == 21)
        {
            if (!c21)
            {
                OMG();
            }
        }
        if (ultima == 22)
        {
            if (!c22)
            {
                OMG();
            }
        }
        if (ultima == 23)
        {
            if (!c23)
            {
                OMG();
            }
        }












    }

   public void seleccion(int numgay)
    {
        ultima = numgay;
        Dalewey();
    }
    void OMG()
    {
        
        polla.Stop();
        int tusmuertos = Random.Range(1, 24);

        while(tusmuertos == ultima || tusmuertos == ultima2 || tusmuertos == ultima3 || tusmuertos == ultima4 || tusmuertos == ultima5 || tusmuertos == ultima6 || tusmuertos == ultima7)
        {
            tusmuertos = Random.Range(1, 24);
        }

        if (tusmuertos != ultima && tusmuertos != ultima2 && tusmuertos != ultima3 && tusmuertos != ultima4 && tusmuertos != ultima5 && tusmuertos != ultima6 && tusmuertos != ultima7)
        {
            ultima7 = ultima6;
            ultima6 = ultima5;
            ultima5 = ultima4;
            ultima4 = ultima3;
            ultima3 = ultima2;
            ultima2 = ultima;
            ultima = tusmuertos;
            Dalewey();
        }
    }

    // Update is called once per frame
    void Dalewey()
    {
        
        GetComponent<Animation>().Stop("Canciones");
        GetComponent<Animation>().Play("Canciones");
        if (ultima == 1)
        {
            if (c1)
            {
                contar = 0;
                texto1.text = "Fall";
                texto2.text = "Eminem";
                polla.clip = pollita1;
                polla.Play();
            }
        }

        if (ultima == 2)
        {
            if (c2)
            {
                contar = 0;
                texto1.text = "Mockingbird";
                texto2.text = "Eminem";
                polla.clip = pollita2;
                polla.Play();
            }
        }
        if (ultima == 3)
        {
            if (c3)
            {
                contar = 0;
                texto1.text = "Lose Yourself";
                texto2.text = "Eminem";
                polla.clip = pollita3;
                polla.Play();
            }
        }
        if (ultima == 4)
        {
            if (c4)
            {
                contar = 0;
                texto1.text = "Not Afraid";
                texto2.text = "Eminem";
                polla.clip = pollita4;
                polla.Play();
            }
        }
        if (ultima == 5)
        {
            if (c5)
            {
                contar = 0;
                texto1.text = "When I'm Gone";
                texto2.text = "Eminem";
                polla.clip = pollita5;
                polla.Play();
            }
        }
        if (ultima == 6)
        {
            if (c6)
            {
                contar = 0;
                texto1.text = "The Real Slim Shady";
                texto2.text = "Eminem";
                polla.clip = pollita6;
                polla.Play();
            }
        }
        if (ultima == 7)
        {
            if (c7)
            {
                contar = 0;
                texto1.text = "Lost";
                texto2.text = "Coldplay";
                polla.clip = pollita7;
                polla.Play();
            }
        }
        if (ultima == 8)
        {
            if (c8)
            {
                contar = 0;
                texto1.text = "Gangsta's Paradise";
                texto2.text = "Coolio";
                polla.clip = pollita8;
                polla.Play();
            }
        }
        if (ultima == 9)
        {
            if (c9)
            {
                contar = 0;
                texto1.text = "Snowflake";
                texto2.text = "Malachai";
                polla.clip = pollita9;
                polla.Play();
            }
        }
        if (ultima == 10)
        {
            if (c10)
            {
                contar = 0;
                texto1.text = "Take Your Mama";
                texto2.text = "Scissor Sisters";
                polla.clip = pollita10;
                polla.Play();
            }
        }
        if (ultima == 11)
        {
            if (c11)
            {                  
                contar = 0;
                texto1.text = "Zonnestraal";
                texto2.text = "De Hofnar";
                polla.clip = pollita11;
                polla.Play();
            }
        }
        if (ultima == 12)
        {
            if (c12)
            {
                contar = 0;
                texto1.text = "Dieci Cento Mille";
                texto2.text = "Brothers";
                polla.clip = pollita12;
                polla.Play();
            }
        }
        if (ultima == 13)
        {
            if (c13)
            {
                contar = 0;
                texto1.text = "Ciao Sono Io";
                texto2.text = "Sandro Bit";
                polla.clip = pollita13;
                polla.Play();
            }
        }
        if (ultima == 14)
        {
            if (c14)
            {
                contar = 0;
                texto1.text = "Follow Me";
                texto2.text = "Miss J";
                polla.clip = pollita14;
                polla.Play();
            }
        }
        if (ultima == 15)
        {
            if (c15)
            {
                contar = 0;
                texto1.text = "Brooklyn Is Burning";
                texto2.text = "Head Automatica";
                polla.clip = pollita15;
                polla.Play();
            }
        }
        if (ultima == 16)
        {
            if (c16)
            {
                contar = 0;
                texto1.text = "Trick Pony";
                texto2.text = "Charlotte Gainsbourg";
                polla.clip = pollita16;
                polla.Play();
            }
        }
        if (ultima == 17)
        {
            if (c17)
            {
                contar = 0;
                texto1.text = "Every Step Every Way";
                texto2.text = "Majid Jordan";
                polla.clip = pollita17;
                polla.Play();
            }
        }
        if (ultima == 18)
        {
            if (c18)
            {
                contar = 0;
                texto1.text = "I Know There's Gonna Be (Good Times)";
                texto2.text = "Jamie xx";
                polla.clip = pollita18;
                polla.Play();
            }
        }
        if (ultima == 19)
        {
            if (c19)
            {
                contar = 0;
                texto1.text = "Hype";
                texto2.text = "Drake";
                polla.clip = pollita19;
                polla.Play();
            }
        }
        if (ultima == 20)
        {
            if (c20)
            {
                contar = 0;
                texto1.text = "Long Run";
                texto2.text = "Fly Union";
                polla.clip = pollita20;
                polla.Play();
            }
        }
        if (ultima == 21)
        {
            if (c21)
            {
                contar = 0;
                texto1.text = "Who Do We Think We Are";
                texto2.text = "John Legend ft. Rick Ross";
                polla.clip = pollita21;
                polla.Play();
            }
        }
        if (ultima == 22)
        {
            if (c22)
            {
                contar = 0;
                texto1.text = "In The Air Tonight";
                texto2.text = "Phil Collins";
                polla.clip = pollita22;
                polla.Play();
            }
        }
        if (ultima == 23)
        {
            if (c23)
            {
                contar = 0;
                texto1.text = "Another Day In Paradise";
                texto2.text = "Phil Collins";
                polla.clip = pollita23;
                polla.Play();
            }
        }





    }
}