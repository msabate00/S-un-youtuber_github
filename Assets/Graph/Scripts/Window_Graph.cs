/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using TMPro;

public class Window_Graph : MonoBehaviour {

    private RectTransform graphContainer;
    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY;
    private RectTransform dashY;
    private RectTransform dashX;
    private GameObject puntogay;
    public bool prueba = false;
    public static List<float> listagay = new List<float>() { 5, 300, 56, 45, 30, 22, 17, 15, 13, 17, 25, 37, 40, 36, 33 };
    public int tipo = 1;

    private void OnEnable() {
        
        
        GameObject[] polla = GameObject.FindGameObjectsWithTag("graficos");

        foreach (GameObject lel in polla)
        {
            Destroy(lel);
        }

        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        dashX = graphContainer.Find("dashX").GetComponent<RectTransform>();
        dashY = graphContainer.Find("dashY").GetComponent<RectTransform>();
        puntogay = graphContainer.Find("Circulogay").gameObject;

        while (Controlador.listadinero.Count > 7)
        {
            Controlador.listadinero.RemoveAt(0);
        }
        while (listagay.Count > 7)
        {
            listagay.RemoveAt(0);
        }
        if (prueba) { ShowGraph(listagay); }
        else {
            if (tipo == 1 || tipo == 2) { ShowGraph(Controlador.listadinero); }
            else if (tipo == 3) { ShowGraph(Controlador.calidadvideos); }

        }
        
    }

    private GameObject CreateCircle(Vector2 anchoredPosition, float pene, int num) {
        GameObject gameObject = Instantiate(puntogay);
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.tag = "graficos";
        gameObject.SetActive(true);
        // gameObject.GetComponent<Image>().sprite = circleSprite;
       
        if (prueba || tipo == 1)
        {
            gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = pene.ToString("F2") + "€";
        }
        
        else if (tipo == 2){ gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = pene.ToString(); }
        else if (tipo == 3) { lenguaje(gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>(),num); }

        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
      //  rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    private void ShowGraph(List<float> valueList) {
        float graphHeight = graphContainer.sizeDelta.y;
       // float yMaximum = 160f;
        float xSize = 50f;

        float max = 0;
        if (prueba) {max = Mathf.Max(listagay.ToArray()); }
        else
        {
            if (tipo == 1) { max = Mathf.Max(Controlador.listadinero.ToArray()); }
            else if (tipo == 2) { max = Mathf.Max(Controlador.suscribersgays.ToArray()); }
            else if (tipo == 3) { max = Mathf.Max(Controlador.calidadvideos.ToArray()); }

        }
       
        float fact = 170 / max;

        GameObject lastCircleGameObject = null;
        for (int i = 0; i < valueList.Count; i++) {
            float xPosition = xSize + i * xSize;
            //    float yPosition = (valueList[i] / yMaximum) * graphHeight;
            float ypos = 0;
            if (prueba) { ypos = 0; ypos = ypos + valueList[i] * fact; }
            else
            {
                if (tipo == 1) { ypos = 0; ypos = ypos + Controlador.listadinero[i] * fact; }
                else if (tipo == 2) { ypos = 0; ypos = ypos + Controlador.suscribersgays[i] * fact; }
                else if (tipo == 3) { ypos = 0; ypos = ypos + Controlador.calidadvideos[i] * fact; }
            }

            GameObject circleGameObject = null; 
            if (prueba) { circleGameObject = CreateCircle(new Vector2(xPosition, ypos), valueList[i], i); }
            else
            {
                if (tipo == 1) { circleGameObject = CreateCircle(new Vector2(xPosition, ypos), Controlador.listadinero[i], i); }
                else if (tipo == 2) { circleGameObject = CreateCircle(new Vector2(xPosition, ypos), Controlador.suscribersgays[i], i); }
                else if (tipo == 3) { circleGameObject = CreateCircle(new Vector2(xPosition, ypos), Controlador.calidadvideos[i], i); }
            }
          

            if (lastCircleGameObject != null) {
                CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastCircleGameObject = circleGameObject;

            RectTransform labelX = Instantiate(labelTemplateX);
            labelX.tag = "graficos";
            labelX.SetParent(graphContainer, false);
            labelX.gameObject.SetActive(true);
            labelX.anchoredPosition = new Vector2(xPosition, -7f);
            if (prueba) { labelX.GetComponent<TextMeshProUGUI>().text = i.ToString(); }
            else
            {
                if (tipo != 3) { labelX.GetComponent<TextMeshProUGUI>().text = Controlador.semanas[i].ToString(); }
                else
                {
                    labelX.GetComponent<TextMeshProUGUI>().text = Controlador.videos[i];
                }
                
            }
            

            RectTransform dashYgay = Instantiate(dashY);
            dashYgay.tag = "graficos";
            dashYgay.SetParent(graphContainer.GetChild(6), false);
            dashYgay.gameObject.SetActive(true);
            dashYgay.anchoredPosition = new Vector2(xPosition, -4f);

        }
        int sep = 10;
        for (int i = 9; i> -1; i--)
        {
            float facgay = 1.88f;
            RectTransform labelY = Instantiate(labelTemplateY);
            labelY.SetParent(graphContainer, false);
            labelY.tag = "graficos";
            labelY.gameObject.SetActive(true);
            float puto = i * 1f / sep;
            labelY.anchoredPosition = new Vector2(18f, puto * graphHeight * facgay);
            float ah = max * (i+1) / 10;
            if (tipo == 3) { ah = ah * 100 / 40; }
            if (tipo != 3) { labelY.GetComponent<TextMeshProUGUI>().text = Mathf.RoundToInt(ah).ToString(); }
            else
            {
                labelY.GetComponent<TextMeshProUGUI>().text = Mathf.RoundToInt(ah).ToString() + "%";
            }

            RectTransform dashXgay = Instantiate(dashX);
            dashXgay.SetParent(graphContainer.GetChild(6), false);
            dashXgay.tag = "graficos";
            dashXgay.gameObject.SetActive(true);
            dashXgay.anchoredPosition = new Vector2(22f, puto * graphHeight * facgay);

        }
    }

    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB) {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer.GetChild(7), false);
        gameObject.tag = "graficos";
        gameObject.GetComponent<Image>().color = new Color(0,0,1, .5f);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);        
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(dir));
        rectTransform.localScale = new Vector3(1, 0.5f, 1);

    }
    void lenguaje(TextMeshProUGUI lol, int i)
    {
        if (Controlador.calidadvideos[i] >= 0 && Controlador.calidadvideos[i] <= 10)
        {
           lol.text = "F";
        }

        if (Controlador.calidadvideos[i] >= 11 && Controlador.calidadvideos[i] <= 14)
        {
            lol.text = "D";
        }

        if (Controlador.calidadvideos[i] >= 15 && Controlador.calidadvideos[i] <= 18)
        {
            lol.text = "D+";
        }

        if (Controlador.calidadvideos[i] >= 19 && Controlador.calidadvideos[i] <= 22)
        {
            lol.text = "C";
        }

        if (Controlador.calidadvideos[i]  >= 23 && Controlador.calidadvideos[i] <= 25)
        {
            lol.text = "C+";
        }

        if (Controlador.calidadvideos[i] >= 26 && Controlador.calidadvideos[i] <= 29)
        {
            lol.text = "B";
        }

        if (Controlador.calidadvideos[i] >= 30 && Controlador.calidadvideos[i] <= 33)
        {
            lol.text = "B+";
        }

        if (Controlador.calidadvideos[i] >= 34 && Controlador.calidadvideos[i] <= 37)
        {
            lol.text = "A";
        }

        if (Controlador.calidadvideos[i] >= 38 && Controlador.calidadvideos[i] <= 40)
        {
            lol.text = "A+";
        }
    }

}
