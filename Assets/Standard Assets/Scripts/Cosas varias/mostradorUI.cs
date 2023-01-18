using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class mostradorUI : MonoBehaviour {

    public TextMeshProUGUI textamen;
    public TextMeshProUGUI textamen2;
    public Image imagengay;
    Coroutine gay = null;
    private float dif = 0;
    private float tiempo = 2;
    private bool para = true;
    private Vignettegay vg;
    private Vignettegay splat;
    private float ant = Controlador.vidahomosexual;
    private AudioSource a;

    void Start()
    {
        vg = GameObject.Find("Vignette").GetComponent<Vignettegay>();
        //splat = GameObject.Find("Spatter").GetComponent<Vignettegay>();
        a = GetComponent<AudioSource>();
    }

    public void actualizar()
    {
        float sex = Controlador.vidahomosexual;
        sex = Mathf.Clamp(sex, 0, 100);
        textamen.text = sex.ToString("F0");
        imagengay.fillAmount = sex / 100;

        if (Controlador.vidahomosexual < vg.maxhp && ant >= vg.maxhp)
        {
            if (vg.transgay != null) { StopCoroutine(vg.transgay); }
            vg.transgay = StartCoroutine(vg.trans());
            a.Play();
        }
        else if (Controlador.vidahomosexual >= vg.maxhp && ant < vg.maxhp)
        {
            if (vg.transgay != null) { StopCoroutine(vg.transgay); }
            vg.transgay = StartCoroutine(vg.trans());
        }

        if (Controlador.vidahomosexual < ant)
        {
            //splat.splosh();
            vg.splosh2();
        }
        
        ant = Controlador.vidahomosexual;
    }

    public void interfaz(float penis)
    {
        if (penis <= 0) { return; }

        dif = dif + penis;
        textamen2.text = "+" + dif.ToString("F0");
        if (para) {

            if (gay == null) { gay = StartCoroutine("bumshakalaka"); }
            else { StopCoroutine(gay); dif = penis; gay = StartCoroutine("bumshakalaka"); }

        }
        else
        {
            tiempo = 2;
        }
       
    }

    IEnumerator bumshakalaka()
    {
        para = false;

        Color rabos = new Color(textamen2.color.r, textamen2.color.g, textamen2.color.b, textamen2.color.a);

        textamen2.color = rabos;

        while (true)
        {
            float mierdas = textamen2.color.a;
            mierdas += Time.deltaTime;

            mierdas = Mathf.Clamp(mierdas, 0, 1);

            textamen2.color = new Color(textamen2.color.r, textamen2.color.g, textamen2.color.b, mierdas);

            if (mierdas == 1) { break; }

            yield return null;
        }

        tiempo = 2;

        while (true)
        {
           
            tiempo -= Time.deltaTime;
            tiempo = Mathf.Clamp(tiempo, 0, 10);

            if (tiempo == 0) { break; }

            yield return null;
        }

        para = true;

        while (true)
        {
            float mierdas = textamen2.color.a;
            mierdas -= Time.deltaTime;

            mierdas = Mathf.Clamp(mierdas, 0, 1);

            textamen2.color = new Color(textamen2.color.r, textamen2.color.g, textamen2.color.b, mierdas);

            if (mierdas == 0) { break; }

            yield return null;

        }


        dif = 0;
        yield break;
    }
}
