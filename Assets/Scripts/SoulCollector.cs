using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoulCollector : MonoBehaviour
{
    private int currentSouls = 10;
    public Text soulCounter;
    public Rigidbody2D rigidBody;

    void Start()
    {   
        soulCounter.text = "Souls: " + currentSouls;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            ChangeSouls(-1);
            rigidBody.AddForce(new Vector2(-1000f, 5f), ForceMode2D.Impulse);
        }

        if (other.gameObject.tag == "Soul")
        {
            ChangeSouls(1);
            Destroy(other.gameObject);
        }
    }

    public void ChangeSouls(int amount)
    {
        currentSouls += amount;
        soulCounter.text = "Souls: " + currentSouls;
    }
}
