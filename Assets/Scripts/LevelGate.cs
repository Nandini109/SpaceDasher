using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class LevelGate : MonoBehaviour
{
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            //win menu activate
            Time.timeScale = 0f;
            MenuManager.Instance.ShowWinMenu();

            //win sound
            audioManager.PlaySFX(audioManager.win, 1);
        }

    }
}
