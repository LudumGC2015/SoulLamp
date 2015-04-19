using UnityEngine;
using System.Collections;

public class JumpAudioSourceController : MonoBehaviour {
    private AudioSource audioSource;

	void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    public void PlayJumpSound()
    {
        GetComponent<AudioSource>().Play();
    }
}
