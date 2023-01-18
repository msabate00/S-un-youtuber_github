using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statsmails : MonoBehaviour {

    public static string Primero;
    public static string Segundo; // los asuntos del mail
    public static string Tercero;
    public static string Cuarto;
    public static string Quinto;
    public static string Sexto;
    public static string Septimo;
    public static string Octavo;
    public static string Noveno;
    public static string Decimo;
    public static string Once;
    public static string Doce;
    public static string Trece;
    public static string Catorce;
    public static string Quince;
    public static string Dieciseis;
    public static string Diecisiete;
    public static string Dieciocho;
    public static string Diecinueve;
    public static string Veinte;
    public static int v1; // triggers del blanco gris este de los cojones; 0 es no hay mail 1 es mail no leido y 2 es leido
    public static int v2;
    public static int v3;
    public static int v4;
    public static int v5;
    public static int v6;
    public static int v7;
    public static int v8;
    public static int v9;
    public static int v10;
    public static int v11;
    public static int v12;
    public static int v13;
    public static int v14;
    public static int v15;
    public static int v16;
    public static int v17;
    public static int v18;
    public static int v19;
    public static int v20;
    public static string x1; // textos dentro del mail
    public static string x2;
    public static string x3;
    public static string x4;
    public static string x5;
    public static string x6;
    public static string x7;
    public static string x8;
    public static string x9;
    public static string x10;
    public static string x11;
    public static string x12;
    public static string x13;
    public static string x14;
    public static string x15;
    public static string x16;
    public static string x17;
    public static string x18;
    public static string x19;
    public static string x20;
    public static string z1; // quien lo ha enviado
    public static string z2;
    public static string z3;
    public static string z4;
    public static string z5;
    public static string z6;
    public static string z7;
    public static string z8;
    public static string z9;
    public static string z10;
    public static string z11;
    public static string z12;
    public static string z13;
    public static string z14;
    public static string z15;
    public static string z16;
    public static string z17;
    public static string z18;
    public static string z19;
    public static string z20;

    public static string Quien = "Youtube";
    public static string Desmone = "Este vídeo ha sido desmonetizado";
    public static string Desmonexp = "Pos si tio lo lamento que te cagas pero es que tus videos son una putisima mierda y alguien tiene que censurar tu puta bazofia de canal TE JODES.";
    void Start () {
		
	}

    // Update is called once per frame
    void OnEnable()
    {

        if (Controlador.Copy)
        {
            z20 = z19;
            x20 = x19;
            v20 = v19;
            Veinte = Diecinueve;
            Conversorini();
            Debug.Log("AY WEY LOS PINCHES DE YUTUF");
        }
    }
    void Conversorini()
    {
        z19 = z18;
        x19 = x18;
        v19 = v18;
        Diecinueve = Dieciocho;
        Conversor();
    }

    void Conversor()
    {
        z18 = z17;
        x18 = x17;
        v18 = v17;
        Dieciocho = Diecisiete;
        Conversor2();
    }

    void Conversor2()
    {
        z17 = z16;
        x17 = x16;
        v17 = v16;
        Diecisiete = Dieciseis;
        Conversor3();
    }

    void Conversor3()
    {
        z16 = z15;
        x16 = x15;
        v16 = v15;
        Dieciseis = Quince;
        Conversor4();
    }

    void Conversor4()
    {
        z15 = z14;
        x15 = x14;
        v15 = v14;
        Quince = Catorce;
        Conversor5();
    }
    void Conversor5()
    {
        z14 = z13;
        x14 = x13;
        v14 = v13;
        Catorce = Trece;
        Conversor6();
    }
    void Conversor6()
    {
        z13 = z12;
        x13 = x12;
        v13 = v12;
        Trece = Doce;
        Conversor7();
    }
    void Conversor7()
    {
        z12 = z11;
        x12 = x11;
        v12 = v11;
        Doce = Once;
        Conversor8();
    }
    void Conversor8()
    {
        z11 = z10;
        x11 = x10;
        v11 = v10;
        Once = Decimo;
        Conversor9();
    }
    void Conversor9()
    {
        z10 = z9;
        x10 = x9;
        v10 = v9;
        Decimo = Noveno;
        Conversor10();
    }
    void Conversor10()
    {
        z9 = z8;
        x9 = x8;
        v9 = v8;
        Noveno = Octavo;
        Conversor11();
    }
    void Conversor11()
    {
        z8 = z7;
        x8 = x7;
        v8 = v7;
        Octavo = Septimo;
        Conversor12();
    }
    void Conversor12()
    {
        z7 = z6;
        x7 = x6;
        v7 = v6;
        Septimo = Sexto;
        Conversor13();
    }
    void Conversor13()
    {
        z6 = z5;
        x6 = x5;
        v6 = v5;
        Sexto = Quinto;
        Conversor14();
    }
    void Conversor14()
    {
        z5 = z4;
        x5 = x4;
        v5 = v4;
        Quinto = Cuarto;
        Conversor15();
    }
    void Conversor15()
    {
        z4 = z3;
        x4 = x3;
        v4 = v3;
        Cuarto = Tercero;
        Conversor16();
        
    }
    void Conversor16()
    {
        z3 = z2;
        x3 = x2;
        v3 = v2;
        Tercero = Segundo;
        Conversor17();
        
    }
    void Conversor17()
    {
        z2 = z1;
        x2 = x1;
        v2 = v1;
        Segundo = Primero;
        Conversor18();
        
    }
    void Conversor18()
    {
        z1 = Quien;
        x1 = Desmonexp;
        v1 = 1;
        Primero = Desmone;
        Controlador.Copy = false;
        
    }
}
