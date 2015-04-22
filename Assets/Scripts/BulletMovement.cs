using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {
    public float speed;

	// Use this for initialization
    void Start() {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
	}

    // Se borra el objeto cuando ya no hace falta dibujarse
    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy") {
            other.gameObject.SendMessage("Kill");
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Brazzier")  {
            other.gameObject.SendMessage("Activate");
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Ground") {
            Destroy(gameObject);
        }
        
    }
}
