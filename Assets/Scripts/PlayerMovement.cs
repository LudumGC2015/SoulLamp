using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed = 3f;
    public float jumpForce = 400f;
    public float knockbackForce = 200f;
    
    private Rigidbody2D rigidBody2D;
    private GroundChecker groundChecker;
    private float knockBackTimer = 0f;

    public void Awake() {
        rigidBody2D = GetComponent<Rigidbody2D>();
        groundChecker = GetComponentInChildren<GroundChecker>();
    }

    public void Update() {
        knockBackTimer -= Time.fixedDeltaTime;
        if (knockBackTimer <= 0) {
            Move();
            Jump();
        }
    }

    private void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.isGrounded()) {
            rigidBody2D.AddForce(Vector2.up * jumpForce);
        }
    }

    private void Move() {
        float xVelocity = Input.GetAxis("Horizontal");
        if (xVelocity < 0) {
            Flip(180);
        } else if (xVelocity > 0) {
            Flip(0);
        }
        rigidBody2D.velocity = new Vector2(xVelocity * movementSpeed, rigidBody2D.velocity.y);
    }

    public void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy") {
            rigidBody2D.velocity = Vector2.zero;
            rigidBody2D.AddForce(-transform.right * knockbackForce);
            knockBackTimer = 0.5f;
        }
    }

    private void Flip(float rotation) {
        transform.rotation = Quaternion.Euler(new Vector2(0f, rotation));
    }
}