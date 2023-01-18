using UnityEngine;

public class HierbaSalud : MonoBehaviour
{
    public int SustractHealth = 1;
    public float timeRateSustraction = 1;

    private float timeRateSustractionCheck;


    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag.Contains("Player") && Time.time >= timeRateSustractionCheck)
        {
            //GameMngr.Instance.nSalud = (int) (GameMngr.Instance.nSalud - (SustractHealth * Time.deltaTime));
            other.gameObject.SendMessage("DamagePlayer", SustractHealth);
            timeRateSustractionCheck = Time.time + timeRateSustraction;
        }
    }

}