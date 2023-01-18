using UnityEngine;


public class DibujadorArmas : MonoBehaviour
{
    public GameObject[] Armas;

    void Awake()
    {
        GameObject FPS = GameObject.Find("FPC");
        DisparoSelectivo DisparoScript = FPS.GetComponent<DisparoSelectivo>();

       // ActivarArma(DisparoScript.NumeroArma);
    }

    // Activamos el arma que debamos activar (en pricipio sta activa el arma 'cero') 
    // y desactivamos todas las demás.
    public void ActivarArma(int NumeroArma)
    {
        int i = 0;
        while (i < Armas.Length)
        {
            bool isActive = (i == NumeroArma);
            Armas[i].GetComponent<Renderer>().enabled = isActive;
            Armas[i].SetActive(isActive);

            i++;
        }
    }

}