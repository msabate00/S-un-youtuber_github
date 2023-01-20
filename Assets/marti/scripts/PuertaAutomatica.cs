using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaAutomatica : MonoBehaviour
{
    public Animator anim;
    private AnimatorStateInfo animStateInfo;
    public AudioClip[] sonidos = new AudioClip[2];
    private AudioSource[] a;
    private Coroutine lel;
    public bool abierta = false;

    private void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("PuertaCerrada"))
        {
            abierta = false;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("PuertaAbierta"))
        {
            abierta = true;
        }
    }

    void Start()
    {
        a = GetComponents<AudioSource>();
        StartCoroutine(actualizar());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("cerca", true);
        }

        if (lel != null)
        {
            StopCoroutine(lel);
        }

        lel = StartCoroutine(sonidosgays());
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("cerca", false);
        }

        if (lel != null)
        {
            StopCoroutine(lel);            
        }

        lel = StartCoroutine(sonidosgays());
    }

    IEnumerator actualizar()
    {
        bool sex = !abierta;

        while (true)
        {
            if (sex == abierta)
            {
                pum();
                sex = !abierta;
            }

            yield return null;
        }
    }

    void pum()
    {
        a[0].Stop();
        a[1].Stop();
        a[0].clip = null;
        a[0].loop = false;
        a[1].clip = sonidos[1];
        a[1].Play();
    }

    IEnumerator sonidosgays()
    {
        yield return null;
        yield return null;
        yield return null;

        string sex = "";
        bool quieta = false;
        bool ahora = abierta;

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("PuertaCerrada"))
        {
            sex = "PuertaAbrierta";
        }
        else
        {
            sex = "PuertaCerrada";
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("PuertaCerrada") || anim.GetCurrentAnimatorStateInfo(0).IsName("PuertaAbierta"))
        {
            quieta = true;
        }

        if (quieta)
        {
            //a[0].loop = true;
            a[0].clip = sonidos[0];
            a[0].Play();
        }

        
    }
}
