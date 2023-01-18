using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parcheescopeta : MonoBehaviour
{
    public Vector3[] pos;
    public Vector3[] rot;
    public Transform[] sex;

    void Start()
    {
        sex = GetComponentsInChildren<Transform>();
        rot = new Vector3[sex.Length];
        pos = new Vector3[sex.Length];

        for (int i = 0; i < sex.Length; i++)
        {
            pos[i] = sex[i].localPosition;
            rot[i] = sex[i].localEulerAngles;
        }
    }

    public void Resetear()
    {
        Debug.Log("QUE TE JODAN");
        for (int i = 0; i < sex.Length; i++)
        {
            sex[i].localPosition = pos[i];
            sex[i].localEulerAngles = rot[i];
        }
    }
   
}
