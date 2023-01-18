// C#
//RecoilScript.cs
using UnityEngine;
using System.Collections;

public class FUCK : MonoBehaviour
{
    //these variables are used to determine the angles n shit of the recoil of the weapon, on which the player 
    //are shooting with
    private Vector3 ang0;
    private Vector3 ang = Vector3.zero;
    private float targetX;
    public float force = 2.5f; //Controlls recoil amplitude
    public float upSpeed = 9; // controls smoothing speed
    public float dnSpeed = 20; // controls how fast the weapon returns to original position

    void Update()
    {
        //Recoil
        ang0 = transform.localEulerAngles; // Save the original angles.
        ang.x = Mathf.Lerp(ang.x, targetX, upSpeed * Time.deltaTime);
        transform.localEulerAngles = ang0 - ang; // move the camera.
        targetX = Mathf.Lerp(targetX, 0, dnSpeed * Time.deltaTime); //returns to rest
                                                                    //Recoil
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Recoil();
        }
    }

    public void Recoil()
    {
        targetX += force;//Add the recoil force
    }
}