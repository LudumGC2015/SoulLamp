using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoulCollector : MonoBehaviour {

    public int initialSouls = 3;

    private int currentSouls;
    private Animator animator;
    private AudioSource deadClip;
    
    public void Start() {
        currentSouls = initialSouls;
        animator = GetComponent<Animator>();
        deadClip = GetComponents<AudioSource>()[2];
    }

    public void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy") {
            currentSouls--;
            CheckDead();
        } else if (other.gameObject.tag == "Soul") {
            currentSouls++;
        }
    }

    private void CheckDead() {
        if (currentSouls == 0) {
            SendMessage("Dead", SendMessageOptions.RequireReceiver);
            animator.SetTrigger("dead");
            deadClip.Play();
        }
    }


    public void substractSouls(int numberOfSouls) {
        currentSouls -= numberOfSouls;
    }

    public int GetCurrentSouls() {
        return currentSouls;
    }
}
