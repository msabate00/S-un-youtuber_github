using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corrase : MonoBehaviour {

    public Animation anim;
    private string runAnimation = "idlepollas";
    void Start () {

        anim = GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
   //     Debug.Log(FPCStatus.isRunning);
        if (FPCStatus.isRunning)
        {
            anim.CrossFade("CameraRun");
            anim["CameraRun"].speed = 0.8f;
        }
       else
            anim.CrossFade("Cameraidlegay");
    }
}
