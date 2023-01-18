using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport10 : MonoBehaviour {

    //public GameObject pene;
    //public Vector3 zorra;
   // public GameObject vagina;
    public GameObject FPC;
    private Transform FPCins;
    public static float tiempo;
    public Vector3 Offset;
    public GameObject parent;
    public Transform cam;

    void cacas()
    {
        //Debug.Log(cam.position.y);
        //FPCins = Instantiate(FPC, transform.position + Offset - (Vector3.up * 4.396557f), cam.rotation).transform;
        FPCins = Instantiate(FPC, transform.position + Offset, cam.rotation).transform;
        FPCins.localEulerAngles = new Vector3(0, FPCins.localEulerAngles.y, 0);
        Transform ostiador = GetComponentInParent<Camera>().transform;
        Transform player = FPCins.GetComponentInChildren<Camera>().transform;
        float sex = player.position.y - ostiador.position.y;
        FPCins.position -= Vector3.up * sex;
        //Debug.Log(FPCins.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).position.y);

        Transform a = FPCins.gameObject.GetComponentInChildren<lanzarputasbolsas>().transform;
        Vector3 gay = a.position - transform.parent.position;
        //Debug.Log(transform.position.y);
        Destroy(parent);
    }

	
	



}
