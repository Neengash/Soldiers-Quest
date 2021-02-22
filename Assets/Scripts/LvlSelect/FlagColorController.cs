using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagColorController : MonoBehaviour
{
    [SerializeField] Animator[] flags;

    ScoreController score;

    const string key = "Color";
    const int BLACK = 0;
    const int RED = 1;
    const int GREEN = 2;

    void Start()
    {
        score = FindObjectOfType<ScoreController>();

        int baseColor = GREEN;
        for (int i = 0; i < flags.Length; i++)
        {
            if (i == score.GetMaxLvl()) {
                flags[i].SetInteger(key, RED);
                baseColor = BLACK;
            } else {
                flags[i].SetInteger(key, baseColor);
            }
        }
    }

}
