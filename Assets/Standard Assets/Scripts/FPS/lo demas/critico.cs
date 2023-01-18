using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class critico : MonoBehaviour
{
    private float ercritico;
    public GameObject vidagay;
    private float stuner;
    private float ahmishuevos;
    private putosgays a;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Golpiado(int damagegay)
    {
        Debug.Log("TU PUTA MADRE COÑO YA OSTIA");
        vidagay.SendMessage("Golpiado", damagegay);
    }

    public void AplicaStun(float stun)
    {
        
        stuner = stun;
        stuner *= ercritico;
        vidagay.SendMessage("AplicaStun", stuner);
    }
    public void AplicaStunmelee(int stun)
    {
        vidagay.SendMessage("AplicaStun", stun);
    }

    public void AplicaDamage(float damage)
    {
        Debug.Log("JHOOOODOER COÑOKDSAFKDSAPOFGRJSAÑKL");
        ahmishuevos = damage;
        ahmishuevos *= ercritico;
        vidagay.SendMessage("AplicaDamage", ahmishuevos);
    }
    public void Aplicacriticks(float criticogay)
    {
        ercritico = criticogay;
    }

    public void tiempobarra()
    {
        vidagay.SendMessage("tiempobarra");
    }
    void puntos()
    {
        if (a == null)
        {
            a = GameObject.Find("PutosPuntosGays").GetComponent<putosgays>();
        }

        a.gays(a.puntitos[0], 0);
    }
}