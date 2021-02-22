using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    int maxLvlCleared = 0;
    string lvlKey = "lvl";

    void Start()
    {
        maxLvlCleared = PlayerPrefs.GetInt(lvlKey, 0);
    }

    public bool HasSavedGame()
    {
        return maxLvlCleared > 0;
    }

    public void ResetGame()
    {
        maxLvlCleared = 0;
        SaveGame();
    }

    void SaveGame()
    {
        PlayerPrefs.SetInt(lvlKey, maxLvlCleared);
    }

    public int GetMaxLvl()
    {
        return maxLvlCleared;
    }

    public void IncrementMaxLvl()
    {
        maxLvlCleared++;
        SaveGame();
    }
}
