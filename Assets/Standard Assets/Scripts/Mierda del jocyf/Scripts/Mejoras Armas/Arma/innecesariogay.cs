using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class innecesariogay : MonoBehaviour {

    public Transform Gun;
    public float x = 0.1f;
    public float y = 0.1f;
    public float z = 0.1f;

    void Start () {
        Gun.localScale += new Vector3(x, y, z);
    }
	
	// Update is called once per frame
	void Update () {
        Gun.transform.position += Gun.transform.up * 0.03f;
    }
}
