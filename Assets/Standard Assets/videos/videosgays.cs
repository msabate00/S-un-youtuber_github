using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class videosgays : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    public VideoClip[] video;
    public AudioSource aud;
    private int current = 0;
    public Coroutine actual;

    void Start()
    {
        StartCoroutine(sexual2());
    }

    IEnumerator sexual2()
    {
        yield return null;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("menu");
        asyncLoad.allowSceneActivation = false;

        for (int i = 0; i < video.Length; i++)
        {
            penisman lol = new penisman(this);

            actual = StartCoroutine(lol.sexual(i));

            while (actual != null)
            {
                if (Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
                {
                    StopCoroutine(actual);
                    actual = null;
                }
                yield return null;
            }
        }

        asyncLoad.allowSceneActivation = true;
    }
}

    public class penisman {

        public videosgays lols;

        public penisman(videosgays script)
        { 
            lols = script;
        }

        public IEnumerator sexual(int i)
        {
            yield return null;
        
            lols.videoPlayer.clip = lols.video[i];
            lols.videoPlayer.Prepare();

            while (!lols.videoPlayer.isPrepared)
            {
                yield return null;
            }


            lols.videoPlayer.Play();
            int actual = (int)lols.videoPlayer.frame;
            int prev = 0;

            while (true)
            {
                prev = actual;

                yield return null;
                actual = (int)lols.videoPlayer.frame;

                if (prev == actual)
                {
                    yield return new WaitForSeconds(0.05f);
                    actual = (int)lols.videoPlayer.frame;
                    if (prev == actual) { break; }
                }
            }

            lols.actual = null;
        }

    }


