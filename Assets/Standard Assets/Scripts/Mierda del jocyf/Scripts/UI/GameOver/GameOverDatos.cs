using UnityEngine;
using TMPro;

public class GameOverDatos : MonoBehaviour {

    public enum GameOverTypeData { Puntos = 0, Enemigos = 1 }
    public GameOverTypeData gameOverTypeData = GameOverTypeData.Puntos;

    //[Tooltip("Es este GUIText el Score o s el mnumero de enemigos que hemos matado?")]
    //public bool isScore = true;


    private TextMeshProUGUI myTextMeshPro;

    void Start ()
    {
        myTextMeshPro = GetComponent<TextMeshProUGUI>();
        ActualizarDatos();
    }
	
	
	public void ActualizarDatos ()
    {
        /*if(isScore)
            myTextMeshPro.text = "PUNTOS: " + GameMngr.Instance.Score.ToString();
        else
            myTextMeshPro.text = "ENEMIGOS: " + GameMngr.Instance.nEnemiesKilled.ToString();*/

        //myTextMeshPro.text = isScore ? "PUNTOS: " + GameMngr.Instance.Score.ToString() : "ENEMIGOS: " + GameMngr.Instance.nEnemiesKilled.ToString();

        switch (gameOverTypeData)
        {
            case GameOverTypeData.Puntos:
                myTextMeshPro.text = "PUNTOS: " + GameMngr.Instance.Score.ToString();
                break;
            case GameOverTypeData.Enemigos:
                myTextMeshPro.text = "ENEMIGOS: " + GameMngr.Instance.nEnemiesKilled.ToString();
                break;
        }
    }
}
