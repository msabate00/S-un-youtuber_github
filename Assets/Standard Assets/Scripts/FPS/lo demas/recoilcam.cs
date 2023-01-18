using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recoilcam : MonoBehaviour {

    public Transform cam;
    public float velosida;
    private float rotcam;
    private Vector3 camaractual;
    private Vector3 palla;
    private Vector3 origay;
    private float timingay;
    private Quaternion original;
    private bool paraostia = false;
    private bool disparao = false;
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {


        if (FPCStatus.isShooting)
        {
            palla = transform.localEulerAngles;
            palla.x = palla.x + 10;

        }
        if (Input.GetButton("Fire1"))
        {
            putorecoil();
            paraostia = false;
            disparao = true;
        }
        if (!Input.GetButton("Fire1"))
        {
            
                if (!paraostia)
                {
                    if (cam.eulerAngles.x < 370 && cam.eulerAngles.x > 200)
                    {
                        origay = cam.eulerAngles;
                        origay.x -= 360;
                        
                    Vector3 mierda = transform.eulerAngles;
                    mierda.x -= origay.x;
                    original = Quaternion.Euler(mierda.x, 0, 0);
                    paraostia = true;
                }
                    if (cam.eulerAngles.x > 0 && cam.eulerAngles.x < 190)
                    {
                        origay = cam.eulerAngles;
                        origay.x = -origay.x;
                       
                    Vector3 mierda = transform.eulerAngles;
                    mierda.x -= origay.x;
                    original = Quaternion.Euler(mierda.x, 0, 0);
                    paraostia = true;
                }
                }
            if (disparao)
            {
                
                
                transform.localRotation = Quaternion.Lerp(transform.localRotation, original, velosida * Time.deltaTime);
                Debug.Log(original);
            }
        }

        



        if (cam.eulerAngles.x < 300 && cam.eulerAngles.x > 200)
        {
            rotcam = cam.eulerAngles.x;
            rotcam -= 300;
            transform.localEulerAngles += new Vector3(-rotcam, transform.localEulerAngles.y, 0);
        }
        if (cam.eulerAngles.x > 60 && cam.eulerAngles.x < 190)
        {
            rotcam = cam.eulerAngles.x;
            rotcam -= 60;
            transform.localEulerAngles -= new Vector3(rotcam, transform.localEulerAngles.y, 0);
        }
    }
    void putorecoil() {
        Debug.Log("cojones");
        Quaternion pollas2 = Quaternion.Euler(palla.x, palla.y, palla.z);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, pollas2, velosida * Time.deltaTime);
        Debug.Log(pollas2);
        //  transform.localEulerAngles = Quaternion.Lerp(transform.localEulerAngles, pollas, velosida * Time.deltaTime);
        // transform.eulerAngles = new Vector3(polla.x, transform.eulerAngles.y, 0);
    }







}
