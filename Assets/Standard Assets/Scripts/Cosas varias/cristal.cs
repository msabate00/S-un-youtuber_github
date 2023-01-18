using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cristal : MonoBehaviour {

	public GameObject shatter;
    public AudioClip[] sonidos;
    public int id;
    public bool[] com = new bool[4];

	public void bum(Vector3 pos)
    {
        GameObject lol = Instantiate(shatter, pos, transform.rotation);
        lol.transform.localPosition += lol.transform.right * -0.02f;
        lol.GetComponent<AudioSource>().clip = sonidos[Random.Range(0, sonidos.Length)];
        lol.GetComponent<AudioSource>().Play();
        lol.SendMessage("uf");
    }

    public void uf()
    {
        StartCoroutine(sex());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("cristal"))
        {
            //GetComponentInParent<cristal>().com[id] = true;
            transform.parent.GetComponent<cristal>().com[id] = true;
        }
    }

    IEnumerator sex()
    {
        GetComponentInChildren<SpriteRenderer>().enabled = false;

        yield return null;
        yield return null;

        for (int i = 0; i < 4; i++)
        {
            if (!com[i]) { yield break; }           
        }

        GetComponentInChildren<SpriteRenderer>().enabled = true;
    }
}
