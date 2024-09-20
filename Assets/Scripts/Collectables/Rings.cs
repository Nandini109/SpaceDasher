using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rings : MonoBehaviour
{
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        RingsCount ringsCount = other.GetComponent<RingsCount>();

        if(ringsCount != null )
        {
            ringsCount.RingsCollected();
            audioManager.PlaySFX(audioManager.coin);
            gameObject.SetActive(false);
        }
    }
}
