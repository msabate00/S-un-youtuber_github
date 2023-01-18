using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegenEspada : MonoBehaviour {

	public bool espadaroja = false;
	public bool refgay = false;
	public GameObject[] slot;
	public Image[] s;
	private float[] dest = new float[3];
	private int[] arm = new int[2];
	public float vel;

	public Image[] s2;
	private Color[] orig2;
	public Color gris;

	public Image[] s3;
	private Color[] orig3;

	public Image[] s4;
	private Color[] orig4;

	public Image[] s5;
	private Color[] orig5;

	public Image[] s6;
	private Color[] orig6;

	public List<int> cosas = new List<int>();

	[HideInInspector]
	public int penesgays;
	[HideInInspector]
	public int penesgays2;

	private Coroutine regenerador;

	void Update()
    {

		if (espadaroja) { R3(); }

		if (refgay) { return; }

		penesgays = cosas.IndexOf(arm[0]);
		
		if (penesgays != -1)
        {
			
			if (penesgays == 0)
            {
				R1();
			}
			
			else if (penesgays == 1)
			{
				R2();
			}

			else if (penesgays == 2)
			{
				if (espadaroja) { return; }
				R4();
			}

			else if (penesgays == 3)
			{
				if (espadaroja) { return; }
				R5();
			}
		}

		

		

	}
	
	void Start () {

		for (int i = 0; i < dest.Length; i++)
        {
			dest[i] = s[i].fillAmount;
        }
		//Ajuste(false);
		
		orig2 = new Color[s2.Length];
		for (int i = 0; i < orig2.Length; i++)
		{
			orig2[i] = s2[i].color;
		}
		
		orig3 = new Color[s3.Length];
		for (int i = 0; i < orig3.Length; i++)
		{
			orig3[i] = s3[i].color;
		}

		if (espadaroja)
        {
			orig4 = new Color[s4.Length];
			for (int i = 0; i < orig4.Length; i++)
			{
				orig4[i] = s4[i].color;
			}
		}

		orig5 = new Color[s5.Length];
		for (int i = 0; i < orig5.Length; i++)
		{
			orig5[i] = s5[i].color;
		}

		orig6 = new Color[s6.Length];
		for (int i = 0; i < orig6.Length; i++)
		{
			orig6[i] = s6[i].color;
		}


	}
	
	public void Ajuste (bool aumento) {

		if (aumento)
        {
			if (regenerador != null) { StopCoroutine(regenerador); }
			
			Controlador.cargas++;

			dest[Controlador.cargas -1] = 1;
			if (s[Controlador.cargas - 1].fillAmount == 0)
            {
				StartCoroutine(pollas(Controlador.cargas - 1));
            }

			Controlador.cd4ratio = Time.time - Controlador.cd4;
		}
        else
        {
			if (Controlador.cargas - 1 >= 0)
            {
				dest[Controlador.cargas - 1] = 0;
				
				if (s[Controlador.cargas - 1].fillAmount == 1)
				{
					StartCoroutine(pollas(Controlador.cargas - 1));
				}
			}
			
			

			Controlador.cargas--;

			if (Controlador.cargas == 0) { Controlador.cd4ratio = Time.time + Controlador.cd4; if (regenerador != null) { StopCoroutine(regenerador); } regenerador = StartCoroutine(espadaregen()); }
		}

	}

	IEnumerator pollas(int oh)
    {
		while(s[oh].fillAmount != dest[oh])
        {
			s[oh].fillAmount = Mathf.MoveTowards(s[oh].fillAmount, dest[oh], vel * Time.deltaTime);

			yield return new WaitForEndOfFrame();
        }
		yield break;

    }

	IEnumerator espadaregen()
    {
		yield return new WaitForSeconds(Controlador.cd4);
		Ajuste(true);
	}

   public void actualizar(int gay, int gay2)
   {
		arm[0] = gay;
		arm[1] = gay2;

		slot[0].GetComponent<RegenEspada>().arm[0] = gay;
		slot[1].GetComponent<RegenEspada>().arm[0] = gay2;

		

		for (int i = 0; i < slot.Length; i++)
        {
			for (int a = 0; a < slot[0].GetComponent<RegenEspada>().slot.Length; a++)
			{
				slot[i].GetComponent<RegenEspada>().slot[a].SetActive(false);
			}
		}

		if (cosas.IndexOf(arm[0]) != -1)
        {
			slot[0].GetComponent<RegenEspada>().slot[cosas.IndexOf(arm[0])].SetActive(true);
		}
		if (cosas.IndexOf(arm[1]) != -1)
		{
			slot[1].GetComponent<RegenEspada>().slot[cosas.IndexOf(arm[1])].SetActive(true);
		}



	}

	void R1()
    {

		    float pene1 = Controlador.cd1ratio - Time.time;
			pene1 = Mathf.Abs(Controlador.cd1 - pene1) / Controlador.cd1;
			pene1 = Mathf.Clamp(pene1, 0, 1);

			for(int i = 0; i <= 1; i++)
            {
				s2[i].fillAmount = pene1;
            }

			if (pene1 < 1)
            {
				for (int i = 2; i <= 4; i++)
				{
					s2[i].color = gris;
				}
			    for (int i = 0; i <= 1; i++)
			    {
				    s2[i].enabled = true;
			    }
		    }
            else
            {
				for (int i = 2; i <= 4; i++)
				{
					s2[i].color = orig2[i];
				}
			    
			    for (int i = 0; i <= 1; i++)
			    {
				    s2[i].enabled = false;
			    }
		    } 
	}

	void R2()
	{

		float pene1 = Controlador.cd3ratio - Time.time;
		pene1 = Mathf.Abs(Controlador.cd3 - pene1) / Controlador.cd3;
		pene1 = Mathf.Clamp(pene1, 0, 1);

		for (int i = 0; i <= 1; i++)
		{
			s3[i].fillAmount = pene1;
		}

		if (pene1 < 1)
		{
			for (int i = 2; i <= 4; i++)
			{
				s3[i].color = gris;
			}
			for (int i = 0; i <= 1; i++)
			{
				s3[i].enabled = true;
			}
		}
		else
		{
			for (int i = 2; i <= 4; i++)
			{
				s3[i].color = orig3[i];
			}

			for (int i = 0; i <= 1; i++)
			{
				s3[i].enabled = false;
			}
		}
	}

	void R3()
	{

		float pene1 = Controlador.cd4ratio - Time.time;
		pene1 = Mathf.Abs(Controlador.cd4 - pene1) / Controlador.cd4;
		pene1 = Mathf.Clamp(pene1, 0, 1);

		for (int i = 0; i <= 1; i++)
		{
			s4[i].fillAmount = pene1;
		}

		if (pene1 < 1)
		{
			for (int i = 2; i <= 5; i++)
			{
				s4[i].color = gris;
			}
			for (int i = 0; i <= 1; i++)
			{
				s4[i].enabled = true;
			}
			s4[3].enabled = true;
		}
		else
		{
			for (int i = 2; i <= 5; i++)
			{
				s4[i].color = orig4[i];
			}

			for (int i = 0; i <= 1; i++)
			{
				s4[i].enabled = false;
			}
			s4[3].enabled = false;
		}
	}

	void R4()
	{

		float pene1 = Controlador.cd2ratio - Time.time;
		pene1 = Mathf.Abs(Controlador.cd2 - pene1) / Controlador.cd2;
		pene1 = Mathf.Clamp(pene1, 0, 1);

		for (int i = 0; i <= 1; i++)
		{
			s5[i].fillAmount = pene1;
		}

		if (pene1 < 1)
		{
			for (int i = 2; i <= 4; i++)
			{
				s5[i].color = gris;
			}
			for (int i = 0; i <= 1; i++)
			{
				s5[i].enabled = true;
			}
		}
		else
		{
			for (int i = 2; i <= 4; i++)
			{
				s5[i].color = orig5[i];
			}

			for (int i = 0; i <= 1; i++)
			{
				s5[i].enabled = false;
			}
		}
	}

	void R5()
	{

		float pene1 = Controlador.cd5ratio - Time.time;
		pene1 = Mathf.Abs(Controlador.cd5 - pene1) / Controlador.cd5;
		pene1 = Mathf.Clamp(pene1, 0, 1);

		for (int i = 0; i <= 1; i++)
		{
			s6[i].fillAmount = pene1;
		}

		if (pene1 < 1)
		{
			for (int i = 2; i <= 4; i++)
			{
				s6[i].color = gris;
			}
			for (int i = 0; i <= 1; i++)
			{
				s6[i].enabled = true;
			}
		}
		else
		{
			for (int i = 2; i <= 4; i++)
			{
				s6[i].color = orig6[i];
			}

			for (int i = 0; i <= 1; i++)
			{
				s6[i].enabled = false;
			}
		}
	}




}
