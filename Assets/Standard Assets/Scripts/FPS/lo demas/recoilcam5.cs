using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recoilcam5 : MonoBehaviour {

    public float intensidad;
    public float intensidad2;
    private float timer;
    private float timerecupera;
    private float timermax;
    public bool dual2 = false;
    private DisparoSelectivo sex;
    private bool dejenme = false;
    public float canty;
    public float cantx;
    public Transform rotY;
  
    [HideInInspector]
    public bool hedisparaosubnormal = false;

    void Start()
    {
        sex = GetComponent<DisparoSelectivo>();
        StartCoroutine("sexoanal");
    }


    void Update()
    {
        timer += Time.deltaTime;
        timermax = sex.GunStatusScript.RatioDeDisparo + sex.GunStatusScript.recoiloffset;

   
    }

    IEnumerator sexoanal()
    {
        while (true)
        {
            MouseLook.rotationX3 = 0;
            MouseLook.rotationY3 = 0;

            yield return new WaitUntil(() => dejenme || FPCStatus.isShooting || FPCStatus.isShooting2 && dual2 || hedisparaosubnormal);

            timer = 0;
            dejenme = false;
            Vector2 penis = new Vector2(Random.Range(sex.GunStatusScript.recoilx.x, sex.GunStatusScript.recoilx.y), Random.Range(sex.GunStatusScript.recoily.x, sex.GunStatusScript.recoily.y));
            //penis = penis.normalized;
            penis *= intensidad * Time.deltaTime;
           
            //canty = 0;

            while (true)
            {

                float m_HorizontalAngle = transform.localEulerAngles.y;
                m_HorizontalAngle = m_HorizontalAngle + penis.x;

                if (m_HorizontalAngle > 360) m_HorizontalAngle -= 360.0f;
                if (m_HorizontalAngle < 0) m_HorizontalAngle += 360.0f;

                Vector3 currentAngles = transform.localEulerAngles;
                currentAngles.y = m_HorizontalAngle;
                transform.localEulerAngles = currentAngles;
                cantx = cantx + (penis.x);


                MouseLook.rotationY -= penis.y;
                MouseLook.rotationY = Mathf.Clamp(MouseLook.rotationY, -90, 90);

                Vector3 currentAngles2 = rotY.localEulerAngles;

                currentAngles2.x = MouseLook.rotationY;
                rotY.localEulerAngles = currentAngles2;


                canty = canty + (penis.y);
                yield return null;
                break;
                
            }

            timerecupera = 0;
            MouseLook.rotationX3 = 0;
            MouseLook.rotationY3 = 0;

            while (true)
            {
                if (FPCStatus.isShooting || FPCStatus.isShooting2 && dual2 || hedisparaosubnormal)
                {
                    dejenme = true;
                    break;
                }

                if (canty <= 0 && cantx <= 0)
                {
                    break;
                }

                bool ystop = false;
                float putos = -intensidad2 * 1f;
                if (Mathf.Abs(putos * Time.deltaTime) > canty) { putos = -canty; ystop = true; }
                MouseLook.rotationY3 = putos;
                
                if (ystop)
                {
                    canty = 0;
                }
                else
                {
                    canty += putos * Time.deltaTime;
                }

                bool xstop = false;
                float putos2 = intensidad2 * 1f;
                if (cantx < 0) { putos2 *= -1; }
                if (Mathf.Abs(putos2 * Time.deltaTime) > cantx) { putos2 = cantx; xstop = true; }
                MouseLook.rotationX3 = putos2;
                if (xstop)
                {
                    cantx = 0;
                }
                else
                {
                    cantx -= putos2 * Time.deltaTime;
                }

               
                
                timerecupera += Time.deltaTime;

                yield return null;
            }
        }
    }

}
