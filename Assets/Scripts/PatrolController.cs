using UnityEngine;
using System.Collections;

public class PatrolController : MonoBehaviour
{
    public float chaseAndReturnSpeed = 5f;
    public float patrolTime = 5f;
    public float patrolDistance = 1f;
    public Transform target;
    private float currentLerpTime;
    private bool playerSighted = false;
    private bool returningToPatrol = false;
    private Vector3 oStartPos;
    private Vector3 oEndPos;
    private Vector3 startPos;
    private Vector3 endPos;
    //private Animator animator;

    public void SetPlayerSighted(bool sight)
    {
        playerSighted = sight;

    }

    public void ReturnToPatrol()
    {
        playerSighted = false;
        returningToPatrol = true;
        endPos = new Vector3(oEndPos.x, transform.position.y, 0);

    }

    public void TurnAround()
    {
        if (transform.rotation.y == 0)
        {
            transform.Rotate(0, 180, 0);
        }
        else
        {
            transform.Rotate(0, -180, 0);
        }
    }

    void Start()
    {
        startPos = transform.position;
        oStartPos = startPos;
        endPos = transform.position - new Vector3(1f, 0f, 0f) * patrolDistance;
        oEndPos = endPos;
        currentLerpTime = 0f;
        //animator = GetComponent<Animator>();
    }

    protected void Update()
    {
        if (playerSighted == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, chaseAndReturnSpeed * Time.deltaTime);
        }
       // else if (returningToPatrol == true)
   //     {
//
      //  }
        else if (!playerSighted && !returningToPatrol)
        {
            //animator.SetFloat("movementX", startPos.x - endPos.x);
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > patrolTime)
            {
                currentLerpTime = patrolTime;
            }
            float perc = currentLerpTime / patrolTime;
            transform.position = Vector3.Lerp(startPos, endPos, perc);
            if (currentLerpTime == patrolTime)
            {
                TurnAround();
                Vector3 swap = startPos;
                startPos = endPos;
                endPos = swap;
                currentLerpTime = 0f;
            }
        }
    }
}