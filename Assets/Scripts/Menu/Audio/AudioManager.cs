using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, SFXSounds;
    public AudioSource musicSource, SFXSource;
    //private const string Button;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        /*if(PlayerPrefs.HasKey("musicVolume") || PlayerPrefs.HasKey("SFXVolume"))
            LoadVolume();
        else
        {
            SetSFXVolume();
            SetMusicVolume();
        }*/
    
        PlayMusic("Theme");
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.Name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            musicSource.clip = s.Clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(SFXSounds, x => x.Name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            SFXSource.clip = s.Clip;
            SFXSource.PlayOneShot(s.Clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        SFXSource.mute = !SFXSource.mute;
    }

    



}
