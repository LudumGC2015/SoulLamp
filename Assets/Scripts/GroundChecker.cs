using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour {

    private Rigidbody2D rigidBody;
    [SerializeField]
    private LayerMask groundMask;

    public void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        groundMask = LayerMask.GetMask("Ground");
    }

    public bool isGrounded() {
        return Physics2D.OverlapCircle(transform.position, 0.2f, groundMask);
    }
}
