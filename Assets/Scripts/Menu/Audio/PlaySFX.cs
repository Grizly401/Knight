using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySFX : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip Clip;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void EventSound()
    {
        _audioSource.PlayOneShot(Clip);
    }
}
