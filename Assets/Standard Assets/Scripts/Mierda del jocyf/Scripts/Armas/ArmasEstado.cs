using UnityEngine;

public class ArmasEstado : MonoBehaviour
{
    // NOTA: Todas estas variables se actualizan al disparar un arma (DisparoSelectivo) desde el script de configuracion del arma (GunStatus)
    // Todas estas variables deberian ser visibles pero estar desactivadas.
    //

    [Tooltip("Tiempo de espera antes de destruir este objeto.")]
    public float TiempoDestruccion = 10;
    public float Aceleracion = 1;
    public float Precision;
    public bool quitaputasangre = false;

    [Space(5)]
    public bool UseRotation = false;
    public bool ProyectilAutoRotacion = false;
    public Vector3 VelocidadRotacion = new Vector3(2, 2, 2);

    [Space(5)]
    public int Damage = 45;
    public float RatioDeDisparo = 1;
    public GameObject sangre;
    public Transform yo;

    [Space(5)]
    public GameObject SplashObject = null;
    public GameObject Decall = null;

    private GameObject MySplashObj = null;



    // Autorotacion de la bala en 3D.


    public virtual void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag.Contains("Player"))
        {
            //DamagePlayer ();       // Aplica daño al Player
            other.gameObject.SendMessage("DamagePlayer", Damage);
        }
        else if (other.transform.tag.Contains("Enemy"))
        {
            DamageEnemigo (other.transform);   // Aplica daño al Enemigo
        }
        else if (!other.transform.tag.Contains("Armas"))    // Creando un SplashObject y un Decall.
        {
            CrearSplashObject (other);   // Se vba a crear un Splash

            ColoreaSplash (other.transform); // Colorea la particula (splash) si existe el Renderer

            CrearDecall (other); // Se crea un decall
        }

   // Destruye la bala ahora mismo.
    }


  

    // Aplica daño al Player
    /*protected virtual void DamagePlayer()
    {
        GameMngr.Instance.nSalud = GameMngr.Instance.nSalud - Damage;       
    }*/

    // Aplica daño al Enemigo
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Contains("pene"))
        {
            


        }

    }



    protected virtual void DamageEnemigo (Transform other)
    {
        //ManageEnemyStatus EstadoEnemigo = (ManageEnemyStatus) other.GetComponent(typeof(ManageEnemyStatus)); /**/
        //EstadoEnemigo.Health = EstadoEnemigo.Health - Damage;   
        other.SendMessage("AplicaDamage", Damage);
    }

    // Creamos el SplashObject apropiadamente.
    protected virtual void CrearSplashObject(Collision other)
    {
        ContactPoint contacto = other.contacts[0];
        Vector3 pos = contacto.point;
        Quaternion rot = Quaternion.identity;

        // Alinea el splash con la normal de la superficie de contacto.  Rota el objeto para que tenga la direccion de la normal
        if (UseRotation)
        {
            //rot = Quaternion.FromToRotation(Vector3.forward, contacto.normal);
            rot = Quaternion.LookRotation(contacto.normal);
        }

        // Creando el Splash
        if (SplashObject != null && !quitaputasangre)
        {
            MySplashObj = Instantiate(SplashObject, pos, rot);
        }
    }

    // Coloreamos la particula con el color del objeto con el que colisiona. Colorea la particula si existe el Renderer
    protected virtual void ColoreaSplash (Transform other)
    {
        if (other.GetComponent<Renderer>() == null) { return; } // Sentencia de seguridad.

        Color MyColor = other.GetComponent<Renderer>().material.color;

        //ParticleChangeColor MyParticleColor = MySplashObj.GetComponent<ParticleChangeColor>(); /**/
        //MyParticleColor.MyColor = MyColor;

        //MySplashObj.GetComponent<ParticleChangeColor>().MyColor = MyColor;
     //   MySplashObj.SendMessage("CambiarColorParticula", MyColor);
    }

    // Creamos en decal en la superfinie del objeto.
    protected virtual void CrearDecall (Collision other)
    {
        if (!quitaputasangre)
        {
            ContactPoint contacto = other.contacts[0];
            Vector3 pos = contacto.point;

            // Creo un decall.
            Quaternion rotDecall = Quaternion.FromToRotation(Vector3.up, contacto.normal);
            GameObject DecallObj = Instantiate(Decall, pos, rotDecall);
            DecallObj.transform.parent = other.transform;

            /**/
            /*Vector3 _posAux = DecallObj.transform.localPosition;
            _posAux.y += 0.1f;
            DecallObj.transform.localPosition = _posAux;*/
            DecallObj.transform.position += DecallObj.transform.up * 0.1f;
        }
       
    }


}