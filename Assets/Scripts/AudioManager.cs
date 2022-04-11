using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlaySfx(AudioClip sound, float volume = 1)
    {
        sfxSource.PlayOneShot(sound, volume);
    }

    public void PlayMusic(AudioClip sound, float volume = 1)
    {
        musicSource.clip = sound;
        musicSource.Play();
    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }
}
