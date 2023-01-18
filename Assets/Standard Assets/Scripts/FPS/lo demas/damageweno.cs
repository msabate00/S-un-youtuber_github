using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageweno : MonoBehaviour {

    private float ercritico;
    public GameObject vidagay;
    private float stuner;
    private float ahmishuevos;
    private ManageEnemyStatus1 vida;
    private float altura;
    public enum Direction { Cabeza, Torso, Piernas};
    public Direction estado;
    public string joder;
    private putosgays a;

    void Start () {
        vida = transform.GetComponentInParent<ManageEnemyStatus1>();
        if (estado == Direction.Cabeza)
        {

        }
    }

    public void AplicaStun(float stun)
    {

        stuner = stun;
        stuner *= ercritico;
        vida.SendMessage("AplicaStun", stuner);
    }
    public void AplicaStunmelee(int stun)
    {
        vida.SendMessage("AplicaStun", stun);
    }

    public void AplicaDamage(float damage)
    {
        ahmishuevos = damage;
        ahmishuevos *= ercritico;
        vida.SendMessage("AplicaDamage", ahmishuevos);
    }
    public void AplicaDamage2(float damage)
    {
        ahmishuevos = damage;
        ahmishuevos *= ercritico;
        vida.SendMessage("AplicaDamage2", ahmishuevos);
    }
    public void AplicaDamage3(float damage)
    {
        ahmishuevos = damage;
        ahmishuevos *= ercritico;
        vida.SendMessage("AplicaDamage3", ahmishuevos);
    }
    public void AplicaDamage4(float damage)
    {
        ahmishuevos = damage;
        ahmishuevos *= ercritico;
        vida.AplicaDamage4(ahmishuevos, 13);
    }
    public void AplicaDamage5(float damage)
    {
        ahmishuevos = damage;
        ahmishuevos *= ercritico;
        vida.AplicaDamage4(ahmishuevos, 14);
    }
    public void Golpiado(int sex)
    {
        vida.Golpiado(sex);
    }
    public void Aplicacriticks(float criticogay)
    {
        if (estado == Direction.Cabeza)
        {
            ercritico = criticogay;
        }
        else
        {
            ercritico = 1;
        }
        
        puntos();
    }
    public void Posgay(Vector3 pos)
    {
        Vector3 posfin = vida.gameObject.transform.position - GameObject.FindGameObjectWithTag("micuerpochingon").transform.position;

        vida.posbala = new Vector3(posfin.x, posfin.y, posfin.z);
        vida.alturabala = pos.y - vida.gameObject.transform.position.y;
        
    }
    void puntos()
    {
        if (a == null)
        {
            a = GameObject.Find("PutosPuntosGays").GetComponent<putosgays>();
        }

        if (vida.health <= 0 || estado != Direction.Cabeza || vida.parry) { return; }
       
        a.gays(a.puntitos[9], 9);
    }

    public void sangrecilla(RaycastHit hit)
    {
        vida.SendMessage("sangrecilla", hit);
    }
    public void sangrecilla2(ContactPoint hit)
    {
        vida.SendMessage("sangrecilla", hit);
    }
}
