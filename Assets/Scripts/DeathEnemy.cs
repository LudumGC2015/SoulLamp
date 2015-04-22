using UnityEngine;
using System.Collections;

public class DeathEnemy : MonoBehaviour {
    private Rigidbody2D rigidBody;
    private CircleCollider2D circleCollider2D;
    private PatrolController patrolController;
    private Animator animator;
    private AudioSource audioSource;
    Object soulPrefab;

    void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        patrolController = GetComponent<PatrolController>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        soulPrefab = Resources.Load("Prefabs/Soul");
    }

    void Kill()
    {
        rigidBody.isKinematic = true;
        audioSource.Play();
        animator.SetTrigger("IsDead");
        GameObject soul = Instantiate(soulPrefab, transform.position, Quaternion.identity) as GameObject;
        soul.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 400f));
        patrolController.enabled = false;
        circleCollider2D.enabled = false;
        Invoke("DestroySoul", 1);
    }

    void DestroySoul()
    {
        Destroy(gameObject);
    }
}
