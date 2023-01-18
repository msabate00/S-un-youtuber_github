using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadMenu : MonoBehaviour
{
    public float waitTime = 1f;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(waitTime);
        LoadLevel(1);
    }

    public void LoadLevel(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}