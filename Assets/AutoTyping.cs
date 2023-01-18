using UnityEngine;
using System.Collections;

public class AutoTyping : MonoBehaviour

{
    //public GUIText LOL;
    public int pene = 0;
    string myString = "A la próxima te mando a buscar un lugar donde enterrar a tu puta madre";

    // Use this for initialization
    void OnEnable()
    {
        pene = 0;
        //LOL.text = "";
        StartCoroutine("AutoType");
    }

    void OnDisable()
    {
        pene = 0;        
    }
    // Update is called once per frame
    IEnumerator AutoType()
    {
        foreach (char letter in myString.ToCharArray())
        {
            //LOL.text += letter; //for unity 5x
                                                    // guiText.text += letter;  // for unity 4x
            yield return new WaitForSeconds (0.016f);
            pene += 1;
            if (pene == 1)
            {
                Debug.Log("Desactivar el desactivador, que irónico");
            }
            if (pene == 70)
            {
                Debug.Log("Activar el desactivador, que irónico");
            }
        }
    }
}