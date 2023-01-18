using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class aprincipal : MonoBehaviour
{
    public Text tusmuertos; // ESTO ES UNA PUTA PRUEBA PON UN APPLICATION.LOADLEVEL Y A TOMAR POR CULO TIO SE BUGGEA UN POCO AL CAMBIAR AL PRINCIPAL ASÍ QUE HAZ ESTO TIO 3 SEGUNDOS DE VIDEOS PORNO Y PARÓN DE 0,5 SEGUNDOS PARA CARGAR ESCENA DE MIERDA PUTO UNITY DE LOS COJONES
    public Slider polla;
    public GameObject polla2;
    public GameObject tusmuertos2;
    float pene = 0;
    float penepolla = 0;
    bool jej = false;
    bool jaj = false;
    public GameObject cosas;
    public GameObject cosas2;
    public bool hazbiencosas = true;

    void Start()
    {
        cosas2.SetActive(false);
        cosas.SetActive(false);
        tusmuertos2.SetActive(false);
        polla2.SetActive(true);
    }
   void Update()
    {
        if (jej)
        {
            pene += Time.deltaTime;
            print(pene + " SEGUNDOS GEIS");
        }

        if (jaj)
        {
            cosas2.SetActive(true);
            cosas.SetActive(true);
            penepolla += Time.deltaTime;
            print(pene + " SEGUNDOS INSUFRIBLES");
        }
        if(penepolla >= 5)
        {
            SceneManager.LoadScene("Principal");
            // StartCoroutine(LoadYourAsyncScene()); ACTIVA LA MIERDA ESTA PARA HACER TRANSICIÓN TO WAPA PERO YO PASO TIO
        }



    }    
    void OnMouseDown()
    {
        // Press the space key to start coroutine
        
            // Use a coroutine to load the Scene in the background
            
        if (hazbiencosas)
        {
            StartCoroutine(LoadYourAsyncScene());
            return;
        }
        tusmuertos2.SetActive(true);
        polla2.SetActive(true);
        jej = true;
        jaj = true;
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("menu");
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            polla.value = progress;
            Debug.Log(progress);
            tusmuertos.text = progress * 100f + "% ESTO ES UNA PUTA MIERDA DE SISTEMA";
            yield return null;
        }
    }
}