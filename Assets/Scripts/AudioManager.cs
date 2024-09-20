using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource gameAudio;
    [SerializeField] AudioSource backgroundMusic;

    public AudioClip speedBoost;
    public AudioClip speedSlow;
    public AudioClip win;
    public AudioClip die;
    public AudioClip background;
    public AudioClip coin;

    private void Start()
    {
        //background music
        backgroundMusic.clip = background;
        backgroundMusic.Play();
    }

    public void PlaySFX(AudioClip clip, int vol)
    {
        gameAudio.PlayOneShot(clip);
        gameAudio.volume = vol;
    }
}
