using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidacosa : MonoBehaviour {


	public int salud = 100;
	public bool morido = false;
	public Vector3 dir;
	private bool asignao = false;
	public GameObject[] next;
	public bool mobil = false;
	public Transform way;
	public float vel;
	private float alt;

	public MeshRenderer textureTarget;
	public Material normal, dada;


	void Start()
    {
		alt = transform.parent.position.y;
    }
	
	void Update()
    {
		if (salud <= 0) { morido = true;  }

		if (morido)
		{

			if (textureTarget.material != dada)
			{
				textureTarget.material = dada;
			}

			//Debug.Log("Morido");
			//Vector3 newDirection = Vector3.RotateTowards(transform.parent.forward, dir, 8 * Time.deltaTime, 0.0f);
			//transform.parent.rotation = Quaternion.LookRotation(newDirection);
		}
		else {

			if (textureTarget.material != normal)
			{
				textureTarget.material = normal;
			}
		}
		if (mobil && salud > 0)
        {
			transform.parent.position = Vector3.MoveTowards(transform.parent.position, way.position, vel);
			transform.parent.position = new Vector3(transform.parent.position.x, alt, transform.parent.position.z);

			if (Vector3.Distance(transform.parent.position, way.position) < 2.1f)
            {
				way = way.GetComponent<waypointcutre>().next;
            }
        }

    }
	
	void Aplicacriticks(float pene) {
		
	}
	
	// Update is called once per frame
	void AplicaDamage(int pene) {
		Debug.Log("CHUPAMELA");
		salud = salud - pene;
		if (salud <= 0 && !asignao)
        {
			morido = true;
			Transform p = GameObject.FindWithTag("Player").transform;
			Vector3 targetDir = p.position - transform.position;
			targetDir = targetDir.normalized;
			Vector3 forward = transform.forward;
			float angle = Vector3.SignedAngle(targetDir, forward, Vector3.up);
			if (angle >-90 && angle < 90)
            {
				dir = new Vector3(0, 1, 0);
			}
            else
            {
				dir = new Vector3(0, -1, 0);
			}

			asignao = true;
			
			
			foreach (GameObject a in next)
            {
				a.SetActive(true);
            }


		}
	}
	void AplicaDamage2(int pene)
	{
		Debug.Log("CHUPAMELA");
		salud = salud - pene;
		if (salud <= 0 && !asignao)
		{
			morido = true;

			Transform p = GameObject.FindWithTag("Player").transform;
			Vector3 targetDir = p.position - transform.position;
			targetDir = targetDir.normalized;
			Vector3 forward = transform.forward;
			float angle = Vector3.SignedAngle(targetDir, forward, Vector3.up);
			if (angle > -90 && angle < 90)
			{
				dir = new Vector3(0, 1, 0);
			}
			else
			{
				dir = new Vector3(0, -1, 0);
			}

			asignao = true;
			foreach (GameObject a in next)
			{
				a.SetActive(true);
			}
			}

		
	}

	void AplicaStun(int pene)
	{

    }
}
