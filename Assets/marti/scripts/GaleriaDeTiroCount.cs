using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaleriaDeTiroCount : MonoBehaviour
{
    public bool tocado = false;
    public GaleriaDeTiroController galeriaDeTiroController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AplicaDamage(float damage)
    {

        if (!tocado) {
            galeriaDeTiroController.sumarPuntuacion(1);
            tocado = true;
        }

    }

    public void AplicaDamage1(float damage) { AplicaDamage(damage); }
    public void AplicaDamage2(float damage) { AplicaDamage(damage); }
    public void AplicaDamage3(float damage) { AplicaDamage(damage); }
    public void AplicaDamage4(float damage) { AplicaDamage(damage); }
    public void AplicaDamage5(float damage) { AplicaDamage(damage); }
    public void Explosionado(float damage) { AplicaDamage(damage); }
    public void ExplosionadoMuerto(float damage) { AplicaDamage(damage); }
}
