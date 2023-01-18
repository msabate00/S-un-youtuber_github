using UnityEngine;

public class ParticleChangeColor : MonoBehaviour
{
    public int initialEmission = 50;
    //public Color32 MyColor = Color.white;

    private ParticleSystem myParticleSystem;
    private Renderer myRenderer;


    private void GetInternalComponents()
    {
        if (myParticleSystem == null)
        {
            myParticleSystem = GetComponent<ParticleSystem>();
        }
        if (myRenderer == null)
        {
            myRenderer = myParticleSystem.GetComponent<Renderer>();
        }
    }

    void Awake()
    {
        GetInternalComponents ();

        //CambiarColorParticula (MyColor);
        myParticleSystem.Emit (initialEmission);
        myParticleSystem.Play ();
    }

    public void CambiarColorParticula (Color _color)
    {
        GetInternalComponents();
        myRenderer.sharedMaterial.color = _color;
    }
}