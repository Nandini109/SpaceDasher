using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource gameAudio;
    [SerializeField] AudioSource backgroundMusic;

    public AudioClip engine;
    public AudioClip fireEngine;
    public AudioClip speedBoost;
    public AudioClip speedSlow;
    public AudioClip win;
    public AudioClip die;
    public AudioClip background;
    public AudioClip coin;

    private void Start()
    {
        backgroundMusic.clip = background;
        backgroundMusic.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        gameAudio.PlayOneShot(clip);
    }
}
