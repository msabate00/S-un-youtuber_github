using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoSecundario : MonoBehaviour {

	[HideInInspector]
	public GunStatus GunStatusScript;
	[HideInInspector]
	public Transform transformPuntoDisparo;
	private DisparoSelectivo selec;
	public bool Activao = true;
	public GameObject[] balas;
	public AudioClip[] sonidos;
	public GameObject ballestasonido;
	public ParticleSystem ps;
	private ParticleSystem.EmissionModule psad;
	public ParticleSystem ps2;
	private ParticleSystem.EmissionModule psad2;
	private int balasPUTAS;
	[HideInInspector]
	public bool disparo = false;
	private int nojoder = 0;
	public GameObject decall;
	public GameObject particulasgays;
	public Coroutine lolsexual;

	void Start()
    {
		selec = gameObject.GetComponent<DisparoSelectivo>();
		psad = ps.emission;
		psad2 = ps2.emission;
		desactivarpar();
	}

	void Update () {

		if (Controlador.acabado)
        {
			return;
        }

		if (Time.timeScale == 0 || Pausa.Pa.dentro) { return; }

		if (FPCStatus.IsFire2Pressed && !FPCStatus.IsFire1Pressed && !FPCStatus.transicion && !FPCStatus.melee && Activao && GunStatusScript.Armasgays != Armasgaystipos.Duales1 && selec.NumeroArma != 8)
        {
			TipoArma();			
		}
		if (Input.GetMouseButtonDown(2) && selec.NumeroArma == 8 && !FPCStatus.transicion && !FPCStatus.melee && Activao)
        {
			TipoArma();
		}

		else if (GunStatusScript.Armasgays == Armasgaystipos.Duales1 && FPCStatus.IsFire2Pressed && !FPCStatus.melee && Activao)
        {
			TipoArma();
		}
		if (Input.GetButtonUp("Fire2") && GunStatusScript.dual)
		{
			psad.enabled = false;			
		}
		if (GunStatusScript.Armasgays == Armasgaystipos.Duales2)
        {
			DisparoDuales2();
        }
	}

	void TipoArma()
	{

		var layerMask = (1 << 2);
		layerMask |= (1 << 0);
		layerMask |= (1 << 4);
		layerMask |= (1 << 8);
		layerMask |= (1 << 10);
		layerMask |= (1 << 13);
		layerMask |= (1 << 14);
		layerMask |= (1 << 17);
		layerMask |= (1 << 22);
		layerMask |= (1 << 23);
		layerMask = ~layerMask;

		if (GunStatusScript.Armasgays == Armasgaystipos.Arma1)
		{

			
			
			if (Time.time > Controlador.cd1ratio && Time.time > selec.TiempoDeDisparo && !FPCStatus.transicion)
            {
				if (FPCStatus.IsFire1Pressed && GunStatusScript.BalasActualesEnCargador > 0) { return; }
				FPCStatus.transicion = true;
				FPCStatus.especial = true;
				StartCoroutine("DisparoArma1");
				nojoder = 0;


			}
			else
			{
				
				
			}
			



		}
		else if (GunStatusScript.Armasgays == Armasgaystipos.Arma2) //BALLESTAHOMOSEXUAL
		{
		//	FPCStatus.especial = true;
			if (Time.time > Controlador.cd2ratio && Time.time > selec.TiempoDeDisparo)
			{
				GameObject CloneFire = Instantiate(balas[0], transformPuntoDisparo.position + (Camera.main.transform.forward * 0.3f), Quaternion.FromToRotation(Vector3.up, Camera.main.transform.forward));
				//CloneFire.GetComponent<damagegay>().damagehomogay = GunStatusScript.Damage;
			//	CloneFire.GetComponent<damagegay>().velbala = GunStatusScript.Aceleracion;

				Vector3 Bulletdirection = Camera.main.transform.TransformDirection(CalcularDireccionBala(Vector3.forward));

				Vector3 dirwena = Vector3.zero;
				dirwena.y = GunStatusScript.Aceleracion;

				//CloneFire.transform.LookAt(CloneFire.transform.position + Bulletdirection);
				//CloneFire.GetComponent<Rigidbody>().AddRelativeForce(dirwena, ForceMode.VelocityChange);
				CloneFire.SendMessage("vels", GunStatusScript.Aceleracion);



				Controlador.cd2ratio = Time.time + Controlador.cd2;
				selec.TiempoDeDisparo = Time.time + GunStatusScript.RatioDeDisparo;
				FPCStatus.isShooting = true;
				GunStatusScript.gameObject.GetComponent<HeadbobberGun>().hadisparao = true;
				Instantiate(ballestasonido, transform.position, transform.rotation);
			}
			else
			{
				FPCStatus.isShooting = false;
			}
		}

		else if (GunStatusScript.Armasgays == Armasgaystipos.Arma3 && GunStatusScript.Tipo != TiposDisparo.Lanzagranadas)
		{

			//FPCStatus.especial = true;
			if (FPCStatus.IsFire2Down && Time.time > selec.TiempoDeDisparo && GunStatusScript.BalasActualesEnCargador > 0)
			{

				if (this.GunStatusScript.BalasActualesEnCargador > 0)
				{


					ParticleSystem.EmissionModule psa = selec.ps.emission;
					ParticleSystem.EmissionModule psa2 = selec.ps2.emission;
					ParticleSystem.EmissionModule psa3 = selec.ps3.emission;
					ParticleSystem.EmissionModule psa4 = selec.ps4.emission;
					psa.enabled = true;
					psa2.enabled = true;
					psa3.enabled = true;
					psa4.enabled = true;
					// Dibuja el destello en el cañon del arma y que suene un disparo.
					Instantiate(GunStatusScript.Destello, transformPuntoDisparo.position, Camera.main.transform.rotation);
					selec.FireSound.PlayOneShot(selec.Sonidos[selec.NumeroArma]);



					RaycastHit hit = default(RaycastHit);


					int cont;

					if (GunStatusScript.BalasActualesEnCargador == 1)
					{
						cont = 7;
					}
					else
					{
						cont = 14;
					}

					selec.hedisparao();

					for (int i = 0; i <= cont; i++)
					{

						Vector3 direction = Camera.main.transform.TransformDirection(Vector3.forward);
						Vector3 Bulletdirection = selec.CalcularDireccionBala(direction);    // Calculamos la direccion que tendra la bala
						direction.z += 0.1f;

						if (Physics.Raycast(Camera.main.transform.position + direction + selec.offset, Bulletdirection, out hit, 1000, layerMask))
						{
							//Debug.Log("Nombre  "+hit.transform.name);
							if (!hit.collider.tag.Contains("Enemy") && !hit.collider.tag.Contains("Player") && !hit.collider.gameObject.tag.Contains("cabesa") && !hit.collider.gameObject.tag.Contains("cuerpasoenemigo") &&
								!hit.collider.tag.Contains("Armas") && !hit.collider.gameObject.tag.Contains("EndGame") && !hit.collider.gameObject.tag.Contains("putasangre") && !hit.collider.gameObject.tag.Contains("abujero"))
							{
								// GameObject mySplashObj = CrearSplashObject(hit);
								//  if (mySplashObj != null){ ColoreaSplash(hit, mySplashObj); }  lo he desactivao yo xq es una puta mierda
								selec.CrearDecall(hit);
							}
							if (hit.collider.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cuerpasoenemigo"))
							{
								Vector3 posa = hit.point;
								GameObject clone;
								selec.Crearsangre(hit);
								GameObject mySplashObj = selec.CrearSplashObject(hit);
								if (mySplashObj != null) { selec.ColoreaSplash(hit, mySplashObj); }
								clone = Instantiate(selec.sangre, posa, transform.rotation);
							}



							// Aplica damage
							if (hit.collider.tag.Contains("Blanco") || hit.collider.gameObject.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cristal"))
							{
								float prc = selec.nerfeo(hit);

								hit.collider.SendMessage("Aplicacriticks", GunStatusScript.Critico * prc, SendMessageOptions.DontRequireReceiver);
								hit.collider.SendMessage("AplicaDamage", GunStatusScript.Damage * prc, SendMessageOptions.DontRequireReceiver);
								hit.collider.SendMessage("Posgay", transform.position, SendMessageOptions.DontRequireReceiver);																
								hit.collider.SendMessage("AplicaStun", GunStatusScript.Stun * prc, SendMessageOptions.DontRequireReceiver);
							}

						}
					}









				}

				selec.CancelInvoke("desactivarpar2");
				selec.Invoke("desactivarpar2", 0.05f);
				selec.desactivarpar(true);
				selec.TiempoDeDisparo = Time.time + GunStatusScript.RatioDeDisparo;
				FPCStatus.isShooting = true;
				GunStatusScript.gameObject.GetComponent<HeadbobberGun>().hadisparao = true;
				// Decremento la municion y la escribo
				if (GunStatusScript.BalasActualesEnCargador == 1)
				{
					GunStatusScript.BalasActualesEnCargador--;
				}
				else
				{
					GunStatusScript.BalasActualesEnCargador -= 2;
				}

				if (GunStatusScript.CargadoresActuales > 0)
				{
					//FPCStatus.transicion = true;
					gameObject.GetComponent<ReloadWeapon>().delay = 0.05f;
					lolsexual = StartCoroutine(gameObject.GetComponent<ReloadWeapon>()._ReloadWeapon(GunStatusScript, false, false));
				}
			}
			else
			{
				FPCStatus.isShooting = false;
			}

		}
		else if (GunStatusScript.Armasgays == Armasgaystipos.Arma4)
		{
			//	FPCStatus.especial = true;
			if (FPCStatus.IsFire2Pressed && Time.time > Controlador.cd3ratio && Time.time > selec.TiempoDeDisparo)
			{

				var layerMask2 = (1 << 10);
				layerMask2 |= (1 << 15);
				layerMask2 |= (1 << 25);
				layerMask2 |= (1 << 26);

				RaycastHit hit;
				bool para = false;
				Vector3 pos = Camera.main.transform.position;
				while (!para)
				{
					if (Physics.Raycast(pos, Camera.main.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask2))
					{
						
						if (hit.collider.tag.Contains("Blanco") || hit.collider.gameObject.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cristal"))
						{
							hit.collider.SendMessage("Posgay", transform.position, SendMessageOptions.DontRequireReceiver);
							hit.collider.SendMessage("Aplicacriticks", GunStatusScript.Critico, SendMessageOptions.DontRequireReceiver);
							hit.collider.SendMessage("AplicaDamage2", 300, SendMessageOptions.DontRequireReceiver);
							hit.collider.SendMessage("sangrecilla", hit, SendMessageOptions.DontRequireReceiver);
							hit.collider.SendMessage("AplicaStun", 270, SendMessageOptions.DontRequireReceiver);
							//hit.collider.SendMessage("AplicaStun", GunStatusScript.Stun);
							pos = hit.point + Camera.main.transform.forward * 1;
						}
						else
                        {
							pos = hit.point;
							para = true;
							GameObject decallobj = Instantiate(decall, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
							decallobj.transform.position += decallobj.transform.up * 0.3f;
							break;
						}
					}

					else
					{
						pos = transform.position + Camera.main.transform.forward * 2000;
						para = true;
						break;
					}


				}
				GameObject CloneFire = Instantiate(balas[2], transformPuntoDisparo.position + (Camera.main.transform.forward * 0.1f), Quaternion.identity);
				StartCoroutine(CloneFire.GetComponent<bajalfaostia>().lol(pos));

				Controlador.cd3ratio = Time.time + Controlador.cd3;
				selec.TiempoDeDisparo = Time.time + selec.GunStatusScript.RatioDeDisparo;
				FPCStatus.isShooting = true;
				selec.GunStatusScript.gameObject.GetComponent<HeadbobberGun>().hadisparao = true;
				//Instantiate(ballestasonido, transform.position, transform.rotation);
				GetComponent<AudioSource>().PlayOneShot(sonidos[1]);
				GameObject a = Instantiate(particulasgays, transformPuntoDisparo.position, transformPuntoDisparo.rotation);
				a.transform.parent = transformPuntoDisparo;
			}
			else
			{
				FPCStatus.isShooting = false;
			}
		}
		else if (GunStatusScript.Armasgays == Armasgaystipos.Duales1)
        {

			if (FPCStatus.IsFire2Down && Time.time > selec.TiempoDeDisparo2 && GunStatusScript.arma2.BalasActualesEnCargador > 0 && !GunStatusScript.arma2.recargando)
			{
				Vector3 PuntoDisparo = GunStatusScript.arma2.GetComponentInChildren<DisableRender>().transform.position;


				ParticleSystem.EmissionModule psa2 = ps2.emission;

				psa2.enabled = true;


				selec.FireSound.PlayOneShot(selec.Sonidos[selec.NumeroArma]);

				Vector3 Bulletdirection = selec.CalcularDireccionBala(Vector3.forward);
				Bulletdirection.z = 1;
			    Bulletdirection = Camera.main.transform.TransformDirection(CalcularDireccionBala(Bulletdirection));

				GameObject CloneFire = Instantiate(balas[4], PuntoDisparo, Quaternion.FromToRotation(Vector3.forward, Bulletdirection));
				CloneFire.GetComponent<mustang>().damagehomosexual = GunStatusScript.Damage;
				CloneFire.GetComponent<mustang>().stunhomosexual = GunStatusScript.Stun;
				//CloneFire.GetComponent<mustang>().velbala = GunStatusScript.Aceleracion;



				Vector3 dirwena = Vector3.zero;
				dirwena.z = GunStatusScript.Aceleracion;

				//CloneFire.transform.LookAt(CloneFire.transform.position + Bulletdirection);
				//CloneFire.GetComponent<Rigidbody>().AddRelativeForce(dirwena, ForceMode.VelocityChange);
				CloneFire.SendMessage("vels", GunStatusScript.Aceleracion);
				selec.TiempoDeDisparo2 = Time.time + GunStatusScript.RatioDeDisparo;

				GunStatusScript.arma2.BalasActualesEnCargador--;
				//GUIBalas.text = GunStatusScript.BalasActualesEnCargador.ToString();

				FPCStatus.isShooting2 = true;
				GunStatusScript.gameObject.GetComponent<recoilcam3>().hedisparaosubnormal = true;
				CancelInvoke("desactivarpar");
				Invoke("desactivarpar", 0.05f);
			}
			else
			{
				FPCStatus.isShooting2 = false;
			}

		}
		else if (GunStatusScript.Armasgays == Armasgaystipos.Duales2)
		{
			if (!disparo)
			{
				FPCStatus.isShooting2 = false;
			}

			if (disparo && GunStatusScript.arma2.BalasActualesEnCargador > 0 && !GunStatusScript.arma2.recargando)
			{
				
				Vector3 PuntoDisparo = transformPuntoDisparo.position;


				ParticleSystem.EmissionModule psa = ps.emission;

				psa.enabled = true;

				// Dibuja el destello en el cañon del arma y que suene un disparo.
				Instantiate(GunStatusScript.Destello, PuntoDisparo, Camera.main.transform.rotation);

				selec.FireSound.PlayOneShot(selec.Sonidos[selec.NumeroArma]);

				Vector3 direction = Camera.main.transform.TransformDirection(Vector3.forward);
				Vector3 Bulletdirection = selec.CalcularDireccionBala(direction);    // Calculamos la direccion que tendra la bala

				RaycastHit hit = default(RaycastHit);
				direction.z += 0.1f;

				if (Physics.Raycast(Camera.main.transform.position + direction + selec.offset, Bulletdirection, out hit, 1000, layerMask))
				{
					//Debug.Log("Nombre  "+hit.transform.name);
					if (!hit.collider.tag.Contains("Enemy") && !hit.collider.tag.Contains("Player") &&
						!hit.collider.tag.Contains("Armas") && !hit.collider.gameObject.tag.Contains("EndGame") && !hit.collider.gameObject.tag.Contains("putasangre") && !hit.collider.gameObject.tag.Contains("abujero") && !hit.collider.gameObject.tag.Contains("cabesa") && !hit.collider.gameObject.tag.Contains("cuerpasoenemigo"))
					{
						// GameObject mySplashObj = CrearSplashObject(hit);
						//  if (mySplashObj != null){ ColoreaSplash(hit, mySplashObj); }  lo he desactivao yo xq es una puta mierda
						selec.CrearDecall(hit);
					}
					if (hit.collider.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cuerpasoenemigo"))
					{
						Vector3 posa = hit.point;
						GameObject clone;
						selec.Crearsangre(hit);
						GameObject mySplashObj = selec.CrearSplashObject(hit);
						if (mySplashObj != null) { selec.ColoreaSplash(hit, mySplashObj); }
						clone = Instantiate(selec.sangre, posa, transform.rotation);
					}



					// Aplica damage
					if (hit.collider.tag.Contains("Blanco") || hit.collider.gameObject.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cristal"))
					{
						hit.collider.SendMessage("Posgay", hit.point);
						hit.collider.SendMessage("Aplicacriticks", GunStatusScript.Critico);
						hit.collider.SendMessage("AplicaDamage", GunStatusScript.Damage);
						hit.collider.SendMessage("AplicaStun", GunStatusScript.Stun);
					}



				}

				selec.TiempoDeDisparo2 = Time.time + GunStatusScript.arma2.RatioDeDisparo;

				GunStatusScript.arma2.BalasActualesEnCargador--;
				//GUIBalas.text = GunStatusScript.BalasActualesEnCargador.ToString();

				FPCStatus.isShooting2 = true;
				CancelInvoke("desactivarpar");
				Invoke("desactivarpar", 0.05f);
				disparo = false;
			}
			

		}

	}


	private Vector3 CalcularDireccionBala(Vector3 _direction)
	{
		Vector3 _bulletdirection = _direction;    // Precision de la bala normal.

		// Si estamos apuntando o la precision del arma no es maxima, calcuklamos la nueva precision (normal o apuntando).
		if (GunStatusScript.aimPrecision != 0)
		{
			float _precision = FPCStatus.IsAiming ? GunStatusScript.aimPrecision : GunStatusScript.Precision;
			_bulletdirection.x = _bulletdirection.x + ((1 - (2 * Random.value)) * _precision);
			_bulletdirection.y = _bulletdirection.y + ((1 - (2 * Random.value)) * _precision);
			_bulletdirection.z = _bulletdirection.z + ((1 - (2 * Random.value)) * _precision);

			_bulletdirection.z = 1;
		}

		//_bulletdirection.x = _bulletdirection.x + (FPCStatus.movimiento.x * 0.05f);


		return _bulletdirection;
	}

	void desactivarpar()
	{
		ParticleSystem.EmissionModule psa = ps.emission;
		psa.enabled = false;
		ParticleSystem.EmissionModule psa2 = ps2.emission;
		psa2.enabled = false;
	}

	void DisparoDuales2()
    {
		if (FPCStatus.isReloading)
        {
			GunStatusScript.arma2.disparo2 = false;
		}

			if (!GunStatusScript.arma2.disparo2)
			{
				FPCStatus.isShooting2 = false;
			}

			if (GunStatusScript.arma2.disparo2 && GunStatusScript.arma2.BalasActualesEnCargador > 0 && !GunStatusScript.arma2.recargando)
			{


			var layerMask = (1 << 0);
			layerMask |= (1 << 2);
			layerMask |= (1 << 4);
			layerMask |= (1 << 8);
			layerMask |= (1 << 13);
			layerMask |= (1 << 14);
			layerMask |= (1 << 17);
			layerMask |= (1 << 22);
			layerMask |= (1 << 23);
			layerMask = ~layerMask;


			Vector3 PuntoDisparo = transformPuntoDisparo.position;


				ParticleSystem.EmissionModule psa = ps.emission;

				psa.enabled = true;

				// Dibuja el destello en el cañon del arma y que suene un disparo.
				Instantiate(GunStatusScript.Destello, PuntoDisparo, Camera.main.transform.rotation);

				selec.FireSound.PlayOneShot(selec.Sonidos[selec.NumeroArma]);

				Vector3 direction = Camera.main.transform.TransformDirection(Vector3.forward);
				Vector3 Bulletdirection = selec.CalcularDireccionBala(direction);    // Calculamos la direccion que tendra la bala

				RaycastHit hit = default(RaycastHit);
				direction.z += 0.1f;

				if (Physics.Raycast(Camera.main.transform.position + direction + selec.offset, Bulletdirection, out hit, 1000, layerMask))
				{
					//Debug.Log("Nombre  "+hit.transform.name);
					if (!hit.collider.tag.Contains("Enemy") && !hit.collider.tag.Contains("Player") &&
						!hit.collider.tag.Contains("Armas") && !hit.collider.gameObject.tag.Contains("EndGame") && !hit.collider.gameObject.tag.Contains("putasangre") && !hit.collider.gameObject.tag.Contains("abujero") && !hit.collider.gameObject.tag.Contains("cabesa") && !hit.collider.gameObject.tag.Contains("cuerpasoenemigo"))
					{
						// GameObject mySplashObj = CrearSplashObject(hit);
						//  if (mySplashObj != null){ ColoreaSplash(hit, mySplashObj); }  lo he desactivao yo xq es una puta mierda
						selec.CrearDecall(hit);
					}
					if (hit.collider.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cuerpasoenemigo"))
					{
						Vector3 posa = hit.point;
						GameObject clone;
						selec.Crearsangre(hit);
						GameObject mySplashObj = selec.CrearSplashObject(hit);
						if (mySplashObj != null) { selec.ColoreaSplash(hit, mySplashObj); }
						clone = Instantiate(selec.sangre, posa, transform.rotation);
					}



					// Aplica damage
					if (hit.collider.tag.Contains("Blanco") || hit.collider.gameObject.tag.Contains("Enemy") || hit.collider.gameObject.tag.Contains("cabesa") || hit.collider.gameObject.tag.Contains("cristal"))
					{
						hit.collider.SendMessage("Posgay", hit.point, SendMessageOptions.DontRequireReceiver);
						hit.collider.SendMessage("Aplicacriticks", GunStatusScript.Critico, SendMessageOptions.DontRequireReceiver);
						hit.collider.SendMessage("AplicaDamage", GunStatusScript.Damage, SendMessageOptions.DontRequireReceiver);
						hit.collider.SendMessage("AplicaStun", GunStatusScript.Stun, SendMessageOptions.DontRequireReceiver);
					}



				}

				selec.TiempoDeDisparo2 = Time.time + GunStatusScript.arma2.RatioDeDisparo;

				GunStatusScript.arma2.BalasActualesEnCargador--;
				//GUIBalas.text = GunStatusScript.BalasActualesEnCargador.ToString();

				FPCStatus.isShooting2 = true;
				CancelInvoke("desactivarpar");
				Invoke("desactivarpar", 0.05f);
				disparo = false;
			    GunStatusScript.arma2.disparo2 = false;
			}		


	}

	public IEnumerator ActivarDisparo()
    {
		yield return new WaitForSeconds(0.05f);
		GunStatusScript.arma2.disparo2 = true;
		GunStatusScript.arma2.gameObject.GetComponent<HeadbobberGun>().disparo2 = true;
	}

	public IEnumerator DisparoArma1()
	{
		selec.FireSound.PlayOneShot(sonidos[0]);
		yield return new WaitForSeconds(0.53f);
		GameObject CloneFire = Instantiate(balas[1], transformPuntoDisparo.position, Camera.main.transform.rotation);
		
		//CloneFire.GetComponent<damagegay>().velbala = 140;
		CloneFire.GetComponent<bolaenergia2>().vel = 140;

		Vector3 Bulletdirection = Camera.main.transform.TransformDirection(CalcularDireccionBala(Vector3.forward));

		Vector3 dirwena = Vector3.zero;
		dirwena.z = GunStatusScript.Aceleracion;
		dirwena = Camera.main.transform.TransformDirection(Vector3.forward);

		CloneFire.transform.LookAt(CloneFire.transform.position + Bulletdirection);
		//CloneFire.GetComponent<Rigidbody>().AddRelativeForce(dirwena, ForceMode.VelocityChange);
		CloneFire.GetComponent<bolaenergia2>().dir = dirwena;


		Controlador.cd1ratio = Time.time + Controlador.cd1;
		selec.TiempoDeDisparo = Time.time + GunStatusScript.RatioDeDisparo;
		FPCStatus.transicion = false;
		FPCStatus.isShooting = true;
		FPCStatus.especial = false;
		GunStatusScript.gameObject.GetComponent<HeadbobberGun>().hadisparao = true;
		nojoder = 0;
	}
}
