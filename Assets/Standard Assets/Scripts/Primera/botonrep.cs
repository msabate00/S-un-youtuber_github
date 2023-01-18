using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonrep : MonoBehaviour {

	public canciones canpenes;
	public enum boton
	{
		c1,
		c2,
		c3,
		c4,
		c5,
		c6,
		c7,
		c8,
		c9,
		c10,
		c11,
		c12,
		c13,
		c14,
		c15,
		c16,
		c17,
		c18,
		c19,
		c20,
		c21,
		c22,
		c23
	}
	public boton lol = boton.c1;
	void Start () {
		//canpenes = GameObject.Find("Main Camera (2)").GetComponent<canciones>();
	}
	
	// Update is called once per frame
	void OnMouseDown () {
		if (lol == boton.c1)
		{
			canciones.c1 = true;
			canpenes.seleccion(1);
		}
		if (lol == boton.c2)
		{
			canciones.c2 = true;
			canpenes.seleccion(2);
		}
		if (lol == boton.c3)
		{
			canciones.c3 = true;
			canpenes.seleccion(3);
		}
		if (lol == boton.c4)
		{
			canciones.c4 = true;
			canpenes.seleccion(4);
		}
		if (lol == boton.c5)
		{
			canciones.c5 = true;
			canpenes.seleccion(5);
		}
		if (lol == boton.c6)
		{
			canciones.c6 = true;
			canpenes.seleccion(6);
		}
		if (lol == boton.c7)
		{
			canciones.c7 = true;
			canpenes.seleccion(7);
		}
		if (lol == boton.c8)
		{
			canciones.c8 = true;
			canpenes.seleccion(8);
		}
		if (lol == boton.c9)
		{
			canciones.c9 = true;
			canpenes.seleccion(9);
		}
		if (lol == boton.c10)
		{
			canciones.c10 = true;
			canpenes.seleccion(10);
		}
		if (lol == boton.c11)
		{
			canciones.c11 = true;
			canpenes.seleccion(11);
		}
		if (lol == boton.c12)
		{
			canciones.c12 = true;
			canpenes.seleccion(12);
		}
		if (lol == boton.c13)
		{
			canciones.c13 = true;
			canpenes.seleccion(13);
		}
		if (lol == boton.c14)
		{
			canciones.c14 = true;
			canpenes.seleccion(14);
		}
		if (lol == boton.c15)
		{
			canciones.c15 = true;
			canpenes.seleccion(15);
		}
		if (lol == boton.c16)
		{
			canciones.c16 = true;
			canpenes.seleccion(16);
		}
		if (lol == boton.c17)
		{
			canciones.c17 = true;
			canpenes.seleccion(17);
		}
		if (lol == boton.c18)
		{
			canciones.c18 = true;
			canpenes.seleccion(18);
		}
		if (lol == boton.c19)
		{
			canciones.c19 = true;
			canpenes.seleccion(19);
		}
		if (lol == boton.c20)
		{
			canciones.c20 = true;
			canpenes.seleccion(20);
		}
		if (lol == boton.c21)
		{
			canciones.c21 = true;
			canpenes.seleccion(21);
		}
		if (lol == boton.c22)
		{
			canciones.c22 = true;
			canpenes.seleccion(22);
		}
		if (lol == boton.c23)
		{
			canciones.c23 = true;
			canpenes.seleccion(23);
		}
	}
}
