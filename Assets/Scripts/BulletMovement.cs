using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {
    public float m_speed;

	// Use this for initialization
    void Start() {
        GetComponent<Rigidbody2D>().velocity = transform.right * m_speed;
	}
}
