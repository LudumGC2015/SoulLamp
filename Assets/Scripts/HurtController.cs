using UnityEngine;
using System.Collections;

public class HurtController : MonoBehaviour {

    private AudioSource audioSource;
    private Transform transform;
    private Rigidbody2D rigidBody;
    private SoulCollector soulCollector;
    private PlayerMovement playerMovement;
    private bool invulnerable;
    public float timer;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy" && !invulnerable)
        {
            soulCollector.ChangeSouls(-1);
            audioSource.Play();
            rigidBody.velocity = new Vector2(0f, 0f);
            rigidBody.AddForce(new Vector2(-8f*transform.right.x, 10f) * 20 * Time.deltaTime, ForceMode2D.Impulse);
            invulnerable = true;
            playerMovement.invulnerable = true;
            timer = 1.0f;
        }
    }

	void Start () {
        audioSource = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        transform = GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();
        soulCollector = GetComponent<SoulCollector>();
        invulnerable = false;
        playerMovement.invulnerable = false;
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            invulnerable = false;
            playerMovement.invulnerable = false;
        }
	}
}
