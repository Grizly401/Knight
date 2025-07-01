using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public virtual void StopGame(bool Stop)
    {
       /* if (Stop)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;*/
    }

    public virtual void LoadScene(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    public virtual void ActiveMenu(GameObject menu)
    {
        menu.SetActive(true);
    }

    public virtual void DisableMenu(GameObject menu)
    {
        menu.SetActive(false);
    }

    public virtual void GameQuit()
    {
        Application.Quit();
    }

    public virtual void PlayAudioKnock()
    {
        AudioManager.Instance.PlaySFX("Knock");
    }

    public void SaveValue()
    {
        PlayerPrefs.Save();
    }

    public void StartActualLevel()
    {
        if (PlayerPrefs.GetInt("UnlockedLevel") == 0)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("UnlockedLevel"));
        }

    }

    /*public void ToggleMusic(bool sound)
    {
        if (sound)
            _audioMixer.audioMixer.SetFloat("MasterVolume", 0);
        else
            _audioMixer.audioMixer.SetFloat("MasterVolume", -80);
    }

    public virtual void ChangeMasterVolume(float voluem)
    {
        _audioMixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, voluem));
    }
    public virtual void ChangeEffectVolume(float voluem)
    {
        _audioMixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, voluem));

    }
    public virtual void ChangeMusicVolume(float voluem)
    {
        _audioMixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, voluem));
    }*/
}
