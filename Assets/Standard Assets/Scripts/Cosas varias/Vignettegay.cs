using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vignettegay : MonoBehaviour {

    public float vel = 2;
    public float vel2 = 0.2f;
	public float max = 0.8f;
	public float maxhp = 80f;
	public Image imagen;
    public Coroutine transgay;
    public Coroutine transgay2;
    public float desgay = 0;
    private float val = 0;

	void Start()
    {
		imagen = GetComponent<Image>();
    }

	public IEnumerator trans()
    {
        float des = 0;
        Color gay = imagen.color;
        gay.a -= val;

        while (true)
        {
            if (Controlador.vidahomosexual < maxhp)
            {
                des = max;
            }
            else
            {
                des = 0;
            }

            gay.a = Mathf.MoveTowards(gay.a, des, vel * Time.deltaTime);
            Color sex = gay; sex.a += val;
            imagen.color = sex;
            desgay = gay.a;
            if (gay.a == des) { yield return null; }

            yield return null;
        }


    }
	
    public void splosh()
    {
        StopAllCoroutines();
        StartCoroutine(trans2());
    }

    public void splosh2()
    {
        if (transgay2 != null) { StopCoroutine(transgay2); }
        transgay2 = StartCoroutine(trans3());
    }

    IEnumerator trans3()
    {

        //val = 0.4f;
        val = Mathf.Clamp(1 - desgay, 0, 0.4f);
/*
        if (desgay > 0.6f)
        {
            val = 1 - desgay;
        }
*/
        Color gay = imagen.color;
        gay.a = desgay + val;
        imagen.color = gay;

        vel2 = val;

        while (true)
        {
            yield return null;

            val = Mathf.MoveTowards(val, 0, vel2 * Time.deltaTime);
            gay.a = desgay + val;
            gay.a = Mathf.Clamp(gay.a, 0, 1);
            imagen.color = gay;
            if (val == 0) { yield return null; }
        }
    }

    IEnumerator trans2()
    {
        Color gay = imagen.color;
        gay.a = max;
        imagen.color = gay;

        while (true)
        {
            yield return null;

            gay.a = Mathf.MoveTowards(gay.a, 0, vel * Time.deltaTime);
            imagen.color = gay;
            if (gay.a == 0) { yield return null; }
        }
    }
}
