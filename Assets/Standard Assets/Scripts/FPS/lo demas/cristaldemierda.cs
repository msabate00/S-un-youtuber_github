using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cristaldemierda : MonoBehaviour {

	public GameObject pene;
    public Vector3 laputaposicion;

	public void Aplicacriticks() {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        GameObject pollones = Instantiate(pene, laputaposicion, transform.rotation);
        pollones.transform.localScale = new Vector3(33, 33, 33);
        Destroy(gameObject);
	}
    public void AplicaDamage()
    {
        //NO BORRES LA MIERDA ESTA K SALTAN ERRORES JODER
    }
    public void AplicaStun()
    {
        //NO BORRES LA MIERDA ESTA K SALTAN ERRORES JODER
    }
    public void Posgay()
    {
        //NO BORRES LA MIERDA ESTA K SALTAN ERRORES JODER
    }
}
