using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidosmelee : MonoBehaviour {

    [HideInInspector]
    public int kekosa;
    private AudioSource sonidosgay;
    public AudioClip ostiapincho;
    public AudioClip ostiadeldos;
    public AudioClip ostiadeltres;

    public AudioClip fallouno;
    public AudioClip fallodos;
    public AudioClip fallotres;

    void Start () {
        sonidosgay = GetComponent<AudioSource>();
        if (kekosa == 1)
        {
            sonidosgay.clip = ostiapincho;
            sonidosgay.Play();
        }
        if (kekosa == 2)
        {
            sonidosgay.clip = ostiadeldos;
            sonidosgay.Play();
        }
        if (kekosa == 3)
        {
            sonidosgay.clip = ostiadeltres;
            sonidosgay.Play();
        }
        if (kekosa == 4)
        {
            sonidosgay.clip = fallouno;
            sonidosgay.Play();
        }
        if (kekosa == 5)
        {
            sonidosgay.clip = fallodos;
            sonidosgay.Play();
        }
        if (kekosa == 7)
        {
            sonidosgay.clip = fallotres;
            sonidosgay.Play();
        }
        Destroy(gameObject, 1f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
