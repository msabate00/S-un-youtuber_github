using UnityEngine;

public class AdaptadorPantalla : MonoBehaviour
{

    public enum Aspecto { Aspecto5by4, Aspecto4by3, Aspecto3by2, Aspecto16by10, Aspecto16by9 };

    public Camera camara;
    public Aspecto aspectoOriginal = Aspecto.Aspecto5by4;

    float[] ratios = new float[] { 1.25f, 1.333f, 1.5f, 1.6f, 1.777f };

    void Reducir(Aspecto aspectoActual)
    {

        float porcentaje = (ratios[(int)aspectoActual] - ratios[(int)aspectoOriginal])
                       / ratios[(int)aspectoActual];
        this.camara.rect = new Rect(0f, 0f, 1f - porcentaje, 1f);
        this.camara.pixelRect = new Rect(Screen.width * porcentaje * 0.5f, 0f, Screen.width * (1f - porcentaje), (float)Screen.height);

    }

    void Aumentar(Aspecto aspectoActual)
    {

        float porcentaje = (ratios[(int)aspectoOriginal] - ratios[(int)aspectoActual])
                       / ratios[(int)aspectoOriginal];
        this.camara.rect = new Rect(0f, 0f, 1f, 1f - porcentaje);
        this.camara.pixelRect = new Rect(0f, Screen.height * porcentaje * 0.5f, (float)Screen.width, Screen.height * (1f - porcentaje));

    }

    void Awake()
    {

        float aspectoPantalla = this.camara.aspect;
        Aspecto aspectoActual;

        if (aspectoPantalla < 1.29f) aspectoActual = Aspecto.Aspecto5by4;
        else if (aspectoPantalla < 1.4f) aspectoActual = Aspecto.Aspecto4by3;
        else if (aspectoPantalla < 1.6f) aspectoActual = Aspecto.Aspecto3by2;
        else if (aspectoPantalla < 1.7) aspectoActual = Aspecto.Aspecto16by10;
        else aspectoActual = Aspecto.Aspecto16by9;

        if (aspectoActual > this.aspectoOriginal) this.Reducir(aspectoActual);
        if (aspectoActual < this.aspectoOriginal) this.Aumentar(aspectoActual);

    }

}