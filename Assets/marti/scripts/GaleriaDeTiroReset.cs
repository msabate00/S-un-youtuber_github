using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaleriaDeTiroReset : MonoBehaviour
{
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

        galeriaDeTiroController.resetSistema();

    }

    public void AplicaDamage1(float damage) { AplicaDamage(damage); }
    public void AplicaDamage2(float damage) { AplicaDamage(damage); }
    public void AplicaDamage3(float damage) { AplicaDamage(damage); }
    public void AplicaDamage4(float damage) { AplicaDamage(damage); }
    public void AplicaDamage5(float damage) { AplicaDamage(damage); }
    public void Explosionado(Transform damage) { AplicaDamage(0); }
    public void ExplosionadoMuerto(Transform damage) { AplicaDamage(0); }

}
