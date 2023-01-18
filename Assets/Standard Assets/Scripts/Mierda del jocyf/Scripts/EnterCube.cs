using UnityEngine;

public class EnterCube : MonoBehaviour
{
    public float interval = 0.5f;
    private float nextinterval;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player"))
        {
            //GameMngr.Instance.nSalud--;
            other.gameObject.SendMessage("DamagePlayer", 1);
            //Debug.Log(GameMngr.Instance.nSalud);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag.Contains("Player"))
        {
            if (Time.time > nextinterval)
            {
                nextinterval = Time.time + interval;
                //GameMngr.Instance.nSalud--;
                other.gameObject.SendMessage("DamagePlayer", 1);
                //Debug.Log(GameMngr.Instance.nSalud);
            }
        }
    }

}