using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour {

    private GameObject yo;
    public GameObject[] opciones;
    public bool dentro = false;
    public bool opcionesgays = false;
    private audiosglobal[] gays2;
    private bool cursorgayvisible = false;
    public List<int> sexualsex = new List<int>();

    public bool estaticocagon = true;
    public List<pausagay> listamierda = new List<pausagay>();
    private Coroutine trans = null;
    public float espacio = 200;
    public float spid = 20;
    public AudioClip sonidogay;

    public float prop = 1;
    public float propmus = 1;
    public float obj = 1;
    private Coroutine transgay = null;
    public static Pausa Pa;

    public bool interactuable = true;

    void Start () {

        if (!estaticocagon) { Pa = this; }
        
        if (estaticocagon) { return; }
        listamierda = new List<pausagay>();
        Controlador.muerto = false;

        for (int i = 0; i < opciones.Length; i++)
        {
            listamierda.Add(new pausagay());
            Pausa[] soygay = opciones[i].GetComponentsInChildren<Pausa>();
            listamierda[i].rectos = new RectTransform[soygay.Length];

            for (int a = 0; a < soygay.Length; a++)
            {
                listamierda[i].rectos[a] = soygay[a].gameObject.GetComponent<RectTransform>();
            }

            listamierda[i].cors = new Vector3[soygay.Length];
            for (int a = 0; a < soygay.Length; a++)
            {
                listamierda[i].cors[a] = listamierda[i].rectos[a].anchoredPosition3D;
            }
        }
        
        //cors[0][0] = cors2[0].gameObject.GetComponent<RectTransform>();
        yo = transform.GetChild(0).gameObject;
        StartCoroutine(imputeador());
	}
	
	public void salir()
    {
        if (!interactuable) { return; }

        for (int i = 0; i < opciones.Length; i++)
        {
            opciones[i].SetActive(false);
        }

        dentro = !dentro;

        if (dentro)
        {
            yo.SetActive(true);
            opciones[2].SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
            sexualsex.Add(2);

            if (trans != null) { StopCoroutine(trans); }        
            trans = StartCoroutine(movedor(sexualsex[sexualsex.Count -1]));
        }
        else
        {
            yo.SetActive(false);
            if (!Controlador.muerto)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                
            }
           
            sexualsex.Clear();
        }

        tiempogay();
    }

    void tiempogay()
    {

        if (dentro) //Ir al menú
        {
            if (transgay != null) { StopCoroutine(transgay); transgay = null; }
            transgay = StartCoroutine(props(false));
            Time.timeScale = 0;
            cursorgayvisible = true;
            gays2 = (audiosglobal[])GameObject.FindObjectsOfType(typeof(audiosglobal));

            for (int i = 0; i < gays2.Length; i++)
            {
                if (gays2 == null) { continue; }
                gays2[i].SendMessage("gestor", true);
            }

        }
        else //Volver al Play
        {
            if (transgay != null) { StopCoroutine(transgay); transgay = null; }
            StartCoroutine(Reanudar());
            transgay = StartCoroutine(props(true));
        }
    }

    IEnumerator props(bool sex)
    {
        float timer = 0;
        float timer2 = 0;

        if (sex) { obj = 1; }
        else { obj = 0; }

        while (true)
        {
            timer = Time.realtimeSinceStartup;
            yield return null;

            timer2 = Time.realtimeSinceStartup - timer;
            prop = Mathf.MoveTowards(prop, obj, 2f * timer2);
            propmus = Mathf.MoveTowards(prop, obj, 3.3f * timer2);

            if (prop == obj && propmus == obj)
            {
                break;
            }
        }
       
    }

    IEnumerator Reanudar()
    {
        cursorgayvisible = false;
        yield return null;

        Time.timeScale = 1;
        
        for (int i = 0; i < gays2.Length; i++)
        {
            if (gays2 == null) { continue; }
            gays2[i].SendMessage("gestor", false);
        }
    }

    public void activarcontroles()
    {
        for (int i = 0; i < opciones.Length; i++)
        {
            opciones[i].SetActive(false);
        }
        sexualsex.Add(1);
        opciones[1].SetActive(true);
    }
    public void saliropciones(bool sex)
    {

        if (!interactuable) { return; }

        for (int i = 0; i < opciones.Length; i++)
        {
            opciones[i].SetActive(false);
        }

        if (sex)
        {
                      
            opcionesgays = false;
            for (int i = 0; i < gays2.Length; i++)
            {
                gays2[i].gameObject.SendMessage("Actulizar", SendMessageOptions.DontRequireReceiver);
                Debug.Log("QWUE TE FOLLEN");
            }

            sexualsex.RemoveAt(sexualsex.Count - 1);
            actulizarmierda();
        }
        else
        {
                opciones[0].SetActive(true);
            sexualsex.Add(0);

            if (trans != null) { StopCoroutine(trans); }
            trans = StartCoroutine(movedor(sexualsex[sexualsex.Count - 1]));

            opcionesgays = true;

        }

    }

    void actulizarmierda()
    {
        DisparoSelectivo.GunStatusScript2.gameObject.SendMessage("ActualizarFOV");
    }

    public void salirgay()
    {

        for (int i = 0; i < gays2.Length; i++)
        {
            if (gays2[i] == null) { continue; }
            gays2[i].gameObject.SendMessage("Actulizar", SendMessageOptions.DontRequireReceiver);
        }

        opciones[sexualsex[sexualsex.Count - 1]].SetActive(false);
        sexualsex.RemoveAt(sexualsex.Count - 1);
        opciones[sexualsex[sexualsex.Count - 1]].SetActive(true);

        if (trans != null) { StopCoroutine(trans); }
        trans = StartCoroutine(movedor(sexualsex[sexualsex.Count - 1]));

        if (sexualsex.Count <= 1) { opcionesgays = false; }
    }

    public void menuinicial()
    {
        if (!interactuable) { return; }
        interactuable = false;
        GameObject.Find("TransicionGay").transform.GetChild(0).SendMessage("fadear");
        if (Controlador.ah.gameObject.GetComponent<audiosglobal>().trans != null) { StopCoroutine(Controlador.ah.gameObject.GetComponent<audiosglobal>().trans); }
        Controlador.ah.gameObject.GetComponent<audiosglobal>().parartodas();
        Controlador.ah.gameObject.GetComponent<audiosglobal>().trans = StartCoroutine(Controlador.ah.gameObject.GetComponent<audiosglobal>().transwapa());
    }

    IEnumerator movedor(int puto)
    {

        for (int i = 0; i < listamierda[puto].rectos.Length; i++)
        {
            listamierda[puto].rectos[i].anchoredPosition3D = listamierda[puto].cors[i] - new Vector3((espacio), 0, 0);

        }

        int min = 0;
        float delta = 0;
        float delta2 = 0;
        while (min < listamierda[puto].rectos.Length)
        {
            delta = Time.realtimeSinceStartup;
            for (int i = min; i < listamierda[puto].rectos.Length; i++)
            {
                listamierda[puto].rectos[i].anchoredPosition3D = Vector3.MoveTowards(listamierda[puto].rectos[i].anchoredPosition3D, listamierda[puto].cors[i], spid * delta2);

                if (listamierda[puto].rectos[min].anchoredPosition3D == listamierda[puto].cors[i])
                {

                    min++;

                    if (min == listamierda[puto].rectos.Length)
                    {
                        GetComponent<AudioSource>().Stop();
                        GetComponent<AudioSource>().PlayOneShot(sonidogay);
                    }


                }

            }

            yield return new WaitForEndOfFrame();
            delta2 = Time.realtimeSinceStartup - delta;
        }
    }

	IEnumerator imputeador()
    {
        while (true)
        {
            if (!interactuable) { yield return null; continue; }

            if (Input.GetKeyDown(KeyCode.Escape)){

                if (!opcionesgays)
                {                   
                    salir();
                }
                else
                {
                    if (sexualsex.Count > 0)
                    {
                        guardar();
                        salirgay();
                    }
                    else
                    {
                        saliropciones(true);
                    }
                    
                }
                
                //yield return new WaitForSeconds(0.1f);
            }

            if (cursorgayvisible) { Time.timeScale = 0; }
            // else { Time.timeScale = 1; }

            if (Controlador.muerto) { yield return null; continue; }

            if (cursorgayvisible)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
                for (int i = 0; i < gays2.Length; i++)
                {
                    //gays2[i].Pause();
                }
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            yield return null;
        }
    }

    public void guardar()
    {
        Controlador.ah.guardar();
    }

}
