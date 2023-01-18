using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alertasubs : MonoBehaviour {

    public static string Quien = "Youtube";
    public static string Desmone = "Felicidades";
    public static string Desmonexp = "Enhorabuena por alcanzar la cifra de 100.000 suscriptores, sigue así y llegarás a la altura de los más grandes de la historia de Youtube.";
    void Start () {
		
	}

    // Update is called once per frame
    void OnEnable()
    {        

        if (Controlador.Suscriptores >= 100000)
        {
            if (!Controlador.cienk)
            {
                Quien = "Youtube";
                Desmone = "Felicidades";
                Desmonexp = "Enhorabuena por alcanzar la cifra de 100.000 suscriptores, sigue así y llegarás a la altura de los más grandes de la historia de Youtube. Tu merecida placa está en camino.";
                Statsmails.z20 = Statsmails.z19;
                Statsmails.x20 = Statsmails.x19;
                Statsmails.v20 = Statsmails.v19;
                Statsmails.Veinte = Statsmails.Diecinueve;
                Conversorini();
                Debug.Log("AY WEY LOS PINCHES DE YUTUF");
            }
        }

        if (Controlador.Suscriptores >= 1000000)
        {
            if (!Controlador.cienk)
            {
                Quien = "Youtube";
                Desmone = "Felicidades";
                Desmonexp = "Felicitaciones por conseguir la magnífica cifra de 1 millón de suscriptores, estamos muy contentos de tenerte en Youtube y ser un modelo a seguir para muchos jovenes.";
                Statsmails.z20 = Statsmails.z19;
                Statsmails.x20 = Statsmails.x19;
                Statsmails.v20 = Statsmails.v19;
                Statsmails.Veinte = Statsmails.Diecinueve;
                Conversorini();
                Debug.Log("AY WEY LOS PINCHES DE YUTUF");
            }
        }

        if (Controlador.Suscriptores >= 10000000)
        {
            if (!Controlador.diezm)
            {
                Quien = "Youtube";
                Desmone = "Felicidades por lograr 10M";
                Desmonexp = "Increíble se queda corto para tu gran hazaña recién conseguida, sin duda tu carisma te ha llevado a colarte entre uno de los mejores Youtubers de la actualidad.";
                Statsmails.z20 = Statsmails.z19;
                Statsmails.x20 = Statsmails.x19;
                Statsmails.v20 = Statsmails.v19;
                Statsmails.Veinte = Statsmails.Diecinueve;
                Conversorini();
                Debug.Log("AY WEY LOS PINCHES DE YUTUF");
            }
        }

        if (Controlador.Suscriptores >= 50000000)
        {
            if (!Controlador.cincom)
            {
                Quien = "Youtube";
                Desmone = "Asombroso";
                Desmonexp = "Sólo unos pocos han conseguido lo que tú acabas de conseguir y es la asombrosa cifra de 50 millones de suscriptores, has hecho historia y estamos orgullosos de que alguien como tú represente nuestra marca.";
                Statsmails.z20 = Statsmails.z19;
                Statsmails.x20 = Statsmails.x19;
                Statsmails.v20 = Statsmails.v19;
                Statsmails.Veinte = Statsmails.Diecinueve;
                Conversorini();
                Debug.Log("AY WEY LOS PINCHES DE YUTUF");
            }
        }

        if (Controlador.Suscriptores >= 100000000)
        {
            if (!Controlador.cienm)
            {
                Quien = "Google";
                Desmone = "Lo has logrado";
                Desmonexp = "Un pequeño paso para un hombre, pero un gran paso para Youtube, te felicitamos directamente desde las oficinas de Google por alcanzar la gloriosa cifra de 100 millones de suscriptores. Sin ninguna duda te has convertido en uno de los más grandes de la historia de esta plataforma.";
                Statsmails.z20 = Statsmails.z19;
                Statsmails.x20 = Statsmails.x19;
                Statsmails.v20 = Statsmails.v19;
                Statsmails.Veinte = Statsmails.Diecinueve;
                Conversorini();
                Debug.Log("AY WEY LOS PINCHES DE YUTUF");
            }
        }



    }

    void Conversorini()
    {
        Statsmails.z19 = Statsmails.z18;
        Statsmails.x19 = Statsmails.x18;
        Statsmails.v19 = Statsmails.v18;
        Statsmails.Diecinueve = Statsmails.Dieciocho;
        Conversor();
    }

    void Conversor()
    {
        Statsmails.z18 = Statsmails.z17;
        Statsmails.x18 = Statsmails.x17;
        Statsmails.v18 = Statsmails.v17;
        Statsmails.Dieciocho = Statsmails.Diecisiete;
        Conversor2();
    }

    void Conversor2()
    {
        Statsmails.z17 = Statsmails.z16;
        Statsmails.x17 = Statsmails.x16;
        Statsmails.v17 = Statsmails.v16;
        Statsmails.Diecisiete = Statsmails.Dieciseis;
        Conversor3();
    }

    void Conversor3()
    {
        Statsmails.z16 = Statsmails.z15;
        Statsmails.x16 = Statsmails.x15;
        Statsmails.v16 = Statsmails.v15;
        Statsmails.Dieciseis = Statsmails.Quince;
        Conversor4();
    }

    void Conversor4()
    {
        Statsmails.z15 = Statsmails.z14;
        Statsmails.x15 = Statsmails.x14;
        Statsmails.v15 = Statsmails.v14;
        Statsmails.Quince = Statsmails.Catorce;
        Conversor5();
    }
    void Conversor5()
    {
        Statsmails.z14 = Statsmails.z13;
        Statsmails.x14 = Statsmails.x13;
        Statsmails.v14 = Statsmails.v13;
        Statsmails.Catorce = Statsmails.Trece;
        Conversor6();
    }
    void Conversor6()
    {
        Statsmails.z13 = Statsmails.z12;
        Statsmails.x13 = Statsmails.x12;
        Statsmails.v13 = Statsmails.v12;
        Statsmails.Trece = Statsmails.Doce;
        Conversor7();
    }
    void Conversor7()
    {
        Statsmails.z12 = Statsmails.z11;
        Statsmails.x12 = Statsmails.x11;
        Statsmails.v12 = Statsmails.v11;
        Statsmails.Doce = Statsmails.Once;
        Conversor8();
    }
    void Conversor8()
    {
        Statsmails.z11 = Statsmails.z10;
        Statsmails.x11 = Statsmails.x10;
        Statsmails.v11 = Statsmails.v10;
        Statsmails.Once = Statsmails.Decimo;
        Conversor9();
    }
    void Conversor9()
    {
        Statsmails.z10 = Statsmails.z9;
        Statsmails.x10 = Statsmails.x9;
        Statsmails.v10 = Statsmails.v9;
        Statsmails.Decimo = Statsmails.Noveno;
        Conversor10();
    }
    void Conversor10()
    {
        Statsmails.z9 = Statsmails.z8;
        Statsmails.x9 = Statsmails.x8;
        Statsmails.v9 = Statsmails.v8;
        Statsmails.Noveno = Statsmails.Octavo;
        Conversor11();
    }
    void Conversor11()
    {
        Statsmails.z8 = Statsmails.z7;
        Statsmails.x8 = Statsmails.x7;
        Statsmails.v8 = Statsmails.v7;
        Statsmails.Octavo = Statsmails.Septimo;
        Conversor12();
    }
    void Conversor12()
    {
        Statsmails.z7 = Statsmails.z6;
        Statsmails.x7 = Statsmails.x6;
        Statsmails.v7 = Statsmails.v6;
        Statsmails.Septimo = Statsmails.Sexto;
        Conversor13();
    }
    void Conversor13()
    {
        Statsmails.z6 = Statsmails.z5;
        Statsmails.x6 = Statsmails.x5;
        Statsmails.v6 = Statsmails.v5;
        Statsmails.Sexto = Statsmails.Quinto;
        Conversor14();
    }
    void Conversor14()
    {
        Statsmails.z5 = Statsmails.z4;
        Statsmails.x5 = Statsmails.x4;
        Statsmails.v5 = Statsmails.v4;
        Statsmails.Quinto = Statsmails.Cuarto;
        Conversor15();
    }
    void Conversor15()
    {
        Statsmails.z4 = Statsmails.z3;
        Statsmails.x4 = Statsmails.x3;
        Statsmails.v4 = Statsmails.v3;
        Statsmails.Cuarto = Statsmails.Tercero;
        Conversor16();
        
    }
    void Conversor16()
    {
        Statsmails.z3 = Statsmails.z2;
        Statsmails.x3 = Statsmails.x2;
        Statsmails.v3 = Statsmails.v2;
        Statsmails.Tercero = Statsmails.Segundo;
        Conversor17();
        
    }
    void Conversor17()
    {
        Statsmails.z2 = Statsmails.z1;
        Statsmails.x2 = Statsmails.x1;
        Statsmails.v2 = Statsmails.v1;
        Statsmails.Segundo = Statsmails.Primero;
        Conversor18();
        
    }
    void Conversor18()
    {
        Statsmails.z1 = Quien;
        Statsmails.x1 = Desmonexp;
        Statsmails.v1 = 1;
        Statsmails.Primero = Desmone;
        
        if (Controlador.Suscriptores >= 100000)
        {
            Controlador.cienk = true;
        }
        if (Controlador.Suscriptores >= 1000000)
        {
            Controlador.unm = true;
        }
        if (Controlador.Suscriptores >= 10000000)
        {
            Controlador.diezm = true;
        }
        if (Controlador.Suscriptores >= 50000000)
        {
            Controlador.cincom = true;
        }
        if (Controlador.Suscriptores >= 100000000)
        {
            Controlador.cienm = true;
        }
       
        
    }
}
