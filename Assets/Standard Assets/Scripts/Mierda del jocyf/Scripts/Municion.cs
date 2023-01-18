using UnityEngine;

// Pickup de un cargador de municion
public class Municion : MonoBehaviour /**/
{
    public GameObject Arma;
    [Range(1, 20)]
    public int NumeroDeCargadores = 3;

    [Range(1, 3)]
    public int VelocidadGiro = 2;

    private DisparoSelectivo DisparoScript;
    private AudioSource FireSound;

    private GameObject FPC;

    void Start()
    {
        FPC = GameObject.Find("First Person Controller");
        DisparoScript = FPC.GetComponent<DisparoSelectivo>();

        GameObject MyEffectObj = GameObject.Find("EffectsSoundSource");
        FireSound = MyEffectObj.GetComponent<AudioSource>();
    }

    // Roto el cargador sobre si mismo a una velocidad determinada "velocidadgiro".
    void Update()
    {
        transform.Rotate(Vector3.up, this.VelocidadGiro, Space.World);
    }

    // Al tocar el trigger actualizo la municion y destruyo el cargador.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("micuerpochingon"))
        {
            if (FireSound != null) { FireSound.Play(); }

            // Accedo al script de ArmasEstado y actualizo la MunicionActual.
            // Nota: El usuario puede cambiar de arma. /**/
            GunStatus GunStatusScript = Arma.GetComponent<GunStatus>();
            GunStatusScript.CargadoresActuales += NumeroDeCargadores;

            // Compruebo que nunca pase de la municion total de balas.
            if (GunStatusScript.CargadoresActuales > GunStatusScript.CargadoresTotales)
            {
                GunStatusScript.CargadoresActuales = GunStatusScript.CargadoresTotales;
            }

            // Escribo la nueva municion en pantalla si el arma actual que estoy usando
            // coincide con el arma que estoy cargando (la municion es de esa arma).
            if (DisparoScript.Armas[DisparoScript.NumeroArma] == Arma)
            {
                //GUICargadores.text = GunStatusScript.CargadoresActuales.ToString();
            }

            //GUIBalas.text = ArmasScript.CargadoresActuales.ToString();
            
            Destroy (this.gameObject); // Destruyo el cargador de municion
        }
    }

}