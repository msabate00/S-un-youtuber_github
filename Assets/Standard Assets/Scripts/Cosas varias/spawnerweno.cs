using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class spawnerweno : MonoBehaviour {

	public Animation furgo;
	public GameObject invisible;
	public GameObject orig;
	public GameObject explotar;
	public Transform bumpos;
	public float siguiente = 5;
	public float esperaronda = 5;
	public Transform[] spawns;
	public GameObject[] Ene;
	public int enemigosact;
	public int enemigosactesp;
	public int enemigosmax = 5;
	public int enemigosmaxesp = 2;
	public float prob;
	public int enemigosmataos;
	public int ronda = 0;
	public List<Spawners> penis = new List<Spawners>();
	public ListaDrops Drops;
	public static bool zona = false;
	public Transform[] estandartes;
	private float puntosrondagays = 0;

	private Coroutine ninja2culero;

	private TextMeshProUGUI mierda1;
	private TextMeshProUGUI mierda2;

	void Awake()
    {
		Controlador.enemigosactuales = 0;
		Controlador.enemigosactualesesp = 0;
		Controlador.enemigoslista = new int[Ene.Length];
	}
	
	void Start () {

		//StartCoroutine("gays");
		AsignarId();

		StartCoroutine(gays2());
		mierda1 = GameObject.Find("MierdasGays").GetComponent<TextMeshProUGUI>();
	}

	
	void Update () {

		
		enemigosact = Controlador.enemigosactuales;
		enemigosactesp = Controlador.enemigosactualesesp;

		//mierda1.text = enemigosact.ToString();

		/*
		if (Time.time > sig)
        {
			sig = Time.time + siguiente;
			ins();
        }
		*/
	}
	
	IEnumerator gays()
    {
		while (true)
        {
			yield return new WaitWhile(() => enemigosact >= enemigosmax);
			yield return new WaitForSeconds(siguiente);

			int a = Random.Range(0, spawns.Length);
			int e = 0;
			if (Random.Range(0, 101) < prob && enemigosactesp < enemigosmaxesp)
            {
				e = Random.Range(1,3);
            }
			Instantiate(Ene[e], spawns[a].position, spawns[a].rotation);
		}	
	}

	IEnumerator gays2()
	{
		yield return null;

		Dropear();
		
		yield return new WaitUntil(() => enemigosact == 0);
		yield return new WaitUntil(() => zona);

		puntosrondagays = Controlador.puntos;
		furgo.Play();
		invisible.SetActive(true);

		int cancionlol = -1;
		int cancionlolant = -1;
		musica mus = GameObject.Find("Musica").GetComponent<musica>();

		cancionlol = Controlador.ah.gameObject.GetComponent<audiosglobal>().adar();
		yield return null;
		Controlador.ah.gameObject.GetComponent<audiosglobal>().rular(mus.Canciones[cancionlol].cancion[0], 4, 1);

		
		//yield return new WaitForSeconds(esperaronda);

		float factor = 1;

		if (Controlador.dificultad == 0)
        {
			factor = 0.4f;
        }
		else if (Controlador.dificultad == 1)
        {
			factor = 1f;
		}
        else
        {
			factor = 1.25f;
		}

		while (true)
		{
			StartCoroutine(activarestandares(true));

			enemigosmataos = 0;
			siguiente = penis[ronda].tiempoespera;
			prob = penis[ronda].randesp;
			enemigosmax = penis[ronda].maxen;
			enemigosmaxesp = penis[ronda].maxesp;
			esperaronda = penis[ronda].tiempoesperaronda;
			//Controlador.enemigosactuales = 0;
			//Controlador.enemigosactualesesp = 0;

			float facsig = 1;
			float limite = 1;

			if (Controlador.dificultad == 0)
			{
				facsig = 1.3f;
				limite = 0.8f;
			}
			else if (Controlador.dificultad == 1)
			{
				facsig = 1f;
			}
			else
			{
				facsig = 0.7f;
				limite = 1.3f;
			}

			siguiente *= facsig;
			enemigosmax = Mathf.RoundToInt(enemigosmax * limite);

			if (penis[ronda].explosion)
            {
				fuerza();
			}
			
			yield return new WaitForSeconds(esperaronda);
			puntosrondagays = Controlador.puntos;
			StartCoroutine(activarestandares(false));
			Rondagay(ronda);

			/*
			if (cancionlolant == cancionlol)
            {
				if (ronda == penis.Count - 1)
                {
					cancionlol = GameObject.Find("Musica").GetComponent<musica>().Canciones.Length - 1;
				}
                else
                {
					cancionlol = Controlador.ah.gameObject.GetComponent<audiosglobal>().adar();
				}
				
			}
			*/
			yield return null;
			Controlador.ah.gameObject.GetComponent<audiosglobal>().rular(mus.Canciones[cancionlol].cancion[1], 4, 1);


			while (true)
            {
				if (enemigosmataos >= penis[ronda].enemigosbajas * factor) { break; }

				yield return new WaitWhile(() => enemigosact >= enemigosmax);
				yield return new WaitForSeconds(siguiente);

				int a = penis[ronda].spawnersid[Random.Range(0, penis[ronda].spawnersid.Length)];
				int e = 0;
				if (Random.Range(0, 101) < prob && enemigosactesp < enemigosmaxesp)
				{
					e = Random.Range(1, 3);
				}
				GameObject penisgay = Instantiate(Ene[e], spawns[a].position, spawns[a].rotation);
				penisgay.SendMessage("asignarspawner");
			}

			int fase = 0;
			yield return new WaitForSeconds(2);

			while (true)
            {
				if (fase >= penis[ronda].bumlol.Count || penis[ronda].bumlol[fase].bum == Vector4.zero) { break; }
				yield return new WaitUntil(() => enemigosact <= penis[ronda].bumlol[fase].bum.z);

				float rango = 10;
				
				for (int i = 0; i < penis[ronda].bumlol[fase].bum.x * factor; i++)
                {
					int a = penis[ronda].spawnersid[Random.Range(0, penis[ronda].spawnersid.Length)];
					int e = 0;

					GameObject penisgay = Instantiate(Ene[e], spawns[a].position + new Vector3(Random.Range(-rango, rango), 0, Random.Range(-rango, rango)), spawns[a].rotation);
					penisgay.SendMessage("asignarspawner");
				}
				for (int i = 0; i < penis[ronda].bumlol[fase].bum.y * factor; i++)
				{
					int a = penis[ronda].spawnersid[Random.Range(0, penis[ronda].spawnersid.Length)];
					int e = Random.Range(1, 3);

					GameObject penisgay = Instantiate(Ene[e], spawns[a].position + new Vector3(Random.Range(-rango, rango), 0, Random.Range(-rango, rango)), spawns[a].rotation);
					penisgay.SendMessage("asignarspawner");
				}
				for (int i = 0; i < penis[ronda].bumlol[fase].bum.w; i++)
				{
					int a = penis[ronda].spawnersid[Random.Range(0, penis[ronda].spawnersid.Length)];
					int e = 3;

					GameObject penisgay = Instantiate(Ene[e], spawns[a].position + new Vector3(Random.Range(-rango, rango), 0, Random.Range(-rango, rango)), spawns[a].rotation);
					penisgay.SendMessage("asignarspawner");
				}

				//cancióngay
				

				if (penis[ronda].bumlol[fase].opcional != null)
                {
					Controlador.ah.gameObject.GetComponent<audiosglobal>().rular(penis[ronda].bumlol[fase].opcional, 4, 1);
				}
                else
                {					
					if (mus.Canciones[cancionlol].cancion[1] != Controlador.ah.gameObject.GetComponent<AudioSource>().clip)
					{
						Controlador.ah.gameObject.GetComponent<audiosglobal>().rular(mus.Canciones[cancionlol].cancion[1], 4, 1);
					}					
				}
				
				fase++;

				yield return null;
				yield return null;

				if (Controlador.enemigoslista[3] > 0)
				{
					if (ninja2culero != null) { StopCoroutine(ninja2culero); }
					ninja2culero = StartCoroutine(ninja2());
					//poner otro while y cosas
				}
			}

			

			yield return null; yield return null;
			yield return new WaitUntil(() => enemigosact == 0);

			ronda++;
			cancionlolant = cancionlol;
			puntosronda();
			if (ronda >= penis.Count) { Debug.Log("Congratulations fuckface, you motherfucking won yo bitch"); Controlador.ah.gameObject.GetComponent<audiosglobal>().rular(mus.af[0], 4, 1f); Controlador.ah.gameObject.GetComponent<AudioSource>().loop = false; puntoswin(); break; }
            else {

				if (ronda == penis.Count - 1)
				{
					cancionlol = GameObject.Find("Musica").GetComponent<musica>().Canciones.Length - 1;
				}
				else
				{
					cancionlol = Controlador.ah.gameObject.GetComponent<audiosglobal>().adar();
				}

				cancionlolant = cancionlol;

				Controlador.ah.gameObject.GetComponent<audiosglobal>().rular(mus.Canciones[cancionlol].cancion[0], 4, 1);
				Debug.Log(cancionlol);
			}

			Dropear();

			//yield return new WaitForSeconds(esperaronda);
		}

		if (Controlador.ah.para != null) { StopCoroutine(Controlador.ah.para); }

			Controlador.ah.para = StartCoroutine(Controlador.ah.resetear(false));

		Muevo.Sacabo();
	}

	IEnumerator ninja2()
    {
		while(Controlador.enemigoslista[3] >= 1)
        {
			if (enemigosact == Controlador.enemigoslista[3])
            {
				float timer = Time.time + 17;

				while (timer > Time.time)
                {
					if (enemigosact != Controlador.enemigoslista[3])
                    {
						break;
                    }
					yield return null;
                }

				if (enemigosact == Controlador.enemigoslista[3])
                {
					int a = Random.Range(0, spawns.Length);
					GameObject penisgay = Instantiate(Ene[0], spawns[a].position, spawns[a].rotation);
					penisgay.SendMessage("asignarspawner");
				}
            }

			yield return null;
        }

		ninja2culero = null;
	}

	void puntosronda()
    {
		float puntosprov = Controlador.puntos - puntosrondagays;

		puntosprov = puntosprov * ronda;
		puntosprov = Mathf.RoundToInt(puntosprov);
		GameObject.Find("PutosPuntosGays").GetComponent<putosgays>().gays(puntosprov, 18);	
    }

	public void sumarmuerte()
    {
		enemigosmataos++;
	}

	void puntoswin()
    {
		//Controlador.acabado = true;

		float factor = 1;
		if (Controlador.dificultad == 0)
        {
			factor = 1.3f;
        }
		else if (Controlador.dificultad == 1)
        {
			factor = 1.5f;
        }
        else
        {
			factor = 1.7f;
        }

		float pts = Controlador.puntos * factor;
	    int pts2 = Mathf.RoundToInt(pts - Controlador.puntos);

		GameObject.Find("PutosPuntosGays").GetComponent<putosgays>().gays(pts2, 17);
		//Controlador.puntos += pts;
		//Controlador.puntostotales += pts;
    }

	void Dropear()
    {
		
		for (int i = 0; i < 4; i++)
        {
			if (Drops.Disponibles.Count == 0 || Drops.DropsDisponibles.Count == 0) { return; }

			int Lugar = Random.Range(0, Drops.Disponibles.Count);
			drops elegido = Drops.Disponibles[Lugar];

			Drops.Disponibles.RemoveAt(Lugar);
			Drops.Ocupados.Add(elegido);

			Lugar = Random.Range(0, Drops.DropsDisponibles.Count);
			ElDrop DropElegido = Drops.DropsDisponibles[Lugar];

			DropElegido.Disponibles--;

			GameObject drup = Instantiate(DropElegido.Drop, elegido.spawn.position, elegido.spawn.rotation);
			//ENVIAR ID DEL DROP A DRUP Y ID DEL SPAWN
			municionsuelogay sex = new municionsuelogay(DropElegido.Id, elegido.Id, this);
			drup.GetComponentInChildren<municionsuelo>().sex = sex;

			if (DropElegido.Disponibles == 0)
			{
				Drops.DropsDisponibles.RemoveAt(Lugar);
				Drops.DropsAcabados.Add(DropElegido);
			}
		}		
	}

	void AsignarId()
    {
		for (int i = 0; i < Drops.Disponibles.Count; i++)
        {
			Drops.Disponibles[i].Id = i;
		}
    }

	public void Restaurar(int IdDrop, int IdSpawn)
    {

		for (int i = 0; i < Drops.Ocupados.Count; i++)
        {
			if (Drops.Ocupados[i].Id == IdSpawn)
            {
				drops elegido = Drops.Ocupados[i];
				Drops.Ocupados.RemoveAt(i);
				Drops.Disponibles.Add(elegido);

				break;
			}
        }

		for (int i = 0; i < Drops.DropsDisponibles.Count; i++)
		{
			if (Drops.DropsDisponibles[i].Id == IdDrop)
			{
				ElDrop elegido = Drops.DropsDisponibles[i];
				elegido.Disponibles++;

				break;
			}
		}

		for (int i = 0; i < Drops.DropsAcabados.Count; i++)
		{
			if (Drops.DropsAcabados[i].Id == IdDrop)
			{
				ElDrop elegido = Drops.DropsAcabados[i];
				elegido.Disponibles++;
				Drops.DropsAcabados.RemoveAt(i);
				Drops.DropsDisponibles.Add(elegido);

				break;
			}
		}
	}

	void fuerza()
    {
		StartCoroutine(penisman());
	}

	IEnumerator penisman()
    {
		yield return new WaitForSeconds(esperaronda - 1.5f);
		bumpos.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(2.5f);
		orig.SetActive(false);
		explotar.SetActive(true);

		yield return null;
		yield return null;
		yield return null;
		
		int layerMask = 1 << 21;
		Collider[] lols = Physics.OverlapSphere(bumpos.position, 30, layerMask);

		foreach (Collider hit in lols)
		{
			Rigidbody rb = hit.GetComponent<Rigidbody>();

			if (rb != null)
				rb.AddExplosionForce(10000, bumpos.position, 40, 3.0F);
		}
	}

	IEnumerator activarestandares(bool sex)
    {
		Vector3 des = Vector3.zero;

		if (sex)
        {
			des.y = 0;
        }
        else
        {
			des.y = -18;
        }
        while (true)
        {
			for (int i = 0; i < estandartes.Length; i++)
			{
				estandartes[i].localPosition = Vector3.MoveTowards(estandartes[i].localPosition, des, 18 * Time.deltaTime);

				if (i == estandartes.Length -1 && estandartes[i].localPosition == des)
                {
					yield break;
                }
			}
			yield return null;
		}
		
    }

	void Rondagay(int sex)
    {
		string[] trans = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };

		GameObject RondaUI = GameObject.Find("RondaUI");
		RondaUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Ronda " + trans[sex];
		RondaUI.GetComponent<Animation>().Play();
		Debug.Log("SEXUALIZAR");
    }

}
