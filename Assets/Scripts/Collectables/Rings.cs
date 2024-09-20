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
            //collecting rings and making them disappear
            ringsCount.RingsCollected();
            gameObject.SetActive(false);

            //ring music
            audioManager.PlaySFX(audioManager.coin, 5);
            
        }
    }
}
