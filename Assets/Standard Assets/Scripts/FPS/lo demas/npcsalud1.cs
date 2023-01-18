using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcsalud1 : MonoBehaviour {


	public void Aplicacriticks() {
        //NO BORRES LA MIERDA ESTA K SALTAN ERRORES JODER
    }
    public void AplicaDamage()
    {
        Debug.Log("POLLALALALALA");
        gameObject.GetComponentInParent<npcsalud>().miscollones();       
    }
    public void AplicaStun()
    {
        //NO BORRES LA MIERDA ESTA K SALTAN ERRORES JODER
    }
    public void ExplosionadoMuerto()
    {
        AplicaDamage();
    }
    public void Explosionado()
    {
        AplicaDamage();
    }
}
