using UnityEngine;
using System.Collections;

public class LeashController : MonoBehaviour
{

    public PatrolController patrolController;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            patrolController.ReturnToPatrol();
        }
    }
}