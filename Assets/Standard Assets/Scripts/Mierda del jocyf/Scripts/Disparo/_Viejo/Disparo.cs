using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Disparo : MonoBehaviour
{
    [Tooltip("Punto de disparo donde se disparara la bala (el cañon del arma).")]
    public Transform PuntoDisparo;
    [Tooltip("Arma a la que pertenece la bala que se va disparar. El arma tiene los datos de la bala (aceleracion, daño que va a hacer, etc).")]
    public GameObject Arma;

    private float Aceleracion = 1f;


    // Inicializa la aceleracion que va a tener la bala a disparar.
    void Start()
    {
        Aceleracion = Arma.GetComponent<ArmasEstado>().Aceleracion;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CreateBullet ();
        }
    }

    // Crea la bala del arma al pulsar el boton de disparo.
    private void CreateBullet ()
    {
        GameObject CloneFire = Instantiate(Arma, PuntoDisparo.position, Camera.main.transform.rotation);
        CloneFire.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, Aceleracion), ForceMode.VelocityChange);
    }
}