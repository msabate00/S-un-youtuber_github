using UnityEngine;

public class PruebaDisparoAlternativo : MonoBehaviour
{
    public Transform PuntoDisparo = null;
    public GameObject Arma = null;


    private float Aceleracion = 1f;
    public float nextFire = 0f;
    public float fireRate = 0.1f;

    // Inicializa la aceleracion que va a tener la bala a disparar.
    void Start()
    {
        Aceleracion = Arma.GetComponent<ArmasEstado>().Aceleracion;
    }

    void Update()
    {

        // Detecta cuando el boton está pulsado.
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            CreateBullet();
        }
    }

    // Crea la bala del arma al pulsar el boton de disparo.
    private void CreateBullet ()
    {
        GameObject CloneFire = Instantiate(Arma, PuntoDisparo.position, Camera.main.transform.rotation);
        CloneFire.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, Aceleracion), ForceMode.VelocityChange);
        nextFire = Time.time + fireRate;    // Actualiza el ratio de disparo.
    }
}