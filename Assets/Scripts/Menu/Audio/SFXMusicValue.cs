using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXMusicValue : MonoBehaviour
{
    private Slider _slider;

    void Start()
    {
        _slider = GetComponent<Slider>();

        _slider.value = 0.5f;

        if(PlayerPrefs.HasKey("SFX"))
            _slider.value = PlayerPrefs.GetFloat("SFX");

        SetSound();
    }


    private void SetSound()
    {
        PlayerPrefs.SetFloat("SFX", _slider.value);
        PlayerPrefs.Save();
    }


}
