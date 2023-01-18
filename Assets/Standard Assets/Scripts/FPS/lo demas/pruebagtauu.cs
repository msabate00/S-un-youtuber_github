using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebagtauu : MonoBehaviour
{

    public float acceleration = 1f;
    private float horigay;
    private float vertigay;
    public audiosglobal[] gays;
    public AudioSource[] gays2;

    void Start()
    {
        gays = (audiosglobal[])GameObject.FindObjectsOfType(typeof(audiosglobal));
        gays2 = (AudioSource[])GameObject.FindObjectsOfType(typeof(AudioSource));

    }

    private void Update()
    {
       
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (horizontal == 1) horigay += 1 * acceleration * Time.deltaTime;
        if (horizontal == -1) horigay -= 1 * acceleration * Time.deltaTime;
        if (horizontal == 0)
        {
            if (Mathf.Abs(horigay) > 0 && Mathf.Abs(horigay) < 0.01f)
            {
                horigay = 0;
            }
                if (horigay > 0)
            {
                horigay -= 1 * acceleration * Time.deltaTime;
            }

            if (horigay < 0)
            {
                horigay += 1 * acceleration * Time.deltaTime;
            }
        }


        if (vertical == 1) vertigay += 1 * acceleration * Time.deltaTime;
        if (vertical == -1) vertigay -= 1 * acceleration * Time.deltaTime;
        if (vertical == 0)
        {
            if (Mathf.Abs(vertigay) > 0 && Mathf.Abs(vertigay) < 0.1f)
            {
                vertigay = 0;
            }
            if (vertigay > 0)
            {
                vertigay -= 1 * acceleration * Time.deltaTime;
            }

            if (vertigay < 0)
            {
                vertigay += 1 * acceleration * Time.deltaTime;
            }
        }

        horigay = Mathf.Clamp(horigay, -1, 1);
        vertigay = Mathf.Clamp(vertigay, -1, 1);

    }
    
}
