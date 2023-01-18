using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cosa1 : MonoBehaviour {

    public Transform sitio;
    public Transform Gan;
    private Vector3 MyPas;
    public float RecoilRandomDispl = 2;
    public float RecoilAmount = 2;
    void Awake () {
        
        MyPas = Gan.localPosition;
    }
	
	// Update is called once per frame
	void OnEnable () {
        Debug.Log(Gan.localPosition);
        
        Gan.localPosition = MyPas;
        MyPas.x = MyPas.x + Random.Range(0f, RecoilRandomDispl);
        MyPas.y = MyPas.y + Random.Range(0f, RecoilRandomDispl);
        MyPas.z = MyPas.z - RecoilAmount;
        if (MyPas.z < 0)
        {
            MyPas.z = 0;
        }
    }
}
