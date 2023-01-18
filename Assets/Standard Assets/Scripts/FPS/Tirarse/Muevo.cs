using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Muevo : MonoBehaviour
{

    //velocidad normal = 9f, velocidad corriéndose = 15f
    public float speed = 15.0F; //17 es el weno
    public float jumpSpeed = 8.0F;
    public float gravity = 150.0F;
    public Vector3 moveDirection = Vector3.zero;
    public Vector3 moveDirectionInput = Vector3.zero;
    public float impulsosalto = 1;
    public float acelstraf = 0.1f;
    public float multistraf = 3f;
    public Vector3 dashdirection;
    public static float velocidad;
    public static bool movimientochingon;
    public float timer = 0;
    public static float eh;
    public float acel = 0;
    private bool dasheando = false;
    public float mult = 40;
    public float multact = 0;
    private bool desac = true;
    public float tiempo = 0;
    public float t = 0.2f;
    public float t2 = 0.2f;
    public float impulso = 22;
    public int contsaltos = 0;
    public int contdashes = 2;
    public float reanudadorgrav = 3;
    private bool manual = false;
    private bool volver = true;
    public float tiempodash = 1;
    private float tiempodashprev = 1;
    private bool cagada = false;
    public GameObject sonidopref;
    public AudioClip[] dash;
    public AudioClip[] cosa;
    public Image[] sprite;
    public Color[] oh;
    private bool lehedao = false;
    private CharacterController controller;
    private bool paraostia = false;
    [HideInInspector]
    public Vector3 momentum;
    public Transform mirador;
    public Transform mirador2;

    private bool gancho = false;
    private bool arrastre = false;
    public float VelocidadLateral = 1;
    public float VelocidadAcercar = 40;
    private Vector3 momentumgay = Vector3.zero;
    public Transform voypalla;
    private float disgancho = 0;
    private float offsetaltura = 3.5f;
    private Transform targetgay;
    public float timergay = 0;

    public AudioClip[] meathook;

    Coroutine garchar = null;


    void Start()
    {
        if (Controlador.acabado)
        {
            //Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
        // StartCoroutine(CalcVelocity());
        desac = true;
        controller = GetComponent<CharacterController>();

        sprite[0] = GameObject.Find("ESPRAIT1").GetComponent<Image>();
        sprite[1] = GameObject.Find("ESPRAIT2 (1)").GetComponent<Image>();
        sprite[4] = GameObject.Find("ESPRAIT2 (2)").GetComponent<Image>();
        sprite[2] = GameObject.Find("imagengay1").GetComponent<Image>();
        sprite[3] = GameObject.Find("imagengay2").GetComponent<Image>();

        StartCoroutine("CalcVelocity");


    }

    void Offdash()
    {
        dasheando = false;
        desac = true;
        paraostia = false;
    }

    void vulvar()
    {
        volver = true;
    }

    void Update()
    {

        if (Controlador.acabado)
        {
            GetComponent<CharacterController>().enabled = false;
            enabled = false;
            return;
        }

        // if (velocidad > 0.1f)
        //   {
        //       movimientochingon = true;
        //   }
        //  if (velocidad < 0.1f)
        //  {
        //      movimientochingon = false;
        //  }

        sprite[0].fillAmount = Controlador.desfibrilador / 2;
        
        sprite[1].fillAmount = tiempodash / 0.5f;
        sprite[4].fillAmount = (tiempodash -0.5f) / 0.5f;

        if (Controlador.desfibrilador == 2)
        {
            sprite[2].color = oh[0];
        }
        else
        {
            sprite[2].color = oh[1];
        }
       
        if (tiempodash == 1)
        {
            sprite[3].color = oh[0];
        }
        else
        {
            sprite[3].color = oh[1];
        }

        if (Salto.tierra)
        {
            contsaltos = 2;

            if (!dasheando)
            {
                /*
                moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")); //MOVIMIENTO NORMAL
                FPCStatus.movimiento = moveDirection;
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection = moveDirection.normalized;
                moveDirection *= speed;
                */
                MovimientoNormal();
            }
                    
        }
        else
        {
            if (!dasheando)
            {

                Vector3 RawInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
                float mag = RawInput.magnitude;
                RawInput = RawInput.normalized;
                if (mag < 0.9f && mag > 0f) { RawInput *= mag; Debug.Log(mag); }


                float prcdis1 = Vector3.Distance(RawInput, moveDirectionInput) / 2;
                float prcdis2 = (2 * prcdis1) - 1; prcdis2 = Mathf.Clamp(prcdis2, 0, 1);


                moveDirectionInput = Vector3.MoveTowards(moveDirectionInput, RawInput, ((acelstraf + ((prcdis2 * multistraf) * Time.deltaTime)) / 0.0155f) * Time.deltaTime);


                    Vector2 penis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                    float magay = Mathf.Clamp(penis.magnitude, 0, 1);
                    moveDirection = Vector3.MoveTowards(moveDirection, Vector3.zero, (t / 0.005f) * Time.deltaTime);

                    Vector3 ah = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
                    ah = transform.TransformDirection(ah);
                    ah = ah.normalized;
                    ah *= speed;

                    moveDirection = Vector3.MoveTowards(moveDirection, ah, (((t2 - t) * magay) / 0.005f) * Time.deltaTime);
               




                }
        }
        if (Input.GetButtonDown("Salto") && !gancho)
        {
            if (desac == true && volver && contsaltos > 0)
            {
                if (!Salto.tierra)
                {
                    if (contsaltos == 2) { contsaltos = 1; }
                }
                if (contsaltos == 2)
                {
                    timer = 18f;
                }
                else //22 por salto, 44 en total
                {
                    timer = 26f;
                    GameObject follar = Instantiate(sonidopref, transform.position, Quaternion.identity);
                    follar.GetComponent<AudioSource>().PlayOneShot(cosa[2]);
                    follar.GetComponent<AudioSource>().volume = 0.8f * Controlador.volumenef;
                }
                
               // timer = impulso;

                
                   

                acel = 0;
                dasheando = false;
                multact = 1;
                desac = true;
                tiempo = 0;
                contsaltos--;
                volver = false;
                CancelInvoke("vulvar");
                Invoke("vulvar", 0.1f);

                if (contsaltos > 0 && timergay < 0.17f)
                {
                    timergay = 0;
                    impulsosalto += 0.2f;
                    if (impulsosalto > 1.4f) { impulsosalto = 1.4f; }
                }
                else
                {
                    impulsosalto = 1;
                }

                timergay = 0;
            }
        }
        if (controller.isGrounded)
        {
            acel = 0;
        }
        if ((controller.collisionFlags == CollisionFlags.Below))
        {
            acel = 0;
        }

        if (Salto.tierra)
        {
            if (!paraostia)
            {
                tiempodashprev = tiempodash;
                tiempodash += Time.deltaTime;
                tiempodash = Mathf.Clamp(tiempodash, 0, 1);
            }
        }
        else if (contdashes < 2)
        {
            if (!paraostia)
            {
                tiempodashprev = tiempodash;
                tiempodash += Time.deltaTime;
                tiempodash = Mathf.Clamp(tiempodash, 0, 0.95f);
            }
        }

        if (tiempodash > 0.5f && tiempodash < 1 && contdashes == 0) {

            lehedao = false;

            if (!cagada) {

                contdashes = 1;
               // a2.Stop(); a2.PlayOneShot(cosa[0]);
                lehedao = true;
            }

        }
        if (tiempodash == 1 && tiempodashprev != tiempodash)
        {
            tiempodashprev = tiempodash;

            if (contdashes == 1)
            {

                GameObject follar = Instantiate(sonidopref, transform.position, Quaternion.identity);
                follar.GetComponent<AudioSource>().PlayOneShot(cosa[0]);
                follar.GetComponent<AudioSource>().volume = 0.75f * Controlador.volumenef;
                lehedao = true;
            }
            else
            {

                GameObject follar = Instantiate(sonidopref, transform.position, Quaternion.identity);
                follar.GetComponent<AudioSource>().PlayOneShot(cosa[1]);
                follar.GetComponent<AudioSource>().volume = 0.8f * Controlador.volumenef;
                lehedao = true;
            }

        }
       
        if (tiempodash == 1) { contdashes = 2; cagada = false; }

        if (Input.GetButtonDown("Dash") && desac && contdashes > 0 && !gancho)
        {
            dashdirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            dashdirection = transform.TransformDirection(dashdirection);
            dashdirection = dashdirection.normalized;

            moveDirection = Vector3.zero;
            moveDirectionInput = Vector3.zero;
            momentumgay = Vector3.zero;

            if (Mathf.Abs(dashdirection.x) == 0 && Mathf.Abs(dashdirection.z) == 0)
            {
                dashdirection.z = 1;
                dashdirection = transform.TransformDirection(dashdirection);
                dashdirection = dashdirection.normalized;
             //   moveDirection *= 9;
            }
           
                desac = false;
                multact = mult * 9;
                dasheando = true;
            CancelInvoke("Offdash");    
            Invoke("Offdash", 0.2f);
            paraostia = true;
            tiempo = 0;
            contdashes--;
            manual = false;
            GameObject follar = Instantiate(sonidopref, transform.position, Quaternion.identity);
            follar.GetComponent<AudioSource>().PlayOneShot(dash[Random.Range(0, dash.Length)], 1f);
            follar.GetComponent<AudioSource>().volume = 0.8f * Controlador.volumenef;

            if (tiempodash < 1) { tiempodash = 0; cagada = true; }
            else { tiempodash = 0.5f; }
        }

        if (desac)                                                    //DASH
        {
            if (multact > reanudadorgrav * 9)
            {
                multact -= 107 * 9 * Time.deltaTime;
                multact = Mathf.Clamp(multact, 0, mult);
            }
            else
            {
                if (Salto.tierra)
                {
                    multact -= 8 * 9 * Time.deltaTime;
                    multact = Mathf.Clamp(multact, 0, mult);
                }
                else
                {
                    multact -= 4  * Time.deltaTime;
                    multact = Mathf.Clamp(multact, 0, mult);
                }
            }
        
        }
        

        if (Salto.tierra)
        {
            timergay += Time.deltaTime;
        }
       

        if (timer > 0)
        {
            acel = 0;

            moveDirection.y = timer;
            timer -= gravity * Time.deltaTime;
          //  timer = timer - 20 * Time.deltaTime;

        }
        if (timer == 0)                                             //SALTO
        {
            acel-= gravity * Time.deltaTime;
            moveDirection.y = acel;

        }
        if (timer == 0 && !Salto.tierra)
        {
            tiempo += Time.deltaTime;
        }





        if (multact == 0)
        {
            dasheando = false;
        }
        else if (!desac)                                    //DASH
        {
            dasheando = true;
            acel = 0;
            moveDirection.y = 0;
            moveDirection = Vector3.zero;
            moveDirectionInput = Vector3.zero;
        }
        if (multact > 3 * 9) //reanudador gravedad
        {
            dasheando = true;
            acel = 0;
            moveDirection.y = 0;
            
        }
        if (multact < reanudadorgrav * 9 && multact > 0)
        {
            dasheando = false;
        }
        if (multact > 5 * 9)
        {
            tiempo += Time.deltaTime;
        }

        acel = Mathf.Clamp(acel, -30, 0);
        timer = Mathf.Clamp(timer, 0, 200);


        float prop = speed / 15;
        float borra = 0.9f;

        if (gancho || arrastre)
        {
            moveDirection.x = 0;
            moveDirection.z = 0;
        }

        

        Vector3 moveDirection2 = new Vector3(moveDirection.x * impulsosalto, moveDirection.y, moveDirection.z * impulsosalto);
        controller.Move(moveDirection2 * Time.deltaTime);
        controller.Move(dashdirection * multact * prop * borra * Time.deltaTime);

        if (voypalla != null && !gancho)
        {
            //disgancho = Vector3.Distance(voypalla.position, new Vector3(transform.position.x, transform.position.y + offsetaltura, transform.position.z));
            Vector3 rel = mirador.position - voypalla.position;
            rel = rel.normalized * disgancho;
            voypalla.position = mirador.position - rel;
        }

        /*
        if (!gancho || !arrastre)
        {
            controller.Move(moveDirection * Time.deltaTime);
            controller.Move(dashdirection * multact * prop * borra * Time.deltaTime);
        }
       */
        // controller.Move(((dashdirection * multact) + moveDirection) * Time.deltaTime);

        // gay.text = moveDirection.y.ToString("F0");

        if (Input.GetMouseButtonDown(2) && DisparoSelectivo.NumeroArmagay == 2 && Time.time > Controlador.cd5ratio)
        {
            gestordemierda();
        }

        Vector2 dirgay = new Vector2(moveDirection.x, moveDirection.z);

        if (impulsosalto > 1f && Salto.tierra && timergay > 0.03f)
        {
            impulsosalto = Mathf.MoveTowards(impulsosalto, 1, 1f * Time.deltaTime);
        }
        if (impulsosalto > 1f && dirgay.magnitude < speed - 4)
        {
            impulsosalto = Mathf.MoveTowards(impulsosalto, 1, 6f * Time.deltaTime);
        }

        if (momentumgay.magnitude > 0)
        {
            Vector3 posgay = transform.position;
            arrastre = true;
            momentumgay.y = 0;
            Vector2 nor = new Vector2(momentumgay.x, momentumgay.z).normalized;
            Vector3 raw = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            float magay = raw.magnitude;
            raw = raw.normalized;
            if (magay < 1) { raw = raw * magay; }
            raw = transform.TransformDirection(raw);
            float variable = Mathf.Abs(nor.x - raw.x) + Mathf.Abs(nor.y - raw.z);
            variable *= 25;

            float suelo = 0;
            if (Salto.tierra) { suelo = 270; }

            magay = Mathf.Clamp(magay, 0, 1);
            Vector3 palante = transform.TransformDirection(Vector3.forward * magay);
            Vector2 palante2 = new Vector2(palante.x, palante.z);
            float magmierda = momentumgay.magnitude;
            Vector2 mom = new Vector2(momentumgay.x, momentumgay.z).normalized;
            mom = Vector2.MoveTowards(mom, palante2, 0.27f * Time.deltaTime);
            mom = mom.normalized; mom *= magmierda;
            momentumgay.x = mom.x; momentumgay.z = mom.y;

            palante = transform.TransformDirection(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")));
            palante2 = new Vector2(palante.x, palante.z).normalized;
            magmierda = momentumgay.magnitude;
            mom = new Vector2(momentumgay.x, momentumgay.z).normalized;
            mom = Vector2.MoveTowards(mom, palante2, 1.25f * Time.deltaTime);
            mom = mom.normalized; mom *= magmierda;
            momentumgay.x = mom.x; momentumgay.z = mom.y;

            momentumgay = Vector3.MoveTowards(momentumgay, Vector3.zero, (1 + variable + suelo) * Time.deltaTime);
            controller.Move(momentumgay * Time.deltaTime);

            Vector3 pos2 = transform.position - posgay;
            RaycastHit hit;
            int layerMask = 1 << 15;
            //Debug.DrawRay(transform.position, momentumgay, Color.green);

            if (Physics.Raycast(transform.position, momentumgay, out hit, 2.7f, layerMask))
            {
                //float angle = Vector3.SignedAngle(momentumgay, -hit.normal, Vector3.up);
                momentumgay = Vector3.zero;
                arrastre = false;
            }

            if (momentumgay.magnitude < speed)
            {
                moveDirection = new Vector3(momentumgay.x, moveDirection.y, momentumgay.y);
                momentumgay = transform.InverseTransformDirection(momentumgay);

                float magshit = momentumgay.magnitude / speed;
                Vector2 putitas = new Vector2(momentumgay.x, momentumgay.z).normalized;
                putitas *= magshit;

                moveDirectionInput = new Vector3(putitas.x, 0, putitas.y);
                
                momentumgay = Vector3.zero;
                arrastre = false;
            }
        }
        else
        {
            arrastre = false;
        }

    }

    IEnumerator CalcVelocity() //DETECTA LA VELOCIDAD DE MOVIMIENTO ES LA POLLA TIO
    {
        while (Application.isPlaying)
        {
            Vector3 prevPos = transform.position;
            yield return new WaitForEndOfFrame();
            momentum = (transform.position - prevPos) / Time.deltaTime;
        }
    }


    void MovimientoNormal()
    {
        // moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")); //MOVIMIENTO NORMAL

        Vector3 RawInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        float mag = RawInput.magnitude;
        RawInput = RawInput.normalized;
        if (mag < 1f && mag > 0f) { RawInput *= mag; Debug.Log(mag); }

        float acelstraf2 = acelstraf * (speed / 21);
        float multistraf2 = multistraf * (speed / 21);
        

        /*
        float prcdis1 = Vector3.Distance(RawInput, moveDirectionInput) / 2;
        float prcdis2 = (2 * prcdis1) - 1; prcdis2 = Mathf.Clamp(prcdis2, 0, 1);


        moveDirectionInput = Vector3.MoveTowards(moveDirectionInput, RawInput, ((acelstraf + ((prcdis2 * multistraf) * Time.deltaTime)) / 0.0155f) * Time.deltaTime); //22
        */
        float sex = 1;
        if (RawInput.x > 0 && moveDirectionInput.x < 0 || RawInput.x < 0 && moveDirectionInput.x > 0) {

            sex = 1;
        }
        else
        {
            sex = 0;
        }

        float factor = 0.0155f;

        moveDirectionInput.x = Mathf.MoveTowards(moveDirectionInput.x, RawInput.x, ((acelstraf2 + ((sex * multistraf2))) / factor) * Time.deltaTime);
        //moveDirectionInput.x = Mathf.MoveTowards(moveDirectionInput.x, RawInput.x, ((acelstraf2 + ((sex * multistraf2) * Time.deltaTime)) / 0.0155f) * Time.deltaTime);
        //multistraf = 5

        if (RawInput.z > 0 && moveDirectionInput.z < 0 || RawInput.z < 0 && moveDirectionInput.z > 0)
        {

            sex = 1;
        }
        else
        {
            sex = 0;
        } //0.078f, 8

        moveDirectionInput.z = Mathf.MoveTowards(moveDirectionInput.z, RawInput.z, ((acelstraf2 + ((sex * multistraf2) )) / factor) * Time.deltaTime);
        //moveDirectionInput.z = Mathf.MoveTowards(moveDirectionInput.z, RawInput.z, ((acelstraf2 + ((sex * multistraf2) * Time.deltaTime)) / 0.0155f) * Time.deltaTime);

        moveDirection = new Vector3(moveDirectionInput.x, moveDirection.y, moveDirectionInput.z);
        FPCStatus.movimiento = moveDirection;
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
    }

    void gestordemierda()
    {
        if (FPCStatus.transicion || FPCStatus.isReloading) { return; }

        var layerMask2 = (1 << 14);
        Collider[] penes = Physics.OverlapSphere(transform.position, 100, layerMask2);
        float angulo = 360;
        Transform elegido = null;


        for (int i = 0; i < penes.Length; i++)
        {
            if (penes[i].CompareTag("micuerpochingon")) { continue; }

            if (penes[i].GetComponent<agarre2>().admisible()) {

                RaycastHit hit;
                int layerMask = 1 << 15;
                Vector3 penis = penes[i].transform.position - transform.position;
                if (Physics.Raycast(transform.position, penis, out hit, penis.magnitude - 0.5f, layerMask))
                {
                    continue;
                }

                Vector3 targetDir = penes[i].transform.root.position - new Vector3(transform.position.x, penes[i].transform.root.position.y, transform.position.z);
                float angle = Vector3.SignedAngle(targetDir, transform.forward, Vector3.up);

                if (Mathf.Abs(angle) < angulo)
                {
                    angulo = Mathf.Abs(angle);
                    elegido = penes[i].transform.root;
                }
            }              

        }

        

        if (elegido == null || FPCStatus.transicion)
        {
            Debug.Log(elegido);
            Debug.Log(FPCStatus.transicion);
            return;
        }

        Controlador.cd5ratio = Time.time + Controlador.cd5;
        if (garchar != null) { StopCoroutine(garchar); }
        ManageEnemyStatus1 salud = null;
        salud = elegido.GetComponent<ManageEnemyStatus1>();
        if (elegido.GetComponent<AIRobotCyborg>() != null) { elegido = elegido.GetChild(0).GetChild(3); }
        
        garchar = StartCoroutine(ganchear(elegido, salud));
    }

    IEnumerator ganchear(Transform sex, ManageEnemyStatus1 salud)
    {
        volvedzorras();
        targetgay = sex;
        disgancho = 0;
        if (voypalla != null) { Destroy(voypalla.gameObject); }
        voypalla = new GameObject().transform;
        if (mirador2 != null) { Destroy(mirador2.gameObject); }
        mirador2 = new GameObject().transform;

        Vector3 posgay = sex.position - transform.position;
        posgay = posgay.normalized * disgancho;
        voypalla.position = transform.position + (Vector3.up * offsetaltura) + posgay;
        mirador2.position = mirador.position;
        //mirador.position = transform.position + (Vector3.up * offsetaltura);
        transform.root.GetComponent<AudioSource>().PlayOneShot(meathook[Random.Range(0, meathook.Length)], 0.7f);

        while (true)
        {
            Controlador.cd5ratio = Time.time + Controlador.cd5;

            disgancho += 180 * Time.deltaTime;
            
            Vector3 des = (sex.position + (Vector3.up * offsetaltura)) - (mirador.position + (Vector3.up * offsetaltura));
            des = des.normalized * disgancho;
            voypalla.position = transform.position + (Vector3.up * offsetaltura) + des;

            float relsex = Vector3.Distance(voypalla.position, mirador.position);
            float relsex3 = Vector3.Distance(sex.position + (Vector3.up * offsetaltura), mirador.position);

            //float angle = Vector3.SignedAngle(relsex2, relsex, Vector3.up);
            //Debug.Log(angle);
            //if (angle > 50) { voypalla.position = sex.position + (Vector3.up * offsetaltura); }

            //if (angle > 50) { voypalla.position = sex.position + (Vector3.up * offsetaltura); }
            

            mirador2.position = mirador.position;
            mirador2.rotation = mirador.rotation;

            Vector3 player = mirador2.position;
            Vector3 target = sex.position + (Vector3.up * offsetaltura);
            if (relsex > relsex3) { voypalla.position = sex.position + (Vector3.up * offsetaltura); target = voypalla.position; }

            Vector3 relpos = target - player;

            mirador2.rotation = Quaternion.FromToRotation(Vector3.forward, relpos);

            //Cadenas(relpos);
            Cadenas();


            if (voypalla.position == sex.position + (Vector3.up * offsetaltura ) || FPCStatus.cambioarma || FPCStatus.isReloading) { break; }
            yield return null;
        }

        gancho = true;

        Vector3 lastpos = transform.position;
        Vector3 newpos = transform.position;

        momentumgay = Vector3.zero;
        Vector3 lateral = Vector3.zero;
        Vector3 pollas = Vector3.zero;

        float dir = 0;
        GameObject buscar = sex.gameObject;

        while (true)
        {

            if (sex == null || salud.health <= 0 || FPCStatus.cambioarma || FPCStatus.isReloading) { Vector3 momentumgay2 = (lateral.normalized * 20) + pollas; momentumgay = momentumgay2.normalized * pollas.magnitude; break; }
            

            moveDirection = Vector3.zero;
            moveDirectionInput = Vector3.zero;

            lastpos = transform.position;

            yield return null;
            if (sex == null || salud.health <= 0) { Vector3 momentumgay2 = (lateral.normalized * 20) + pollas; momentumgay = momentumgay2.normalized * pollas.magnitude; break; }

            

            pollas = ((sex.position - transform.position).normalized) * VelocidadAcercar;
            controller.Move(pollas * Time.deltaTime);

           

            newpos = lastpos - transform.position;
            Vector3 lol = sex.position - transform.position;
            float mag = lol.magnitude;

            mirador.rotation = Quaternion.LookRotation(lol, Vector3.up);

            dir = Mathf.MoveTowards(dir, Input.GetAxisRaw("Horizontal"), 0.1f * Time.deltaTime);
            lateral = mirador.TransformDirection(new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0) * VelocidadLateral);
            controller.Move(lateral * Time.deltaTime);
            lol = (transform.position - sex.position).normalized;
            lol *= mag;
            Vector3 pos = sex.position + lol;
            Vector3 relposgay = pos - transform.position;
            controller.Move(relposgay);
            //transform.position = pos;
            voypalla.position = sex.position + (Vector3.up * offsetaltura);
            mirador2.position = mirador.position;

            Vector3 player = mirador2.position;
            Vector3 target = sex.position + (Vector3.up * offsetaltura);

            Vector3 relpos = target - player;

            mirador2.rotation = Quaternion.FromToRotation(Vector3.forward, relpos);

            Controlador.cd5ratio = Time.time + Controlador.cd5;

            Cadenas();

            if (Input.GetButtonDown("Salto"))
            {           
                Vector3 momentumgay2 = (lateral.normalized * 20) + pollas;
                momentumgay = momentumgay2.normalized * pollas.magnitude;
                pollas.y = 35;
                timer = pollas.y;

                if (contsaltos == 0) { contsaltos = 2; }
                //volvedzorras();
                break;
            }

            if (newpos.magnitude < (VelocidadAcercar - 20) * Time.deltaTime || Vector3.Distance(transform.position, sex.position) < 6)
            {
                Vector3 momentumgay2 = (lateral.normalized * 20) + pollas;
                momentumgay = momentumgay2.normalized * pollas.magnitude;
                //volvedzorras();

                break;
            }
        }

        gancho = false;
        disgancho = Vector3.Distance(voypalla.position, mirador.position);

        while (true)
        {
            if (FPCStatus.cambioarma || FPCStatus.isReloading) { break; }
            voypalla.position = Vector3.MoveTowards(voypalla.position, mirador.position, 85 * Time.deltaTime);
            disgancho = Vector3.Distance(voypalla.position, mirador.position);
            mirador2.position = mirador.position;

            Vector3 target = voypalla.position - mirador2.position;
            Cadenas();
            if (voypalla.position == mirador.position) { break; }
            mirador2.rotation = Quaternion.LookRotation(target, Vector3.up);
            yield return null;
        }

        volvedzorras();
        if (voypalla != null) { Destroy(voypalla.gameObject); }
        voypalla = null;
    }

    void Cadenas()
    {
            float dis = 0;
            float longitud = 0.347412f;
            if (mirador2.childCount > 0)
            {
                Transform ult = mirador2.GetChild(mirador2.childCount - 1).transform.GetChild(0).GetChild(0);
                dis = Vector3.Distance(ult.position, mirador2.position);
                float dis2 = Vector3.Distance(mirador2.position, voypalla.position);
                dis = dis2 - dis;
            }
            else
            {
                dis = Vector3.Distance(voypalla.position, mirador2.position);
            }
            Transform cadenitas = GameObject.Find("Cadenas").transform;
            //Debug.Log(dis);

            while (dis > longitud)
            {
                dis = dis - longitud;
                if (cadenitas.childCount == 0) { return; }
                Transform sig = cadenitas.GetChild(0).transform;
            

            if (mirador2.childCount == 0)
                {
                
                sig.position = mirador2.position;
                    //sig.localEulerAngles = new Vector3(0, 0, -90);
                Vector3 rel = (targetgay.position + (Vector3.up * offsetaltura)) - mirador2.position;
                    sig.rotation = Quaternion.LookRotation(rel, Vector3.up);
                    sig.rotation = mirador2.rotation;
                sig.parent = mirador2;
            }
                else
                {

                sig.position = mirador2.GetChild(mirador2.childCount - 1).transform.GetChild(0).GetChild(0).position;
                    sig.rotation = mirador2.GetChild(0).rotation;
                sig.parent = mirador2;
            }
                
                sig.gameObject.SetActive(true);
        }
            while(dis < longitud)
            {
            
            dis = dis + longitud;
            if (mirador2.childCount == 0) { return; }
            GameObject sig = mirador2.GetChild(mirador2.childCount - 1).gameObject;
            sig.transform.parent = cadenitas;
            sig.SetActive(false);
        }
     
    }

    public void volvedzorras()
    {
        if (mirador2 == null || mirador2.childCount == 0) { return; }

        Transform cadenitas = GameObject.Find("Cadenas").transform;
        while (mirador2.childCount > 0)
        {
            GameObject sig = mirador2.GetChild(0).gameObject;
            sig.transform.parent = cadenitas;
            sig.SetActive(false);
        }
        if (mirador2 != null) { Destroy(mirador2.gameObject); }
        mirador2 = null;
    }

    public static void Sacabo()
    {
        Controlador.acabado = true;
        //Destroy(GameObject.FindGameObjectWithTag("Player"));
        //Destroy(GetComponent<Muevo>());
    }
            


}