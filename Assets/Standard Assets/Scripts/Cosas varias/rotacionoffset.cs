using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacionoffset : MonoBehaviour {

	public Vector3 offsetgay;
	public Transform ene;
	private Vector3 dest;
	private Quaternion ah;
	public AudioClip[] audios;
	public List<string> nombres;
	public GameObject[] objetos;

	public Vector2Int[] rango;
	public GameObject[] prefab;
	private Camera sex;

	void Start () {

		sex = GetComponentInChildren<Camera>();
		sex.fieldOfView = Controlador.fov;
		//Debug.Log(transform.position.y);
		Vector3 gay = ene.TransformDirection(offsetgay);
		dest = ene.position - transform.position + offsetgay;
		ah = Quaternion.FromToRotation(Vector3.forward, transform.TransformDirection(Vector3.forward + offsetgay));

		Invoke("spawnear", 0f);
	}
	
	public void ejecutaputo (string gay)
    {
		//GetComponent<AudioSource>().PlayOneShot(audios[nombres.IndexOf(gay)]);

		for (int i = 0; i < nombres.Count; i++)
        {
			if (nombres[i] == gay)
            {
				GetComponent<AudioSource>().PlayOneShot(audios[i]);
				return;
            }
        }
    }

	// Update is called once per frame
	void Update () {


		sex.fieldOfView = Controlador.fov;
		if (offsetgay != Vector3.zero)
        {
			//Quaternion rotation = Quaternion.LookRotation(dest, Vector3.up);
			//transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 3f);
			//	transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2 * Time.deltaTime);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, ah, 2 * Time.deltaTime);
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

		}
		
	}

	public void activar(bool sex)
    {
		if (sex) { return; }

			for(int i = 0; i < objetos.Length; i++)
            {
				objetos[i].SetActive(false);
            }

      
    }

	void spawnear()
	{
		for (int i = 0; i < 4; i++)
		{
			int factor = 1;
			if (agarre2.espadahit && i != 3)
            {
				factor = 2;
            }
			int def = Random.Range(rango[i].x * factor, rango[i].y * factor);

			for (int a = 0; a < def - 1; a++)
			{
				Instantiate(prefab[i], transform.position + (Vector3.up), Quaternion.identity);
			}
		}

	}
}
