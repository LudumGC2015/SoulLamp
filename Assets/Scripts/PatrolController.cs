using UnityEngine;
using System.Collections;



public class PatrolController : MonoBehaviour {
    public enum State
    {
        PATROLLING,
        FOLLOWING,
        RETURNING
    }
    public float patrolSpeed = 2f;
    public float followSpeed = 3f;
    public float patrolDistance = 1f;
    private Vector3 patrolStartPosition;
    private Vector3 patrolEndPosition;
    public GameObject player;
    private Rigidbody2D rigidBody;
    public State state;
    private Vector3 actualVelocity;

    public void Start() {
        patrolStartPosition = transform.position;
        patrolEndPosition = transform.position - Vector3.right * patrolDistance;
        rigidBody = GetComponent<Rigidbody2D>();
        state = State.PATROLLING;
        actualVelocity = -Vector2.right * patrolSpeed;
    }

    public void FixedUpdate() {
        if (state == State.PATROLLING) {
            Patrol();
        }
        else if (state == State.FOLLOWING) {
            FollowPlayer();
        }
        else if (state == State.RETURNING) {
            ReturnToPosition();
        }
        rigidBody.velocity = actualVelocity;
    }
    public void Flip() {
        transform.Rotate(new Vector3(0f,180f, 0f));
    }
    
    private void Patrol() {
        if (transform.position.x >= patrolStartPosition.x) {
            Flip();
            actualVelocity = -Vector2.right * patrolSpeed;
        } else if (transform.position.x <= patrolEndPosition.x) { 
            Flip();
            actualVelocity = Vector2.right * patrolSpeed;
        }
    }

    private void FollowPlayer() {
        float direction = player.transform.position.x - transform.position.x;
        actualVelocity = new Vector2(direction * followSpeed, rigidBody.velocity.y);
    }

    private void ReturnToPosition() {
        if (Vector2.Distance(transform.position, patrolStartPosition) <= 0.1f)
        {
            state = State.PATROLLING;
        }
        Vector2 velocity = new Vector2(patrolStartPosition.x - transform.position.x, 0f);
        actualVelocity = velocity.normalized * patrolSpeed;
        
    }

    public void OnCollider2DEnter(Collision2D coll) {
        if (coll.gameObject.tag == "Edge") {
            Debug.Log("Collided");
            state = State.RETURNING;
        }
    }
    
}