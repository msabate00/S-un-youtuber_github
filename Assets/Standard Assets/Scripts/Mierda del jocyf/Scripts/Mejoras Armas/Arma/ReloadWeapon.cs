using UnityEngine;
using System.Collections;

public class ReloadWeapon : MonoBehaviour
{
    public GameObject BulletPrefab;
    private GunStatus GunStatusScript;
    private DisparoSelectivo DisparoSelectivoSrc;
    [HideInInspector]
    public float delay;
    private bool manual;
    private bool arma1;
    private bool doble = false;
    private int balasact;
    private bool derecha = false;
    public recargas[] audios;
    public AudioSource aud;

    void OnEnable()
    {
        DisparoSelectivoSrc = GetComponent<DisparoSelectivo>();
        FPCStatus.isReloading = false;

    }


    void Update()
    {
        if (Controlador.acabado)
        {
            return;
        }

        GunStatusScript = DisparoSelectivoSrc.Armas[DisparoSelectivoSrc.NumeroArma].GetComponent<GunStatus>(); /**/
        if (Input.GetButtonDown("Reload") && !FPCStatus.IsJumping && !FPCStatus.transicion && !GunStatusScript.dual)
        {
            if (FPCStatus.isReloading) { return; }
            if (GunStatusScript.BalasActualesEnCargador == GunStatusScript.BalasTotalesPorCargador) { return; } // NO recargar si tenemos todas las balas.
            if (GunStatusScript.CargadoresActuales == 0) { return; }
            manual = false;
            StartCoroutine(_ReloadWeapon(GunStatusScript, false, false));
        }
        if (Input.GetButtonDown("Fire1") && !FPCStatus.IsJumping && !FPCStatus.transicion && GunStatusScript.BalasActualesEnCargador == 0 && !GunStatusScript.dual || Input.GetButtonDown("Fire2") && DisparoSelectivoSrc.GunStatusScript.Tipo == TiposDisparo.Escoputa && !FPCStatus.IsJumping && !FPCStatus.transicion && GunStatusScript.BalasActualesEnCargador == 0 && !GunStatusScript.dual)
        {
            if (FPCStatus.isReloading) { return; }
            if (GunStatusScript.BalasActualesEnCargador == GunStatusScript.BalasTotalesPorCargador) { return; } // NO recargar si tenemos todas las balas.
            if (GunStatusScript.CargadoresActuales == 0) { return; }
            manual = false;
            StartCoroutine(_ReloadWeapon(GunStatusScript, false, false));
        }


        if (Input.GetButtonDown("Fire1") && GunStatusScript.Armasgays == Armasgaystipos.Duales1 || Input.GetButtonDown("Fire2") && GunStatusScript.Armasgays == Armasgaystipos.Duales1) 
        {
            if (FPCStatus.isReloading) { return; }
            if (GunStatusScript.BalasActualesEnCargador == 0 && GunStatusScript.arma2.BalasActualesEnCargador == 0 && !GunStatusScript.recargando && !GunStatusScript.arma2.recargando) { recargadual(); return; } // NO recargar si tenemos todas las balas.
            if (GunStatusScript.BalasActualesEnCargador > 0 && GunStatusScript.arma2.BalasActualesEnCargador > 0) { return; }
            if (GunStatusScript.CargadoresActuales == 0) { return; }


            if (Input.GetButtonDown("Fire1"))
            {
                derecha = false;
            }
            else
            {
                derecha = true;
            }
           
            if (derecha && !GunStatusScript.arma2.recargando && GunStatusScript.arma2.BalasActualesEnCargador == 0 && !FPCStatus.isReloading)
            {
                StartCoroutine(_ReloadWeapon(GunStatusScript.arma2, false, false));
            }
            if (!derecha && !GunStatusScript.recargando && GunStatusScript.BalasActualesEnCargador == 0 && !FPCStatus.isReloading)
            {
                StartCoroutine(_ReloadWeapon(GunStatusScript, false, false));
            }
                
   
            manual = false;

        }

        if (Input.GetButtonDown("Reload") && GunStatusScript.dual && GunStatusScript.Armasgays == Armasgaystipos.Duales1 && !FPCStatus.isReloading)
        {
            recargadual();
        }

        if (Input.GetButtonDown("Reload") && GunStatusScript.dual && GunStatusScript.Armasgays == Armasgaystipos.Duales2)
        {
            if ( !FPCStatus.IsJumping && !FPCStatus.transicion && GunStatusScript.arma2.BalasActualesEnCargador < GunStatusScript.arma2.BalasTotalesPorCargador && GunStatusScript.BalasActualesEnCargador < GunStatusScript.BalasTotalesPorCargador)
            {
                if (FPCStatus.isReloading) { return; }
                if (GunStatusScript.BalasActualesEnCargador == GunStatusScript.BalasTotalesPorCargador && GunStatusScript.arma2.BalasActualesEnCargador == GunStatusScript.arma2.BalasTotalesPorCargador) { return; }
                if (GunStatusScript.CargadoresActuales == 0) { return; }

                StartCoroutine(_ReloadWeapon2(GunStatusScript, true, true));
                DisparoSelectivoSrc.cola = false;
            }
        }
        if (Input.GetButtonDown("Fire1") && !FPCStatus.IsJumping && !FPCStatus.transicion && !FPCStatus.isReloading && GunStatusScript.Armasgays == Armasgaystipos.Duales2) {

            if (GunStatusScript.BalasActualesEnCargador == 0 && GunStatusScript.CargadoresActuales > 0 && GunStatusScript.arma2.BalasActualesEnCargador == 0)
            {
                                 
                StartCoroutine(_ReloadWeapon2(GunStatusScript, true, true));
                DisparoSelectivoSrc.cola = false;
            }
           

        }

    }

    void sexualizar()
    {
        StartCoroutine(audiosgays(2));
    }

    void recargadual()
    {
        
        if (GunStatusScript.arma2.BalasActualesEnCargador < GunStatusScript.arma2.BalasTotalesPorCargador && GunStatusScript.BalasActualesEnCargador < GunStatusScript.BalasTotalesPorCargador && !GunStatusScript.recargando && !GunStatusScript.arma2.recargando)
        {
            if (GunStatusScript.BalasActualesEnCargador == GunStatusScript.BalasTotalesPorCargador) { return; } // NO recargar si tenemos todas las balas.
            if (GunStatusScript.arma2.BalasActualesEnCargador == GunStatusScript.arma2.BalasTotalesPorCargador) { return; }
            if (GunStatusScript.CargadoresActuales == 0) { return; }
            if (GunStatusScript.arma2.CargadoresActuales == 0) { return; }
            if (FPCStatus.isReloading) { return; }
            manual = true;
            doble = true;
            StartCoroutine(_ReloadWeapon(GunStatusScript, true, true));
            return;
        }
        else if (!FPCStatus.IsJumping && !FPCStatus.transicion)
        {
            if (FPCStatus.isReloading) { return; }
            if (GunStatusScript.BalasActualesEnCargador == GunStatusScript.BalasTotalesPorCargador && GunStatusScript.arma2.BalasActualesEnCargador == GunStatusScript.arma2.BalasTotalesPorCargador) { return; }
            if (GunStatusScript.CargadoresActuales == 0 && GunStatusScript.arma2.CargadoresActuales == 0) { return; }

            if (GunStatusScript.arma2.BalasActualesEnCargador < GunStatusScript.arma2.BalasTotalesPorCargador) { manual = false; StartCoroutine(_ReloadWeapon(GunStatusScript.arma2, false, false)); }
            if (GunStatusScript.BalasActualesEnCargador < GunStatusScript.BalasTotalesPorCargador) { manual = false; StartCoroutine(_ReloadWeapon(GunStatusScript, false, false)); }


        }
        if (FPCStatus.isShooting)
        {
            // PlayFireAnimation();  pos no lo activo jejejejej gilipollas
        }
    }
    
    public void SetSpeed(float n)
    {
        foreach (AnimationState state in GunStatusScript.AnimacionesArma.GetComponent<Animation>())
        {
            state.speed = n;
        }
    }

    public void PlayFireAnimation()
    {
        if (GunStatusScript.AnimacionesArma != null)
        {
            GunStatusScript.AnimacionesArma.GetComponent<Animation>()["disparo"].speed = 1;
            GunStatusScript.AnimacionesArma.GetComponent<Animation>().Play("disparo");
            PlayBullets();
        }
    }

    // Dispara casquillos al disparar
    public void PlayBullets()
    {
        if (GunStatusScript.PuntoCasquillo == null) { return; }

        GameObject Casquillo = Instantiate(BulletPrefab, GunStatusScript.PuntoCasquillo.position, GunStatusScript.PuntoCasquillo.rotation);
        Vector3 direction = transform.TransformDirection(Vector3.right);
        Vector3 Bulletdirection = SprayDirection(direction);
        Bulletdirection.x = Bulletdirection.x + (GunStatusScript.Aceleracion * 2);
        Casquillo.GetComponent<Rigidbody>().AddRelativeForce(Bulletdirection, ForceMode.VelocityChange);
    }

    public Vector3 SprayDirection(Vector3 direction)
    {
        direction.x = direction.x + ((1 - (2 * Random.value)) * 0.5f);
        direction.y = direction.y + ((1 - (2 * Random.value)) * 0.5f);
        return direction;
    }

    public void ReloadWeaponSpawn()
    {
        DisparoSelectivoSrc.NumeroArma = GameMngr.numerogayarma;
       // NumeroArma = GameMngr.numerogayarma;
        GunStatusScript = DisparoSelectivoSrc.Armas[DisparoSelectivoSrc.NumeroArma].GetComponent<GunStatus>();
        if (GunStatusScript.CargadoresActuales > 0)
        {
            //  GunStatusScript.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("polladas");

           

            int balasputas = GunStatusScript.BalasActualesEnCargador;
            int balasputas2 = GunStatusScript.BalasTotalesPorCargador;
            int balasputas3 = GunStatusScript.CargadoresActuales;
            int balasputas4 = GunStatusScript.CargadoresActuales;
            int balasputas5 = GunStatusScript.BalasActualesEnCargador;
            int balasputas7 = balasputas4 += balasputas5;
            balasputas2 -= balasputas;
            if (balasputas7 >= GunStatusScript.BalasTotalesPorCargador)
            {
                GunStatusScript.BalasActualesEnCargador += balasputas2;
                GunStatusScript.CargadoresActuales -= balasputas2;
            }
            if (balasputas7 < GunStatusScript.BalasTotalesPorCargador)
            {
                GunStatusScript.BalasActualesEnCargador += GunStatusScript.CargadoresActuales;
                GunStatusScript.CargadoresActuales = 0;
            }
            if (GunStatusScript.CargadoresActuales < 0)
            {
                GunStatusScript.CargadoresActuales = 0;
            }
            // GunStatusScript.BalasActualesEnCargador = GunStatusScript.BalasTotalesPorCargador;  SOY DEMASIADO GUAY Y YO ME INVENTO MI PROPIO DE ESO VALE? POS VALE
            // GunStatusScript.CargadoresActuales--; 
        }
      
        FPCStatus.isReloading = false;
    }

    public IEnumerator _ReloadWeapon(GunStatus gunS, bool manualA, bool dobleA)
    {        
        
        balasact = gunS.BalasActualesEnCargador;
        
        delay = 0;

        if (!GunStatusScript.dual)
        {
            FPCStatus.isReloading = true;
            //FPCStatus.transicion = true;
        }
        else
        {
            if (dobleA)
            {
                FPCStatus.isReloading = true;
                //FPCStatus.transicion = true;
                gunS.recargando = true;
                gunS.arma2.recargando = true;

            }
            if (!dobleA)
            {
                if (gunS.arma2 != null) {
                  
                    FPCStatus.isReloading = true;
                    //FPCStatus.transicion = true;
                    gunS.recargando = true;
                }
                else
                {
                    gunS.recargando = true;
                    FPCStatus.isReloading = true;
                    //FPCStatus.transicion = true;
                }
            }
        }
        FPCStatus.IsAiming = false;
        GunStatusScript.transform.GetComponent<AimDownSights>().restablecer();
        if (GunStatusScript.arma2 != null)
        {
            GunStatusScript.arma2.transform.GetComponent<AimDownSights>().restablecer();
        }

        yield return new WaitForSeconds(delay);
        yield return new WaitForSeconds(0.1f);
        {
            

            gunS.AnimacionesArmagays.GetComponent<Animator>().enabled = true;
            if (manualA && gunS.dual && dobleA && gunS.arma2 != null)
            {
                gunS.arma2.AnimacionesArmagays.GetComponent<Animator>().enabled = true;
            }
            // GunStatusScript.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("pollones");
            gunS.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("polladas");
            gunS.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("polladas2");
            gunS.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("transigay");
            gunS.AnimacionesArmagays.GetComponent<Animator>().SetTrigger("polladas");
            gunS.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("pollones");

            if (manualA && GunStatusScript.dual && dobleA && GunStatusScript.CargadoresActuales > 1) {

                Debug.Log("WAT");
                if (gunS.arma2 != null)
                {
                    gunS.arma2.AnimacionesArmagays.GetComponent<Animator>().enabled = true;
                    // GunStatusScript.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("pollones");

                    gunS.arma2.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("polladas");
                    gunS.arma2.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("polladas2");
                    gunS.arma2.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("transigay");
                    gunS.arma2.AnimacionesArmagays.GetComponent<Animator>().SetTrigger("polladas");
                    gunS.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("pollones");
                }
            }
        }

        for(int i = 0; i < audios.Length; i++)
        {
            if (audios[i].Id == DisparoSelectivo.NumeroArmagay)
            {
                StartCoroutine(audiosgays(i));
                //aud.PlayOneShot(audios[i].Audio);
                break;
            }
        }

        if (GunStatusScript.AnimacionesArma != null)
        {
            //GunStatusScript.AnimacionesArma.GetComponent<Animation>().Play("recargahomosexual");
           // GunStatusScript.AnimacionesArma.GetComponent<Animation>()["recargahomosexual"].speed = 1;
        }
        yield return new WaitForSeconds(GunStatusScript.DuracionRecarga -0.2f);
        DisparoSelectivoSrc.ballestabala.SetActive(true);
        yield return new WaitForSeconds(0.2f);

        if (GunStatusScript.CargadoresActuales > 0)
        {
            //  GunStatusScript.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("polladas");

            if (manualA && GunStatusScript.dual && dobleA)
            {
              



                int a = GunStatusScript.BalasTotalesPorCargador - GunStatusScript.BalasActualesEnCargador;
                int ah = GunStatusScript.BalasTotalesPorCargador - GunStatusScript.arma2.BalasActualesEnCargador;


                int balas1 = (GunStatusScript.BalasTotalesPorCargador * 2) - GunStatusScript.BalasActualesEnCargador + GunStatusScript.arma2.BalasActualesEnCargador;
                if ((a+ah) > GunStatusScript.CargadoresActuales)
                {
                    /* Debug.Log("MACEDONIA");
                     balas1 = GunStatusScript.CargadoresActuales;
                     float balas2 = balas1; balas2 = balas2 / 2;
                     int balas3 = GunStatusScript.CargadoresActuales - Mathf.RoundToInt(balas2);

                     GunStatusScript.BalasActualesEnCargador = GunStatusScript.BalasActualesEnCargador + Mathf.RoundToInt(balas2);
                     GunStatusScript.arma2.BalasActualesEnCargador = GunStatusScript.arma2.BalasActualesEnCargador + balas3;
                     GunStatusScript.CargadoresActuales = GunStatusScript.CargadoresActuales - balas1;

                     GunStatusScript.BalasActualesEnCargador--;
                     GunStatusScript.arma2.BalasActualesEnCargador++;
                    */

                    bool a1 = false;
                    bool a2 = false;
                    bool oh = true;
                    while (GunStatusScript.CargadoresActuales > 0)
                    {
                        if (oh)
                        {
                            if (GunStatusScript.BalasActualesEnCargador < GunStatusScript.BalasTotalesPorCargador)
                            {
                                GunStatusScript.BalasActualesEnCargador++;
                                a1 = true;
                            }
                            else
                            {
                                oh = !oh;
                            }
                        }
                        else
                        {
                            if (GunStatusScript.arma2.BalasActualesEnCargador < GunStatusScript.BalasTotalesPorCargador)
                            {
                                GunStatusScript.arma2.BalasActualesEnCargador++;
                                a2 = true;
                                Debug.Log("WTF");
                            }
                            else
                            {
                                oh = !oh;
                            }
                                
                        }
                        GunStatusScript.CargadoresActuales--;
                        oh = !oh;
                    }

                    if (a1)
                    {
                        gunS.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("polladas2");
                        gunS.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("transigay");
                        gunS.AnimacionesArmagays.GetComponent<Animator>().SetTrigger("pollones");
                    }
                    if (a2)
                    {
                        Debug.Log("LOL");
                        gunS.arma2.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("polladas2");
                        gunS.arma2.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("transigay");
                        gunS.arma2.AnimacionesArmagays.GetComponent<Animator>().SetTrigger("pollones");
                    }


                }
                else
                {
                    Debug.Log("MACEDONIA2");
                    int balas2 = GunStatusScript.BalasTotalesPorCargador - GunStatusScript.BalasActualesEnCargador;
                    GunStatusScript.CargadoresActuales = GunStatusScript.CargadoresActuales - balas2;
                    GunStatusScript.BalasActualesEnCargador = GunStatusScript.BalasActualesEnCargador + balas2;

                    balas2 = GunStatusScript.BalasTotalesPorCargador - GunStatusScript.arma2.BalasActualesEnCargador;
                    GunStatusScript.CargadoresActuales = GunStatusScript.CargadoresActuales - balas2;
                    GunStatusScript.arma2.BalasActualesEnCargador = GunStatusScript.arma2.BalasActualesEnCargador + balas2;

                    GunStatusScript.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("polladas2");
                    GunStatusScript.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("transigay");
                    GunStatusScript.AnimacionesArmagays.GetComponent<Animator>().SetTrigger("pollones");
                    GunStatusScript.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("polladas");


                    GunStatusScript.arma2.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("polladas2");
                    GunStatusScript.arma2.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("transigay");
                    GunStatusScript.arma2.AnimacionesArmagays.GetComponent<Animator>().SetTrigger("pollones");
                    GunStatusScript.arma2.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("polladas");
                }
               

            }
            else
            {

                gunS.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("polladas2");
                gunS.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("transigay");
                gunS.AnimacionesArmagays.GetComponent<Animator>().SetTrigger("pollones");



                int balasputas = gunS.BalasActualesEnCargador;
                int balasputas2 = gunS.BalasTotalesPorCargador;
                int balasputas3 = GunStatusScript.CargadoresActuales;
                int balasputas4 = GunStatusScript.CargadoresActuales;
                int balasputas5 = gunS.BalasActualesEnCargador;
                int balasputas7 = balasputas4 += balasputas5;
                balasputas2 -= balasputas;
                if (balasputas7 >= gunS.BalasTotalesPorCargador)
                {
                    gunS.BalasActualesEnCargador += balasputas2;
                    GunStatusScript.CargadoresActuales -= balasputas2;
                }
                if (balasputas7 < gunS.BalasTotalesPorCargador)
                {
                    gunS.BalasActualesEnCargador += GunStatusScript.CargadoresActuales;
                    GunStatusScript.CargadoresActuales = 0;
                }
                if (GunStatusScript.CargadoresActuales < 0)
                {
                    GunStatusScript.CargadoresActuales = 0;
                }
            }
            // GunStatusScript.BalasActualesEnCargador = GunStatusScript.BalasTotalesPorCargador;  SOY DEMASIADO GUAY Y YO ME INVENTO MI PROPIO DE ESO VALE? POS VALE
            // GunStatusScript.CargadoresActuales--; 
            GameObject.Find("Controlador").GetComponent<normalizador>().actarmasrecarga();
        }
        yield return new WaitForSeconds(0.01f);
        {
            gunS.AnimacionesArmagays.GetComponent<Animator>().enabled = false;
            if (manualA && gunS.dual && dobleA && gunS.arma2 != null)
            {
                gunS.arma2.AnimacionesArmagays.GetComponent<Animator>().enabled = false;
            }
            //FPCStatus.transicion = false;
        }
        //DisparoSelectivoSrc.GUICargadores.text = GunStatusScript.CargadoresActuales.ToString();
        //DisparoSelectivoSrc.GUIBalas.text = GunStatusScript.BalasActualesEnCargador.ToString();
        // DisparoSelectivoSrc.UIBalas.text = GunStatusScript.CargadoresActuales.ToString() + "/" + GunStatusScript.BalasActualesEnCargador.ToString();
        if (manualA && GunStatusScript.dual && dobleA)
        {
            GunStatusScript.arma2.recargando = false;
            Debug.Log("FOLLAME PUTA");
            gunS.recargando = false;
            gunS.arma2.recargando = false;
        }
        gunS.recargando = false;
        FPCStatus.transicion = false;
        FPCStatus.isReloading = false;
        manual = false;
        doble = false;
    }

    public IEnumerator _ReloadWeapon2(GunStatus gunS, bool manualA, bool dobleA)
    {
        DisparoSelectivoSrc.NumeroArma = GameMngr.numerogayarma;
        // NumeroArma = GameMngr.numerogayarma;
        GunStatusScript = DisparoSelectivoSrc.Armas[DisparoSelectivoSrc.NumeroArma].GetComponent<GunStatus>();

        FPCStatus.isReloading = true;
        FPCStatus.IsAiming = false;
        GunStatusScript.transform.GetComponent<AimDownSights>().restablecer();
        if (GunStatusScript.arma2 != null)
        {
            GunStatusScript.arma2.transform.GetComponent<AimDownSights>().restablecer();
        }
        //FPCStatus.transicion = true;

        yield return new WaitForSeconds(delay);
        yield return new WaitForSeconds(0.1f);
        {

            gunS.AnimacionesArmagays.GetComponent<Animator>().enabled = true;
            gunS.arma2.AnimacionesArmagays.GetComponent<Animator>().enabled = true;

            // GunStatusScript.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("pollones");

            gunS.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("polladas2");
            gunS.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("transigay");
            gunS.AnimacionesArmagays.GetComponent<Animator>().SetTrigger("polladas");
            gunS.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("pollones");

            if (manualA && dobleA && GunStatusScript.CargadoresActuales > 1) {

                if (gunS.arma2 != null)
                {
                    gunS.arma2.AnimacionesArmagays.GetComponent<Animator>().enabled = true;
                    // GunStatusScript.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("pollones");

                    gunS.arma2.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("polladas2");
                    gunS.arma2.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("transigay");
                    gunS.arma2.AnimacionesArmagays.GetComponent<Animator>().SetTrigger("polladas");
                    gunS.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("pollones");
                }
            }
        }

        normalizador nor = Controlador.ah.gameObject.GetComponent<normalizador>();

        int veces = 0;

        if (nor.listagay2[4].BalasAct < GunStatusScript.BalasTotalesPorCargador && nor.listagay2[4].CargadoresAct > 0)
        {
            veces++;
        }
        if (nor.listagay2[4].BalasActArma2 < GunStatusScript.BalasTotalesPorCargador && nor.listagay2[4].CargadoresAct > 0)
        {
            if (nor.listagay2[4].CargadoresAct == 1 && veces == 1)
            {

            }
            else
            {
                veces++;
            }
            
        }

        if (veces == 1)
        {
            StartCoroutine(audiosgays(3));
        }
        else
        {
            StartCoroutine(audiosgays(2));
        }

        yield return new WaitForSeconds(gunS.DuracionRecarga);
        if (gunS.CargadoresActuales > 0)
        {
            //  GunStatusScript.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("polladas");

            if (manualA && GunStatusScript.dual && dobleA)
            {
              



                int a = GunStatusScript.BalasTotalesPorCargador - GunStatusScript.BalasActualesEnCargador;
                int ah = GunStatusScript.BalasTotalesPorCargador - GunStatusScript.arma2.BalasActualesEnCargador;


                int balas1 = (GunStatusScript.BalasTotalesPorCargador * 2) - GunStatusScript.BalasActualesEnCargador + GunStatusScript.arma2.BalasActualesEnCargador;
                if ((a+ah) > GunStatusScript.CargadoresActuales)
                {
                    /* Debug.Log("MACEDONIA");
                     balas1 = GunStatusScript.CargadoresActuales;
                     float balas2 = balas1; balas2 = balas2 / 2;
                     int balas3 = GunStatusScript.CargadoresActuales - Mathf.RoundToInt(balas2);

                     GunStatusScript.BalasActualesEnCargador = GunStatusScript.BalasActualesEnCargador + Mathf.RoundToInt(balas2);
                     GunStatusScript.arma2.BalasActualesEnCargador = GunStatusScript.arma2.BalasActualesEnCargador + balas3;
                     GunStatusScript.CargadoresActuales = GunStatusScript.CargadoresActuales - balas1;

                     GunStatusScript.BalasActualesEnCargador--;
                     GunStatusScript.arma2.BalasActualesEnCargador++;
                    */

                    bool a1 = false;
                    bool a2 = false;
                    bool oh = true;
                    while (GunStatusScript.CargadoresActuales > 0)
                    {
                        if (oh)
                        {
                            if (GunStatusScript.BalasActualesEnCargador < GunStatusScript.BalasTotalesPorCargador)
                            {
                                GunStatusScript.BalasActualesEnCargador++;
                                a1 = true;
                            }
                            else
                            {
                                oh = !oh;
                            }
                        }
                        else
                        {
                            if (GunStatusScript.arma2.BalasActualesEnCargador < GunStatusScript.BalasTotalesPorCargador)
                            {
                                GunStatusScript.arma2.BalasActualesEnCargador++;
                                a2 = true;
                            }
                            else
                            {
                                oh = !oh;
                            }
                                
                        }
                        GunStatusScript.CargadoresActuales--;
                        oh = !oh;
                    }

                    if (a1)
                    {
                        gunS.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("polladas2");
                        gunS.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("transigay");
                        gunS.AnimacionesArmagays.GetComponent<Animator>().SetTrigger("pollones");
                    }
                    if (a2)
                    {
                        gunS.arma2.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("polladas2");
                        gunS.arma2.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("transigay");
                        gunS.arma2.AnimacionesArmagays.GetComponent<Animator>().SetTrigger("pollones");
                    }


                }
                else
                {
                    int balas2 = GunStatusScript.BalasTotalesPorCargador - GunStatusScript.BalasActualesEnCargador;
                    GunStatusScript.CargadoresActuales = GunStatusScript.CargadoresActuales - balas2;
                    GunStatusScript.BalasActualesEnCargador = GunStatusScript.BalasActualesEnCargador + balas2;

                    balas2 = GunStatusScript.BalasTotalesPorCargador - GunStatusScript.arma2.BalasActualesEnCargador;
                    GunStatusScript.CargadoresActuales = GunStatusScript.CargadoresActuales - balas2;
                    GunStatusScript.arma2.BalasActualesEnCargador = GunStatusScript.arma2.BalasActualesEnCargador + balas2;

                    GunStatusScript.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("polladas2");
                    GunStatusScript.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("transigay");
                    GunStatusScript.AnimacionesArmagays.GetComponent<Animator>().SetTrigger("pollones");
                    GunStatusScript.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("polladas");


                    GunStatusScript.arma2.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("polladas2");
                    GunStatusScript.arma2.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("transigay");
                    GunStatusScript.arma2.AnimacionesArmagays.GetComponent<Animator>().SetTrigger("pollones");
                    GunStatusScript.arma2.AnimacionesArmagays.GetComponent<Animator>().ResetTrigger("polladas");
                }
               

            }
          
            // GunStatusScript.BalasActualesEnCargador = GunStatusScript.BalasTotalesPorCargador;  SOY DEMASIADO GUAY Y YO ME INVENTO MI PROPIO DE ESO VALE? POS VALE
            // GunStatusScript.CargadoresActuales--; 
        }
        GameObject.Find("Controlador").GetComponent<normalizador>().actarmasrecarga();
        yield return new WaitForSeconds(0.01f);
        {
            gunS.AnimacionesArmagays.GetComponent<Animator>().enabled = false;
            if (manualA && gunS.dual && dobleA && gunS.arma2 != null)
            {
                gunS.arma2.AnimacionesArmagays.GetComponent<Animator>().enabled = false;
            }
            //FPCStatus.transicion = false;
        }
        //DisparoSelectivoSrc.GUICargadores.text = GunStatusScript.CargadoresActuales.ToString();
        //DisparoSelectivoSrc.GUIBalas.text = GunStatusScript.BalasActualesEnCargador.ToString();
        // DisparoSelectivoSrc.UIBalas.text = GunStatusScript.CargadoresActuales.ToString() + "/" + GunStatusScript.BalasActualesEnCargador.ToString();
        if (manualA && GunStatusScript.dual && dobleA)
        {
            GunStatusScript.arma2.recargando = false;
        }
        gunS.recargando = false;
        FPCStatus.isReloading = false;
        FPCStatus.transicion = false;
        manual = false;
        doble = false;
    }

    IEnumerator audiosgays(int i)
    {
        int sec = 0;
        float tiempo = Time.time;
        

        for (int a = 0; a < audios[i].timer.Length; a++)
        {
            aud.volume = audios[i].volumen * Controlador.volumenef;
            float siguiente = (audios[i].timer[sec]);
            if (a > 0) { siguiente -= audios[i].timer[sec - 1]; }
            yield return new WaitForSeconds(siguiente);
            
            if (audios[i].Audio[sec].Audiogays.Length > 0)
            {
                AudioClip audgay = audios[i].Audio[sec].Audiogays[Random.Range(0, audios[i].Audio[sec].Audiogays.Length)];
                aud.PlayOneShot(audgay);
            }
            
            
            sec++;
            
        }

        
        
    }



}





