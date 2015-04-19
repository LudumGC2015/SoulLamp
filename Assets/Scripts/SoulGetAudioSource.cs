using UnityEngine;
using System.Collections;

public class SoulGetAudioSource : MonoBehaviour {

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	public void PlayGetSoul() {
        audioSource.Play();
	}
}
