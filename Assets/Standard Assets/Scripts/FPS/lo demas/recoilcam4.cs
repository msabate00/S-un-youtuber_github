using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recoilcam4 : MonoBehaviour {

    public float intensidad;
    private float timer;
    private float timerecupera;
    private float timermax;
    public bool dual2 = false;
    private DisparoSelectivo sex;
    private bool dejenme = false;
    public float canty;
  
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
            penis = penis.normalized;
            penis *= intensidad;
            MouseLook.rotationX3 = penis.x;
            MouseLook.rotationY3 = penis.y;
            canty = 0;

            while (true)
            {
                
                if (FPCStatus.isShooting || FPCStatus.isShooting2 && dual2 || hedisparaosubnormal)
                {
                    timer = 0;
                    penis = new Vector2(Random.Range(sex.GunStatusScript.recoilx.x, sex.GunStatusScript.recoilx.y), Random.Range(sex.GunStatusScript.recoily.x, sex.GunStatusScript.recoily.y)).normalized;
                    penis *= intensidad;
                    MouseLook.rotationX3 = penis.x;
                    MouseLook.rotationY3 = penis.y;
                }
                canty = canty + (penis.y * Time.deltaTime);
                if (timer > timermax) { break; }
                yield return null;
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

                if (timerecupera > 0.2f || canty <= 0)
                {
                    break;
                }

                float putos = -intensidad * 1.5f;
                if (Mathf.Abs(putos * Time.deltaTime) > canty) { putos = -canty; }
                MouseLook.rotationY3 = putos;
                canty += putos * Time.deltaTime;

                timerecupera += Time.deltaTime;

                yield return null;
            }
        }
    }

}
