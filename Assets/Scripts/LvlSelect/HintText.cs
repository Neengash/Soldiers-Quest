using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintText : MonoBehaviour
{
    TextMeshPro text;

    float r, g, b;

    const float INVISIBLE = 0f;
    const float MAX_VISIBLE = 1f;

    float fadeSpeed;
    const float STOP = 0f;
    const float FADE_IN = 0.05f;
    const float FADE_OUT = -0.05f;

    void Start()
    {
        text = GetComponent<TextMeshPro>();

        r = text.color.r;
        g = text.color.g;
        b = text.color.b;

        text.color = new Color(r, g, b, INVISIBLE);

        fadeSpeed = STOP;
    }

    void Update()
    {
        if (fadeSpeed != STOP)
        {
            float a = text.color.a;
            a += fadeSpeed;
            if (a > MAX_VISIBLE) { 
                a = MAX_VISIBLE;
                fadeSpeed = STOP;
                StartCoroutine(FadeOut());
            }
            if (a < INVISIBLE)
            {
                a = INVISIBLE;
            }
            text.color = new Color(r, g, b, a);
        }
    }

    public void FadeIn()
    {
        fadeSpeed = FADE_IN;
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1f);

        if (fadeSpeed == STOP)
        {
            fadeSpeed = FADE_OUT;
        }
    }
}
