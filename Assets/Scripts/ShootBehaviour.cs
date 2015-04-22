using UnityEngine;
using System.Collections;

public class ShootBehaviour : MonoBehaviour {

    private Object bulletPrefab;
    private AudioSource shootSound;
    private SoulCollector soulCollector;
    private float timer = 0f;

    // Use this for initialization 
    void Start() {
        shootSound = GetComponent<AudioSource>();
        soulCollector = GameObject.FindGameObjectWithTag("Player").GetComponent<SoulCollector>();
        bulletPrefab = Resources.Load("Prefabs/NormalBullet");
    }

    // Update is called once per frame
    void Update() {
        if (timer > 0f) {
            timer -= Time.deltaTime;
        } else if (Input.GetKey(KeyCode.Mouse0)) {
            timer = 1f;
            Shoot();
        }
    }

    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0f, transform.eulerAngles.y, 0f)) as GameObject;
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), transform.parent.GetComponent<Collider2D>());
        soulCollector.substractSouls(1);
        shootSound.Play();
    }
}
