using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_DoubleJumps : MonoBehaviour
{
    Text doubleJumpText;

    void Start()
    {
        doubleJumpText = GetComponent<Text>();
    }

    void Update()
    {
        doubleJumpText.text = HeroGameController.doubleJumpsAvailable.ToString();  
    }
}
