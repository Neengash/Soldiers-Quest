using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LvlInteractions : MonoBehaviour
{

    [SerializeField] TextMeshPro lvlInfo;
    LevelSelectController mainController;

    float fadeSpeed;
    float r, g, b;
    const float STOPPED = 0;
    const float FADE_IN = 0.05f;
    const float FADE_OUT = -0.05f;


    private void Start()
    {
        mainController = FindObjectOfType<LevelSelectController>();

        fadeSpeed = STOPPED;
        r = lvlInfo.color.r;
        g = lvlInfo.color.g;
        b = lvlInfo.color.b;
        lvlInfo.color = new Color(r, g, b, 0f);
    }

    private void Update()
    {
        if (fadeSpeed != STOPPED)
        {
            float a = lvlInfo.color.a;
            a += fadeSpeed;
            if (a > 1) { a = 1f; fadeSpeed = STOPPED; }
            if (a < 0) { a = 0f; fadeSpeed = STOPPED; }
            lvlInfo.color = new Color(r, g, b, a);
        }
   }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        mainController.Stop();
        fadeSpeed = FADE_IN;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        fadeSpeed = FADE_OUT;
    }
}
