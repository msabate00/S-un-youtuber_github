using UnityEngine;

public class SplashEstado : MonoBehaviour
{
    [Tooltip("Escala final del objeto.")]
    public Vector3 targetScale = new Vector3(3f, 3f, 3f);
    [Tooltip("Tiempo de escalado del objeto.")]
    public float smoothTime = 0.2f;

    [Tooltip("Tiempo de espera antes de destruir este objeto.")]
    public float TimeToDestroy = 0.5f;

    private Vector3 newScale = Vector3.zero;    // Var. Interna. Usada en el Update para guardar la escala en curso.
    private float Velocity = 0.1f;  // Variable interna obligatoria de SmoothDamp que devuelve la velocidad del proceso de reescalado.


    void Start()
    {
        newScale = transform.localScale;
        Destroy(gameObject, TimeToDestroy); // Destruye el object a los X segundos
    }

    void Update()
    {
        newScale.x = Mathf.SmoothDamp(newScale.x, targetScale.x, ref Velocity, smoothTime);
        newScale.y = Mathf.SmoothDamp(newScale.y, targetScale.y, ref Velocity, smoothTime);
        newScale.z = Mathf.SmoothDamp(newScale.z, targetScale.z, ref Velocity, smoothTime);
        transform.localScale = newScale;
    }

}