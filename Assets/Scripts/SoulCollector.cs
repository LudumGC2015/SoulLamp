﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoulCollector : MonoBehaviour
{   
    private SoulGetAudioSource sGAS;
    private int currentSouls = 10;
    public Text soulCounter;
    private Rigidbody2D rigidBody;

    void Start() 
    {
        sGAS = GetComponentInChildren<SoulGetAudioSource>();
        soulCounter.text = "Souls: " + currentSouls;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Soul")
        {
            ChangeSouls(1);
            sGAS.PlayGetSoul();
            Destroy(other.gameObject);
        }
    }

    public void ChangeSouls(int amount)
    {
        currentSouls += amount;
        soulCounter.text = "Souls: " + currentSouls;
    }
}
