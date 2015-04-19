using UnityEngine;
using System.Collections;

public class SightController : MonoBehaviour {

    public PatrolController patrolController;

    void Awake() {
        patrolController = transform.parent.GetComponent<PatrolController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            patrolController.state = PatrolController.State.FOLLOWING;
            patrolController.player = other.gameObject;
        }
    }
}
