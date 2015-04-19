using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoulCollector : MonoBehaviour
{
    public bool playerDead;
    private Object dead;
    private SoulGetAudioSource sGAS;
    private int currentSouls = 10;
    public Text soulCounter;
    private Rigidbody2D rigidBody;

    void Start()
    {
        playerDead = false;
        dead = Resources.Load("Prefabs/PlayerDead");
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
        CheckForDeath();
    }

    void CheckForDeath()
    {
        if (currentSouls == 0)
        {
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                enemy.GetComponent<PatrolController>().enabled = false;
            }
            GameObject deadPlayer = Instantiate(dead, transform.position, Quaternion.Euler(0f, transform.eulerAngles.y, 0f)) as GameObject;
            Destroy(gameObject);
        }
    }
}
