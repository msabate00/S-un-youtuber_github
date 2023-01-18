using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMngr : MonoBehaviour
{
    public int nSalud = 100;
    public int Score = 0;
    public int nEnemiesKilled = 0;
    public static int numerogayarma = 1;
    public TextMeshProUGUI munact;
    public TextMeshProUGUI muntot;
    public static int balasact;
    public static int balastot;

    [Space(5)]
    public int numLevels = 2;   // Niveles totales del juego.
    public int currentLevel = 1;
    private int baseLevel = 5; // Nivel Base para oider calcular la escena a cargar.

    [Space(5)]
    public float volumen = 1f;
    public float sensibilidad = 1f;

    #region Singleton
    public static GameMngr Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion
    
    void Update()
    {
        numerogayarma = DisparoSelectivo.NumeroArmagay;
    
    }

    public void LoadLevel(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void LoadCurrentLevel()
    {
        LoadLevel(baseLevel + currentLevel);
    }

    public bool IsLastLevel()
    {
        return currentLevel == numLevels;
    }

    public bool IsGameFinished()
    {
        return currentLevel > numLevels;
    }

    // Cargamos la escena de final de nivel.
    public void LoadGameOverScene()
    {
        LoadLevel(3);
    }

    // Cargamos la escena de final de nivel.
    public void LoadFinishLevelScene()
    {
        LoadLevel(4);
    }

    // Cargamos la escena de final de juego.
    public void LoadFinishGameScene()
    {
        LoadLevel(5);
    }

    public void ActualizarVolumen()
    {
     //   AudioListener.volume = volumen;
    }

    //=======================================================================================================
    //
    //
    //=======================================================================================================
    public void LoadCubiclandData()
    {
        nSalud = PlayerPrefs.GetInt("Salud", 100);
        Score = PlayerPrefs.GetInt("Score", 0);
        nEnemiesKilled = PlayerPrefs.GetInt("NumKills", 0);
        currentLevel = PlayerPrefs.GetInt("Level", 1);

        volumen = PlayerPrefs.GetFloat("Volumen", 1f);
        sensibilidad = PlayerPrefs.GetFloat("Sensibilidad", 1f);
    }

    public void SaveCubiclandData()
    {
        PlayerPrefs.SetInt("Salud", nSalud);
        PlayerPrefs.SetInt("Score", Score);
        PlayerPrefs.SetInt("NumKills", nEnemiesKilled);
        PlayerPrefs.SetInt("Level", currentLevel);

        PlayerPrefs.SetFloat("Volumen", volumen);
        PlayerPrefs.SetFloat("Sensibilidad", sensibilidad);
    }

    public void ResetCubiclandData()
    {
        nSalud = 100;
        Score = 0;
        nEnemiesKilled = 0;
        currentLevel = 1;
        
        // Ajustes del juego.
        volumen = 1f;
        sensibilidad = 1f;

        ActualizarVolumen();
        PlayerPrefs.DeleteAll();
    }

    //=======================================================================================================


    void Start()
    {
        LoadCubiclandData();
        ActualizarVolumen();
        DontDestroyOnLoad (this);
    }

}