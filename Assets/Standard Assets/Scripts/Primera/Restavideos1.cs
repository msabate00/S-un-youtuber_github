using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restavideos1 : MonoBehaviour {
    public static bool tend1 = false;
    public static bool tend2 = false;
    public static bool tend3 = false;
    public static bool tend4 = false;
    public static bool tend5 = false;
    public static bool tend6 = false;
    public static bool tend7 = false;
    public static bool tend8 = false;
    public static bool tend9 = false;
    public static bool tend10 = false;
    public static bool tend11 = false;
    public static bool tend12 = false;
    public static bool tend13 = false;
    public static bool tend14 = false;
    public static bool tend15 = false;
    public static bool tend16 = false;
    public static bool tend17 = false;
    public static bool tend18 = false;
    public static bool tend19 = false;
    public static bool tend20 = false;
    public static bool tend21 = false;
    public static bool tend22 = false;
    public static bool tend23 = false;
    public static bool tend24 = false;
    public static bool tend25 = false;
    public static bool tend26 = false;
    public static bool tend27 = false;
    public static bool tend28 = false;
    public static bool tend29 = false;
    public static bool tend30 = false;
    public static bool tend31 = false;
    public static bool tend32 = false;
    public static bool tend33 = false;
    public static bool tend34 = false;
    public static bool tend35 = false;

    void OnEnable () {
        if (!tend1)
        {
            Videojuegos.juego1intmax = 3;
        }


        if (!tend2)
        {
            if (Videojuegos.juego2v <= 4)
            {
                Videojuegos.juego2intmax = 5;
            }
                if (Videojuegos.juego2v >= 5)
            {
                Videojuegos.juego2intmax = 3;
                if (Videojuegos.juego2int >= 4)
                {
                    Videojuegos.juego2int = 3;
                }
            }
        }

        if (!tend3)
        {
            Videojuegos.juego3intmax = 3;
        }

        if (!tend4)
        {
            Videojuegos.juego4intmax = 3;
        }

        if (!tend5)
        {
            Videojuegos.juego5intmax = 4;
        }
        if (!tend6)
        {
            Videojuegos.juego6intmax = 2;
        }
        if (!tend7)
        {
            Videojuegos.juego7intmax = 2;
        }

        if (!tend8)
        {
            if (Videojuegos.juego8v <= 4)
            {
                Videojuegos.juego8intmax = 4;
            }
                if (Videojuegos.juego8v >= 5)
            {
                Videojuegos.juego8intmax = 2;
                if (Videojuegos.juego8int >= 3)
                {
                    Videojuegos.juego8int = 2;
                }
            }
        }



        if (!tend9)
        {
            if (Videojuegos.juego9v <= 4)
            {
                Videojuegos.juego9intmax = 4;
            }
                if (Videojuegos.juego9v >= 5)
            {
                Videojuegos.juego9intmax = 3;
                if (Videojuegos.juego9int >= 4)
                {
                    Videojuegos.juego9int = 3;
                }
            }
        }

        if (!tend10)
        {
            Videojuegos.juego10intmax = 3;
        }

        if (!tend11)
        {
            if (Videojuegos.juego11v <= 4)
            {
                Videojuegos.juego11intmax = 5;
            }
                if (Videojuegos.juego11v >= 5)
            {
                Videojuegos.juego11intmax = 4;
                if (Videojuegos.juego11int >= 5)
                {
                    Videojuegos.juego11int = 4;
                }
            }
        }


        if (!tend12)
        {
            if (Videojuegos.juego12v <= 4)
            {
                Videojuegos.juego12intmax = 3;
            }
            if (Videojuegos.juego12v >= 5)
            {
                Videojuegos.juego12intmax = 2;
                if (Videojuegos.juego12int >= 3)
                {
                    Videojuegos.juego12int = 2;
                }
            }
        }


        if (!tend13)
        {
            if (Videojuegos.juego13v <= 4)
            {
                Videojuegos.juego13intmax = 4;
            }
            if (Videojuegos.juego13v >= 5)
            {
                Videojuegos.juego13intmax = 3;
                if (Videojuegos.juego13int >= 4)
                {
                    Videojuegos.juego13int = 3;
                }
            }
        }

        if (!tend14)
        {
            if (Videojuegos.juego14v <= 4)
            {
                Videojuegos.juego14intmax = 3;
            }
            if (Videojuegos.juego14v >= 5)
            {
                Videojuegos.juego14intmax = 2;
                if (Videojuegos.juego14int >= 3)
                {
                    Videojuegos.juego14int = 2;
                }
            }
        }

        if (!tend15)
        {
            Videojuegos.juego15intmax = 3;
        }
        if (!tend16)
        {
            Videojuegos.juego16intmax = 3;
        }
        if (!tend17)
        {
            if (Videojuegos.juego17v <= 4)
            {
                Videojuegos.juego17intmax = 4;
            }
            if (Videojuegos.juego17v >= 5)
            {
                Videojuegos.juego17intmax = 3;
                if (Videojuegos.juego17int >= 4)
                {
                    Videojuegos.juego17int = 3;
                }
            }
        }


        if (!tend18)
        {
            if (Videojuegos.juego18v <= 4)
            {
                Videojuegos.juego18intmax = 4;
            }
            if (Videojuegos.juego18v >= 5)
            {
                Videojuegos.juego18intmax = 3;
                if (Videojuegos.juego18int >= 4)
                {
                    Videojuegos.juego18int = 3;
                }
            }
        }


        if (!tend19)
        {
            if (Videojuegos.juego19v <= 4)
            {
                Videojuegos.juego19intmax = 4;
            }
            if (Videojuegos.juego19v >= 5)
            {
                Videojuegos.juego19intmax = 3;
                if (Videojuegos.juego19int >= 4)
                {
                    Videojuegos.juego19int = 3;
                }
            }
        }


        if (!tend20)
        {
            if (Videojuegos.juego20v <= 4)
            {
                Videojuegos.juego20intmax = 4;
            }
            if (Videojuegos.juego20v >= 5)
            {
                Videojuegos.juego20intmax = 3;
                if (Videojuegos.juego20int >= 4)
                {
                    Videojuegos.juego20int = 3;
                }
            }
        }

        if (!tend21)
        {
            if (Videojuegos.juego21v <= 2)
            {
                Videojuegos.juego21intmax = 5;
            }
            if (Videojuegos.juego21v >= 3 && Videojuegos.juego21v <= 4)
            {
                Videojuegos.juego21intmax = 4;
                if (Videojuegos.juego21int >= 5)
                {
                    Videojuegos.juego21int = 4;
                }
            }
            if (Videojuegos.juego21v >= 5 && Videojuegos.juego21v <= 7)
            {
                Videojuegos.juego21intmax = 3;
                if (Videojuegos.juego21int >= 4)
                {
                    Videojuegos.juego21int = 3;
                }
            }
            if (Videojuegos.juego21v >= 8)
            {
                Videojuegos.juego21intmax = 2;
                if (Videojuegos.juego21int >= 3)
                {
                    Videojuegos.juego21int = 2;
                }
            }
        }


        if (!tend22)
        {
            if (Videojuegos.juego22v <= 4)
            {
                Videojuegos.juego22intmax = 5;
            }
            if (Videojuegos.juego22v >= 5)
            {
                Videojuegos.juego22intmax = 2;
                if (Videojuegos.juego22int >= 3)
                {
                    Videojuegos.juego22int = 2;
                }
            }
        }

        if (!tend23)
        {
            if (Videojuegos.juego23v <= 4)
            {
                Videojuegos.juego23intmax = 4;
            }
            if (Videojuegos.juego23v >= 5)
            {
                Videojuegos.juego23intmax = 2;
                if (Videojuegos.juego23int >= 3)
                {
                    Videojuegos.juego23int = 2;
                }
            }
        }

        if (!tend24)
        {
            if (Videojuegos.juego24v <= 2)
            {
                Videojuegos.juego24intmax = 3;
            }
            if (Videojuegos.juego24v >= 3)
            {
                Videojuegos.juego24intmax = 1;
                if (Videojuegos.juego24int >= 2)
                {
                    Videojuegos.juego24int = 1;
                }
            }
        }

        if (!tend25)
        {
            if (Videojuegos.juego25v <= 4)
            {
                Videojuegos.juego25intmax = 5;
            }
            if (Videojuegos.juego25v >= 5)
            {
                Videojuegos.juego25intmax = 4;
                if (Videojuegos.juego25int >= 5)
                {
                    Videojuegos.juego25int = 4;
                }
            }
        }

        if (!tend26)
        {
            if (Videojuegos.juego26v <= 4)
            {
                Videojuegos.juego26intmax = 4;
            }
            if (Videojuegos.juego26v >= 5)
            {
                Videojuegos.juego26intmax = 2;
                if (Videojuegos.juego26int >= 3)
                {
                    Videojuegos.juego26int = 2;
                }
            }
        }

        if (!tend27)
        {
            Videojuegos.juego27intmax = 4;
        }
        if (!tend28)
        {
            Videojuegos.juego28intmax = 3;
        }
        if (!tend29)
        {
            if (Videojuegos.juego29v <= 2)
            {
                Videojuegos.juego29intmax = 5;
            }
            if (Videojuegos.juego29v >= 3)
            {
                Videojuegos.juego29intmax = 1;
                if (Videojuegos.juego29int >= 2)
                {
                    Videojuegos.juego29int = 1;
                }
            }
        }

        if (!tend30)
        {
            if (Videojuegos.juego30v <= 3)
            {
                Videojuegos.juego30intmax = 4;
            }
            if (Videojuegos.juego30v >= 4)
            {
                Videojuegos.juego30intmax = 1;
                if (Videojuegos.juego30int >= 2)
                {
                    Videojuegos.juego30int = 1;
                }
            }
        }

        if (!tend31)
        {
            if (Videojuegos.juego31v <= 3)
            {
                Videojuegos.juego31intmax = 4;
            }
            if (Videojuegos.juego31v >= 4)
            {
                Videojuegos.juego31intmax = 3;
                if (Videojuegos.juego31int >= 4)
                {
                    Videojuegos.juego31int = 3;
                }
            }
        }

        if (!tend32)
        {
            if (Videojuegos.juego32v <= 2)
            {
                Videojuegos.juego32intmax = 5;
            }
            if (Videojuegos.juego32v >= 3 && Videojuegos.juego32v <= 4)
            {
                Videojuegos.juego32intmax = 4;
                if (Videojuegos.juego32int >= 5)
                {
                    Videojuegos.juego32int = 4;
                }
            }
            if (Videojuegos.juego32v >= 5)
            {
                Videojuegos.juego32intmax = 3;
                if (Videojuegos.juego32int >= 4)
                {
                    Videojuegos.juego32int = 3;
                }
            }
            
        }


        if (!tend33)
        {
            if (Videojuegos.juego33v <= 6)
            {
                Videojuegos.juego33intmax = 5;
            }
            if (Videojuegos.juego33v >= 7)
            {
                Videojuegos.juego33intmax = 2;
                if (Videojuegos.juego33int >= 3)
                {
                    Videojuegos.juego33int = 2;
                }
            }
        }

        if (!tend34)
        {
            if (Videojuegos.juego34v <= 4)
            {
                Videojuegos.juego34intmax = 5;
            }
            if (Videojuegos.juego34v >= 5)
            {
                Videojuegos.juego34intmax = 3;
                if (Videojuegos.juego34int >= 4)
                {
                    Videojuegos.juego34int = 3;
                }
            }
        }

        if (!tend35)
        {
            if (Videojuegos.juego35v <= 6)
            {
                Videojuegos.juego35intmax = 5;
            }
            if (Videojuegos.juego35v >= 7)
            {
                Videojuegos.juego35intmax = 4;
                if (Videojuegos.juego35int >= 5)
                {
                    Videojuegos.juego35int = 4;
                }
            }
        }

    }
}
