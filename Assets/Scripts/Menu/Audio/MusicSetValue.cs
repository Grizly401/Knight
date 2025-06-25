using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSetValu : MonoBehaviour
{
    private AudioSource _sound;

    // Start is called before the first frame update
    void Start()
    {
        _sound = GetComponent<AudioSource>();

        if(PlayerPrefs.HasKey("Music"))
            _sound.volume = PlayerPrefs.GetFloat("Music");
    }

    private void SetSound()
    {
        PlayerPrefs.SetFloat("Music", _sound.volume);
        PlayerPrefs.Save();
    }
}
