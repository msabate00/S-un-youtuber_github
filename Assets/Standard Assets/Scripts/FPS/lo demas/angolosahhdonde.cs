using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angolosahhdonde : MonoBehaviour {

	public static angolosahhdonde yo;
	public Transform[] targets = new Transform[3];
	[HideInInspector]
	public bool[] derecho = new bool [3];
	public float[] lel = new float[3];
	public Transform[] dir = new Transform[3];
	[HideInInspector]
	public int cont = -1;
	public float[] contalfa = new float[3];
	private bool asignao = false;
	private Transform player;

	void Start()
    {
		yo = this;

		if (dir[0] == null)
        {
			dir[0] = GameObject.Find("Dir0").transform;
        }
		if (dir[1] == null)
		{
			dir[1] = GameObject.Find("Dir1").transform;
		}
		if (dir[2] == null)
		{
			dir[2] = GameObject.Find("Dir2").transform;
		}

	}
	
	public void asignador(Transform orig)
	{
		asignao = false;

		for (int i = 0; i < 3; i++)
		{
			if (orig == targets[i]) //comprovar si existen
			{
				contalfa[i] = 1;
				return;
			}
		}

		for (int i = 0; i < 3; i++)
		{
			if (targets[i] == null || contalfa[i] == 0) // si hay slot y el de antes no se ha cumplio
            {
				targets[i] = orig;
				asignao = true;
				cont = i;
				contalfa[i] = 1;
				break;
			}
		}

		if (!asignao) // a las malas pos se carga uno A LA PUTA MIERDA AQUI MANDO YO JODER
		{
			float min = 0.99f;
			int minslot = 3;
			bool yas = false;
			for (int i = 0; i < 3; i++)
			{
				if (contalfa[i] <= min) { minslot = i; min = contalfa[i]; yas = true; }
			}
			if (yas) {

				targets[minslot] = orig;
				contalfa[minslot] = 1;
			}

		}
		
	}
	
	
	// Update is called once per frame
	void Update () {

		if (player == null && GameObject.FindGameObjectWithTag("ELPLAYERJODER")) { player = GameObject.FindGameObjectWithTag("ELPLAYERJODER").transform.GetChild(0); }

		for (int i = 0; i < 3; i++)
        {
			contalfa[i] = contalfa[i] - Time.deltaTime / 2;
			contalfa[i] = Mathf.Clamp(contalfa[i], 0, 1);

			Transform lal = dir[i].GetChild(0);
			Color gay = lal.GetComponent<MeshRenderer>().material.color;
			gay.a = Mathf.Clamp(contalfa[i] * 1.6667f, 0, 1);
			
			lal.GetComponent<MeshRenderer>().material.color = gay;

			if (player == null) { continue; }

			if (targets[i] != null)
			{
				if (contalfa[i] == 0) { targets[i] = null; continue; }
				
				Vector3 targetweno = targets[i].position;
				targetweno.y = player.position.y;
				Vector3 targetDir = targetweno - player.transform.position;

				float angle = Vector3.SignedAngle(targetDir, player.transform.forward, Vector3.up);

				if (angle > 0) { derecho[i] = false; } else { derecho[i] = true; }

				if (!derecho[i]) { lel[i] = angle; }
				else
				{ lel[i] = angle; lel[i] = lel[i] + 360; }

				Vector3 dire = dir[i].eulerAngles;
				dire.z = lel[i];
				dir[i].eulerAngles = dire;

			}

		}	

	}
}
