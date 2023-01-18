using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrolldemierda : MonoBehaviour
{
    private Vector3 orig;
    RectTransform yo;
    public Scrollbar sc;

    void Start()
    {
        yo = GetComponent<RectTransform>();
        orig = yo.anchoredPosition3D;
        sc = transform.parent.parent.GetComponentInChildren<Scrollbar>();
    }

    public void mueveteguarra(float val)
    {
        Vector3 pos = orig;
        pos.y = (422 * val) + 458;
        yo.anchoredPosition3D = pos;
    }

    private void Update()
    {
        sc.value -= Input.GetAxis("Mouse ScrollWheel");
        sc.value = Mathf.Clamp(sc.value, 0, 1);
    }
}
