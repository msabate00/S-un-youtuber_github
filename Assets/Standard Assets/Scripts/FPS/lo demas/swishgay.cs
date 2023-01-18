using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swishgay : MonoBehaviour
{
    public float aumento = 1;
    public float vel = 1;
    public int array = 8;
    [HideInInspector]
    public bool dao = false;
    private float cdcheck = 0.4f;

    void Update()
    {
        Vector3 e = transform.localScale;
        float a = aumento * Time.deltaTime;
        e.x += a; e.y += a; e.z += a;
        transform.localScale = e;

        transform.Translate(Vector3.forward * vel * Time.deltaTime);

        cdcheck += Time.deltaTime;

        if (dao)
        {
            dao = false;

            Controlador.vidahomosexual = Controlador.vidahomosexual - Controlador.dañoenemigogay[array];

            angolosahhdonde.yo.SendMessage("asignador", transform);

            Controlador.ah.SendMessage("actualizarvida");
        }
    }

    public void sexo()
    {
        if (cdcheck < 0.7f) { return; }
        cdcheck = 0;
        dao = true;
    }
}
