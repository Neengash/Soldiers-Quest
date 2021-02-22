using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeColorDynamic : MonoBehaviour
{
    TextMeshPro textMesh;

    float red = 0.87f;
    float green = 0.87f;
    float blue = 0.77f;

    float colorChange = - 0.01f;

    float minBlue = 0.40f;
    float maxBlue = 0.90f;

    void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
        AssignColor();
    }

    void Update()
    {
        UpdateColor();
        CheckDirection();
    }

    void AssignColor()
    {
        textMesh.color = new Color(red, green, blue);
    }

    void UpdateColor()
    {
        red += colorChange;
        green += colorChange;
        blue += colorChange;

        AssignColor();
    }

    void CheckDirection()
    {
        if (
            (colorChange < 0 && blue < minBlue) ||
            (colorChange > 0 && blue > maxBlue)
        ) {
            colorChange *= -1;
        }
    }
}
