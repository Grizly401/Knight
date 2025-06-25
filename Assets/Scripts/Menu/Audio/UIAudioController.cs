using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class UIAudioController : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private Slider _sliderMusic, _sliderSFX;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume") || PlayerPrefs.HasKey("SFXVolume"))
            LoadVolume();
        else
        {
            SetSFXVolume();
            SetMusicVolume();
        }
    }

    public void SetMusicVolume()
    {
        float volume = _sliderMusic.value;
        _mixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void SetSFXVolume()
    {
        float volume = _sliderSFX.value;
        _mixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadVolume()
    {
        _sliderMusic.value = PlayerPrefs.GetFloat("musicVolume");
        _sliderSFX.value = PlayerPrefs.GetFloat("SFXVolume");

        SetMusicVolume();
        SetSFXVolume();
    }
    /* public void ToggleMusic()
     {
         AudioManager.Instance.ToggleMusic();
     }

     public void ToggleSFX()
     {
         AudioManager.Instance.ToggleSFX();
     }

     public void MusicVolume()
     {
         AudioManager.Instance.SetMusicVolume();
     }
     public void SFXVolume()
     {
         AudioManager.Instance.SetSFXVolume();
     }*/

}
