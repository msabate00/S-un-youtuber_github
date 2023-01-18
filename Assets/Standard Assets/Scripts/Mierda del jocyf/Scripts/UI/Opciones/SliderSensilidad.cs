using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSensilidad : MonoBehaviour {

    private Slider mySlider;
	
	void Start ()
    {
        mySlider = GetComponent<Slider>();
        mySlider.value = GameMngr.Instance.sensibilidad;
    }
	
	
	public void CambioSensibilidad()
    {
        GameMngr.Instance.sensibilidad = mySlider.value;
    }
}
