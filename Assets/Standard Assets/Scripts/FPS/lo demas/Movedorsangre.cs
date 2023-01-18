using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movedorsangre : MonoBehaviour {

    [HideInInspector]
    public bool iz = false;
    [HideInInspector]
    public bool de = false;
    [HideInInspector]
    public bool ar = false;
    [HideInInspector]
    public bool ab = false;
    [HideInInspector]
    public bool jej = false;

    private bool muerecerda = false;
    private bool nopudoguey = false;

    public Transform yo;
    public GameObject yo2;
    public float velosida;

    private Vector3 esiz;
    private Vector3 rotagay;

    private float xa;
    private float ya;
    private float za;
    private float xa2;
    private float ya2;
    private float za2;
    private float xa3;
    private float ya3;
    private float za3;

    private float timinga = 0;
    private float timinga2 = 0;
    private float timinga3 = 0;

    public float tiempodestruccion;

    private float xm = 0.1f;
    private float ym = 0.1f;
    private float zm = 0.1f;

    private bool pareseostia = false;

    [SerializeField]
    private AnimationCurve fadeCurve;
    Renderer _renderer;
    Color _color;
    private float _timer = 1f;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _color = _renderer.material.color;
    }


    void Start () {
        
        
        esiz = yo.localScale;
        xa = esiz.x;
        ya = esiz.y;
        za = esiz.z;
        xa3 = esiz.x;
        ya3 = esiz.y;
        za3 = esiz.z;
        
        Calculos();
    }
	
	void Update () {
        timinga3 += Time.deltaTime;
        if (jej)
        {
            if (!nopudoguey)
            {
                if (timinga3 < 0.3f)
                {
                    muerecerda = true;
                }
            }
        }
        if (muerecerda)
        {
            Destroy(gameObject);
            // Debug.Log("AYY QUE CHINGADA WEY");
        }

        if (timinga >= 0.8f)
        {
            Destroy(gameObject);
        }
        if (timinga2 >= tiempodestruccion)
        {
            _timer -= Time.deltaTime * 0.2f;
            _color.a = fadeCurve.Evaluate(_timer);
            _renderer.material.color = _color;
            Destroy(gameObject, 5);
        }

        //  Debug.Log(pareseostia);
        esiz = yo.localScale;
        xa = esiz.x;
        ya = esiz.y;
        za = esiz.z;
        if (xa <= xa2)
        {
            pareseostia = true;   
        }

        if (iz && de && ar && ab)
        {
            nopudoguey = true;
            yo2.GetComponent<MeshRenderer>().enabled = true;
            timinga2 += Time.deltaTime;
            pareseostia = true;

            comprovadorfps[] a = gameObject.GetComponentsInChildren<comprovadorfps>();

            foreach(comprovadorfps ah in a)
            {
                Destroy(ah);
            }
        }
        else
        {
            timinga += Time.deltaTime;
        }


        if (!iz && !de)
        {
            Destroy(gameObject);
        }
        if (!ar && !ab)
        {
            Destroy(gameObject);
        }


        if (!iz)
        {
            yo.transform.position += yo.transform.right * 0.1f * velosida * Time.deltaTime;

            if (!pareseostia)
            {
                xm = 0.15f;
                ym = 0.1f;
                zm = 0.1f;
                yo.localScale -= new Vector3(xm, ym, zm);
            }
        }
        if (!de)
        {
            yo.transform.position += yo.transform.right * -0.1f * velosida * Time.deltaTime;

            if (!pareseostia)
            {
                xm = 0.15f;
                ym = 0.1f;
                zm = 0.1f;
                yo.localScale -= new Vector3(xm, ym, zm);
            }
        }
        if (!ar)
        {
            yo.transform.position += yo.transform.up * -0.1f * velosida * Time.deltaTime;
            if (!pareseostia)
            {
                ym = 0.15f;
                xm = 0.1f;
                zm = 0.1f;
                yo.localScale -= new Vector3(xm, ym, zm);
            }
        }
        if (!ab)
        {
            yo.transform.position += yo.transform.up * 0.1f * velosida * Time.deltaTime;
            if (!pareseostia)
            {
                ym = 0.15f;
                xm = 0.1f;
                zm = 0.1f;
                yo.localScale -= new Vector3(xm, ym, zm);
            }
        }


    }

    void Calculos()
    {
    //    yo.transform.Rotate(xa3, ya3, za3);
        xa2 = xa;
        xa2 /= 2;

        ya2 = ya;
        ya2 /= 2;

        za2 = za;
        za2 /= 2;






    }






}
