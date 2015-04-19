using UnityEngine;
using System.Collections;

public class LeashController : MonoBehaviour
{

    public PatrolController patrolController;

    void Awake()
    {
        patrolController = transform.parent.GetComponent<PatrolController>();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            patrolController.state = PatrolController.State.RETURNING;
        }
    }
}