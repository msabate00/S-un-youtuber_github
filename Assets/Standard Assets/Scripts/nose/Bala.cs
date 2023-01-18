using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

	private Transform flechazul;
	private Transform flechamarilla;
	private Transform flechaverde;
	public Transform Flechazul;
	public Transform Flechamarilla;
	public Transform Flechaverde;
	public GameObject particulasgays;
	private GameObject insazul;
	private GameObject insamarillo;
	private GameObject insverde;
	private Transform fondo;
	private float altura;
	private float alturamarillo;

	public Transform[] cosas;

	private GameObject[] cojones;

	void Start () {

		insamarillo = GameObject.Find("Instanciador Amarillo");
		insazul = GameObject.Find("Instanciador Azul");
		insverde = GameObject.Find("Instanciador Verde");
		Vector3 pos = transform.position;
		pos.y = 0;
		transform.position = pos;
		genazul();
		genamarillo();
		genaverde();
	}

	void FixedUpdate()
	{

		Vector3 posg = flechaverde.position;
		float alt = altura;
		alt *= 1.1241f;
		alt -= 0.35f;
		posg.y = alt;
		//posg.y += 5.85f * Time.fixedDeltaTime;
		flechaverde.position = posg;
	}
	void Update () {
		
		Vector3 pos = transform.position;
		pos.y += 7.7f * Time.deltaTime;
		altura = pos.y;
		transform.position = pos;



		posazul();
		posamarillo();
		posverde();
		insazul.transform.LookAt(fondo);
	}
	void genaverde()
    {
		flechaverde = Instantiate(Flechaverde, insverde.transform.position, insverde.transform.rotation);
		flechaverde.GetComponent<Detectadorgay>().original = gameObject;
		Destroy(flechaverde.gameObject, 2);
		Destroy(flechazul.gameObject, 2);
		Destroy(flechamarilla.gameObject, 2);
		Destroy(gameObject, 2);
	}
	void genazul()
    {
		flechazul = Instantiate(Flechazul, insazul.transform.position, insazul.transform.rotation);
		flechazul.GetChild(0).GetChild(0).gameObject.SetActive(false);
	}
	void genamarillo()
	{
		flechamarilla = Instantiate(Flechamarilla, insamarillo.transform.position, insamarillo.transform.rotation);
		
	}
	void posamarillo()
    {
		Vector3 pos = flechamarilla.GetChild(0).localPosition;
		float alt = altura;
		alt *= 0.17f;
		//alt += 1.2685f;
		pos.x = alt;
		alturamarillo = alt;
		flechamarilla.GetChild(0).localPosition = pos;

	}
	void posverde()
	{
	

	}
	void posazul()
    {
		if (flechazul.position.x > 26f)
        {
			flechazul.GetChild(0).GetChild(0).gameObject.SetActive(true);
        }

		Vector3 radio = flechazul.GetChild(0).localPosition; //radio
		radio.z = altura;
		radio.z *= -0.3011f;
		flechazul.GetChild(0).localPosition = radio;

		Vector3 pos = flechazul.position; //posición
		pos.x = altura;
		pos.x *= 16.442f;
		pos.x += 21.61f;
		flechazul.position = pos;
	}
	void particulas(GameObject[] enemigo)
    {
		GameObject rojo = Instantiate(particulasgays, transform.position, transform.rotation);
		GameObject azul = Instantiate(particulasgays, flechazul.position, flechazul.rotation);
		GameObject amarillo = Instantiate(particulasgays, flechamarilla.GetChild(0).position, flechamarilla.rotation);
		GameObject verde = Instantiate(particulasgays, flechaverde.position, flechaverde.rotation);

		Vector3 escala1 = Vector3.zero;
		escala1.Set(1.7f,1.7f,1.7f);
		Vector3 escala2 = Vector3.zero;
		escala2.Set(2f, 2f, 2f);
		Vector3 escala3 = Vector3.zero;
		escala3.Set(1.31f, 2f, 2f);

		Vector3 pene = Vector3.zero;
		pene.z = -90;
		verde.transform.localEulerAngles = pene;

		cosas[0] = rojo.transform;
		cosas[1] = rojo.transform.GetChild(0);
		cosas[2] = rojo.transform.GetChild(1);
		cosas[3] = rojo.transform.GetChild(2);

		foreach (Transform t in cosas)
		{
			t.gameObject.layer = 1;
		}

		rojo.transform.localScale = escala1;
		azul.transform.localScale = escala2;
		amarillo.transform.localScale = escala2;
		verde.transform.localScale = escala3;

		rojo.GetComponent<Animation>().Play("circulocolorojo");
		azul.GetComponent<Animation>().Play("circulocolorazul");
		amarillo.GetComponent<Animation>().Play("circulocoloramar");
		verde.GetComponent<Animation>().Play("circulocolorverde");

		foreach (GameObject gay in enemigo)
        {
			Destroy(gay);
        }
		Destroy(flechaverde.gameObject);
		Destroy(flechazul.gameObject);
		Destroy(flechamarilla.gameObject);
		Destroy(gameObject);
	}
}
