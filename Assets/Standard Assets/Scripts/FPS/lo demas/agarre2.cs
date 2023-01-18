using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agarre2 : MonoBehaviour {

	public bool espadeable = true;
	public Transform PuntoDisparo;
	public GameObject aymegolpiaste;
	public GameObject desfigays;
	private Vector3 pene;
	public Transform cubogay;
	private Vector2 poswena;
	public Vector3 poswenadeverdad;
	public float OffsetYNor = 0;
	public float OffsetYAereo = 10;
	public float DistNormal = 4;
	public float DistAerea = 2;
	public bool Enemigo = true;
	public float RangoRay = 10;
	[HideInInspector]
	public Transform objetivoenemigo;
	[HideInInspector]
	public agarre2 scriptenemigo;
	public bool activao = false;
	public Transform FPC;
	public bool cuerpo = false;
	[HideInInspector]
	public bool encararcam = false;
	[HideInInspector]
	public bool encaradofpc = false;
	public Transform anim;
	[HideInInspector]
	public Vector3 rotfinal;
	Quaternion rotfinalwena;
	public Vector3 OffsetRot;
	public Vector3 OffsetRotBack;
	private Vector3 notemuevascojones;
	private bool backstab = false;
	private bool aereo = false;
	public bool mareao = false;
	private string nombre = "";
	private int num = 69;
	public float VENGAOSTIA;
	private bool cuchillo = false;
	public bool follame = false;
	private bool espada = false;

	public List<Collider> colisiones = new List<Collider>();
	public List<animejec> listagay = new List<animejec>();

	private bool enello = false;
	private putosgays a;
	public GameObject meleegay;
	public DisparoSelectivo Ds;
	public AudioSource desfaudio;
	public AudioSource olimpo;
	public AudioClip[] au;
	public GameObject sonidopref;

	[Header("Animaciones")]
	public float offsetY;
	public float offsetX = 1;
	public int[] backaereo;
	public int[] back;
	public int[] frontaereo;
	public int[] front;

	public int[] backaereoESPADA;
	public int[] backESPADA;
	public int[] frontaereoESPADA;
	public int[] frontESPADA;

	private int anteriorgay;
	private float tiempo;
	private GameObject pollas;
	public static bool efectivamentelehedao = false;
	public static bool efectivamentelehedao2 = false;

	private bool estoymuertosubnormal = false;
	private bool wau = false;
	public static bool espadahit = false;

	[HideInInspector]
	public float puntosexuales;
	[HideInInspector]
	public ManageEnemyStatus1 vidaenemiga;

	void Start()
    {
		notemuevascojones = transform.position;


	}

	void devolver(agarre2 gay, bool ohsinena)
    {
        if (ohsinena)
        {
			if (gameObject.GetComponent<MeshRenderer>().isVisible && transform.parent.GetComponent<agarre2>().mareao)
			{
				var layerMask2 = (1 << 15);
				if (!Physics.Linecast(transform.position, gay.transform.position, layerMask2))
				{
					gay.colisiones.Add(gameObject.GetComponent<Collider>());
				}
			}
		}
        else
        {
			if (gameObject.GetComponent<MeshRenderer>().isVisible && transform.parent.GetComponent<agarre2>().activao == false && espadeable)
			{
				var layerMask2 = (1 << 15);
				if (!Physics.Linecast(transform.position, gay.transform.position, layerMask2))
				{
					gay.colisiones.Add(gameObject.GetComponent<Collider>());
				}
			}
		}
		

    }

	public bool admisible()
    {

		if (GetComponentInParent<ManageEnemyStatus1>() == null)
        {
			return false;
        }
		if (gameObject.GetComponent<MeshRenderer>().isVisible && GetComponentInParent<ManageEnemyStatus1>().health > 0)
        {
			return true;
        }

		return false;


    }

	void Update()
	{
		//if (cuerpo) { Debug.Log(transform.position.y); }		

	    if (Enemigo)
		{
		
			if (activao) { rotenemigo(); }

		}

		else
		{
			if (Input.GetKeyDown(KeyCode.E) && !cuerpo && !Enemigo && !Controlador.acabado)
			{
				var layerMask2 = (1 << 14);
				Collider[] penes = Physics.OverlapSphere(transform.position, RangoRay, layerMask2);

				colisiones.Clear();
				for (int i = 0; i < penes.Length; i++)
				{
					if (penes[i].gameObject.GetComponent<agarre2>() != null)
					{
						penes[i].gameObject.GetComponent<agarre2>().devolver(transform.GetComponent<agarre2>(), true);
					}

				}

				Transform elegido = null;
				float angleweno = 360;

				if (colisiones.Count > 0) {
				for (int i = 0; i < colisiones.Count; i++)
				{
					Transform gay = colisiones[i].transform;

					Vector3 targetDir = gay.position - transform.position;
					float angle = Vector3.Angle(targetDir, transform.TransformDirection(Vector3.forward * 0.05f));
					
					if (angle < angleweno)
                        {
							angleweno = angle;
							elegido = gay;
                        }

				}
			}
								
				if (elegido == null) { if (efectivamentelehedao && FPCStatus.melee) { return; } melee(true); return; }
				if (enello) { return; }
				
				scriptenemigo = elegido.parent.GetComponent<agarre2>();
				scriptenemigo.mareao = false;
				poswenadeverdad = scriptenemigo.calcularpos(true);
				backstab = scriptenemigo.backgay();
				aereo = scriptenemigo.alturagay();
				objetivoenemigo = elegido.parent;
				encararcam = scriptenemigo.encararcam;
				OffsetRot = scriptenemigo.OffsetRot;
				FPC.GetComponent<agarre2>().objetivoenemigo = objetivoenemigo;
				FPC.GetComponent<agarre2>().scriptenemigo = transform.GetComponent<agarre2>();

				desactivarfpc();
				scriptenemigo.desactivarenemigo(this);
				activao = true;
				scriptenemigo.activao = true;
				enello = true;
				espadahit = false;
			}

			if (Input.GetKeyDown(KeyCode.V) && !cuerpo && !Enemigo && !Controlador.acabado)
			{				
				var layerMask2 = (1 << 14);
				Collider[] penes = Physics.OverlapSphere(transform.position, RangoRay, layerMask2);

				colisiones.Clear();
				for (int i = 0; i < penes.Length; i++)
				{
					if (penes[i].gameObject.GetComponent<agarre2>() != null)
					{
						penes[i].gameObject.GetComponent<agarre2>().devolver(transform.GetComponent<agarre2>(), false);
					}

				}

				Transform elegido = null;
				float angleweno = 360;

				if (colisiones.Count > 0)
				{
					for (int i = 0; i < colisiones.Count; i++)
					{
						Transform gay = colisiones[i].transform;

						Vector3 targetDir = gay.position - transform.position;
						float angle = Vector3.Angle(targetDir, transform.TransformDirection(Vector3.forward * 0.05f));

						if (angle < angleweno)
						{
							angleweno = angle;
							elegido = gay;
						}

					}
				}
				if (Controlador.cargas == 0) { melee(false); return; } // Aqui se pone return normal si no está mejorao 
				if (elegido == null) { if (efectivamentelehedao && FPCStatus.melee) { return; } melee(false); return; }
				if (enello) { return; }


				scriptenemigo = elegido.parent.GetComponent<agarre2>();
				scriptenemigo.mareao = false;
				poswenadeverdad = scriptenemigo.calcularpos(false);
				backstab = scriptenemigo.backgay();
				aereo = scriptenemigo.alturagay();
				objetivoenemigo = elegido.parent;
				encararcam = scriptenemigo.encararcam;
				OffsetRot = scriptenemigo.OffsetRot;
				FPC.GetComponent<agarre2>().objetivoenemigo = objetivoenemigo;
				FPC.GetComponent<agarre2>().scriptenemigo = transform.GetComponent<agarre2>();

				desactivarfpc();
				scriptenemigo.desactivarenemigo(this);
				activao = true;
				scriptenemigo.activao = true;
				enello = true;
				espadahit = true;
			}

			if (activao)
			{
				posicionar();
				FPC.GetComponent<agarre2>().objetivoenemigo = objetivoenemigo;
				FPC.GetComponent<agarre2>().rotarfpc();
				comprovar();
			}


		


		}
		
		if (follame)
        {
			Debug.Log(transform.position.y);
		}
	}

	bool backgay()
    {
		return backstab;
    }
	bool alturagay()
    {
		return encararcam;
	}

	Vector3 calcularpos (bool ohsinena) {
		//PENEPENEPENEPENEPENE


		GetComponent<Animator>().enabled = false;
		GetComponent<NavMeshAgent>().enabled = false;
		notemuevascojones = transform.position;
		notemuevascojones.y += 0.02f;
		transform.position = notemuevascojones;
		Transform yo = GameObject.FindWithTag("micuerpochingon").transform;
		pene = yo.position - transform.position;
		poswena = new Vector2(pene.x, pene.z);

		Vector3 t = yo.position - transform.position;
		t.y = transform.position.y;
		
		if (Mathf.Abs(Vector3.SignedAngle(t, transform.forward, Vector3.up)) > 130)
		{
			backstab = true;
		}
		else
		{
			backstab = false;
		}


		if (pene.y > 8)
		{
			//poswena = poswena.normalized; poswena = poswena * DistAerea;
			encararcam = true;
			aereo = true;
		}
		else
		{
			//poswena = poswena.normalized; poswena = poswena * DistNormal;
			encararcam = false;
			aereo = false;
		}



		//aereo = alturagay();
		num = animacionesgays(ohsinena);
		animejec lol = listagay[num];
		DistAerea = lol.X;
		OffsetYAereo = lol.Y;
		OffsetYNor = lol.Y;
		nombre = lol.nom;
		OffsetRotBack = lol.offset;
		OffsetRot = lol.offset;
		VENGAOSTIA = lol.tiempesito;
		cuchillo = lol.cuchillo;
		espada = lol.espada;

		poswena = poswena.normalized; poswena = poswena * DistAerea * offsetX;

		poswenadeverdad = new Vector3(poswena.x, offsetY, poswena.y);
		if (pene.y > 8) { poswenadeverdad.y = poswenadeverdad.y += OffsetYAereo; }
		else { poswenadeverdad.y = poswenadeverdad.y += OffsetYNor; }
		//cubogay.position = transform.position + poswenadeverdad;
		// TODA ESTA CHAPA SE LLAMA 1 VEZ EN MÉTODO A PARTE CUANDO SE LLAME LOL

		//Vector3 gay = transform.TransformDirection(OffsetRot);
		//poswenadeverdad = poswenadeverdad + gay;

		Vector3 posdef = transform.position + poswenadeverdad;
		GetComponent<Animator>().enabled = true;
		return posdef;
	}

	void rotenemigo()
    {
		transform.position = notemuevascojones;
		Quaternion rotation;
		if (!backstab)
        {
	        rotation = Quaternion.LookRotation(poswenadeverdad, Vector3.up);
        }
        else
        {
			rotation = Quaternion.LookRotation(-poswenadeverdad, Vector3.up);
			
		}
		
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.4f);
		transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		transform.position = notemuevascojones;
	}
	
	void posicionar()
    {
		transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.identity, 300 * Time.deltaTime);

		FPC.position = Vector3.MoveTowards(FPC.position, poswenadeverdad, 100 * Time.deltaTime);

		//Quaternion rotation = Quaternion.LookRotation(objetivoenemigo.position, Vector3.up);
		//FPC.rotation = Quaternion.Slerp(FPC.rotation, rotation, 0.2f);
		//FPC.LookAt(objetivoenemigo);
		//FPC.eulerAngles = new Vector3(0, FPC.eulerAngles.y, 0);
	}
	
	void rotarfpc()
    {
		Vector3 gay = objetivoenemigo.TransformDirection(scriptenemigo.OffsetRot);
		Vector3 relativePos = objetivoenemigo.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);

		rotfinalwena = rotation;
		rotfinal = rotation.eulerAngles;
		rotfinal.x = 0; rotfinal.z = 0;
		Vector3 v = rotation.eulerAngles;		

		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.7f);
		//transform.eulerAngles = Vector3.MoveTowards(transform.eulerAngles, v, 40);  HACE 360 NOSCOPE PORQUÉ SÍ A VECES
		transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);

	    v.Set(0, v.y, 0);

		Vector3 chupa = new Vector3(objetivoenemigo.position.x, transform.position.y, objetivoenemigo.position.z) - transform.position;

		//if (Vector3.Distance(transform.eulerAngles, v) < 0.1f)
		if (Vector3.Angle(transform.forward, chupa) < 0.2f)
		{
			transform.rotation = rotation;
			transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
			scriptenemigo.encaradofpc = true;
		}
        else
        {
			scriptenemigo.encaradofpc = false;
		}
			
	}

	void comprovar()
    {
		GetComponentInParent<Muevo>().volvedzorras();
		if (encaradofpc && transform.localEulerAngles == Vector3.zero && Vector3.Distance(FPC.position, poswenadeverdad) < 0.01f) {
			puntos();
			GetComponent<AudioListener>().enabled = false;

			GameObject a = Instantiate(anim.gameObject, new Vector3 (poswenadeverdad.x, FPC.GetChild(2).position.y + -0.4135403f, poswenadeverdad.z), Quaternion.Euler(FPC.GetComponent<agarre2>().rotfinal));
			rotacionoffset e = a.GetComponent<rotacionoffset>();
			e.ene = objetivoenemigo;
			e.offsetgay = scriptenemigo.OffsetRot;
			a.transform.localEulerAngles = new Vector3(0, a.transform.localEulerAngles.y, 0);
			a.GetComponentInChildren<Teleport10>().Invoke("cacas", scriptenemigo.VENGAOSTIA);

			Controlador.bajaspartidagay[9]++;
			Controlador.bajas[9]++;
			objetivoenemigo.GetComponent<Animator>().CrossFadeInFixedTime(scriptenemigo.nombre, 0.17f, -1, 0, 0);
			objetivoenemigo.GetComponentInChildren<seteadorsangreanims>().ComprovadorSangre(scriptenemigo.nombre);
			a.GetComponent<Animator>().CrossFadeInFixedTime(scriptenemigo.nombre, 0.17f, -1, 0, 0);
			a.SendMessage("ejecutaputo", scriptenemigo.nombre);

			GameObject pene = GameObject.FindGameObjectWithTag("Finish");
			
			pene.transform.position = transform.position;
			pene.transform.rotation = transform.rotation;


			if (!scriptenemigo.cuchillo)
            {
				GameObject.FindGameObjectWithTag("Cuchillo").SetActive(false);
            }
			if (!scriptenemigo.espada)
			{
				GameObject.FindGameObjectWithTag("Espada").SetActive(false);
			}
            else
            {
				GameObject.Find("ArmasUI").GetComponent<RegenEspada>().Ajuste(false);
			}

			a.SendMessage("activar", espadahit);
			//Controlador.vidahomosexual += 20;
			//Controlador.vidahomosexual = Mathf.Clamp(Controlador.vidahomosexual, 0, 100);
			Controlador.ah.gameObject.SendMessage("AutoRecarga");
			Controlador.ah.SendMessage("actualizarvida");

			Controlador.ah.gameObject.SendMessage("darle", scriptenemigo.VENGAOSTIA);
			Destroy(FPC.parent.gameObject);
		}
    }

	int animacionesgays(bool ohsinena)
    {
		int num = 0;
	    List<int> listafollar = new List<int>();
		listafollar.Clear();
		if (ohsinena) {
			if (backstab)
			{
				if (aereo)
				{

					num = backaereo[Random.Range(0, backaereo.Length)];
					if (Controlador.ultanim == num)
                    {
						if (backaereo.Length > 1)
                        {
							for(int i = 0; i < backaereo.Length; i++)
                            {
								listafollar.Add(backaereo[i]);
							}
							listafollar.Remove(Controlador.ultanim);
							num = listafollar[Random.Range(0, listafollar.Count)];
						}
                    }
					Controlador.ultanim = num;
				}
				else if (!aereo)
				{

					num = back[Random.Range(0, back.Length)];
					if (Controlador.ultanim == num)
					{
						if (back.Length > 1)
						{
							for (int i = 0; i < back.Length; i++)
							{
								listafollar.Add(back[i]);
							}
							listafollar.Remove(Controlador.ultanim);
							num = listafollar[Random.Range(0, listafollar.Count)];
						}
					}
					Controlador.ultanim = num;

				}


			}
			else if (!backstab)
			{
				if (aereo)
				{

					num = frontaereo[Random.Range(0, frontaereo.Length)];
					if (Controlador.ultanim == num)
					{
						if (frontaereo.Length > 1)
						{
							for (int i = 0; i < frontaereo.Length; i++)
							{
								listafollar.Add(frontaereo[i]);
							}
							listafollar.Remove(Controlador.ultanim);
							num = listafollar[Random.Range(0, listafollar.Count)];
						}
					}
					Controlador.ultanim = num;

				}
				else if (!aereo)
				{

					num = front[Random.Range(0, front.Length)];
					if (Controlador.ultanim == num)
					{
						if (front.Length > 1)
						{
							for (int i = 0; i < front.Length; i++)
							{
								listafollar.Add(front[i]);
							}
							listafollar.Remove(Controlador.ultanim);
							num = listafollar[Random.Range(0, listafollar.Count)];
						}
					}
					Controlador.ultanim = num;

				}


			}
		}
        else
        {
			if (backstab)
			{
				if (aereo)
				{

					num = backaereoESPADA[Random.Range(0, backaereoESPADA.Length)];
					if (Controlador.ultanim == num)
					{
						if (backaereoESPADA.Length > 1)
						{
							for (int i = 0; i < backaereoESPADA.Length; i++)
							{
								listafollar.Add(backaereoESPADA[i]);
							}
							listafollar.Remove(Controlador.ultanim);
							num = listafollar[Random.Range(0, listafollar.Count)];
						}
					}
					Controlador.ultanim = num;

				}
				else if (!aereo)
				{

					num = backESPADA[Random.Range(0, backESPADA.Length)];
					if (Controlador.ultanim == num)
					{
						if (backESPADA.Length > 1)
						{
							for (int i = 0; i < backESPADA.Length; i++)
							{
								listafollar.Add(backESPADA[i]);
							}
							listafollar.Remove(Controlador.ultanim);
							num = listafollar[Random.Range(0, listafollar.Count)];
						}
					}
					Controlador.ultanim = num;

				}


			}
			else if (!backstab)
			{
				if (aereo)
				{

					num = frontaereoESPADA[Random.Range(0, frontaereoESPADA.Length)];
					if (Controlador.ultanim == num)
					{
						if (frontaereoESPADA.Length > 1)
						{
							for (int i = 0; i < frontaereoESPADA.Length; i++)
							{
								listafollar.Add(frontaereoESPADA[i]);
							}
							listafollar.Remove(Controlador.ultanim);
							num = listafollar[Random.Range(0, listafollar.Count)];
						}
					}
					Controlador.ultanim = num;

				}
				else if (!aereo)
				{

					num = frontESPADA[Random.Range(0, frontESPADA.Length)];
					if (Controlador.ultanim == num)
					{
						if (frontESPADA.Length > 1)
						{
							for (int i = 0; i < frontESPADA.Length; i++)
							{
								listafollar.Add(frontESPADA[i]);
							}
							listafollar.Remove(Controlador.ultanim);
							num = listafollar[Random.Range(0, listafollar.Count)];
						}
					}
					Controlador.ultanim = num;
				}


			}
		}

		

		

		
		return num;
	}

	void puntos()
	{
		if (a == null)
		{
			a = GameObject.Find("PutosPuntosGays").GetComponent<putosgays>();
		}

		a.puntos += 300;

		if  (!scriptenemigo.espada){
			
			a.gays(a.puntitos[8] + puntosexuales, 8);
		}
        else
        {
			a.gays(a.puntitos[12] + puntosexuales, 12);
		}
	}

	void desactivarfpc()
    {
		if (FPC == null) { return; }
		FPC.GetComponent<Muevo>().enabled = false;
		FPC.GetComponent<MouseLook>().enabled = false;
		transform.GetComponent<MouseLook>().enabled = false;
		FPC.GetComponent<CharacterController>().enabled = false;

		if (GameObject.Find("Colisioncuerpogay")) { GameObject.Find("Colisioncuerpogay").SetActive(false); }
	}
	
	void desactivarenemigo(agarre2 penisgay)
    {
		
		gameObject.SendMessage("desactivar");
		ManageEnemyStatus1 oh = GetComponent<ManageEnemyStatus1>();
		penisgay.vidaenemiga = oh;
		penisgay.puntosexuales = oh.puntos;
		oh.actualizarstats(true);
		GetComponent<NavMeshAgent>().enabled = false;
		GetComponent<CharacterController>().enabled = false;
		GetComponent<AIAnimation>().enabled = false;
		if (GetComponent<AIRobot2>() != null)
		{
			Destroy(oh.Icono);
		}
		Rigidbody[] gays = oh.AllRigids;

		foreach (Rigidbody follar in gays)
        {
			Destroy(follar.gameObject.GetComponent<CharacterJoint>());
			Destroy(follar);
		}
		oh.health = 0;
		oh.parry = false;
		oh.amorido = true;
		oh.enabled = false;
		//gameObject.SetActive(false);
		transform.GetComponentInChildren<doit>().gameObject.SetActive(false);
		Destroy(oh.vida.transform.parent.gameObject);
		//Destroy(GetComponent<ManageEnemyStatus1>());
		Destroy(gameObject, 8);
	}

	void melee(bool gays)
    {
		MouseLook.rotationX2 = 0;
		if (FPCStatus.IsAiming) { return; }
		if (FPCStatus.IsJumping) { return; }
		if (FPCStatus.isReloading) { return; }
		if (FPCStatus.transicion) { return; }
		if (FPCStatus.accionando) { return; }
		if (FPCStatus.melee && !efectivamentelehedao) { return; }
		meleegay.SetActive(true);
		FPCStatus.melee = true;
		efectivamentelehedao = false;
		efectivamentelehedao2 = false;
		
		int polla = Random.Range(1, 4);
		meleegay.layer = 13;

		if (gays)
        {			
			if (polla == anteriorgay)
			{
				if (polla == 1)
				{
					polla = 2;
				}
				else if (polla == 2)
				{
					polla = 3;
				}
				else if (polla == 3)
				{
					polla = 1;
				}
			}
			if (polla == 1)
			{
				tiempo = lehedaoxd.timingpincho;
			}
			if (polla == 2)
			{
				tiempo = lehedaoxd.timingapu;
			}
			if (polla == 3)
			{
				tiempo = lehedaoxd.timingarrastre;
			}
			if (Controlador.desfibrilador >= 2) { polla = 4; }
			anteriorgay = polla;

			pollas = Ds.Armas[DisparoSelectivo.NumeroArmagay];
			if (pollas.GetComponent<GunStatus>().arma2 != null)
			{
				pollas.GetComponent<GunStatus>().arma2.gameObject.transform.parent.parent.parent.parent.gameObject.SetActive(false);
			}
			pollas.transform.parent.parent.parent.parent.gameObject.SetActive(false);


			if (polla == 1)
			{
				meleegay.GetComponent<Animator>().Play("pincho");
				Invoke("desactiva", 0.5f);
			}
			else if (polla == 2)
			{
				meleegay.GetComponent<Animator>().Play("apu");
				Invoke("desactiva", 0.5f);
			}
			else if (polla == 3)
			{
				meleegay.GetComponent<Animator>().Play("arrastrao");
				Invoke("desactiva", 0.5f);
			}
			else if (polla == 4)
			{
				if (Controlador.puntostotales >= Controlador.meleenivel2)
                {
					meleegay.layer = 0;
					meleegay.GetComponent<Animator>().CrossFadeInFixedTime("Desfibrilador1", 0f, -1, 0, 0);
					tiempo = 0.58f;
					//Controlador.desfibrilador = 0;
					Invoke("desactiva", 1f);
					desfaudio.Stop();
					desfaudio.PlayOneShot(au[3]);
				}
                else
                {
					meleegay.GetComponent<Animator>().CrossFadeInFixedTime("Desfibrilador", 0f, -1, 0, 0);
					tiempo = 1.84f;
					//Controlador.desfibrilador = 0;
					Invoke("desactiva", 2.55f);
					desfaudio.Stop();
					desfaudio.PlayOneShot(au[2]);
				}
				
			}
			Invoke("elgolpiador", tiempo);

		}
        else
        {

			wau = !wau;

			pollas = Ds.Armas[DisparoSelectivo.NumeroArmagay];
			if (pollas.GetComponent<GunStatus>().arma2 != null)
			{
				pollas.GetComponent<GunStatus>().arma2.gameObject.transform.parent.parent.parent.parent.gameObject.SetActive(false);
			}
			pollas.transform.parent.parent.parent.parent.gameObject.SetActive(false);

			if (wau)
            {
				meleegay.GetComponent<Animator>().Play("espada1");
				tiempo = 0.2f;
				Invoke("desactiva", 0.35f);
				olimpo.Stop();
				//olimpo.PlayOneShot(au[0]);
				GameObject follar = Instantiate(sonidopref, transform.position, Quaternion.identity);
				follar.GetComponent<AudioSource>().PlayOneShot(au[0]);
			}
            else
            {
				meleegay.GetComponent<Animator>().Play("espada2");
				tiempo = 0.2f;
				Invoke("desactiva", 0.35f);
				olimpo.Stop();
				//olimpo.PlayOneShot(au[1]);
				GameObject follar = Instantiate(sonidopref, transform.position, Quaternion.identity);
				follar.GetComponent<AudioSource>().PlayOneShot(au[1]);
			}

		}






	}

	void elgolpiador()
	{
		if (anteriorgay == 4)
        {
			//Instantiate(desfigays, PuntoDisparo.position, PuntoDisparo.rotation);
			GameObject golpeadorputamadre = Instantiate(aymegolpiaste, PuntoDisparo.position, PuntoDisparo.rotation);
			golpeadorputamadre.GetComponent<golpiador>().animacion = anteriorgay;
			golpeadorputamadre.GetComponent<golpiador>().des = true;
		}
	
        else
        {
			GameObject golpeadorputamadre = Instantiate(aymegolpiaste, PuntoDisparo.position, PuntoDisparo.rotation);
			golpeadorputamadre.GetComponent<golpiador>().animacion = anteriorgay;
		}
				
	}

	void desactiva()
	{
		if (efectivamentelehedao) //Este if es pa aser stunlock homosexual
		{
			melee(true);
			return;
		}
		if (efectivamentelehedao2) //Este if es pa aser stunlock homosexual
		{
			efectivamentelehedao = true;
			melee(false);
			return;
		}
		pollas.transform.parent.parent.parent.parent.gameObject.SetActive(true);
		if (pollas.GetComponent<GunStatus>().arma2 != null)
		{
			GameObject arma2 = pollas.GetComponent<GunStatus>().arma2.gameObject;
		    arma2.transform.parent.parent.parent.parent.gameObject.SetActive(true);
			arma2.GetComponent<Animator>().enabled = true;
			arma2.GetComponent<Animator>().ResetTrigger("polladas");
			arma2.GetComponent<Animator>().ResetTrigger("pollones");
			arma2.GetComponent<Animator>().ResetTrigger("pollones2");
			arma2.GetComponent<Animator>().SetTrigger("transigay");
		}
		float transiciontiempo = Ds.Armas[DisparoSelectivo.NumeroArmagay].GetComponent<GunStatus>().cambioarma;
		FPCStatus.transicion = true;
		pollas.GetComponent<Animator>().enabled = true;
		pollas.GetComponent<Animator>().ResetTrigger("polladas");
		pollas.GetComponent<Animator>().ResetTrigger("pollones");
		pollas.GetComponent<Animator>().ResetTrigger("pollones2");
		pollas.GetComponent<Animator>().SetTrigger("transigay");

		meleegay.SetActive(false);
		Invoke("transicionvuelta", transiciontiempo);
	}

	void transicionvuelta()
	{
		FPCStatus.melee = false;
		if (pollas.GetComponent<GunStatus>().arma2 != null)
		{
			GameObject arma2 = pollas.GetComponent<GunStatus>().arma2.gameObject;
			arma2.GetComponent<Animator>().ResetTrigger("polladas");
			arma2.GetComponent<Animator>().ResetTrigger("pollones");
			arma2.GetComponent<Animator>().ResetTrigger("transigay");
			arma2.GetComponent<Animator>().SetTrigger("pollones2");
			arma2.GetComponent<Animator>().enabled = false;
		}
		pollas.GetComponent<Animator>().ResetTrigger("polladas");
		pollas.GetComponent<Animator>().ResetTrigger("pollones");
		pollas.GetComponent<Animator>().ResetTrigger("transigay");
		pollas.GetComponent<Animator>().SetTrigger("pollones2");
		pollas.GetComponent<Animator>().enabled = false;
		FPCStatus.transicion = false;
	}

	

}
