using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lucesalamierda : MonoBehaviour {

    public GameObject sparks;
    private bool dao = false;
    public MeshRenderer penis;

	public void AplicaDamage()
    {
        if (dao) { return; }
        StopAllCoroutines();
        StartCoroutine(analsex());
    }

    IEnumerator analsex()
    {
        yield return null;
        dao = true;
        Light gay = GetComponentInChildren<Light>();        
        Instantiate(sparks, transform.position, Quaternion.identity);
        GetComponent<AudioSource>().Play();

        var intMaterials = new Material[penis.materials.Length];
        var orig = new Material[penis.materials.Length];

        for (int i = 0; i < penis.materials.Length; i++)
        {
            intMaterials[i] = penis.materials[i];
            orig[i] = penis.materials[i];
        }

        gay.enabled = false;
        intMaterials[1] = intMaterials[2];
        penis.materials = intMaterials;

        bool sex = true;

        for (int i = 0; i < Random.Range(20,45); i++)
        {
            yield return new WaitForSeconds(0.05f);
            

            if (sex)
            {
                penis.materials = orig;
                gay.enabled = true;
            }
            else
            {
                penis.materials = intMaterials;
                gay.enabled = false;
            }

            sex = !sex;
        }

        yield return new WaitForSeconds(0.05f);

        penis.materials = intMaterials;
        gay.enabled = false;
    }
}
