using UnityEngine;

public class FinalNivelMngr : MonoBehaviour
{

    private bool hasEntered = false;

    void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Contains("Player") || hasEntered) return;

        hasEntered = true;
        EndLevel();

    }

    void OnTriggerStay(Collider other)
    {
        if (!other.tag.Contains("Player") || hasEntered) return;

        hasEntered = true;
        EndLevel();
    }


    private void EndLevel()
    {
        GameMngr.Instance.currentLevel++;
        GameMngr.Instance.SaveCubiclandData();

        if (GameMngr.Instance.IsGameFinished())
        {
            GameMngr.Instance.LoadFinishGameScene();    // Detecta el final de juego y carga escena de creditos (final de juego)
        }
        else
        {
            GameMngr.Instance.LoadFinishLevelScene();   // Carga la escena de final de nivel.
        }
    }

}