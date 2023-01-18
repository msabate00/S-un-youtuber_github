using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doit : MonoBehaviour {
    public bool pene = false;
    public bool sfera = false;
    public float polla = 10;
    public GameObject Elotro;
    public GameObject esfera;
    public GameObject lacam;
    [HideInInspector]
    public bool moribundotio = true; // cosa de esto para que se active el de dar ostias
    [HideInInspector]
    public bool yaaempezao = false;
    private float mishuevos;
    [HideInInspector]
    public string tipogay;
    private bool jodergay = true;

    void Start () {
    if (GetComponent<BoxCollider>() != null)
        {
            GetComponent<BoxCollider>().enabled = true;
        }
        mishuevos = Elotro.GetComponent<ManageEnemyStatus>().stunmax;
    tipogay = Elotro.GetComponent<ManageEnemyStatus>().tipoenemigogay; 
    }
	
    void Moridoweno()
    {
        Elotro.SendMessage("hasmorio");
    }

    void Morido()
    {
        if (Elotro.GetComponent<ManageEnemyStatus>().tipo == "tochoalpha")
        {
            Controlador.enemigostochosalpha -= 1;
        }
        if (Elotro.GetComponent<ManageEnemyStatus>().tipo ==  "tochobeta")
        {
            Controlador.enemigostochosbeta -= 1;
        }
        if (Elotro.GetComponent<ManageEnemyStatus>().tipo == "tochodelta")
        {
            Controlador.enemigostochosdelta -= 1;
        }
        if (Elotro.GetComponent<ManageEnemyStatus>().tipo == "tochogamma")
        {
            Controlador.enemigostochosgamma -= 1;
        }
        if (Elotro.GetComponent<ManageEnemyStatus>().tipo == "normalalpha")
        {
            Controlador.enemigosnormalesalpha -= 1;
        }
        if (Elotro.GetComponent<ManageEnemyStatus>().tipo == "normalbeta")
        {
            Controlador.enemigosnormalesbeta -= 1;
        }
        if (Elotro.GetComponent<ManageEnemyStatus>().tipo == "normaldelta")
        {
            Controlador.enemigosnormalesdelta -= 1;
        }
        if (Elotro.GetComponent<ManageEnemyStatus>().tipo == "normalgamma")
        {
            Controlador.enemigosnormalesgamma -= 1;
        }
        if (Elotro.GetComponent<ManageEnemyStatus>().tipo == "camperoalpha")
        {
            Controlador.enemigoscampersalpha -= 1;
        }
        if (Elotro.GetComponent<ManageEnemyStatus>().tipo == "camperobeta")
        {
            Controlador.enemigoscampersbeta -= 1;
        }
        if (Elotro.GetComponent<ManageEnemyStatus>().tipo == "camperodelta")
        {
            Controlador.enemigoscampersdelta -= 1;
        }
        if (Elotro.GetComponent<ManageEnemyStatus>().tipo == "camperogamma")
        {
            Controlador.enemigoscampersgamma -= 1;
        }

    }
	void Update () {

        if (Elotro.GetComponent<ManageEnemyStatus>().stuneable == false)
        {
            moribundotio = true;
            if (yaaempezao)
            {
                Elotro.SendMessage("finishgay");
                if (jodergay)
                {
                    Moridoweno();
                    jodergay = false;
                }
            }
        }
        if (Elotro.GetComponent<ManageEnemyStatus>().stuneable == true)
        {
            if (Elotro.GetComponent<ManageEnemyStatus>().stunact == mishuevos)
            {
                moribundotio = true;
            }
            else
            if (!yaaempezao)
            {
                moribundotio = false;
            }
            if (yaaempezao)
            {
                moribundotio = true;
                Elotro.SendMessage("finishgay");
                if (jodergay)
                {
                    Moridoweno();
                    jodergay = false;
                }
            }
        }


        if (pene)
        {
            Elotro.GetComponent<Destroyer>().enabled = true;
            // Elotro.GetComponent<doit1>().enabled = true;   antiguo sistema
            //  print ("TU PUTA MADRE");
           // lacam.GetComponent<DesCam3>().enabled = true; antiguo sistema pero si da fallos o algo unexpected lo siento ttio jej
        }

        if (sfera)
        {
            esfera.SetActive(true);
           // print("TU PUTA MADRE");
        }
    }
}
