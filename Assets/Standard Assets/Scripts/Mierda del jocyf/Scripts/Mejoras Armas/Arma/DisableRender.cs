using UnityEngine;

public class DisableRender : MonoBehaviour
{
    void Start()
    {
        GetComponent<Renderer>().enabled = false;
    }

}