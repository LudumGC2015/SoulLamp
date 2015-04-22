using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour {
    
    private LayerMask groundMask;

    public void Start() {
        groundMask = LayerMask.GetMask("Ground");
    }

    public bool isGrounded() {
        return Physics2D.OverlapCircle(transform.position, 0.2f, groundMask);
    }
}
