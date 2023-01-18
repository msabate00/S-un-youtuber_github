using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class editadorshader : MonoBehaviour {

	private PostProcessVolume _postProcessVolume;
    private Vignette vg;

	private void Start()
    {
        _postProcessVolume = GetComponent<PostProcessVolume>();
        _postProcessVolume.profile.TryGetSettings(out vg);
        
    }
}
