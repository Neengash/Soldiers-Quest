using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_kills : MonoBehaviour
{
    Text killsText;

    void Start()
    {
        killsText = GetComponent<Text>();
    }

    void Update()
    {
        killsText.text = HeroGameController.enemiesKilled.ToString();
    }
}
