using UnityEngine;

public class AutoDestruir : MonoBehaviour /**/
{
    public float destroyTime = 0.1f;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Siguiente()
    {

    }
}