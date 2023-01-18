using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municionwena : MonoBehaviour {

	public int municion1 = 2;
	public int municion2 = 2;
	public int municion3 = 2;
	public int municion4 = 2;
	private GunStatus Arma1;
	private GunStatus Arma2;
	private GunStatus Arma3;
	private GunStatus Arma4;
	private float polla;
	private int numerogay;
	void Start () {
		Destroy(gameObject, 30);
	}

	// Update is called once per frame
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag.Contains("micuerpochingon") || other.gameObject.tag.Contains("Player"))
		{
			//numerogay = other.gameObject.GetComponentInParent<DisparoSelectivo>().NumeroArma;
			Arma1 = other.gameObject.GetComponentInParent<DisparoSelectivo>().Armas[0].GetComponent<GunStatus>();
			Arma2 = other.gameObject.GetComponentInParent<DisparoSelectivo>().Armas[1].GetComponent<GunStatus>();
			Arma3 = other.gameObject.GetComponentInParent<DisparoSelectivo>().Armas[2].GetComponent<GunStatus>();
			Arma4 = other.gameObject.GetComponentInParent<DisparoSelectivo>().Armas[3].GetComponent<GunStatus>();

			if (Arma1.CargadoresActuales == Arma1.CargadoresTotales && Arma2.CargadoresActuales == Arma2.CargadoresTotales && Arma3.CargadoresActuales == Arma3.CargadoresTotales && Arma4.CargadoresActuales == Arma4.CargadoresTotales)
			{

			}
			else
			if (Arma1.CargadoresActuales < Arma1.CargadoresTotales || Arma2.CargadoresActuales < Arma2.CargadoresTotales || Arma3.CargadoresActuales < Arma3.CargadoresTotales || Arma4.CargadoresActuales < Arma4.CargadoresTotales)
			{
				

				Arma1.CargadoresActuales += municion1;
				Arma2.CargadoresActuales += municion2;
				Arma3.CargadoresActuales += municion3;
				Arma4.CargadoresActuales += municion4;
				if (Arma1.CargadoresActuales > Arma1.CargadoresTotales)
				{
					Arma1.CargadoresActuales = Arma1.CargadoresTotales;
				}
				if (Arma2.CargadoresActuales > Arma2.CargadoresTotales)
				{
					Arma2.CargadoresActuales = Arma2.CargadoresTotales;
				}
				if (Arma3.CargadoresActuales > Arma3.CargadoresTotales)
				{
					Arma3.CargadoresActuales = Arma3.CargadoresTotales;
				}
				if (Arma4.CargadoresActuales > Arma4.CargadoresTotales)
				{
					Arma4.CargadoresActuales = Arma4.CargadoresTotales;
				}
				Destroy(gameObject);
			}
		}
	}
}
