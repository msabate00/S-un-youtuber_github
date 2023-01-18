using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolumen : MonoBehaviour {

    private Slider mySlider;
	
	void Start ()
    {
        mySlider = GetComponent<Slider>();
        mySlider.value = GameMngr.Instance.volumen;
    }
	
	
	public void CambioVolumen ()
    {
        GameMngr.Instance.volumen = mySlider.value;
        GameMngr.Instance.ActualizarVolumen ();
    }
}
