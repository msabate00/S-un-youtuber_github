using UnityEngine;

public class AumentoSalud : MonoBehaviour /**/
{
    [Range(5, 50)]
    public int CantidadSalud = 10;
    [Range(1, 3)]
    public int VelocidadGiro = 2;

    private AudioSource FireSound;


    void Start()
    {
        GameObject MyEffectObj = GameObject.Find("EffectsSoundSource");
        FireSound = MyEffectObj.GetComponent<AudioSource>();
    }

    // Roto el cargador sobre si mismo a una velocidad determinada "velocidadgiro".
    void Update()
    {
        transform.Rotate(Vector3.up, VelocidadGiro, Space.World);
    }

    // Al tocar el trigger actualizo la municion y destruyo el cargador.
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Contains("Player"))
        {
            if (FireSound != null) { FireSound.Play(); }

            GameMngr.Instance.nSalud += CantidadSalud;
            if (GameMngr.Instance.nSalud > 100)
            {
                GameMngr.Instance.nSalud = 100;
            }

            Destroy(gameObject);    // Destruyo el kit de salud
        }
    }

}