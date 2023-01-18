using UnityEngine;


public class MenuLoadLevel : MonoBehaviour {

	
	public void LoadLevel (int sceneToLoad)
    {
        GameMngr.Instance.LoadLevel(sceneToLoad);
	}

    public void LoadNextLevel()
    {
        GameMngr.Instance.LoadCurrentLevel();
    }

    public void PlayNewGame()
    {
        GameMngr.Instance.ResetCubiclandData();
        LoadNextLevel();
    }

    public void LoadLevelGameOver (int sceneToLoad)
    {
        GameMngr.Instance.nSalud = 100;
        GameMngr.Instance.LoadLevel(sceneToLoad);
    }
}
