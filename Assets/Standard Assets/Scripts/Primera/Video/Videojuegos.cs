using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Videojuegos : MonoBehaviour {

    public float[] precios = new float[35];
    public float[] preciofinal = new float[35];
    public int[] descuento = new int[35];
    public bool[] disponible = new bool[35];
    public static int nota = 0;  //la suma entre los 2 anteriores, (1-9)
    public static int juego1com = 1; // que si lo has comprao 0 es no 1 es si joder si no entiendes esto mirate este video a ver si te ayuda https://www.youtube.com/watch?v=9tUk8eZBuKY
    public static int juego1 = 8;  //2 cold, 5 normal, 8 hot
    public static int juego1skill = 1;  //1 has entrenado, 0 poco, -1 no
    public static int juego1req = 2;
    public static int juego2com = 1;
    public static int juego2 = 2;
    public static int juego2skill = -1;
    public static int juego2req = 1;
    public static int juego3com = 1;
    public static int juego3 = 2;
    public static int juego3skill = -1;
    public static int juego3req = 1; // 1 es pocos requisitos, 2 es normales y 3 la puta pcmaster race, si es menor que Controlador.Ordenador se supone que no tienes requisitos y no puedes juegar jaja pringao
    public static int juego4com = 1;
    public static int juego4 = 5;
    public static int juego4skill = 0;
    public static int juego4req = 2;
    public static int juego5com = 1;
    public static int juego5 = 2;
    public static int juego5skill = -1;
    public static int juego5req = 2;
    public static int juego6com = 1;
    public static int juego6 = 2;
    public static int juego6skill = -1;
    public static int juego6req = 3;
    public static int juego7com = 1;
    public static int juego7 = 2;
    public static int juego7skill = -1;
    public static int juego7req = 1;
    public static int juego8com = 0;
    public static int juego8 = 2;
    public static int juego8skill = 0;
    public static int juego8req = 2;
    public static int juego9com = 0;
    public static int juego9 = 5;
    public static int juego9skill = 1;
    public static int juego9req = 2;
    public static int juego10com = 0;
    public static int juego10 = 5;
    public static int juego10skill = 0;
    public static int juego10req = 2;
    public static int juego11com = 0;
    public static int juego11 = 8;
    public static int juego11skill = 1;
    public static int juego11req = 3;
    public static int juego12com = 0;
    public static int juego12 = 8;
    public static int juego12skill = 0;
    public static int juego12req = 2;
    public static int juego13com = 0;
    public static int juego13 = 8;
    public static int juego13skill = 1;
    public static int juego13req = 2;
    public static int juego14com = 0;
    public static int juego14 = 8;
    public static int juego14skill = 1;
    public static int juego14req = 2;
    public static int juego15com = 0;
    public static int juego15 = 2;
    public static int juego15skill = -1;
    public static int juego15req = 1;
    public static int juego16com = 0;
    public static int juego16 = 2;
    public static int juego16skill = -1;
    public static int juego16req = 2;
    public static int juego17com = 0;
    public static int juego17 = 2;
    public static int juego17skill = -1;
    public static int juego17req = 1;
    public static int juego18com = 0;
    public static int juego18 = 2;
    public static int juego18skill = -1;
    public static int juego18req = 3;
    public static int juego19com = 0;
    public static int juego19 = 2;
    public static int juego19skill = -1;
    public static int juego19req = 1;
    public static int juego20com = 0;
    public static int juego20 = 2;
    public static int juego20skill = -1;
    public static int juego20req = 1;
    public static int juego21com = 0;
    public static int juego21 = 8;
    public static int juego21skill = -1;
    public static int juego21req = 2;
    public static int juego22com = 0;
    public static int juego22 = 8;
    public static int juego22skill = 1;
    public static int juego22req = 3;
    public static int juego23com = 0;
    public static int juego23 = 5;
    public static int juego23skill = 1;
    public static int juego23req = 3;
    public static int juego24com = 0;
    public static int juego24 = 5;
    public static int juego24skill = 1;
    public static int juego24req = 2;
    public static int juego25com = 0;
    public static int juego25 = 8;
    public static int juego25skill = 1;
    public static int juego25req = 3;
    public static int juego26com = 0;
    public static int juego26 = 5;
    public static int juego26skill = 1;
    public static int juego26req = 2;
    public static int juego27com = 0;
    public static int juego27 = 8;
    public static int juego27skill = 1;
    public static int juego27req = 2;
    public static int juego28com = 0;
    public static int juego28 = 8;
    public static int juego28skill = 1;
    public static int juego28req = 3;
    public static int juego29com = 0;
    public static int juego29 = 8;
    public static int juego29skill = 1;
    public static int juego29req = 2;
    public static int juego30com = 0;
    public static int juego30 = 5;
    public static int juego30skill = 1;
    public static int juego30req = 2;
    public static int juego31com = 0;
    public static int juego31 = 5;
    public static int juego31skill = 1;
    public static int juego31req = 3;
    public static int juego32com = 0;
    public static int juego32 = 5;
    public static int juego32skill = 1;
    public static int juego32req = 3;
    public static int juego33com = 0;
    public static int juego33 = 5;
    public static int juego33skill = 1;
    public static int juego33req = 3;
    public static int juego34com = 0;
    public static int juego34 = 5;
    public static int juego34skill = 1;
    public static int juego34req = 3;
    public static int juego35com = 0;
    public static int juego35 = 5;
    public static int juego35skill = 1;
    public static int juego35req = 2;

    public static int juegoselecintmax = 0;
    public static int juegoselecint = 0;
    public static int juego1intmax = 3; // maximo para cada juego es 5, en este caso es 3 porque esta old y no da mas de si exdi CSGO la cuestion es que el interes maximo baja en 5 videos de ese mismo juego en los que baja claro está fóllame perra
    public static int juego1int = 3;
    public static int juego2intmax = 5; // Minecraft baja a 3    X CIERTO LAS TENDENCIAS ALEATORIAS SUBEN EL INTERES MAXIMO A 4 O 5 CRUCK
    public static int juego2int = 5;
    public static int juego3intmax = 3; // LOL
    public static int juego3int = 3;
    public static int juego4intmax = 3; // NBA
    public static int juego4int = 3;
    public static int juego5intmax = 4; // fifa
    public static int juego5int = 4;
    public static int juego6intmax = 2; // f1
    public static int juego6int = 2;
    public static int juego7intmax = 2; // age of empires
    public static int juego7int = 2;
    public static int juego8intmax = 4; // final fantasy baja a 2
    public static int juego8int = 4;
    public static int juego9intmax = 4; // dark souls baja un poco joder 3
    public static int juego9int = 4;
    public static int juego10intmax = 3; // need for speed
    public static int juego10int = 3;
    public static int juego11intmax = 5; // gta baja a 4
    public static int juego11int = 5;
    public static int juego12intmax = 3; // portal baja a 2
    public static int juego12int = 3;
    public static int juego13intmax = 4; // assassin's creed  baja a 3
    public static int juego13int = 4;
    public static int juego14intmax = 3; // bioshock baja a 2
    public static int juego14int = 3;
    public static int juego15intmax = 3; // undertale
    public static int juego15int = 3;
    public static int juego16intmax = 3; // fallout
    public static int juego16int = 3;
    public static int juego17intmax = 4; // dragon age baja a 3
    public static int juego17int = 4;
    public static int juego18intmax = 4; // devil may cry baja a 3
    public static int juego18int = 4;
    public static int juego19intmax = 4; // diablo baja a 3
    public static int juego19int = 4;
    public static int juego20intmax = 4; // WOW baja a 3
    public static int juego20int = 4;
    public static int juego21intmax = 5; // COD baja a 2 en 10 videos
    public static int juego21int = 5;
    public static int juego22intmax = 5; // Destiny baja a 2 en 5 videos
    public static int juego22int = 5;
    public static int juego23intmax = 4; // bloodborne baja a 2
    public static int juego23int = 4;
    public static int juego24intmax = 3; // unravel baja a 1
    public static int juego24int = 3;
    public static int juego25intmax = 5; // battlefield baja a 4 en 5 videos
    public static int juego25int = 5;
    public static int juego26intmax = 4; // spiderman baja a 2
    public static int juego26int = 4;
    public static int juego27intmax = 4; // rainbow six
    public static int juego27int = 4;
    public static int juego28intmax = 3; // forza horizon
    public static int juego28int = 3;
    public static int juego29intmax = 5; // no man's sky baja a 1 en 3 videos
    public static int juego29int = 5;
    public static int juego30intmax = 4; // nier automata baja a 1 en 4 videos
    public static int juego30int = 4;
    public static int juego31intmax = 4; // the witcher baja a 3
    public static int juego31int = 4;
    public static int juego32intmax = 5; // kingdom hearts baja a 2
    public static int juego32int = 5;
    public static int juego33intmax = 5; // god of war baja a 2
    public static int juego33int = 5;
    public static int juego34intmax = 5; // red dead redemption baja a 3
    public static int juego34int = 5;
    public static int juego35intmax = 5; // fortnite baja a 4
    public static int juego35int = 5;

    public static int juego1v = 0;
    public static int juego2v = 0;
    public static int juego3v = 0;
    public static int juego4v = 0;
    public static int juego5v = 0;
    public static int juego6v = 0;
    public static int juego7v = 0;
    public static int juego8v = 0;
    public static int juego9v = 0;
    public static int juego10v = 0;
    public static int juego11v = 0;
    public static int juego12v = 0;
    public static int juego13v = 0;
    public static int juego14v = 0;
    public static int juego15v = 0;
    public static int juego16v = 0;
    public static int juego17v = 0;
    public static int juego18v = 0;
    public static int juego19v = 0;
    public static int juego20v = 0;
    public static int juego21v = 0;
    public static int juego22v = 0;
    public static int juego23v = 0;
    public static int juego24v = 0;
    public static int juego25v = 0;
    public static int juego26v = 0;
    public static int juego27v = 0;
    public static int juego28v = 0;
    public static int juego29v = 0;
    public static int juego30v = 0;
    public static int juego31v = 0;
    public static int juego32v = 0;
    public static int juego33v = 0;
    public static int juego34v = 0;
    public static int juego35v = 0;

    void Start()
    {

    }
    void Update()
    {

    }

}
