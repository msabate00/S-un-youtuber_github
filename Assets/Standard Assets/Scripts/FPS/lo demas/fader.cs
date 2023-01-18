using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fader : MonoBehaviour
{

	
     [SerializeField]
    private AnimationCurve fadeCurve;
    Renderer _renderer;
    Color _color;
    private float _timer = 1f;
    public float ahorita;
    private float vengaostia;
    public GameObject sexual;
    public string penis;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _color = _renderer.material.color;
    }

    private void Update()
    {
        vengaostia += Time.deltaTime;
        if (vengaostia > ahorita)
        {
            _timer -= Time.deltaTime * 0.4f;
            _color.a = fadeCurve.Evaluate(_timer);
            _renderer.material.color = _color;
        }
    }

    public void lol(GameObject sex)
    {
        sexual = sex;
        penis = sex.name;
    }
}