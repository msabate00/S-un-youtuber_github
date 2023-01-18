using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcsalud : MonoBehaviour {


	public void Aplicacriticks() {
        //NO BORRES LA MIERDA ESTA K SALTAN ERRORES JODER
    }
    public void miscollones()
    {
        Controlador.civilmuerto = true;
        gameObject.GetComponent<Animator>().enabled = false;
        Destroy(gameObject, 100);
    }
    public void AplicaStun()
    {
        //NO BORRES LA MIERDA ESTA K SALTAN ERRORES JODER
    }
    public void ExplosionadoMuerto()
    {
     //   AplicaDamage();
    }
    public void Explosionado()
    {
       // AplicaDamage();
    }
}
