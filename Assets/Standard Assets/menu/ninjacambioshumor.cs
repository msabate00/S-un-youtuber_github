using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ninjacambioshumor : MonoBehaviour {

	private Animator anim;
	public string[] estados;
	private int last = 69;
	private List<int> oh = new List<int>();

	void Start () {
		StartCoroutine(a());
	}
	
	IEnumerator a()
    {
		anim = GetComponent<Animator>();

		for(int i = 0; i < estados.Length; i++)
        {
			oh.Add(i);
		}

		while (true)
        {

			if (last != 69) { oh.Add(last); }
			int e = Random.Range(0, oh.Count);
			
			last = e;

			anim.CrossFadeInFixedTime(estados[oh[e]], 0.4f, -1, 0, 0);
			oh.Remove(e);
			yield return new WaitForSeconds(4);

		}

    }
}
