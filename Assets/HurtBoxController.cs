using UnityEngine;
using System.Collections;

public class HurtBoxController : MonoBehaviour {

    public Rigidbody2D player;

    void OnColliderEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.AddForce(new Vector2(-10f, -10f), ForceMode2D.Impulse);
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
