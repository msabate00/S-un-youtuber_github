using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class municionsuelo : MonoBehaviour {

	public bool curacion = false;
	public Vector2 id;
	public Vector2 mun;
	public int id2;
	public int mun2;
	public municionsuelogay sex;
	public AudioClip morido;
	public enum sexgay { Generico, Espada, Melee, Curacion};
	public sexgay gay;


	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("micuerpochingon"))
		{
			penisman();
			Debug.Log("PUTAMIERDA");
		}

	}

	void penisman()
	{
		int factor = 1;
		if (agarre2.espadahit)
		{
			factor = 4;
		}
		factor = 1;

		bool asignado = false;

		if (gay == sexgay.Curacion)
		{
			if (Controlador.vidahomosexual == 100) { return; }

			float orig = Controlador.vidahomosexual;

			Controlador.vidahomosexual = Controlador.vidahomosexual + Random.Range(id.x, id.y);

			Controlador.vidahomosexual = Mathf.Clamp(Controlador.vidahomosexual, 0, 100);

			float dif = Controlador.vidahomosexual - orig;

			mostradorUI mierdas = GameObject.Find("VidaUI").GetComponent<mostradorUI>();

			mierdas.SendMessage("actualizar");

			mierdas.SendMessage("interfaz", dif);

			asignado = true;
		}
		else if (gay == sexgay.Espada)
        {
			if (Controlador.cargas == 3) { return; }

			RegenEspada lol = GameObject.Find("ArmasUI").GetComponent<RegenEspada>();
			lol.Ajuste(true);

			asignado = true;
		}
		else if (gay == sexgay.Melee)
        {
			if (Controlador.desfibrilador == 2) { return; }

			Controlador.desfibrilador = 2;
			asignado = true;
		}
		else if (gay == sexgay.Generico)
		{
			normalizador weon = GameObject.Find("Controlador").GetComponent<normalizador>();
			DisparoSelectivo gay = GameObject.FindGameObjectWithTag("ELPLAYERJODER").GetComponentInChildren<DisparoSelectivo>();

			if (weon.listagay[Mathf.FloorToInt(id.x)].CargadoresAct == 0)
			{
				int pollas = Mathf.FloorToInt(id.x);

				GunStatus rabos = gay.Armas[pollas].GetComponent<GunStatus>();

				if (weon.listagay2[pollas].BalasAct != weon.listagay[pollas].BalasAct)
				{

					rabos.BalasActualesEnCargador += Mathf.FloorToInt(mun.x * factor);

					rabos.BalasActualesEnCargador = Mathf.Clamp(rabos.BalasActualesEnCargador, 0, weon.listagay[pollas].BalasAct);

					weon.listagay2[pollas].BalasAct = rabos.BalasActualesEnCargador;
					asignado = true;
				}
			}
			else
			{
				int pollas = Mathf.FloorToInt(id.x);

				GunStatus rabos = gay.Armas[pollas].GetComponent<GunStatus>();

				if (weon.listagay2[pollas].CargadoresAct + weon.listagay[pollas].BalasAct + weon.listagay[pollas].BalasActArma2 - weon.listagay2[pollas].BalasAct - weon.listagay2[pollas].BalasActArma2 != weon.listagay[pollas].CargadoresAct)
				{
					Debug.Log(weon.listagay2[pollas].CargadoresAct + weon.listagay[pollas].BalasAct + weon.listagay[pollas].BalasActArma2 - weon.listagay2[pollas].BalasAct - weon.listagay2[pollas].BalasActArma2);
					Debug.Log(weon.listagay[pollas].CargadoresAct + weon.listagay[pollas].BalasAct + weon.listagay2[pollas].BalasActArma2);

					rabos.CargadoresActuales += Mathf.FloorToInt(mun.x * factor);

					rabos.CargadoresActuales = Mathf.Clamp(rabos.CargadoresActuales, 0, weon.listagay[pollas].CargadoresAct + weon.listagay[pollas].BalasAct + weon.listagay[pollas].BalasActArma2 - weon.listagay2[pollas].BalasAct - weon.listagay[pollas].BalasActArma2);

					weon.listagay2[pollas].CargadoresAct = rabos.CargadoresActuales;

					asignado = true;
				}
			}


			if (weon.listagay[Mathf.FloorToInt(id.y)].CargadoresAct == 0)
			{
				int pollas = Mathf.FloorToInt(id.y);

				GunStatus rabos = gay.Armas[pollas].GetComponent<GunStatus>();

				if (weon.listagay2[pollas].BalasAct != weon.listagay[pollas].BalasAct)
				{

					rabos.BalasActualesEnCargador += Mathf.FloorToInt(mun.y * factor);

					rabos.BalasActualesEnCargador = Mathf.Clamp(rabos.BalasActualesEnCargador, 0, weon.listagay[pollas].BalasAct);

					weon.listagay2[pollas].BalasAct = rabos.BalasActualesEnCargador;

					asignado = true;
				}
			}
			else
			{
				int pollas = Mathf.FloorToInt(id.y);

				GunStatus rabos = gay.Armas[pollas].GetComponent<GunStatus>();

				if (weon.listagay2[pollas].CargadoresAct + weon.listagay[pollas].BalasAct + weon.listagay[pollas].BalasActArma2 - weon.listagay2[pollas].BalasAct - weon.listagay2[pollas].BalasActArma2 != weon.listagay[pollas].CargadoresAct)
				{

					rabos.CargadoresActuales += Mathf.FloorToInt(mun.y * factor);

					rabos.CargadoresActuales = Mathf.Clamp(rabos.CargadoresActuales, 0, weon.listagay[pollas].CargadoresAct + weon.listagay[pollas].BalasAct + weon.listagay[pollas].BalasActArma2 - weon.listagay2[pollas].BalasAct - weon.listagay[pollas].BalasActArma2);

					weon.listagay2[pollas].CargadoresAct = rabos.CargadoresActuales;

					asignado = true;
				}
			}

			if (mun2 > 0)
			{
				if (weon.listagay[Mathf.FloorToInt(id2)].CargadoresAct == 0)
				{
					int pollas = Mathf.FloorToInt(id2);

					GunStatus rabos = gay.Armas[pollas].GetComponent<GunStatus>();

					if (weon.listagay2[pollas].BalasAct != weon.listagay[pollas].BalasAct)
					{

						rabos.BalasActualesEnCargador += Mathf.FloorToInt(mun2 * factor);

						rabos.BalasActualesEnCargador = Mathf.Clamp(rabos.BalasActualesEnCargador, 0, weon.listagay[pollas].BalasAct);

						weon.listagay2[pollas].BalasAct = rabos.BalasActualesEnCargador;

						asignado = true;
					}
				}
				else
				{
					int pollas = Mathf.FloorToInt(id2);

					GunStatus rabos = gay.Armas[pollas].GetComponent<GunStatus>();

					if (weon.listagay2[pollas].CargadoresAct + weon.listagay[pollas].BalasAct + weon.listagay[pollas].BalasActArma2 - weon.listagay2[pollas].BalasAct - weon.listagay2[pollas].BalasActArma2 != weon.listagay[pollas].CargadoresAct)
					{

						rabos.CargadoresActuales += Mathf.FloorToInt(mun2 * factor);

						rabos.CargadoresActuales = Mathf.Clamp(rabos.CargadoresActuales, 0, weon.listagay[pollas].CargadoresAct + weon.listagay[pollas].BalasAct + weon.listagay[pollas].BalasActArma2 - weon.listagay2[pollas].BalasAct - weon.listagay[pollas].BalasActArma2);

						weon.listagay2[pollas].CargadoresAct = rabos.CargadoresActuales;

						asignado = true;
					}
				}
			}

		}

		if (asignado) { asignabro(); }

	}

	void asignabro()
    {
		sex.spawn.Restaurar(sex.IdDrop, sex.IdSpawn);
		if (morido != null)
		{
			AudioSource[] penis = GameObject.FindGameObjectWithTag("Audio Sourcesgays").GetComponents<AudioSource>();
			penis[0].Stop();
			penis[0].PlayOneShot(morido);
		}
		Destroy(transform.root.gameObject);
	}
}

public class municionsuelogay {

	public int IdDrop = -1;
	public int IdSpawn = -1;
	public spawnerweno spawn;

	public municionsuelogay(int IdDrop2, int IdSpawn2, spawnerweno spawn2)
    {
		IdDrop = IdDrop2;
		IdSpawn = IdSpawn2;
		spawn = spawn2;
	}

}
