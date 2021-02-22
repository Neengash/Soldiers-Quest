using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSingleton : MonoBehaviour
{
    static BackgroundSingleton background;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (background == null) {
            background = this;
        } else if (background != this) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
