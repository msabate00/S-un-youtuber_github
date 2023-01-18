using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mierdaza : MonoBehaviour
{

	public GameObject[] respawns;
	public List<float> pulladas = new List<float>();
	public float distmin = 7;
	private float minimo = 30;
	public float minimoconfirmao = 30;
	public int numerogay = 0;
	public GameObject adestruir;

	void Start()
    {
		minimo = distmin;

	}
	void Update()
	{
		pulladas.Clear();
		
		RaycastHit hit;
		if (adestruir != null && Vector3.Distance(transform.position, adestruir.transform.position) > distmin)
        {
			adestruir = null;
		}
		if (adestruir != null && Physics.Linecast(transform.position, adestruir.transform.position, out hit))
		{

			if (hit.collider.tag != "Finish")
			{
				adestruir = null;
			}
		}


			if (Input.GetKeyDown(KeyCode.Space))
		    {
				Destroy(adestruir);
			}
					
			respawns = GameObject.FindGameObjectsWithTag("Finish");
			foreach (GameObject respawn in respawns)
			{
				float polla = Vector3.Distance(transform.position, respawn.transform.position);
				pulladas.Add(polla);
				Vector3.Distance(transform.position, respawn.transform.position);
			}
		
        
		if(respawns.Length != 0)
        {
			MaxValue(respawns);
			numerogay = 0;
			minimo = distmin;
		}





	}


	void MaxValue(GameObject[] penes)
	{
		Debug.Log(minimo);
		int numerogay2 = numerogay;
		numerogay2 += 1;
		
		if (Vector3.Distance(transform.position, penes[numerogay].transform.position) < minimo)
        {
			RaycastHit hit;
			if (Physics.Linecast(transform.position, penes[numerogay].transform.position, out hit))
			{
				
				if (hit.collider.tag == "Finish")
				{
					minimo = Vector3.Distance(transform.position, penes[numerogay].transform.position);
					adestruir = penes[numerogay];
					minimoconfirmao = Vector3.Distance(transform.position, penes[numerogay].transform.position);
				}
				}
			
		}
		numerogay += 1;
		if (numerogay2 < penes.Length)
		{
			MaxValue(respawns);
		}
		}
}