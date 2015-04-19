using UnityEngine;
using System.Collections;



public class PatrolController : MonoBehaviour {
    public enum State
    {
        PATROLLING,
        FOLLOWING,
        RETURNING
    }

    public float patrolSpeed;
    public float followSpeed;
    public float patrolDistance = 1f;
    private Vector3 patrolStartPosition;
    private Vector3 patrolEndPosition;
    public GameObject player;
    private Rigidbody2D rigidBody;
    public State state;

    public void Start() {
        patrolStartPosition = transform.position;
        patrolEndPosition = transform.position - new Vector3(1f, 0f, 0f) * patrolDistance;
        rigidBody = GetComponent<Rigidbody2D>();
        state = State.PATROLLING;
        rigidBody.velocity = -Vector2.right * patrolSpeed;
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
    }
    public void TurnAround() {
        if (transform.rotation.y == 0) {
            transform.Rotate(0, 180, 0);
        }
        else {
            transform.Rotate(0, -180, 0);
        }
    }
    
    private void Patrol() {
        if (transform.position.x >= patrolStartPosition.x) {
            rigidBody.velocity = -Vector3.right * patrolSpeed;
            TurnAround();
        }
        else if (transform.position.x <= patrolEndPosition.x) {
            rigidBody.velocity = Vector3.right * patrolSpeed;
            TurnAround();
        }
        Debug.Log(rigidBody.velocity);
    }

    private void FollowPlayer() {
        Vector2 velocity = new Vector2(player.transform.position.x - transform.position.x, 0f);
        GetComponent<Rigidbody2D>().velocity = velocity.normalized * followSpeed;
    }

    private void ReturnToPosition() {
        if (Vector2.Distance(transform.position, patrolStartPosition) <= 0.1f)
        {
            state = State.PATROLLING;
        }
        Vector2 velocity = new Vector2(patrolStartPosition.x - transform.position.x, 0f);
        GetComponent<Rigidbody2D>().velocity = velocity.normalized * patrolSpeed;
        
    }

    public void OnCollision2DStay(Collision2D coll) {
        if (coll.gameObject.tag == "Edge") {
            state = State.RETURNING;
        }
    }
    
}