using UnityEngine;
using System.Collections;

public class SoulLinkAudioController : MonoBehaviour {

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoulLink()
    {
        audioSource.Play();
    }

    public void StopSoulLink()
    {
        audioSource.Stop();
    }
}
