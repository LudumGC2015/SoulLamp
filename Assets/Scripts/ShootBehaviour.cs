using UnityEngine;
using System.Collections;

public class ShootBehaviour : MonoBehaviour {

    private Object bullet;
    private AudioSource audioSource;
    public float timer = 0f;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        bullet = Resources.Load("Prefabs/NormalBullet");
	}
	
	// Update is called once per frame
	void Update () {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        } else if (Input.GetKeyDown(KeyCode.Mouse0)) {
            timer = 1f;
            Shoot();
        }
	}

    void Shoot() {
        GameObject bul = Instantiate(bullet, transform.position, Quaternion.Euler(0f, transform.eulerAngles.y, 0f)) as GameObject;
        Debug.Log(gameObject);
        Physics2D.IgnoreCollision(bul.GetComponent<Collider2D>(), transform.parent.GetComponent<Collider2D>());
        audioSource.Play();
    }
}
