using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cosa : MonoBehaviour {

    public Transform Gan;
    private Vector3 MyPas;
    public Transform MyPos;
    public float RecoilRandomDispl = 2;
    public float RecoilAmount = 2;
    public float lols = 2;
    void Awake () {
        MyPas = Gan.localPosition;
    }
	
	// Update is called once per frame
	void OnEnable () {
        Debug.Log(Gan.localPosition);

        MyPas = Gan.localPosition;
        MyPas.x = MyPas.x + Random.Range(0f, RecoilRandomDispl);
        MyPas.y = MyPas.y + Random.Range(0f, RecoilRandomDispl);
        MyPas.z = MyPas.z - RecoilAmount;        
        Gan.localPosition = MyPas;
        if (MyPas.z < 0)
        {
            MyPas.z = 0;
        }
    }

    void Update()
    {
        Gan.localPosition = Vector3.Lerp(Gan.localPosition, MyPos.position, lols *Time.deltaTime);
        if (Gan == MyPos)
        {
            Debug.Log("LOL TIO");
        }
    }


}
