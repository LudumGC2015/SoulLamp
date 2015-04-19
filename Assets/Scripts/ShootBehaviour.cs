using UnityEngine;
using System.Collections;

public class ShootBehaviour : MonoBehaviour {

    private Object bullet;

	// Use this for initialization
	void Start () {
        bullet = Resources.Load("Prefabs/NormalBullet");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Shoot();
        }
	}

    void Shoot() {
        GameObject bul = Instantiate(bullet, transform.position, Quaternion.Euler(0f, transform.eulerAngles.y, 0f)) as GameObject;
        Debug.Log(gameObject);
        Physics2D.IgnoreCollision(bul.GetComponent<Collider2D>(), transform.parent.GetComponent<Collider2D>());
    }
}
