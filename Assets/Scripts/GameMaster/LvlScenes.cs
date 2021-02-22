using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlScenes : MonoBehaviour
{
    // <lvl, scene>
    Dictionary<int, int> lvlScenes = new Dictionary<int, int>() {
        {1, 2},
        {2, 3}
    };

    // <scene, lvl>
    Dictionary<int, int> reverse;

    private void Awake()
    {
        reverse = new Dictionary<int, int>();
        
        foreach (KeyValuePair<int, int> entry in lvlScenes) {
            reverse.Add(entry.Value, entry.Key);
        }
    }

    public int GetLevelScene(int lvl)
    {
        int scene;
        lvlScenes.TryGetValue(lvl, out scene);
        return scene;
    }

    public int GetCurrentLevel()
    {
        int currentLevel = 0;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        reverse.TryGetValue(currentScene, out currentLevel);
        return currentLevel;
    }

    public int GetNextLevelScene()
    {
        int current = GetCurrentLevel();
        current++;
        return GetLevelScene(current);
    }
}
