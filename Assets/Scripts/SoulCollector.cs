using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoulCollector : MonoBehaviour {

    public int initialSouls = 3;

    private int currentSouls;
    
    public void Start() {
        currentSouls = initialSouls;
    }

    public void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy") {
            currentSouls--;
        } else if (other.gameObject.tag == "Soul") {
            currentSouls++;
        }
    }


    public void substractSouls(int numberOfSouls) {
        currentSouls -= numberOfSouls;
    }

    public int GetCurrentSouls() {
        return currentSouls;
    }
}
