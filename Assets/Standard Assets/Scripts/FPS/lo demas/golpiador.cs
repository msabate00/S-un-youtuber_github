using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golpiador : MonoBehaviour {

    private bool pollas = false;
    private int miscojonazos;
    public GameObject sangrecilla;
    public GameObject sonido;
    [HideInInspector]
    public int animacion;
    [HideInInspector]
    public int fallao;
    [HideInInspector]
    public bool des = false;
    public GameObject despart;

    private bool follame = true;

    void Start () {
        Destroy(gameObject, 0.2f);
        Invoke("Instanciador", 0.05f);

        if (animacion == 1)
        {
            fallao = 4;
        }
        if (animacion == 2)
        {
            fallao = 5;
        }
        if (animacion == 3)
        {
            fallao = 7;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider target)
    {
        if (!pollas)
        {
            if (target.tag == "cabesa" || target.tag == "Enemy")
            {
                if (target.transform.root.GetComponent<ManageEnemyStatus1>().amorido) { return; }
                pollas = true;
                

                if (!des)
                {
                    target.transform.SendMessage("Golpiado", 43, SendMessageOptions.DontRequireReceiver);                    
                    //target.transform.SendMessage("AplicaStunmelee", 55, SendMessageOptions.DontRequireReceiver);
                    GameObject DecallObja = Instantiate(sangrecilla, transform.position, transform.rotation);


                    GameObject DecallObj = Instantiate(sonido, transform.position, transform.rotation);
                    DecallObj.GetComponent<sonidosmelee>().kekosa = animacion;
                    Destroy(gameObject);
                }
                else
                {
                    Controlador.desfibrilador = 0;
                
                    GameObject pollades = Instantiate(despart, transform.position, Quaternion.identity);
                    Destroy(pollades, 6);

                    var layerMask2 = (1 << 10);
                    layerMask2 |= (1 << 15);
                    layerMask2 |= (1 << 25);

                    Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10, layerMask2);
                    foreach (var hit in hitColliders)
                    {
                        if (hit.gameObject.tag.Contains("Enemy") || hit.gameObject.tag.Contains("cabesa") || hit.gameObject.tag.Contains("cristal"))
                        {
                            hit.SendMessage("Posgay", transform.position, SendMessageOptions.DontRequireReceiver);
                            hit.SendMessage("Aplicacriticks", 1, SendMessageOptions.DontRequireReceiver);
                            hit.SendMessage("AplicaDamage3", 580, SendMessageOptions.DontRequireReceiver);
                            hit.SendMessage("AplicaStun", 450, SendMessageOptions.DontRequireReceiver);
                        }
                    }

                    hitColliders = Physics.OverlapSphere(transform.position, 25, layerMask2);
                    foreach (var hit in hitColliders)
                    {
                        if (hit.gameObject.tag.Contains("Enemy") || hit.gameObject.tag.Contains("cabesa") || hit.gameObject.tag.Contains("cristal"))
                        {
                            hit.SendMessage("Posgay", transform.position, SendMessageOptions.DontRequireReceiver);
                            hit.SendMessage("Aplicacriticks", 1, SendMessageOptions.DontRequireReceiver);
                            hit.SendMessage("AplicaDamage3", 50, SendMessageOptions.DontRequireReceiver);
                            hit.SendMessage("AplicaStun", 70, SendMessageOptions.DontRequireReceiver);
                        }
                    }
                    Destroy(gameObject);
                }
              
                
            }
        }
    }

    void Instanciador()
    {
        if (pollas)
        {
         //   GameObject DecallObj = Instantiate(sonido, transform.position, transform.rotation);
         //   DecallObj.GetComponent<sonidosmelee>().kekosa = animacion;
        }
        if (!pollas)
        {
            GameObject DecallObja = Instantiate(sonido, transform.position, transform.rotation);
            DecallObja.GetComponent<sonidosmelee>().kekosa = fallao;
        }
    }

}
