using UnityEngine;
using UnityEngine.UI;

public class UIDamageMngr : MonoBehaviour
{
    public float fadeTime = 0.1f;


    private float OrigAlpha = 0f;
    private float rate = 0f;
    private float i = 0f;
    private int OrigHealth = 0;

    private Image myDamageImage = null;
    //private GUITexture myGUITexture = null;


    void Start()
    {
        myDamageImage = GetComponent<Image>();
        if (myDamageImage.enabled) myDamageImage.enabled = false;

        //myGUITexture = GetComponent<GUITexture>();
        //if (myGUITexture.enabled) myGUITexture.enabled = false; // Lo desactiva el GUI de daño, para que no se vea en pantalla.

        // Ajusto la textutra de daño al tamaño de la pantalla. (Ajusta la anchura y altura de nuestro GUI).
        /*Rect _pixelInsetAux = myGUITexture.pixelInset;
        _pixelInsetAux.width = Screen.width;
        _pixelInsetAux.height = Screen.height;
        myGUITexture.pixelInset = _pixelInsetAux;*/

        // Inicializo las variables privadas locales del script.
        OrigAlpha = myDamageImage.color.a;
        rate = 1f / fadeTime;
        OrigHealth = GameMngr.Instance.nSalud;
    }

    // El FX visual de daño se ve en pantalla y empiza a desaparacer.
    // Realiza el fade y desactiva el GUI cuando el alpha ya es cero (no se ve con alpha cero).
    void Update()
    {
        if (myDamageImage.enabled)
        {
            if (i < 1f)
            {
                i += Time.deltaTime * rate;

                Color _colorAux = myDamageImage.color;
                _colorAux.a = Mathf.Lerp(OrigAlpha, 0, i);
                myDamageImage.color = _colorAux;
            }
            else
            {
                myDamageImage.enabled = false;
            }
        }

        // Comprobacion obsoleta /**/
        if (OrigHealth > GameMngr.Instance.nSalud)
        {
            OrigHealth = GameMngr.Instance.nSalud;
            ShowGUIDamage();
        }
    }

    // Funcion que sera llamada por otros scripts que hagan danio a nuetro FPC.
    public void ShowGUIDamage()
    {
        OrigHealth = GameMngr.Instance.nSalud;
        i = 0;

        Color _colorAux = myDamageImage.color;
        _colorAux.a = OrigAlpha;
        myDamageImage.color = _colorAux;

        myDamageImage.enabled = true;
    }


}