using UnityEngine;
using System.Collections;

public class SightController : MonoBehaviour {

    public PatrolController patrolController;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            patrolController.SetPlayerSighted(true);
        }
    }
}
