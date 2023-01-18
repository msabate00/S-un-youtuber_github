using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagegay : MonoBehaviour {

    public GameObject sangre;
    public GameObject yo;
    public float distancia = 1;
    private float distancia2;
    private int paraostia = 0;
    public GameObject sangrecilla;
    private int pollas = 0;
    public int damagehomogay;
    public float stun;
    public Transform original;
    public bool eh = false;
    private Vector3 cosa;
    public GameObject decall;
    public GameObject decall2;
    private Vector3 vel;
    private float mag;
    public float velbala;
    private float grav = 10;
    public bool autoaim = true;
    private float siguiente;
    private float contadorgay = 0;
    private bool destruyetepa = false;
    public AudioClip[] Sonidos;
    public GameObject sonidobum;
    private bool enemigo = false;
    public float radio;
    public Vector3 offset;
    public bool ballesta = false;

    public float velocidadgay = 0;

    void Start () {
        distancia2 = distancia;
        distancia2 *= 2;
        cosa = FPCStatus.movimiento;
        cosa.y = 0;
        cosa.z = 0;
        if (eh)
        {
            transform.localPosition = transform.localPosition + (cosa * 0.18f);
        }

        Invoke("AutoDestroy", 5);
        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().volume = GetComponent<AudioSource>().volume * Controlador.volumenef;
        }
        
        // Invoke("activar", 0.001f);
    }
	
	void activar()
    {
        GetComponent<Renderer>().enabled = true;
    }

    public void vels(float sex)
    {
        velocidadgay = sex;

    }

    void Update()
    {
        if (velocidadgay == 0) { return; }

        var layerMask2 = (1 << 2);
        layerMask2 |= (1 << 4);
        layerMask2 |= (1 << 15);
        layerMask2 |= (1 << 22);
        layerMask2 |= (1 << 26);
        RaycastHit hit2;
        Vector3 semen = transform.TransformDirection(Vector3.forward);

        if (Physics.SphereCast(transform.position + transform.TransformDirection(offset), radio, semen, out hit2, velocidadgay * Time.deltaTime, layerMask2))
        {
            if (pollas < 1)
            {
                if (hit2.transform.CompareTag("pene"))
                {

                    //                Debug.Log("oh god");

                    pollas += 1;

                    Vector3 pos = transform.TransformDirection(Vector3.back);

                    var layerMask = (1 << 2);
                    layerMask |= (1 << 4);
                    layerMask |= (1 << 13);
                    layerMask |= (1 << 14);
                    layerMask |= (1 << 17);
                    layerMask |= (1 << 22);
                    layerMask |= (1 << 23);
                    layerMask = ~layerMask;


                    RaycastHit hit = default(RaycastHit);
                    if (Physics.Raycast(transform.position + pos, -pos, out hit, 30, layerMask))
                    {
                        Vector3 posa = hit2.point;
                        Quaternion rotDecall = Quaternion.FromToRotation(Vector3.up, hit2.normal);
                        // GameObject DecallObj = Instantiate(decall, posa, rotDecall);
                        GameObject DecallObj2 = Instantiate(decall2, posa, rotDecall);

                        DecallObj2.transform.position += DecallObj2.transform.up * 0.03f;
                    }
                    if (!ballesta)
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        velocidadgay = 0;
                        transform.position = hit2.point;

                        GetComponent<sonidoballesta>().dalebro(0);
                    }
                   


                }
                if (hit2.transform.CompareTag("Blanco"))
                {
                    Vector3 pos = transform.TransformDirection(Vector3.back);

                    var layerMask = (1 << 2);
                    layerMask |= (1 << 4);
                    layerMask |= (1 << 13);
                    layerMask |= (1 << 14);
                    layerMask |= (1 << 17);
                    layerMask |= (1 << 22);
                    layerMask |= (1 << 23);
                    layerMask = ~layerMask;

                    Debug.Log(transform.position);
                    Debug.Log(transform.position + pos);
                    Debug.Log(pos);

                    RaycastHit hit = default(RaycastHit);
                    if (Physics.Raycast(transform.position + pos, -pos, out hit, 30, layerMask))
                    {
                        Debug.Log("LA MIURA");
                        Vector3 posa = hit.point;
                        Quaternion rotDecall = Quaternion.FromToRotation(Vector3.up, hit.normal);
                        GameObject DecallObj = Instantiate(decall, posa, rotDecall);

                        /**/
                        /*Vector3 _posAux = DecallObj.transform.position;
                        _posAux.y = DecallObj.transform.position.y + 0.1f;
                        DecallObj.transform.position = _posAux;*/
                        DecallObj.transform.position += DecallObj.transform.up * 0.03f;

                        DecallObj.transform.parent = hit.transform;

                    }

                    hit2.transform.SendMessage("AplicaDamage", damagehomogay);
                }
                if (hit2.transform.CompareTag("Enemy"))
                {
                    hit2.transform.SendMessage("Posgay", transform.position, SendMessageOptions.DontRequireReceiver);
                    hit2.transform.SendMessage("Aplicacriticks", GameObject.Find("Controlador").GetComponent<normalizador>().listagay[DisparoSelectivo.NumeroArmagay].Critico, SendMessageOptions.DontRequireReceiver);
                    hit2.transform.SendMessage("AplicaDamage", damagehomogay, SendMessageOptions.DontRequireReceiver);
                    hit2.transform.SendMessage("AplicaStun", stun, SendMessageOptions.DontRequireReceiver);

                    var layerMask = (1 << 2);
                    layerMask |= (1 << 4);
                    layerMask |= (1 << 13);
                    layerMask |= (1 << 14);
                    layerMask |= (1 << 17);
                    layerMask |= (1 << 22);
                    layerMask |= (1 << 23);
                    layerMask = ~layerMask;


                    Vector3 pos = transform.TransformDirection(Vector3.back);
                    
                    hit2.collider.SendMessage("sangrecilla", hit2, SendMessageOptions.DontRequireReceiver);

                    if (!ballesta)
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        velocidadgay = 0;
                        transform.position = hit2.point;
                        transform.SetParent(hit2.transform);

                        GetComponent<AudioSource>().volume = 1;
                        GetComponent<sonidoballesta>().dalebro(Random.Range(1, 3));
                    }
                }
                if (hit2.transform.CompareTag("cristal"))
                {
                    hit2.transform.SendMessage("bum", hit2.point);

                    Vector3 pos = transform.TransformDirection(Vector3.back);

                    var layerMask = (1 << 2);
                    layerMask |= (1 << 4);
                    layerMask |= (1 << 13);
                    layerMask |= (1 << 14);
                    layerMask |= (1 << 17);
                    layerMask |= (1 << 22);
                    layerMask |= (1 << 23);
                    layerMask = ~layerMask;


                    RaycastHit hit = default(RaycastHit);
                    if (Physics.Raycast(transform.position + pos, -pos, out hit, 30, layerMask))
                    {
                        Vector3 posa = hit2.point;
                        Quaternion rotDecall = Quaternion.FromToRotation(Vector3.up, hit2.normal);
                        // GameObject DecallObj = Instantiate(decall, posa, rotDecall);
                        GameObject DecallObj2 = Instantiate(decall2, posa, rotDecall);

                        DecallObj2.transform.position += DecallObj2.transform.up * 0.03f;
                    }
                    Destroy(gameObject);
                }
            }
        }

        transform.position += semen * velocidadgay * Time.deltaTime;
    }

    void LateUpdate()
    {
        /* RaycastHit hit;
         // Does the ray intersect any objects excluding the player layer
         if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia))
         {
             if (hit.collider.tag.Contains("micuerpochingon"))
             {
                 Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
                 sangrepechito(hit);
                 sangrehomosexual();

                // Debug.Log("Did Hit");
             }
         }
         if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, distancia2))
         {
             if (hit.collider.tag.Contains("micuerpochingon"))
             {
                 Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * hit.distance, Color.green);
               //  sangrepechito(hit);
               //  sangrehomosexual();

               //  Debug.Log("Did Hit");
             }
         }
         
        if (eh && !primero) // DESACTIVA ESTA PUTA MIERDA
         {
            grav = grav - 15 * Time.deltaTime;
            // GetComponent<Rigidbody>().AddForce(-transform.right * 100f);

            Vector3 penes = transform.eulerAngles;
               penes.y -= 100 * Time.deltaTime;
            transform.eulerAngles = penes;
            GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, grav, 20), ForceMode.Acceleration);
            Vector2 pollas = new Vector2(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.z).normalized * 20;
            GetComponent<Rigidbody>().velocity = new Vector3(pollas.x, grav, pollas.y);
        }
        

       
        */
        if (GetComponent<Rigidbody>() == null) { return; }
        vel = GetComponent<Rigidbody>().velocity;
        mag = GetComponent<Rigidbody>().velocity.magnitude;
        if (destruyetepa)
        {
            if (mag < 0.5f)
            {

                contadorgay += Time.deltaTime;
            }
            else
            {
                contadorgay = 0;
            }
            if (contadorgay > 0.08f)
            {
                    if (mag < 0.5f)
                    {
                    Instantiate(sonidobum, transform.position, transform.rotation);   
                    Destroy(gameObject);
                    }
            }
        }
    }
    void OnTriggerEnter(Collider target)
    {
        
        if (pollas < 1)
        {
            if (target.tag == "pene")
            {

                //                Debug.Log("oh god");
              
                                pollas += 1;

                Vector3 pos = transform.TransformDirection(Vector3.back);

                var layerMask = (1 << 2);
                layerMask |= (1 << 4);
                layerMask |= (1 << 13);
                layerMask |= (1 << 14);
                layerMask |= (1 << 17);
                layerMask |= (1 << 22);
                layerMask |= (1 << 23);
                layerMask = ~layerMask;


                RaycastHit hit = default(RaycastHit);
                if (Physics.Raycast(transform.position + pos, -pos, out hit, 30, layerMask))
                {
                    Vector3 posa = hit.point;
                    Quaternion rotDecall = Quaternion.FromToRotation(Vector3.up, hit.normal);
                   // GameObject DecallObj = Instantiate(decall, posa, rotDecall);
                    GameObject DecallObj2 = Instantiate(decall2, posa, rotDecall);

                   // DecallObj.transform.position += DecallObj.transform.up * 0.03f;
                    DecallObj2.transform.position += DecallObj2.transform.up * 0.3f;
                }
                
                Destroy(gameObject);
                
               
                }
            else if (target.tag == "Blanco")
            {
                Vector3 pos = transform.TransformDirection(Vector3.back);

                var layerMask = (1 << 2);
                layerMask |= (1 << 4);
                layerMask |= (1 << 13);
                layerMask |= (1 << 14);
                layerMask |= (1 << 17);
                layerMask |= (1 << 22);
                layerMask |= (1 << 23);
                layerMask = ~layerMask;

                Debug.Log(transform.position);
                Debug.Log(transform.position + pos);
                Debug.Log(pos);

                RaycastHit hit = default(RaycastHit);
                if (Physics.Raycast(transform.position + pos, -pos, out hit, 30, layerMask))
                {
                    Debug.Log("LA MIURA");
                    Vector3 posa = hit.point;
                    Quaternion rotDecall = Quaternion.FromToRotation(Vector3.up, hit.normal);
                    GameObject DecallObj = Instantiate(decall, posa, rotDecall);

                    /**/
                    /*Vector3 _posAux = DecallObj.transform.position;
                    _posAux.y = DecallObj.transform.position.y + 0.1f;
                    DecallObj.transform.position = _posAux;*/
                    DecallObj.transform.position += DecallObj.transform.up * 0.03f;
                   
                        DecallObj.transform.parent = hit.transform;
                    
                }

                target.SendMessage("AplicaDamage", damagehomogay);
            }
            else if (target.tag == "Enemy")
            {

                target.SendMessage("Posgay", transform.position, SendMessageOptions.DontRequireReceiver);
                target.SendMessage("Aplicacriticks", GameObject.Find("Controlador").GetComponent<normalizador>().listagay[DisparoSelectivo.NumeroArmagay].Critico, SendMessageOptions.DontRequireReceiver);
                target.SendMessage("AplicaDamage", damagehomogay, SendMessageOptions.DontRequireReceiver);
                target.SendMessage("AplicaStun", stun, SendMessageOptions.DontRequireReceiver);

                var layerMask = (1 << 2);
                layerMask |= (1 << 4);
                layerMask |= (1 << 13);
                layerMask |= (1 << 14);
                layerMask |= (1 << 17);
                layerMask |= (1 << 22);
                layerMask |= (1 << 23);
                layerMask = ~layerMask;


                Vector3 pos = transform.TransformDirection(Vector3.back);
                RaycastHit hit = default(RaycastHit);
                if (Physics.Raycast(transform.position + pos, -pos, out hit, 30, layerMask))
                {
                   // Vector3 posa = hit.point;
                   // Quaternion rotDecall = Quaternion.FromToRotation(Vector3.up, hit.normal);
                    //GameObject DecallObj = Instantiate(sangre, posa, rotDecall);
                    hit.collider.SendMessage("sangrecilla", hit, SendMessageOptions.DontRequireReceiver);

                    /**/
                    /*Vector3 _posAux = DecallObj.transform.position;
                    _posAux.y = DecallObj.transform.position.y + 0.1f;
                    DecallObj.transform.position = _posAux;*/
                    //DecallObj.transform.position += DecallObj.transform.up * 0.03f;

                }

                Destroy(gameObject);
            }
        }
       }

    void sangrehomosexual()
    {
        if (paraostia < 1)
        {
            paraostia += 1;
            GameObject clone;
            clone = Instantiate(sangre, yo.transform.position, yo.transform.rotation);



        }        
   }

   private void sangrepechito(RaycastHit hit)
    {
        if (paraostia < 1)
        {
            Vector3 pos = hit.point;
            Quaternion rotDecall = Quaternion.FromToRotation(Vector3.up, hit.normal);
            GameObject DecallObj = Instantiate(sangrecilla, pos, rotDecall);

            /**/
            /*Vector3 _posAux = DecallObj.transform.position;
            _posAux.y = DecallObj.transform.position.y + 0.1f;
            DecallObj.transform.position = _posAux;*/
            DecallObj.transform.position += DecallObj.transform.up * 0.03f;

            DecallObj.transform.parent = hit.transform;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        float angolomierda = 60;
        
        Vector3 dir = other.contacts[0].normal;
        Vector3 pos = GetComponent<Rigidbody>().velocity.normalized;

        Vector3 dir2 = Vector3.Reflect(vel.normalized, dir);
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().isKinematic = false;


        // GetComponent<Rigidbody>().velocity = dir2.normalized * mag;

        //  transform.localRotation = Quaternion.LookRotation(dir2, Vector3.forward);

        // GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,0, velbala), ForceMode.VelocityChange); //ACTIVA ESTO JODER
        if (other.collider.tag == "Enemy")
        {
            angolomierda = 360;
        }
        
        if (autoaim && Time.time > siguiente)
        {
            var layerMask2 = (1 << 14);
            Collider[] penes = Physics.OverlapSphere(transform.position, 80, layerMask2);
            float angulo = 360;
            Transform ah = null;

            if (penes.Length > 0)
            {
                for (int i = 0; i < penes.Length; i++)
                {
                    Vector3 gay = penes[i].transform.parent.position - new Vector3(transform.position.x, penes[i].transform.parent.position.y, transform.position.z); gay = gay.normalized;
                    float angle = Vector3.SignedAngle(dir2, gay, Vector3.up);
                    if (Mathf.Abs(angle) < Mathf.Abs(angulo) && penes[i].gameObject.tag != "micuerpochingon")
                    {
                        ah = penes[i].transform.parent;
                        angulo = angle;
                    }
                }
            }
            if (ah != null && Mathf.Abs(angulo) < angolomierda)
            {
                Vector3 dirgay = (ah.position + (Vector3.up * 4f) - transform.position).normalized;
                GetComponent<Rigidbody>().AddForce(dirgay * velbala, ForceMode.VelocityChange);
            }
            else
            {
                GetComponent<Rigidbody>().AddForce(dir2 * velbala, ForceMode.VelocityChange);
            }
            GetComponent<AudioSource>().PlayOneShot(Sonidos[Random.Range(0, 2)]);
        }
        else
        {
            GetComponent<Rigidbody>().AddForce(dir2 * velbala, ForceMode.VelocityChange);
        }
        
        destruyetepa = true;

     if (other.collider.tag == "Blanco")
        {
            Debug.Log("ERES UNA MIERDA");
            other.collider.SendMessage("AplicaDamage", 200);
        }

        ContactPoint contacto = other.contacts[0];
        Vector3 pos2 = contacto.point;

        // Creo un decall.
        Quaternion rotDecall = Quaternion.FromToRotation(Vector3.up, contacto.normal);
        GameObject DecallObj = Instantiate(decall, pos2, rotDecall);
        DecallObj.transform.parent = other.transform;

        /**/
        /*Vector3 _posAux = DecallObj.transform.localPosition;
        _posAux.y += 0.1f;
        DecallObj.transform.localPosition = _posAux;*/
        DecallObj.transform.position += DecallObj.transform.up * 0.03f;


        if (other.collider.tag == "Enemy" && Time.time > siguiente)
        {
            other.collider.SendMessage("Posgay", transform.position, SendMessageOptions.DontRequireReceiver);
            other.collider.SendMessage("Aplicacriticks", 1, SendMessageOptions.DontRequireReceiver);
            other.collider.SendMessage("AplicaDamage4", damagehomogay, SendMessageOptions.DontRequireReceiver);
            other.collider.SendMessage("AplicaStun", stun, SendMessageOptions.DontRequireReceiver);

            ContactPoint follame = other.contacts[0];
            Vector3 posgay = follame.point;
            Quaternion rotgay = Quaternion.FromToRotation(Vector3.up, follame.normal);

            other.collider.SendMessage("sangrecilla2", follame, SendMessageOptions.DontRequireReceiver);

            // GameObject puto = Instantiate(sangre, posgay, rotgay);
            // puto.transform.position += puto.transform.up * 0.03f;

            siguiente = Time.time + 0.15f;

        }

        }
 
    void AutoDestroy()
    {
        if (ballesta) { return; }

        if (sonidobum != null)
        {
            Instantiate(sonidobum, transform.position, transform.rotation);
        }
        
        Destroy(gameObject);
    }

}


