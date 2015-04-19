using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour {

    private Rigidbody2D rigidBody;
    [SerializeField]
    private LayerMask whatIsGround;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!rigidBody.isKinematic && Physics2D.Linecast(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z), whatIsGround))
        {
            rigidBody.gravityScale = 0;
            rigidBody.isKinematic = true;
        }
	}
}
