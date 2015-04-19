using UnityEngine;
using System.Collections;

public class LeashController : MonoBehaviour
{

    private PatrolController patrolController;

    void Awake()
    {
        patrolController = GetComponent<PatrolController>();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            patrolController.ReturnToPatrol();
        }
    }
}