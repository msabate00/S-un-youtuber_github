using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bajalfaostia : MonoBehaviour {

	public Color ah;
	void Start () {
		Destroy(gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
		ah.a = Mathf.MoveTowards(ah.a, 0, 1 * Time.deltaTime);
		GetComponent<TrailRenderer>().material.SetColor("_TintColor", ah);
	}
	
	public IEnumerator lol(Vector3 pos)
    {
		yield return new WaitForEndOfFrame();
		transform.position = pos;
	}
}
