using UnityEngine;

public class MiraInteligente : MonoBehaviour
{
    // Basado en el script original de rojasasa.
    // Publicado originalmente en el hilo "Mira Dinamica" del foro UnitySpain.com

    public Color ColorNormal = Color.black;
    public Color ColorActivo = Color.red;
    public string[] DetectLayers;
    public float VisibilityDist = 100;
    public float size = 8;
    public float minimo = 16;
    public float maximo = 64;
    public float rateSize = 0.3f;

    private Texture2D TexturaNormal;
    private Texture2D TexturaActiva;
    private float intervalo;
    private CharacterController controller;


    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Creado la textura normal de un solo pixel (con el color normal)
        TexturaNormal = new Texture2D(1, 1);
        TexturaNormal.SetPixel(0, 0, ColorNormal);
        TexturaNormal.Apply();

        // Creado la textura activa de un solo pixel (con el color activo)
        TexturaActiva = new Texture2D(1, 1);
        TexturaActiva.SetPixel(0, 0, ColorActivo);
        TexturaActiva.Apply();
    }

    // Dibujamos la mira inteligente.
    void OnGUI()
    {
        RaycastHit hit = default(RaycastHit);
        bool isActive = false;

        intervalo = controller.isGrounded ? controller.velocity.magnitude / rateSize : maximo;
        intervalo = Mathf.Clamp(intervalo, minimo, maximo);
        Vector3 fwd = Camera.main.transform.TransformDirection(Vector3.forward);
        int layerMask = 1 << 9;
        layerMask = ~layerMask;

        // Se comprueba si se detecta algo lanzado un rayo hacia adelante
        if (Physics.Raycast(Camera.main.transform.position, fwd, out hit, VisibilityDist, layerMask))
        {
            foreach (string MyTag in DetectLayers)
            {
                if (hit.transform.tag.Contains(MyTag))
                {
                    isActive = true;
                }
            }
        }


        // Se dibuja la mira de diferente color dependiendo de si hemos detectado algo o no.
        if (isActive)
        {
            GUI.DrawTexture(new Rect(((Screen.width / 2) - (size / 2)) - intervalo, (Screen.height / 2) - (size / 8), size, size / 4), TexturaActiva);
            GUI.DrawTexture(new Rect(((Screen.width / 2) - (size / 2)) + intervalo, (Screen.height / 2) - (size / 8), size, size / 4), TexturaActiva);
            GUI.DrawTexture(new Rect((Screen.width  / 2) - (size / 8), ((Screen.height / 2) - (size / 2)) - intervalo,size / 4, size), TexturaActiva);
            GUI.DrawTexture(new Rect((Screen.width  / 2) - (size / 8), ((Screen.height / 2) - (size / 2)) + intervalo,size / 4, size), TexturaActiva);
        }
        else
        {
            GUI.DrawTexture(new Rect(((Screen.width / 2) - (size / 2)) - intervalo, (Screen.height / 2) - (size / 8), size, size / 4), TexturaNormal);
            GUI.DrawTexture(new Rect(((Screen.width / 2) - (size / 2)) + intervalo, (Screen.height / 2) - (size / 8), size, size / 4), TexturaNormal);
            GUI.DrawTexture(new Rect((Screen.width  / 2) - (size / 8), ((Screen.height / 2) - (size / 2)) - intervalo, size / 4, size), TexturaNormal);
            GUI.DrawTexture(new Rect((Screen.width  / 2) - (size / 8), ((Screen.height / 2) - (size / 2)) + intervalo, size / 4, size), TexturaNormal);
        }
    }

}