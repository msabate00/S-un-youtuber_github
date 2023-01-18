using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class botonesgays : MonoBehaviour {

	public Image fondo;

	public void volver (string gay) {
		Controlador.ah.guardar();
		StartCoroutine(sexualsex(gay));
	}
		
	IEnumerator sexualsex(string gay)
    {
		yield return null;

		Color orig = fondo.color;
		orig.a = 0;
		fondo.gameObject.SetActive(true);
		float alpha = 0;

        while (true)
        {
			alpha += 0.5f * Time.deltaTime;
			alpha = Mathf.Clamp(alpha, 0, 1);
			orig.a = alpha;
			fondo.color = orig;

			if (alpha == 1) { break; }

			yield return null;
		}

		yield return new WaitForSeconds(0.4f);
		Controlador.adondequiereirbro = gay;
		if (Controlador.ah.activacursorgay != null) { StopCoroutine(Controlador.ah.activacursorgay); }

		SceneManager.LoadSceneAsync(gay);
	}
}
