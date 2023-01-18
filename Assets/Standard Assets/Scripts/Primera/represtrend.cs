using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class represtrend : MonoBehaviour {

    public TextMeshProUGUI texto1;
    public TextMeshProUGUI texto2;
    public TextMeshProUGUI texto3;
    public GameObject textamen1;
    public GameObject textamen2;
    public GameObject textamen3;
    public GameObject textamen4;

    void OnEnable () {
        if (Controlador.trendactivao)
        {
       //     textamen1.SetActive(true);
        //    textamen2.SetActive(true);
          //  textamen3.SetActive(true);
            //Controlador.trendactivao = false;
            //textamen4.SetActive(true);
        }
        if (!Controlador.trendactivao)
        {
            //textamen1.SetActive(false);
           // textamen2.SetActive(false);
           // textamen3.SetActive(false);
           // textamen4.SetActive(false);
        }




        if (Nsetio.primero == 1)
        {
            texto1.text = "-Counter Strike";
        }
        if (Nsetio.primero == 2)
        {
            texto1.text = "-Minecraft";
        }
        if (Nsetio.primero == 3)
        {
            texto1.text = "-League Of Legends";
        }
        if (Nsetio.primero == 4)
        {
            texto1.text = "-NBA 2K";
        }
        if (Nsetio.primero == 5)
        {
            texto1.text = "-FIFA";
        }
        if (Nsetio.primero == 6)
        {
            texto1.text = "-F1";
        }
        if (Nsetio.primero == 7)
        {
            texto1.text = "-Age Of Empires";
        }
        if (Nsetio.primero == 8)
        {
            texto1.text = "-Final Fantasy";
        }
        if (Nsetio.primero == 9)
        {
            texto1.text = "-Dark Souls";
        }
        if (Nsetio.primero == 10)
        {
            texto1.text = "-Need For Speed";
        }
        if (Nsetio.primero == 11)
        {
            texto1.text = "-Grand Theft Auto";
        }
        if (Nsetio.primero == 12)
        {
            texto1.text = "-Portal";
        }
        if (Nsetio.primero == 13)
        {
            texto1.text = "-Assassin's Creed";
        }
        if (Nsetio.primero == 14)
        {
            texto1.text = "-Bioshock";
        }
        if (Nsetio.primero == 15)
        {
            texto1.text = "-Undertale";
        }
        if (Nsetio.primero == 16)
        {
            texto1.text = "-Fallout";
        }
        if (Nsetio.primero == 17)
        {
            texto1.text = "-Dragon Age";
        }
        if (Nsetio.primero == 18)
        {
            texto1.text = "-Devil May Cry";
        }
        if (Nsetio.primero == 19)
        {
            texto1.text = "-Diablo";
        }
        if (Nsetio.primero == 20)
        {
            texto1.text = "-World Of Warcraft";
        }
        if (Nsetio.primero == 21)
        {
            texto1.text = "-Call Of Duty";
        }
        if (Nsetio.primero == 22)
        {
            texto1.text = "-Destiny";
        }
        if (Nsetio.primero == 23)
        {
            texto1.text = "-Bloodborne";
        }
        if (Nsetio.primero == 24)
        {
            texto1.text = "-Unravel";
        }
        if (Nsetio.primero == 25)
        {
            texto1.text = "-Battlefield";
        }
        if (Nsetio.primero == 26)
        {
            texto1.text = "-Rainbow Six";
        }
        if (Nsetio.primero == 27)
        {
            texto1.text = "-Spiderman";
        }
        if (Nsetio.primero == 28)
        {
            texto1.text = "-Forza Horizon";
        }
        if (Nsetio.primero == 29)
        {
            texto1.text = "-No Man's Sky";
        }
        if (Nsetio.primero == 30)
        {
            texto1.text = "-Nier Automata";
        }
        if (Nsetio.primero == 31)
        {
            texto1.text = "-The Witcher";
        }
        if (Nsetio.primero == 32)
        {
            texto1.text = "-Kingdom Hearts";
        }
        if (Nsetio.primero == 33)
        {
            texto1.text = "-God Of War";
        }
        if (Nsetio.primero == 34)
        {
            texto1.text = "-Red Dead Redemption";
        }
        if (Nsetio.primero == 35)
        {
            texto1.text = "-Fortnite";
        }



        if (Nsetio.segundo == 1)
        {
            texto2.text = "-Counter Strike";
        }
        if (Nsetio.segundo == 2)
        {
            texto2.text = "-Minecraft";
        }
        if (Nsetio.segundo == 3)
        {
            texto2.text = "-League Of Legends";
        }
        if (Nsetio.segundo == 4)
        {
            texto2.text = "-NBA 2K";
        }
        if (Nsetio.segundo == 5)
        {
            texto2.text = "-FIFA";
        }
        if (Nsetio.segundo == 6)
        {
            texto2.text = "-F1";
        }
        if (Nsetio.segundo == 7)
        {
            texto2.text = "-Age Of Empires";
        }
        if (Nsetio.segundo == 8)
        {
            texto2.text = "-Final Fantasy";
        }
        if (Nsetio.segundo == 9)
        {
            texto2.text = "-Dark Souls";
        }
        if (Nsetio.segundo == 10)
        {
            texto2.text = "-Need For Speed";
        }
        if (Nsetio.segundo == 11)
        {
            texto2.text = "-Grand Theft Auto";
        }
        if (Nsetio.segundo == 12)
        {
            texto2.text = "-Portal";
        }
        if (Nsetio.segundo == 13)
        {
            texto2.text = "-Assassin's Creed";
        }
        if (Nsetio.segundo == 14)
        {
            texto2.text = "-Bioshock";
        }
        if (Nsetio.segundo == 15)
        {
            texto2.text = "-Undertale";
        }
        if (Nsetio.segundo == 16)
        {
            texto2.text = "-Fallout";
        }
        if (Nsetio.segundo == 17)
        {
            texto2.text = "-Dragon Age";
        }
        if (Nsetio.segundo == 18)
        {
            texto2.text = "-Devil May Cry";
        }
        if (Nsetio.segundo == 19)
        {
            texto2.text = "-Diablo";
        }
        if (Nsetio.segundo == 20)
        {
            texto2.text = "-World Of Warcraft";
        }
        if (Nsetio.segundo == 21)
        {
            texto2.text = "-Call Of Duty";
        }
        if (Nsetio.segundo == 22)
        {
            texto2.text = "-Destiny";
        }
        if (Nsetio.segundo == 23)
        {
            texto2.text = "-Bloodborne";
        }
        if (Nsetio.segundo == 24)
        {
            texto2.text = "-Unravel";
        }
        if (Nsetio.segundo == 25)
        {
            texto2.text = "-Battlefield";
        }
        if (Nsetio.segundo == 26)
        {
            texto2.text = "-Rainbow Six";
        }
        if (Nsetio.segundo == 27)
        {
            texto2.text = "-Spiderman";
        }
        if (Nsetio.segundo == 28)
        {
            texto2.text = "-Forza Horizon";
        }
        if (Nsetio.segundo == 29)
        {
            texto2.text = "-No Man's Sky";
        }
        if (Nsetio.segundo == 30)
        {
            texto2.text = "-Nier Automata";
        }
        if (Nsetio.segundo == 31)
        {
            texto2.text = "-The Witcher";
        }
        if (Nsetio.segundo == 32)
        {
            texto2.text = "-Kingdom Hearts";
        }
        if (Nsetio.segundo == 33)
        {
            texto2.text = "-God Of War";
        }
        if (Nsetio.segundo == 34)
        {
            texto2.text = "-Red Dead Redemption";
        }
        if (Nsetio.segundo == 35)
        {
            texto2.text = "-Fortnite";
        }



        if (Nsetio.tercero == 1)
        {
            texto3.text = "-Counter Strike";
        }
        if (Nsetio.tercero == 2)
        {
            texto3.text = "-Minecraft";
        }
        if (Nsetio.tercero == 3)
        {
            texto3.text = "-League Of Legends";
        }
        if (Nsetio.tercero == 4)
        {
            texto3.text = "-NBA 2K";
        }
        if (Nsetio.tercero == 5)
        {
            texto3.text = "-FIFA";
        }
        if (Nsetio.tercero == 6)
        {
            texto3.text = "-F1";
        }
        if (Nsetio.tercero == 7)
        {
            texto3.text = "-Age Of Empires";
        }
        if (Nsetio.tercero == 8)
        {
            texto3.text = "-Final Fantasy";
        }
        if (Nsetio.tercero == 9)
        {
            texto3.text = "-Dark Souls";
        }
        if (Nsetio.tercero == 10)
        {
            texto3.text = "-Need For Speed";
        }
        if (Nsetio.tercero == 11)
        {
            texto3.text = "-Grand Theft Auto";
        }
        if (Nsetio.tercero == 12)
        {
            texto3.text = "-Portal";
        }
        if (Nsetio.tercero == 13)
        {
            texto3.text = "-Assassin's Creed";
        }
        if (Nsetio.tercero == 14)
        {
            texto3.text = "-Bioshock";
        }
        if (Nsetio.tercero == 15)
        {
            texto3.text = "-Undertale";
        }
        if (Nsetio.tercero == 16)
        {
            texto3.text = "-Fallout";
        }
        if (Nsetio.tercero == 17)
        {
            texto3.text = "-Dragon Age";
        }
        if (Nsetio.tercero == 18)
        {
            texto3.text = "-Devil May Cry";
        }
        if (Nsetio.tercero == 19)
        {
            texto3.text = "-Diablo";
        }
        if (Nsetio.tercero == 20)
        {
            texto3.text = "-World Of Warcraft";
        }
        if (Nsetio.tercero == 21)
        {
            texto3.text = "-Call Of Duty";
        }
        if (Nsetio.tercero == 22)
        {
            texto3.text = "-Destiny";
        }
        if (Nsetio.tercero == 23)
        {
            texto3.text = "-Bloodborne";
        }
        if (Nsetio.tercero == 24)
        {
            texto3.text = "-Unravel";
        }
        if (Nsetio.tercero == 25)
        {
            texto3.text = "-Battlefield";
        }
        if (Nsetio.tercero == 26)
        {
            texto3.text = "-Rainbow Six";
        }
        if (Nsetio.tercero == 27)
        {
            texto3.text = "-Spiderman";
        }
        if (Nsetio.tercero == 28)
        {
            texto3.text = "-Forza Horizon";
        }
        if (Nsetio.tercero == 29)
        {
            texto3.text = "-No Man's Sky";
        }
        if (Nsetio.tercero == 30)
        {
            texto3.text = "-Nier Automata";
        }
        if (Nsetio.tercero == 31)
        {
            texto3.text = "-The Witcher";
        }
        if (Nsetio.tercero == 32)
        {
            texto3.text = "-Kingdom Hearts";
        }
        if (Nsetio.tercero == 33)
        {
            texto3.text = "-God Of War";
        }
        if (Nsetio.tercero == 34)
        {
            texto3.text = "-Red Dead Redemption";
        }
        if (Nsetio.tercero == 35)
        {
            texto3.text = "-Fortnite";
        }









    }
}
