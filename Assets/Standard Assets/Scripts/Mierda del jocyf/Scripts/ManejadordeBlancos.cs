using UnityEngine;

public class ManejadordeBlancos : MonoBehaviour
{
    public int Salud = 100;
    public GameObject Explosion = null;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Contains("Armas"))
        {
            //ArmasEstado ArmasScript = (ArmasEstado) other.gameObject.GetComponent(typeof(ArmasEstado));
            //DecrementaSalud(ArmasScript.Damage);
            AplicaDamage(other.gameObject.GetComponent<ArmasEstado>().Damage);
        }
    }

    public void AplicaDamage (int Damage)
    {
        Salud -= Damage;
        if (Salud <= 0)
        {
            Instantiate (Explosion, transform.position, Quaternion.identity);
            Destroy (gameObject);
        }
    }

}