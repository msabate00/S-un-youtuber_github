using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grafico : MonoBehaviour {

	public float[] altura;
	public Transform[] putos;
	public float altmax = 10;
	public float sep = 2;

	void Update () {

		for (int i = 0; i < putos.Length -1; i++)
		{
			int num = i;
			num++;
			putos[i].GetChild(0).LookAt(putos[num].GetChild(0).GetChild(0));
			Vector3 rot = putos[0].GetChild(0).localEulerAngles;
			//	rot.z = 0; rot.x = 0;
			putos[i].GetChild(0).localEulerAngles = rot;

		}
		


		
	}
	
	// Update is called once per frame
	void OnEnable () {
		float max = Mathf.Max(altura);
		float fact = altmax / max;
		for (int i=0; i <putos.Length; i++)
            {
			int num = i;
			num++;
			Vector3 pene = Vector3.zero;
			pene.x = num * sep;
			pene.y = pene.y + altura[i] * fact;
			putos[i].localPosition = pene;
			
			if (i < putos.Length-1)
            {
				int lol = i;
				lol++;
				Vector3 scalaputo = putos[i].GetChild(0).GetChild(0).localScale;
				scalaputo.x = Vector3.Distance(putos[i].GetChild(0).GetChild(0).position, putos[lol].position);
				putos[i].GetChild(0).GetChild(0).localScale = scalaputo;
				putos[i].GetChild(0).LookAt(putos[lol].GetChild(0).GetChild(0));
				Vector3 rot = putos[i].GetChild(0).localEulerAngles;
				//rot.z = 0; rot.x = 0;
				putos[i].GetChild(0).localEulerAngles = rot;
			}
			
            }
		
	}
}
