using TMPro;
using UnityEngine;

public class HintTrigger : MonoBehaviour
{

    [SerializeField] TextMeshPro hintText;

    float r, g, b;
    float aVariation;

    const float FADE_SPEED = 0.04f;
    const float MAX_VALUE = 1;
    const float MIN_VALUE = 0;

    private void Start()
    {
        r = hintText.color.r;
        g = hintText.color.g;
        b = hintText.color.b;
    }

    private void Update()
    {
        if (aVariation != 0f) {
            float a = hintText.color.a;
            a += aVariation;
            if (a >= MAX_VALUE) {
                a = MAX_VALUE;
                aVariation = 0;
            } else if (a <= MIN_VALUE) {
                a = MIN_VALUE;
                aVariation = 0;
            }
            hintText.color = new Color(r, g, b, a);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == Layers.HERO) {
            FadeIn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == Layers.HERO) {
            FadeOut();
        }
    }

    private void FadeIn()
    {
        aVariation = FADE_SPEED;
    }

    private void FadeOut()
    {
        aVariation = -1 * FADE_SPEED;
    }

}
