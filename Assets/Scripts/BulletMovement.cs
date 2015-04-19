using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {
    public float m_speed;

	// Use this for initialization
    void Start() {
        GetComponent<Rigidbody2D>().velocity = transform.right * m_speed;
	}

    // Se borra el objeto cuando ya no hace falta dibujarse
    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Enemy") {
            coll.gameObject.SendMessage("Kill");
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "Brazzier")  {
            coll.gameObject.SendMessage("Activate");
            Destroy(gameObject);

        }
        
    }
}
