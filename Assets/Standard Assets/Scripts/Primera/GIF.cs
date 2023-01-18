using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GIF : MonoBehaviour {

    public Texture2D[] frames;
    public float fps = 10;

    void Update()
    {
        int index = (int)(Time.time * fps) % frames.Length;
        GetComponent<RawImage>().texture = frames[index];
    }
}
