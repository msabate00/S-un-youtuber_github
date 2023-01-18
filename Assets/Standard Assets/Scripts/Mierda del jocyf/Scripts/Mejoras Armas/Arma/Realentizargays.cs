using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Realentizargays : MonoBehaviour {
    public float tiempogay;
    private float fixedDeltaTime;
    // Use this for initialization

    // Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;

    // Update is called once per frame
    void Start()
    {
        Invoke("cojonazos", 1.5f);
    }
    void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }
    void Update () {
        Time.timeScale = tiempogay;
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
    }
    void cojonazos()
    {
        Controlador.mestoylevantandojoder = false;
    }
}
