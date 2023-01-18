using UnityEngine;
using UnityEngine.UI;

public class SliderSalud : MonoBehaviour
{
    private int salud = 100;

    private Slider mySliderSalud;

    /*private Renderer myRenderer = null;
    private Material myMaterial = null;*/
    
    void Start()
    { 
        mySliderSalud = GetComponent<Slider>();
        
        //myRenderer = GetComponent<Renderer>();
        //myMaterial = myRenderer.material;

        ActualizaBarraSalud();
    }

    /**/ 
    void Update()
    {
        if (salud != GameMngr.Instance.nSalud)
        {
            ActualizaBarraSalud ();
        }
    }


    private void ActualizaBarraSalud ()
    {
        //myMaterial.SetFloat("_Cutoff", Mathf.InverseLerp(0, 100, GameMngr.Instance.nSalud));
        mySliderSalud.value = GameMngr.Instance.nSalud;
        salud = GameMngr.Instance.nSalud;
    }
}