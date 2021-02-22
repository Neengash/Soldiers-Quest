using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceeneOnVisible : MonoBehaviour
{
    const int LEVEL_SELECT_SCENE = 1;
    private void OnBecameVisible()
    {
        SceneManager.LoadScene(LEVEL_SELECT_SCENE);
    }
}
