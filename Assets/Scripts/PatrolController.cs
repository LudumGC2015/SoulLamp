using UnityEngine;
using System.Collections;

public class PatrolController : MonoBehaviour 
{
    public float patrolTime = 5f;
    public float patrolDistance = 1f;
    private float currentLerpTime;
    private Vector3 startPos;
    private Vector3 endPos;
    //private Animator animator;

    protected void Start()
    {
        startPos = transform.position;
        endPos = transform.position - new Vector3(1f, 0f, 0f) * patrolDistance;
        currentLerpTime = 0f;
        //animator = GetComponent<Animator>();
    }

    protected void Update()
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
            Vector3 swap = startPos;
            startPos = endPos;
            endPos = swap;
            currentLerpTime = 0f;
        }

    }
}