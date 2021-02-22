using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlClear : MonoBehaviour
{
    GameClearController gameClear;
    AudioSource audioSource;
    [SerializeField] AudioClip successSound;

    private void Start()
    {
        gameClear = FindObjectOfType<GameClearController>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == Layers.HERO) {
            audioSource.PlayOneShot(successSound);
            gameClear.GameClear();
        }
    }
}
