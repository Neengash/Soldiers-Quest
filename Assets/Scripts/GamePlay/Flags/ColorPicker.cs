using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    Animator animator;
    ScoreController score;
    LvlScenes lvlScenes;

    const string CLEARED = "cleared";

    void Start()
    {
        animator = GetComponent<Animator>();
        score = FindObjectOfType<ScoreController>();
        lvlScenes = FindObjectOfType<LvlScenes>();

        if (lvlScenes.GetCurrentLevel() <= score.GetMaxLvl()) {
            animator.SetBool(CLEARED, true);
        }
    }
}
