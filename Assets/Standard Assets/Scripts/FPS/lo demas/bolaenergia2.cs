using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolaenergia2 : MonoBehaviour {

    [HideInInspector]
    public float vel = 0;
    [HideInInspector]
    public Vector3 dir = Vector3.zero;

    public float damagehomogay = 120;
    public float stun = 180;

    public AudioClip[] Sonidos;
    public GameObject sonidobum;

    public float radio;
    public Vector3 offset;

    void Start()
    {
        Invoke("AutoDestroy", 5);
    }

    void Update () {
        RaycastHit hit;
        var layerMask = (1 << 2);
        layerMask |= (1 << 4);
        layerMask |= (1 << 15);
        layerMask |= (1 << 22);
        layerMask |= (1 << 26);

        
        if (Physics.SphereCast(transform.position + transform.TransformDirection(offset), radio, dir, out hit, vel * Time.deltaTime, layerMask))
        {
            float angolomierda = 60;

            Vector3 dir2 = hit.normal;
            Vector3 pos = dir;

            Vector3 dir3 = Vector3.Reflect(dir, dir2);

            if (hit.transform.tag == "Enemy")
            {
                angolomierda = 360;

                hit.collider.SendMessage("Posgay", transform.position, SendMessageOptions.DontRequireReceiver);
                hit.collider.SendMessage("Aplicacriticks", 1, SendMessageOptions.DontRequireReceiver);
                hit.collider.SendMessage("AplicaDamage4", damagehomogay, SendMessageOptions.DontRequireReceiver);
                hit.collider.SendMessage("AplicaStun", stun, SendMessageOptions.DontRequireReceiver);

                hit.collider.SendMessage("sangrecilla2", hit, SendMessageOptions.DontRequireReceiver);
            }

                var layerMask2 = (1 << 14);
                Collider[] penes = Physics.OverlapSphere(transform.position, 80, layerMask2);
                float angulo = 360;
                Transform ah = null;

                if (penes.Length > 0)
                {
                    for (int i = 0; i < penes.Length; i++)
                    {
                        Vector3 gay = penes[i].transform.parent.position - new Vector3(transform.position.x, penes[i].transform.parent.position.y, transform.position.z); gay = gay.normalized;
                        float angle = Vector3.SignedAngle(dir3, gay, Vector3.up);
                        if (Mathf.Abs(angle) < Mathf.Abs(angulo) && penes[i].gameObject.tag != "micuerpochingon")
                        {
                            if (hit.transform.CompareTag("Enemy") && hit.transform.root == penes[i].transform.root) { continue;  }

                            ah = penes[i].transform.parent;
                            angulo = angle;
                        }
                    }
                }
                if (ah != null && Mathf.Abs(angulo) < angolomierda)
                {
                    dir = (ah.position + (Vector3.up * 3f) - transform.position).normalized;
                }
                else
                {
                    dir = dir3;
                }

                GetComponent<AudioSource>().PlayOneShot(Sonidos[Random.Range(0, 2)]);
            
        }
        
        transform.Translate(dir * (vel * Time.deltaTime), Space.World);
    }

    void AutoDestroy()
    {
        if (sonidobum != null)
        {
            Instantiate(sonidobum, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }

}
