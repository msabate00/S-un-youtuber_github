using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ehhyokse : MonoBehaviour {

	public float Velocidad = 1;
	private float Velocidadplano = 30.25210084033613f;
	public Transform redonda;
	public Transform plano;
	public Transform circulo;
	public Transform circuloraro;
	public Transform Flecha;
	public Transform fondo;

	public static bool muerto = false;

	private Transform Insrojo;
	private Transform Flecharoja;
	private float tiempo;
	private float smuz = 0;

	void Start () {
		Insrojo = redonda.GetChild(0).GetChild(0).GetChild(0).GetChild(0);
	}

	// Update is called once per frame
	void Update()
	{

		posrot();
		posplano();
		poscirc();
		poscircraro();

		if (Input.GetKey(KeyCode.Space) && Time.time > tiempo && !muerto || Input.GetButton("DisparoNavesXbox") && Time.time > tiempo && !muerto)
		{
			Instanciar();
		}
	}
	void Instanciar()
    {
		GameObject.Find("Controlador").SendMessage("Sonidosgays", 1);
		Flecharoja = Instantiate(Flecha, Insrojo.position, Insrojo.rotation);
		//	Flecharoja.parent = Insrojo;
		tiempo = Time.time + 0.4f;
	}

	void posrot()
    {
		if (!muerto)
        {
			entrada();
			Vector3 posact = transform.eulerAngles;
			posact.y += entrada() * Velocidad * Time.deltaTime;
			transform.eulerAngles = posact;

			Vector3 posactwena = redonda.transform.eulerAngles;
			float penes = transform.eulerAngles.y;
			penes = 360 - penes;
			posactwena.y = penes;
			redonda.eulerAngles = posactwena;
		}
		
	}
	float entrada()
	{

		float velocidad = 1.9f;
		float puto = 0;
		if (Mathf.Abs(Input.GetAxis("HorizontalNaves")) > 0) { puto = Input.GetAxis("HorizontalNaves"); return puto; }
		
		if (Mathf.Abs(Input.GetAxisRaw("HorizontalNavesXbox")) > 0)
		{
			if (Input.GetAxis("HorizontalNavesXbox") > 0)
			{
				smuz += velocidad * Time.deltaTime;
				smuz = Mathf.Clamp(smuz, 0, Input.GetAxisRaw("HorizontalNavesXbox"));
			}
			if (Input.GetAxis("HorizontalNavesXbox") < 0)
			{
				smuz -= velocidad * Time.deltaTime;
				smuz = Mathf.Clamp(smuz, Input.GetAxisRaw("HorizontalNavesXbox"), 0);
			}
			smuz = Mathf.Clamp(smuz, -1, 1);
       return smuz;
		}
		else
			smuz = Mathf.Lerp(smuz, 0, 0.7f);
		return smuz;
	}
	void posplano()
    {
		float posgen = transform.eulerAngles.y;
		posgen *= 16.34f;
		posgen /= 360;
		Vector3 posicion;
		posicion.x = plano.localPosition.x;
		posicion.y = plano.localPosition.y;
		posicion.z = posgen;
		plano.localPosition = posicion;
	}
	void poscirc()
	{
		Vector3 posact = circulo.transform.localEulerAngles;
		//posact.z = 90;
		posact.y = transform.localEulerAngles.y;
		circulo.localEulerAngles = posact;
	}
	void poscircraro()
	{
		Vector3 posact = circuloraro.transform.localEulerAngles;
		//posact.z = 90;
		posact.y = transform.localEulerAngles.y;
		circuloraro.localEulerAngles = posact;

		Vector3 posact2 = fondo.transform.localEulerAngles;
		//posact.z = 90;
		posact2.y = transform.localEulerAngles.y;
		fondo.localEulerAngles = posact2;
	}
}
