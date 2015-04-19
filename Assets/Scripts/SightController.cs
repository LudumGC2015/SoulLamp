using UnityEngine;
using System.Collections;

public class SightController : MonoBehaviour {

    private PatrolController patrolController;

    void Awake()
    {
        patrolController = GetComponent<PatrolController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            patrolController.SetPlayerSighted(true);
        }
    }
}
