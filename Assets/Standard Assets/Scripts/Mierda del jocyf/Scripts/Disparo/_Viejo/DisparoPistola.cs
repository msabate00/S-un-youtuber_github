using UnityEngine;

public class DisparoPistola : MonoBehaviour
{
    [Tooltip("Splash que se usará donde la 'bala' impacte con un objeto (si impacta con algo).")]
    public GameObject SplashObject = null;
    [Tooltip("El Splash estará orientado respecto a la superficie donde colisione?")]
    public bool UseRotation = true;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))   // Deteccion del boton de disparo.
        {
            RaycastHit hit = default(RaycastHit);
            // Se mira si nuestra 'bala imaginaria' choca con algo del escenario, para crear nuestro Splash (explosion)
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 1000))
            {
                CreateSplashObject (hit);
            }
        }
    }

    // Creamos nuestro Splash.
    private void CreateSplashObject(RaycastHit hit)
    {
        Vector3 position = hit.point;
        Quaternion rotation = Quaternion.identity;

        if (UseRotation == true)
        {
            rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }

        Instantiate(SplashObject, position, rotation);
    }

}