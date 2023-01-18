using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lehedaoxd : MonoBehaviour {

    public Transform PuntoDisparo;
    public GameObject aymegolpiaste;
    public int damagemeleewao = 20;
    public int stunwapo = 30;
    public static int damagemelee = 10;
    public static int stun = 30;
    public static float timingpincho = 0.2f;
    public static float timingapu = 0.25f;
    public static float timingarrastre = 0.05f;

    void Awake()
    {
        stun = stunwapo;
        damagemelee = damagemeleewao;
    }
    void OnEnable () {
        //  Instantiate(aymegolpiaste, PuntoDisparo.position, PuntoDisparo.rotation);
    //    Raycastman.efectivamentelehedao = false;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            agarre2.efectivamentelehedao = true;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            agarre2.efectivamentelehedao2 = true;
        }

    }
}
